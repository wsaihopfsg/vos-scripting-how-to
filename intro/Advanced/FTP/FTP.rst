:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Viewing of Inspection Images and Results on Web Browser 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of the ``Threshold`` preprocessor on an image taken in back-lighting
2. Use of the  ``Circle`` tool |circletool| to obtain the outer and inner diameters of a *50 yen* & *5 yen* coin
3. Use of the ``Concentric Circles`` tool |concentrictool| to calculate the concentricity of the outer & inner circles of the coins
4. Logging of images and the associated tools to a configured ftp server by ``WriteImageTools``
5. Sending of the inspection results to a TCP client

.. table::
  :class: tight-table 

  +---------------------+----------------------------------+-----------------------------------------------------------------------------+
  |**Function**         |**Parameters**                    |**Explanation**                                                              |
  +---------------------+----------------------------------+-----------------------------------------------------------------------------+
  |``WriteImageTools``  |``fileName``, ``camID``           |Write the current image with tools from the camera specified by ``camID`` to |
  |                     |                                  |the ``fileName`` specified. Only to be used in ``Post image process``.       |
  +---------------------+----------------------------------+-----------------------------------------------------------------------------+
  |``WriteImageFile``   |``fileName``, ``camID``           |Write the current image from the camera specified by ``camID`` to            |
  |                     |                                  |the ``fileName`` specified. Only to be used in ``Post image process``.       |
  +---------------------+----------------------------------+-----------------------------------------------------------------------------+
  |``WriteHistoryImage``|``fileName``, ``camID``,          |Write 1 image with tools from the Histroy Log of ``camID`` specified by      |
  |                     |``numImagesBack``                 |``numImagesBack`` to the ``fileName`` specified. ``numImagesBack=0`` is one  |
  |                     |                                  |image prior to the current image.                                            |
  +---------------------+----------------------------------+-----------------------------------------------------------------------------+

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Advanced/FTP>`__
-----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``ftp07.bin``                     |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/FTP/ftp07.bin?raw=true>`__                            |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir1| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``flows.json``                    |`The Node Red Flow <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/FTP/flows.json?raw=true>`__                           |
  |                                     |                                                                                                                                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``50+5.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/FTP/50+5.bmp?raw=true>`__ Picture of a *50yen* and a     |
  |                                     |*5yen* coin in normal lighting.                                                                                                                        |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``backlite.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/FTP/backlite.bmp?raw=true>`__ Picture of a *50yen* and a |
  |                                     |*5yen* coin in back-lighting.                                                                                                                          |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where ``the images`` have been saved                                                                                                                 |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

 

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``backlite.bmp`` is loaded. 

.. image:: /intro/Advanced/FTP/tools.png
..  :width: 400px

* A preprocessor with only ``Threshold`` set to 38

.. image:: /intro/Advanced/FTP/preproc.jpg

* For the *5yen* coin on the left
  
  * A ``circle`` tool |circletool| to measure the outer circle's  diameter named ``CDiam``
  * A ``circle`` tool |circletool| to measure the inner circle's  diameter named ``CDiam1``
  * A ``Concentric Circles`` tool |concentrictool| to calculate the concentricity of the outer & inner circles named ``CC``

* For the *50yen* coin on the right
  
  * A ``circle`` tool |circletool| to measure the outer circle's  diameter named ``CDiam2``
  * A ``circle`` tool |circletool| to measure the inner circle's  diameter named ``CDiam3``
  * A ``Concentric Circles`` tool |concentrictool| to calculate the concentricity of the outer & inner circles named ``CC1``


  .. Tip::
    The dimensions of the `5yen <https://en.wikipedia.org/wiki/5_yen_coin>`__ and `50yen <https://en.wikipedia.org/wiki/50_yen_coin>`__ coin can be found on Wikipedia

Communication Setup
--------------------

* A summary of the communication setup is shown below
  
  .. image:: /intro/Advanced/FTP/comms1.jpg

.. warning:: 
  The IP addresses have to be changed according to your network setup

TCP Server Setup
###################

* Click on :hoverxreftooltip:`Setup Connections <intro/Basic/Hover/setupconn:Setup Connections>` |conn| |cir1|, We are using the ``VOS emulator`` as a ``TCP socket server``, at ``port 5024`` with the name ``TcpP5024``.  

  .. image:: /intro/Advanced/FTP/tcpp5024.jpg

