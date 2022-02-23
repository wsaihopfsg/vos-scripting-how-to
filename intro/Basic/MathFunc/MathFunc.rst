:orphan:

.. _mathfunc:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Mathematical Functions
++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of the  ``Angle`` , ``Distance`` & ``Rake`` tools
2. Built-in Mathematical functions
   
   * ``sin`` (:math:`{x}`) - Returns :math:`\sin{x}`, :math:`{x}` in radians
   * ``cos`` (:math:`{x}`) - Returns :math:`\cos{x}`, :math:`{x}` in radians
   * ``tan`` (:math:`{x}`) - Returns :math:`\tan{x}`, :math:`{x}` in radians
   * ``asin`` (:math:`{x}`) - Returns :math:`\arcsin{x}` within [-:math:`\pi`/2, :math:`\pi`/2] radians; :math:`{x}` is [-1,1]
   * ``acos`` (:math:`{x}`) - Returns :math:`\arccos{x}` within [-:math:`\pi`/2, :math:`\pi`/2] radians; :math:`{x}` is [-1,1]
   * ``atan`` (:math:`{x}`) - Returns :math:`\arctan{x}` within [-:math:`\pi`/2, :math:`\pi`/2] radians
   * ``atan2`` (:math:`{y}` , :math:`{x}`) - Returns :math:`\arctan{y/x}` within [-:math:`\pi`, :math:`\pi`] radians
   * ``exp`` (:math:`{x}`) - Returns :math:`e^x`
   * ``logn`` (:math:`{x}`) - Returns :math:`ln(x)`
   * ``sqrt`` (:math:`{x}`) - Returns :math:`\sqrt{x}`
   * ``pow`` (:math:`{x}` , :math:`{y}`) - Returns :math:`x^y`
   * ``GetMean`` (*measurementVar*) - returns the arithmetic mean of *measurementVar*
   * ``GetStdDev`` (*measurementVar*) - returns the standard deviation of *measurementVar*
   * ``GetMin`` (*measurementVar*) - returns the minimum value of *measurementVar*
   * ``GetMax`` (*measurementVar*) - returns the maximum value of *measurementVar*
  
`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/MathFunc>`__
---------------------------------------------------------------------------------------------------------

1. ``mathFunc.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/MathFunc/mathFunc.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
2. ``card.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/MathFunc/card.bmp?raw=true>`__ with a rotated rectangle

   * At the Sensor Setup page |sensorsetup|, set |demoimg| to the folder where ``vosrox.bmp`` have been saved 

Tools Explanation
-----------------
* At the ``Tool Setup`` page |toolsetup|, click on |takepic| until ``card.bmp`` is loaded.
* 3 ``Angle`` tools named ``A0`` , ``A1`` & ``A2`` are used
* 2 ``Rake`` tools named ``RakeShort`` & ``RakeLong`` with 7 and 11 rakes for the width and length of the rectangle respectively.
* 1 ``Distance`` tool named ``Slant`` for the length of the diagonal.

Code Walk-Through
-----------------
* Click on ``Edit Script`` |edit| 


.. _deg2rad:

deg2rad(p1)
##################
* Choose the user-defined function ``deg2rad(p1)`` at the bottom left 

  .. image:: /intro/Basic/MathFunc/deg2rad.jpg

* In the Script Function window we see 

.. code-block::
    :linenos:

    return(p1/180*3.141592654)

* Line 1: Converts the degree input into radians

.. _rad2deg:

rad2deg(p1)
##################
* Choose the user-defined function ``rad2deg(p1)`` at the bottom left 

  .. image:: /intro/Basic/MathFunc/rad2deg.jpg

* In the Script Function window we see 

.. code-block::
    :linenos:

    return(p1/3.141592654*180)

* Line 1: Returns radians input into degrees

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
* Line 11-14: Return the mean, standard deviation, minimum and maximum of ``RakeLong`` respectively

Running the solution
--------------------

* At the ``Run Solution`` |runsoln| page, click on ``Manual Trigger`` |manTrig| button
  
  .. image:: /intro/Basic/MathFunc/MathFunc.jpg

  
* Insepction of the ``Variable List`` the results for the various variables can be seen.
 
  .. image:: /intro/Basic/MathFunc/varlist.jpg

#math #radian #degree #trigonometry #logarithm
