:orphan:

.. toctree::

.. include:: /shared/EmulatorComponents.rst

VOS integration with ROS motion planning in a virtual UR5 cobot
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

.. note::
  Code has been developed with ``ROS Melodic`` in ``Ubuntu 18.04``. No guarantee that it will work with other ROS distros. 

1. VOS sends ``x``, ``y`` , ``rotation`` data to ROS vision node through TCP 
2. ROS vision node publishes the received data to a ROS topic
3. Object location shows in RViz as a marker  
4. Virtual robot performs path planning and executes "pick"

`Folder Contents <https://github.com/wsaihopfsg/vos-scripting-how-to/tree/master/code/Advanced/ROS>`__
-----------------------------------------------------------------------------------------------------------

.. table::
  :class: tight-table 

  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |1. ``VosRos.bin``                    |`The solution file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/ROS/VosRos.bin?raw=true>`__                           |
  |                                     |                                                                                                                                                       |
  |                                     |* At the :hoverxreftooltip:`Solution Setup page <intro/Basic/Hover/solnsetup:Solution Setup>` |solnsetup| |cir1| , import |import| |cir2| the solution |  
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |2. ``fake_ar_publisher.cpp``         |`The ROS node file in C++ <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/ROS/fake_ar_publisher.cpp?raw=true>`__         |  
  |                                     |which performs image triggering and data reception from VOS. It publishes the received data to a ROS topic.                                            |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |3. ``workcellex22.launch``           |`A ROS launch file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/ROS/workcellex22.launch?raw=true>`__                  |  
  |                                     |with IP address & port information to connect to the VOS TCP server.                                                                                   |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+
  |4. ``topright.bmp``                  |`The image file <https://github.com/wsaihopfsg/vos-scripting-how-to/blob/master/code/Advanced/ROS/topright.bmp?raw=true>`__                            |  
  |                                     |is an image with a rotated QR code on the top right-hand corner, which acts as the image captured by a software trigger.                               |
  |                                     |                                                                                                                                                       |   
  |                                     |* At the :hoverxreftooltip:`Sensor Setup page <intro/Basic/Hover/sensorsetup:Sensor Setup>` |sensorsetup| |cir1|,                                      |
  |                                     |                                                                                                                                                       |
  |                                     |  set |demoimg| |cir2| to the folder                                                                                                                   |
  |                                     |                                                                                                                                                       |
  |                                     |  where ``topright.bmp`` has been saved                                                                                                                |
  +-------------------------------------+-------------------------------------------------------------------------------------------------------------------------------------------------------+

.. note::
  Most of the code is identical to `ROS Industrial (Melodic) Training Exercises <https://industrial-training-master.readthedocs.io/en/melodic/>`__ until `Exercise 4.0 <https://industrial-training-master.readthedocs.io/en/melodic/_source/session4/Motion-Planning-CPP.html>`__ , except for the the 2 files included here. ``fake_ar_publisher.cpp`` should replace the file of the same name in the ``./src/fake_ar_publisher/`` folder, while ``workcellex22.launch`` should be copied to ``./src/myworkcell_support/launch`` folder. All the other files have to be present otherwise the ``catkin build`` will fail.

Scene
-----------------

* The virtual table is 1m by 1m, with the ``World Frame`` located at the its centre, 0.5m below the table
* The robot ``Base Frame`` is also located in the moddle of the table, and hence at (0,0,0.5) with respect to ``World Frame``
* The ``Camera Frame`` is located (-0.25, -0.5, 1.25) with respect to the ``World Frame``, with a 180 degree rotation applied along its y-axis since the camera is pointing down.
* When viewed from the y-axis, the scene looks something like this in ``RViz``  
  
  .. image:: /intro/Advanced/ROS/y0.jpg

* And when viewed from the top, the scene looks something like this in ``RViz`` 
  
  .. image:: /intro/Advanced/ROS/top.jpg

.. note:: 
  The (x,y,z) axes are represented by (red, green, blue) respectively. The length of each axis = 0.3m in the above screen-caps.

