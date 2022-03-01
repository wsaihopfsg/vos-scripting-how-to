:orphan:

.. _todo:  

.. toctree::

.. include:: /shared/EmulatorComponents.rst

TODO 
+++++++++++++++++

Summary of todo

1. Script panel run through, same as Bible p6-8
2. Intensity based GPO; locator based on CE mark
  
  * Pulsed GPO for pass/fail/recycle
  * difference between Equalize & Normalize
  * Image correction with brightness & contrast?
  * Tolerance settings, p19-21 in Bible

3. HKID...?  

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/Scratch>`__
------------------------------------------------------------------------------------------------------

#. ``todo.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/scratch.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
#. ``todo.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/unscratched.bmp?raw=true>`__ for PASS with no patch detected.
#. ``todo.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/scratched_hidden.bmp?raw=true>`__ for FAIL due to scratch detected.

   * At the :hoverxreftooltip:`Sensor Setup page <soln/ROI/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|, set |demoimg| |cir2| to the folder where ``QR1.bmp`` has been saved 

Tools Explanation
-----------------
* At the ``Tool Setup`` page |toolsetup|, click on |takepic| until ``todo.bmp`` is loaded. 

//.. image:: /code/Soln/Scratch/scratched_hidden.bmp

* 3 tools have been used

  * A ``todo`` tool named ``Pre``
  * Another ``todo`` tool named ``Pre1`` 
  * A ``todo`` tool named ``N`` 

  
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

    //todo

* Line 1: todo
* Line 2: todo

Running the solution
--------------------

* At the ``Run Solution`` |runsoln| page, click on ``Manual Trigger`` |manTrig| button 


#multiple #preprocessor #scratch #detection #remove #blob #erode #dilate #stacking #stack

