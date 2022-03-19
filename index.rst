.. VOS Scripting How-To documentation master file, created by
   sphinx-quickstart on Tue Feb  8 09:53:52 2022.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

.. include:: /shared/EmulatorComponents.rst
   
Welcome to VOS Scripting How-To!
================================

The following links describe a set of basic VOS tutorials. Please note that their solution and image files are available in the respective repositories.

.. note::
   While the authors try to be technically correct in these tutorials, the datasheet and manual for VOS in https://www.pepperl-fuchs.com shall provide the final technical adjudication.

You should have downloaded and installed the ``Pepperl-Fuchs Vision Configuration Tool`` as described in the manual. 

We will be using the ``VOS emulator`` mostly in this tutorial, which is launched through ``VOS Emulator Config`` 

.. image:: /img/emulatorConfig.JPG

Please note the following constraints for VOS Scripting:

* There is a **60-character** limit for variable names.
* There is a **256-character** limit for each line of script. 
* The number of lines per script is limited by your computer's memory.
* Variable and function names are not case-sensitive!!

As always, we would be happy to hear your comments and receive your contributions on any tutorial.

.. toctree::

Basic Topics
============

:doc:`String Functions <intro/Basic/StrFunc/StrFunc>`
-----------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Formatting Strings                                                                                         |  
+===========================================================================================================+
|| The user-defined function strips a certain a character in a string. May be useful in OCR/barcode/QR code |
|| reading or dealing with any string.                                                                      |
|| |strfunc|                                                                                                |
+-----------------------------------------------------------------------------------------------------------+

:doc:`Math Functions <intro/Basic/MathFunc/MathFunc>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Mathematical Functions                                                                                     |
+===========================================================================================================+
|| Demonstrates built-in math functions with Rake, Distance and Angle tools                                 |
|| |mathfunc|                                                                                               |
+-----------------------------------------------------------------------------------------------------------+

:doc:`Working with Locator, Preprocessors & GPOs <intro/Basic/GPIO/GPIO>`
------------------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Detection of Plastic Cover In Various Lighting With Intensity Tool                                         |  
+===========================================================================================================+
|| This example makes use of the ``Match`` Tool to serve as a locator for other image processing tools.     |
|| To detect whether the insulation cap has been installed on the 3-pin plug, the ROI is first preprocessed |
|| by an ``erode`` followed by a ``normalize`` before the value compared to a threshold. A pulse will be    |
|| issued at the GPO ports depending on the inspection results, and the images that failed inspection are   | 
|| logged. Bit functions are demonstrated too.                                                              |
|| |matchpix|                                                                                               |
+-----------------------------------------------------------------------------------------------------------+

:doc:`OCR for Italic Font <intro/Basic/OcrItalic/OcrItalic>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Using Shear X Preprocessor to Facilitate Italic Font OCR Teach-In                                          |  
+===========================================================================================================+
|| Italic fonts can be tricky for teach-in because their characters may not fit into rectangles used for    |
|| manual region-of-interest (ROI) indication due to kerning. The ``Shear X`` preprocessor is ideal for     |
|| making the italic characters up-right so that they fit into rectangles. This tutorial shows an example   |
|| where the italic font, gives errorneous results even after tweaking with the ``Required score``          | 
|| threshold. On the other hand with shear correction, the OCR is able to perform perfectly.                |
|| |deitalic|                                                                                               |
+-----------------------------------------------------------------------------------------------------------+



Advanced Topics
===============

:doc:`Interation with C# <intro/Advanced/csharp/csharp>`
----------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Customized User Interface with C#                                                                          |       
+===========================================================================================================+
|| Sometimes we may not want operators have direct access to the VOS emulator software. While solution      |
|| development can only be done at the VOS emulator, it is for a .NET program integrated with VOS           |
|| |UI|                                                                                                     | 
+-----------------------------------------------------------------------------------------------------------+

:doc:`Scale-Invariant OCR On a Rim with 2 Solutions Working in Tandem <intro/Advanced/SolnSwitch/SolnSwitch>`
-------------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Scale-Invariant OCR With Multiple Taught-In Font Sizes                                                     |       
+===========================================================================================================+
|| Two solutions are used cyclically                                                                        |
|| 1. Detection of concentric circle diameters & centre of circle based on 2 count tools                    |
|| 2. The OCR ROI is adjusted based on previous solution's values and the current image is ``ReTrigger``.   |
||                                                                                                          |
|| Scale-invariant OCR is achieved by teaching-in 2 font sizes.                                             |
|| |OCR57|                                                                                                  |
+-----------------------------------------------------------------------------------------------------------+

:doc:`Publishing VOS Data to MQTT </intro/Advanced/MQTT/MQTT>`
----------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|VOS & IIoT                                                                                                 |
+===========================================================================================================+
|| Extending on :doc:`OCR of Asian Scripts & Colour Discrimination <soln/Menkyo/Menkyo>`, this tutorial     |
| shows                                                                                                     |
|| 1. Sending of VOS processed data as JSON-formatted string to a socket server                             |
|| 2. Publishing of the JSON string to a topic ``vos/menkyo`` on a public MQTT broker through Node-red      |
| running on an edge device                                                                                 |
|| 3. Subscribing to the ``vos/menkyo`` topic and display of the VOS data on an android phone               |
|                                                                                                           |
||vosiot|                                                                                                   |
+-----------------------------------------------------------------------------------------------------------+

