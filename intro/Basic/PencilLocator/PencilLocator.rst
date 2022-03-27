:orphan:

.. _gpio:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Using Count Tool as Locator  
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of two  ``Pencil`` tools |penciltool| to deal with small translations of the object-of-interest.
2. Use of the ``Arc`` tool |arctool| to check an arc of the object-of-interest. 

.. note:: 
  The main advanatge of using ``Pencil`` tool as locator is speed. However 
  
  * It is only applicable to small translations
  * To track rotation also, another feature is needed

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/PencilLocator>`__
--------------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``solution10.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/PencilLocator/solution10.bin?raw=true>`__             |
  |                                     |                                                                                                                                                    |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |solnsetup| |cir1|, import |import| |cir2| solution   |  
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``demo1280_01.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/PencilLocator/demo1280_01.bmp?raw=true>`__ is the same   |
  |                                     |example image provided by the VOS ``Vision Configuration Tool`` software                                                                            |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``demo1280_02.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/PencilLocator/demo1280_02.bmp?raw=true>`__ is the same   |
  |                                     |image as  ``demo1280_01.bmp`` with a slight translation                                                                                             |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``demo1208_04.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/PencilLocator/demo1280_03.bmp?raw=true>`__ is the same   |
  |                                     |image as  ``demo1280_01.bmp`` with a slight translation and an defect at the arc to be inspected                                                    |
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
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``demo1280_01.bmp`` is loaded. 

.. image:: /intro/Basic/PencilLocator/penciltoolsetup.jpg

* 2 ``Pencil`` tools |penciltool| have been used

  * One named ``P`` along the horizontal edge
    
    * First point called ``PP``
    * Second point called ``PP1``
  
  * Another named ``P1`` along the vertical edge
  
    * First point called ``PP2``
    * Second point called ``PP3``
    * Notice that their ROI has been enlarged to cater for the movement of the incoming images
    
    .. image:: /intro/Basic/PencilLocator/pp2roi.jpg
  
  * Both ``P`` & ``P1`` are extended to meet at point ``PP4``, which is set as locator's 1 position anchor

    .. image:: /intro/Basic/PencilLocator/PP4prop.jpg

* An ``Arc`` tool |arctool| has been used along one edge of the pill shape. 
    
      .. image:: /intro/Basic/PencilLocator/arcprop.jpg

      * A ``threshold`` tool with threshold set at 128, converting the input image to binary
      * A ``Remove Blobs`` tool with its properties set so that all other white blobs are removed except for the circle. This ensures that the ``Count`` |counttool| tool detects only the circle and not multiple shapes
    
.. note:: 
  Please refer to the VOS manual for details on how to use the pencil tool.  

Code Walk-Through
-----------------
* There is no script used in this solution.


Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2| 

+-------------------------------------------------+
||1|                                              |
|                                                 |
|``demo1280_01.bmp``                              |
+-------------------------------------------------+
||2|                                              |
|                                                 |
|``demo1280_02.bmp``                              |
+-------------------------------------------------+
||3|                                              |
|                                                 |
|``demo1280_03.bmp``                              |
+-------------------------------------------------+

.. Tip::
  #arc #pencil #locator #point

.. |1| image:: /intro/Basic/PencilLocator/pencil1.jpg
  

.. |2| image:: /intro/Basic/PencilLocator/pencil2.jpg
  

.. |3| image:: /intro/Basic/PencilLocator/pencil3.jpg
  

