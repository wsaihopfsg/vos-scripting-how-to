:orphan:

.. _gpio:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Presence / Absence Detection with GPO In Diverse Lighting 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of the  ``Match`` tool |matchtool| and ``Locator`` to deal with position and rotation of the object-of-interest
2. Use of the ``erode`` & ``normalize`` preprocessor for dealing with diverse lighting conditions 
3. Use of the ``Intensity`` tool |intensitytool| for plastic cover presence detection
4. Image logging 
5. Use the the ``GetBit``, ``SetBit`` , ``ClearBit`` & ``pulse`` functions

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``GetBit``        |``value``, ``bitPosition``        |Return the bit state of ``bitPosition`` in ``value``              |
+------------------+----------------------------------+------------------------------------------------------------------+
|``SetBit``        |``value``, ``bitPosition``        |Return the value after setting the bit state of ``bitPosition``   |
|                  |                                  |to 1 in ``value``                                                 |
+------------------+----------------------------------+------------------------------------------------------------------+
|``ClearBit``      |``value``, ``bitPosition``        |Return the value after clearing the bit state of ``bitPosition``  |
|                  |                                  |to 0 in ``value``                                                 |
+------------------+----------------------------------+------------------------------------------------------------------+
|``pulse``         |``activeVal``,                    |``activeVal``: 1 is active-high, 0 is active low                  |
|                  |                                  |                                                                  |
|                  |``offsetMillisec``,               |``offsetMillisec``: Delay of execution of pulsing in ms           |
|                  |                                  |                                                                  |
|                  |``durationMillisec``              |``durationMillisec``: Pulse duration in ms                        |
+------------------+----------------------------------+------------------------------------------------------------------+

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/GPIO>`__
------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``preAbsence.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/preAbsence.bin?raw=true>`__                      |
  |                                     |                                                                                                                                                    |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |solnsetup| |cir1|, import |import| |cir2| solution   |  
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``nolight1.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/nolight1.bmp?raw=true>`__ without plastic cover     |
  |                                     |taken in a room with natural window light but no ceiling light                                                                                      |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``nolight1a.bmp``                 |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/nolight1a.bmp?raw=true>`__ is a rotated version of  |
  |                                     |``nolight1.bmp``                                                                                                                                    |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``nolight2.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/nolight2.bmp?raw=true>`__ with plastic cover taken  |
  |                                     |in a room with no ceiling light                                                                                                                     |               
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |5. ``bright1.bmp``                   |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/bright1.bmp?raw=true>`__ with plastic cover taken in| 
  |                                     |a room with natural window light and ceiling light on                                                                                               |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``bright2.bmp``                   |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/bright2.bmp?raw=true>`__ without plastic cover taken| 
  |                                     |in a room with natural window light and ceiling light on                                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |7. ``rmFlash1.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmFlash1.bmp?raw=true>`__ without plastic cover     |
  |                                     |taken in a totally dark room with camera flash                                                                                                      |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``rmFlash2.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmFlash2.bmp?raw=true>`__ with plastic cover taken  |
  |                                     |in a totally dark room with camera flash                                                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |9. ``rmLight1.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmLight1.bmp?raw=true>`__ with plastic cover taken  |
  |                                     |in a windowless room with ceiling light                                                                                                             |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |10. ``rmLight2.bmp``                 |`Another image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmLight2.bmp?raw=true>`__ taken in the same     |
  |                                     |conditions as ``rmLight1.bmp``                                                                                                                      |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |11. ``rmLight3.bmp``                 |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmLight3.bmp?raw=true>`__ without plastic cover     |
  |                                     |taken in a windowless room with ceiling light                                                                                                       |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |12. ``rmFlash1a.bmp``                |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmFlash1a.bmp?raw=true>`__ is a rotated version of  |
  |                                     |``rmFlash1.bmp`` and serves as the template for Tool Setup |toolsetup|                                                                              |
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
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``rmFlash1a.bmp`` is loaded. 

.. image:: /intro/Basic/GPIO/toolsetup.png

