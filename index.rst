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

The ``VOS emulator`` is the only program that we will be using in this tutorial, which is launched through ``VOS Emulator Config`` 

.. image:: /img/emulatorConfig.JPG

As always, we would be happy to hear your comments and receive your contributions on any tutorial.

.. toctree::

Basic Topics
============

Variable Tree List
------------------
Function List
-------------
Script Editor
-------------
Scripting Basics
----------------

Advanced Topics
===============

Interation with C#
------------------
Integration with ROS
--------------------

User contributions
==================

:doc:`Using reference shape to compute dimensions </soln/RefCirSizeRect/RefCirSizeRect>`
----------------------------------------------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Scale-Invariant Solution                                                                                   |       
+===========================================================================================================+
|| This solution uses a circle's diameter as a reference to compute the length and breadth of any rectangles|
|| in the field-of-view. The reference circle is required to be the left most shape.                        |
|| |refCir|                                                                                                 | 
+-----------------------------------------------------------------------------------------------------------+


:doc:`Sequential reading of QR codes </soln/ROI/roi>`
-----------------------------------------------------

+-----------------------------------------------------------------------------------------------------------+
|Changing ROI Programmatically                                                                              |       
+===========================================================================================================+
|| While the region-of-interest (ROI) of most solutions are fixed, in some cases it may be advantageous to  |
|| shift the ROI. This example shows reading each QR code sequentially, relying on the "Periodic: 200ms"    |
|| function to perform ROI shifts with a timer.                                                             |
|| |VOSROX|                                                                                                 | 
+-----------------------------------------------------------------------------------------------------------+


:doc:`Defect Detection </soln/DefectDots/DefectDots>`
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

:doc:`Scratch Detection </soln/Scratch/Scratch>`
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

.. |refCir| image:: /soln/RefCirSizeRect/refCirManyRect.JPG
   :width: 480pt
   :height: 480pt

.. |VOSROX| image:: /soln/ROI/vosrox.gif
   :align: middle

.. |DefectDots| image:: /soln/DefectDots/failedPatches.jpg

.. |scratch_hi| image:: /soln/Scratch/scratch_highlighted.jpg