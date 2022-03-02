:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Glossary
===========

.. _tools:

Tools  
+++++++++++++++++
+-----------------------------------------------------------+------------------------------------------------+
|* |match|_                                                 |* Preprocessing                                 |
|                                                           |                                                |
|* :hoverxreftooltip:`Count <Glossary/Count:Count>`         |  * Convolve 3x3                                |
|                                                           |                                                |
|  * :doc:`/soln/RefCirSizeRect/RefCirSizeRect`             |  * Dilate                                      |
|  * :doc:`/soln/DefectDots/DefectDots`                     |                                                |
|  * :doc:`/soln/ROI/roi`                                   |  * |equalize|_                                 |
|  * :doc:`/soln/Scratch/Scratch`                           |                                                |
|                                                           |                                                |
|* Edge Count                                               |  * |erode|_                                    |
|                                                           |                                                |
|* |intensity|_                                             |  * Gaussian                                    |
|                                                           |                                                |
|* Caliper                                                  |  * High-pass (Sharpen)                         |
|                                                           |                                                |
|* Point                                                    |  * ``Invert``                                  |
|                                                           |                                                |
|* Tip                                                      |    * :doc:`soln/Scratch/Scratch`               |
|                                                           |    * :doc:`soln/DefectDots/DefectDots`         |
|* Pencil                                                   |                                                |
|                                                           |                                                |
|* |distance|_                                              |  * Low-pass (Blur)                             |
|                                                           |                                                |
|* |rake|_                                                  |  * Mask                                        |
|                                                           |                                                |
|* Contour                                                  |  * |median|_                                   |
|                                                           |                                                |
|* |angle|_                                                 |  * |normalize|_                                |
|                                                           |                                                |
|* Arc                                                      |  * Project H                                   |
|                                                           |                                                |
|* Circle                                                   |  * Project V                                   |
|                                                           |                                                |
|* Concentric                                               |  * ``Remove blobs``                            |
|                                                           |                                                |
|                                                           |    * :doc:`soln/Scratch/Scratch`               |
|                                                           |    * :doc:`soln/DefectDots/DefectDots`         |
|                                                           |                                                |
|* Graphics                                                 |  * Shear X                                     |
|                                                           |                                                |
|* ``Barcode``                                              |  * Shear Y                                     |
|                                                           |                                                |
|  * :doc:`soln/ROI/roi`                                    |  * Sobel                                       |
|  * :doc:`intro/Basic/StrFunc/StrFunc`                     |                                                |
|                                                           |                                                |
|* ``QR Code``                                              |  * Subtract                                    |
|                                                           |                                                |
|  * :doc:`soln/ROI/roi`                                    |  * |thres|_                                    |
|  * :doc:`intro/Basic/StrFunc/StrFunc`                     |                                                |
|                                                           |                                                |
|* OCR                                                      |  * ``Threshold (band)``                        |
|                                                           |                                                |
|                                                           |    * :doc:`soln/Scratch/Scratch`               |
|                                                           |    * :doc:`soln/DefectDots/DefectDots`         |
|                                                           |                                                |
|                                                           |                                                |
|* Verify                                                   |  * Thresh (adaptive)                           |
|                                                           |                                                |
|* Color Meter                                              |  * Zoom                                        |
|                                                           |                                                |
+-----------------------------------------------------------+------------------------------------------------+

.. |distance| replace:: ``Distance``
.. _distance: intro/Basic/MathFunc/MathFunc.html
.. |rake| replace:: ``Rake``
.. _rake: intro/Basic/MathFunc/MathFunc.html
.. |angle| replace:: ``Angle``
.. _angle: intro/Basic/MathFunc/MathFunc.html
.. |erode| replace:: ``Erode``
.. _erode: soln/Scratch/Scratch.html
.. |median| replace:: ``Median``
.. _median: soln/RefCirSizeRect/RefCirSizeRect.html
.. |normalize| replace:: ``Normalize``
.. _normalize: soln/Scratch/Scratch.html
.. |thres| replace:: ``Threshold``
.. _thres: soln/Scratch/Scratch.html
.. |match| replace:: ``Match``
.. _match: intro/Basic/GPIO/GPIO.html
.. |intensity| replace:: ``Intensity``
.. _intensity: intro/Basic/GPIO/GPIO.html
.. |equalize| replace:: ``Equalize``
.. _equalize: intro/Basic/GPIO/GPIO.html

