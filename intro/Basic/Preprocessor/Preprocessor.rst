:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

Preprocessors in Image Processing 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

This sample demonstrates

1. Use of ``Preprocessor`` tool |preprocessortool|
  
  * Low pass 
  * High pass 
  * Gaussian 
  * Median
  * Mask
  * Project H
  * Project V
  * Convolve 3x3
  * Subtract
  * Invert
  * Sobel
  
`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Basic/Proprocessor>`__
---------------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``solution14.bin``                |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Preprocessor/solution14.bin?raw=true>`__                 |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir1| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``many.bmp``                      |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Basic/Preprocessor/many.bmp?raw=true>`__                          |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where ``many.bmp`` have been saved                                                                                                                   |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| until ``many.bmp`` is loaded. 

  .. image:: /intro/Basic/Preprocessor/preoverview1.jpg

  * ``many.bmp`` is made up of these 2 images
  
  =============== ===============
  |gimzua|        |tsq|
  =============== ===============

  .. |gimzua| image:: /intro/Basic/Preprocessor/gimzua.png
    :width: 300px
  .. |tsq| image:: /intro/Basic/Preprocessor/tsq.jpg  
    :width: 300px

* 13 ``Preprocessor`` tools |preprocessortool| have been used on various parts of the image. The properties for each is shown here.
  
  =================== =================== =================== ===================
  ↓ ``Pre2``          ↓ ``Pre3``          ↓ ``Pre4``          ↓ ``Pre5`` 
  ------------------- ------------------- ------------------- -------------------
  |pre2|              |pre3|              |pre4|              |pre5|
  ------------------- ------------------- ------------------- -------------------
  ↓ ``Pre6``          ↓ ``Pre9``          ↓ ``Pre10``             
  ------------------- ------------------- ------------------- -------------------
  |pre6|              |pre9|              |pre10|              
  ------------------- ------------------- ------------------- -------------------
  ↓ ``Pre7``                              ↓ ``Pre8``             
  --------------------------------------- ---------------------------------------
  |pre7|                                  |pre8|              
  --------------------------------------- ---------------------------------------
  ↓ ``Pre``
  -------------------------------------------------------------------------------
  |pre|
  -------------------------------------------------------------------------------
  ↓ ``Pre1``
  -------------------------------------------------------------------------------
  |pre1|
  -------------------------------------------------------------------------------
  ↓ ``Pre12``
  -------------------------------------------------------------------------------
  |pre12|
  -------------------------------------------------------------------------------
  ↓ ``Pre11``
  -------------------------------------------------------------------------------
  |pre11|
  ===============================================================================

  .. |pre| image:: /intro/Basic/Preprocessor/preprop.jpg
  .. |pre1| image:: /intro/Basic/Preprocessor/pre1prop.jpg
  .. |pre2| image:: /intro/Basic/Preprocessor/pre2propA.jpg  
  .. |pre3| image:: /intro/Basic/Preprocessor/pre3propA.jpg
  .. |pre4| image:: /intro/Basic/Preprocessor/pre4prop.jpg
  .. |pre5| image:: /intro/Basic/Preprocessor/pre5prop.jpg
  .. |pre6| image:: /intro/Basic/Preprocessor/pre6propB.jpg
  .. |pre7| image:: /intro/Basic/Preprocessor/pre7propB.jpg
  .. |pre8| image:: /intro/Basic/Preprocessor/pre8propB.jpg
  .. |pre9| image:: /intro/Basic/Preprocessor/pre9prop.jpg
  .. |pre10| image:: /intro/Basic/Preprocessor/pre10prop.jpg
  .. |pre11| image:: /intro/Basic/Preprocessor/pre11prop.jpg
  .. |pre12| image:: /intro/Basic/Preprocessor/pre12prop.jpg

* A ``Count`` tool just to make this solution runnable. It does not serve any useful purpose. 

Code Walk-Through
-----------------
* There is no scripting involved in this solution

Running the solution
--------------------

* At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` |runsoln| |cir1|, click on ``Manual Trigger`` |manTrig| button |cir2|. 

* The box with ``Pre2`` & ``Pre3``
  
  .. image:: /intro/Basic/Preprocessor/results23a.jpg

  * Both ``Low-pass`` (``Pre2``) & ``Gaussian`` (``Pre3``) are low-pass filters that is able to remove noise by blurring
    
    * ``Low-pass`` (``Pre2``) blurs out noise and edges 
    * ``Gaussian`` (``Pre3``) blurs out noise but is able to retain edges better than ``Low-pass``

.. Note::
  * White noise exists in all frequencies
  * Edges are sudden changes in intensity values and hence exist as high frequencies
  * ``Low-pass`` filter allows low frequency contents to pass and block high frequencies
    
    * Therefore ``Low-pass`` filter helps to reduce noise but also blurs edges 
  
  * ``Gaussian`` filter does not have a sharp cut-off frequency like ``Low-pass`` which cuts off all high-frequency contents abruptly.
  
    * Hence ``Gaussian`` is better suited to remove noise while preserving edges
  
  | `(Reference) <https://www.researchgate.net/post/What_is_meant_by_stating_that_edges_in_an_image_correspond_to_high_spatial_frequencies>`__
      
