:orphan:

.. _strfunc:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

String Manipulations
++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Reading a QR Code 
2. Built-in string functions; all indices are zero-based
   
   * ``Find`` (*substring*, *inString*) - Returns the first occurance of *substring* within *inString*; -1 if not found
   * ``Substring`` (*string*, *startIndex*, *length*) - Returns a substring from *stratIndex* for *length* characters; *length* =0 for the end of string
   * ``StrLen`` (*string*) - Returns how many characters are in *string*
   * ``GetChar`` (*string*, *index*) - Returns the ASCII code of a character at *index* of *string*
   * ``SetChar`` (*string*, *index*, *char*) - Replaces the character at *index* with *char* within *string*. Note *string* itself is modified. 
   * ``char`` (*int*) - Returns a character from the input ASCII *int* value
   * ``int`` (*string*) - Returns an integer after conversion of the input *string*
   * ``float`` (*string*) - Returns a floating point number after conversion of the input *string*
   * ``string`` (*inputNum*) - Returns a string based on the input number. *inputNum* can be an integer or float. Formatting for float please refer to ``FormatString`` below
   * ``FormatString`` (*stringForm*) - Returns a formatted string using *stringForm*

     * [*VariableName* %{width} {.precision} type ] Example: [myFloat%3.4f]
  
       * Items in {} are optional
  
     * Type
  
       * *c* : character
       * *d* : signed decimal
       * *i* : signed integer
       * *u* : unsigned decimal
       * *x* : unsigned hex, in "abcdef"
       * *X* : unsigned hex, in "ABCDEF"
       * *f* : floating point in [–]dddd.dddd 
  
         * dddd are some decimal digits
  
       * *e* : scientific format in exponential notation in [–]d.dddd e [sign]dd[d]

         * d is single decimal digit
         * dddd are some decimal digits
         * [sign] is ``+`` or ``-``
         * dd[d] is 2 or 3 decimal digits
   
  
`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/StrFunc>`__
---------------------------------------------------------------------------------------------------------

1. ``strFunc.bin``: `The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/StrFunc/strFunc.bin?raw=true>`__

   * At the Solution Setup page |solnsetup|, import |import| the solution 
  
2. ``vosrox.bmp``: `The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/StrFunc/vosrox.bmp?raw=true>`__ with a rotated QR code

   * At the Sensor Setup page |sensorsetup|, set |demoimg| to the folder where ``vosrox.bmp`` have been saved 

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

* Line 1: Calls a user-defined function :ref:`removeChar <removechar>` to remove ``char(32)`` (white-space) from ``B2d``
* Line 2: Calls a user-defined function :ref:`up2low <uplow>` to convert all characters in ``B2d`` to lower-case
* Line 4: Formats ``Angle`` to 4 decimal places and returns it to ``opStrAngle4f``
* Line 5: Replaces the last character of ``opStrAngle4f`` with ``Char(176)``
* Lines 7-9: Demonstration of ``int``, ``float``, ``string`` functions respectively

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
  
* Insepction of the ``Variable List`` the results for ``xInt ``, ``xFloat`` & ``xString`` can be seen.
 
  .. image:: /intro/Basic/StrFunc/varList.jpg

#string #upper-case #lower-case #remove #space
