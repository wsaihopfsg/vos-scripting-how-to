.. include:: /shared/EmulatorComponents.rst

Defect Detection 
++++++++++++++++

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/DetectDots>`__
----------------------------------------------------------------------------------------------------

#. ``detectpatches.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/DetectDots/detectpatches.bin?raw=true>`_

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
#. ``mpsmok.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/DetectDots/mpsmok.bmp?raw=true>`__ for PASS with no patch detected.
#. ``mpsmdots.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/DetectDots/mpsmdots.bmp?raw=true>`__ for FAIL due to defect detected.

   * At the Sensor Setup page |sensorsetup|, set |demoimg| to the folder where ``mpsmdots.bmp`` & ``mpsmok.bmp`` have been saved 

Tools Explanation
-----------------
* At the ``Tool Setup`` page |toolsetup|, click on |takepic| if until ``mpsmdots.bmp`` is loaded.
* Only a ``Count`` tool called ``N`` is used with the region-of-interest (ROI) set to the area where defect detection is to be performed.
* Hovering the mouse over the green line denoting the ROI, the count tool gives a preview of the output after preprocessing has been applied. |CountPreview|
* Right-clicking on the border which has turned red, the Count Properties window will be shown |CountProp| 
  * Click on preprocess button |preprocess| to bring up the Preprocess window |PreprocessWin|
  



.. |CountPreview| image:: /soln/DefectDots/CountPreview.jpg

.. |CountProp| image:: /soln/DefectDots/CountProperties.jpg

.. |PreprocessWin| image:: /soln/DefectDots/Preproc.jpg