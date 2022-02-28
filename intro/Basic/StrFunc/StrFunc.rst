:orphan:

.. _strfunc:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

String Manipulations
++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Reading a QR Code 
2. Built-in string functions; all indices are zero-based

+-----------------+----------------------------------+------------------------------------------------------------------+
|**Function**     |**Parameters**                    |**Explanation**                                                   |
+-----------------+----------------------------------+------------------------------------------------------------------+
|``Find``         |``substring``,                    |Return the first occurance of ``substring`` within ``inString``.  |
|                 |                                  |                                                                  |
|                 |``inString``                      |-1 if not found                                                   |   
+-----------------+----------------------------------+------------------------------------------------------------------+
|``Substring``    |``string``,                       |Return a substring from ``stratIndex`` for ``length`` characters  | 
|                 |                                  |                                                                  |
|                 |``startIndex``,                   |in ``string``. ``length`` =0 for the end of string                |
|                 |                                  |                                                                  |
|                 |``length``                        |                                                                  |   
+-----------------+----------------------------------+------------------------------------------------------------------+
|``StrLen``       |``string``                        |Return how many characters are in ``string``                      |
+-----------------+----------------------------------+------------------------------------------------------------------+
|``GetChar``      |``string``,                       |Return the ASCII code of a character at ``index`` of ``string``   |  
|                 |                                  |                                                                  |   
|                 |``index``                         |                                                                  |
+-----------------+----------------------------------+------------------------------------------------------------------+
|``SetChar``      |``string``,                       |Replace the character at ``index`` with ``char`` within ``string``|
|                 |                                  |                                                                  |   
|                 |``index``,                        |Note ``string`` itself is modified.                               |
|                 |                                  |                                                                  |   
|                 |``char``                          |                                                                  |
+-----------------+----------------------------------+------------------------------------------------------------------+
|``char``         |``int``                           |Return a character from the input ASCII ``int`` value             |   
+-----------------+----------------------------------+------------------------------------------------------------------+
|``int``          |``string``                        |Return an integer after conversion of the input ``string``        |  
+-----------------+----------------------------------+------------------------------------------------------------------+
|``float``        |``string``                        |Return a floating point number after conversion of the input      |
|                 |                                  |                                                                  |   
|                 |                                  |``string``                                                        |
+-----------------+----------------------------------+------------------------------------------------------------------+   
|``string``       |``inputNum``                      |Return a string based on the input number. *inputNum* can be an   |
|                 |                                  |                                                                  |   
|                 |                                  |integer or float. Float format please refer to ``FormatString``   |                                                                                   
|                 |                                  |                                                                  |   
|                 |                                  |below                                                             |
+-----------------+----------------------------------+------------------------------------------------------------------+   
||setmatch|       |``string``                        |Change the "perfect" value of the barcode/QR code/OCR             |
|                 |                                  |                                                                  |
|                 |                                  |``measurementVar`` to ``perfectMatch`` .                          |
+-----------------+----------------------------------+------------------------------------------------------------------+   
|``float``        |``measurementVar``,               |Return a floating point number after conversion of the input      |
|                 |                                  |                                                                  |
|                 |``perfectMatch``                  |``string``                                                        |
+-----------------+----------------------------------+------------------------------------------------------------------+   
|``FormatString`` |``stringForm``                    |Return formatted string using ``stringForm``. Refer to            |
|                 |                                  |:ref:`string format <stringformat>`                               |
+-----------------+----------------------------------+------------------------------------------------------------------+   
 
  
`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/StrFunc>`__
---------------------------------------------------------------------------------------------------------

