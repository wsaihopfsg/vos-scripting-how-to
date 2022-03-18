:orphan:

.. _refcir:

.. toctree::
  
.. include:: /shared/EmulatorComponents.rst

Compute Size of Rectangles 
++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

#. A scale-invariant VOS solution
#. Using socket to control parameters
#. Remote triggering
#. How to create a user-defined function
#. String formatting in VOS scripting
#. Overwriting ``PASS``. ``FAIL`` & ``RECYCLE`` results

.. note::
  The solution uses a circle, placed at the most left position, as having an user-supplied reference diameter of ``cirD`` units. Rectangles of random sizes and orientation are place at random, and the following properties will be computed for these rectangles.

  * L: Length in units
  * W: Width in units
  * R: Rotation angle in degree
  * D: Distance of the centre of the rectangle from the centre of the reference circle, in units

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/RefCirSizeRect>`__
-------------------------------------------------------------------------------------------------------------

+-------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|1.``RefCirSizeRect.bin``       |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/RefCirSizeRect.bin?raw=true>`__            |
|                               |                                                                                                                                                       |
|                               |* At the :hoverxreftooltip:`Solution Setup page <soln/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| ,                                            |
|                               |                                                                                                                                                       |
|                               |  import |import| |cir2| the solution                                                                                                                  |
+-------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|2.``test0.bmp``                |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/test0.bmp?raw=true>`__                        |   
|                               |reference circle with diameter of 1 unit.                                                                                                              |    
+-------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+ 
|3.``test1.bmp``                |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/test1.bmp?raw=true>`__                        |
|                               |for reference shape failure.                                                                                                                           |
+-------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|4.``test2.bmp``                |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/test2.bmp?raw=true>`__                        | 
|                               |reference circle with diameter of 3 unit.                                                                                                              |
+-------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|5.``test3.bmp``                |`Another image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/RefCirSizeRect/test3.bmp?raw=true>`__                    |
|                               |reference circle with diameter of 3 unit.                                                                                                              |
|                               |                                                                                                                                                       |
|                               |* At the :hoverxreftooltip:`Sensor Setup page <soln/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                             |
|                               |                                                                                                                                                       |
|                               |  set |demoimg| |cir2|                                                                                                                                 |
|                               |                                                                                                                                                       |
|                               |  to the folder where the image files have been saved.                                                                                                 |
+-------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <soln/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``test0.bmp`` is loaded. 

.. image:: /soln/RefCirSizeRect/test0.jpg

* From the ``Tool List``, 2 tools have been used

  * A ``Preprocess`` tool named ``Pre`` whose region-of-interest (ROI) covers the whole picture
  * A ``Count`` tool |counttool| named ``N`` with the following properties enabled

    * Area
    * Major
    * Minor
    * X
    * Y
    * Angle
    * Centre point

* Right-click on the row occupied by the preprocessor ``Pre`` in the ``Tool List``, to bring up properties of ``Pre``. Drag the ``Preprocess Properties`` window so that it is not blocking the main picture. The 2 preprocessors used in ``Pre`` are

  #. ``Threshold``, ``Level`` = 230. It converts the greyscale picture to binary.
  #. ``Median``, ``Width`` = 11. It removes salt-and-pepper noise.

Connections
-----------
* Click on :hoverxreftooltip:`Setup Connections <soln/Hover/setupconntcp:Setup Connections>` |conn| |cir1|. We are using the ``VOS emulator`` as a ``TCP socket server``, at ``port 5025`` with the name ``TcpP5025``.  

.. image:: /soln/RefCirSizeRect/tcp5025.jpg 

.. note::
  The ``VOS emulator`` can be configured as a ``TCP client`` also, for which the IP address and port of the ``TCP server`` needs to be provided for connection setup. Please refer to :doc:`Publishing VOS Data to MQTT </intro/Advanced/MQTT/MQTT>`

Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <soln/Hover/editscript:Edit Script>` |edit| |cir1|. Notice that in addition to the 4 standard functions, there are 2 user-defined functions 
  
  #. findLeftMostShape()
  #. calcRectSizeDist() 

Solution Initialize
###################
* Choose the predefined function ``Solution Initialize`` at the bottom left 
  |fn_init_here|

* In the Script Function window we see 3 variables being initialized

   * ``cirD`` which is the default diameter of the reference circle. It can be changed based on user input during software trigger.
   * ``tolCir`` fixed to 0.95, defining the tolerance for ratio of ``Minor Axis`` to ``Major Axis`` of the left-most shape
   * ``areaFact`` fixed to 1.3 is a heuristic ratio threshold between the area returned by the ``Area`` property of the ``Count`` tool against the value computed from the product of ``Major`` and ``Minor`` of the same shape. It is to distinguish between a square from a circle.
  
.. code-block::
   :linenos:

   cirD = 1
   tolCir = 0.95
   areaFact = 1.3

Periodic Function
#################

* Choose the predefined function ``Periodic: 200ms`` at the bottom left 
  |fn_period_here|

