:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

OCR of Asian Scripts & Colour Discrimination 
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

1. OCR of Asian scripts
2. Conversion of Japanese era dates to Gregorian Calendar
3. Use of VOS lighting to discriminate the color-coded driving licenses with ``Intensity tool`` |intensitytool|
4. Use of ``Edge Count Tool`` |edgecounttool| to detect presence and absence of Japanese words in a box
5. Use of ``locator`` for all tool locations 
6. Use of ``readVar`` function in a loop for variables with similar names in a loop

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``ReadVar``       |``varName``                       |Return the value of ``varName``                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``WriteVar``      |``varName`` , ``value``           |Write ``value`` to ``varName``                                    |
+------------------+----------------------------------+------------------------------------------------------------------+

Components of the Japanese Driving License 運転免許証
-------------------------------------------------------

.. note:: 
  Images in this tutorial are adapted from `here <https://www.npa.go.jp/policies/application/license_renewal/img/license.jpg>`__

.. _menkyoComponents:

.. image:: /soln/Menkyo/components.jpg

1. The date of birth in Japanese era format. Conversion table can be found `here. <http://www.tokyo-kuwano.com/postmail/nengou_kanzan.html>`__
2. The date of issue in Japanese era format. Conversion table can be found `here. <http://www.tokyo-kuwano.com/postmail/nengou_kanzan.html>`__ The last 5 digits are the issuing number.
3. The color-code. There are 3 colours

.. _colortable:
.. table::
  :class: tight-table 

  +------------------+----------------------------------+--------------------------------------------------------------------------------+
  |Gold              |R:169 G:123 B:97   |goldbar|      |For excellent drivers who have not had a traffic offence or accident for 5 years|
  +------------------+----------------------------------+--------------------------------------------------------------------------------+
  |Blue              |R:44  G:183 B:215  |bluebar|      |For experienced drivers                                                         |
  +------------------+----------------------------------+--------------------------------------------------------------------------------+
  |Green             |R:194 G:243 B:75   |greenbar|     |For newbie drivers                                                              |
  +------------------+----------------------------------+--------------------------------------------------------------------------------+

.. |goldbar| image:: /soln/Menkyo/gold.png
  :width: 20px

.. |bluebar| image:: /soln/Menkyo/blue.png
  :width: 20px

.. |greenbar| image:: /soln/Menkyo/green.png
  :width: 20px

4. The license number
5. The vehicle categories that this license hold is qualified for. The positions for the different categories are fixed. ``-`` indicates that the category is not applicable. The translation for the different categories are

.. _vehcat:
.. image:: /soln/Menkyo/shurui.jpg

.. table::
  :class: tight-table 

  +------------------+----------------------------------+------------------+----------------------------------+
  |0                 |Heavy vehicle                     |6                 |Small special vehicle             |
  +------------------+----------------------------------+------------------+----------------------------------+
  |1                 |Medium vehicle                    |7                 |Moped                             |
  +------------------+----------------------------------+------------------+----------------------------------+
  |2                 |Semi-medium vehicle               |8                 |Commercial special vehicle        |
  +------------------+----------------------------------+------------------+----------------------------------+
  |3                 |Ordinary vehicle                  |9                 |Commercial medium vehicle         |
  +------------------+----------------------------------+------------------+----------------------------------+
  |4                 |Heavy special vehicle             |10                |Commercial ordinary vehicle       |
  +------------------+----------------------------------+------------------+----------------------------------+
  |5                 |Heavy motocycle                   |11                |Commercial heavy vehicle          |
  +------------------+----------------------------------+------------------+----------------------------------+
  |12                |Ordinary motocycle                |13                |Commercial tractor-trailer vehicle|
  +------------------+----------------------------------+------------------+----------------------------------+

6. The words "Driving License" in Japanese which is constant in all variation of licenses.

How to Discriminate License Colours in VOS
--------------------------------------------