.. note::
  Due to the 180 degress rotation of the y-axis in ``Camera Frame``, its x- & z-axes are pointing in opposite direction from the ``World Frames``
  
  |world2camy| |world2camz|

.. |world2camy| image:: /intro/Advanced/ROS/world_to_cam_y.jpg
  :width: 310px
.. |world2camz| image:: /intro/Advanced/ROS/world_to_cam_z.jpg
  :width: 300px

Tools Explanation
-----------------
* At the :hoverxreftooltip:`Tool Setup page <intro/Basic/Hover/toolsetup:Tool Setup>` |toolsetup| |cir1|, click on |takepic| |cir2| so that ``topright.bmp`` is loaded. 
* Only a ``2D Barcode`` tool named ``B2d`` is used with the region-of-interest (ROI) set to a 960 pixels by 960 pixels square which corresponds to the table in the virtual scene.
  
  * The ``Angle`` property named ``Angle`` is enabled to obtained the angle of rotation of the QR code.
  * The co-ordinates of centre of the QR code is output as ``PX`` & ``PY`` in pixels

Connections
-----------
* Click on :hoverxreftooltip:`Setup Connections <intro/Basic/Hover/setupconntcp:Setup Connections>` |conn| |cir1|. We are using the ``VOS emulator`` as a ``TCP socket server`` at ``port 58888`` with the name ``TcpP58888``.  

.. image:: /intro/Advanced/ROS/tcp58888.jpg

.. warning:: 
  Firewalls / anti-virus may block incoming connections to your socket server. 

VOS Code Walk-Through
----------------------

* Click on :hoverxreftooltip:`Edit Script <intro/Basic/Hover/editscript:Edit Script>` |edit| |cir1|  

Pre Image Process
#####################
* Choose the predefined function ``Pre Image Process`` at the bottom left 

  |fn_pre|

* In the Script Function window we see

.. code-block::
  :linenos:

  socketPubInit = 40 //only triggered at even count
  spamSocket = 0 //coordinates not ready, do not spam
  socketPub = socketPubInit
  exTrigEn = 1 //external trigger enable

* Line 1: Initialization for a count-down counter
* Line 2: Flag indicating whether to transmit the ``x`` , ``y`` , ``rotation`` information to the socket client
* Line 3: Actual count-down counter. Note that information is only to the socket client at even counts
* Line 4: Turn external trigger on (1) or off (0)

Periodic: 200ms
#####################
* Choose the predefined function ``Periodic: 200ms`` at the bottom left 

  |fn_periodic|

* In the Script Function window we see

.. code-block::
  :linenos:

  if(exTrigEn=1) 
      ReadBuffer = ReadString( TcpP58888, 13 )
      if(ReadBuffer!= "") // if NOT an empty data string
          //WriteString(TcpP58888, "ReadBuffer=" + ReadBuffer)
          CommandString = ReadBuffer
          CommandCharacter = Substring(CommandString, 0, 1)
          if(CommandCharacter="T") 
              trigger()
              exTrigEn = 0 //only trigger once
          endif
      endif
  endif
  if( spamSocket = 1) 
      if(GetBit(socketPub,0)=0) //even
          //WriteString(TcpP8080, string(socketPub) + ":" + socketStr )
          WriteString(TcpP58888, socketStr )
      endif
      socketPub = socketPub - 1
      if(socketPub < 0) //finished spamming, reset
          socketPub = socketPubInit
          spamSocket = 0
      endif
  endif

exTrigEn=1 Branch 
^^^^^^^^^^^^^^^^^^

.. note::
  VOS checks for external trigger signal here by the ROS script :ref:`fake_ar_publisher.cpp <manualTrigger>`. Trigger will only be activated once.

* Lines 1-12: Branch for external trigger enabled
* Line 2: Read from socket until carrier return character (ASCII 13) to ``ReadBuffer``
* Lines 3-11: if ``ReadBuffer`` is not empty
* Line 6: Obtain the first character to ``CommandCharacter``
* Line 7-10: if ``CommandCharacter`` is ``T``
* Line 8: Invoke trigger in VOS
* Line 9: Turn ``exTrigEn`` off