* 2 tools have been used

  * A ``Match`` tool |matchtool| named ``MS``, matching with |CE| symbol

    .. image:: /intro/Basic/GPIO/matchproperties.png
       :width: 300px

    .. note::  
       Due to variation in lighting, the ``Method`` used is based on ``Edges only`` instead of ``All pixels``. The ``Required score`` has been lowered also.

    * Its centre point named ``PP`` serves as locator 1's position
    
    .. image:: /intro/Basic/GPIO/ppproperties.jpg
       :width: 300px
    
    * One of its corner points named ``PP1`` serves locator 1's angle of rotation
 
    .. image:: /intro/Basic/GPIO/pp1properties.jpg
       :width: 300px

  * 3 ``Intensity`` tools |intensitytool| named ``Live``, ``Neutral``, ``Earth`` 
    
    * The ROI (region of interest) of the tool is chosen to be the same as the size of the live, neutral and earth pins. When the plastic cap is on, the whole ROI should ideally lie within the white area.
 
    .. image:: /intro/Basic/GPIO/ROIinwhite.jpg

    * Each has preprocessors ``Erode`` followed by ``Normalize`` turned on 

      .. image:: /intro/Basic/GPIO/intensityproperties.jpg
  
      * ``Erode`` preprocessor helps reduce probability of making the wrong decision. For example in ``rmFlash1a.bmp``, the metal live and neutral pins may appear white in the presence of strong light reflecting from the camera flash. ``Erode`` erodes the amount of white present on the metal pin, as apparent in the picture below where the white area in the live pin is smaller after ``Erode`` than the neutral pin which remains uneroded. 

      .. image:: /intro/Basic/GPIO/erodevsnoerode.jpg 

      .. note::
        If the ROI is totally white i.e. on the plastic cap, erode will have no effect because there is no boundary

      .. note::
        The dual of ``Erode`` is ``Dilate``, which makes white patches bigger
      
      * ``Normalize`` preprocessor helps to adjust the pixel values to the full range from 0-255. This is useful in this example in which the lighting can be of diverse sources, so that after ``Normalize`` a single threshold value can be used.

      .. note::
        ``Normalize`` & ``Equalize`` perform similar functions of extending the pixel intensities to the full range of 0-255. However they are not the same. Please refer to the VOS manual and online resources to learn more about the differences between these 2 preprocessors.

        ``Normalize`` : Adjust the pixel intensities to cover the full range from 0 to 255. Remove Min% and Max% intensity pixels before adjusting.

        ``Equalize`` : broadens image intensity to span the entire range from 0 to 255. The darkest pixels in the area will be set to 0; the brightest pixels in the area will be set to 255. Other pixels are set based on a statistical normalization of the intensity histogram.


Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  


Solution Initialize
###################
* Choose the predefined function ``Solution Initialize`` at the bottom left 
  |fn_init|

* In the Script Function window we see only 1 line of threshold initialization for ``Thres``

.. code-block::
    :linenos:
    
    Thres = 172 //heuristic

.. note::
  The threshold value is heuristically chosen

Post Image Process
##################
* Choose the predefined function ``Post Image Process`` at the bottom left 
  |fn_post|

* In the Script Function window we see 

.. code-block::
    :linenos:

    //init to uncover (=0)
    cover.0 = 0 //live
    cover.1 = 0 //neutral
    cover.2 = 0 //earth
    if(Live >= Thres) 
        cover.0 = 1
    endif
    if(Neutral >= Thres) 
        cover.1 = 1
    endif
    if(Earth >= Thres) 
        cover.2 = 1
    endif
    cover.3 = cover.0 + cover.1 + cover.2
    if(cover.3 = 0) 
        PASS = 0
        RECYCLE = 0
        FAIL = 1
        SetDisplayStatus( "Uncovered", "red")
        GLOBAL.GPO[0] = pulse(1,0,600)
    else
        if(cover.3 = 3) 
            PASS = 1
            RECYCLE = 0
            FAIL = 0
            SetDisplayStatus( "Covered", "green")
            GLOBAL.GPO[1] = pulse(1,0,600)
        else
            PASS = 0
            RECYCLE = 1
            FAIL = 0
            SetDisplayStatus( "Ambiguous", "magenta")
            GLOBAL.GPO[2] = pulse(1,0,600)
        endif
    endif
    a.0 = ClearBit(255, 5)
    a.1 = GetBit(255, 5)
    a.2 = SetBit(0, 5)


* Lines 1-4: The array ``cover`` which stores the decision result for the live, neutral & earth pins, and is initialized to 0 (uncovered).
  
  * 0 means pin is uncovered
  * 1 means pin is covered

* Lines 5-13: If the average intensity is above ``Thres``, set the corresponding ``cover`` value to 1 (covered)
* Line 14: Sum the values for the array ``cover`` and store as the 4th element in ``cover``
* Lines 15-20: Sum=0, meaning all 3 pins are 0 (uncovered)
  
  * Set ``Result`` to ``FAIL``
  * Display "Uncovered" on screen in ``red``
  * Send a pulse for 600ms on ``GLOBAL.GPO[0]``

* Lines 22-27: Sum=0, meaning all 3 pins are 1 (covered)
  
  * Set ``Result`` to ``PASS``
  * Display "Covered" on screen in ``green``
  * Send a pulse for 600ms on ``GLOBAL.GPO[1]``

* Lines 29-33: Sum is either 1 or 2, inspection outcome is not unanimous among the 3 pins
  
  * Set ``Result`` to ``RECYCLE``
  * Display "Ambiguous" on screen in ``magenta``
  * Send a pulse for 600ms on ``GLOBAL.GPO[2]``

* Lines 36-38: Bit-functions 

Image Logging
----------------

* Click on :hoverxreftooltip:`Setup Connections <intro/Basic/Hover/setupconn:Setup Connections>` |conn| |cir1|, then on ``Setup Image Logging`` |imglogbut| |cir2| and the ``Image Logging`` panel will be shown.

.. Note::
  Click on |imglogen| to toggle between enabling/disabling ``Image Logging``

