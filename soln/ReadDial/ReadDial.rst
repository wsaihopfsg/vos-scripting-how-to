:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Reading an Analog Dial Through VOS Tools
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

1. Using ``Count`` tool |counttool| as a position locator
2. Using ``Match`` tool |matchtool| as rotation locator
3. Use of ``Pencil`` tool |penciltool| to join 2 points
4. Use of ``Angke`` tool |angletool| to detect the angle between the needle and some reference points

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Soln/ReadDial>`__
----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``solution11.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/ReadDial/solution11.bin?raw=true>`__                      |
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
* At the :hoverxreftooltip:`Tool Setup page <soln/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until  ``blue1.bmp`` is loaded. 


  * ``Rotation`` is set between ``0`` to ``360`` 
  * ``Method`` is ``Edges only`` 
  * ``Show points`` with ``Origin`` & ``Corner`` selected for position and rotation of Locator 1 respectively

+-------------------+--------------------+
||L1pos|            ||L1loc|             |
+-------------------+--------------------+
||L1postext|        ||L1loctext|         |
+-------------------+--------------------+

.. |L1pos| image:: /soln/Menkyo/L1pos.jpg
  :width: 300px

.. |L1loc| image:: /soln/Menkyo/L1loc.jpg
  :width: 300px

.. |L1postext| replace:: Properties for point at ``Origin`` for Locator 1's position
.. |L1loctext| replace:: Properties for point at ``Corner`` for Locator 1's rotation

.. table::
  :class: tight-table 

  +----------------------+--------------------+--------------------------------------------------------------------------------------------+
  |Locations in |lic|_   |Name                |Description                                                                                 |
  +----------------------+--------------------+--------------------------------------------------------------------------------------------+
  ||cir1|                |ocrRegDate1         ||desp1|                                                                                     |
  +----------------------+--------------------+                                                                                            +
  ||cir2|                |ocrRegDate          |                                                                                            |
  +----------------------+--------------------+--------------------------------------------------------------------------------------------+
  ||cir4|                |OCR                 ||desp2|                                                                                     |
  +----------------------+--------------------+--------------------------------------------------------------------------------------------+

.. |lic| replace:: ``License Components``
.. _lic: #components-of-the-japanese-driving-license
.. |desp1| replace:: The *kanji* relevant to the Japanese era dates are taught-in as full-width characters. |br| Numbers are taught-in as half-width characters.
.. |desp2| replace:: Only numbers are taught-in. Preprocessor ``Threshold`` is applied to remove the background pattern for the 4 digits at the center.
.. |br| raw:: html

   <br />

  .. image:: /soln/Menkyo/edgecountprop.jpg

  * With the ``Edge`` property set to ``Either``, we can check if the box is marked with *kanji* or ``-`` 
  
  +------------------------+-------------------------------------------+
  |                        |**Edge Count Value**                       |
  +------------------------+-------------------------------------------+
  ||emptybox|              |2 for an empty box                         |
  +------------------------+-------------------------------------------+
  ||kanjibox|              |> 2 for a box with *kanji*                 |
  +------------------------+-------------------------------------------+

.. |emptybox| image:: /soln/Menkyo/emptybox.png
.. |kanjibox| image:: /soln/Menkyo/kanjibox.png  

* An ``Intensity`` tool |intensitytool| for color discrimination named ``IntenAvg``
  
Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <soln/Hover/editscript:Edit Script>` |edit| |cir1|  


Solution Initialize
#####################
* Choose the predefined function ``Solution Initialize`` at the bottom left 

  .. image:: /soln/Menkyo/solninit.jpg

* In the Script Function window we see 

.. code-block::
  :linenos:

  thresLtIsGold = 90 //below=gold
  thresGtIsGreen = 125 //above=green
  licStr.0 = "Gold"
  licStr.1 = "Blue"
  licStr.2 = "Green"
  thresEEmpty = 2
  TTrue = 1
  FFalse = 0
  vehCat.0 = "Heavy Veh."
  vehCat.1 = "Med. Veh."
  vehCat.2 = "Semi-Med. Veh."
  vehCat.3 = "Ord. Veh."
  vehCat.4 = "Heavy Special Veh."
  vehCat.5 = "Heavy Motor."
  vehCat.6 = "Small Special Veh."
  vehCat.7 = "Moped"
  vehCat.8 = "Comm. Heavy Veh."
  vehCat.9 = "Comm. Med. Veh."
  vehCat.10 = "Comm. Ord. Veh."
  vehCat.11 = "Comm. Heavy Special Veh."
  vehCat.12 = "Ord. Motor."
  vehCat.13 = "Comm. Tractor-Trailer Veh."