spamSocket=1 Branch
^^^^^^^^^^^^^^^^^^^^^^^^

.. note::
  VOS outputting data to socket here. The same data will be sent every 400ms for a total of 8 seconds.

* Lines 13-23: The flag ``spamSocket=1`` signifies that post image processing has completed
* Line 14-17: If count-down counter ``socketPub`` is even, which eventually makes the output interval to 2x200ms = 400ms. With ``socketPub`` initialized to 40, it means the values will be sent through the socket 20 times.
* Line 16: Write ``socketStr`` to socket
* Line 18: Decrement counter. 
* Lines 19-22: Reset ``socketPub`` & ``spamSocket``

Post Image Process
#####################
* Choose the predefined function ``Post Image Process`` at the bottom left 

  |fn_post|

* In the Script Function window we see

.. code-block::
  :linenos:

  PXX = 0.25 - PY/960
  PYY = PX/960
  socketStr = FormatString("[PXX%.4f]") + "," + FormatString("[PYY%.4f]") + "," + FormatString("[Angle%.4f]") + "\n"
  SetDisplayStatus(socketStr,"darkgreen")
  //WriteString(TcpP8080,socketStr)
  spamSocket = 1

* Line 1: Conversion of pixels ``PY`` to x-coordinate ``PXX`` with the offset due to the camera axis.
* Line 2: Conversion of pixels ``PX`` to y-coordinate ``PYY``
* Line 3: Formatting the ``x`` , ``y`` & ``rotation`` value to 4 decimal places
* Line 6: Set the ``spamSocket`` flag to inform ``Periodic: 200ms`` that post image process has finished and data is ready to be sent

ROS Code 
-----------

fake_ar_publisher.cpp
##########################################