.. Note::
  The difference between ``Image Logging`` and ``Image File Logging`` 
  
  *  ``Image Logging`` : Images saved in memory, with a limit 
  *  ``Image File Logging`` : Images saved to PC location

Image File Logging
--------------------

* Click on :hoverxreftooltip:`Setup Connections <intro/Basic/Hover/setupconn:Setup Connections>` |conn| |cir1|, then on ``Setup Image Logging`` |imglogbut| |cir2| and the ``Image Logging`` panel will be shown. In this solution, the images that are classified as ``recycle`` will be saved to ``c:\Users`` with file names ``imageXX.bmp`` where ``XX`` is a sequential counter from 00 to 99 since ``#images`` are set to 100.
  |imglog| 

.. Caution::
  The sequenctial counter ``XX`` for filename resets at every ``Run Solution`` |runsoln| invocation, and files of the same name will be overwritten without warning. 

.. Note::
  User may choose between ``.bmp`` or ``jpg`` as the image logging format.

.. Note::
  File names can be substituted a different name for one image using LogImage/WriteImageFile/WriteImageTools/WriteHistoryImage. 

.. Note::
  Click on |imgfilelogen| to toggle between enabling/disabling ``Image File Logging``

.. Note::
  Check the |gfxchked| to save measurement graphics. If |gfxcbox|, only camera images will be saved.

+-----------------------------------------------------------------------------------+
|(Click to enlarge)                                                                 |
|                                                                                   |
||ambi|                                                                             |
|                                                                                   |
+-----------------------------------------------------------------------------------+
|Output of |gfxcbox| & |gfxchked|                                                   |
+-----------------------------------------------------------------------------------+

.. |ambi0| image:: /intro/Basic/GPIO/ambi0.jpg
  :width: 280px

.. |ambi1| image:: /intro/Basic/GPIO/ambi1.jpg
  :width: 280px

.. |ambi| image:: /intro/Basic/GPIO/ambi.jpg

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2| 

+-------------------------------------------------+-------------------------------------------------+
||1|                                              ||2|                                              |
|                                                 |                                                 |
|``bright1.bmp``                                  |``bright2.bmp``                                  |
+-------------------------------------------------+-------------------------------------------------+
||3|                                              ||4|                                              |
|                                                 |                                                 |
|``nolight1.bmp``                                 |``nolight1a.bmp``                                |
+-------------------------------------------------+-------------------------------------------------+
||5|                                              ||6|                                              |
|                                                 |                                                 |
|``nolight2.bmp``                                 |``rmFlash1.bmp``                                 |
+-------------------------------------------------+-------------------------------------------------+
||7|                                              ||8|                                              |
|                                                 |                                                 |
|``rmFlash1a.bmp``                                |``rmlight1.bmp``                                 |
+-------------------------------------------------+-------------------------------------------------+
||9|                                              ||10|                                             |
|                                                 |                                                 |
|``rmlight2.bmp``                                 |``rmlight3.bmp``                                 |
+-------------------------------------------------+-------------------------------------------------+
||11|                                             |                                                 |
|                                                 |                                                 |
|``rmFlash2.bmp``                                 |                                                 |
+-------------------------------------------------+-------------------------------------------------+


.. Note::
  * For ``rmFlash2.bmp``, the results are classified as ``RECYCLED`` with the Live-pin below the threshold value despite it being covered. 

* In the ``Variable List`` the results of bit-functions can be found in array ``a`` 

.. image:: /intro/Basic/GPIO/varlist.jpg
  :width: 300px

.. Note::
 With ``Image Logging`` |imglogen| enabled, we can invoke the ``History Recall`` |history| button. The buttons in the panel are self-explanatory and are omitted here for brevity. Invoke the ``Return`` |return| button to return to monitor. |historypanel| 


.. Tip::
  #lighting #preprocessor #erode #normalize #GPO #GPI #GPIO #bit-functions #intensity

.. |CE| image:: /intro/Basic/GPIO/CE.jpg

.. |1| image:: /intro/Basic/GPIO/bright1.jpg
  :width: 400px

.. |2| image:: /intro/Basic/GPIO/bright2.jpg
  :width: 400px

.. |3| image:: /intro/Basic/GPIO/nolight1.jpg
  :width: 400px

.. |4| image:: /intro/Basic/GPIO/nolight1a.jpg
  :width: 400px

.. |5| image:: /intro/Basic/GPIO/nolight2.jpg
  :width: 400px

.. |6| image:: /intro/Basic/GPIO/rmFlash1.jpg
  :width: 400px

.. |7| image:: /intro/Basic/GPIO/rmFlash1a.jpg
  :width: 400px

.. |8| image:: /intro/Basic/GPIO/rmlight1.jpg
  :width: 400px

.. |9| image:: /intro/Basic/GPIO/rmlight2.jpg
  :width: 400px

.. |10| image:: /intro/Basic/GPIO/rmlight3.jpg
  :width: 400px

.. |11| image:: /intro/Basic/GPIO/rmFlash2_.jpg