.. note:: 
  Since we are displaying the vehicle categories with ``SetDisplayStatus``, we need to ensure that the 256 character limit is not violated for someone that has obtained all the 14 vehicle categories. Hence shortforms are used.

User-Defined Function chkLicType()
##########################################
* Choose the user-defined function ``chkLicType()`` at the bottom left 

  .. image:: /soln/Menkyo/chklictype.jpg

* In the Script Function window we see 

.. code-block::
  :linenos:

  if(IntenAvg<thresLtIsGold) 
      licType = 0 //gold
  else
      if(IntenAvg>thresGtIsGreen) 
          licType = 2 //Green
      else
          licType = 1 //Blue
      endif
  endif
  return(licStr.[licType])

* Lines 1-2: Check if ``IntenAvg`` is less than ``thresLtIsGold``, if so set ``licType`` to ``0`` (Gold)
* Lines 4-5: Check if ``IntenAvg`` is less than ``thresGtIsGreen``, if so set ``licType`` to ``2`` (Green)
* Line 7: Set ``licType`` to ``1`` otherwise (Blue)

User-Defined Function chkCat()
##########################################
* Choose the user-defined function ``chkCat()`` at the bottom left 

  .. image:: /soln/Menkyo/chkcat.jpg

* In the Script Function window we see 

.. code-block::
  :linenos:

  nowCtr = 0
  while( nowCtr<14 )
      nowEname = "E" + nowCtr
      nowE = readVar(nowEname)
      if(nowE = thresEEmpty ) 
          EEmpty.[nowCtr] = TTrue
      else
          EEmpty.[nowCtr] = FFalse
      endif
      nowCtr = nowCtr+1
  endwhile
  return (EEmpty)

* Line 1: Counter initialization
* Lines 2-11: ``while`` loop to check for all 14 ``Edge Count`` Tools
* Line 3: Set the ``varName``
* Line 4: Read the variable with ``ReadVar`` and store as ``nowE``
* Line 5: Check if ``nowE`` is equal to the threshold for empty vehicle category box ``thresEEmpty``
* Line 6: If vehicle category box is empty, set the corresponding entry in ``EEmpty`` to ``TTrue``. 
* Line 8: If vehicle category box is not empty, set the corresponding entry in ``EEmpty`` to ``FFalse``. 

.. note:: 
  ``WriteVar`` performs similar function as ``ReadVar``, writing a value to a variable

User-Defined Function convert2yr(p1)
##########################################
* Choose the user-defined function ``convert2yr(p1)`` at the bottom left 

  .. image:: /soln/Menkyo/convert2yr.jpg

* In the Script Function window we see 

.. code-block::
  :linenos:

  nenPos = find("年",p1)
  era = substring(p1,0,6)
  if(nenPos=9) //元年 first year of an era
      eraYr = 0
      eraMth = int(substring(p1,12,2))
      eraDay = int(substring(p1,17,2))
  else
      eraYr = int(substring(p1,6,2)) -1
      eraMth = int(substring(p1,11,2))
      eraDay = int(substring(p1,16,2))
  endif
  if(era ="令和") //Reiwa
      opYr = 2019
  else
      if(era="平成") //Heisei
          opYr = 1989
      else
          //昭和 Showa
          opYr = 1926
      endif
  endif
  opYr = opYr+eraYr
  opStr = string(eraDay) + "/" + string(eraMth) + "/" + string(opYr)
  return(opStr)

* Line 1: Find the position of the *kanji* 年 (year) and return the position to ``nenPos``. The first year of any era is called 元年, the other years are numerated sequentially with a half-width number. 
* Line 2: Get the Japanese era name from the first 6-byte

.. note:: 
  There are only 3 Japanese eras possible for driving licenses, either 昭和 (Showa: 1926-1989), 平成 (Heisei: 1989-2019) or 令和 (Reiwa: 2019-). Each era has 2 full-width *kanji*. Since each UTF-8 full-width character `takes 3-byte <https://en.wikipedia.org/wiki/UTF-8#Encoding>`__ , the era takes up the first 6-byte 

* Line 3: Check if the position of the *kanji* 年 from ``nenPos`` is 9, which means it is the first year of the era XX元年
* Lines 4-6: For the first year of the era, set ``eraYr`` to 0 since it is the first year of that era. Extract the month and day information to ``eraMth`` & ``eraDay`` respectively.   
* Lines 8-10: For other years of the era, set ``eraYr`` to the year value minus 1. Extract the month and day information to ``eraMth`` & ``eraDay`` respectively.   
* Lines 12-21: Set the first year to ``opYr`` based on the era information.
* Lines 22-23: Construct the Gregorian date string

User-Defined Function extractSerial()
##########################################
* Choose the user-defined function ``extractSerial()`` at the bottom left 

  .. image:: /soln/Menkyo/extractserial.jpg

