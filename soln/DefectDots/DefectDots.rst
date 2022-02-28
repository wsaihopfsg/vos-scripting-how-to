:orphan:

.. _defectdots:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Defect Detection 
++++++++++++++++

This sample demonstrates

1. Use of preprocessors to aid in a vision task
2. Detailed explanation for ``Remove blob``

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/DetectDots>`__
---------------------------------------------------------------------------------------------------------

1. ``detectpatches.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/DetectDots/detectpatches.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
2. ``mpsmok.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/DetectDots/mpsmok.bmp?raw=true>`__ for PASS with no patch detected.
3. ``mpsmdots.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/DetectDots/mpsmdots.bmp?raw=true>`__ for FAIL due to defect detected.

   * At the :hoverxreftooltip:`Sensor Setup page <soln/ROI/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|, set |demoimg| |cir2| to the folder where ``mpsmdots.bmp`` & ``mpsmok.bmp`` have been saved 

Tools Explanation
-----------------
* At the ``Tool Setup`` page |toolsetup|, click on |takepic| until ``mpsmdots.bmp`` is loaded.
* Only a ``Count`` tool called ``N`` is used with the region-of-interest (ROI) set to the area where defect detection is to be performed.
  * The ``Tolerance`` of the tool is set to all zeros because we want to trigger a failure when N>0 
* Hovering the mouse over the green line denoting the ROI, the count tool gives a preview of the output after preprocessing has been applied. |CountPreview|
* Right-clicking on the border which has turned red, the ``Count Properties`` window will be shown |CountProp| 

  * Click on ``Preprocess`` button |preprocess| to bring up the ``Preprocess`` window |PreprocessWin|
  
    1. ``Threshold (band)``: According to the VOS manual, this converts the grayscale image to black-and-white by
  
      * ``White`` (255): All pixels between or equal to ``Low`` and ``High`` values
      * ``Black`` (0): Other pixels.
      * In this example, the defects to be detected are always darker than the uncorrupted image, and the ``Threshold (band)`` is used to convert these defects to ``white``. The resultant image from this tool alone is 
  
        |Preprocess1|
  
    2. Since in ``Count Properties`` the ``Object Type`` is set to ``Dark``, the ``Count`` tool would be counting black objects. Hence the ``Invert`` tool is needed as the second preprocessor. Take note of the 4 crescent shapes at the bottom; they should not be considered as defects.
       |Preprocess2| 
    3. Until this step the alphabets would have been included in the defect count. Since they are expected to be much bigger than the defects, we use the ``Remove blobs`` tool to get rid of them. However before using ``Remove blobs`` tool, we need information on what we are removing or retaining. With only the first 2 preprocessors above active, we can click on the ``Advanced...`` |advanced| button

       |Advanced|

       * With the information on the area and the minor/major axes from ``Advanced...``, we can proceed to populate the parameters for the third preprocessor ``Remove blob``.

.. _blob:  

       +-----------------+-------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------------+
       |White blobs      |0                  |Removing dark blobs                                                                                                                                          |
       +-----------------+-------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------------+
       |8 way            |1                  |Use 8-way connection                                                                                                                                         |
       +-----------------+-------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------------+
       |Rm edge blobs    |0                  |Do not remove blobs that touch the ROI                                                                                                                       |
       +-----------------+-------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------------+
       |Limit type       |0                  |Remove objects outside specified limits                                                                                                                      |
       +-----------------+-------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------------+       
       |Min area         |0                  |From ``Advanced..``, alphabets are > 10000 in                                                                                                                |
       +-----------------+-------------------+                                                                                                                                                             +       
       |Max area         |10000              |area                                                                                                                                                         |
       +-----------------+-------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------------+
       |Min width        |3                  |From ``Advanced..``, defects' width is < 55.                                                                                                                 |
       +-----------------+-------------------+                                                                                                                                                             +       
       |Max width        |55                 |Min width of 3 to exclude very small defects.                                                                                                                |
       |                 |                   |                                                                                                                                                             |
       |                 |                   |Width cannot be too big otherwise the 4 crescent                                                                                                             |
       |                 |                   |                                                                                                                                                             |
       |                 |                   |shapes at the bottom will be erroneously included as defects.                                                                                                |   
       +-----------------+-------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------------+
       |Min height       |3                  |From ``Advanced..``, defects' height is < 55.                                                                                                                |
       +-----------------+-------------------+                                                                                                                                                             +       
       |Max height       |55                 |Min height of 3 to exclude very small defects.                                                                                                               |
       +-----------------+-------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------------+

Code Walk-Through
-----------------
* Click on ``Edit Script`` |edit| 

Post Image Process
##################
* Choose the predefined function ``Post Image Process`` at the bottom left 
  |fn_post|

* In the Script Function window we see 

.. code-block::
    :linenos:

    if(N=0) 
        SetDisplayStatus("Pass","darkgreen")
    else
        SetDisplayStatus("Fail with "+N+" patches detected","red")
    endif

.. note::
  
  * The code uses the count value ``N`` to decide whether to pass or fail the defect inspection, and output by ``SetDisplayStatus`` with the number of defects detected .

Running the solution
--------------------

* At the ``Run Solution`` |runsoln| page, click on ``Manual Trigger`` |manTrig| button to toggle between the 2 pictures
  
  .. image:: /soln/DefectDots/failedPatches.jpg
  
  .. image:: /soln/DefectDots/passPatches.jpg    

.. tip::
  #remove #blob #defect #detection #preprocessor

.. |CountPreview| image:: /soln/DefectDots/CountPreview.jpg

.. |CountProp| image:: /soln/DefectDots/CountProperties.jpg

.. |PreprocessWin| image:: /soln/DefectDots/Preproc.jpg

.. |Preprocess1| image:: /soln/DefectDots/Preproc1.jpg

.. |Preprocess2| image:: /soln/DefectDots/Preproc2.jpg

.. |Preprocess3| image:: /soln/DefectDots/Preproc3.jpg

.. |Advanced| image:: /soln/DefectDots/CountAdvanced.jpg    