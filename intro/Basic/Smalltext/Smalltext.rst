:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

OCR Teach-In for Small Font Sizes 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of the  ``OCR`` tool |ocrtool| with teach-in of characters
2. Use of the ``Zoom`` preprocessor to facilitate the teach-in of very small fonts 

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/Smalltext>`__
-----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``SmallText.bin``                 |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Smalltext/SmallText.bin?raw=true>`__                     |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir1| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``ArialSize6.bmp``                |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Smalltext/ArialSize6.bmp?raw=true>`__ OCR text in size 6    |
  |                                     |Arial Font.                                                                                                                                            |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where ``ArialSize6.bmp`` have been saved                                                                                                             |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

 

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2|.

.. image:: /intro/Basic/Smalltext/toolsetup.jpg
..  :width: 400px

* 2 OCRs tools |ocrtool| have been used, both trying to recognize the same string "Very Small Text"

  * One named ``OCR``. As shown below, a ``Grayscale`` based template-based OCR with a treshold of ``85`` required with ``Very High`` effort has been configured. 

    .. image:: /intro/Basic/Smalltext/OCRproperties.jpg
       :width: 400px

    * The taught-in characters are as shown below. Notice that some characters barely satisfy the 4x4 pixels minimum teach-in size. 

      .. image:: /intro/Basic/Smalltext/fontedit2.jpg
        :width: 500px   
  
  * Another named ``OCR1`` with its properties same as above but with its ``Zoom`` preprocessor |preprocess| turned on as shown here.
  
    .. image:: /intro/Basic/Smalltext/zoom2x.jpg

    * The taught-in characters boundaries are as shown, with more freedom available for the choosing of teach-in area as the chacrters appear larger.
  
      .. image:: /intro/Basic/Smalltext/fontedit1.jpg
        :width: 500px

    .. note::  
      The difference between the ``Zoom`` preprocessor against the ``zoom-in`` |fontzoom| button in the Font Editor is that the image is scaled in the ``Zoom`` preprocessor with interpolation while the ``zoom-in`` button merely enlarges each pixel on the screen. 

    .. note::
      For an overview of template-based OCR please refer to :ref:`here<templateocr>`.

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 
* We can observe that
   
  * ``OCR1`` is able to recognize the alphabets with 100% accuracy, 
  * ``OCR`` has difficult to recognize some characters.
    
  
.. Tip::
  #OCR #preprocessor #zoom #small #template #font #interpolator #interpolation #rescaling
