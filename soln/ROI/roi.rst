.. include:: /shared/EmulatorComponents.rst

Sequential reading of QR codes
++++++++++++++++++++++++++++++

This sample demonstrates

#. How to dynamically change ROI through VOS script
#. Reading of QR codes

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/ROI>`__
--------------------------------------------------------------------------------------------------

#. ``roishift.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ROI/roishift.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
#. ``QR1.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ROI/QR1.bmp?raw=true>`__ with 6 QR codes, with an alphabet encoded in each.

   * At the Sensor Setup page |sensorsetup|, set |demoimg| to the folder where ``QR1.bmp`` has been saved 

Tools Explanation
-----------------
* At the ``Tool Setup`` page |toolsetup|, click on |takepic| if ``QR1.bmp`` is not loaded
* Only a ``2D Barcode`` tool called ``B2d0`` is used with the region-of-interest (ROI) set at one of the QR codes. Note that the actual QR code that lies within the ROI in this ``Tool Setup`` page may be different, depending on when the emulator was stopped in the previous run.

|BC2d_ROI|

Code Walk-Through
-----------------
* Click on ``Edit Script`` |edit| 

Solution Initialize
###################

* Choose the predefined function ``Solution Initialize`` at the bottom left 
  |fn_init|

* In the Script Function window we see 2 variables being initialized

   * ``nowCtr`` keeps track of which QR code is being read
   * ``opStr`` is the output string for ``SetDisplayStatus``
  
.. code-block::
   :linenos:

   nowCtr = 0
   opStr = ""


Periodic Function
#################
* Choose the predefined function ``Periodic: 200ms`` at the bottom right 
  |fn_periodic|

* In the Script Function window we see 

.. code-block::
    :linenos:
    :emphasize-lines: 13

    xIntv = 164
    yIntv = 142
    nowCol = nowCtr % 3
    nowRow = (nowCtr - nowCol) / 3
    Tool1Pos[0] = "setroi"
    Tool1Pos[1] = "B2d0"
    Tool1Pos[2] = 0
    Tool1Pos[3] = "rect"
    Tool1Pos[4] = nowCol * xIntv + 412
    Tool1Pos[5] = nowRow * yIntv + 351
    Tool1Pos[6] = nowCol * xIntv + 535
    Tool1Pos[7] = nowRow * yIntv + 475
    setParam(8,Tool1Pos)
    if(nowCtr < 6) 
        nowCtr = nowCtr + 1
        Delay(200)
        ReTrigger(0)
    else
        nowCtr = 0
        opStr = ""
    endif

* The shift ROI operation is performed by the ``setparam`` function as high-lighted aboved in line 13. The following table is copied from the VOS online help page; for QR code reading however, ``rect`` will suffice.

 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ROI Type       | Points             | Explanation                                                                                 |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ``point``      | x y                |                                                                                             |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ``rect``       | x1 y1 x2 y2        | top left and bottom right corner points                                                     |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ``line``       | x1 y1 x2 y2        | end points                                                                                  |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ``circle``     | x1 y1 x2 y2        | any point on the circumference, opposite point on circumference along the diameter          |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ``arc``        | x1 y1 x2 y2 x3 y3  | start point of the arc, any point along the arc, end point of the arc                       |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ``polyline``   | x1 y1 ... xn yn    | all the vertex points                                                                       |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ``polygon``    | x1 y1 ... xn yn    | all the vertex points. Polygon automatically closed by connecting the first and last points |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ``annulus``    | x1 y1 x2 y2 x3 y3  | center point, any point on the outer circle, any point on the inner circle                  |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+
 | ``annulararc`` | x1 y1 x2 y2 x3 y3  | center point, a corner of the inner arc, corner at the opposite end on the outer arc        |
 +----------------+--------------------+---------------------------------------------------------------------------------------------+

* The ``argList`` is stored in the array ``Tool1Pos`` defined in lines 5-12
  
  0. Name of the parameter being set, ``setroi``
  1. Tool name, ``B2d0``
  2. CamID, always ``0`` for VOS 
  3. ROI Type, ``rect``
  4. x1 is the x-coordinate of the top left corner
  5. y1 is the y-coordinate of the top left corner
  6. x2 is the x-coordinate of the bottom right corner
  7. y2 is the y-coordinate of the bottom right corner


* ``nowCtr`` in line 19 is a counter that keeps track of the current QR code being read, numbered as shown below.
   
   * ``nowCol`` in line 3 is the current column as calculated from ``nowCtr`` 
   * ``nowRow`` in line 4 is the current row as calculated from ``nowCtr`` 

  |BC2d_idx|

* ``xIntv`` in line 1 the increament in x value for each column
* ``yIntv`` in line 2 the increament in y value for each row
* The hardcoded values in lines 9-12 are the top left and bottom right (x,y) coordinates for the first QR code when nowCtr=0.
* ``Delay`` in line 16 creates a delay in a periodic function in milliseconds.
* ``ReTrigger`` in line 17 causes re-processing the last image on the indicated camID, which works only in a periodic function. Each ``ReTrigger`` causes the script to be re-run, with ROI shifted and the output changed.

Post Image Process
##################
* Choose the predefined function ``Post Image Process`` at the bottom left 
  |fn_post|

* In the Script Function window we see 

.. code-block::
    :linenos:
    
    opStr = opStr + B2d0
    if(StrLen(opStr)=3) 
        opStr = opStr + "\n"
    endif
    SetDisplayStatus(opStr,"darkgreen")

* The code simply appends the results from the QR code tool to ``opStr`` in line 1 and insetion of a line break at the third character in line 3 before displaying ``opStr`` through ``SetDisplayStatus``.

Running the solution
--------------------

* At the ``Run Solution`` |runsoln| page, click on ``Manual Trigger`` |manTrig| button.

  |VOSROX|

#dynamic #ROI #setparam #sequential #shift #region-of-interest #region #interest

.. |QR1| image:: /code/Soln/ROI/QR1.bmp
   :width: 480pt
   :height: 360pt

.. |BC2d_ROI| image:: /soln/ROI/BC2d_ROI.jpg

.. |BC2d_idx| image:: /soln/ROI/BC2d_idx.jpg

.. |VOSROX| image:: /soln/ROI/vosrox.gif
   :align: middle
