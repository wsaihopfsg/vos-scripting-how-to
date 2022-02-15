.. include:: /shared/EmulatorComponents.rst

Scratch Detection 
+++++++++++++++++

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Scratch>`__
------------------------------------------------------------------------------------------------

#. ``scratch.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Scratch/scratch.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
#. ``unscratched.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Scratch/unscratched.bmp?raw=true>`__ for PASS with no patch detected.
#. ``scratched_hidden.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/DetectDots/scratched_hidden.bmp?raw=true>`__ for FAIL due to scratch detected.

   * At the Sensor Setup page |sensorsetup|, set |demoimg| to the folder where ``mpsmdots.bmp`` & ``mpsmok.bmp`` have been saved 

Tools Explanation
-----------------
* At the ``Tool Setup`` page |toolsetup|, click on |takepic| if until ``scratched_hidden.bmp`` is loaded.
