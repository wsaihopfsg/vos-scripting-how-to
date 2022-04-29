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
