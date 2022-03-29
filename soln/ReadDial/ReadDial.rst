:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Reading an Analog Dial Through VOS Tools
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

1. Using ``Count`` tool |counttool| as a position locator
2. Using ``Match`` tool |matchtool| as rotation locator
3. Using ``Tip`` tool |tiptool| to find an extreme edge 
4. Use of ``Pencil`` tool |penciltool| to join 2 points
5. Use of ``Angle`` tool |angletool| to detect the angle between the needle and some reference points

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/ReadDial>`__
----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``solution13.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/solution13.bin?raw=true>`__                      |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <soln/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution        |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``0.bmp``                         |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/0.bmp?raw=true>`__                                  |  
  |                                     |for an unrotated image of a dial with the needle pointing at 0.                                                                                        |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``0r.bmp``                        |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/0r.bmp?raw=true>`__                                 |  
  |                                     |for a rotated image of a dial with the needle pointing at 0.                                                                                           |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``15.bmp``                        |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/15.bmp?raw=true>`__                                 |  
  |                                     |for an unrotated image of a dial with the needle pointing at 15.                                                                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |5. ``20.bmp``                        |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/20.bmp?raw=true>`__                                 |  
  |                                     |for an unrotated image of a dial with the needle pointing at 20.                                                                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``20r.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/20r.bmp?raw=true>`__                                |  
  |                                     |for a rotated image of a dial with the needle pointing at 20.                                                                                          |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |7. ``25.bmp``                        |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/25.bmp?raw=true>`__                                 |  
  |                                     |for an unrotated image of a dial with the needle pointing at 25.                                                                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``40.bmp``                        |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/40.bmp?raw=true>`__                                 |  
  |                                     |for an unrotated image of a dial with the needle pointing at 40.                                                                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |9. ``40r.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/40r.bmp?raw=true>`__                                |  
  |                                     |for a rotated image of a dial with the needle pointing at 40.                                                                                          |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``60.bmp``                        |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/60.bmp?raw=true>`__                                 |  
  |                                     |for an unrotated image of a dial with the needle pointing at 60.                                                                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``80.bmp``                        |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/80.bmp?raw=true>`__                                 |  
  |                                     |for an unrotated image of a dial with the needle pointing at 80.                                                                                       |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``100.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/100.bmp?raw=true>`__                                |  
  |                                     |for an unrotated image of a dial with the needle pointing at 100.                                                                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``120.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/120.bmp?raw=true>`__                                |  
  |                                     |for an unrotated image of a dial with the needle pointing at 120.                                                                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``135.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/135.bmp?raw=true>`__                                |  
  |                                     |for an unrotated image of a dial with the needle pointing at 135.                                                                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``140.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/140.bmp?raw=true>`__                                |  
  |                                     |for an unrotated image of a dial with the needle pointing at 140.                                                                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``145.bmp``                       |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/145.bmp?raw=true>`__                                |  
  |                                     |for an unrotated image of a dial with the needle pointing at 145.                                                                                      |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |10. ``160.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/160.bmp?raw=true>`__                                |
  |                                     |for an unrotated image of a dial with the needle pointing at 160.                                                                                      |   
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <soln/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                             |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where the images have been saved                                                                                                                     |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <soln/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until  ``0.bmp`` is loaded. 

* First there is a ``Count`` tool |counttool| whose region-of-interest (ROI) covers the whole field-of-view with the following properties and preprocessor |preprocess| 

  +-----------------------+
  || |cprop|              |
  || Count tool properties|
  +-----------------------+
  || |preprop|            |
  || Preprocessor         |       
  +-----------------------+

  .. |cprop| image:: /soln/ReadDial/countlocatorprop.jpg
  .. |preprop| image:: /soln/ReadDial/countlocatorpre.jpg

  .. note::
    Use the ``Advanced`` button |advanced| to inspect the values to be entered into ``Remove blobs``. For details on using count tool as locator, please refer to :doc:`here </intro/Basic/CountLocator/CountLocator>`

  * At the centre point of the ``Count`` tool is set to be the position anchor for ``Locator 1``.

  .. image:: /soln/ReadDial/loc1pos.jpg

