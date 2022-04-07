:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Punnet Orientation Checking
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

1. Using ``Edge Count`` tool |edgecounttool| to find the edge of the punnet with the help of preprocessors
2. Using the ``sort`` function

.. table::
  :class: tight-table 

  ============== ================= ======================
  **Function**   **Parameters**    **Explanation**
  Sort           |paramnames|      |paramex| 
  ============== ================= ======================

.. |paramnames| replace:: ``keyVarName``, ``ascend``, ``followVarNames``
.. |paramex| replace:: Sort the array ``keyVarName`` based on ``ascend`` (1: ascending; 0 : descending). ``followVarNames`` is an optional list of the names of arrays to be sorted in the same order as ``keyVarName``.

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/Punnet>`__
----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``solution19.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/solution19.bin?raw=true>`  __                      |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <soln/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution        |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``Image2_1.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_1.bmp?raw=true>`__                             |  
  |                                     |for a punnet in the correct orientation. Should return PASS.                                                                                           |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``Image2_2.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_2.bmp?raw=true>`__                             |  
  |                                     |for a punnet in the correct orientation. Should return PASS.                                                                                           |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``Image2_3.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_3.bmp?raw=true>`__                             |  
  |                                     |for a punnet in the correct orientation. Should return PASS.                                                                                           |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |5. ``Image2_6.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_6.bmp?raw=true>`__                             |  
  |                                     |for a punnet in the correct orientation. Should return PASS.                                                                                           |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``Image2_7x.bmp``                 |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_7x.bmp?raw=true>`__                            |  
  |                                     |for a punnet in the wrong orientation. Should return FAIL.                                                                                             |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``Image2_8x.bmp``                 |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_8x.bmp?raw=true>`__                            |  
  |                                     |for a punnet in the wrong orientation. Should return FAIL.                                                                                             |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |7. ``Image2_4.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Punnet/Image2_4.bmp?raw=true>`__                             |
  |                                     |for a composite image 2 punnets the correct orientation for tool setup. Should return PASS.                                                            |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <soln/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                             |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where the images have been saved                                                                                                                     |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <soln/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until  ``Image2_4.bmp`` is loaded. 

.. image:: /soln/Punnet/punnettoolsetup.jpg

* There is are 2 ``Edge Count`` tools |edgecounttool| defined. One named ``E1`` at the top and another named ``E2`` at the bottom. 
* For ``E1``, its properties and preprocessors are shown below

  ======================================== ============================================================
  |edgecountprop|                          |edgecountpre|
  Properties of ``E1``                     Properties of the preprocessor of ``E1``
  ======================================== ============================================================

  .. |edgecountprop| image:: /soln/Punnet/punnetedgecountprop.jpg
  .. |edgecountpre| image:: /soln/Punnet/punnetedgecountpre.jpg

.. note:: 
  The region-of-interest (ROI) for this solution can be kept small because there is a trigger sensor to ensure each punnet is captured at roughly the same place by VOS

* For ``E2``, its properties and preprocessors are shown below

  ======================================== ============================================================
  |edgecountprop2|                         |edgecountpre2|
  Properties of ``E2``                     Properties of the preprocessor of ``E2``
  ======================================== ============================================================

  .. |edgecountprop2| image:: /soln/Punnet/punnetedgecountprop2.jpg
  .. |edgecountpre2| image:: /soln/Punnet/punnetedgecountpre2.jpg

* The purpose of each preprocessor is summarized here
  
  ================== ====================================================================
  ``Equalize``       To deal with lighting variations
  ``Project H``      To get an average intensity horizontally
  ``Convolve 3x3``   An Sobel edge detector in the y-direction
  ``Threshold``      Heuristic threshold to obtain the most prominent edges 
  ================== ====================================================================
  
  * The region-of-interest (ROI) of the ``Edge Count`` tool |edgecounttool| is designed to intersect with the top and bottom edges of the punnet. Numerous intersections points are defined, each with the ``X`` & ``Y`` properties enabled. 

.. _nPP:

    * Since each picture is different, 
      
      * The names and enumeration for each detected ``Activate Edge Point`` are unchanged from the default
      * The tolerance of all ``PX`` are fixed between 310 to 411, which is the span of the ROI of ``E1`` & ``E2`` along the x-direction
      * The tolerance of all ``PY`` are fixed between 0 to 960, which is the the full y-span since we cannot tell *a-priori* if the detected edge point is going to appear in which ``Edge Count`` tool
    
    * A sample of of the ``PX`` & ``PY`` properties is shown below

    ======================= =====================
    |pxprop|                |pyprop| 
    ======================= =====================

    .. note:: 
      The ``Perfect`` values for all ``PX`` & ``PY`` do not matter since the outcome of the inspection results will be re-evailuated

    .. |pxprop| image:: /soln/Punnet/pxprop.jpg
      :width: 270px
    .. |pyprop| image:: /soln/Punnet/pyprop.jpg
      :width: 270px
  
  
Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <soln/Hover/editscript:Edit Script>` |edit| |cir1|  

