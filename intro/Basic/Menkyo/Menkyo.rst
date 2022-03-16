:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

OCR of Asian Scripts & Colour Discrimination 
+++++++++++++++++++++++++++++++++++++++++++++++++++

Summary of this tutorial

1. OCR of Asian scripts
2. Conversion of Japanese era dates to Julian Calendar
3. Use of VOS lighting to discriminate the color-coded driving licenses with ``Intensity tool``
4. Use of ``Edge Count Tool`` to detect presence and absence of Japanese words in a box
5. Use of ``locator`` for all tool locations 
6. Use of ``readVar`` function in a loop for variables with similar names in a loop

+------------------+----------------------------------+------------------------------------------------------------------+
|**Function**      |**Parameters**                    |**Explanation**                                                   |
+------------------+----------------------------------+------------------------------------------------------------------+
|``readVar``       |``varName``                       |Return the value of ``varName``                                   |
+------------------+----------------------------------+------------------------------------------------------------------+

Components of the Japanese Driving License 運転免許証
-------------------------------------------------------

.. note:: 
  Images in this tutorial are adapted from `here <https://www.npa.go.jp/policies/application/license_renewal/img/license.jpg>`__

.. _menkyoComponents:

.. image:: /intro/Basic/Menkyo/components.jpg

1. The date of birth in Japanese era format. Conversion table can be found `here. <http://www.tokyo-kuwano.com/postmail/nengou_kanzan.html>`__
2. The date of issue in Japanese era format. Conversion table can be found `here. <http://www.tokyo-kuwano.com/postmail/nengou_kanzan.html>`__
3. The color-code. There are 3 colours

.. _colortable:
.. table::
  :class: tight-table 

  +------------------+----------------------------------+-------------------------------------------------------------------------+
  |Gold              |R:169 G:123 B:97   |goldbar|      |For excellent drivers who have not had a traffic offence for xxx years   |
  +------------------+----------------------------------+-------------------------------------------------------------------------+
  |Blue              |R:44  G:183 B:215  |bluebar|      |For experienced drivers                                                  |
  +------------------+----------------------------------+-------------------------------------------------------------------------+
  |Green             |R:194 G:243 B:75   |greenbar|     |For newbie drivers                                                       |
  +------------------+----------------------------------+-------------------------------------------------------------------------+

.. |goldbar| image:: /intro/Basic/Menkyo/gold.png
  :width: 20px

.. |bluebar| image:: /intro/Basic/Menkyo/blue.png
  :width: 20px

.. |greenbar| image:: /intro/Basic/Menkyo/green.png
  :width: 20px

4. The license number
5. The vehicle categories that this license hold is qualified for. The positions for the different categories are fixed. ``-`` indicates that the category is not applicable. The translation for the different categories are

.. _vehcat:
.. image:: /intro/Basic/Menkyo/shurui.jpg

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
* Without applying special lighting, using the `NTSC formula <http://support.ptc.com/help/mathcad/en/index.html#page/PTC_Mathcad_Help/example_grayscale_and_color_in_images.html>`__ directly, we get the following grayscale intensity for the 3 license colors

+-----------+------------+
|Gold       |134         |
+-----------+------------+
|Blue       |145         |
+-----------+------------+
|Green      |209         |
+-----------+------------+

* We observe that the difference between Gold & Blue is too small and will be very hard to discriminate between them based on grayscale intensity
* Referring to :ref:`the color table <colortable>` above, we can see that the green channel offers a relatively large separation for the 3 license color codes
* When we use green lighting, the red and blue channels are effectively zero. Using the `NTSC formula <http://support.ptc.com/help/mathcad/en/index.html#page/PTC_Mathcad_Help/example_grayscale_and_color_in_images.html>`__ on the green channel alone, we get the following grayscale intensity for the 3 license colors in green lighting

+-----------+------------+
|Gold       |73          |
+-----------+------------+
|Blue       |107         |
+-----------+------------+
|Green      |143         |
+-----------+------------+

.. _threshold3:

* Using midpoints we can use these intensity values as thresholds