* A ``Match`` tool named ``MS`` is configured with its matching template set at the number 20. 
  
  .. image:: /soln/ReadDial/match20.jpg
  
  * The properties for ``MS`` are as shown
  
  .. image:: /soln/ReadDial/match20prop.jpg

  .. note
    The small dial marking to the left of number 20 is included to differentiate from the number 120

  * The centre of the matched area ``PP2`` is used as the rotation anchor for ``Locator 1``.
  
  .. image:: /soln/ReadDial/pp2rotprop.jpg
  
* A ``Tip`` tool |tiptool| named ``Tip`` with its ROI trained at a corner near to the number 120. The found corner is called ``PP4``.
  
    .. image:: /soln/ReadDial/tipat120.jpg

    * ``PP4`` is anchored to ``Locator 1``.
   
    .. image:: /soln/ReadDial/tipat120pointprop.jpg

* An ``Edge Count`` tool |edgecounttool| that detects the location of the needle and indicate the detected edge with a point ``PP1``
  
  ====================== ======================
  |ecneedle|             |ecneedleprop|  
  ====================== ======================

  .. |ecneedle| image:: /soln/ReadDial/edgecountneedle.jpg
  .. |ecneedleprop| image:: /soln/ReadDial/edgecountneedleprop.jpg

.. note:: 
  If the dial face has other objects in addition to the needle, it will be necessary to get rid of them using preprocessors.

* Multiple pencil tools for 2 angle calculations
  
  * Main angle ``A1`` w.r.t. polar axis 
  
    * One ``Pencil`` tool named ``P`` joining ``PP1`` (``Edge Count`` tool) to ``PP`` (position anchor of ``Locator 1``). Ideally it should overlap with the needle.
  
    * One ``Pencil`` tool named ``P1`` joining ``PP2`` (Centre of ``Match`` tool ``MS``) to ``PP`` (position anchor of ``Locator 1``). This line serves as the polar axis.

    ====== ======
    |p|    |p1|
    ``P``  ``P1``
    ====== ======

    .. |p1| image:: /soln/ReadDial/pencilp1.jpg 
      :width: 300px
  
    .. |p| image:: /soln/ReadDial/pencilp.jpg 
      :width: 300px

    * An ``angle`` tool |angletool| named ``A1`` that measures the angle between the pencil lines ``P`` & ``P1``. This measures the angle between the needle and the polar axis.
  
    .. image:: /soln/ReadDial/angleA1.jpg
    
  * A supplementary angle ``A2`` for deconflicting results from ``A1``
  
    * One ``Pencil`` tool named ``P2`` joining ``PP4`` (corner found by ``Tip`` tool ``Tip``) to ``PP`` (position anchor of ``Locator 1``). 
    * An ``angle`` tool |angletool| named ``A2`` that measures the angle between the pencil lines ``P`` & ``P2``. In ``0.bmp``, ``A2`` should appear as an 180° angle.
  
    ====== =======
    |p2|    |A2|
    ``P2``  ``A2``
    ====== =======
    
    .. |p2| image:: /soln/ReadDial/pencilp2.jpg 
      :width: 450px

    .. |A2| image:: /soln/ReadDial/angleA2.jpg 
      :width: 240px

Why 2 angles are needed
########################

* The results for the measured ``A1`` & ``A2`` are summarized here

  ============ ============ ============
  **Image**    **A1**       **A2**  
  ------------ ------------ ------------
  ``0.bmp``     28.29       175.18
  ``20.bmp``     1.77       145.07
  ``40.bmp``    31.37       115.48
  ``60.bmp``    61.03        85.95
  ``80.bmp``    89.68        57.12
  ``100.bmp``  118.44        28.51 
  ``120.bmp``  149.26         2.35
  ``140.bmp``  179.19        32.29 
  ``160.bmp``  149.82        63.30
  ============ ============ ============

* Just looking at ``A1``, it can be observed that ambiguity arises by the angle reported by the ``Angle`` tool |angletool| in the shaded regions.
  
.. image:: /soln/ReadDial/ambiguousregion.jpg