* In the Script Function window we see 

.. code-block::
  :linenos:

  nichiPos = find("日",p1)
  return(int(substring(p1,nichiPos+3,0)))

* Line 1: Find the position of the *kanji* 日 (day) and return it to ``nichiPos``
* Line 2: Return the issuing number 

User-Defined Function parseCat()
##########################################
* Choose the user-defined function ``parseCat()`` at the bottom left 

  .. image:: /soln/Menkyo/parsecat.jpg

* In the Script Function window we see 

.. code-block::
  :linenos:

  nowCtr = 0
  opStr = ""
  totalCtr = 1
  while(nowCtr<14 )
      if(EEmpty.[nowCtr]=FFalse  ) 
          if(GetBit(totalCtr,0)=1) 
              opStr = opStr+vehCat.[nowCtr]
          else
              opStr = opStr+"/"+vehCat.[nowCtr] + "/\n"
          endif
          totalCtr = totalCtr+1
      endif
      nowCtr = nowCtr+1
  endwhile
  if(GetBit(totalCtr,0)=1) //was even
      opStr = substring(opStr,0,strlen(opStr)-3)
  endif
  return(opStr)

* Line 1-3: initializations
* Line 4-14: ``while`` loop for each ``EEmpty`` array element
* Line 5: Branch if ``EEmpty`` array element is not empty
* Lines 6-7: If ``totalCtr`` is odd, concatenate to ``opStr`` based on ``vehCat``
* Line 9: If ``totalCtr`` is not odd, concatenate to ``opStr`` based on ``vehCat`` with a ``\`` as separator and line break at the end
* Lines 15-17: Remove last ``\``
* Line 18: Return ``opStr``

Pre Image Process
#####################
* Choose the predefined function ``Pre Image Process`` at the bottom left 

  .. image:: /soln/Menkyo/preimgproc.jpg

* In the Script Function window we see only 1 line, which resets the ``Inspection Status Box``

.. code-block::
  :linenos:

  SetDisplayStatus( 0,0 )

.. note:: 
  The ``Inspection Status Box`` can be reset by either ``SetDisplayStatus( 0,0 )`` or ``SetDisplayStatus( "","" )``

Post Image Process
#####################
* Choose the predefined function ``Post Image Process`` at the bottom left 

  .. image:: /soln/Menkyo/postimgproc.jpg

* In the Script Function window we see

.. code-block::
  :linenos:

  licColor = chkLicType()
  chkCat()
  regDate = convert2yr(ocrRegDate )
  birthDate = convert2yr(ocrRegDate1 )
  regSerial = extractSerial(ocrRegDate )
  engCat = parseCat( )
  if(licType=0) 
      SetDisplayStatus(engCat  , "darkred")
  else
      if(licType=1  ) 
          SetDisplayStatus( engCat , "blue")
      else
          SetDisplayStatus( engCat , "darkgreen")
      endif
  endif

* Line 1: Call the ``chkLicType()`` function and return the license color code to ``licColor`` in string and ``licType`` as integer
* Line 2: Call the ``chkCat()`` function and return the occuapncy status of the vehicle category to the ``EEmpty`` array
* Line 3: Convert registration date from Japanese era to Gregorian and return it to ``regDate``
* Line 4: Convert birth date from Japanese era to Gregorian and return it to ``birthDate``
* Line 5: Return the issuing number to ``regSerial``
* Line 6: Based on ``EEmpty`` array, construct a string ``engCat``
* Lines 7-15: Display ``engCat`` based on the detected license color-code in the ``Inspection Status Box``

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
.. |dial0r| image:: /soln/ReadDial/dial0r.jpg  
.. |dial15| image:: /soln/ReadDial/dial15.jpg
.. |dial20| image:: /soln/ReadDial/dial20.jpg
.. |dial20r| image:: /soln/ReadDial/dial20r.jpg  
.. |dial25| image:: /soln/ReadDial/dial25.jpg
.. |dial40| image:: /soln/ReadDial/dial40.jpg
.. |dial40r| image:: /soln/ReadDial/dial40r.jpg  
.. |dial60| image:: /soln/ReadDial/dial60.jpg

.. |dial80| image:: /soln/ReadDial/dial80.jpg
  
.. |dial100| image:: /soln/ReadDial/dial100.jpg
.. |dial120| image:: /soln/ReadDial/dial120.jpg
  
.. |dial135| image:: /soln/ReadDial/dial135.jpg
.. |dial140| image:: /soln/ReadDial/dial140.jpg
  
.. |dial145| image:: /soln/ReadDial/dial145.jpg

.. |dial160| image:: /soln/ReadDial/dial160.jpg
  


.. tip::
  #japanese #OCR #teach-in #asian #script #edge #count 

