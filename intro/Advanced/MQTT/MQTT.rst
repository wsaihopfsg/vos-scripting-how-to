:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Publishing VOS Data to MQTT & Displaying On Mobile
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

1. Reusing the tools and functions from :doc:`OCR of Asian Scripts & Colour Discrimination </soln/Menkyo/Menkyo>` tutorial.
2. Sending serialized JSON data to a socket server
3. Socket server publishes the data to a topic on a public MQTT broker 
4. Mobile phone subcribes to the same topic and displays the data
  

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Advanced/MQTT>`__
-----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``mqtt.bin``                      |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/MQTT/mqtt.bin?raw=true>`__                            |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``green2.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/MQTT/green2.bmp?raw=true>`__                             |  
  |                                     |is the same image as :ref:`here<menkyobmp>` for a rotated green color-coded driving license under green lighting.                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``blue2.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/MQTT/blue2.bmp?raw=true>`__                              |  
  |                                     |is the same image as :ref:`here<menkyobmp>` for a rotated blue color-coded driving license under green lighting.                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``gold2.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/MQTT/gold2.bmp?raw=true>`__                              |  
  |                                     |is the same image as :ref:`here<menkyobmp>` for a rotated gold color-coded driving license under green lighting.                                       |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where the images have been saved                                                                                                                     |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* Refer to :doc:`OCR of Asian Scripts & Colour Discrimination </soln/Menkyo/Menkyo>`

Connections
-----------
* Click on :hoverxreftooltip:`Setup Connections <soln/Hover/setupconntcp:Setup Connections>` |conn| |cir1|. We are using the ``VOS emulator`` as a ``TCP socket client``, with the socket server's ``Device IP 192.168.10.126`` at ``port 5025`` with the name ``TcpC126P5025``.  

.. image:: /intro/Advanced/MQTT/tcpclient.jpg

Code Walk-Through
-----------------

* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  
* All functions are the same as :doc:`OCR of Asian Scripts & Colour Discrimination </soln/Menkyo/Menkyo>`, except for 1 extra user-defined function
  
User-Defined Function write2Socket()
####################################
* Choose the user-defined function ``write2Socket`` at the bottom left 
  
  .. image:: /intro/Advanced/MQTT/write2socket.jpg


* The code in the Script Function window generates a JSON-formatted file as below and sent to ``TcpC126P5025``.

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
* We use Node-Red to

  1. Perform the role of the socket server, and receive the JSON-formatted data sent from ``TcpC126P5025``
  2. Publish the received data to topic ``vos/menkyo`` of a configured MQTT broker

.. image:: /intro/Advanced/MQTT/flow.jpg

* The properties for ``tcp in`` node are

.. image:: /intro/Advanced/MQTT/tcpinprop.jpg

* The properties for ``mqtt out`` node are

.. image:: /intro/Advanced/MQTT/mqttpubprop.jpg

IoT MQTT Panel Setup
--------------------
* We use an Android app called ``IoT MQTT Panel`` to subscribe to the ``vox/menkyo`` topic and display the relevant data on the screen

.. image:: /intro/Advanced/MQTT/iotMQTTpanel.jpg

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 

#multiple #preprocessor #scratch #detection #remove #blob #erode #dilate #stacking #stack