* In the Script Function window we see 

.. _period:
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

* Line 1: Attempts to read from the configured TCP socket port and scans for ``<CR>`` character (ASCII 13)
* Line 4 (high-lighted): Read from ``CommandString`` from character 0 for 1 chracter and output to ``CommandCharacter``
* Line 6 (high-lighted):  Read from ``CommandString`` from character 1 for 1 chracter and output to ``ProgramNumber``
* Line 7: Check if ``ProgramNumber``>0, if so pass the value to ``cirD`` in Line 8

.. note::  
  * In this version, only single digit diameter is used
  
* Line 10: Check if ``CommandCharacter`` = ``T``, if perform software ``trigger()`` in Line 11
  
Post Image Process
##################
* Choose the predefined function ``Post Image Process`` at the bottom left 
  |fn_post_here|

* In the Script Function window we see 

.. code-block::
    :linenos:
    :emphasize-lines: 5,22

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

* Lines 3-5 uses a user-defined function :ref:`findLeftMostShape() <findL>` to compute the shape index ``minShape`` of the left-most object at ``minX`` resulting from the ``Count`` tool. 
* Lines 9-10 uses ``minShape`` to obtain the ``Major`` & ``Minor`` axes and return them to ``MajorCir`` & ``MinorCir``
* Line 11 computes the average of ``MajorCir`` & ``MinorCir``
* Line 12 ``minY`` is the y-coordinate of the left most shape
* Line 13 ``err`` is the error index, initialized to ``0`` 
  
  * 0: no error
  * 1: bad reference shape
  
* Line 14 checks if the ratio of ``MinorCir`` to ``MajorCir`` is within tolerance set by ``tolCir``, since we know that the ratio for a perfect circle is close to 1.
* Lines 15-16 handles the case when the ratio is not within tolerance, and the left-most shape is definitely not circular
* Line 18 uses a heuristic threshold ``areaFact`` to determine whether a shape is circular or squarish, since both shapes will pass the ``tolCir`` test  earlier.
* Lines 19-20 handles the case when the left-most shape is squarish and not circular
* Line 22 uses a user-defined function :ref:`calcRectSizeDist() <calc>` to compute the dimensions of the other shapes, using the left-most circular shape as reference. The relevant information is output to ``opStr``.
* Lines 26-29 outputs the ``opStr`` to the screen with ``SetDisplayStatus`` if there is error index indicates no error.
* Line 31 outputs the ``opStr`` error message to the screen with ``SetDisplayStatus`` in red. 
* Lines 32-34 overwrites the ``Result`` variable to ``FAIL``. Note that all 3 built-in variables ``PASS``, ``FAIL`` & ``RECYCLE`` must be in CAPS.

.. note::
  * The ``Special Global Variable`` named ``Result`` returns the overall inspection result, defined as
    
    * ``PASS``: Result = 1
    * ``RECYCLE``: Result =2
    * ``FAIL``: REsult =3
  
  * ``Result.0`` returns the value of ``Result`` before it is output, allowing the script to make changes before sending the final ``Result`` to the screen & decision I/Os. ``Result.0`` takes the same values as defined above for ``PASS`` , ``FAIL`` & ``RECYCLE``
  
* Line 36 writes the ``opStr`` to the TCP socket ``TcpP5025``

findLeftMostShape()
====================

.. _findL:

* Choose the predefined function ``findLeftMostShape()`` at the bottom left 
  |fn_left_here|, and the following code will be shown

.. code-block::
    :linenos:
 
    nowCtr = 0
    while( nowCtr < N )
        nowX = CountX.[nowCtr]
        if(  nowX < minX) 
            minX = nowX
            minShape = nowCtr
        endif
        nowCtr = nowCtr+1
    endwhile
    Return(0)

* findLeftMostShape() uses a ``while`` loop to cycle through all shapes' x-coordinates detected by the ``Count`` tool.
  
  * ``minShape``: The shape index of the left-most shape 
  * ``minX``: The x-coordinate of the left-most shape 
  * Notice that we are not returning these values by the ``Return()`` function. In fact every variable created has global scope and is not destroyed after the user-defined function has ``Return()``.

calcRectSizeDist()
====================

.. _calc:

* Choose the predefined function ``calcRectSizeDist()`` at the bottom left 
  |fn_calc_here|, and the following code will be shown

.. code-block::
    :linenos:

    adjFact = sqrt(4/3) / cirD
    RefCir = MeanCir* adjFact
    opStr1 = "Ref Circle Diameter = [cirD%d] units\r\n"
    nowCtr = 0
    while (nowCtr < N )
        if(nowCtr != minShape) 
            rectL = Major.[nowCtr] / RefCir
            rectW = Minor.[nowCtr] / RefCir
            rectRot = CountAngle.[nowCtr]
            rectDist = sqrt((CountX.[nowCtr]-minX)*(CountX.[nowCtr]-minX) + (CountY.[nowCtr]-minY)*(CountY.[nowCtr]-minY)) / MeanCir
            opStr1 = opStr1 + "Rect" + FormatString( "[nowCtr%d]") + " L:"+ FormatString("[rectL%.2f]") + " W:" + FormatString("[rectW%.2f]") + " R:" + FormatString("[rectRot%.1f]") +Char(176)
            opStr1 = opStr1 + " D:" + FormatString("[rectDist%.2f]") +"\r\n"
        endif
        nowCtr = nowCtr +1
    endwhile
    Return(opStr1)

