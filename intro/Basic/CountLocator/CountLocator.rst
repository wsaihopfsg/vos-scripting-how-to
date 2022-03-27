:orphan:

.. _gpio:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Using Count Tool as Locator  
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of two  ``Count`` tools |counttool| to deal with position and rotation of the object-of-interest.
2. Use of the ``Remove blobs`` preprocessor to make sure that there is only 1 shape identified in the region-of-interest (ROI) of the ``Count`` tools |counttool|.  
3. Use of the ``Barcode`` tool |barcodetool| for barcode reading on the object-of-interest. 
4. Use of the ``Contour`` tool |contourtool| to ensure the shape of the cut-out is correct.  

.. table::
  :class: tight-table 

  +------------------+----------------------------------+------------------------------------------------------------------+
  |**Function**      |**Parameters**                    |**Explanation**                                                   |
  +------------------+----------------------------------+------------------------------------------------------------------+
  | |getname|        |``camID``                         |Return the current file name used in the emulator                 |
  +------------------+----------------------------------+------------------------------------------------------------------+
  |``SetMatchString``|``measurementVar``,               |Change the “perfect” value of the barcode/QR code/OCR             |
  |                  |``perfectMatch``                  |``measurementVar`` to  ``perfectMatch``                           |
  +------------------+----------------------------------+------------------------------------------------------------------+
  |``Substring``     |``string``, ``startIndex``,       |Return a substring from ``stratIndex`` for ``length`` characters  |
  |                  |``length``                        |in ``string``. length =0 for the end of string                    |
  +------------------+----------------------------------+------------------------------------------------------------------+
  |``int``           |``string``                        |Return an integer after conversion of the input ``string``        |  
  +------------------+----------------------------------+------------------------------------------------------------------+

