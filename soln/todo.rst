:orphan:

.. _todo:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

TODO 
+++++++++++++++++

This sample demonstrates

#. 1st point
#. 2nd point

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/Scratch>`__
------------------------------------------------------------------------------------------------------

#. ``todo.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/scratch.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
#. ``todo.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/unscratched.bmp?raw=true>`__ for PASS with no patch detected.
#. ``todo.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/scratched_hidden.bmp?raw=true>`__ for FAIL due to scratch detected.

   * At the Sensor Setup page |sensorsetup|, set |demoimg| to the folder where the image files have been saved.

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

