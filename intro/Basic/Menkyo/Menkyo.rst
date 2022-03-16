:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

OCR of Asian Scripts & Colour Discrimination 
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

1. OCR of Asian scripts
2. Conversion of Japanese era dats to Julian Calendar
3. Use of VOS lighting to discriminate the color-coded driving licenses with ``Intensity tool``
4. Use of ``Edge Count Tool`` to detect presence and absence of Japanese words
5. Use of a ``locator`` for all tool locations 
6. Use of ``readVar`` function 

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``readVar``       |``varName``                       |Return the value of ``varName``                                   |
+------------------+----------------------------------+------------------------------------------------------------------+

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/Menkyo>`__
------------------------------------------------------------------------------------------------------

+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|1.``menkyo.bin``                     |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/menkyo.bin?raw=true>`__                           |
|                                     |                                                                                                                                                       |
|                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution |  
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|2.``green1.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/green1.bmp?raw=true>`__                              |  
|                                     |for an unrotated green color-coded driving license.                                                                                                    |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|3.``green2.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/green2.bmp?raw=true>`__                              |  
|                                     |for a rotated green color-coded driving license.                                                                                                       |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|4.``green3.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/green3.bmp?raw=true>`__                              |  
|                                     |for another rotated green color-coded driving license.                                                                                                 |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|5.``blue1.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/blue1.bmp?raw=true>`__                               |  
|                                     |for an unrotated blue color-coded driving license.                                                                                                     |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|6.``blue2.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/blue2.bmp?raw=true>`__                               |  
|                                     |for a rotated blue color-coded driving license.                                                                                                        |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|7.``blue3.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/blue3.bmp?raw=true>`__                               |  
|                                     |for another rotated blue color-coded driving license.                                                                                                  |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|8.``gold1.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/gold1.bmp?raw=true>`__                               |  
|                                     |for an unrotated gold color-coded driving license.                                                                                                     |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|9.``gold2.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/gold2.bmp?raw=true>`__                               |  
|                                     |for a rotated gold color-coded driving license.                                                                                                        |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|10.``gold3.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Scratch/gold3.bmp?raw=true>`__                               |
|                                     |for another rotated gold color-coded driving license.                                                                                                  |   
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