.. |getname| replace:: ``GetImageFileName``

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/CountLocator>`__
--------------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``solution09.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/CountLocator/solution09.bin?raw=true>`__              |
  |                                     |                                                                                                                                                    |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |solnsetup| |cir1|, import |import| |cir2| solution   |  
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``demo1280_01.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/CountLocator/demo1280_01.bmp?raw=true>`__ is the same    |
  |                                     |example image provided by the VOS ``Vision Configuration Tool`` software                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``demo1280_02.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/CountLocator/demo1280_02.bmp?raw=true>`__ is the same    |
  |                                     |example image provided by the VOS ``Vision Configuration Tool`` software                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``demo1280_03.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/CountLocator/demo1280_01.bmp?raw=true>`__ is the same    |
  |                                     |example image provided by the VOS ``Vision Configuration Tool`` software                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |5. ``demo1280_04.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/CountLocator/demo1280_01.bmp?raw=true>`__ is the same    |
  |                                     |example image provided by the VOS ``Vision Configuration Tool`` software                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``demo1280_05.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/CountLocator/demo1280_01.bmp?raw=true>`__ is the same    |
  |                                     |example image provided by the VOS ``Vision Configuration Tool`` software                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |7. ``demo1280_06.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/CountLocator/demo1280_01.bmp?raw=true>`__ is the same    |
  |                                     |example image provided by the VOS ``Vision Configuration Tool`` software                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``demo1208_07.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/CountLocator/demo1280_01.bmp?raw=true>`__ is the same    |
  |                                     |example image provided by the VOS ``Vision Configuration Tool`` software                                                                            |
  |                                     |                                                                                                                                                    |
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                   |
  |                                     |                                                                                                                                                    |
  |                                     |  set |demoimg| |cir2|                                                                                                                              |
  |                                     |                                                                                                                                                    |  
  |                                     |  to the folder where these images have been saved                                                                                                  |
  |                                     |                                                                                                                                                    |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``demo1280_01.bmp`` is loaded. 

.. image:: /intro/Basic/CountLocator/toolsetup.jpg

* 2 ``Count`` tools |counttool| have been used

  * A ``Count`` tool |counttool| named ``N`` with the ROi set to the lower left corner of the image. Its properties are as shown below, detecting white objects

    .. image:: /intro/Basic/CountLocator/countlocposprop.jpg

    * 2 preprocessors |preprocessortool| have been used
    
      .. image:: /intro/Basic/CountLocator/prepro1.jpg

      * A ``threshold`` tool with threshold set at 128, converting the input image to binary
      * A ``Remove Blobs`` tool with its properties set so that all other white blobs are removed except for the circle. This ensures that the ``Count`` |counttool| tool detects only the circle and not multiple shapes
    
      .. warning:: 
        When multiple shapes are found by the ``Count`` tool |counttool|, their index is given by the program at random. Without the ``Remove blobs`` preprocessor, there is no way to ensure that the circular shape of interest will be given the first index.

    * The centre point of the shape found named ``PP`` serves as locator 1's position
    
    .. image:: /intro/Basic/CountLocator/ppprop.jpg
       :width: 300px

  * Another identical ``Count`` tool |counttool| named ``N1`` with the ROi set to the lower right corner of the image, detecting white objects
    
    * The exact same 2 preprocessors |preprocessortool| as above have been used to remove all white blobs other than the circle-of-interest.

    * The centre point of the shape found named ``PP1`` serves as locator 1's rotation
 
    .. image:: /intro/Basic/CountLocator/pp1prop.jpg
       :width: 300px

  * A ``Barcode`` tool |barcodetool| named ``Bar`` which is anchaored to Locator 1 

  .. image:: /intro/Basic/CountLocator/barprop.jpg

  * A ``Contour`` tool |contourtool| named ``Contour`` which tracks the shape of the cut-out

  .. image:: /intro/Basic/CountLocator/contourprop.jpg
  
Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  


Solution Initialize
###################
* Choose the predefined function ``Solution Initialize`` at the bottom left 
  |fn_init|

* In the Script Function window we see the initialization for the perfect string of the barcode of the various images stored in the array ``perfStr``.

.. code-block::
  :linenos:
    
  perfStr.1 = "S9009535"
  perfStr.2 = "S3815131"
  perfStr.3 = "S9006206"
  perfStr.4 = "S3685070"
  perfStr.5 = "S3569129"
  perfStr.6 = "S3569129"
  perfStr.7 = "S9009535"

Pre Image Process
##################
* Choose the predefined function ``Pre Image Process`` at the bottom left 
  |fn_pre|

* In the Script Function window we see

.. code-block::
  :linenos:

  nowName = GetImageFileName(0)
  imgNo = int(Substring( nowName, strlen(nowName)-6,2 ))
  SetMatchString (bar,perfStr.[imgNo])
  SetDisplayStatus( 0,0 )

* Line 1: Get the name of the current image under inspection and return it to ``nowName``
* Line 2: Get the image number and return it to ``imgNo``
* Line 3: Set the match string of ``bar`` with the ``perfStr`` array and ``imgNo``
* Line 4: Reset the Inspection Status output
  
Post Image Process
##################
* Choose the predefined function ``Post Image Process`` at the bottom left 
  |fn_post|

* In the Script Function window we see 

.. code-block::
  :linenos:

  barRe = Bar.Result
  conRe = ContourFailedSections.Result
  if(Result.0 = 3  ) 
      if(barRe=3  ) 
          SetDisplayStatus( "Barcode Failed", "red")
      else
          SetDisplayStatus( "Contour Failed", "red")
      endif
  endif


* Line 1: Get the result of the barcode inspection and return to ``barRe``, compared against the perfect string for each image
* Line 2: Get the result of the contour inspection and return to ``conRe``
* Line 3: If the overall result is a failure
* Line 4-5: If it is barcode that fails, display on ``Insepction Status`` output
* Line 6-7: If it is contour that fails, display on ``Insepction Status`` output
  

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2| 

+-------------------------------------------------+-------------------------------------------------+
||1|                                              ||2|                                              |
|                                                 |                                                 |
|``demo1280_01.bmp``                              |``demo1280_02.bmp``                              |
+-------------------------------------------------+-------------------------------------------------+
||3|                                              ||4|                                              |
|                                                 |                                                 |
|``demo1280_03.bmp``                              |``demo1280_04.bmp``                              |
+-------------------------------------------------+-------------------------------------------------+
||5|                                              ||6|                                              |
|                                                 |                                                 |
|``demo1280_05.bmp``                              |``demo1280_06.bmp``                              |
+-------------------------------------------------+-------------------------------------------------+
||7|                                              |                                                 |
|                                                 |                                                 |
|``demo1280_07.bmp``                              |                                                 |
+-------------------------------------------------+-------------------------------------------------+

.. Tip::
  #preprocessor #threshold #remove #blobs #locator #count #contour

.. |1| image:: /intro/Basic/CountLocator/1.jpg
  :width: 400px

.. |2| image:: /intro/Basic/CountLocator/2.jpg
  :width: 400px

.. |3| image:: /intro/Basic/CountLocator/3.jpg
  :width: 400px

.. |4| image:: /intro/Basic/CountLocator/4.jpg
  :width: 400px

.. |5| image:: /intro/Basic/CountLocator/5.jpg
  :width: 400px

.. |6| image:: /intro/Basic/CountLocator/6.jpg
  :width: 400px

.. |7| image:: /intro/Basic/CountLocator/7.jpg
  :width: 400px