Solution Initialize
#####################
* Choose the predefined function ``Solution Initialize`` at the bottom left 

  .. image:: /soln/Punnet/punnetinit.jpg

* In the Script Function window we see 

.. code-block::
  :linenos:

  minY = 40
  maxY = 950
  thresTB = (minY+maxY) * 0.5 //threshold for top & bottom Edge Counter
  thresLR = (401+311) * 0.5  //threshold for left of right side, not used?
  thresHV = 776 //heuristic threshold for horizontal or vertical punnet
  nPP = 26 //max points defined in the soln

* Line 1: The minimum Y value for a valid detected edge. This is to rule out detecting the top edge of the conveyor.
* Line 2: The maximum Y value for a valid detected edge. This is to rule out detecting the bottom edge of the conveyor.
* Line 3: Mid-point between ``minY`` and ``maxY``, serves as threshold to decide whether the detected edge point is in ``E1`` or ``E2``
* Line 4: Not used
* Line 5: Hueristic threshold for the detected length to decide on the punnet's Orientation
* Line 6: Maximum number of detected edge points, as configured :ref:`here <nPP>`

User-Defined Function gpPP()
##########################################
* Choose the user-defined function ``gpPP`` at the bottom left 

  .. image:: /soln/Punnet/punnetgppp.jpg

* In the Script Function window we see 

.. code-block::
  :linenos:

  nowIdx = 0
  topPP = 0
  botPP = 0
  while(nowIdx < nPP  )
      if(nowIdx=0) //no index for 0
          nowVarX = "PX"
          nowVarY = "PY"
      else
          nowVarX = "PX"+nowIdx
          nowVarY = "PY"+nowIdx
      endif
      tmpX = ReadVar(nowVarX)
      tmpY = ReadVar(nowVarY)
      if(tmpY!=0) 
          if(tmpY<thresTB ) 
              topX.[topPP] = tmpX
              topY.[topPP] = tmpY
              topPP = topPP+1
          else
              botX.[botPP] = tmpX
              botY.[botPP] = tmpY
              botPP = botPP+1
          endif
      endif
      nowIdx = nowIdx+1
  endwhile
  return (0)

* Line 1: ``while`` loop index
* Line 2: Counter for detected edge points at ``E1`` on top
* Line 3: Counter for  detected edge points at ``E2`` below
* Line 4: Compare ``nowIdx`` with the maximum number of edge points configured ``nPP``
* Lines 5-7: If index is ``0``, we check the variables named ``PX`` & ``PY`` as this is the default way of variable naming in VOS
* Lines 9-10: If the index is non-zero, we use the enumerated variable names based on the default way of variable naming in VOS
* Lines 12-13: Read the current x- & y-coordinates into ``tmpX`` & ``tmpY`` respectively
* Line 14: If the variable has no value or not present, zero will be returned
* Line 15: Based on ``tmpY``, the detected edge point is in ``E1``
* Line 16: Return the current ``tmpX`` value to an array called ``topX``
* Line 17: Return the current ``tmpY`` value to an array called ``topY``
* Line 18: Increment counter ``topPP``
* Line 19: Based on ``tmpY``, the detected edge point is in ``E2``
* Line 20: Return the current ``tmpX`` value to an array called ``botX``
* Line 21: Return the current ``tmpY`` value to an array called ``botY``
* Line 22: Increment counter ``botPP``
* Line 25: Increment ``while`` loop counter
 
User-Defined Function findLen()
##########################################
* Choose the user-defined function ``findLen`` at the bottom left 

  .. image:: /soln/Punnet/punnetfindlen.jpg

* In the Script Function window we see 

.. code-block::
  :linenos:

  foundTopY = 0
  foundBotY = 0
  nowIdx = 0
  while(nowIdx < topPP  )
      tmpY = topY.[nowIdx]
      if(tmpY<minY) //border
          nowIdx = nowIdx+1
      else
          tmpX = topX.[nowIdx]
          if(topX.[nowIdx+1]!=tmpX) //found 2 edges
              foundTopY = (tmpY + topY.[nowIdx+1])*0.5
          else
              //found 1 edge only
              foundTopY = tmpY
          endif
          nowIdx = topPP
      endif
  endwhile
  nowIdx = 0
  while(nowIdx < botPP  )
      tmpY = botY.[nowIdx]
      if(tmpY>maxY) //border
          nowIdx = nowIdx+1
      else
          tmpX = botX.[nowIdx]
          if(botX.[nowIdx+1]!=tmpX) //found 2 edges
              foundBotY = (tmpY + botY.[nowIdx+1])*0.5
          else
              //found 1 edge only
              foundBotY = tmpY
          endif
          nowIdx = botPP
      endif
  endwhile
  return (foundBotY-foundTopY)