.. warning:: 
  Firewalls / anti-virus may block incoming connections to your socket server. 

Node-Red Flow
###################

* On any web browser within the same intranet, navigate to the IP where Node-Red is running. In this example it is ``http://192.168.10.126:1880``.
* The Node-Red flow looks like this, with 2 branches

  * The FTP branch on top receives the post processed image with tools 
  * The TCP branch below receives the inspection results   

.. image:: /intro/Advanced/FTP/flow.jpg

.. note:: 
  We have used the following Node-Red Palettes
  
  * ``node-red-contrib-ftp-server``
  * ``node-red-node-base64``

.. _ftpbranch:

* FTP Branch
  
  * The properties of the ``Vos Ftp In`` node are as shown below, in which the FTP server is configured at port 7021. The ``username`` and ``password`` will be needed at VOS' `Post Image Process <#post-image-process>`__ script.

  .. image:: /intro/Advanced/FTP/ftpinpro.jpg
    :width: 500px

  .. note:: 
    The image sent from VOS will be passed as ``msg.payload`` in Node-Red

  * The properties & code for ``ftp mustache template`` node is as shown here, where the html code displays the image with a certain width and height

  .. image:: /intro/Advanced/FTP/ftpmuspro.jpg
    :width: 500px

  |
  
  .. code-block::
    :linenos:

    <img width="320px" height="240px" src="data:image/jpg;base64,{{{payload}}}">  

  * The properties & code for the ``ftp ui template`` node is as shown below

  .. image:: /intro/Advanced/FTP/ftpuipro.jpg
    :width: 500px

  |
  
  .. code-block::
    :linenos:
    
    <div ng-bind-html="msg.payload",div style="text-align: center;"></div>

* TCP branch

  * The properties for the ``Vos Tcp In`` node is as shown, a TCP client configured to connect to ``192.168.10.143:5024`` as configured at `TCP Server Setup <#tcp-server-setup>`__ above.

  .. image:: /intro/Advanced/FTP/tcpinproc.jpg
    :width: 500px

.. _newlinereplace:

  * The properties & code for the ``Replace new line with <br>`` function node is shown here, which replaces all new line character ``\n`` from VOS to HTML ``<br>``

    .. image:: /intro/Advanced/FTP/tcpreplacepro.jpg
      :width: 500px

    |
  
    .. code-block::
      :linenos:
    
      msg.payload = msg.payload.replace(/\n/g,"<br/>");
      return msg;

  * The properties & code for ``tcp mustache template`` node is as shown here, where the html code displays the image with a certain width and height

    .. image:: /intro/Advanced/FTP/tcpmuspro.jpg
      :width: 500px

    |
  
    .. code-block::
      :linenos:
    
      {{{payload}}} 

  * The properties & code for the ``tcp ui template`` node is as shown below

    .. image:: /intro/Advanced/FTP/tcpuipro.jpg
      :width: 500px

    |
  
    .. code-block::
      :linenos:

      <div ng-bind-html="msg.payload",div style="text-align: center;"></div>

.. note:: 
  To keep this tutorial simple, we have not shown how to save the transmitted image locally. 

Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  

Solution Initialize
###################
* Choose the predefined function ``Solution Initialize`` at the bottom left 
  |fn_init|

* In the Script Function window we see the following lines of code

.. code-block::
  :linenos:
    
    myPass = 1
    myRecycle = 2
    myFail = 3
    ctr=0

* Lines 1-3: Return values for ``pass``, ``fail`` & ``recycle`` values in VOS' ``Result.0``
* Line 4: Reset image counter

Pre Image Process
##################

* Choose the predefined function ``Pre Image Process`` at the bottom left 
  |fn_pre|

* In the Script Function window we see a line of code which resets the variable ``socketStr``

.. code-block::
  :linenos:

    socketStr = ""

Post Image Process
##################

* Choose the predefined function ``Post Image Process`` at the bottom left 
  |fn_post|

* In the Script Function window we see 

