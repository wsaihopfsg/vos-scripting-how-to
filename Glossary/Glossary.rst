:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Glossary
===========

.. _toolss:

Tools  
+++++++++++++++++

.. table::
   :class: wy-table-responsive table

   +-----------------------------------------------------------+--------------------------------------------------------+
   |* |match|_                                                 |* Preprocessing                                         |
   |                                                           |                                                        |
   |* :confval:`Count <Count>`                                 |  * Convolve 3x3                                        |
   |* |edgecount|_                                             |  * |dilate|_                                           |
   |* :confval:`Intensity <Intensity>`                         |  * |equalize|_                                         |
   |* Caliper                                                  |  * :confval:`Erode <Erode>`                            |
   |* Point                                                    |  * Gaussian                                            |
   |* Tip                                                      |  * High-pass (Sharpen)                                 |
   |* Pencil                                                   |  * :confval:`Invert <Invert>`                          |
   |* |distance|_                                              |  * Low-pass (Blur)                                     |
   |* |rake|_                                                  |  * Mask                                                |
   |* Contour                                                  |  * |median|_                                           |
   |* |angle|_                                                 |  * :confval:`Normalize`                                |
   |* Arc                                                      |  * Project H                                           |
   |* |circle|_                                                |  * Project V                                           |
   |* |concent|_                                               |  * :confval:`Remove blobs <Remove blobs>`              |
   |* Graphics                                                 |  * |shearx|_                                           |
   |* :confval:`Barcode <Barcode>`                             |  * |sheary|_                                           |
   |                                                           |  * Sobel                                               |
   |* :confval:`QR Code <QR Code>`                             |  * Subtract                                            |
   |                                                           |  * :confval:`Threshold <Threshold>`                    |
   |* :confval:`OCR <OCR>`                                     |  * :confval:`Threshold (band) <Threshold (band)>`      |
   |* Verify                                                   |  * Thresh (adaptive)                                   |
   |                                                           |  * Zoom                                                |
   +-----------------------------------------------------------+--------------------------------------------------------+

.. |circle| replace:: ``Circle``
.. _circle: ../intro/Advanced/FTP/FTP.html
.. |concent| replace:: ``Concentric Circles``
.. _concent: ../intro/Advanced/FTP/FTP.html
.. |distance| replace:: ``Distance``
.. _distance: ../intro/Basic/MathFunc/MathFunc.html
.. |rake| replace:: ``Rake``
.. _rake: ../intro/Basic/MathFunc/MathFunc.html
.. |angle| replace:: ``Angle``
.. _angle: ../intro/Basic/MathFunc/MathFunc.html
.. |dilate| replace:: ``Dilate``
.. _dilate: ../intro/Basic/GPIO/GPIO.html
.. |median| replace:: ``Median``
.. _median: ../soln/RefCirSizeRect/RefCirSizeRect.html
.. |normalize| replace:: ``Normalize``
.. _normalize: ../soln/Scratch/Scratch.html
.. .. |thres| replace:: ``Threshold``
.. .. _thres: ../soln/Scratch/Scratch.html
.. |match| replace:: ``Match``
.. _match: ../intro/Basic/GPIO/GPIO.html
.. |equalize| replace:: ``Equalize``
.. _equalize: ../intro/Basic/GPIO/GPIO.html
.. |shearx| replace:: ``Shear X``
.. _shearx: ../intro/Basic/OcrItalic/OcrItalic.html
.. |sheary| replace:: ``Shear Y``
.. _sheary: ../intro/Basic/OcrItalic/OcrItalic.html
.. |edgecount| replace:: ``Edge Count``
.. _edgecount: ../soln/Menkyo/Menkyo.html

Predefined Functions
++++++++++++++++++++++++

.. _maths:

Mathematical Functions
----------------------

.. table::
   :class: wy-table-responsive table

   +-----------------------------------------------+-----------------------------------------------+
   |* |acos|_                                      |* :confval:`GetBit <GetBit>`                   |  
   |* |asin|_                                      |* |logn|_                                      |  
   |* |atan|_                                      |* |pow|_                                       |
   |* |atan2|_                                     |* |setbit|_                                    |
   |* |clearbit|_                                  |* |sin|_                                       |
   |* |cos|_                                       |* :confval:`sqrt <sqrt>`                       |
   |* |exp|_                                       |* |tan|_                                       |
   +-----------------------------------------------+-----------------------------------------------+

