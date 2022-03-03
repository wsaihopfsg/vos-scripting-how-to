:orphan:

.. _gpio:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Presence / Absence Detection with GPO In Diverse Lighting 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of the  ``Match`` tool |matchtool| and ``Locator`` to deal with position and rotation of the object-of-interest
2. Use of the ``erode`` & ``normalize`` preprocessor for dealing with diverse lighting conditions 
3. Use of the ``Intensity`` tool |intensitytool| for plastic cover presence detection
4. Use the the ``GetBit``, ``SetBit`` & ``ClearBit`` functions

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``GetBit``        |``value``, ``bitPosition``        |Return the bit state of ``bitPosition`` in ``value``              |
+------------------+----------------------------------+------------------------------------------------------------------+
|``SetBit``        |``value``, ``bitPosition``        |Return the value after setting the bit state of ``bitPosition``   |
|                  |                                  |to 1 in ``value``                                                 |
+------------------+----------------------------------+------------------------------------------------------------------+
|``ClearBit``      |``value``, ``bitPosition``        |Return the value after clearing the bit state of ``bitPosition``  |
|                  |                                  |to 0 in ``value``                                                 |
+------------------+----------------------------------+------------------------------------------------------------------+

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/GPIO>`__
------------------------------------------------------------------------------------------------------

#. ``preAbsence.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/preAbsence.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
#. ``nolight1.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/nolight1.bmp?raw=true>`__ without plastic cover taken in a room with natural window light but no ceiling light
#. ``nolight1a.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/nolight1a.bmp?raw=true>`__ is a rotated version of ``nolight1.bmp``
#. ``nolight2.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/nolight2.bmp?raw=true>`__ with plastic cover taken in a room with no ceiling light
#. ``bright1.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/bright1.bmp?raw=true>`__ with plastic cover taken in a room with natural window light and ceiling light on
#. ``bright2.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/bright2.bmp?raw=true>`__ without plastic cover taken in a room with natural window light and ceiling light on
#. ``rmFlash1.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmFlash1.bmp?raw=true>`__ without plastic cover taken in a totally dark room with camera flash
#. ``rmFlash1a.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmFlash1a.bmp?raw=true>`__ is a rotated version of ``rmFlash1.bmp`` and serves as the template for Tool Setup |toolsetup|
#. ``rmLight1.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmLight1.bmp?raw=true>`__ with plastic cover taken in a windowless room with ceiling light
#. ``rmLight2.bmp``: `Another image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmLight2.bmp?raw=true>`__ taken in the same conditions as ``rmLight1.bmp``
#. ``rmLight3.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GPIO/rmLight3.bmp?raw=true>`__ without plastic cover taken in a windowless room with ceiling light

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

