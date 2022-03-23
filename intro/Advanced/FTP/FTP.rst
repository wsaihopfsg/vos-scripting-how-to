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
  |1. ``FTP.bin``                       |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/FTP/OcrItalic.bin?raw=true>`__                        |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir1| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``50+5.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/FTP/50+5.bmp?raw=true>`__ Picture of a *50yen* and a     |
  |                                     |*5yen* coin in normal lighting.                                                                                                                        |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``vosftp.json``                   |`The Node Red Flow <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/FTP/vosftp.json?raw=true>`__                          |
  |                                     |                                                                                                                                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``backlite.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/FTP/backlite.bmp?raw=true>`__ Picture of a *50yen* and a |
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

* 1 preprocessor with only ``Threshold`` set to 38

.. image:: /intro/Advanced/FTP/preproc.jpg

* For the *5yen* coin on the left
  
  * 1 ``circle`` tool |circletool| to measure the outer circle's  diameter named ``CDiam``
  * 1 ``circle`` tool |circletool| to measure the inner circle's  diameter named ``CDiam1``
  * 1 ``Concentric Circles`` tool |concentrictool| to calculate the concentricity of the outer & inner circles named ``CC``

* For the *50yen* coin on the right
  
  * 1 ``circle`` tool |circletool| to measure the outer circle's  diameter named ``CDiam2``
  * 1 ``circle`` tool |circletool| to measure the inner circle's  diameter named ``CDiam3``
  * 1 ``Concentric Circles`` tool |concentrictool| to calculate the concentricity of the outer & inner circles named ``CC1``


  .. Tip::
    The dimensions of the `5yen <https://en.wikipedia.org/wiki/5_yen_coin>`__ and `50yen <https://en.wikipedia.org/wiki/50_yen_coin>`__ coin can be found on Wikipedia

Communication Setup
--------------------

* A summary of the communication setup is shown below
  
  .. image:: /intro/Advanced/FTP/comms1.jpg

TCP Server Setup
###################

* Click on :hoverxreftooltip:`Setup Connections <intro/Basic/Hover/setupconn:Setup Connections>` |conn| |cir1|, We are using the ``VOS emulator`` as a ``TCP socket server``, at ``port 5024`` with the name ``TcpP5024``.  

  .. image:: /intro/Advanced/FTP/tcpp5024.jpg

.. warning:: 
  Firewalls may block incoming connections to your socket server. 

Node-Red Flow
###################

* The Node-Red flow looks like this, with 2 branches

  * The FTP branch on top receives the post processed image with tools 
  * The TCP branch below receives the inspection results   

//todo image

.. note:: 
  We have used the following Node-Red Palettes
  
  * ``node-red-contrib-ftp-server``
  * ``node-red-node-base64``

* FTP Branch
  * The properties of the ``VosFtpIn`` node are as shown below, in which the FTP server is configured at port 7021. The username and password will be needed at VOS scripting.

  //todo image

  .. note:: 
    The image sent from VOS will appear as ``msg.payload`` in Node-Red

  * The properties & code for ``Mustache Template`` node is as shown here, where the html code displays the image with a certain width and height

  //todo image

  .. code-block::
    :linenos:
    

  * The properties & code for the ``UI Template`` node is as shown below

  //todo image

  .. code-block::
    :linenos:
    

* TCP branch

  * The properties for the ``VosTcpIn`` node is as shown, a TCP client configured to connect to ``192.168.10.143:5024`` as configured at `TCP Server Setup <#tcp-server-setup>`__ above.

  // todo image

  * The properties & code for the ``function`` node is shown here, which replaces all new line characters ``\n`` from VOS to HTML ``<br>``

  //todo image
    .. code-block::
      :linenos:
    
  * The properties & code for ``Mustache Template`` //todo change name node is as shown here, where the html code displays the image with a certain width and height

  //todo image

    .. code-block::
      :linenos:
    

  * The properties & code for the ``UI Template`` //todo change name node is as shown below

  //todo image

  .. code-block::
    :linenos:

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

* Line 1: Setting the ftp path with the username and password, IP address and port, and the image name to ``ftpath``
* Line 2: Writing the image file with tools
* Line 3: Image counter increament
* Lines 5-7: Branch when inspection result is ``pass``  


.. note::
  Other FTP related functions are ``WriteImageFile`` & ``WriteHistoryImage``

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 
* Clicking on ``Manual Trigger`` |manTrig| repeatedly we will see files created 
  
  * As many .jpg files as ``Manual Trigger`` |manTrig| clicks    
  * A .csv file with 5 entries

.. code-block::
  :linenos:
  
  "Frame Number","TimeStamp","Result","OsheaR","OCR",

  1, 17:58:04, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC
  2, 17:58:04, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC
  3, 17:58:05, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC
  4, 17:58:05, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC
  5, 17:58:06, Pass, italicfontOCR fictionaltORC, italicfontOC fictionaltORC


* We can observe that
   
  * ``OsheaR`` is able to recognize the alphabets with 100% accuracy, 
  * ``OCR`` has difficult to decode the last R of *italic font OCR*. Tweaking the ``Required score`` of ``OCR`` manually does not seem to help as summarize in the following table.
    
    * 85: italicfontOC
    * 50: italicfontOCI
    * 40: italicfontOCIc
    * 10: c italicfontOC     

+-------------------------------------------------+-------------------------------------------------+
||1|                                              ||2|                                              |
|                                                 |                                                 |
|``Required score`` = 85                          |``Required score`` = 50                          |
+-------------------------------------------------+-------------------------------------------------+
||3|                                              ||4|                                              |
|                                                 |                                                 |
|``Required score`` = 40                          |``Required score`` = 10                          |
+-------------------------------------------------+-------------------------------------------------+

.. Note::
  * In this case where |charsamesize| is unchecked in the ``font editor`` |fonteditor|,
    
    * Spaces may become hard to detect
    * Other taught-in chracters may have a higher score than the correct character, like in this example *i* seems fit into the downward stroke of the *R*.
      

.. Tip::
  #OCR #preprocessor #shear #italic #template #AI #grayscale #intensity

.. |1| image:: /intro/Basic/OcrItalic/85.jpg
  :width: 400px

.. |2| image:: /intro/Basic/OcrItalic/50.jpg
  :width: 400px

.. |3| image:: /intro/Basic/OcrItalic/40_.jpg
  :width: 400px

.. |4| image:: /intro/Basic/OcrItalic/10.jpg
  :width: 400px

.. |charsamesize| image:: /intro/Basic/OcrItalic/charsamesize.jpg

.. |teachsizes| replace:: teach-in the other font size

