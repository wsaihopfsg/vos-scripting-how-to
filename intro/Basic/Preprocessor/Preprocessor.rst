:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Preprocessors in Image Processing 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of ``Preprocessor`` tool |preprocessortool|
  
  * Low pass 
  * High pass 
  * Gaussian 
  * Median
  * Mask
  * Project H
  * Project V
  * Convolve 3x3
  * Subtract
  * Invert
  * Sobel
  
`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/Proprocessor>`__
---------------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``solution14.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Preprocessor/solution14.bin?raw=true>`__                 |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir1| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``many.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Preprocessor/many.bmp?raw=true>`__                          |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where ``many.bmp`` have been saved                                                                                                                   |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``many.bmp`` is loaded. 

  .. image:: /intro/Basic/Preprocessor/preoverview.jpg

  * ``many.bmp`` is made up of these 2 images
  
  =============== ===============
  |gimzua|        |tsq|
  =============== ===============

  .. |gimzua| image:: /intro/Basic/Preprocessor/gimzua.png
    :width: 300px
  .. |tsq| image:: /intro/Basic/Preprocessor/tsq.jpg  
    :width: 300px

* 13 ``Preprocessor`` tools |preprocessortool| have been used on various parts of the image. The properties for each is shown here.
  
  =================== =================== =================== ===================
  ↓ ``Pre2``          ↓ ``Pre3``          ↓ ``Pre4``          ↓ ``Pre5`` 
  ------------------- ------------------- ------------------- -------------------
  |pre2|              |pre3|              |pre4|              |pre5|
  ------------------- ------------------- ------------------- -------------------
  ↓ ``Pre6``          ↓ ``Pre9``          ↓ ``Pre10``             
  ------------------- ------------------- ------------------- -------------------
  |pre6|              |pre9|              |pre10|              
  ------------------- ------------------- ------------------- -------------------
  ↓ ``Pre7``                              ↓ ``Pre8``             
  --------------------------------------- ---------------------------------------
  |pre7|                                  |pre8|              
  --------------------------------------- ---------------------------------------
  ↓ ``Pre``
  -------------------------------------------------------------------------------
  |pre|
  -------------------------------------------------------------------------------
  ↓ ``Pre1``
  -------------------------------------------------------------------------------
  |pre1|
  -------------------------------------------------------------------------------
  ↓ ``Pre12``
  -------------------------------------------------------------------------------
  |pre12|
  -------------------------------------------------------------------------------
  ↓ ``Pre11``
  -------------------------------------------------------------------------------
  |pre11|
  ===============================================================================

  .. |pre| image:: /intro/Basic/Preprocessor/preprop.jpg
  .. |pre1| image:: /intro/Basic/Preprocessor/pre1prop.jpg
  .. |pre2| image:: /intro/Basic/Preprocessor/pre2prop.jpg  
  .. |pre3| image:: /intro/Basic/Preprocessor/pre3prop.jpg
  .. |pre4| image:: /intro/Basic/Preprocessor/pre4prop.jpg
  .. |pre5| image:: /intro/Basic/Preprocessor/pre5prop.jpg
  .. |pre6| image:: /intro/Basic/Preprocessor/pre6prop.jpg
  .. |pre7| image:: /intro/Basic/Preprocessor/pre7prop.jpg
  .. |pre8| image:: /intro/Basic/Preprocessor/pre8prop.jpg
  .. |pre9| image:: /intro/Basic/Preprocessor/pre9prop.jpg
  .. |pre10| image:: /intro/Basic/Preprocessor/pre10prop.jpg
  .. |pre11| image:: /intro/Basic/Preprocessor/pre11prop.jpg
  .. |pre12| image:: /intro/Basic/Preprocessor/pre12prop.jpg

* A ``Count`` tool just to make this solution runnable. It does not serve any useful purpose. 

Code Walk-Through
-----------------
* There is no scripting involved in this solution

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 

* We can observe that
   
  * ``Pre2`` is able to recognize the alphabets with 100% accuracy, 
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

.. |teachsizes| replace:: teach-in the other font size

