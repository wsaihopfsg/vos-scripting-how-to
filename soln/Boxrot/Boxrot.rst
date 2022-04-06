:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Box Orientation & Angle Checking
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

1. Using ``Edge Count`` tool |edgecounttool| as a position locator
2. Using ``Pencil`` tool |penciltool| to join found edges
3. Use of ``Angle`` tool |angletool| to detect the angle between the needle and some reference points

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/Boxrot>`__
----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``strawberries.bin``              |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Boxrot/strawberries.bin?raw=true>`__                      |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <soln/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution        |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``trans1.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Boxrot/trans1.bmp?raw=true>`__                               |  
  |                                     |for a rotated image of a strawberry punnet in the correct orientation but more than the rotation threshold. Should return RECYCLE.                     |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``trans2.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Boxrot/trans2.bmp?raw=true>`__                               |  
  |                                     |for an unrotated image of a strawberry punnet in the correct orientation. Should return PASS.                                                          |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``trans3.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Boxrot/trans3.bmp?raw=true>`__                               |  
  |                                     |for a rotated image of a strawberry punnet in the correct orientation but more than the rotation threshold. Should return RECYCLE.                     |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |5. ``trans4.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Boxrot/trans4.bmp?raw=true>`__                               |  
  |                                     |for an unrotated image of a strawberry punnet in the correct orientation. Should return PASS.                                                          |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``trans5.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Boxrot/trans5.bmp?raw=true>`__                               |  
  |                                     |for an unrotated image of a strawberry punnet in the wrong orientation. Should return FAIL.                                                            |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |7. ``trans6.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Boxrot/trans6.bmp?raw=true>`__                               |
  |                                     |for a rotated image of a strawberry punnet in the wrong orientation and less than rotation threshold. Should return FAIL.                              |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <soln/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                             |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where the images have been saved                                                                                                                     |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <soln/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until  ``trans2.bmp`` is loaded. 

.. image:: /soln/Boxrot/boxrottoolsetup.jpg

* There is an ``Edge Count`` tool |edgecounttool| named ``E`` with preprocessor as shown below

  ======================================== ============================================================
  |edgecountprop|                          |edgecountpre|
  Properties of edge count tool            Properties of the preprocessor of the edge count tool
  ======================================== ============================================================

  .. |edgecountprop| image:: /soln/Boxrot/boxrotedgecountprop.jpg
  .. |edgecountpre| image:: /soln/Boxrot/boxrotedgecountpre.jpg

  * The region-of-interest (ROI) of the ``Edge Count`` tool |edgecounttool| is designed to intersect with the edges of the punnet. With the help of the preprocessor, the 4 intersections points are  
    
    * Point ``PP`` is located at the low right-hand corner of the intersections
    * Point ``PP1`` is located at the top right-hand corner of the intersections
    * Point ``PP2`` is located at the top left-hand corner of the intersections
    * Point ``PP3`` is located at the low left-hand corner of the intersections
  
* 2 ``Pencil`` tools |penciltool| defined

  * ``Pencil`` tool |penciltool| name ``P`` joining points ``PP2`` to ``PP1``
  * ``Pencil`` tool |penciltool| name ``P1`` joining points ``PP2`` to ``PP3``

* An ``Angle`` tool |angletool| named ``A`` defined to compute the angle between ``P`` & ``P1``  

.. note::
  Make sure ``A`` is identical to the picture shown `here <#tools-explanation>`__. Sometimes the adjacent angle on a straight line of A is high-lighted which may give outcomes that differ from the solution design.

* A ``Distance`` tool |distancetool| named ``L`` which measures the distance between ``PP`` & ``PP1``.
  
Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <soln/Hover/editscript:Edit Script>` |edit| |cir1|  

Solution Initialize
#####################
* Choose the predefined function ``Solution Initialize`` at the bottom left 

  |fn_init|

* In the Script Function window we see 

.. code-block::
  :linenos:

  pi = 3.141592654
  thresL = 700
  thresA = 10

* Line 1: Value of :math:`{π}`
* Line 2: Threshold distinguishing the length from breadth of the rectangle
* Line 3: Threshold for maximum allowed angle of rotation

Pre Image Process
#####################

* Choose the predefined function ``Pre Image Process`` at the bottom left 

  |fn_pre|

* In the Script Function window we see only 1 line of code which resets the ``Inspection Status``

.. code-block::
  :linenos:

  SetDisplayStatus( 0,0 )

Post Image Process
#####################
* Choose the predefined function ``Post Image Process`` at the bottom left 

  |fn_post|

* In the Script Function window we see

.. code-block::
  :linenos:

  nowA = A/180 * pi
  if(A>90  ) 
      nowA = (180-A)/180 * pi
  endif
  nowL = L * sin( nowA )
  if( nowL > thresL ) 
      PASS = 0
      RECYCLE = 0
      FAIL = 1
  else
      absA = A-90
      if(absA < 0) 
          absA = -1.0*absA
      endif
      if( absA > thresA ) 
          PASS = 0
          RECYCLE = 1
          FAIL = 0
      else
          PASS = 1
          RECYCLE = 0
          FAIL = 0
      endif
  endif

* Line 1: Convert ``A`` from degrees to radians
* Lines 2-4: If ``A`` is greater than 90, find the adjacent angle on a straight line in radians
* Line 5: Find the height of the parallelogram and return the value to ``nowL``
  
  .. note::
    A rectangle is a special parallelogram 

* Lines 6-9: ``nowL`` is above ``thresL``, return ``FAIL``
* Line 11: Find angle of rotation and return to ``absA``
* Lines 12-14: Return the absolute value of ``absA`` if needed
* Lines 15-18: ``absA`` is above ``thresA``, return ``RECYCLE``
* Lines 20-23: Return ``PASS``

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <soln/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 

================ =================
|dial1|          |dial2|         
``trans1.bmp``   ``trans2.bmp`` 
|dial3|          |dial4|         
``trans3.bmp``   ``trans4.bmp`` 
|dial5|          |dial6|        
``trans5.bmp``   ``trans6.bmp`` 
================ =================

.. |dial1| image:: /soln/Boxrot/boxrotresulttrans1.jpg
  :width: 300px
.. |dial2| image:: /soln/Boxrot/boxrotresulttrans2.jpg
  :width: 300px
.. |dial3| image:: /soln/Boxrot/boxrotresulttrans3.jpg
  :width: 300px
.. |dial4| image:: /soln/Boxrot/boxrotresulttrans4.jpg
  :width: 300px
.. |dial5| image:: /soln/Boxrot/boxrotresulttrans5.jpg
  :width: 300px
.. |dial6| image:: /soln/Boxrot/boxrotresulttrans6.jpg
  :width: 300px
.. |fast| image:: /soln/Boxrot/boxrotinspect.jpg

.. note:: 
  |fast|
  
  The tools used in this solution ensures a very quick inspection time.

.. tip::
  #angle #edge #count #fast #pencil #preprocessor

