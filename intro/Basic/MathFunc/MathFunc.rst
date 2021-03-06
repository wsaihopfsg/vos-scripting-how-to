:orphan:

.. _mathfunc:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Mathematical Functions
++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of the  ``Angle`` , ``Distance`` & ``Rake`` tools
2. Built-in Mathematical functions

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``sin``           |:math:`{x}`                       |Return :math:`\sin{x}`, :math:`{x}` in radians                    |
+------------------+----------------------------------+------------------------------------------------------------------+
|``cos``           |:math:`{x}`                       |Return :math:`\cos{x}`, :math:`{x}` in radians                    |
+------------------+----------------------------------+------------------------------------------------------------------+
|``tan``           |:math:`{x}`                       |Return :math:`\tan{x}`, :math:`{x}` in radians                    |
+------------------+----------------------------------+------------------------------------------------------------------+
|``asin``          |:math:`{x}`                       |Return :math:`\arcsin{x}`, :math:`{x}` within [-:math:`\pi`/2,    |
|                  |                                  |:math:`\pi`/2] radians;                                           |    
|                  |                                  |                                                                  |
|                  |                                  |:math:`{x}` is [-1,1]                                             |
+------------------+----------------------------------+------------------------------------------------------------------+
|``acos``          |:math:`{x}`                       |Return :math:`\arccos{x}`, :math:`{x}` within [-:math:`\pi`/2,    |
|                  |                                  |:math:`\pi`/2] radians;                                           |    
|                  |                                  |                                                                  |
|                  |                                  |:math:`{x}` is [-1,1]                                             |
+------------------+----------------------------------+------------------------------------------------------------------+
|``atan``          |:math:`{x}`                       |Return :math:`\arctan{x}`, :math:`{x}` within [-:math:`\pi`/2,    |
|                  |                                  |:math:`\pi`/2] radians;                                           |    
+------------------+----------------------------------+------------------------------------------------------------------+
|``atan2``         |:math:`{y}`, :math:`{x}`          |Return :math:`\arctan{y/x}`, within [-:math:`\pi`, :math:`\pi`/2] |
|                  |                                  |                                                                  |    
|                  |                                  |radians                                                           |
+------------------+----------------------------------+------------------------------------------------------------------+
|``exp``           |:math:`{x}`                       |Return :math:`e^x`                                                |
+------------------+----------------------------------+------------------------------------------------------------------+
|``logn``          |:math:`{x}`                       |Return :math:`ln(x)`                                              |
+------------------+----------------------------------+------------------------------------------------------------------+
|``sqrt``          |:math:`{x}`                       |Return :math:`\sqrt{x}`                                           |
+------------------+----------------------------------+------------------------------------------------------------------+
|``pow``           |:math:`{x}`, :math:`{y}`          |Return :math:`x^y`                                                |
+------------------+----------------------------------+------------------------------------------------------------------+
|``GetMean``       |``measurementVar``                |Return mean of ``measurementVar``                                 |
+------------------+----------------------------------+------------------------------------------------------------------+
|``GetStdDev``     |``measurementVar``                |Return standard deviation of ``measurementVar``                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``GetMin``        |``measurementVar``                |Return minimum value of ``measurementVar``                        |
+------------------+----------------------------------+------------------------------------------------------------------+
|``GetMax``        |``measurementVar``                |Return maximum value of ``measurementVar``                        |
+------------------+----------------------------------+------------------------------------------------------------------+
|``RequestRelearn``|``measurementVar``                |Reset statistics of ``measurementVar``                            |
+------------------+----------------------------------+------------------------------------------------------------------+

  
`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/MathFunc>`__
---------------------------------------------------------------------------------------------------------

+-------------------------------+---------------------------------------------------------------------------------------------------------------------------------+
|1. ``mathFunc.bin``            ||download1|                                                                                                                      |
|                               |                                                                                                                                 |      
|                               |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1|, import |import||
|                               |  the solution |cir2|                                                                                                            |
+-------------------------------+---------------------------------------------------------------------------------------------------------------------------------+
|2. ``card.bmp``                ||download2| with a rotated rectangle                                                                                             |
|                               |                                                                                                                                 |
|                               |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                |
|                               |                                                                                                                                 |
|                               |  set |demoimg| |cir2| to the folder                                                                                             |
|                               |                                                                                                                                 |
|                               |  where ``vosrox.bmp`` have been saved                                                                                           |
+-------------------------------+---------------------------------------------------------------------------------------------------------------------------------+