* Line 1: ``adjFact`` is a heuristic factor that takes into account of the user-input reference circle diameter ``cirD``.
* Line 2: ``RefCir`` is a factor that links ``Major`` & ``Minor`` axes values as measured by VOS to actual measurements in units.
* Lines 5-15: The ``while`` loop goes through all shapes except for the reference and computes
  
  * Line 7: ``Major`` axis (length) as ``rectL``
  * Line 8: ``Minor`` axis (width) as ``rectW``
  * Line 9: ``CountAngle`` as ``rectRot``
  * Line 10: Distance of the centre of the shape from the centre of the reference as ``rectDist``
  * Line 11-12: Output string, which is returned in Line 16

Running the solution
--------------------

* Click on the :hoverxreftooltip:`Run Solution page <soln/Hover/runsoln:Run Solution>` |runsoln| |cir1|
* Get a phone connected as the same WiFi network as the PC. Download app that, for example ``Simple TCP Socket Tester`` for Android

.. image:: /soln/RefCirSizeRect/tcpSocketApp.jpg
   :width: 240pt
   


* The phone is the ``TCP socket client`` while ``VOS emulator`` as the ``TCP socket server``. Connect to the PC's IP address (in this case 192.168.10.143) and configured port (5025) for ``VOS emulator``

.. image:: /soln/RefCirSizeRect/tcpSocketStep1.jpg
   :width: 240pt

* Choose to enter values as ``HEX``, and type ``54310D`` and press ``SEND``

  * #54 is the ASCII character ``T`` , for :ref:`Software Trigger <period>`

  * #31 is the ASCII character ``1``, as the user-input reference circle diameter of 1 unit

  * #0D is the ``<CR>`` character, which the ``periodic function`` checks for :ref:`end of a command <period>`

* The following should be shown on the phone and the ``VOS emulator`` 
  
+-------------------------+-------------------------+
||test0phone|             ||test0result|            |
+-------------------------+-------------------------+
|Phone                    |VOS Emulator             |
+-------------------------+-------------------------+

* Press ``SEND`` again with ``54310D`` unchanged, the following error should be shown on the phone and the ``VOS emulator`` because the left-most shape is not circular

+-------------------------+-------------------------+
||test1phone|             ||test1result|            |
+-------------------------+-------------------------+
|Phone                    |VOS Emulator             |
+-------------------------+-------------------------+

* Change the HEX string to ``54330D``, here we are informing VOS that the reference diameter is 3 units (#33). Press ``SEND``, the following should be shown on the phone and the ``VOS emulator`` 

+-------------------------+-------------------------+
||test2phone|             ||test2result|            |
+-------------------------+-------------------------+
|Phone                    |VOS Emulator             |
+-------------------------+-------------------------+

* Press ``SEND`` again with ``54330D`` unchanged, the following should be shown on the phone and the ``VOS emulator``

+-------------------------+-------------------------+
||test3phone|             ||test3result|            |
+-------------------------+-------------------------+
|Phone                    |VOS Emulator             |
+-------------------------+-------------------------+

.. note::
  An advanced tutorial for integrating this solution with c# can be found :ref:`here <csharp>`.

.. tip::
  #scale-invariant #socket #tcp #remote #trigger #user-defined #function #string #format #results #over-writing

.. |fn_init_here| image:: /soln/RefCirSizeRect/fnSolnInit.jpg

.. |fn_period_here| image:: /soln/RefCirSizeRect/fnPeriodic.jpg

.. |fn_post_here| image:: /soln/RefCirSizeRect/fnPostImgProc.jpg  

.. |fn_left_here| image:: /soln/RefCirSizeRect/fnLeft.jpg    

.. |fn_calc_here| image:: /soln/RefCirSizeRect/fnCalc.jpg    

.. |test0phone| image:: /soln/RefCirSizeRect/test0phone.jpg

.. |test1phone| image:: /soln/RefCirSizeRect/test1phone.jpg

.. |test2phone| image:: /soln/RefCirSizeRect/test2phone.jpg

.. |test3phone| image:: /soln/RefCirSizeRect/test3phone.jpg

.. |test0result| image:: /soln/RefCirSizeRect/test0Re.jpg

.. |test1result| image:: /soln/RefCirSizeRect/test1Re.jpg

.. |test2result| image:: /soln/RefCirSizeRect/test2Re.jpg

.. |test3result| image:: /soln/RefCirSizeRect/test3Re.jpg