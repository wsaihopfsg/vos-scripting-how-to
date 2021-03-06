.. VOS Scripting How-To documentation master file, created by
   sphinx-quickstart on Tue Feb  8 09:53:52 2022.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

.. include:: /shared/EmulatorComponents.rst
   
Welcome to VOS Scripting How-To!
================================

The following links describe a set of basic VOS tutorials. Please note that their solution and image files are available in the respective repositories.

.. note::
   While the authors try to be technically correct in these tutorials, the datasheet and manual for VOS in https://www.pepperl-fuchs.com/global/en/vos.htm shall provide the final technical adjudication.

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

:doc:`Locator Using Count Tool <intro/Basic/CountLocator/CountLocator>`
------------------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Using Count Tool as Locator                                                                                |  
+===========================================================================================================+
|| A position ``position locator`` aligns the image area to the (x,y) coordinates, and a rotation           |
|| ``rotation locator`` tracks the rotation of an image. Up to 16 locators can be defined in VOS. Each tool |
|| gets its position and rotation fixed by following one of the defined locators. This tutorial demonstrates|
|| the use of the ``Count`` |counttool| tools as locators to perform some inspection tasks with ``Barcode`` | 
|| |barcodetool| & ``Contour`` |contourtool| tools.                                                         |
|| |countloc|                                                                                               |
+-----------------------------------------------------------------------------------------------------------+

.. |countloc| image:: /intro/Basic/CountLocator/overviewcl.jpg

:doc:`Locator Using Pencil Tool <intro/Basic/PencilLocator/PencilLocator>`
-------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Using Pencil Tool as Locator                                                                               |  
+===========================================================================================================+
|| Small translation of (x,y) co-ordinates can be tracked using ``Pencil`` tool |penciltool|. However,      |
|| another feature is needed to track rotation. This tutorial demonstrates using pencil tool as locator,    |
|| and the use of the ``Arc`` tool |arctool|                                                                |
|| |pencilloc|                                                                                              |
+-----------------------------------------------------------------------------------------------------------+

.. |pencilloc| image:: /intro/Basic/PencilLocator/penciloverview.jpg

:doc:`Locator Using Edge Count Tool <intro/Basic/EdgeCountLocator/EdgeCountLocator>`
-------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Using Edge Count Tool as Locator                                                                           |  
+===========================================================================================================+
|| When the translation is in either x or y direction only, this can be tracked using ``Edge Count`` tool   |
|| |edgecounttool|. This is useful when the object size is beyong the field-of-view. This tutorial          |
|| demonstrates using ``Edge Count`` tool |edgecounttool| as locator, together with ``Caliper`` tool        |
|| |calipertool|                                                                                            |
|| |edgeloc|                                                                                                |
+-----------------------------------------------------------------------------------------------------------+

.. |edgeloc| image:: /intro/Basic/EdgeCountLocator/edgecountlocatoroverview.jpg

:doc:`Locator Using Match Tool, Preprocessors & GPOs <intro/Basic/GPIO/GPIO>`
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

:doc:`OCR for Small Font <intro/Basic/Smalltext/Smalltext>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Zoom Preprocessor to Facilitate OCR Teach-In for Small Font Sizes                                          |  
+===========================================================================================================+
|| The minimum size for the teach-in area for OCR is 4x4 pixels, but we may often need to deal with font    |
|| sizes that barely meet this limit. This tutorial shows how the ``Zoom`` preprocessor may be used to      |
|| provide some extra freedom for teachi-in of small text.                                                  |
|| |smalltext|                                                                                              |
+-----------------------------------------------------------------------------------------------------------+

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

:doc:`Preprocessors <intro/Basic/Preprocessor/Preprocessor>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Introduction to Preprocessor                                                                               |  
+===========================================================================================================+
|| Demonstrates some preprocessors available for VOS.                                                       |
|| |preprocessintro|                                                                                        |
+-----------------------------------------------------------------------------------------------------------+

.. |preprocessintro| image:: /intro/Basic/Preprocessor/preoverview1.jpg

:doc:`Image Conversion <intro/Basic/GenericImg/GenericImg>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Using Pictures from Any Image Source to Emulator                                                           |  
+===========================================================================================================+
|| Since VOS requires that images must be monochrome bitmaps with the resolution of the selected sensor,    |
|| this tutorial demonstrates how to convert pictures from any image source into a VOS compliant one.       |
|| |jpg2bmp|                                                                                                |
+-----------------------------------------------------------------------------------------------------------+

.. |jpg2bmp| image:: /intro/Basic/GenericImg/jpg2bmp.jpg
   :width: 300pt

Advanced Topics
===============

:doc:`Interaction with C# <intro/Advanced/csharp/csharp>`
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