.. |download1| replace:: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/MathFunc/mathFunc.bin?raw=true>`__
.. |download2| replace:: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/MathFunc/card.bmp?raw=true>`__

.. .. |test| replace:: ``Download``
.. .. _test: https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/MathFunc/mathFunc.bin?raw=true

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``card.bmp`` is loaded.
* 3 ``Angle`` tools named ``A0`` , ``A1`` & ``A2`` are used
* 2 ``Rake`` tools named ``RakeShort`` & ``RakeLong`` with 7 and 11 rakes for the width and length of the rectangle respectively.
* 1 ``Distance`` tool named ``Slant`` for the length of the diagonal.

Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  


.. _deg2rad:

deg2rad(p1)
##################
* Choose the user-defined function ``deg2rad(p1)`` at the bottom left 

  .. image:: /intro/Basic/MathFunc/deg2rad.jpg

* In the Script Function window we see a line of code that converts degree input into radians. 

.. code-block::
    :linenos:

    return(p1/180*3.141592654)

.. _rad2deg:

rad2deg(p1)
##################
* Choose the user-defined function ``rad2deg(p1)`` at the bottom left 

  .. image:: /intro/Basic/MathFunc/rad2deg2.jpg

* In the Script Function window we see a line of code that converts radians into degrees

.. code-block::
    :linenos:

    return(p1/3.141592654*180)

Post Image Process
##################
* Choose the predefined function ``Post Image Process`` at the bottom left 

  .. image:: /intro/Basic/MathFunc/fn_post.jpg

* In the Script Function window we see 

.. code-block::
    :linenos:

    sum3 = A0+A1+A2
    xA0sin = sin(deg2rad(A0))
    xA1tan = tan(deg2rad(A1))
    xA2cos = cos(deg2rad(A2))
    xA0ASin = rad2deg(asin(RakeShort/Slant))
    xA1ACos = rad2deg(acos(RakeShort/Slant))
    xA1Atan = rad2deg(atan(RakeLong/RakeShort))
    xSlantTheory = sqrt(pow(RakeShort,2)+pow(RakeLong,2))
    x2Times3 = exp(logn(2)+logn(3))
    xAtan2 = atan2(1,2)
    xMeanRakeLong = GETMEAN(RakeLong)
    xSDRakeLong = GetStdDev(RakeLong)
    xMinRakeLong = GetMin(RakeLong)
    xMaxRakeLong = GetMax(RakeLong)

* Line 1: Sum ``A0`` , ``A1`` & ``A2``, should be close to 180
* Line 2: Return results of ``sin`` of ``A0`` in radians to ``xA0sin`` 
* Line 3: Return results of ``tan`` of ``A1`` in radians to ``xA1tan`` 
* Line 4: Return results of ``cos`` of ``A2`` in radians to ``xA2cos`` 
* Line 5: Return results of ``asin`` of ``RakeShort``/ ``Slant`` in degrees to ``xA0ASin`` 
* Line 6: Return results of ``acos`` of ``RakeShort``/ ``Slant`` in degrees to ``xA1ACos`` 
* Line 7: Return results of ``atan`` of ``RakeLong`` / ``RakeShort`` in degrees to ``xA1ATan`` 
* Line 8: Return the theoretical value of ``Slant`` based on Pythagoras theorem
* Line 9: Return the value of 2 x 3 using logarithm
* Line 10: Return results of ``atan`` of 1/2
* Line 11-14: Return the ``mean``, ``standard deviation``, ``minimum`` and ``maximum`` of ``RakeLong`` respectively

.. note::  
  * These functions computes the statistical values over multiple runs ``RakeLong``, and since there is only 1 image in this solution and hence the ``mean`` / ``standard deviation`` / ``minimum`` / ``maximum`` are of these values shown in the :ref:`variable list<varlist>` as high-lighted in yellow.
    
  * You may reset the measurement statistics over multiple runs by the ``RequestRelearn`` (*measurementVar*) command. For example ``RequestRelearn(RakeLong)`` resets the statistics for ``RakeLong`` on the next image.
  
  * If you require the statistics of the individual 11 rakes for ``RakeLong``, you may make use of the relevant properties in ``Rake`` tool

  |rakepro|


Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2| 
  
  .. image:: /intro/Basic/MathFunc/MathFunc.jpg

.. _varlist:

* Insepction of the ``Variable List`` the results for the various variables can be seen.
 
  .. image:: /intro/Basic/MathFunc/varlist.jpg

.. tip::
   #math #radian #degree #trigonometry #logarithm

.. |rakepro| image:: /intro/Basic/MathFunc/rakeproperties.jpg