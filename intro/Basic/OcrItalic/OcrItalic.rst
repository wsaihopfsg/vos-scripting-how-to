:orphan:

.. _gpio:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

OCR Teach-In for Italic Font 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of the  ``OCR`` tool |ocrtool| with teach-in of characters
2. Use of the ``Shear X`` preprocessor to facilitate the teach-in process of the italic fonts 
3. Logging results to a configured .csv file  and substituting configured filename of ``Image File Logging``

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``LogStart``      |``fileName``, ``onClient``        |Commence logging of processed data the specified ``fileName``     |
+------------------+----------------------------------+------------------------------------------------------------------+
|``LogStop``       |( )                               |Stop data logging                                                 |
+------------------+----------------------------------+------------------------------------------------------------------+
|``LogImage``      |``fileName``                      |Save image to ``fileName`` for 1 image. ``Image file logging``    |
|                  |                                  ||imgfilelogen| must be enabled                                    |
+------------------+----------------------------------+------------------------------------------------------------------+

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/OcrItalic>`__
-----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``OcrItalic.bin``                 |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/OcrItalic/OcrItalic.bin?raw=true>`__                     |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir1| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``OcrItalic.bmp``                 |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/OcrItalic/OcrItalic.bmp?raw=true>`__ OCR text in size 11    |
  |                                     |Times New Roman Font in italic.                                                                                                                        |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  
 

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``OcrItalic.bmp`` is loaded. 

.. image:: /intro/Basic/OcrItalic/toolsetup.jpg
..  :width: 400px

* 2 OCRs tools |ocrtool| have been used, both trying to recognize the same strings *italic font OCR     fictional tORC*

  .. Note::
    *fictional tORC* is an anagram of *italic font OCR*. In non-AI OCR mode, VOS can only recognize the characters that have been taught-in.

  .. Warning::
    The current version of the AI OCR in VOS is very limited. Use with a lot of caution.   

  * One named ``OCR``. As shown below, a ``Grayscale`` based template-based OCR with a treshold of ``85`` required with ``Very High`` effort has been configured. 

    .. image:: /intro/Basic/OcrItalic/OCRproperties.jpg
       :width: 400px

    * The taught-in characters boundaries are as shown. Notice that due to italics and kerning, the boundary for some characters cannot be properly defined with rectangles.

      .. image:: /intro/Basic/OcrItalic/fontedit2.jpg
        :width: 500px   
  
  * Another named ``OsheaR`` with its properties same as above but with its ``Shear X`` preprocessor |preprocess| turned on.
  
    .. image:: /intro/Basic/OcrItalic/shearx.jpg

    * As we can observe the text with the red border below, the italic effects have been removed by an appropriate ``Angle`` in ``Shear X``

      .. image:: /intro/Basic/OcrItalic/deitalic.jpg

    * The taught-in characters boundaries are as shown, with a much better character boundary definition than before.
  
      .. image:: /intro/Basic/OcrItalic/fontedit1.jpg
        :width: 500px

    .. note::  
      The ``Shear Y`` preprocessor works in similar way but in the y-direction, which is not needed in this example

Template-Based OCR
######################################

.. Note::
  This section describes how template matching is applied in OCR conceptually. The authors have no idea how VOS actually implements OCR.

* In template-based OCR, the taught-in characters served as templates for detection of the unknown character. For example, we have taught-in 3 characters A, B, C and their binary representation shown below.
  
  +-----------------------+------------------------+------------------------+
  ||A|                    ||B|                     ||C|                     |
  +-----------------------+------------------------+------------------------+

* The unknown character will be compred against the available template and a score will be given. In this case, the percentage of pixels that are the same or a :math:`{pixelwise XOR/30}`. 

  +-----------------------+------------------------+------------------------+------------------------+
  ||unknown|              | Template **A**         | Template **B**         | Template **C**         |
  +                       +------------------------+------------------------+------------------------+
  |                       |83%                     |53%                     |57%                     |
  +-----------------------+------------------------+------------------------+------------------------+

* The condition for a decalring a match is the highest score that is over a preset threshold. Therefore in this case if the threshold is 
  
  * 50%, the result will be output as **A** 
  * 90%, unrecognized character

.. Note::
  Since ``Grayscale`` method in VOS has an extra degree-of-freedom in terms of individual pixel's intensity, ``Grayscale`` is usually preferred over ``Binary`` OCR.

.. Warning::
  Like most tools in VOS, template-based OCR is not scale invariant. Same font type of other sizes near to the taught-in size may still work if the threshold is low enough, but if the size differs too much you will have to teach-in the other font size too. 

.. |A| image:: /intro/Basic/OcrItalic/A.jpg
  :width: 100px

.. |B| image:: /intro/Basic/OcrItalic/B.jpg
  :width: 100px

.. |C| image:: /intro/Basic/OcrItalic/C.jpg
  :width: 100px

.. |unknown| image:: /intro/Basic/OcrItalic/char.jpg
    :width: 100px
 
Image File Logging
--------------------

* Click on :hoverxreftooltip:`Setup Connections <intro/Basic/Hover/setupconn:Setup Connections>` |conn| |cir1|, then on ``Setup Image Logging`` |imglogbut| |cir2| and the ``Image Logging`` panel will be shown. In this solution, the images that are classified as ``pass`` will be saved but we will overwrite the filename settings with scripting.

.. image:: /intro/Basic/OcrItalic/imglog.jpg


Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  

Solution Initialize
###################
* Choose the predefined function ``Solution Initialize`` at the bottom left 
  |fn_init|

* In the Script Function window we see 2 lines of code

.. code-block::
  :linenos:
    
    nowCtr = 0
    logstart("C:\Users\temp\test.csv",1) 

* Line 1: Counter initialization
* Line 2: Start file logging to ``test.csv`` 

Post Image Process
##################

* Choose the predefined function ``Post Image Process`` at the bottom left 
  |fn_post|

* In the Script Function window we see 

.. code-block::
  :linenos:

  saveStr = "C:\Users\temp\now"+nowCtr+".jpg"
  logimage(saveStr)
  nowCtr = nowCtr+1
  if(nowCtr>5) 
      logstop()
  endif

* Line 1: Changing image file name based on ``nowCtr``
* Line 2: Overwriting the image file logging name with ``saveStr``
* Line 3: Counter increament
* Lines 4-6: Stop logging criterion  


.. note::
  LogImage only works when ``Image File Logging`` |imgfilelogen| is enabled and filename substitution only works for the current filename. 

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 
* Clicking on ``Manual Trigger`` |manTrig| repeatedly we will see files created 
  
  * As many .jpg files as ``Manual Trigger`` |manTrig| clicks    
  * A .csv file with 5 entries

.. code-block::
  :linenos:
  
  "Frame Number","TimeStamp","Result","OsheaR","OCR",

  1, 17:58:04, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC
  2, 17:58:04, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC
  3, 17:58:05, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC
  4, 17:58:05, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC
  5, 17:58:06, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC


* We can observe that
   
  * ``OsheaR`` is able to recognize the alphabets with 100% accuracy, 
  * ``OCR`` has difficult to decode the last R of *italic font OCR*. Tweaking the ``Required score`` of ``OCR`` manually does not seem to help as summarize in the following table.
    
    * 85: italicfontOC
    * 50: italicfontOCI
    * 40: italicfontOCIc
    * 10: c italicfontOC     

+-------------------------------------------------+-------------------------------------------------+
||1|                                              ||2|                                              |
|                                                 |                                                 |
|``Required score`` = 85                          |``Required score`` = 50                          |
+-------------------------------------------------+-------------------------------------------------+
||3|                                              ||4|                                              |
|                                                 |                                                 |
|``Required score`` = 40                          |``Required score`` = 10                          |
+-------------------------------------------------+-------------------------------------------------+

.. Note::
  * In this case where |charsamesize| is unchecked in the ``font editor`` |fonteditor|,
    
    * Spaces may become hard to detect
    * Other taught-in chracters may have a higher score than the correct character, like in this example *i* seems fit into the downward stroke of the *R*.
      

.. Tip::
  #OCR #preprocessor #shear #italic #template #AI #grayscale #intensity

.. |1| image:: /intro/Basic/OcrItalic/85.jpg
  :width: 400px

.. |2| image:: /intro/Basic/OcrItalic/50.jpg
  :width: 400px

.. |3| image:: /intro/Basic/OcrItalic/40_.jpg
  :width: 400px

.. |4| image:: /intro/Basic/OcrItalic/10.jpg
  :width: 400px

.. |charsamesize| image:: /intro/Basic/OcrItalic/charsamesize.jpg
