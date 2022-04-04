:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

External Trigger Setup and Connection
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

1. Setting up of GPIOs 
2. Wiring of GPIs & configuration in VOS
3. Wiring of GPOs & configuration in VOS

VOS 2000 Pinout
#####################

* Please refer to the datasheets & manual for the pinout for your VOS model. For this tutorial we have used the pinout for VOS2000 as an example

.. image:: /soln/Extrig/VOS2000pintout.jpg

Setting up of GPIOs
---------------------

* At the :hoverxreftooltip:`Sensor Setup page <soln/Hover/inspectiontrig:Inspection Trigger Setup>` |sensorsetup| |cir1|, set ``Trigger Source`` to ``Inspection Trigger`` |cir2|.

* At the :hoverxreftooltip:`Setup Connections <soln/Hover/setupio:Setup IO>` |conn| |cir1|, ``Setup I/O`` |cir2| is used for interface configuration.

GPI Configuration
###################

* Click on ``Inputs`` |gpi|, and the ``Input COnfiguration`` will be shown

.. image:: /soln/Extrig/inputconfig.png
  
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

