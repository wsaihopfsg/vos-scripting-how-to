:orphan:

.. _csharp:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Integrating VOS Solutions with C#
+++++++++++++++++++++++++++++++++

This sample demonstrates

#. How to run a VOS server at the background
#. How to integrate VOS solution in C# 

   * Specifically, :ref:`this solution <refcir>` using reference shape to compute dimensions.

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Advanced/csharp>`__
---------------------------------------------------------------------------------------------------------

* ``CsClient.csproj``: The `c# project file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/CsClient.csproj?raw=true>`__
* ``Form1.cs``: Main Form `source code <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/Form1.cs?raw=true>`__
* ``iClientApi.cs``: VOS `wrapper for c# <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/iClientApi.cs?raw=true>`__
* ``App.config``: The `configuration file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/App.config?raw=true>`__

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
  * Line 4: 
  * Line 10: Get the Run Mode of ``iServer.exe`` application, returns an ``int`` as ``EngMode``
  * Line 11: Based on ``EngMode``, display the Run Mode as text to label ``Mode``.
  * Lines 13-14: 

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

* ``GetCurrentState()``

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


  

  
  
.. |iserverico| image:: /intro/Advanced/csharp/iserver_ico.jpg

.. |APIhelp| image:: /intro/Advanced/csharp/vbhelp.jpg

.. |5025| replace:: ``5025``

.. _5025: `refcir`