1. ``strFunc.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/StrFunc/strFunc.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
2. ``vosrox.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/StrFunc/vosrox.bmp?raw=true>`__ with a rotated QR code

   * At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/MathFunc/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|, set |demoimg| |cir2| to the folder where ``vosrox.bmp`` have been saved 

Tools Explanation
-----------------
* At the ``Tool Setup`` page |toolsetup|, click on |takepic| until ``vosrox.bmp`` is loaded.
* Only a ``2D Barcode`` tool named ``B2d`` is used with the region-of-interest (ROI) set to almost the whole field-of-view.
  
  * The ``Angle`` property named ``Angle`` is enabled to obtained the angle of rotation of the QR code.

Code Walk-Through
-----------------
* Click on ``Edit Script`` |edit| 

Post Image Process
##################
* Choose the predefined function ``Post Image Process`` at the bottom left 

  .. image:: /intro/Basic/StrFunc/fn_post.jpg

* In the Script Function window we see 

.. code-block::
    :linenos:

    qrStrip = removeChar(B2d,char(32))
    qrLow = up2low(B2d)
    opStr = "QR Code="+B2d+"\nNo Space="+qrStrip+"\nlower case="+qrLow+"\n"
    opStrAngle4f = FormatString("[Angle%.4f]")
    SetChar(opStrAngle4f,StrLen(opStrAngle4f)-1,Char(176))
    SetDisplayStatus(opStr+"Angle="+opStrAngle4f,"darkgreen")
    xInt = int("123")
    xFloat = float("123.456")
    xString = string("[Angle%.4f]")
    SetMatchString(B2d, "Something Else")

* Line 1: Call a user-defined function :ref:`removeChar <removechar>` to remove ``char(32)`` (white-space) from ``B2d``
* Line 2: Call a user-defined function :ref:`up2low <uplow>` to convert all characters in ``B2d`` to lower-case
* Line 4: Format ``Angle`` to 4 decimal places and returns it to ``opStrAngle4f``
* Line 5: Replace the last character of ``opStrAngle4f`` with ``Char(176)``
* Line 6: Set the text in the Inspection Status Box with a specific color as summarized in the table below. Note that font size is chosen automatically.

===== ===== ===== ===== 
 |0|   |1|   |2|   |3|   
 |4|   |5|   |6|   |8|        
 |7|   |9|  |10|  |11|     
|12|  |13|  |14|  |15|
|16|  |17|  |18|  |19|
===== ===== ===== ===== 

* Lines 7-9: Demonstration of ``int``, ``float``, ``string`` functions respectively

.. _setperfect:

* Line 10: Changes the "perfect" value of ``B2d`` to the string "Something Else"

.. _removechar:

removeChar(p1,p2)
##################
* Choose the user-defined function ``removeChar(p1,p2)`` at the bottom left 

  .. image:: /intro/Basic/StrFunc/fn_remove.jpg

* In the Script Function window we see 

.. code-block::
    :linenos:

    ipStr = p1
    char2Strip = p2
    if(StrLen(char2Strip)=1) //check for single character
        idx = find(char2Strip,ipStr)
        while(idx != -1)
            ipStr = Substring(ipStr, 0, idx) + Substring(ipStr, idx+1,0)
            idx = find(char2Strip,ipStr)
        endwhile
    else
        ipStr = "Error: Parameter 2 has to be single character string."
    endif
    Return(ipStr)

* Line 3: Make sure that parameter 2 is single character. If not, return an error string at Line 10.
* Line 4: Using ``find`` to return the index of ``char2Strip`` within ``ipStr`` to ``idx``
* Line 6: Removing ``char2Strip`` based on ``idx``

.. _uplow:

up2low(p1)
##################
* Choose the user-defined function ``up2low(p1)`` at the bottom left 

  .. image:: /intro/Basic/StrFunc/fn_2lower.jpg

* In the Script Function window we see 

.. code-block::
    :linenos:

    //converts upper to lower case
    ipLen = StrLen(p1)
    nowChar = 0
    opStr = ""
    while( nowChar < ipLen  )
        ipChar = GetChar(p1,nowChar) //ASCII value
        if(ipChar>64 AND ipChar <91) //UPPER case ASCII
            opStr = opStr + char(ipChar+32)
        else
            opStr = opStr + char(ipChar)
        endif
        nowChar = nowChar + 1
    endwhile
    return(opStr)

* Line 2: Return the length of the input parameter string ``p1`` to ``ipLen``
* Lines 5-13: ``while`` loop for each character in ``p1``
* Line 6: Return the ASCII value of the current character to ``ipChar``
* Line 7: Check if the ``ipChar`` is UPPER CASE
* Line 8: Converts ``ipChar`` to lower case and append to ``opStr``
* Line 10: Do nothing for non-upper case ``ipChar`` and append to ``opStr``
* Line 12: Increament for ``while`` loop character counter

Running the solution
--------------------

* At the ``Run Solution`` |runsoln| page, click on ``Manual Trigger`` |manTrig| button
  
  .. image:: /intro/Basic/StrFunc/strFunc.jpg
   :width: 320pt
  
* Insepction of the ``Variable List`` the results for ``xInt`` , ``xFloat`` & ``xString`` can be seen.
 
  .. image:: /intro/Basic/StrFunc/varList.jpg

* Notice that the ``Result`` variable is ``Passed``, because the orginal "perfect" value of ``B2d`` was set to "*". However, the :ref:`last line <setperfect>` of ``Post Image Process`` sets the "perfect" string to some other values. Hence if we click on ``Manual Trigger`` |manTrig| button again, the ``Result`` variable becomes ``Rejected``.

  .. image:: /intro/Basic/StrFunc/varlist_reject.jpg

Appendix
-----------------

.. _stringformat:

String Formatting
##################

[``VariableName`` %{``width``} {. ``precision``} ``type``]. Items in {} are optional

* ``width`` 
  
  * Optional positive decimal, specifying minimum number of characters in the formatted text.
  * Padding is done if the number of characters is less than ``width``, by
    
    * 0 if ``width`` is prefixed with 0
    * space otherwise

* ``precision``  
  
  * For types ``d``, ``i``, ``u``, ``o``, ``x`` & ``X``: Minimum digits output, default = 1
    
    * If digits less than precision, pad on the left with 0
    * No truncation if precision is exceeded
  
  * For types ``e`` & ``E``: Number of digits after decimal point with rounding, default = 6
    
    * If ``precision``=0 or ``.`` appears without a number, no decimal is output
  
  * For type ``f``: Number of digits after decimal point 
    
    * If there is a decimal point, at least 1 digit is before it
    * The value is rounded to the specified number of digits
  
* ``type``
  
+------+-----------------------------------------------------------------------+
|Type  |Meaning                                                                |
+------+-----------------------------------------------------------------------+
|``c`` |character                                                              |
+------+-----------------------------------------------------------------------+
|``d`` |signed decimal                                                         |
+------+-----------------------------------------------------------------------+
|``i`` |signed integer                                                         |
+------+-----------------------------------------------------------------------+
|``u`` |unsigned decimal                                                       |
+------+-----------------------------------------------------------------------+
|``x`` |unsigned hex, in "abcdef"                                              |
+------+-----------------------------------------------------------------------+
|``X`` |unsigned hex, in "ABCDEF"                                              |
+------+-----------------------------------------------------------------------+
|``f`` |floating point in [–]dddd.dddd                                         |
|      |                                                                       |
|      |* dddd are some decimal digits                                         |
+------+-----------------------------------------------------------------------+
|``e`` |scientific format in exponential notation in [–]d.dddd e [sign]dd[d]   |
|      |                                                                       |
|      |* d is single decimal digit                                            |
|      |                                                                       |
|      |* dddd are some decimal digits                                         |
|      |                                                                       |
|      |* [sign] is ``+`` or ``-``                                             |
|      |                                                                       |
|      |* dd[d] is 2 or 3 decimal digits                                       |
+------+-----------------------------------------------------------------------+
|``g`` |Signed value in ``f`` or ``e`` format, whichever is more compact.      |
+------+-----------------------------------------------------------------------+
|``G`` |Identical to ``g``, except for ``E`` instead of ``e`` for exponent     |
+------+-----------------------------------------------------------------------+
|``s`` |Single-byte character string, printed up to                            |
|      |                                                                       |
|      |* first null character or                                              |
|      |                                                                       |
|      |* precision value is reached                                           |
+------+-----------------------------------------------------------------------+

* eg: Angle = 45.73
  
  * string("[Angle%5.1f]")  = " 45.4"
  * string("[Angle%05.1f]") = "045.4"
  * string("[Angle%5.1e]")  = "4.5e+001" 
  * string("[Angle%5.1g]")  = "5e+001"

.. tip::
  
  #string #upper-case #lower-case #remove #space #format #formatting 

.. |0| image:: /intro/Basic/StrFunc/0.jpg
   :width: 80pt

.. |1| image:: /intro/Basic/StrFunc/1.jpg
   :width: 50pt

.. |2| image:: /intro/Basic/StrFunc/2.jpg
   :width: 80pt

.. |3| image:: /intro/Basic/StrFunc/3.jpg
   :width: 100pt

.. |4| image:: /intro/Basic/StrFunc/4.jpg
   :width: 80pt

.. |5| image:: /intro/Basic/StrFunc/5.jpg
   :width: 100pt

.. |6| image:: /intro/Basic/StrFunc/6.jpg
   :width: 80pt

.. |7| image:: /intro/Basic/StrFunc/7.jpg
   :width: 100pt

.. |8| image:: /intro/Basic/StrFunc/8.jpg
   :width: 100pt

.. |9| image:: /intro/Basic/StrFunc/9.jpg
   :width: 150pt

.. |10| image:: /intro/Basic/StrFunc/10.jpg
   :width: 150pt

.. |11| image:: /intro/Basic/StrFunc/11.jpg
   :width: 150pt

.. |12| image:: /intro/Basic/StrFunc/12.jpg
   :width: 150pt

.. |13| image:: /intro/Basic/StrFunc/13.jpg
   :width: 150pt

.. |14| image:: /intro/Basic/StrFunc/14.jpg
   :width: 150pt

.. |15| image:: /intro/Basic/StrFunc/15.jpg
   :width: 150pt

.. |16| image:: /intro/Basic/StrFunc/16.jpg
   :width: 100pt

.. |17| image:: /intro/Basic/StrFunc/17.jpg
   :width: 150pt

.. |18| image:: /intro/Basic/StrFunc/18.jpg
   :width: 150pt

.. |19| image:: /intro/Basic/StrFunc/19.jpg
   :width: 150pt

.. |setmatch| replace:: ``SetMatchString``

.. |formatting| replace:: [VariableName%{width} {.precision} type]; Items in {} are optional  