.. code-block::
  :linenos:

    ftpath = "ftp://vos:rox@192.168.10.126:7021/img" + ctr + ".jpg"
    WriteImageTools( ftpath,0 )
    ctr = ctr+1
    if(Result.0=myPass  ) 
        socketStr = "Pass"+"\n"+"OuterL=" + FormatString("[CDiam%3.1f]") + ", InnerL=" + FormatString("[CDiam1%3.1f]") + ", ConcentricityL=" + FormatString("[CC%.2f]") + "\n"
        socketStr = socketStr    +"OuterR=" + FormatString("[CDiam2%3.1f]") + ", InnerR=" + FormatString("[CDiam3%3.1f]") + ", ConcentricityR=" + FormatString("[CC1%.2f]")
        iColor = "darkgreen"
    else
        if(Result.0=myRecycle) 
            socketStr = "Recycle"
            iColor = "magenta"
        else
            socketStr = "Fail"
            iColor = "red"
        endif
    endif
    WriteString(TcpP5024,socketStr)
    SetDisplayStatus(socketStr , iColor)

* Line 1: Setting the ftp path with the :ref:`username & password<ftpbranch>`, IP address and port, and the image name to ``ftpath``
* Line 2: Writing the image file with tools
* Line 3: Image counter increament
* Lines 5-7: Branch when inspection result is ``pass``. Note the new line character ``\n`` :ref:`will be replaced by its html equivalent<newlinereplace>` by the Node-Red function node ``Replace new line with <br>``. Please refer to :doc:`here for string formatting tutorial </intro/Basic/StrFunc/StrFunc>`.
* Lines 10-11: Branch when inspection result is ``recycle``  
* Lines 13-14: Branch when inspection result is ``fail``
* Line 17: Sending of ``socketStr`` to the configured TCP client
* Line 18: Display ``socketStr`` in the ``Inspection Status`` window

.. note::
  Other FTP related functions are ``WriteImageFile`` & ``WriteHistoryImage``

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 
* On any web browser within the same intranet, navigate to the IP where Node-Red dashboard is running. In this example it is ``http://192.168.10.126:1880/ui``.
* When ``backlite.bmp`` is being inspected, we see that the output at ``Vision Configuration Tool`` and web browser below. 

+-------------------------------------------------+-------------------------------------------------+
||1|                                              ||2|                                              |
+-------------------------------------------------+-------------------------------------------------+
|In ``Vision Configuration Tool``                 |On web browser of a mobile phone                 |
+-------------------------------------------------+-------------------------------------------------+

* If we compare the diameter results against Wikipedia's record, we can see that the measurement from VOS is quite accurate indeed.
   
.. table::

  +-------------------------------+-----------------------------+----------------------------+------------------------------+-----------------------------+
  |                               |.. centered:: *5yen*                                      |.. centered:: *50yen*                                       |
  +-------------------------------+-----------------------------+----------------------------+------------------------------+-----------------------------+
  |                               | .. centered:: Inner Diameter|.. centered:: Outer Diameter|.. centered:: Inner Diameter  |.. centered:: Outer Diameter |  
  +-------------------------------+-----------------------------+----------------------------+------------------------------+-----------------------------+
  | .. centered:: Wikipedia       | .. centered:: 22mm          | .. centered:: 5mm          |.. centered:: 21mm            |.. centered:: 4mm            |
  +-------------------------------+-----------------------------+----------------------------+------------------------------+-----------------------------+
  | .. centered:: Ratio In/Out    | .. centered:: 4.4                                        | .. centered:: 5.25                                         |         
  +-------------------------------+-----------------------------+----------------------------+------------------------------+-----------------------------+
  | .. centered:: VOS (back-light)| .. centered:: 232.9 units   | .. centered:: 56.8 units   |.. centered:: 219.4 units     | .. centered:: 41.4 units    |
  +-------------------------------+-----------------------------+----------------------------+------------------------------+-----------------------------+
  |.. centered:: Ratio In/Out     | .. centered:: 4.1                                        | .. centered:: 5.3                                          |        
  +-------------------------------+-----------------------------+----------------------------+------------------------------+-----------------------------+


* When ``50+5.bmp`` is being inspected, the results is ``Fail``. We note that in normal lighting, it may be challenging for the ``circle`` tool |circletool| to detect the actual edges due to the embossed designs on the coins. Therefore back-lighting is preferred this example.

.. Tip::
  #circle #concentric #concentricity #remote #image #backlight #insepction 

.. |1| image:: /intro/Advanced/FTP/vctpass1.jpg 
  :width: 400px

.. |2| image:: /intro/Advanced/FTP/phonepass1.jpg
  :width: 400px