Predefined Functions
++++++++++++++++++++++++

.. _maths:

Mathematical Functions
----------------------

+-----------------------------------------------+-----------------------------------------------+
|* |acos|_                                      |* GetBit                                       |  
|* |asin|_                                      |* |logn|_                                      |  
|* |atan|_                                      |* |pow|_                                       |
|* |atan2|_                                     |* SetBit                                       |
|* ClearBit                                     |* |sin|_                                       |
|* |cos|_                                       |* ``sqrt``                                     |
|                                               |                                               |
|                                               |  * :doc:`intro/Basic/MathFunc/MathFunc`       |
|                                               |  * :doc:`soln/RefCirSizeRect/RefCirSizeRect`  |
|                                               |                                               |
|* |exp|_                                       |* |tan|_                                       |
+-----------------------------------------------+-----------------------------------------------+

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


.. _strings:

String Functions
---------------------

+-------------------------------------------------------+-------------------------------------------------------+
|* ``char``                                             |* ``int``                                              |
|                                                       |                                                       |
|  *  :doc:`intro/Basic/StrFunc/StrFunc`                |  *  :doc:`intro/Basic/StrFunc/StrFunc`                | 
|  *  :doc:`soln/RefCirSizeRect/RefCirSizeRect`         |  *  :doc:`soln/RefCirSizeRect/RefCirSizeRect`         |
|                                                       |                                                       |
|* |find|_                                              |* |setchar|_                                           |
|                                                       |                                                       |
|* |float|_                                             |* |string|_                                            |
|                                                       |                                                       |
|* ``FormatString``                                     |* ``StrLen``                                           |
|                                                       |                                                       |
|  *  :doc:`intro/Basic/StrFunc/StrFunc`                |  * :doc:`intro/Basic/StrFunc/StrFunc`                 |
|  *  :doc:`soln/RefCirSizeRect/RefCirSizeRect`         |  * :doc:`soln/ROI/roi`                                |
|                                                       |                                                       |
|* |getchar|_                                           |* ``Substring``                                        |
|                                                       |                                                       |
|                                                       |  * :doc:`intro/Basic/StrFunc/StrFunc`                 |                                                
|                                                       |  * :doc:`soln/RefCirSizeRect/RefCirSizeRect`          |
|                                                       |                                                       |
|                                                       |                                                       |
+-------------------------------------------------------+-------------------------------------------------------+

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
  
  
.. _stats:

Statistical Functions
----------------------
* |getmean|_
* |getmin|_
* |getmax|_
* |getstddev|_
* |reqrelearn|_
* ResetVarStats

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


.. _attrs:

Attribute Functions
----------------------

+-----------------------------------------------+-----------------------------------------------+
|* DeleteVar                                    |* ReadVar                                      |
|* EnableFormat                                 |* |setmatchstr|_                               |
|* GetNthToolType                               |* |setparam|_                                  |
|* GetNumElements                               |* SetNthTolerances                             |
|* GetNthTolerances                             |* SetTolerances                                |
|* GetTolerances                                |* SetToolFill                                  |
|* GetToolName                                  |* SetToolPenColor                              |
|* GetToolResult                                |* SetToolText                                  |
|* GetToolType                                  |* Sort                                         |
|* GetToolValue                                 |* WriteVar                                     |
|* GetVarDimension                              |                                               |
+-----------------------------------------------+-----------------------------------------------+

.. |setmatchstr| replace:: ``SetMatchString``
.. _setmatchstr: intro/Basic/MathFunc/MathFunc.html
.. |setparam| replace:: ``SetParam``
.. _setparam: soln/ROI/roi.html
 
.. _ios:

IOs
----------------------

