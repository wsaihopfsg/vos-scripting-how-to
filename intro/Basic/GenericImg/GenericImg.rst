:orphan:

.. _gpio:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Image Conversion from Any Source to VOS Emulator  
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This demonstrates how to convert a .jpg file into a .bmp format that can be read by the emulator.

.. note:: 
  The image canvas size is VOS model dependent 
  
  ===================== ===================== =======================
  Model                 Width in pixels (X)   Height in pixels (Y)
  VOS-1000              640                   480
  VOS-2000              1280                  960
  VOS-5000              2560                  1920
  ===================== ===================== =======================

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/GenericImg>`__
-------------------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``1.jpg``                         |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GenericImg/1.jpg?raw=true>`__ for conversion, taken from |
  |                                     |https://yic-assm.com/wp-content/uploads/2017/09/xray-pcb.jpg                                                                                        |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``1canvas.jpg``                   |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GenericImg/1canvas.jpg?raw=true>`__ after canvas resize  |
  |                                     |                                                                                                                                                    |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``1canvas.jpg.bmp``               |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/GenericImg/1canvas.jpg.bmp?raw=true>`__ after canvas     |
  |                                     |resize and format conversion                                                                                                                        |
  +-------------------------------------+----------------------------------------------------------------------------------------------------------------------------------------------------+

.. note::
  There may be multiple ways of making the conversion works, but this is the method that the author has been using

Steps
-----------------

.. note::
  The steps assume VOS-2000 is used in the emulator.

1. Open the image in ``Paint 3D``. You may have to download it if it is not already installed in your Windows system.
2. Click on ``Canvas``, and at ``Resize Canvas`` change the ``Width`` & ``Height`` to 1280px & 960px respectively. The result will be similar to ``1canvas.jpg``.

.. image:: /intro/Basic/GenericImg/resizecanvas.jpg

3. Run ``Image Prep`` |imageprep| and choose the ``source`` & ``destination`` folders and the ``Grayscale`` radio button, and press ``Start Conversion``. The result will be similar to ``1canvas.jpg.bmp``.

  .. |imageprep| image:: /intro/Basic/GenericImg/imageprep.jpg
    :width: 200px

  .. image:: /intro/Basic/GenericImg/imageprepscn.jpg


  .. note::
    All .jpg files in the ``source`` folder will be converted
  
  
.. Tip::
  #jpg #bmp #canvas #vos #emulator