* Most VOS variants can only "see" in grayscale
* Without applying special lighting, using the `NTSC formula <http://support.ptc.com/help/mathcad/en/index.html#page/PTC_Mathcad_Help/example_grayscale_and_color_in_images.html>`__ directly, we get the following grayscale intensity in column 2 of :ref:`Table 1 <table1>`

.. _table1:

.. table::
  :class: tight-table 

  +-----------+------------+---------------+-----------------+
  |Column 1   |Column 2    |Column 3       |Column 4         | 
  +-----------+------------+---------------+-----------------+
  |Table 1    ||NTSC|      ||greenlight|   |Chosen Threshold | 
  +-----------+------------+---------------+-----------------+
  |Gold       |134         |73             |< 90             |
  +-----------+------------+---------------+-----------------+
  |Blue       |145         |107            |Otherwise        |
  +-----------+------------+---------------+-----------------+
  |Green      |209         |143            |> 125            |
  +-----------+------------+---------------+-----------------+

.. |NTSC| replace:: NTSC Grayscale Intensity
.. |greenlight| replace:: Green Light Grayscale Intensity

* We observe that the intensity difference between Gold (134) & Blue (145) is too small and will be very hard to discriminate between them based on grayscale intensity
* Referring to :ref:`the color table <colortable>` above, we can see that the green channel offers a relatively large separation for the 3 license color codes
* When we use green lighting, the red and blue channels are effectively zero. Using the `NTSC formula <http://support.ptc.com/help/mathcad/en/index.html#page/PTC_Mathcad_Help/example_grayscale_and_color_in_images.html>`__ on the green channel alone, we get the following grayscale intensity for the 3 license colors in green lighting in column 3 of :ref:`Table 1 <table1>`
* Using midpoints we can use the intensity values of column 4 of :ref:`Table 1 <table1>` as thresholds


`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/Menkyo>`__
------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``menkyo.bin``                    |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/menkyo.bin?raw=true>`__                            |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <soln/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution        |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``green1.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/green1.bmp?raw=true>`__                               |  
  |                                     |for an unrotated green color-coded driving license under green lighting.                                                                               |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``green2.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/green2.bmp?raw=true>`__                               |  
  |                                     |for a rotated green color-coded driving license under green lighting.                                                                                  |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``green3.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/green3.bmp?raw=true>`__                               |  
  |                                     |for another rotated green color-coded driving license under green lighting.                                                                            |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |5. ``blue1.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/blue1.bmp?raw=true>`__                                |  
  |                                     |for an unrotated blue color-coded driving license under green lighting.                                                                                |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``blue2.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/blue2.bmp?raw=true>`__                                |  
  |                                     |for a rotated blue color-coded driving license under green lighting.                                                                                   |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |7. ``blue3.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/blue3.bmp?raw=true>`__                                |  
  |                                     |for another rotated blue color-coded driving license under green lighting.                                                                             |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``gold1.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/gold1.bmp?raw=true>`__                                |  
  |                                     |for an unrotated gold color-coded driving license under green lighting.                                                                                |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |9. ``gold2.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/gold2.bmp?raw=true>`__                                |  
  |                                     |for a rotated gold color-coded driving license under green lighting.                                                                                   |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |10. ``gold3.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Soln/Menkyo/gold3.bmp?raw=true>`__                                |
  |                                     |for another rotated gold color-coded driving license under green lighting.                                                                             |   
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

.. image:: /soln/Menkyo/blue_mono3.jpg

* A ``Match tool`` |matchtool| named ``MS`` with the region-of-interest (ROI) set to 6 in :ref:`License Components <menkyoComponents>` with properties set as shown

  .. image:: /soln/Menkyo/matchToolProp.jpg
  
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

* 3 ``OCR`` tools |ocrtool| at these locations of the :ref:`License Components <menkyoComponents>` 

.. table::
  :class: tight-table 

  +----------------------+--------------------+--------------------------------------------------------------------------------------------+
  |Locations in |lic|_   |Name                |Description                                                                                 |
  +----------------------+--------------------+--------------------------------------------------------------------------------------------+
  |1                     |ocrRegDate1         ||desp1|                                                                                     |
  +----------------------+--------------------+                                                                                            +
  |2                     |ocrRegDate          |                                                                                            |
  +----------------------+--------------------+--------------------------------------------------------------------------------------------+
  |4                     |OCR                 ||desp2|                                                                                     |
  +----------------------+--------------------+--------------------------------------------------------------------------------------------+

