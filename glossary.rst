:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Glossary
===========

Tools  
+++++++++++++++++

* Count
  
  * :doc:<soln/DefectDots/DefectDots>

* some other tools
* ...

Predefined Functions
++++++++++++++++++++++++

Mathematical Functions
----------------------
* |acos|_  
* |asin|_  
* |atan|_
* |atan2|_
* ClearBit
* |cos|_  
* |exp|_  
* GetBit
* |logn|_
* |pow|_
* SetBit
* |sin|_
* |sqrt|_
* |tan|_

String Functions
---------------------
* ``char``

  *  :doc:`intro/Basic/StrFunc/StrFunc`
  *  :doc:`soln/RefCirSizeRect/RefCirSizeRect`

* |find|_

* |float|_

* ``FormatString``

  *  :doc:`intro/Basic/StrFunc/StrFunc`
  *  :doc:`soln/RefCirSizeRect/RefCirSizeRect`

* |getchar|_

* ``int``

  *  :doc:`intro/Basic/StrFunc/StrFunc`
  *  :doc:`soln/RefCirSizeRect/RefCirSizeRect`

* |setchar|_

* |string|_

* ``StrLen``

  * :doc:`intro/Basic/StrFunc/StrFunc`
  * :doc:`soln/ROI/roi`

* ``Substring``
  
  * :doc:`intro/Basic/StrFunc/StrFunc`
  * :doc:`soln/RefCirSizeRect/RefCirSizeRect`


Statistical Functions
----------------------
* |getmean|_
* |getmin|_
* |getmax|_
* |getstddev|_
* |reqrelearn|_
* ResetVarStats
  
Attribute Functions
----------------------
* DeleteVar
* EnableFormat
* GetNthToolType
* GetNumElements
* |setmatchstr|_
* SetNthTolerances
* GetNthTolerances
* GetTolerances
* GetToolName
* GetToolResult
* GetToolType
* GetToolValue
* GetVarDimension
* ReadVar
* |setparam|_
* SetTolerances
* SetToolFill
* SetToolPenColor
* SetToolText
* Sort
* WriteVar
 

IOs
----------------------
* GetBrightness
* GetCamBrightness
* GetCamExposure
* GetContrast
* GetExposure
* GetFrameTime
* GetImageFileName
* GetNumCameras
* GetSrcCamID
* NewImageReady
* Pulse
* QueueResult
* |retrigger|_
* SetBrightness
* SetCamBrightness
* SetCamExposure
* SetContrast
* SetDisplayCam
* SetExposure
* SetImageSource
* SetStrobeEnable
* |trigger|_
* TriggerCam
* TriggerSource


Logger
----------------------
* AppendFile
* DriveConnnect
* GetFtpStatus
* LogStart
* LogStop
* LogImage
* WriteImageFile
* WriteImageTools
* WriteHistoryImage

Communication Functions
--------------------------
* Disconnect
* GetKey
* GetPortChar
* GetPortString
* IsConnected
* PutPortString
* ReadByte
* |rstr|_
* SendEmail
* SendEmailInfo
* WriteBytes
* |wformatstr|_
* WriteString

System Functions
--------------------------
* AutoSaveEnable
* ChangeSolution
* ChangeStartupSolution
* Copy
* |delay|_
* FormatTime
* GetColor
* GetMaxInspectTime
* GetMinInspectTime
* GetPixel
* GetSolutionID
* GetTime
* GetTimeString
* GetUserName
* GetVersion
* Print
* ReadCell
* RefreshExcel
* ResetHistory
* ResetStatistics
* ResetRejector
* ``SetDisplayStatus``

  * :doc:`intro/Basic/StrFunc/StrFunc`
  * :doc:`soln/DefectDots/DefectDots`
  * :doc:`soln/RefCirSizeRect/RefCirSizeRect`
  * :doc:`soln/ROI/roi`
  * :doc:`soln/Scratch/Scratch`

* SetAppButton
* SetImageEncode
* StartInspect
* StopInspect
* SwitchingIsEnabled
* TimeMillisec
* WriteCell
* return
  * :doc:`soln/RefCirSizeRect/RefCirSizeRect`
  * :doc:`intro/Basic/StrFunc/StrFunc`
  * :doc:`intro/Basic/MathFunc/MathFunc`


.. |sin| replace:: ``sin``
.. _sin: intro/Basic/MathFunc/MathFunc.html
.. |cos| replace:: ``cos``
.. _cos: intro/Basic/MathFunc/MathFunc.html
.. |tan| replace:: ``tan``
.. _tan: intro/Basic/MathFunc/MathFunc.html
.. |asin| replace:: ``asin``
.. _asin: intro/Basic/MathFunc/MathFunc.html
.. |acos| replace:: ``acos``
.. _acos: intro/Basic/MathFunc/MathFunc.html
.. |atan| replace:: ``atan``
.. _atan: intro/Basic/MathFunc/MathFunc.html
.. |atan2| replace:: ``atan2``
.. _atan2: intro/Basic/MathFunc/MathFunc.html
.. |exp| replace:: ``exp``
.. _exp: intro/Basic/MathFunc/MathFunc.html
.. |logn| replace:: ``logn``
.. _logn: intro/Basic/MathFunc/MathFunc.html
.. |sqrt| replace:: ``sqrt``
.. _sqrt: intro/Basic/MathFunc/MathFunc.html
.. |pow| replace:: ``pow``
.. _pow: intro/Basic/MathFunc/MathFunc.html

.. |find| replace:: ``Find``
.. _find: intro/Basic/StrFunc/StrFunc.html
.. |getchar| replace:: ``GetChar``
.. _getchar: intro/Basic/StrFunc/StrFunc.html
.. |setchar| replace:: ``SetChar``
.. _setchar: intro/Basic/StrFunc/StrFunc.html
.. |float| replace:: ``float``
.. _float: intro/Basic/StrFunc/StrFunc.html
.. |string| replace:: ``string``
.. _string: intro/Basic/StrFunc/StrFunc.html

.. |getmean| replace:: ``GetMean``
.. _getmean: intro/Basic/MathFunc/MathFunc.html
.. |getstddev| replace:: ``GetStdDev``
.. _getstddev: intro/Basic/MathFunc/MathFunc.html
.. |getmin| replace:: ``GetMin``
.. _getmin: intro/Basic/MathFunc/MathFunc.html
.. |getmax| replace:: ``GetMax``
.. _getmax: intro/Basic/MathFunc/MathFunc.html
.. |reqrelearn| replace:: ``RequestRelearn``
.. _reqrelearn: intro/Basic/MathFunc/MathFunc.html

.. |setmatchstr| replace:: ``SetMatchString``
.. _setmatchstr: intro/Basic/MathFunc/MathFunc.html
.. |setparam| replace:: ``SetParam``
.. _setparam: soln/ROI/roi.html

.. |retrigger| replace:: ``ReTrigger``
.. _retrigger: soln/ROI/roi.html
.. |trigger| replace:: ``Trigger``
.. _trigger: soln/RefCirSizeRect/RefCirSizeRect.html

.. |wformatstr| replace:: ``WriteFormatString``
.. _wformatstr: soln/RefCirSizeRect/RefCirSizeRect.html
.. |rstr| replace:: ``ReadString``
.. _rstr: soln/RefCirSizeRect/RefCirSizeRect.html

.. |delay| replace:: ``Delay``
.. _delay: soln/ROI/roi.html
