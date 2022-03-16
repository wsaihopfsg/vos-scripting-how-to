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
* Without applying special lighting, using the `NTSC formula <http://support.ptc.com/help/mathcad/en/index.html#page/PTC_Mathcad_Help/example_grayscale_and_color_in_images.html>` directly, we get the following grayscale intensity for the 3 license colors

+-----------+------------+
|Gold       |134         |
+-----------+------------+
|Blue       |145         |
+-----------+------------+
|Green      |209         |
+-----------+------------+

* We observe that the difference between Gold & Blue is too small and will be very hard to discriminate between them based on grayscale intensity
* Referring to :ref:`the color table <colortable>` above, we can see that the green channel offers a relatively large separation for the 3 license color codes
* When we use green lighting, the red and blue channels are effectively zero. Using the `NTSC formula <http://support.ptc.com/help/mathcad/en/index.html#page/PTC_Mathcad_Help/example_grayscale_and_color_in_images.html>` on the green channel alone, we get the following grayscale intensity for the 3 license colors in green lighting

+-----------+------------+
|Gold       |73          |
+-----------+------------+
|Blue       |107         |
+-----------+------------+
|Green      |143         |
+-----------+------------+

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

+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|1.``menkyo.bin``                     |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/menkyo.bin?raw=true>`__                           |
|                                     |                                                                                                                                                       |
|                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution |  
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|2.``green1.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/green1.bmp?raw=true>`__                              |  
|                                     |for an unrotated green color-coded driving license.                                                                                                    |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|3.``green2.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/green2.bmp?raw=true>`__                              |  
|                                     |for a rotated green color-coded driving license.                                                                                                       |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|4.``green3.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/green3.bmp?raw=true>`__                              |  
|                                     |for another rotated green color-coded driving license.                                                                                                 |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|5.``blue1.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/blue1.bmp?raw=true>`__                               |  
|                                     |for an unrotated blue color-coded driving license.                                                                                                     |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|6.``blue2.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/blue2.bmp?raw=true>`__                               |  
|                                     |for a rotated blue color-coded driving license.                                                                                                        |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|7.``blue3.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/blue3.bmp?raw=true>`__                               |  
|                                     |for another rotated blue color-coded driving license.                                                                                                  |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|8.``gold1.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/gold1.bmp?raw=true>`__                               |  
|                                     |for an unrotated gold color-coded driving license.                                                                                                     |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|9.``gold2.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/gold2.bmp?raw=true>`__                               |  
|                                     |for a rotated gold color-coded driving license.                                                                                                        |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
|10.``gold3.bmp``                     |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Menkyo/gold3.bmp?raw=true>`__                               |
|                                     |for another rotated gold color-coded driving license.                                                                                                  |   
|                                     |                                                                                                                                                       |   
|                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
|                                     |                                                                                                                                                       |
|                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
|                                     |                                                                                                                                                       |
|                                     |  where the images have been saved                                                                                                                     |
+-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until  ``todo.bmp`` is loaded. 

//.. image:: /code/Soln/Scratch/scratched_hidden.bmp

* 3 tools have been used

  * A ``todo`` tool named ``Pre``
  * Another ``todo`` tool named ``Pre1`` 
  * A ``todo`` tool named ``N`` 

  
+-------------------+--------------------+-----------------------------+
|                   |Pic. above, removes |Pic. below, removes          |
|                   |                    |                             |              
|                   |small patches only  |big & small patches together |
+-------------------+--------------------+-----------------------------+
|Max Area           |400                 |1500                         |
+-------------------+--------------------+-----------------------------+
|Max Width          |30                  |100                          |
+-------------------+--------------------+-----------------------------+
|Max Height         |30                  |100                          |
+-------------------+--------------------+-----------------------------+

Code Walk-Through
-----------------
* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  

Post Image Process
##################
* Choose the predefined function ``Post Image Process`` at the bottom left 
  |fn_post|

* In the Script Function window we see 

.. code-block::
    :linenos:

    //todo

* Line 1: todo
* Line 2: todo

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 

#multiple #preprocessor #scratch #detection #remove #blob #erode #dilate #stacking #stack