* Using ``A2`` together with ``A1``, we will be able to solve this ambiguity by the following psedo-code
  
  * Based on ``A1``, decide whether the needle is in the red, white or green region
    
    * If in red region, use ``A2`` to decide if the needle is above or below the 20 marking
    
      * > red_threshold, needle is below 20 
      * < red_threshold, needle is above 20  
    
    * If in green region, use ``A2`` to decide if the needle is above or below the 140 marking

      * > green_threshold, needle is above 140 
      * < green_threshold, needle is below 140  

Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <soln/Hover/editscript:Edit Script>` |edit| |cir1|  


Solution Initialize
#####################
* Choose the predefined function ``Solution Initialize`` at the bottom left 

  |fn_init|

* In the Script Function window we see 

.. code-block::
  :linenos:

  thres.0 = 145.17 //red_threshold
  thres.1 = 32.825 //green_threshold
  thres.2 = 19 // if roundedMark < this, use thres.0 otherwise use thres.1
  totalMark = 48
  oneMark = 360.0 / totalMark

* Line 1: red_threshold for ``A1`` disambiguity
* Line 2: green_threshold for ``A1`` disambiguity
* Line 3: Threshold for region determination
* Line 4: 12 big marks * 4 small marks
* Line 5: Angle for 1 small mark

Post Image Process
#####################
* Choose the predefined function ``Post Image Process`` at the bottom left 

  |fn_post|

* In the Script Function window we see

.. code-block::
  :linenos:

  exactMark = (A1 / oneMark)
  a = string("[exactMark%.0f]")
  roundedMark = int(a)
  readVal = 20+ roundedMark*5
  if( roundedMark < thres.2 ) 
      if( A2 > thres.0 ) 
          readVal = 20- roundedMark*5
      endif
  else
      if( A2 > thres.1  ) 
          readVal = 20+ (totalMark -roundedMark)*5
      endif
  endif
  SetDisplayStatus( string(readVal), "darkgreen")

* Line 1: Calculate how many marks the needle is away from the polar axis, ignoring ambiguity 
* Lines 2-3: Rounding, assuming that the needle is always exactly on a mark

* Line 4: For most values, we do not need special treatment as shown in white. Output this temporary value to ``readVal``

  .. image:: /soln/ReadDial/ambiguouscode.jpg

* Line 5: In white or red region
* Line 7: In red region that requires recalculation, and output new result to ``readVal``
* Line 11: In green region that requires recalculation, and output new result to ``readVal``
* Line 14: Display ``readVal`` to the ``Inspection Status Box``

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <soln/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 

+--------------+---------------+
||dial0|       ||dial15|       |
+--------------+---------------+
||dial20|      ||dial25|       |
+--------------+---------------+
||dial40|      ||dial60|       |
+--------------+---------------+
||dial80|      ||dial100|      |
+--------------+---------------+
||dial120|     ||dial135|      |
+--------------+---------------+
||dial140|     ||dial145|      |
+--------------+---------------+
||dial160|     ||dial0r|       |
+--------------+---------------+
||dial20r|     ||dial40r|      |
+--------------+---------------+

.. |dial0| image:: /soln/ReadDial/dial0.jpg
  :width: 300px
.. |dial0r| image:: /soln/ReadDial/dial0r.jpg  
  :width: 300px
.. |dial15| image:: /soln/ReadDial/dial15.jpg
  :width: 300px
.. |dial20| image:: /soln/ReadDial/dial20.jpg
  :width: 300px
.. |dial20r| image:: /soln/ReadDial/dial20r.jpg  
  :width: 300px
.. |dial25| image:: /soln/ReadDial/dial25.jpg
  :width: 300px
.. |dial40| image:: /soln/ReadDial/dial40.jpg
  :width: 300px
.. |dial40r| image:: /soln/ReadDial/dial40r.jpg  
  :width: 300px
.. |dial60| image:: /soln/ReadDial/dial60.jpg
  :width: 300px
.. |dial80| image:: /soln/ReadDial/dial80.jpg
  :width: 300px
.. |dial100| image:: /soln/ReadDial/dial100.jpg
  :width: 300px
.. |dial120| image:: /soln/ReadDial/dial120.jpg
  :width: 300px
.. |dial135| image:: /soln/ReadDial/dial135.jpg
  :width: 300px
.. |dial140| image:: /soln/ReadDial/dial140.jpg
  :width: 300px
.. |dial145| image:: /soln/ReadDial/dial145.jpg
  :width: 300px
.. |dial160| image:: /soln/ReadDial/dial160.jpg
  :width: 300px


.. tip::
  #dial #analog #needle #angle #pencil #count #locator #match  #remove #blobs #preprocessor