* The box with ``Pre4`` & ``Pre5``
  
  .. image:: /intro/Basic/Preprocessor/results45.jpg

  * Both ``High-pass`` (``Pre4``) & ``Sobel`` (``Pre5``) are able to detect edges.
  
    * ``Sobel`` is explicitly designed as an edge detector and eliminates low frequency contents by turning those pixels black. It does not enhance the image
    * ``High-pass`` filter does the exact opposite to its ``Low-pass`` counterparts
      
      * Let high frequency contents pass and filter out low frequencies
      * Enhances details, including noise 
    
    | `(Reference) <https://dsp.stackexchange.com/questions/55149/is-the-sobel-filter-a-high-pass-filter-and-if-not-what-is-the-difference-betwe>`__

  .. note::
    The ``High-pass`` filter implemented in VOS is different from what is `commonly used in image processing <https://cdn.diffractionlimited.com/help/maximdl/High-Pass_Filtering.htm>`__.

* The box with ``Pre6`` , ``Pre7`` & ``Pre5`` demonstrates the use of ``Mask``
  
  .. image:: /intro/Basic/Preprocessor/results678B.jpg

  * ``Pre6`` simply turns the grayscale image to binary using ``Threshold (adaptive)``, in which black pixels are 0s & white pixels are 1s. The ``mask`` uses these 0s and 1s to decide whether to replce this value.
  * ``Pre7`` fills all the 0s with the ``Fill value`` of 200, due to ``Invert`` being 1
  * ``Pre8`` fills all the 1s with the ``Fill value`` of 200, due to ``Invert`` being 0

  .. note::
    ``Threshold (adaptive)`` is used to create a binary image sensitive to lighting changes or reflection. For each pixel, a mean value is calculated around its ``Width`` x ``Height``. The amount ``Level`` is added to that mean to obtain the binary threshold. ``Level`` can be negative.

.. note::
  The pixels that are not replced by ``mask`` retain their original intensity values

* The box with ``Pre9`` & ``Pre10`` demonstrates the use of ``Project H`` & ``Project V``

  .. image:: /intro/Basic/Preprocessor/results9A.jpg
  
  * ``Project H`` sums all pixels row-wise and normalize it between 0 to 255. Each pixel in that horizontal is replaced with that normalized sum. That's why the rows with the white part has a lower intensity.
  * ``Project V`` sums all pixels column-wise and normalize it between 0 to 255. Each pixel in that vertical is replaced with that normalized sum. That's why the columns with the white part has a lower intensity.
  
  .. warning::
    If your image has rotation, even though your ``Project H`` or ``Project V`` is anchored to some locator that resolves rotation, the vertical or horizontal average computation is still with respect to the camera's x- y- axes.
  
* The box with ``Pre`` & ``Pre1`` demonstrates `unsharp masking <https://www.idtools.com.au/unsharp-masking-with-python-and-opencv/>`__

  .. code-block::
    :linenos:
  
    sharp_image = image - a * Laplacian(image)

  .. image:: /intro/Basic/Preprocessor/results01.jpg
  
  * For the preprocessor ``Pre``
    
    * For Laplacian in this image we have chosen |mask1|, which is in the first ``Convolve 3x3`` preprocessor of ``Pre``
    * The second ``Convolve 3x3`` preprocessor of ``Pre`` realizes the multiplication of the constant ``a``. In this case, ``a=1``.
    * The third ``Subtract`` preprocessor of ``Pre`` subtracts the pixel intensity in the runtime image from the original image.
    * The forth ``Invert`` preprocessor of ``Pre`` inverts the pixels.
    * The effect is that a sharpened image as seen in the image above.
  
    .. |mask1| image:: /intro/Basic/Preprocessor/mask1.gif
  
  * The preprocessor ``Pre1`` is identical to ``Pre`` except for a ``Median`` filter as the first preprocessor.
    
    * We see that the sharpened image in ``Pre1`` is has less artefacts than ``Pre``

* The box with ``Pre11`` & ``Pre12`` demonstrates the same unsharp masking effect with a different Laplacian kernel |mask2|.

  * It can be seen that the sharpening effect is less than ``Pre`` & ``Pre1``. This is evident from the Laplacian kernels chosen.
  
  .. image:: /intro/Basic/Preprocessor/resultsBC.jpg

  .. |mask2| image:: /intro/Basic/Preprocessor/mask2.gif

.. note:: 
  Please refer to other resources `such as this <https://setosa.io/ev/image-kernels/>`__ for an introduction to kernels in image processing

.. note:: 
  The ``Convolve 3x3`` preprocessor is populated row-wise; hence the first 3 values correspond to the first row, next 3 values to the centre row and the last 3 values are the last row. 
  
  The final results from the convolution should be kept between 0-255. This can be achieved by
  
  * Ensure the sum of coefficients is either 0 or 1 or
  * Ensure the sum of the coefficients divided by the divider is between 0-1
  
.. Tip::
  #preprocessor #project #horizontal #vertical #convolve #3x3 #high-pass #low-pass #sobel #subtract #gaussian #median #mask #invert