+-----------------------------------------------+-----------------------------------------------+
|* GetBrightness                                |* |retrigger|_                                 |
|* GetCamBrightness                             |* SetBrightness                                |
|* GetCamExposure                               |* SetCamBrightness                             |
|* GetContrast                                  |* SetCamExposure                               |
|* GetExposure                                  |* SetContrast                                  |
|* GetFrameTime                                 |* SetDisplayCam                                |
|* GetImageFileName                             |* SetExposure                                  |
|* GetNumCameras                                |* SetImageSource                               |
|* GetSrcCamID                                  |* SetStrobeEnable                              |
|* NewImageReady                                |* |trigger|_                                   |
|* Pulse                                        |* TriggerCam                                   |
|* QueueResult                                  |* TriggerSource                                |
+-----------------------------------------------+-----------------------------------------------+

.. |retrigger| replace:: ``ReTrigger``
.. _retrigger: soln/ROI/roi.html
.. |trigger| replace:: ``Trigger``
.. _trigger: soln/RefCirSizeRect/RefCirSizeRect.html


.. _logs:

Logger
----------------------

+-----------------------------------------------+-----------------------------------------------+
|* AppendFile                                   |* LogImage                                     |
|* DriveConnnect                                |* WriteImageFile                               |
|* GetFtpStatus                                 |* WriteImageTools                              |
|* LogStart                                     |* WriteHistoryImage                            |
|* LogStop                                      |                                               |
+-----------------------------------------------+-----------------------------------------------+

.. _comms:

Communication Functions
--------------------------

+-----------------------------------------------+-----------------------------------------------+
|* Disconnect                                   |* |rstr|_                                      |
|* GetKey                                       |* SendEmail                                    |
|* GetPortChar                                  |* SendEmailInfo                                |
|* GetPortString                                |* WriteBytes                                   |
|* IsConnected                                  |* |wformatstr|_                                |
|* PutPortString                                |* WriteString                                  |
|* ReadByte                                     |                                               |
+-----------------------------------------------+-----------------------------------------------+

.. |wformatstr| replace:: ``WriteFormatString``
.. _wformatstr: soln/RefCirSizeRect/RefCirSizeRect.html
.. |rstr| replace:: ``ReadString``
.. _rstr: soln/RefCirSizeRect/RefCirSizeRect.html

.. _sys:

System Functions
--------------------------

+-----------------------------------------------+-----------------------------------------------+
|* AutoSaveEnable                               |* Print                                        |
|* ChangeSolution                               |* ReadCell                                     |
|* ChangeStartupSolution                        |* RefreshExcel                                 |
|* Copy                                         |* ResetHistory                                 |
|* |delay|_                                     |* ResetStatistics                              |
|* FormatTime                                   |* ResetRejector                                |
|* GetColor                                     |* ``SetDisplayStatus``                         |
|                                               |                                               |
|                                               |  * :doc:`intro/Basic/StrFunc/StrFunc`         |
|                                               |  * :doc:`soln/DefectDots/DefectDots`          |
|                                               |  * :doc:`soln/RefCirSizeRect/RefCirSizeRect`  |
|                                               |  * :doc:`soln/ROI/roi`                        |
|                                               |  * :doc:`soln/Scratch/Scratch`                |
|                                               |                                               |
|* GetMaxInspectTime                            |* SetAppButton                                 |
|* GetMinInspectTime                            |* SetImageEncode                               |
|* GetPixel                                     |* StartInspect                                 |
|* GetSolutionID                                |* StopInspect                                  |
|* GetTime                                      |* SwitchingIsEnabled                           |
|* GetTimeString                                |* TimeMillisec                                 |
|* GetUserName                                  |* WriteCell                                    |
|* GetVersion                                   |* return                                       |
|                                               |                                               |
|                                               |  * :doc:`soln/RefCirSizeRect/RefCirSizeRect`  |
|                                               |  * :doc:`intro/Basic/StrFunc/StrFunc`         |
|                                               |  * :doc:`intro/Basic/MathFunc/MathFunc`       |
|                                               |                                               |
+-----------------------------------------------+-----------------------------------------------+
  

.. |delay| replace:: ``Delay``
.. _delay: soln/ROI/roi.html
