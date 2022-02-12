Sequential reading of QR codes
++++++++++++++++++++++++++++++
.. _shiftROI:

Folder Contents
---------------
#. ``roishift.bin``: The solution file //todo actual links

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
#. ``QR1.bmp``: The image file with 6 QR codes

   * At the Sensor Setup page |sensorsetup|, set |demoimg| to the folder where ``QR1.bmp`` has been saved 

Tool Explanation
----------------
* At the Tool Setup page |toolsetup|, click on |takepic| if ``QR1.bmp`` is not loaded
* Only a ``2D Barcode`` tool is used with the region-of-interest (ROI) set at one of the QR codes 

|BC2d|

Code Explanation
----------------
* Click on ``Edit Script`` |edit| 
* Choose the predefined function ``Periodic: 200ms`` at the bottom right 
* In the Script Function window we see 

.. |QR1| image:: /code/ROI/QR1.bmp
   :width: 480pt
   :height: 360pt

.. |edit| image:: /img/emulator/buttons/editscript.jpg
   :width: 45px
   :height: 45px

.. |solnsetup| image:: /img/emulator/buttons/SolutionSetup.jpg
   :width: 45px
   :height: 45px

.. |import| image:: /img/emulator/buttons/ImportSoln.jpg
   :width: 45px
   :height: 45px

.. |demoimg| image:: /img/emulator/demoImgLoc.jpg
   :width: 421px
   :height: 74px

.. |sensorsetup| image:: /img/emulator/buttons/SensorSetup.jpg
   :width: 45px
   :height: 45px

.. |toolsetup| image:: /img/emulator/buttons/ToolSetup.jpg
   :width: 45px
   :height: 45px

.. |takepic| image:: /img/emulator/buttons/TakePic.jpg
   :width: 45px
   :height: 45px

.. |BC2d| image:: /img/Soln/ROI/BC2d.jpg

