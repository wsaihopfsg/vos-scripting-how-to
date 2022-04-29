:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

VOS integration with ROS motion planning in a virtual UR5 cobot
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

1. VOS sends ``x``, ``y`` , ``rotation`` data to ROS vision node through TCP 
2. ROS vision node publishes the received data to a ROS topic
3. Object location shows in RViz as a marker  
4. Virtual robot performs path planning and executes "pick"
  

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Advanced/ROS>`__
-----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``VosRos.bin``                    |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/ROS/VosRos.bin?raw=true>`__                           |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``fake_ar_publisher.cpp``         |`The ROS node file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/ROS/fake_ar_publisher.cpp?raw=true>`__                |  
  |                                     |in C++, which performs image triggering and data reception from VOS. It publishes the received data to a ROS topic.                                    |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``workcellex22.launch``           |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/ROS/workcellex22.launch?raw=true>`__                     |  
  |                                     |is a launch file with IP address & port information to connect to the VOS TCP server.                                                                  |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``topright.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/ROS/topright.bmp?raw=true>`__                            |  
  |                                     |is an image with a rotated QR code on the top right-hand corner, which acts as the image captured by a software trigger.                               |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where ``topright.bmp`` has been saved                                                                                                                |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

.. note::
  The ROS code has been developed under ROS Melodic. Most of the code is identical to `ROS Industrial (Melodic) Training Exercises <https://industrial-training-master.readthedocs.io/en/melodic/>`__ until `Exercise 4.0 <https://industrial-training-master.readthedocs.io/en/melodic/_source/session4/Motion-Planning-CPP.html>`, except for the the 2 files included here. ``fake_ar_publisher.cpp`` should replace the file of the same name in the ``./src/fake_ar_publisher/`` folder, while ``workcellex22.launch`` should be copied to ``./src/myworkcell_support/launch`` folder.

Tools Explanation
-----------------
* Refer to :doc:`OCR of Asian Scripts & Colour Discrimination </soln/Menkyo/Menkyo>`

Connections
-----------
* Click on :hoverxreftooltip:`Setup Connections <intro/Basic/Hover/setupconntcp:Setup Connections>` |conn| |cir1|. We are using the ``VOS emulator`` as a ``TCP socket client``, with the socket server's ``Device IP 192.168.10.126`` at ``port 5025`` with the name ``TcpC126P5025``.  

.. image:: /intro/Advanced/MQTT/tcpclient.jpg

Code Walk-Through
-----------------

* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  
* All functions are the same as :doc:`OCR of Asian Scripts & Colour Discrimination </soln/Menkyo/Menkyo>`, except for 1 extra user-defined function ``write2Socket()``
  
User-Defined Function write2Socket()
####################################
* Choose the user-defined function ``write2Socket`` at the bottom left 
  
  .. image:: /intro/Advanced/MQTT/write2socket.jpg


* The code in the Script Function window generates a JSON-formatted file as below and sent to ``TcpC126P5025``. We will skip the code and show only the JSON string in pretty-formatting.

.. _JSONstr:

.. code-block:: 
  :linenos:

  {
      "LicenseNo": "012345678900",
      "LicColor": "Gold",
      "RegSerial": "01234",
      "Date": {
          "Birth": "18/3/1977",
          "Reg": "20/12/2010"
      },
      "VehCatEmpty": [ 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1 ]
  }

.. _hanako:

.. image:: /soln/Menkyo/components.jpg

* Line 2: The license number |cir4|
* Line 3: The license color |cir3|
* Line 4: The 5-digit issuing number at the end of |cir2|
* Line 6: The birth date converted from the Japanese era format at |cir1|
* Line 7: The registration date converted from the Japanese era format at |cir2|
* Line 9: The vehicle category qualifications, based on |cir5|

Post Image Process
#####################
* Choose the predefined function ``Post Image Process`` at the bottom left 

  .. image:: /soln/Menkyo/postimgproc.jpg

* In the Script Function window we see almost the same code as :ref:`here <menkyopost>`, except for the last line that invokes the user-defined Function ``write2Socket()`` above.

Node-Red Setup
--------------------
* We use Node-Red at the edge device to

  1. Perform the role of the socket server, and receive the JSON-formatted data sent from ``TcpC126P5025``
  2. Publish the received data to topic ``vos/menkyo`` of a configured MQTT broker

.. image:: /intro/Advanced/MQTT/flow1.jpg

* The properties for ``tcp in`` node are

.. image:: /intro/Advanced/MQTT/tcpinprop.jpg
  :width: 400px

* The properties for ``mqtt out`` node are

.. image:: /intro/Advanced/MQTT/mqttpubprop.jpg
  :width: 400px
  
IoT MQTT Panel Setup
--------------------
* We use an Android app called ``IoT MQTT Panel`` to subscribe to the ``vox/menkyo`` topic and display the relevant data on the screen. The numbering shown here has an one-to-one correspondence to :ref:`the sample Japanese Dirving License<hanako>` 

.. image:: /intro/Advanced/MQTT/iotMQTTpanel1.jpg

* The setup of the various panels are as shown below

+------------------------------------+-----------------------------------------+
||birthdate|                         ||licenseno|                              |
+------------------------------------+-----------------------------------------+
||issuedate|                         ||issue|                                  |
+------------------------------------+-----------------------------------------+
||licolor|                           |                                         |
+------------------------------------+-----------------------------------------+
||cat0|                              ||cat13|                                  |
+------------------------------------+-----------------------------------------+
|.. Note:: Only the first and last categories are shown for |cir5| for brevity |
+------------------------------------+-----------------------------------------+  

.. Note:: 
  Since data is sent as JSON format, the relevant data is extracted using `JSON Path <https://jsonpath.com/>`__. The correspondence of the :ref:`JSON formatted string <JSONstr>` with its JSON path is summarized here
  
  ============= ===================
  Line Number   JSON Path
  2             $.LicenseNo
  3             $.LicColor
  4             $.RegSerial
  6             $.Date.Birth
  7             $.Date.Reg
  9, element 0  $.VehCatEmpty[0]
  9, element 13 $.VehCatEmpty[13]           
  ============= =================== 

.. |licolor| image:: /intro/Advanced/MQTT/licolor.jpg
.. |licenseno| image:: /intro/Advanced/MQTT/licenseno.jpg
  :width: 300px
.. |birthdate| image:: /intro/Advanced/MQTT/birthdate.jpg
  :width: 300px
.. |issuedate| image:: /intro/Advanced/MQTT/issuedate.jpg
  :width: 300px
.. |issue| image:: /intro/Advanced/MQTT/issue.jpg  
  :width: 300px
.. |cat0| image:: /intro/Advanced/MQTT/cat0.jpg
  :width: 300px
.. |cat13| image:: /intro/Advanced/MQTT/cat13.jpg   
  :width: 300px

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. You will observe the phone's screen is updated with each ``Manual Trigger`` |manTrig|.

.. youtube:: qylTNJB3DmI

.. Tip::
  #MQTT #JSON #publish #subscribe #mobile #Android #IoT #IIOT #edge #device

