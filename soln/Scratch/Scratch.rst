.. toctree::

.. include:: /shared/EmulatorComponents.rst

Scratch Detection 
+++++++++++++++++

This sample demonstrates

#. Stacking of multiple preprocessors
#. Use of the ``erode`` preprocessor

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/Scratch>`__
------------------------------------------------------------------------------------------------------

#. ``scratch.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/scratch.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
#. ``unscratched.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/unscratched.bmp?raw=true>`__ for PASS with no patch detected.
#. ``scratched_hidden.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/scratched_hidden.bmp?raw=true>`__ for FAIL due to scratch detected.

   * At the Sensor Setup page |sensorsetup|, set |demoimg| to the folder where the image files have been saved.

Tools Explanation
-----------------
* At the ``Tool Setup`` page |toolsetup|, click on |takepic| until ``scratched_hidden.bmp`` is loaded. 

.. image:: /code/Soln/Scratch/scratched_hidden.bmp

* 3 tools have been used

  * A ``Preprocess`` tool named ``Pre`` whose region-of-interest (ROI) covers the whole picture
  * Another ``Preprocess`` tool named ``Pre1`` whose ROI overlaps with ``Pre``
    * From the ``Tool List`` we can see that ``Pre`` is executed before ``Pre1``. 
  * A ``Count`` tool named ``N`` that has an ROI made artificially smaller than ``Pre`` & ``Pre1`` 

* To keep things simple, we first make the effects by ``Pre1`` and ``Count`` invisible by clicking on their ``visibility toggle`` |invisible|. The resulting ``Tool List`` should look like 

  .. image:: /soln/Scratch/pre_visible_only.jpg

* Right-click on the row occupied by the preprocessor ``Pre`` in the ``Tool List``, to bring up properties of ``Pre``. Drag the ``Preprocess Properties`` window so that it is not blocking the main picture. The 5 preprocessors used in ``Pre`` are

  #. Normalize
  #. Threshold (band)
  #. Invert
  #. Remove blobs
  #. Erode

* We can turn preprocessors 2-5 off by selecting ``--`` and click on ``apply`` |apply| to see the immediate effects on the image. As long as ``ok`` |ok| is not invoked, it is still possible to regain the original settings for all preprocessors by clicking ``cancel`` |cancel|.

  .. image:: /soln/Scratch/pre_1.jpg

* The ``Min %`` & ``Max %`` is set to 5 & 85 respectively to remove much of the lighter gray background noise and subsequent normalization would help make the scratch more visible.

  .. image:: /soln/Scratch/pre_1img.jpg

* Next we turn preprocessors 3-5 off, which effctively turns the image into binary.

  .. image:: /soln/Scratch/pre_12img.jpg

* When preprocessors 4-5 are turned off, each binary pixel is inverted.

  .. image:: /soln/Scratch/pre_123img.jpg

* When only preprocessor 5 in ``Pre`` off, the ``Remove blobs`` tool removes all of the smallest patches, so that the larger patches remain. Details of the ``Remove blob`` can be found :doc:`here </soln/DefectDots/DefectDots>`

  .. image:: /soln/Scratch/pre_1234img.jpg

* We do not directly use a larger ``Max Area``, ``Max Width`` & ``Max Height`` here to remove the larger patches together because part of the scratch may also be removed.
  
+-------------------+--------------------+-----------------------------+
|                   |Pic. above, removes |Pic. below, removes          |
|                   |                    |                             |              
|                   |small patches only  |big & small patches together |
+-------------------+--------------------+-----------------------------+
|Max Area           |400                 |1500                         |
+-------------------+--------------------+-----------------------------+
|Max Width          |30                  |100                          |
+-------------------+--------------------+-----------------------------+
|Max Height         |30                  |100                          |
+-------------------+--------------------+-----------------------------+

  .. image:: /soln/Scratch/pre_1234big.jpg

* The last preprocessor in ``Pre`` is the ``Erode`` tool, which makes the black patches and most importantly the scratch line slightly larger so to prevent ``Remove blobs`` from removing part of the scratch.

.. image:: /soln/Scratch/pre_12345img.jpg

* After making ``Pre1`` visible, right click on its row in the ``Tool List`` to bring up its properties. There is only 1 preprocessor in ``Pre1``, which is a ``Remove blobs`` tool to remove the larger patches. The final result from stacking these 2 preprocessors is only a slightly expanded version of the scratch.

 .. image:: /soln/Scratch/pre_123456img.jpg

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
        SetDisplayStatus("Fail with "+N+" scratches detected","red")
    endif

* The code uses the count value ``N`` to decide whether to pass or fail the scratch inspection, and output by ``SetDisplayStatus`` with the number of scratches detected.

Running the solution
--------------------

* At the ``Run Solution`` |runsoln| page, click on ``Manual Trigger`` |manTrig| button to toggle between the 2 pictures

+-------------------------+
||pass|                   |
+-------------------------+
|                         |
+-------------------------+
||fail|                   |
+-------------------------+

#multiple #preprocessor #scratch #detection #remove #blob #erode #dilate #stacking #stack

.. |pass| image:: /soln/Scratch/pass.jpg

.. |fail| image:: /soln/Scratch/fail.jpg
