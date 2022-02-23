.. VOS Scripting How-To documentation master file, created by
   sphinx-quickstart on Tue Feb  8 09:53:52 2022.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

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
* Variable and function names are non case-sensitive!!

As always, we would be happy to hear your comments and receive your contributions on any tutorial.

.. toctree::

Basic Topics
============

:ref:`String Functions <strfunc>`
----------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Formatting Strings                                                                                         |  
+===========================================================================================================+
|| The user-defined function strips a certain a character in a string. May be useful in OCR/barcode/QR code |
|| reading or dealing with any string.                                                                      |
|| |strfunc|                                                                                                |
+-----------------------------------------------------------------------------------------------------------+

:ref:`Math Functions <mathfunc>`
----------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Mathematical Functions                                                                                     |
+===========================================================================================================+
|| Demonstrates built-in math functions with Rake, Distance and Angle tools                                 |
|| |mathfunc|                                                                                               |
+-----------------------------------------------------------------------------------------------------------+

:ref:`Bit Functions (WIP) <todo>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|(WIP)                                                                                                      |  
+===========================================================================================================+
|| "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et  |
|| dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip  |
|| ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu |
|| fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt| 
|| mollit anim id est laborum."                                                                             |
+-----------------------------------------------------------------------------------------------------------+

:ref:`Statistics & Attribute Functions (WIP) <todo>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|(WIP)                                                                                                      |  
+===========================================================================================================+
|| "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et  |
|| dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip  |
|| ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu |
|| fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt| 
|| mollit anim id est laborum."                                                                             |
+-----------------------------------------------------------------------------------------------------------+


:ref:`Digital IO / Control Functions (WIP) <todo>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|(WIP)                                                                                                      |  
+===========================================================================================================+
|| "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et  |
|| dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip  |
|| ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu |
|| fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt| 
|| mollit anim id est laborum."                                                                             |
+-----------------------------------------------------------------------------------------------------------+

:ref:`Logging Functions (WIP) <todo>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|(WIP)                                                                                                      |  
+===========================================================================================================+
|| "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et  |
|| dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip  |
|| ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu |
|| fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt| 
|| mollit anim id est laborum."                                                                             |
+-----------------------------------------------------------------------------------------------------------+

:ref:`Keyboard & Serial IO Functions (WIP) <todo>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|(WIP)                                                                                                      |  
+===========================================================================================================+
|| "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et  |
|| dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip  |
|| ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu |
|| fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt| 
|| mollit anim id est laborum."                                                                             |
+-----------------------------------------------------------------------------------------------------------+

:ref:`Comm & TCP IO Functions (WIP) <todo>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|(WIP)                                                                                                      |  
+===========================================================================================================+
|| "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et  |
|| dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip  |
|| ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu |
|| fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt| 
|| mollit anim id est laborum."                                                                             |
+-----------------------------------------------------------------------------------------------------------+

:ref:`Symstem & Miscellaneous Functions (WIP) <todo>`
------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|(WIP)                                                                                                      |  
+===========================================================================================================+
|| "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et  |
|| dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip  |
|| ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu |
|| fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt| 
|| mollit anim id est laborum."                                                                             |
+-----------------------------------------------------------------------------------------------------------+

Advanced Topics
===============

:ref:`Interation with C# <csharp>`
------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Customized User Interface with C#                                                                          |       
+===========================================================================================================+
|| Sometimes we may not want operators have direct access to the VOS emulator software. While solution      |
|| development can only be done at the VOS emulator, it is for a .NET program integrated with VOS           |
|| |UI|                                                                                                     | 
+-----------------------------------------------------------------------------------------------------------+

Branching to Multiple Solutions (WIP)
-------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|C# client switches to another solution based on current image                                              |       
+===========================================================================================================+
|| A single solution may not be able to handle complicated vision problems. The C# client can load the      |
|| appropriate solution based on the image information from VOS. This greatly expands the capability and    |
|| flexibility of VOS. Note that solution switching can be achieved with a PLC also, which is not within the| 
|| purview of this tutorial.                                                                                |
|| |branch|                                                                                                 |
+-----------------------------------------------------------------------------------------------------------+

Integration with ROS (WIP)
--------------------------

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

:ref:`Using reference shape to compute dimensions <refcir>`
----------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Scale-Invariant Solution Using Circular Reference Shape                                                    |       
+===========================================================================================================+
|| This solution uses a circle's diameter as a reference to compute the length and breadth of any rectangles|
|| in the field-of-view. The reference circle is required to be the left most shape.                        |
|| |refCir|                                                                                                 | 
+-----------------------------------------------------------------------------------------------------------+


:ref:`Sequential reading of QR codes <ROI>`
-----------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Changing ROI Programmatically                                                                              |       
+===========================================================================================================+
|| While the region-of-interest (ROI) of most solutions are fixed, in some cases it may be advantageous to  |
|| shift the ROI. This example shows reading each QR code sequentially, relying on the "Periodic: 200ms"    |
|| function to perform ROI shifts with a timer.                                                             |
|| |VOSROX|                                                                                                 | 
+-----------------------------------------------------------------------------------------------------------+


:ref:`Defect Detection <defectdots>`
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

:ref:`Scratch Detection <scratch>`
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

Scale-Invariant OCR On a Rim (WIP)
----------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Scale-Invariant OCR With Multiple Taught-In Font Sizes                                                     |       
+===========================================================================================================+
|| This solution uses 2 taught in font sizes to achieve scale-invariant OCR. The OCR ROI is adjusted based  |
|| on 2 count tools' output.                                                                                |
|| |OCR57|                                                                                                  |
+-----------------------------------------------------------------------------------------------------------+

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

.. |branch| image:: /intro/Advanced/SolnSwitch/Overview.jpg
   :width: 320pt
   
.. |OCR57| image:: /soln/OCRim/ocr57.JPG

.. _RobotArm: https://github.com/ros-industrial/industrial_training/blob/foxy/gh_pages/_downloads/slides/ROS-I%20Basic%20Developers%20Training%20-%20Session%204.pdf

.. |strfunc| image:: /intro/Basic/StrFunc/strFunc.jpg
   :width: 320pt

.. |mathfunc| image:: /intro/Basic/MathFunc/MathFunc.jpg
   :width: 320pt