.. note::
  The arrays ``topY`` is sorted in ascending order, while ``botY`` in descending order before this function is called. 

* Lines 1-2: Initialize the found edge's y-coordinates to zero
* Line 3: Index for ``while`` loop
* Lines 4-18: Checking values in array ``topY``
* Line 5: Store the current y-value inspected to ``tmpY``
* Lines 6-7: ``tmpY`` is less than the configured minimum y-value ``minY``, increment while loop index
* Lines 9-17: ``tmpY`` is more than the configured minimum y-value ``minY``
* Line 9: Store the current x-value inspected to ``tmpX``
* Line 10: Check if the next x-value is different from ``tmpX``. If so 2 edges have been found
* Line 11: Take average of the 2 found edges and return the value to ``foundTopY``
* Line 14: Only 1 edge has been found, return the found value to ``foundTopY``
* Line 16: Prepare the ``while`` loop counter for exit
* Line 19: Reset ``while`` loop counter for processing ``botY``
* Lines 20-34: Checking values in array ``botY``
* Line 21: Store the current y-value inspected to ``tmpY``
* Lines 22-23: ``tmpY`` is more than the configured maximum y-value ``maxY``, increment while loop index
* Lines 25-33: ``tmpY`` is less than the configured maximum y-value ``maxY`` 
* Line 25: Store the current x-value inspected to ``tmpX``
* Lines 26-27: Check if the next x-value is different from ``tmpX``. If so 2 edges have been found
* Line 27: Take average of the 2 found edges and return the value to ``foundTopY``
* Line 30: Only 1 edge has been found, return the found value to ``foundBotY``
* Line 32: Prepare the ``while`` loop counter for exit
* Line 35: Return the length found based on y-coordinates 

Pre Image Process
#####################

* Choose the predefined function ``Pre Image Process`` at the bottom left 

.. image:: /soln/Punnet/punnetpre.jpg

* In the Script Function window we see only 4 lines of code which deletes the arrays ``topX`` , ``topY`` , ``botX`` & ``botX``

.. code-block::
  :linenos:

  DeleteVar(topX)
  DeleteVar(topY)
  DeleteVar(botX)
  DeleteVar(botY)


Post Image Process
#####################
* Choose the predefined function ``Post Image Process`` at the bottom left 

.. image:: /soln/Punnet/punnetpost.jpg  

* In the Script Function window we see

.. code-block::
  :linenos:

  gpPP()
  idxTop.0 = "topX"
  idxBot.0 = "botX"
  sort(topY,1,idxTop) //Smallest Y first, since want to detect top
  sort(botY,0,idxBot) //Largest Y first, since want to detect bottom
  foundLen = findLen()
  if(foundLen < thresHV  ) 
      PASS = 0
      RECYCLE = 0
      FAIL = 1
  else
      PASS = 1
      RECYCLE = 0
      FAIL = 0
  endif

* Line 1: Call the user-defined function |gpPP|_
* Line 2: Store the name of the x-coordinates for the ``followVarNames`` paramater in ``sort`` for the edge point coordinates found on top 
* Line 3: Store the name of the x-coordinates for the ``followVarNames`` paramater in ``sort`` for the edge point coordinates found at the bottom 
* Line 4: Sort array ``topY`` in ascending order, with indices of ``topX`` following the same sorting order
* Line 5: Sort array ``botY`` in descending order, with indices of ``botX`` following the same sorting order
* Line 6: Return the length found according to y-coordinates to ``foundLen``
* Lines 7-10: ``foundLen`` is less than threshold and hence the punnet is in the wrong orientation, inspection fails
* Lines 11-14: ``foundLen`` is more than threshold and hence the punnet is in the right orientation, inspection passes

.. |gppp| replace:: ``gpPP()``
.. _gppp: #user-defined-function-gppp


Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <soln/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 

================ =================
|pun1|           |pun2|         
``Image2_1.bmp`` ``Image2_2.bmp`` 
|pun3|           |pun4|         
``Image2_3.bmp`` ``Image2_4.bmp`` 
|pun6|           |pun7|        
``Image2_6.bmp`` ``Image2_7.bmp`` 
|pun8|                  
``Image2_8.bmp``   
================ =================

.. |pun1| image:: /soln/Punnet/punnet1.jpg
  :width: 300px
.. |pun2| image:: /soln/Punnet/punnet2.jpg
  :width: 300px
.. |pun3| image:: /soln/Punnet/punnet3.jpg
  :width: 300px
.. |pun4| image:: /soln/Punnet/punnet4.jpg
  :width: 300px
.. |pun7| image:: /soln/Punnet/punnet7.jpg
  :width: 300px
.. |pun6| image:: /soln/Punnet/punnet6.jpg
  :width: 300px
.. |pun8| image:: /soln/Punnet/punnet8.jpg
  :width: 300px

.. tip::
  #angle #edge #count #fast #pencil #preprocessor