.. |sin| replace:: ``sin``
.. _sin: ../intro/Basic/MathFunc/MathFunc.html
.. |cos| replace:: ``cos``
.. _cos: ../intro/Basic/MathFunc/MathFunc.html
.. |tan| replace:: ``tan``
.. _tan: ../intro/Basic/MathFunc/MathFunc.html
.. |asin| replace:: ``asin``
.. _asin: ../intro/Basic/MathFunc/MathFunc.html
.. |acos| replace:: ``acos``
.. _acos: ../intro/Basic/MathFunc/MathFunc.html
.. |atan| replace:: ``atan``
.. _atan: ../intro/Basic/MathFunc/MathFunc.html
.. |atan2| replace:: ``atan2``
.. _atan2: ../intro/Basic/MathFunc/MathFunc.html
.. |exp| replace:: ``exp``
.. _exp: ../intro/Basic/MathFunc/MathFunc.html
.. |logn| replace:: ``logn``
.. _logn: ../intro/Basic/MathFunc/MathFunc.html
.. |sqrt| replace:: ``sqrt``
.. _sqrt: ../intro/Basic/MathFunc/MathFunc.html
.. |pow| replace:: ``pow``
.. _pow: ../intro/Basic/MathFunc/MathFunc.html
.. |setbit| replace:: ``setbit``
.. _setbit: ../intro/Basic/GPIO/GPIO.html
.. |clearbit| replace:: ``clearbit``
.. _clearbit: ../intro/Basic/GPIO/GPIO.html


.. _strings:

String Functions
---------------------

.. table::
   :class: wy-table-responsive table

   +-------------------------------------------------------+-------------------------------------------------------+
   |* :confval:`char <char>`                               |* :confval:`int <int>`                                 |
   |                                                       |                                                       |
   |* :confval:`find`                                      |* |setchar|_                                           |
   |                                                       |                                                       |
   |* |float|_                                             |* |string|_                                            |
   |                                                       |                                                       |
   |* :confval:`FormatString <FormatString>`               |* :confval:`StrLen <StrLen>`                           |
   |                                                       |                                                       |
   |* |getchar|_                                           |* :confval:`Substring <Substring>`                     |
   |                                                       |                                                       |
   +-------------------------------------------------------+-------------------------------------------------------+

.. |find| replace:: ``Find``
.. _find: ../intro/Basic/StrFunc/StrFunc.html
.. |getchar| replace:: ``GetChar``
.. _getchar: ../intro/Basic/StrFunc/StrFunc.html
.. |setchar| replace:: ``SetChar``
.. _setchar: ../intro/Basic/StrFunc/StrFunc.html
.. |float| replace:: ``float``
.. _float: ../intro/Basic/StrFunc/StrFunc.html
.. |string| replace:: ``string``
.. _string: ../intro/Basic/StrFunc/StrFunc.html
  
  
.. _stats:

Statistical Functions
----------------------

.. table::
   :class: wy-table-responsive table

   +--------------------+--------------------+
   |* |getmean|_        |* |getstddev|_      |
   |* |getmin|_         |* |reqrelearn|_     |
   |* |getmax|_         |* ResetVarStats     |
   +--------------------+--------------------+

.. |getmean| replace:: ``GetMean``
.. _getmean: ../intro/Basic/MathFunc/MathFunc.html
.. |getstddev| replace:: ``GetStdDev``
.. _getstddev: ../intro/Basic/MathFunc/MathFunc.html
.. |getmin| replace:: ``GetMin``
.. _getmin: ../intro/Basic/MathFunc/MathFunc.html
.. |getmax| replace:: ``GetMax``
.. _getmax: ../intro/Basic/MathFunc/MathFunc.html
.. |reqrelearn| replace:: ``RequestRelearn``
.. _reqrelearn: ../intro/Basic/MathFunc/MathFunc.html


.. _attrs:

Attribute Functions
----------------------

.. table::
   :class: wy-table-responsive table

   +-----------------------------------------------+-----------------------------------------------+
   |* DeleteVar                                    |* |readvar|_                                   |
   |* EnableFormat                                 |* |setmatchstr|_                               |
   |* GetNthToolType                               |* |setparam|_                                  |
   |* GetNumElements                               |* SetNthTolerances                             |
   |* GetNthTolerances                             |* SetTolerances                                |
   |* GetTolerances                                |* SetToolFill                                  |
   |* GetToolName                                  |* SetToolPenColor                              |
   |* GetToolResult                                |* SetToolText                                  |
   |* GetToolType                                  |* Sort                                         |
   |* GetToolValue                                 |* |writevar|_                                  |
   |* GetVarDimension                              |                                               |
   +-----------------------------------------------+-----------------------------------------------+

