:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

External Trigger Setup and Connection
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

1. Setting up of GPIOs 
2. Wiring of GPIs & configuration in VOS
3. Wiring of GPOs & configuration in VOS

Setting up of GPIOs
---------------------

* At the :hoverxreftooltip:`Sensor Setup page <soln/Hover/inspectiontrig:Inspection Trigger Setup>` |sensorsetup| |cir1|, set ``Trigger Source`` to ``Inspection Trigger`` |cir2|.

* At the :hoverxreftooltip:`Setup Connections <soln/Hover/setupio:Setup IO>` |conn| |cir1|, ``Setup I/O`` |cir2| is used for interface configuration.

* There is an ``Edge Count`` tool |edgecounttool| named ``E`` with preprocessor as shown below

  ======================================== ============================================================
  |edgecountprop|                          |edgecountpre|
  Properties of edge count tool            Properties of the preprocessor of the edge count tool
  ======================================== ============================================================

  .. |edgecountprop| image:: /soln/Boxrot/boxrotedgecountprop.jpg
  .. |edgecountpre| image:: /soln/Boxrot/boxrotedgecountpre.jpg

  * The region-of-interest (ROI) of the ``Edge Count`` tool |edgecounttool| is designed to intersection with the edges of the punnet. With the help of the preprocessor, the 4 intersections points are  
    
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

