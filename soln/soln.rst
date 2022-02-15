User contributions
==================

Using reference shape to compute dimensions
-------------------------------------------

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
|| * Median                                                                                      |
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