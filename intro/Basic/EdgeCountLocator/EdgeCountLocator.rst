:orphan:

.. _gpio:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Using Edge Count Tool as Locator  
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of ``Edge Count`` tools |edgecounttool| to deal with small x-translations of the object-of-interest.
2. Use of the ``Caliper`` tool |calipertool| to measure an irregular shape.

.. note:: 
  The main advanatge of using ``Edge Count`` tool as locator is speed. However 
  
  * It is only applicable to small translations in either x or y direction
  * It is usually used for objects that are bigger than the current field-of-view.

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/EdgeCountLocator>`__
-------------------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``solution12.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/EdgeCountLocator/solution12.bin?raw=true>`__          |
  |                                     |                                                                                                                                                    |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |solnsetup| |cir1|, import |import| |cir2| solution   |  
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``1.bmp``                         |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/EdgeCountLocator/1.bmp?raw=true>`__ is the same          |
  |                                     |example image provided by the VOS ``Vision Configuration Tool`` software                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``2.bmp``                         |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/EdgeCountLocator/2.bmp?raw=true>`__ is the same          |
  |                                     |image as  ``demo1280_01.bmp`` with a slight x-translation                                                                                           |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``3.bmp``                         |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/EdgeCountLocator/3.bmp?raw=true>`__ is the same          |
  |                                     |image as  ``demo1280_01.bmp`` with a slight x-translation                                                                                           |
  |                                     |                                                                                                                                                    |
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                   |
  |                                     |                                                                                                                                                    |
  |                                     |  set |demoimg| |cir2|                                                                                                                              |
  |                                     |                                                                                                                                                    |  
  |                                     |  to the folder where these images have been saved                                                                                                  |
  |                                     |                                                                                                                                                    |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``1.bmp`` is loaded. 

.. image:: /intro/Basic/EdgeCountLocator/edgecountlocatortooloverview.jpg

* An ``Edge Count`` tool |edgecounttool| named ``E`` has been used, with a search line that covers the expected movement of the image in the x-direction. 

  .. image:: /intro/Basic/EdgeCountLocator/edgecountlocatorprop1.jpg
  
  * At the intersection of the edge with the search line of ``E``, a point called ``PP`` is set to be the position anchor for ``Locator 1``.
  
    .. image:: /intro/Basic/EdgeCountLocator/edgecountloc.jpg
  
* A ``Caliper`` tool |calipertool| has been defined to measure the irregular shape at the bottom of the figure. It is anchored to ``Locator 1`` with these properties
    
    .. image:: /intro/Basic/EdgeCountLocator/edgecountcaliper.jpg

.. note:: 
  Please refer to the VOS manual for details on how to use the ``Caliper`` tool |calipertool|.  

Code Walk-Through
-----------------
* There is no script used in this solution.


Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2| 

+-------------------------------------------------+
||1|                                              |
|                                                 |
|``1.bmp``                                        |
+-------------------------------------------------+
||2|                                              |
|                                                 |
|``2.bmp``                                        |
+-------------------------------------------------+
||3|                                              |
|                                                 |
|``3.bmp``                                        |
+-------------------------------------------------+

.. Tip::
  #caliper #edge #count #locator #point

.. |1| image:: /intro/Basic/EdgeCountLocator/edgecountlocator1.jpg
  

.. |2| image:: /intro/Basic/EdgeCountLocator/edgecountlocator2.jpg
  

.. |3| image:: /intro/Basic/EdgeCountLocator/edgecountlocator3.jpg
  

