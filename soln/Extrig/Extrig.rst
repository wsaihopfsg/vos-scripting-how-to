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

* Please refer to the datasheets & manual for the pinout of your VOS model. In this tutorial we have used the pinout of VOS2000 as an example

.. image:: /soln/Extrig/VOS2000pintout.jpg

Setting up of GPIOs
---------------------

* At the :hoverxreftooltip:`Sensor Setup page <soln/Hover/inspectiontrig:Inspection Trigger Setup>` |sensorsetup| |cir1|, set ``Trigger Source`` to ``Inspection Trigger`` |cir2|.

* At the :hoverxreftooltip:`Setup Connections <soln/Hover/setupio:Setup IO>` |conn| |cir1|, ``Setup I/O`` |cir2| is used for interface configuration.

GPI Configuration
###################

* Click on ``Inputs`` |gpi|, and the ``Input Configuration`` will be shown

.. image:: /soln/Extrig/inputconfig.png

.. table::
  :class: tight-table 

  +---------------+---------------------------------------------------------------------------------------------+
  | **Input**     | **Explanation**                                                                             |
  +---------------+---------------------------------------------------------------------------------------------+
  |Trigger (GPI0) | * Set the polarity (Active High or Active Low) in the ``Control`` column                    |
  |               | * Enter a debounce period                                                                   |
  |               | * Set a trigger divider ``Triggers per Image`` for the sensor trigger input                 |
  +---------------+---------------------------------------------------------------------------------------------+
  |IN1/GPI1       | * Use the drop-down list to select the function                                             |
  +---------------+ * ``Job Change`` and ``Job Select`` has been set for input 1 & 2 respectively               |
  |IN2/GPI2       | * The ``Value`` column shows the current status of all inputs                               |
  |               |                                                                                             |  
  |               |   * 1 for high, 0 for low                                                                   |
  +---------------+---------------------------------------------------------------------------------------------+

 
GPI Wiring
#####################

======================= ======================= =======================
**Sensor (PNP)**        **VOS Camera**          **Power** 
Pin 1 - BN                                      +UB
Pin 3 - BU              Pin 7 - BK              -UB
Pin 4 - BK              Pin 5 - PK
----------------------- ----------------------- -----------------------
|pnpgpi|
-----------------------------------------------------------------------
======================= ======================= =======================

.. |pnpgpi| image:: /soln/Extrig/gpipnp1.jpg

======================= ======================= =======================
**Sensor (NPN)**        **VOS Camera**          **Power** 
Pin 1 - BN              Pin 7 - BK              +UB
Pin 3 - BU                                      -UB
Pin 4 - BK              Pin 5 - PK
----------------------- ----------------------- -----------------------
|npngpi|
-----------------------------------------------------------------------
======================= ======================= =======================

.. |npngpi| image:: /soln/Extrig/gpinpn1.jpg

.. note:: 
  Make sure that Pin 7 ``IN CMN`` is connected!

GPO Configuration
###################

* Click on ``Outputs`` |gpo|, and the ``Output Configuration`` will be shown

.. image:: /soln/Extrig/outputconfig.png

.. note:: 
  Change the output based on your application, please make sure ``Pulse Duration`` is according to your design needs

.. note:: 
  For details of the outputs, please refer to Section 7.4.2 of the VOS manual 

GPO Wiring
#####################

* VOS2000 has 3 outputs (OUT0, OUT1 & OUT2), these output can be configured via NEXUS software. 
* In this example, we use OUT1 and OUT2 where Pin 3 represent “Pass” and Pin 10 represent “Fail” respectively. 

======================== =
**PNP Wiring**
------------------------ -
|pnpgpo|
======================== =

======================== =
**NPP Wiring**
------------------------ -
|npngpo|
======================== =

.. |pnpgpo| image:: /soln/Extrig/gpopnp.jpg
.. |npngpo| image:: /soln/Extrig/gponpn.jpg

.. tip::
  #GPI #GPO #wiring #GPIO #PNP #NPN