.. code-block::
  :linenos:

  #include <ros/ros.h>
  #include <fake_ar_publisher/ARMarker.h>
  #include <visualization_msgs/Marker.h>
  #include <sys/socket.h> 
  #define PI 3.141592654 
  #include<arpa/inet.h>	
  #include <math.h>
  //#include<iostream>
  //#include<string>
  using namespace std;

  ros::Publisher ar_pub;
  ros::Publisher visual_pub;
  int sock = 0, valread=0, sockStatus=-1;
  std::string SockAddr, SockPortStr;
  char buffer[1024] = { 0 };

  static std::string& camera_frame_name()
  {
    static std::string camera_frame;
    return camera_frame;
  } 

  // Singleton Instance of Object Position
  static geometry_msgs::Pose& pose()
  {
    static geometry_msgs::Pose pose;
    return pose;
  }

  int mySockClient()
  { //https://www.geeksforgeeks.org/socket-programming-cc/
    struct sockaddr_in serv_addr;
    std::string hello = "T\r";
    if ((sock = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
        ROS_ERROR("\n Socket creation error \n");
        return -1;
    } else {
      ROS_INFO("Socket OK");
    }
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_port = htons((short)stoi(SockPortStr.c_str()));
    serv_addr.sin_addr.s_addr = inet_addr(SockAddr.c_str()); // https://answers.ros.org/question/49042/cannot-ouput-string-service-via-ros_info/
  
    if (connect(sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr))< 0) {
          ROS_ERROR("\nConnection Failed \n");
          return -1;
    }else {
      ROS_INFO("Connect OK");
      send(sock, hello.c_str(), strlen(hello.c_str()), 0); //https://www.geeksforgeeks.org/socket-programming-cc/
    }
    return 0;
  }

  // Given a marker w/ pose data, publish an RViz visualization
  // You'll need to add a "Marker" visualizer in RVIZ AND define
  // the "camera_frame" TF frame somewhere to see it.
  static void pubVisualMarker(const fake_ar_publisher::ARMarker& m)
  {
    const double width = 0.08;
    const double thickness = 0.005;
  
    visualization_msgs::Marker marker;
    marker.header.frame_id = m.header.frame_id;
    marker.header.stamp = ros::Time::now();
    marker.ns = "ar_marker_visual";
    marker.id = 0;
    marker.type = visualization_msgs::Marker::CUBE;
    marker.action = visualization_msgs::Marker::ADD;
    marker.pose = m.pose.pose;
    marker.pose.position.z -= thickness / 2.0;
    marker.scale.x = width;
    marker.scale.y = width;
    marker.scale.z = thickness;
    marker.color.a = 1.0;
    marker.color.b = 1.0;
  
    visual_pub.publish(marker);
  }

  void pubCallback(const ros::TimerEvent&)
  {
    char * pch;
  
    fake_ar_publisher::ARMarker m;
    m.header.frame_id = camera_frame_name();
    m.header.stamp = ros::Time::now();
    /*pose().position.x = 0.0;
    pose().position.y = 0.0;*/
  
    if (sockStatus==0){
      valread = read(sock, buffer, 1024);
      //ROS_INFO("%s",buffer);
      pch = strtok(buffer,",");
      //while (pch != NULL){
      for (int i=0;i<3;i++){
        switch (i){
        case 0: //x
          pose().position.x = stof(pch); 
          ROS_INFO("x=%s",pch);
          break;
        case 1: //y
          pose().position.y = stof(pch);
          ROS_INFO("y=%s",pch);
          break;
        case 2: //do nothing for angle except for querternion https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
          float angleInRad = stof(pch)/180 * PI;
          pose().orientation.x = 0.0;
          pose().orientation.y = 0.0;
          pose().orientation.z = sin(angleInRad/2);
          pose().orientation.w = cos(angleInRad/2);
          ROS_INFO("r=%s",pch);
          break; 
        }
        pch = strtok (NULL,",");
      }
    } 
    geometry_msgs::Pose p = pose();
    m.pose.pose = p;
    ROS_INFO("x=%.2f, y=%.2f",p.position.x,p.position.y);
    ar_pub.publish(m);
    pubVisualMarker(m); // visualize the marker
  }

  int main(int argc, char **argv)
  {
    SockAddr =  argv[1];
    SockPortStr = argv[2];
    // Set up ROS.
    ros::init(argc, argv, "fake_ar_publisher");
    ros::NodeHandle nh, pnh ("~");
    ar_pub = nh.advertise<fake_ar_publisher::ARMarker>("ar_pose_marker", 1);
    visual_pub = nh.advertise<visualization_msgs::Marker>("ar_pose_visual", 1);

    sockStatus=mySockClient();

    // init pose
    pose().orientation.w = 1.0; // facing straight up
    pnh.param<double>("x_pos", pose().position.x, -0.6);
    pnh.param<double>("y_pos", pose().position.y, 0.2);
    pnh.param<double>("z_pos", pose().position.z, 0.5);
  
    pnh.param<std::string>("camera_frame", camera_frame_name(), "camera_frame");

    ROS_INFO("Starting simulated ARMarker publisher");  
    ROS_INFO("ip=%s:%s",SockAddr.c_str(), SockPortStr.c_str()); 
    ros::Timer t = nh.createTimer(ros::Duration(0.5), pubCallback, false, true);
    ros::spin();
  }

Initialization
^^^^^^^^^^^^^^^^^

* Line 12: ROS topic publish
* Line 13: Marker visualization publish
* Line 14: 

  - ``sock`` stores the status of the socket creation
  - ``valread`` stores the value from reading the socket
  - ``sockStatus`` stores the return status from ``mySockClient()``

* Line 15: The IP address and port as obtained from command-line input argument to ``SockAddr`` & ``SockPortStr`` respectively
* Line 16: Buffer for socket reading

Functions camera_frame_name & pose
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

* Lines 18-22: Singleton instance of camera frame name
* Lines 24-29: Singleton instance of object position

Function mySockClient
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

