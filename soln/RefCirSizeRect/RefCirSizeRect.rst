.. include:: /shared/EmulatorComponents.rst

Using a Reference Circle to Compute Size of Rectangles 
++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates
#. A scale-invariant VOS solution
#. Using socket to control parameters
#. Remote triggering
#. How to create a user-defined function
#. String formatting in VOS scripting
#. Overwriting ``PASS``. ``FAIL`` & ``RECYCLE`` results

The solution uses a circle, placed at the most left position, as having an user-supplied reference diameter of ``cirD`` units. Rectangles of random sizes and orientation are place at random, and the following properties will be computed for these rectangles.
* L: Length in units
* W: Width in units
* R: Rotation angle in degree
* D: Distance of the centre of the rectangle from the centre of the reference circle, in units

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/RefCirSizeRect>`__
-------------------------------------------------------------------------------------------------------------

#. ``RefCirSizeRect.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/RefCirSizeRect.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
#. ``test0.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/test0.bmp?raw=true>`__ reference circle with diameter of 1 unit.
#. ``test1.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/test1.bmp?raw=true>`__ for reference shape failure
#. ``test2.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/test2.bmp?raw=true>`__ reference circle with diameter of 3 unit.
#. ``test3.bmp``: `Another image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/test3.bmp?raw=true>`__ reference circle with diameter of 3 unit.

   * At the Sensor Setup page |sensorsetup|, set |demoimg| to the folder where the image files have been saved.

Tools Explanation
-----------------
* At the ``Tool Setup`` page |toolsetup|, click on |takepic| until ``test0.bmp`` is loaded. 

.. image:: /soln/RefCirSizeRect/test0.jpg

* From the ``Tool List``, 2 tools have been used

  * A ``Preprocess`` tool named ``Pre`` whose region-of-interest (ROI) covers the whole picture
  * A ``Count`` tool named ``N`` with the following properties enabled
    * Area
    * Major
    * Minor
    * X
    * Y
    * Angle
    * Centre point

* Right-click on the row occupied by the preprocessor ``Pre`` in the ``Tool List``, to bring up properties of ``Pre``. Drag the ``Preprocess Properties`` window so that it is not blocking the main picture. The 2 preprocessors used in ``Pre`` are

  #. Threshold, Level = 230. It converts the greyscale picture to binary.
  #. Median, Width = 11. It removes salt-and-pepper noise.

Connections
-----------
* Click on ``Setup Connections`` |conn|. We are using the VOS emulator as a ``TCP socket server``, at ``port 5025`` with the name ``TcpP5025``. Note that the VOS emulator can be configured as a ``TCP client`` also, for which the IP address and port of the ``TCP server`` needs to be provided for connection setup.

.. image:: /soln/RefCirSizeRect/tcp5025.jpg 

Code Walk-Through
-----------------
* Click on ``Edit Script`` |edit|. Notice that in addition to the 4 standard functions, there are 2 user-defined functions 
  
  #. findLeftMostShape()
  #. calcRectSizeDist() 

Solution Initialize
###################
* Choose the predefined function ``Solution Initialize`` at the bottom right 
  |fn_init|

* In the Script Function window we see 3 variables being initialized

   * ``cirD`` which is the default diameter of the reference circle. It can be changed based on user input during software trigger.
   * ``tolCir`` fixed to 0.95 //todo explain what does this mean
   * ``areaFact`` fixed to 1.3 //todo explain what does this mean
  
.. code-block::
   :linenos:

   cirD = 1
   tolCir = 0.95
   areaFact = 1.3

Periodic Function
#################
* Choose the predefined function ``Periodic: 200ms`` at the bottom right 
  |fn_periodic|

* In the Script Function window we see 

.. code-block::
    :linenos:
    :emphasize-lines: 6, 4

    ReadBuffer = ReadString( TcpP5025 , 13 )
    if(ReadBuffer!= "") // if NOT an empty data string
        CommandString = ReadBuffer
        CommandCharacter = Substring(CommandString, 0, 1)
        // trigger command
        ProgramNumber = Substring(CommandString, 1, 1)
        if(INT(ProgramNumber) > 0) // cirD
            cirD = INT(ProgramNumber)
        endif
        if(CommandCharacter="T") 
            trigger()
        endif
    endif

* Line 1: Attempts to read from the configured TCP socket port and scans for ``CR`` character (ASCII 13)
* Line 4 (high-lighted): Read from ``CommandString`` from character 0 for 1 chracter and output to ``CommandCharacter``
* Line 6 (high-lighted):  Read from ``CommandString`` from character 1 for 1 chracter and output to ``ProgramNumber``
* Line 7: Check if ``ProgramNumber``>0, if so pass the value to ``cirD`` in Line 8
* Line 10: Check if ``CommandCharacter`` = ``T``, if perform software ``trigger()`` in Line 11
  
Post Image Process
##################
* Choose the predefined function ``Post Image Process`` at the bottom right 
  |fn_post|

* In the Script Function window we see 

.. code-block::
    :linenos:
    :emphasize-lines:

    ////////Find left most shape start//////
    //
    minX = 1281
    minShape = 100
    findLeftMostShape( )
    //
    /////Check left most shape start//////
    //
    MajorCir = Major.[minShape]
    MinorCir = Minor.[minShape]
    MeanCir = (MajorCir + MinorCir)/2
    minY = CountY.[minShape]
    err = 0
    if( MinorCir / MajorCir < tolCir ) 
        err = 1 //bad shape
        opStr = "Ref shape not circular!\r\n"
    else
        if( MajorCir * MinorCir / Area.[minShape]  > areaFact) // square
            err = 1 //bad shape
            opStr = "Ref shape not circular!\r\n"
        else
            opStr = calcRectSizeDist( )
        endif
    endif
    if(err=0) 
        SetDisplayStatus( opStr,"darkgreen" )
        PASS = 1
        RECYCLE = 0
        FAIL = 0
    else
        SetDisplayStatus( opStr,"red" )
        PASS = 0
        RECYCLE = 0
        FAIL = 1
    endif
    WriteFormatString(TcpP5025 , opStr)

* The code uses the count value ``N`` to decide whether to pass or fail the scratch inspection, and output by ``SetDisplayStatus`` with the number of scratches detected.

Running the solution
####################

* At the ``Run Solution`` |runsoln| page, click on ``Manual Trigger`` |manTrig| button to toggle between the 2 pictures

+-------------------------+
||pass|                   |
+-------------------------+
|                         |
+-------------------------+
||fail|                   |
+-------------------------+

#multiple #preprocessor #scratch #detection #remove #blob #erode #dilate #stacking #stack

.. |pass| image:: /soln/Scratch/pass.jpg

.. |fail| image:: /soln/Scratch/fail.jpg
