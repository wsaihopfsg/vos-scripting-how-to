:orphan:

.. _gpio:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

OCR Teach-In for Italic Font 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of the  ``OCR`` tool |ocrtool| with teach-in of characters
2. Use of the ``Shear X`` preprocessor to facilitate the teach-in process of the italic fonts 
3. Logging results to .csv file  //todo

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``LogStart``      |``fileName``, ``onClient``        |Commence logging of processed data the specified ``fileName``     |
+------------------+----------------------------------+------------------------------------------------------------------+
|``LogStop``       |( )                               |Stop data logging                                                 |
+------------------+----------------------------------+------------------------------------------------------------------+
|``LogImage``      |``fileName``                      |Save image to ``fileName`` .... //todo                            |
|                  |                                  |to 0 in ``value``                                                 |
+------------------+----------------------------------+------------------------------------------------------------------+

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/OcrItalic>`__
-----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``OcrItalic.bin``                 |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/OcrItalic/OcrItalic.bin?raw=true>`__                  |
  |                                     |                                                                                                                                                    |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/MathFunc/sensorsetup:Sensor Setup>` |solnsetup|, import |import| the solution          |  
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``OcrItalic.bmp``                 |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/OcrItalic/OcrItalic.bmp?raw=true>`__ OCR text in size 11 |
  |                                     |Times New Roman Font in italic.                                                                                                                     |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  
 

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup <intro/Basic/MathFunc/sensorsetup:Sensor Setup>` page |toolsetup|, click on |takepic| until ``OcrItalic.bmp`` is loaded. 

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
  This section describes how template matching is conceptually applied in OCR. The authors have no idea how VOS actually implements OCR.

* In template-based OCR, the taught-in characters served as templates for detection of the unknown character. For example, we have taught-in 3 characters A, B, C and their binary representation shown below.
  
  +-----------------------+------------------------+------------------------+
  ||A|                    ||B|                     ||C|                     |
  +-----------------------+------------------------+------------------------+

* The unknown character will be compred against the available template and a score will be given. In this case, the percentage of pixels that are the same or a :math:`{bitwise XOR/30}`. 

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

.. |A| image:: /intro/Basic/OcrItalic/A.jpg
  :width: 100px

.. |B| image:: /intro/Basic/OcrItalic/B.jpg
  :width: 100px

.. |C| image:: /intro/Basic/OcrItalic/C.jpg
  :width: 100px

.. |unknown| image:: /intro/Basic/OcrItalic/char.jpg
    :width: 100px
 
Code Walk-Through
-----------------
* There is no scripting involved in this example 

CSV Logging
----------------
//todo

Running the solution
--------------------

* At the ``Run Solution`` |runsoln| page, click on ``Manual Trigger`` |manTrig| button. While
   
  * ``OsheaR`` is able to recognize the alphabets with 100% accuracy, 
  * ``OCR`` has difficult to decode the last R of *italic font OCR*. Tweaking the ``Required score`` of ``OCR`` does not seem to help as summarize in the following table.
    
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
  * For ``rmFlash2.bmp``, the results are classified as ``RECYCLED`` with the Live-pin below the threshold value despite it being covered. 

* In the ``Variable List`` the results of bit-functions can be found in array ``a`` 

.. image:: /intro/Basic/GPIO/varlist.jpg
  :width: 300px

.. Note::
 With ``Image Logging`` |imglogen| enabled, we can invoke the ``History Recall`` |history| button. The buttons in the panel are self-explanatory and are omitted here for brevity. Invoke the ``Return`` |return| button to return to monitor. |historypanel| 


.. Tip::
  #lighting #preprocessor #erode #normalize #GPO #GPI #GPIO #bit-functions #intensity

.. |1| image:: /intro/Basic/OcrItalic/85.jpg
  :width: 400px

.. |2| image:: /intro/Basic/OcrItalic/50.jpg
  :width: 400px

.. |3| image:: /intro/Basic/OcrItalic/40.jpg
  :width: 400px

.. |4| image:: /intro/Basic/OcrItalic/10.jpg
  :width: 400px

