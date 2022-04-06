:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Punnet Orientation Checking
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

* Using ``Edge Count`` tool |edgecounttool| to find the edge of the punnet with the help of preprocessors
  
`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/Punnet>`__
----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``solution19.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/solution19.bin?raw=true>`  __                      |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <soln/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution        |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``Image2_1.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_1.bmp?raw=true>`__                             |  
  |                                     |for a punnet in the correct orientation. Should return PASS.                                                                                           |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``Image2_2.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_2.bmp?raw=true>`__                             |  
  |                                     |for a punnet in the correct orientation. Should return PASS.                                                                                           |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``Image2_3.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_3.bmp?raw=true>`__                             |  
  |                                     |for a punnet in the correct orientation. Should return PASS.                                                                                           |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |5. ``Image2_6.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_6.bmp?raw=true>`__                             |  
  |                                     |for a punnet in the correct orientation. Should return PASS.                                                                                           |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``Image2_7x.bmp``                 |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_7x.bmp?raw=true>`__                            |  
  |                                     |for a punnet in the wrong orientation. Should return FAIL.                                                                                             |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``Image2_8x.bmp``                 |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_8x.bmp?raw=true>`__                            |  
  |                                     |for a punnet in the wrong orientation. Should return FAIL.                                                                                             |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |7. ``Image2_4.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_4.bmp?raw=true>`__                             |
  |                                     |for a composite image 2 punnets the correct orientation for tool setup. Should return PASS.                                                            |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <soln/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                             |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where the images have been saved                                                                                                                     |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <soln/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until  ``Image2_4.bmp`` is loaded. 

.. image:: /soln/Punnet/punnettoolsetup.jpg

* There is are 2 ``Edge Count`` tools |edgecounttool| defined. One named ``E1`` at the top and another named ``E2`` at the bottom. 
* For ``E1``, its properties and preprocessors are shown below

  ======================================== ============================================================
  |edgecountprop|                          |edgecountpre|
  Properties of ``E1``                     Properties of the preprocessor of ``E1``
  ======================================== ============================================================

  .. |edgecountprop| image:: /soln/Punnet/punnetedgecountprop.jpg
  .. |edgecountpre| image:: /soln/Punnet/punnetedgecountpre.jpg

* For ``E2``, its properties and preprocessors are shown below

  ======================================== ============================================================
  |edgecountprop2|                         |edgecountpre2|
  Properties of ``E2``                     Properties of the preprocessor of ``E2``
  ======================================== ============================================================

  .. |edgecountprop2| image:: /soln/Punnet/punnetedgecountprop2.jpg
  .. |edgecountpre2| image:: /soln/Punnet/punnetedgecountpre2.jpg

* The purpose of each preprocessor is summarized here
  
  ================== ====================================================================
  ``Equalize``       To deal with lighting variations
  ``Project H``      To get an average intensity horizontally
  ``Convolve 3x3``   An Sobel edge detection in the y-direction
  ``Threshold``      Heuristic threshold to obtain the most prominent edges 
  ================== ====================================================================
  
  * The region-of-interest (ROI) of the ``Edge Count`` tool |edgecounttool| is designed to intersect with the top and bottom edges of the punnet. Numerous intersections points are defined, each with the ``X`` & ``Y`` properties enabled. 
    
    * Since each picture may experience 
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

