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
* ``Form1.resx``: Main Form `design <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/Form1.resx?raw=true>`__
* ``iClientApi.cs``: VOS `wrapper for c# <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/iClientApi.cs?raw=true>`__
* ``App.config``: The `configuration file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/csharp/App.config?raw=true>`__

Running iServer.exe
===================

* Open ``%ProgramFiles(x86)%/Pepperl+Fuchs/VisionConfigurationTool`` folder
* Look for ``iServer.exe`` |iserverico|, and run it.

  .. image:: /intro/Advanced/csharp/iserver.jpg

* Copy ``*.dll`` from the ``%ProgramFiles(x86)%/Pepperl+Fuchs/VisionConfigurationTool`` folder to the folder where your c# program will be compiled

  * Note that the version for ``*.dll``  and ``iServer.exe`` has to be the same.


.. |iserverico| image:: /intro/Advanced/csharp/iserver_ico.jpg

Code Walk-Through
-----------------

.. code-block::
    :linenos:

