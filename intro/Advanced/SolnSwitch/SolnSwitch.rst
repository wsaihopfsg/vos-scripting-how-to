:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Scale-Invariant OCR On a Rim with 2 Solutions Working in Tandem 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Scale-invariant OCR on a rim
2. Use of multi solutions for solving vision problems  
3. Use of ``persistent variables``
     

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``ChangeSolution``|``requestedSolutionID``           |Load a the Solution file specified by ``requestedSolutionID``     |
+------------------+----------------------------------+------------------------------------------------------------------+
|``ReTrigger``     |``camID``                         |Reprocessing of the last image at ``camID``                       |
+------------------+----------------------------------+------------------------------------------------------------------+

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Advanced/SolnSwitch>`__
----------------------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1.``00.bin``                         |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/SolnSwitch/00.bin?raw=true>`__ that performs          |
  |                                     |                                                                                                                                                       |
  |                                     |* Circle detection                                                                                                                                     |
  |                                     |* Inner & outer diamters computation                                                                                                                   |
  |                                     |* Coordinates of the centre of circle                                                                                                                  |
  |                                     |* Switching to solution ``01.bin``                                                                                                                     |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir1| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2.``01.bin``                         |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/SolnSwitch/01.bin?raw=true>`__  that performs         |
  |                                     |                                                                                                                                                       |
  |                                     |* Region-of-interest (ROI) adjustment base on the values found in solution ``00.bin``                                                                  |
  |                                     |* ``Retrigger`` for evaluation of the same image based on the newly adjusted ROI                                                                       |
  |                                     |* Switching back to solution ``00.bin``                                                                                                                |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir1| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3.``todo.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/unscratched.bmp?raw=true>`__                         |  
  |                                     |for PASS with no patch detected.                                                                                                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4.``todo.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/scratched_hidden.bmp?raw=true>`__                    |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where ``todo.bmp`` have been saved                                                                                                                   |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* * At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until  ``todo.bmp`` is loaded. 

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
* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  

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

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 

#multiple #preprocessor #scratch #detection #remove #blob #erode #dilate #stacking #stack