.. |vosiot| image:: /intro/Advanced/MQTT/overview.jpg

.. |mihon| image:: /soln/Menkyo/mihon.jpg

:ref:`Integration with ROS (WIP) <todo>`
----------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Publishing (X,Y) & Rotation Information For Robot Pick-and-Place                                           |
+===========================================================================================================+
|| The virtual robot performs a pick-and-place demonstration in RViz based on the (X,Y) co-ordinates        |
|| pf the camera_frame published by the VOS emulator. Path planning is done by the MoveIt! package.         |
|| |pNp|                                                                                                    |
|| `(c) Picture Credits <http://www.google.com>`__  //todo                                                  |
+-----------------------------------------------------------------------------------------------------------+

User contributions
==================

:doc:`Using reference shape to compute dimensions <soln/RefCirSizeRect/RefCirSizeRect>`
----------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Scale-Invariant Solution Using Circular Reference Shape                                                    |       
+===========================================================================================================+
|| This solution uses a circle's diameter as a reference to compute the length and breadth of any rectangles|
|| in the field-of-view. The reference circle is required to be the left most shape.                        |
|| |refCir|                                                                                                 | 
+-----------------------------------------------------------------------------------------------------------+


:doc:`Sequential reading of QR codes <soln/ROI/roi>`
-----------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Changing ROI Programmatically                                                                              |       
+===========================================================================================================+
|| While the region-of-interest (ROI) of most solutions are fixed, in some cases it may be advantageous to  |
|| shift the ROI. This example shows reading each QR code sequentially, relying on the "Periodic: 200ms"    |
|| function to perform ROI shifts with a timer.                                                             |
|| |VOSROX|                                                                                                 | 
+-----------------------------------------------------------------------------------------------------------+


:doc:`Defect Detection <soln/DefectDots/DefectDots>`
-----------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Defect Detection Through Preprocessors                                                                     |       
+===========================================================================================================+
|| This solution shows defect detection through preprocessors.                                              |
|| * Threshold (band)                                                                                       | 
|| * Invert                                                                                                 |
|| * Remove blobs                                                                                           |
|| |DefectDots|                                                                                             | 
+-----------------------------------------------------------------------------------------------------------+

:doc:`Scratch Detection <soln/Scratch/Scratch>`
-----------------------------------------------------

+------------------------------------------------------------------------------------------------+
|Scratch Detection in the Presence of Background Noise                                           |
+================================================================================================+
|| This solution shows scratch detection through use of multiple preprocessors stacked together. |
|| * Normalize                                                                                   |
|| * Threshold (band)                                                                            |
|| * Invert                                                                                      |
|| * Remove blobs                                                                                |
|| * Erode                                                                                       |
|| * Remove blobs                                                                                |
|| |scratch_hi|                                                                                  |
+------------------------------------------------------------------------------------------------+

:doc:`OCR of Asian Scripts & Colour Discrimination <soln/Menkyo/Menkyo>`
----------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Extracting Data from Sample Japanese Driving Licenses 運転免許証                                           |
+===========================================================================================================+
|| This tutorial using samples of Japanese driving licenses to demonstrate                                  |
|| 1. OCR of Asian Scripts                                                                                  |
|| 2. Discriminiating between the 3 colours for Japanese driving liceses with lighting                      |
|| 3. Use of the Edge Count tool |edgecounttool|                                                            |
|| |mihon|                                                                                                  |
+-----------------------------------------------------------------------------------------------------------+

:doc:`Glossary <Glossary/Glossary>`
========================================

* :ref:`Tools <toolss>`
* :ref:`Mathematical Functions <maths>`
* :ref:`String Functions <strings>`
* :ref:`Statistical Functions <stats>`
* :ref:`Attribute Functions <attrs>`
* :ref:`IOs <ios>`
* :ref:`Logger <logs>`
* :ref:`Communication Functions <comms>`
* :ref:`System Functions <sys>`



.. |refCir| image:: /soln/RefCirSizeRect/refCirManyRect.JPG
   :width: 480pt
   :height: 480pt

.. |VOSROX| image:: /soln/ROI/vosrox.gif
   :align: middle

.. |DefectDots| image:: /soln/DefectDots/failedPatches.jpg

.. |scratch_hi| image:: /soln/Scratch/scratch_highlighted.jpg

.. |UI| image:: /intro/Advanced/csharp/UI.jpg

.. |pNp| image:: /intro/Advanced/ROS/pickNplace.jpg  
   :width: 320pt

.. |OCR57| image:: /soln/OCRim/ocr57.JPG

.. _RobotArm: https://github.com/ros-industrial/industrial_training/blob/foxy/gh_pages/_downloads/slides/ROS-I%20Basic%20Developers%20Training%20-%20Session%204.pdf

.. |strfunc| image:: /intro/Basic/StrFunc/strFunc.jpg
   :width: 320pt

.. |mathfunc| image:: /intro/Basic/MathFunc/MathFunc.jpg
   :width: 320pt

.. |matchpix| image:: /intro/Basic/GPIO/coverUN.jpg

.. |deitalic| image:: /intro/Basic/OcrItalic/deitalic.jpg