+-----------+------------+
|Gold       |< 90        |
+-----------+------------+
|Green      |> 125       |
+-----------+------------+
|Blue       |Otherwise   |
+-----------+------------+
  

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/Menkyo>`__
------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``menkyo.bin``                    |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/menkyo.bin?raw=true>`__                           |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``green1.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/green1.bmp?raw=true>`__                              |  
  |                                     |for an unrotated green color-coded driving license under green lighting.                                                                               |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``green2.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/green2.bmp?raw=true>`__                              |  
  |                                     |for a rotated green color-coded driving license under green lighting.                                                                                  |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``green3.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/green3.bmp?raw=true>`__                              |  
  |                                     |for another rotated green color-coded driving license under green lighting.                                                                            |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |5. ``blue1.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/blue1.bmp?raw=true>`__                               |  
  |                                     |for an unrotated blue color-coded driving license under green lighting.                                                                                |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |6. ``blue2.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/blue2.bmp?raw=true>`__                               |  
  |                                     |for a rotated blue color-coded driving license under green lighting.                                                                                   |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |7. ``blue3.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/blue3.bmp?raw=true>`__                               |  
  |                                     |for another rotated blue color-coded driving license under green lighting.                                                                             |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |8. ``gold1.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/gold1.bmp?raw=true>`__                               |  
  |                                     |for an unrotated gold color-coded driving license under green lighting.                                                                                |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |9. ``gold2.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/gold2.bmp?raw=true>`__                               |  
  |                                     |for a rotated gold color-coded driving license under green lighting.                                                                                   |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |10. ``gold3.bmp``                    |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/gold3.bmp?raw=true>`__                               |
  |                                     |for another rotated gold color-coded driving license under green lighting.                                                                             |   
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where the images have been saved                                                                                                                     |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until  ``blue1.bmp`` is loaded. 

.. image:: /intro/Basic/Menkyo/blue_mono3.jpg

* A ``Match tool`` |matchtool| named ``MS`` with the region-of-interest (ROI) set to 6 in :ref:`License Components <menkyoComponents>` with properties set as shown

  .. image:: /intro/Basic/Menkyo/matchToolProp.jpg
  
  * ``Rotation`` is set between ``0`` to ``360`` 
  * ``Method`` is ``Edges only`` 
  * ``Show points`` with ``Origin`` & ``Corner`` selected for position and rotation of Locator 1 respectively

+-------------------+--------------------+
||L1pos|            ||L1loc|             |
+-------------------+--------------------+
||L1postext|        ||L1loctext|         |
+-------------------+--------------------+

.. |L1pos| image:: /intro/Basic/Menkyo/L1pos.jpg
  :width: 300px

.. |L1loc| image:: /intro/Basic/Menkyo/L1loc.jpg
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

* 14 ``Preprocessor`` tools for each box of the vehicle categories which is 5 in :ref:`License Components <menkyoComponents>` to remove the background pattern
* 14 ``Edge Count`` tools named ``E0`` to ``E13`` for each box diagonally of the vehicle categories which is 5 in :ref:`License Components <menkyoComponents>` with these properties

  .. image:: /intro/Basic/Menkyo/edgecountprop.jpg

.. _thresedgecount:

  * With the ``Edge`` property set to ``Either``, we can check if the box is marked with *kanji* or ``-`` 
  
  +------------------------+-------------------------------------------+
  |                        |**Edge Count Value**                       |
  +------------------------+-------------------------------------------+
  ||emptybox|              |2 for an empty box                         |
  +------------------------+-------------------------------------------+
  ||kanjibox|              |> 2 for a box with kanji                   |
  +------------------------+-------------------------------------------+

.. |emptybox| image:: /intro/Basic/Menkyo/emptybox.png
.. |kanjibox| image:: /intro/Basic/Menkyo/kanjibox.png  

Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  


Solution Initialize
#####################
* Choose the predefined function ``Solution Initialize`` at the bottom left 
  .. image:: /intro/Basic/Menkyo/solninit.jpg

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


* Lines 1-2: :ref:`Thresholds <threshold3>` for gold and green
* Lines 3-5: Strings for the 3 license colors
* Line 6: :ref:`Threshold <thresedgecount>` for an empty vehicle category
* Lines 7-8: Self-defined values for ``TTrue`` and ``FFalse``. Used for indicating vehicle category box's occupancy
* Lines 9-22: The different :ref:`vehicle categories <vehcat>`.

.. note:: 
  Since we are displaying the vehicle categories with ``SetDisplayStatus``, we need to ensure that the 256 character limit is not violated for someone that has obtained all the 14 vehicle categories. Hence shortforms are used.

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 

#multiple #preprocessor #scratch #detection #remove #blob #erode #dilate #stacking #stack

