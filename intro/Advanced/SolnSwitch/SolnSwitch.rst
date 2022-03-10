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
  |1. ``00.bin``                        |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/SolnSwitch/00.bin?raw=true>`__ that performs          |
  |                                     |                                                                                                                                                       |
  |                                     |* Circle detection                                                                                                                                     |
  |                                     |* Inner & outer diamters computation                                                                                                                   |
  |                                     |* Coordinates of the centre of circle                                                                                                                  |
  |                                     |* Switching to solution ``01.bin``                                                                                                                     |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``01.bin``                        |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/SolnSwitch/01.bin?raw=true>`__  that performs         |
  |                                     |                                                                                                                                                       |
  |                                     |* Region-of-interest (ROI) adjustment base on the values found in solution ``00.bin``                                                                  |
  |                                     |* ``Retrigger`` for evaluation of the same image based on the newly adjusted ROI                                                                       |
  |                                     |* Switching back to solution ``00.bin``                                                                                                                |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``pic4pt5.bmp``                   |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/SolnSwitch/pic4pt5.bmp?raw=true>`__                      |  
  |                                     |with an inner diameter of ~4.5cm.                                                                                                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``pic5.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/SolnSwitch/pic5.bmp?raw=true>`__                         |  
  |                                     |with an inner diameter of ~5.0cm.                                                                                                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |5 ``pic6.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/SolnSwitch/pic6.bmp?raw=true>`__                         |  
  |                                     |with an inner diameter of ~6.0cm.                                                                                                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``pic6pt5.bmp``                   |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/SolnSwitch/pic6pt5.bmp?raw=true>`__                      |  
  |                                     |with an inner diameter of ~6.5cm.                                                                                                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |7. ``pic7.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/SolnSwitch/pic7.bmp?raw=true>`__                         |
  |                                     |with an inner diameter of ~6.0cm.                                                                                                                      |   
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where these images have been saved                                                                                                                   |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tool Explanation
-----------------

* * At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| and load any of the above ``.bmp`` image. 

* 3 tools have been used

  * A ``Count`` tool named ``OuterC``, where the ``Object type`` has been set to ``Bright`` which detects the outer ring in ``00.bin``
  * Another ``Count`` tool named ``InnerC``, where the ``Object type`` has been set to ``Dark`` which detects the inner ring in ``00.bin``

  +-------------------+--------------------+
  ||inner|            ||outer|             |
  +-------------------+--------------------+
  |InnerC's properties|OuterC's properties |
  +-------------------+--------------------+

  * An ``OCR`` tool named ``OCR`` with these properties for ``01.bin``
  
    .. image:: /intro/Advanced/SolnSwitch/OCRprop.jpg
      :width: 300px

    * In the ``font editor`` |fonteditor|, we would have observed that 2 font sizes have been taught-in.
  
.. |inner| image:: /intro/Advanced/SolnSwitch/InnerCprop.jpg
  :width: 300px

.. |outer| image:: /intro/Advanced/SolnSwitch/OuterCprop.jpg  
  :width: 300px

Code Walk-Through
-----------------

* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|. There are 5 user-defined functions in addition to the 4 predefined functions.  

User-Defined function ``parseIn()``
####################################

* Choose the User-function ``parseIn()`` at the bottom left 

.. image:: /intro/Advanced/SolnSwitch/parseIn.jpg

* In the Script Function window we see

.. code-block:: 
  :linenos:

  nowCtr = 0
  cirIndex = -1
  while( nowCtr < InnerC )
      if(InMinor.[nowCtr] >  cirMinD) 
          MajMinRatio = InMajor.[nowCtr]/InMinor.[nowCtr] * 1.0
          if(MajMinRatio < cirMajMinRatio) 
              //opStr = FormatString("[MajMinRatio%.2f]")
              cirIndex = nowCtr
              nowCtr = InnerC
          endif
      endif
    nowCtr = nowCtr+1
  endwhile
  return(cirIndex)

.. _parseInCode:

* Line 1: Initialize counter ``nowCtr``
* Line 2: Initialize index of circle ``cirIndex``
* Lines 3-13: Loop to look for circular Object
* Line 4: Length of the minor axis has to be greater than the minimum circle diameter ``cirMinD`` |cirmind|
* Line 5: Computer ratio between Major and minor axes
* Line 6: Check if the above ratio is smaller than threshold ``cirMajMinRatio``. 
* Line 8: Set the circle index ``cirIndex`` to ``nowCtr`` because a circle has been found
* Lines 9 & 12: Counter operations
* Line 14: Function return

.. |cirmind| replace:: ``cirMinD``
.. _cirmind: SolnSwitch  

User-Defined function ``parseOut()``
####################################

* Choose the User-function ``parseOut()`` at the bottom left 

.. image:: /intro/Advanced/SolnSwitch/parseOut.jpg

* In the Script Function window we see

.. code-block:: 
  :linenos:

  nowCtr = 0
  cirIndex = -1
  while( nowCtr < OuterC )
      if(OutMinor.[nowCtr] >  cirMinD) 
          MajMinRatio = OutMajor.[nowCtr]/OutMinor.[nowCtr] * 1.0
          if(MajMinRatio < cirMajMinRatio) 
              //opStr = FormatString("[MajMinRatio%.2f]")
              cirIndex = nowCtr
              nowCtr = OuterC
          endif
      endif
      nowCtr = nowCtr+1
  endwhile
  return(cirIndex)

* This code is almost identical to ``parseIn``. Please refer to :ref:`above for explanation <parseInCode>`.

User-Defined function ``findMean2Num(p1,p2)``
###################################################

* Choose the User-function ``findMean2Num(p1,p2)`` at the bottom left 

.. image:: /intro/Advanced/SolnSwitch/mean.jpg

* In the Script Function window we see only 1 line of code which returns the average of the 2 input parameters.

.. code-block:: 
  :linenos:

  return((p1+p2)*0.5)

User-Defined function ``setOcROI()``
####################################

* Choose the User-function ``setOcROI()`` at the bottom left 

.. image:: /intro/Advanced/SolnSwitch/setROI.jpg

* In the Script Function window we see

.. code-block:: 
  :linenos:

  Tool1Pos[0] = "setroi"
  Tool1Pos[1] = "OCR" 
  Tool1Pos[2] = 0
  Tool1Pos[3] = "annulus"
  Tool1Pos[4] = xx
  Tool1Pos[5] = yy
  Tool1Pos[6] = xx
  Tool1Pos[7] = yy + (OutDiameter * 0.5)
  Tool1Pos[8] = xx
  Tool1Pos[9] = yy + (InDiameter * 0.5)
  setParam(10,Tool1Pos)
  return(0)

* Lines 1-10: Parameters for setting ROI
  
  0. Name of the parameter being set, ``setroi``
  1. Tool name, ``OCr``
  2. CamID 
  3. ROI Type, ``annulus``
  4. xx is the x-coordinate of the centre of the concentric circles
  5. yy is the y-coordinate of the centre of the concentric circles
  6. x-coordinate of a point on the outer diameter of the ``annulus``
  7. y-coordinate of a point on the outer diameter of the ``annulus``
  8. x-coordinate of a point on the inner diameter of the ``annulus``
  9. y-coordinate of a point on the inner diameter of the ``annulus``
   
* Line 11: Changing ROI 
* Please refer to :ref:`here for more details <setRoiTable>`
  
User-Defined function ``removeChar(p1,p2)``
##############################################

* Choose the User-function ``removeChar(p1,p2)`` at the bottom left 

.. image:: /intro/Advanced/SolnSwitch/removeChar.jpg

* The code and explanation is :ref:`identical to here <removechar>`.  

.. _solninit:

Solution Initialize (``00.bin``)
####################################

* Choose the predefined function ``Solution Initialize`` at the bottom left 
  .. image:: /intro/Advanced/SolnSwitch/mean.jpg

* In the Script Function window we see  

.. code-block::
  :linenos:

  cirMajMinRatio = 1.01 // major/minor must be smaller than this
  cirMinD = 300 //minimum value for minor axis
  postImg = 0


Post Image Process (``00.bin``)
####################################

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

