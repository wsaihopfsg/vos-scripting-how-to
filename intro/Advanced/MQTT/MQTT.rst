:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Publishing VOS Data to MQTT & Displaying On Mobile
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of todo

1. Script panel run through, same as Bible p6-8
2. Intensity based GPO; locator based on CE mark
  
  * Pulsed GPO for pass/fail/recycle
  * difference between Equalize & Normalize
  * Image correction with brightness & contrast?
    * https://dsp.stackexchange.com/questions/46564/what-is-the-difference-between-image-normalization-contrast-stretching-and 
  * Tolerance settings, p19-21 in Bible
  * Preprocessors
    * Kernels https://setosa.io/ev/image-kernels/
    * Subtract
    * ...
  * Tools
  * Calibration how-to
  * FTP server 

3. HKID...?  

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``LogStart``      |``fileName``, ``onClient``        |Commence logging of processed data the specified ``fileName``     |
+------------------+----------------------------------+------------------------------------------------------------------+
|``LogStop``       |( )                               |Stop data logging                                                 |
+------------------+----------------------------------+------------------------------------------------------------------+
|``LogImage``      |``fileName``                      |Save image to ``fileName`` for 1 image. ``Image file logging``    |
|                  |                                  ||imgfilelogen| must be enabled                                    |
+------------------+----------------------------------+------------------------------------------------------------------+

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/Scratch>`__
------------------------------------------------------------------------------------------------------

+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|1.``todo.bin``                       |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/scratch.bin?raw=true>`__                          |
|                                     |                                                                                                                                                       |
|                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution |  
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|2.``todo.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/unscratched.bmp?raw=true>`__                         |  
|                                     |for PASS with no patch detected.                                                                                                                       |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|3.``todo.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/scratched_hidden.bmp?raw=true>`__                    |
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

