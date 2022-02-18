:orphan:

.. _csharp:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Integrating VOS Solutions with C#
+++++++++++++++++++++++++++++++++

This sample demonstrates

#. How to run a VOS server at the background
#. How to integrate VOS solution in C# 

   * Specifically, :ref:`this solution <refcir>` using reference shape to compute rectangular dimensions.

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Advanced/csharp>`__
---------------------------------------------------------------------------------------------------------

* ``CsClient.csproj``: The `c# project file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/CsClient.csproj?raw=true>`__
* ``Form1.cs``: Main Form `source code <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/Form1.cs?raw=true>`__
* ``iClientApi.cs``: VOS `wrapper for c# <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/iClientApi.cs?raw=true>`__
* ``App.config``: The `configuration file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/App.config?raw=true>`__
* Explanations of other files are left out for brevity
  
Running iServer.exe
===================

* Open ``%ProgramFiles(x86)%/Pepperl+Fuchs/VisionConfigurationTool`` folder
* Look for ``iServer.exe`` |iserverico|, and run it.

  .. image:: /intro/Advanced/csharp/iserver.jpg

* Copy ``*.dll`` from the ``%ProgramFiles(x86)%/Pepperl+Fuchs/VisionConfigurationTool`` folder to the folder where your c# program will be compiled

  * Note that the version for ``*.dll``  and ``iServer.exe`` has to be the same.


Code Walk-Through
-----------------

* ``API Help`` 

  * The ``iClient API for VOS`` help |APIhelp| is installed together with the ``VOS emulator`` and other VOS programs.
  * It is an important reference for c# programming.
  
* ``App.config``
  
  * Line 4: The configured server port. In our case it is |5025|_. //todo fix hyperlink
  * Line 5: The server address. Since ``iServer.exe`` is running on the same machine as the c# client app, the local loopback address is configured.
  * Line 6: The default solution to load when the custom c# client app runs.
  * Line 7: The unit used for the custom c# client app

.. code-block::
    :linenos:

    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <appSettings>
        <add key="ServerPort" value="5025"/>
        <add key="ServerAddr" value="127.0.0.1"/>
        <add key="DefaultSoln" value="12"/>
        <add key="DefaultUnit" value="cm"/>
      </appSettings>
    </configuration>

* ``Form1.cs: Form1_Load``

  * Line 3: Create a pointer to the Client engine object based on the configured IP Address.
  * Line 4: :ref:`GetCurrentState() <currentState>`
  * Line 10: Get the Run Mode of ``iServer.exe`` application, returns an ``int`` as ``EngMode``
   
    ``0.`` Live image

    ``1.`` Process solution
    
    ``2.`` Stopped
    
  * Line 11: Based on ``EngMode``, display the Run Mode as text to label ``Mode``.
  * Lines 13-14: Set to the configure solution.
  * Lines 18-20: For picture display at ``pictureBox1``
  * Line 21: Populate the up-down box ``updUnit`` for reference circle diameter selection
  * Line 22: Socket connection to the configured IP & port

.. code-block::
    :linenos:
    :emphasize-lines: 9

    private void Form1_Load(object sender, System.EventArgs e)
    {
        pIClient = iClientLib.iClientCreate(IPAddress);

        if (pIClient != (IntPtr)0 ) 
        {
            int EngMode;

            GetCurrentState();
            EngMode = iClientLib.iClientGetMode(pIClient);
            Mode.Text= iClientLib.iClientGetModeString(EngMode);
				
            UpdateSolutionIDCombo(nLastSolutionID);
            SetSolutionIDComboIndex(Int32.Parse(ConfigurationManager.AppSettings["DefaultSoln"]));

            Text = "VOS Object Measurement Demo" + " (Version: " + iClientLib.iClientGetVersion(pIClient) +")";

            iClientLib.iClientSetWindow( pIClient, pictureBox1.Handle );
            iClientLib.iClientSetCamZoom(pIClient, 1, iClientLib.IFW_STRETCH_TO_FIT, iClientLib.IFW_STRETCH_TO_FIT);
            iClientLib.iClientSetResultsCallback(pIClient, resultsCB, pIClient);

            updUnitAddItems();
            connectSocket(IPAddress,IPort);
            btnTrigger.Text = btnTrigger.Text.Replace("Units", DefaultUnit);
        }
    }

.. _currentState:

* ``GetCurrentState()``

  * Line 3: Get the current status of the application software, returns an ``short`` as ``nLastState``
  * Line 4: Based on ``nLastState``, display the Run Mode as text to label ``State``.
   
    ``0.`` Not configured
    
    ``1.`` Ready to run
    
    ``2.`` Running
    
    ``3.`` Alarm
    
    ``4.`` Stopped
    
    ``5.`` Live image

.. code-block::
    :linenos:

    private void GetCurrentState()
    {
        nLastState = iClientLib.iClientGetState(pIClient);
        State.Text = iClientLib.iClientGetStateString(nLastState);
    
        if (nLastState == (int)iClientLib.IFRAMEWORK_STATE.IFW_STATE_RUNNING ) 
        {
            StartStop.Text = "Stop Inspection";
        }
        else if (nLastState == (int)iClientLib.IFRAMEWORK_STATE.IFW_STATE_READY_TO_RUN) 
        {
            StartStop.Text = "Start Inspection";
        }
        else 
        {
            StartStop.Enabled = false;
            StartStop.Text = "Start Inspection";
        }
    }

* ``Form1.cs: btnTrigger_Click(object sender, EventArgs e)``

  * Line 5: Prepare the bytes for software triggering and user-defined reference diameter
  
.. code-block::
    :linenos:

    private void btnTrigger_Click(object sender, EventArgs e)
    {
        byte[] inStream = new byte[(int)clientSocket.ReceiveBufferSize];
        NetworkStream serverStream = clientSocket.GetStream();
        byte[] outStream = { 0x54, (byte)(Byte.Parse(updUnit.Text) + 0x30), 13 };
        serverStream.Write(outStream, 0, outStream.Length);
        serverStream.Flush();

        serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
        string serverText = System.Text.Encoding.ASCII.GetString(inStream);
    
        txtOp.Text = parseVosOpString(serverText);//serverText
    }

Running the c# client 
---------------------

* Make sure ``iServer.exe`` is already running
* Make sure all .dll files has been copied to the same folder as the compiled c# executable 
* Change the working folder to where the 4 images for :ref:`Using a Reference Circle to Compute Size of Rectangles <refcir>` solution using ``VOS emulator`` if needed
  
  * You may exit the emulator after changing the folder
  
* Run the c# client. The ``iServer.exe`` updates with ``Client connected``
  
  .. image:: /intro/Advanced/csharp/iserverConnected.jpg

* Use the up-down box to select the reference diameter
* Press ``Trigger``
* Output for ``test0.bmp``, triggered with 1cm reference diameter
  
  .. image:: /intro/Advanced/csharp/test0.jpg

* Output for ``test1.bmp``. Notice that ``Failed`` has been high-lighted in red.
  
  .. image:: /intro/Advanced/csharp/test1.jpg

* Output for ``test2.bmp``, triggered with 3cm reference diameter
  
  .. image:: /intro/Advanced/csharp/test2.jpg

* Output for ``test3.bmp``, triggered with 3cm reference diameter

  .. image:: /intro/Advanced/csharp/test3.jpg

.. |iserverico| image:: /intro/Advanced/csharp/iserver_ico.jpg

.. |APIhelp| image:: /intro/Advanced/csharp/vbhelp.jpg

.. |5025| replace:: ``5025``

.. _5025: `refcir`