.. note::
  In this demo, VOS is the socket server which this function attempts to connect to based on the input arguments for socket server's IP address and port.

* Lines 31-53: Connect to socket server; returns ``0`` for successful connection and ``-1`` otherwise

.. _manualTrigger:

* Line 34: Character T with carrier return for triggering VOS

* Lines 35-40: Socket creation with status return and screen output.
* Lines 45-53: Socket connection to provided IP address and port, with status return and screen output.
* Line 50: If socket has been successfully connected, send a trigger signal to VOS

Void pubVisualMarker
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

.. note::
  Location & querternion information would have been passed to the function input argument ``m``

* Lines 58-79: Visual marker creation

Void pubCallback
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

* Lines 81-123: Publish call back
* Lines 91-117: Process the VOS data as sent from socket 
* Line 92: Read up to 1024 bytes from the socket into ``buffer``
* Line 94: Process first token ``,`` in ``buffer``
* Lines 96-114: ``for`` loop to extract ``x``, ``y`` & ``rotation``
* Line 99: Pass the value of ``x`` to ``pose().position.x``
* Line 103: Pass the value of ``y`` to ``pose().position.y``
* Lines 107-111: Convert ``rotation`` which is in the z-axis to querternion
* Line 115: Process next token ``,`` in ``buffer``
* Line 121: Publish to ROS topic
* Line 122: Call pubVisualMarker() for marker creation

Function main 
^^^^^^^^^^^^^^^^^^^^^^^^^^^

* Lines 127-128: Get command-line input arguments for socket server's ip address and port
* Line 135: Attempt to connect to socket server
* Line 147: Callback function
  
workcellex22.launch
##########################################

* ``workcellex22.launch`` is almost identical to ``workcell.launch``, except for the ``fake_ar_publisher`` package in lines 2-4
  
.. code-block::
  :linenos:

  <launch>
    <arg name="SockPort" default="8888"/>
    <arg name="SockAddr" default="192.168.10.143"/>
  <node name="fake_ar_publisher" pkg="fake_ar_publisher" type="fake_ar_publisher_node" output="screen" args="$(arg SockAddr) $(arg SockPort)"></node>
  <node name="vision_node" pkg="myworkcell_core" type="vision_node" output="screen" />
  <node name="myworkcell_node" pkg="myworkcell_core" type="myworkcell_node" output="screen">
     <param name="base_frame" value="world"/>
  </node>
  </launch>

.. _defaultValues:

* Line 2: Default socket port if not supplied from command-line
* Line 3: Default IP address if not supplied from command-line
* Line 4: Pass the arguments to the ``fake_ar_publisher`` package
  
Running the solution
--------------------

.. note::
  At the :hoverxreftooltip:`Run Solution page <intro/Basic/Hover/runsoln:Run Solution>` **do not** press the ``Manual Trigger`` button because triggering is activated by the ROS script.

1. Launch the VOS solution as above, without clicking on the manual trigger button.
2. At your ROS workspace parent folder, invoke 
   
   ``catkin build``

3. If necessary, source the worksapce by 
   
   ``source devel/setup.bash``

4. In a separate Linux command prompt, launch ``RViz`` with the virtual robot and the related ``MoveIt!`` packages for path planning by invoking
   
   ``roslaunch myworkcell_moveit_config myworkcell_planning_execution.launch``

5. In yet another Linux command prompt, invoke 
   
   ``roslaunch myworkcell_support workcellex22.launch SockAddr:=xxx.xxx.xxx.xxx SockPort:=yyyyy``

.. note::
  Please change ``SockAddr`` & ``SockPort`` as appropriate in the command line. If left unspecified, the default values are ``192.168.10.143`` and ``8888`` for :ref:`ip and port respectively <defaultValues>`.

6. The virtual robot will be launched as shown in the youtube video below.
   
.. youtube:: 1O28Kq6fWc8

.. Tip::
  #ROS #socket #path #planning #robot #ur5 #pick-and-place #cobot #qr #tf #melodic #socket 