.. |lic| replace:: ``License Components``
.. _lic: #components-of-the-japanese-driving-license
.. |desp1| replace:: The *kanji* relevant to the Japanese era dates are taught-in as full-width characters. |br| Numbers are taught-in as half-width characters.
.. |desp2| replace:: Only numbers are taught-in. Preprocessor ``Threshold`` is applied to remove the background pattern for the 4 digits at the center.
.. |br| raw:: html

   <br />

* 14 ``Preprocessor`` tools |preprocessortool| for each box of the vehicle categories (5 in :ref:`License Components <menkyoComponents>`) to remove the background pattern
* 14 ``Edge Count`` tools |edgecounttool| named ``E0`` to ``E13`` for each box diagonally of the vehicle categories (5 in :ref:`License Components <menkyoComponents>`) with these properties

  .. image:: /soln/Menkyo/edgecountprop.jpg

.. _thresedgecount:

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


* Lines 1-2: :ref:`Thresholds <table1>` for gold and green
* Lines 3-5: Strings for the 3 license colors
* Line 6: :ref:`Threshold <thresedgecount>` for an empty vehicle category
* Lines 7-8: Self-defined values for ``TTrue`` and ``FFalse``. Used for indicating vehicle category box's occupancy
* Lines 9-22: The different :ref:`vehicle categories <vehcat>`.

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
||green1l|     ||green1r|      |
+--------------+---------------+
||green2l|     ||green2r|      |
+--------------+---------------+
||green3l|     ||green3r|      |
+--------------+---------------+
||blue1l|      ||blue1r|       |
+--------------+---------------+
||blue2l|      ||blue2r|       |
+--------------+---------------+
||blue3l|      ||blue3r|       |
+--------------+---------------+
||gold1l|      ||gold1r|       |
+--------------+---------------+
||gold2l|      ||gold2r|       |
+--------------+---------------+
||gold3l|      ||gold3r|       |
+--------------+---------------+

.. |green1l| image:: /soln/Menkyo/green1l.jpg
  :width: 250px
.. |green1r| image:: /soln/Menkyo/green1r.jpg
.. |green2l| image:: /soln/Menkyo/green2l.jpg
  :width: 250px  
.. |green2r| image:: /soln/Menkyo/green2r.jpg
.. |green3l| image:: /soln/Menkyo/green3l.jpg
  :width: 250px
.. |green3r| image:: /soln/Menkyo/green3r.jpg

.. |blue1l| image:: /soln/Menkyo/blue1l.jpg
  :width: 250px
.. |blue1r| image:: /soln/Menkyo/blue1r.jpg
.. |blue2l| image:: /soln/Menkyo/blue2l.jpg
  :width: 250px
.. |blue2r| image:: /soln/Menkyo/blue2r.jpg
.. |blue3l| image:: /soln/Menkyo/blue3l.jpg
  :width: 250px
.. |blue3r| image:: /soln/Menkyo/blue3r.jpg

.. |gold1l| image:: /soln/Menkyo/gold1l.jpg
  :width: 250px
.. |gold1r| image:: /soln/Menkyo/gold1r.jpg
.. |gold2l| image:: /soln/Menkyo/gold2l.jpg
  :width: 250px
.. |gold2r| image:: /soln/Menkyo/gold2r.jpg
.. |gold3l| image:: /soln/Menkyo/gold3l.jpg
  :width: 250px
.. |gold3r| image:: /soln/Menkyo/gold3r.jpg

.. note:: 
  Please refer to :doc:`here </intro/Advanced/MQTT/MQTT>` for sending the data extracted from this tutorial to a mobile phone through MQTT


.. tip::
  #japanese #OCR #teach-in #asian #script #edge #count 