.. |setmatchstr| replace:: ``SetMatchString``
.. _setmatchstr: ../intro/Basic/MathFunc/MathFunc.html
.. |setparam| replace:: ``SetParam``
.. _setparam: ../soln/ROI/roi.html
.. |readvar| replace:: `ReadVar`
.. _readvar: ../soln/Menkyo/Menkyo.html
.. |writevar| replace:: `WriteVar`
.. _writevar: ../soln/Menkyo/Menkyo.html   


.. _ios:

IOs
----------------------

.. table::
   :class: wy-table-responsive table

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
   |* |pulse|_                                     |* TriggerCam                                   |
   |* QueueResult                                  |* TriggerSource                                |
   +-----------------------------------------------+-----------------------------------------------+

.. |retrigger| replace:: ``ReTrigger``
.. _retrigger: ../soln/ROI/roi.html
.. |trigger| replace:: ``Trigger``
.. _trigger: ../soln/RefCirSizeRect/RefCirSizeRect.html
.. |pulse| replace:: ``Pulse``
.. _pulse: ../intro/Basic/GPIO/GPIO.html   

.. _logs:

Logger
----------------------

.. table::
   :class: wy-table-responsive table

   +-----------------------------------------------+-----------------------------------------------+
   |* AppendFile                                   |* |logimage|_                                  |
   |* DriveConnnect                                |* |writeimagefile|_                            |
   |* GetFtpStatus                                 |* |writeimagetool|_                            |
   |* |logstart|_                                  |* |writehistoryimage|_                         |
   |* |logstop|_                                   |                                               |
   +-----------------------------------------------+-----------------------------------------------+

.. |logstart| replace:: ``LogStart``
.. _logstart: ../intro/Basic/OcrItalic/OcrItalic.html   
.. |logstop| replace:: ``LogStop``
.. _logstop: ../intro/Basic/OcrItalic/OcrItalic.html
.. |logimage| replace:: ``LogImage``
.. _logimage: ../intro/Basic/OcrItalic/OcrItalic.html
.. |writeimagefile| replace:: ``WriteImageFile``
.. _writeimagefile: ../intro/Advanced/FTP/FTP.html
.. |writeimagetool| replace:: ``WriteImageTools``
.. _writeimagetool: ../intro/Advanced/FTP/FTP.html
.. |writehistoryimage| replace:: ``WriteHistoryImage``
.. _writehistoryimage: ../intro/Advanced/FTP/FTP.html

.. _comms:

Communication Functions
--------------------------

.. table::
   :class: wy-table-responsive table

   +-----------------------------------------------+-----------------------------------------------+
   |* Disconnect                                   |* |rstr|_                                      |
   |* GetKey                                       |* SendEmail                                    |
   |* GetPortChar                                  |* SendEmailInfo                                |
   |* GetPortString                                |* WriteBytes                                   |
   |* IsConnected                                  |* |wformatstr|_                                |
   |* PutPortString                                |* |writestring|_                               |
   |* ReadByte                                     |                                               |
   +-----------------------------------------------+-----------------------------------------------+

.. |wformatstr| replace:: ``WriteFormatString``
.. _wformatstr: ../intro/Advanced/MQTT/MQTT.html
.. |rstr| replace:: ``ReadString``
.. _rstr: ../soln/RefCirSizeRect/RefCirSizeRect.html
.. |writestring| replace:: ``WriteString``
.. _writestring: ../intro/Advanced/FTP/FTP.html

.. _sys:

System Functions
--------------------------

.. table::
   :class: wy-table-responsive table

   +-----------------------------------------------+-----------------------------------------------+
   |* AutoSaveEnable                               |* Print                                        |
   |* |changesoln|_                                |* ReadCell                                     |
   |* ChangeStartupSolution                        |* RefreshExcel                                 |
   |* Copy                                         |* ResetHistory                                 |
   |* |delay|_                                     |* ResetStatistics                              |
   |* FormatTime                                   |* ResetRejector                                |
   |* GetColor                                     |* :confval:`SetDisplayStatus<SetDisplayStatus>`|
   |* GetMaxInspectTime                            |* SetAppButton                                 |
   |* GetMinInspectTime                            |* SetImageEncode                               |
   |* GetPixel                                     |* StartInspect                                 |
   |* GetSolutionID                                |* StopInspect                                  |
   |* GetTime                                      |* SwitchingIsEnabled                           |
   |* GetTimeString                                |* TimeMillisec                                 |
   |* GetUserName                                  |* WriteCell                                    |
   |* GetVersion                                   |* :confval:`Return <Return>`                   |
   +-----------------------------------------------+-----------------------------------------------+
  

.. |delay| replace:: ``Delay``
.. _delay: ../soln/ROI/roi.html

.. |changesoln| replace:: ``ChangeSolution``
.. _changesoln: ../intro/Advanced/SolnSwitch/SolnSwitch.html