:doc:`FTP Logging & Viewing of Images on Web Browser <intro/Advanced/FTP/FTP>`
--------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Viewing of Inspection Images and Results on Web Browser                                                    |  
+===========================================================================================================+
|| VOS serves as a FTP client, and logs images to a configured FTP server on Node-Red. The image and its    |
|| associated tools together with the inspection results are displayed in the web broswer of any            |
|| phone/tablet/computer within the same intranet through the Node-Red dashboard.                           |
|| |ftpviewer|                                                                                              |
+-----------------------------------------------------------------------------------------------------------+

.. |ftpviewer| image:: /intro/Advanced/FTP/overview.png

:doc:`Integration with ROS <intro/Advanced/ROS/ROS>`
------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|VOS integration with ROS motion planning in a virtual UR5 cobot                                            |
+===========================================================================================================+
|| In this example, we have integrated VOS with a virtual UR5 cobot for a pick-and-place demo in ROS. VOS   |
|| takes a picture of the scene, and outputs the location & rotation of the QR code on the object to be     |
|| picked up. The (x,y,rotation) information is published as a ROS topic and ROS performs automatic TF      |
|| co-ordinate transformation. The virtual robot performs path planning from its current position to "pick" |
|| the object up. Since a gripper is not simulated on the cobot, rotation information is not used in this   |
|| demo except for showing the blue marker for object representation.                                       |
|| |pNp|                                                                                                    |
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
|Extracting Data from Sample Japanese Driving Licenses ???????????????                                           |
+===========================================================================================================+
|| This tutorial using samples of Japanese driving licenses to demonstrate                                  |
|| 1. OCR of Asian Scripts                                                                                  |
|| 2. Discriminiating between the 3 colours for Japanese driving liceses with lighting                      |
|| 3. Use of the Edge Count tool |edgecounttool|                                                            |
|| |mihon|                                                                                                  |
+-----------------------------------------------------------------------------------------------------------+

:doc:`Reading of an Analog Dial <soln/ReadDial/ReadDial>`
----------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Automatic Reading of an Analog Dial                                                                        |
+===========================================================================================================+
|| With the help of the ``Angle`` tool |angletool|, VOS can be used to perform automatic dial reading on    |
|| analog meters.                                                                                           |
|| |readmeters|                                                                                             |
+-----------------------------------------------------------------------------------------------------------+

.. |readmeters| image:: /soln/ReadDial/readdialoverview.jpg

:doc:`Checking Box Orientation & Angle <soln/Boxrot/Boxrot>`
----------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Reject Boxes in Wrong Orientation On a Conveyor Belt (I)                                                   |
+===========================================================================================================+
|| In this application, the rectangular box needs to be put in a horizontal orientation with rotation not   |
|| exceeding certain thresholds. If the box is in the wrong orientation, the inspection fails. If the box is|
|| in the correct orientation but the exceeds the rotation limit, the inspection is recycled. Being on a    |
|| conveyor, very fast inspection speed is also required.                                                   |
|| |boxrot|                                                                                                 |
+-----------------------------------------------------------------------------------------------------------+

.. |boxrot| image:: /soln/Boxrot/boxrotoverview.jpg

:doc:`Checking Punnet Orientation <soln/Punnet/Punnet>`
----------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Reject Boxes in Wrong Orientation On a Conveyor Belt (II)                                                  |
+===========================================================================================================+
|| This application is similar to the previous one, in which the rectangular box needs to be put in a       |
|| certain orientation with no requirement for computing the angle of rotation. If the box is in the correct|
|| orientation, the inspection passes; otherwise it fails. Very fast inspection speed is again required.    |
|| |punrot|                                                                                                 |
+-----------------------------------------------------------------------------------------------------------+

.. |punrot| image:: /soln/Punnet/punnetoverview.jpg

:doc:`GPIOs Setup and Connection <soln/Extrig/Extrig>`
----------------------------------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Wiring up GPIOs to VOS                                                                                     |
+===========================================================================================================+
|| This tutorial contains information on how to wire-up GPIOs to VOS. Note that most screen shots are not   |
|| available on the VOS emulator because physical hardware is involved.                                     |
|| |extrig|                                                                                                 |
+-----------------------------------------------------------------------------------------------------------+

.. |extrig| image:: /soln/Extrig/gpipnp1.jpg

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

.. |OCR57| image:: /intro/Advanced/SolnSwitch/ocr57.JPG

.. _RobotArm: https://github.com/ros-industrial/industrial_training/blob/foxy/gh_pages/_downloads/slides/ROS-I%20Basic%20Developers%20Training%20-%20Session%204.pdf

.. |strfunc| image:: /intro/Basic/StrFunc/strFunc.jpg
   :width: 320pt

.. |mathfunc| image:: /intro/Basic/MathFunc/MathFunc.jpg
   :width: 320pt

.. |matchpix| image:: /intro/Basic/GPIO/coverUN.jpg

.. |deitalic| image:: /intro/Basic/OcrItalic/deitalic.jpg

.. |smalltext| image:: /intro/Basic/Smalltext/zoomed.jpg