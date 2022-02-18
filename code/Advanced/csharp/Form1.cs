using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Net.Sockets;
using System.Configuration;

namespace CsClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		public IntPtr pIClient;

		public int nLastCameraID;
		public int nLastSolutionID;
		public int nLastState;
        public static int cbCount;
		private TcpClient clientSocket = new TcpClient();
		private int IPort = Int32.Parse(ConfigurationManager.AppSettings["ServerPort"]);
		private int maxRefDia = 9;

		//string IPAddress;
		public static readonly string IPAddress = ConfigurationManager.AppSettings["ServerAddr"];
		public static readonly string DefaultUnit = ConfigurationManager.AppSettings["DefaultUnit"];
		private System.Windows.Forms.ComboBox SolutionID;
		private System.Windows.Forms.Label SolIDLabel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label Mode;
		private System.Windows.Forms.Label State;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label Pass;
		private System.Windows.Forms.Label Reject;
		private System.Windows.Forms.Label Recycle;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button StartStop;
		private System.Windows.Forms.Label Inspected;
		private System.Windows.Forms.Label Skipped;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label ProcessTime;
		private System.Windows.Forms.Label PassL;
		private System.Windows.Forms.Label RejectL;
		private System.Windows.Forms.Label RecycleL;
		private System.Windows.Forms.GroupBox groupBox4;
        private TextBox txtOp;
        private Button btnTrigger;
        private DomainUpDown updUnit;
        private System.ComponentModel.IContainer components;

		public Form1()
		{
            int numDev = iClientLib.iClientGetNumDevices();
            if (numDev > 0)
            {
                string[] devices = new string[numDev];
                for (int z = 0; z < numDev; z++)
                {
                    devices[z] = iClientLib.iClientGetDeviceIP(z);
                }
            }
            //IPAddress = iClientLib.iClientGetConnectToAddress();

		    nLastCameraID = 0;
			nLastSolutionID = 0;
			cbCount = 0;

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			Closing +=  new System.ComponentModel.CancelEventHandler(Form1_UnLoad);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StartStop = new System.Windows.Forms.Button();
            this.SolutionID = new System.Windows.Forms.ComboBox();
            this.SolIDLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.State = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Inspected = new System.Windows.Forms.Label();
            this.Skipped = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PassL = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.Label();
            this.Reject = new System.Windows.Forms.Label();
            this.RejectL = new System.Windows.Forms.Label();
            this.Recycle = new System.Windows.Forms.Label();
            this.RecycleL = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ProcessTime = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtOp = new System.Windows.Forms.TextBox();
            this.btnTrigger = new System.Windows.Forms.Button();
            this.updUnit = new System.Windows.Forms.DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(300, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 513);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // StartStop
            // 
            this.StartStop.Location = new System.Drawing.Point(181, 50);
            this.StartStop.Name = "StartStop";
            this.StartStop.Size = new System.Drawing.Size(80, 48);
            this.StartStop.TabIndex = 2;
            this.StartStop.Text = "Start Inspection";
            this.StartStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // SolutionID
            // 
            this.SolutionID.Enabled = false;
            this.SolutionID.Location = new System.Drawing.Point(76, 16);
            this.SolutionID.Name = "SolutionID";
            this.SolutionID.Size = new System.Drawing.Size(185, 21);
            this.SolutionID.TabIndex = 5;
            this.SolutionID.Text = "0";
            this.SolutionID.SelectedIndexChanged += new System.EventHandler(this.SolutionID_SelectedIndexChanged);
            // 
            // SolIDLabel
            // 
            this.SolIDLabel.Location = new System.Drawing.Point(15, 21);
            this.SolIDLabel.Name = "SolIDLabel";
            this.SolIDLabel.Size = new System.Drawing.Size(55, 16);
            this.SolIDLabel.TabIndex = 6;
            this.SolIDLabel.Text = "Soln ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.State);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Mode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SolIDLabel);
            this.groupBox2.Controls.Add(this.SolutionID);
            this.groupBox2.Controls.Add(this.StartStop);
            this.groupBox2.Location = new System.Drawing.Point(16, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 104);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // State
            // 
            this.State.Location = new System.Drawing.Point(73, 74);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(93, 16);
            this.State.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "State:";
            // 
            // Mode
            // 
            this.Mode.Location = new System.Drawing.Point(73, 50);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(93, 16);
            this.Mode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Parts Inspected";
            // 
            // Inspected
            // 
            this.Inspected.Location = new System.Drawing.Point(115, 195);
            this.Inspected.Name = "Inspected";
            this.Inspected.Size = new System.Drawing.Size(36, 16);
            this.Inspected.TabIndex = 9;
            // 
            // Skipped
            // 
            this.Skipped.Location = new System.Drawing.Point(115, 217);
            this.Skipped.Name = "Skipped";
            this.Skipped.Size = new System.Drawing.Size(36, 18);
            this.Skipped.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(21, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Parts Skipped";
            // 
            // PassL
            // 
            this.PassL.Location = new System.Drawing.Point(169, 200);
            this.PassL.Name = "PassL";
            this.PassL.Size = new System.Drawing.Size(32, 13);
            this.PassL.TabIndex = 12;
            this.PassL.Text = "Pass";
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(68, 14);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(48, 13);
            this.Pass.TabIndex = 13;
            // 
            // Reject
            // 
            this.Reject.Location = new System.Drawing.Point(68, 41);
            this.Reject.Name = "Reject";
            this.Reject.Size = new System.Drawing.Size(48, 13);
            this.Reject.TabIndex = 15;
            // 
            // RejectL
            // 
            this.RejectL.Location = new System.Drawing.Point(169, 228);
            this.RejectL.Name = "RejectL";
            this.RejectL.Size = new System.Drawing.Size(40, 13);
            this.RejectL.TabIndex = 14;
            this.RejectL.Text = "Reject";
            // 
            // Recycle
            // 
            this.Recycle.Location = new System.Drawing.Point(68, 68);
            this.Recycle.Name = "Recycle";
            this.Recycle.Size = new System.Drawing.Size(48, 13);
            this.Recycle.TabIndex = 17;
            // 
            // RecycleL
            // 
            this.RecycleL.Location = new System.Drawing.Point(169, 255);
            this.RecycleL.Name = "RecycleL";
            this.RecycleL.Size = new System.Drawing.Size(48, 13);
            this.RecycleL.TabIndex = 16;
            this.RecycleL.Text = "Recycle";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ProcessTime);
            this.groupBox3.Location = new System.Drawing.Point(21, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 45);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ProcessTime (ms)";
            // 
            // ProcessTime
            // 
            this.ProcessTime.Location = new System.Drawing.Point(14, 16);
            this.ProcessTime.Name = "ProcessTime";
            this.ProcessTime.Size = new System.Drawing.Size(112, 23);
            this.ProcessTime.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Recycle);
            this.groupBox4.Controls.Add(this.Pass);
            this.groupBox4.Controls.Add(this.Reject);
            this.groupBox4.Location = new System.Drawing.Point(156, 187);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 96);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            // 
            // txtOp
            // 
            this.txtOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOp.Location = new System.Drawing.Point(12, 289);
            this.txtOp.Multiline = true;
            this.txtOp.Name = "txtOp";
            this.txtOp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOp.Size = new System.Drawing.Size(272, 239);
            this.txtOp.TabIndex = 20;
            // 
            // btnTrigger
            // 
            this.btnTrigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrigger.Location = new System.Drawing.Point(16, 121);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(268, 60);
            this.btnTrigger.TabIndex = 21;
            this.btnTrigger.Text = "          Trigger                   Units";
            this.btnTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrigger.UseVisualStyleBackColor = true;
            this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
            // 
            // updUnit
            // 
            this.updUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updUnit.Location = new System.Drawing.Point(119, 138);
            this.updUnit.Name = "updUnit";
            this.updUnit.Size = new System.Drawing.Size(62, 26);
            this.updUnit.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(944, 547);
            this.Controls.Add(this.updUnit);
            this.Controls.Add(this.btnTrigger);
            this.Controls.Add(this.txtOp);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.RecycleL);
            this.Controls.Add(this.RejectL);
            this.Controls.Add(this.PassL);
            this.Controls.Add(this.Skipped);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Inspected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public static void ImageResultsCallback(IntPtr param)
        {
            cbCount = cbCount + 1;
            iClientLib.iClientSetVarValDbl(param, "cbCount", cbCount);
        }

        public static iClientLib.ProcessResultsCallback resultsCB = new iClientLib.ProcessResultsCallback(ImageResultsCallback);

        


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
	static void Main() 
	{
		Application.Run(new Form1());
        GC.KeepAlive(resultsCB);
	}

	private void button1_Click(object sender, System.EventArgs e)
	{
		if (nLastState == (int)iClientLib.IFRAMEWORK_STATE.IFW_STATE_RUNNING ) 
		{
			iClientLib.iClientStopInspection (pIClient);
			btnTrigger.Enabled = false;
			updUnit.Enabled = false;
		}
		else if (nLastState == (int)iClientLib.IFRAMEWORK_STATE.IFW_STATE_READY_TO_RUN) 
		{
			iClientLib.iClientStartInspection(pIClient);
			btnTrigger.Enabled = true;
			updUnit.Enabled = true;
		}
		GetCurrentState();		
	}

	private void GetCurrentState()
	{
		nLastState = iClientLib.iClientGetState(pIClient);
		State.Text = iClientLib.iClientGetStateString(nLastState);
    
		if (nLastState == (int)iClientLib.IFRAMEWORK_STATE.IFW_STATE_RUNNING ) 
		{
			StartStop.Text = "Stop Inspection";
		}
		else if (nLastState == (int)iClientLib.IFRAMEWORK_STATE.IFW_STATE_READY_TO_RUN) 
		{
			StartStop.Text = "Start Inspection";
		}
		else 
		{
			StartStop.Enabled = false;
			StartStop.Text = "Start Inspection";
		}

	}



		/*private void UpdateCameraIDCombo(int nCameraCount , int nCurrentCameraID )
		{
			int i;

			CameraID.Items.Clear();
			for (i = 0; i< nCameraCount ; i++) 
			{
				CameraID.Items.Insert(i,i);
			}

			if (CameraID.Items.Count > nCurrentCameraID)
			{
				CameraID.SelectedIndex = nCurrentCameraID;
			}
		}*/

		/*private TreeNode AddVarToTree(TreeNode parent, IntPtr pAppVar )
		{
			if ( pAppVar == (IntPtr)0) 
			{
				return null;
			}

			string VarText;
	        string Key;
			TreeNode LoopNode=null;
			TreeNode ChildNode=null;

			if (parent==null) 
			{
				Key = VarText = "AppVar";
				if (VarTree1.Nodes.Count > 0) 
				{
					ChildNode = VarTree1.Nodes[0];
				}
				else 
				{
					ChildNode = new TreeNode("AppVar");
					ChildNode.Tag = "AppVar";
					VarTree1.Nodes.Add(ChildNode);
					ChildNode.Expand();
				}
			}
			else 
			{
				VarText = iClientLib.iClientGetVarName(pAppVar);
				Key = (string)parent.Tag + "." + VarText;
				if (parent.Nodes.Count > 0 ) 
				{
					for (int i=0; i < parent.Nodes.Count; i++)
					{
						LoopNode = parent.Nodes[i];
						if ((string)LoopNode.Tag == Key ) 
						{
							ChildNode = LoopNode;
							break;
						}
					}
				}
			}
			if (ChildNode == null) {
				ChildNode = new TreeNode(VarText + iClientLib.iClientGetVarValueStr(pIClient, pAppVar) );
				ChildNode.Tag = Key;

				if (parent != null)
					parent.Nodes.Add(ChildNode);
				else
					VarTree1.Nodes.Add(ChildNode);
				ChildNode.Expand();
			}
			else {
				ChildNode.Text = VarText + iClientLib.iClientGetVarValueStr(pIClient, pAppVar);
			}

			IntPtr pChildVar = iClientLib.iClientGetFirstChild(pAppVar);
    
			while (pChildVar != (IntPtr)0) {
				AddVarToTree (ChildNode, pChildVar);
				pChildVar = iClientLib.iClientGetNextChild(pAppVar, pChildVar);
			}

			if (LoopNode == null) 
			{
				ChildNode.Expand();
			}

			return ChildNode;
		}*/



		private struct SolIdType
		{
			public int SolID;
			public string SolName;

			public SolIdType (int _solID, string _SolName)
			{
				SolID = _solID;
				SolName = _SolName;
			}

			public override string ToString()
			{
				return this.SolName;
			}
		}


		private void UpdateSolutionIDCombo(int nCurrentSolutionID )
		{
			int i ;
			int j ;

			string Str;
			int nCount ;
			int solId;
			int [] SolutionIDs= new int[iClientLib.IFW_MAX_NUM_OF_SOLUTIONS];

			j = 0;
			SolutionID.Items.Clear();
			nCount = iClientLib.iClientGetSavedSolutionIds(pIClient, SolutionIDs, (uint)iClientLib.IFW_MAX_NUM_OF_SOLUTIONS);

			for (i = 0; i < nCount; i++) 
			{
				solId = SolutionIDs[i];
				if (nCurrentSolutionID == solId ) 
				{
					j = SolutionID.Items.Count;
				}

				Str = solId + " - " + iClientLib.iClientGetSolutionDescription(pIClient, solId);
				SolutionID.Items.Add(new SolIdType(solId,Str));
			}

			if (SolutionID.Items.Count > j ) 
			{
				SolutionID.SelectedIndex = j;
				nLastSolutionID = nCurrentSolutionID;
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
			/*CameraID.Items.Clear();
			CameraID.Items.Add("0");*/

			/////sawong 20211011 loopback error 
			/*if (IPAddress.Equals("loopback"))
            {
				IPAddress = "127.0.0.1";
            }*/
			////////////
			pIClient = iClientLib.iClientCreate(IPAddress);

			if (pIClient != (IntPtr)0 ) 
			{
				int EngMode;

				GetCurrentState();


				EngMode = iClientLib.iClientGetMode(pIClient);

				Mode.Text= iClientLib.iClientGetModeString(EngMode);
				
				//nLastSolutionID = iClientLib.iClientGetCurrentSolutionID(pIClient);
				//UpdateCameraIDCombo (iClientLib.iClientGetNumOfCameras(pIClient), iClientLib.iClientGetCurrentCameraID(pIClient));
				UpdateSolutionIDCombo(nLastSolutionID);
				SetSolutionIDComboIndex(Int32.Parse(ConfigurationManager.AppSettings["DefaultSoln"]));

				//Text = iClientLib.iClientGetAppTitle(pIClient) + ", Version: " + iClientLib.iClientGetVersion(pIClient);
				Text = "VOS Object Measurement Demo" + " (Version: " + iClientLib.iClientGetVersion(pIClient) +")";

				iClientLib.iClientSetWindow( pIClient, pictureBox1.Handle );
                iClientLib.iClientSetCamZoom(pIClient, 1, iClientLib.IFW_STRETCH_TO_FIT, iClientLib.IFW_STRETCH_TO_FIT);
                iClientLib.iClientSetResultsCallback(pIClient, resultsCB, pIClient);

				updUnitAddItems();
				connectSocket(IPAddress,IPort);
				btnTrigger.Text = btnTrigger.Text.Replace("Units", DefaultUnit);
			}

		}

        private void connectSocket(string ipAddr, int ipPort)
        {
			try
			{
				clientSocket.Connect(ipAddr, ipPort);
            }
			catch (ArgumentNullException ane)
			{
				Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
				txtOp.Text = "ArgumentNullException : {ane.ToString()}";
			}
			catch (SocketException se)
			{
				Console.WriteLine("SocketException : {0}", se.ToString());
				txtOp.Text = "SocketException : {se.ToString()}";
			}
			catch (Exception e)
			{
				Console.WriteLine("Unexpected exception : {0}", e.ToString());
				txtOp.Text = "Unexpected exception : {e.ToString()}";
			}
		}

        private void updUnitAddItems()
        {
			for (int i = maxRefDia; i > 0; i--)
			{
				updUnit.Items.Add(i.ToString());
			}
			updUnit.SelectedIndex = maxRefDia-1;
		}

        private void Form1_UnLoad(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (pIClient != (IntPtr)0 ) 
			{
				iClientLib.iClientSetWindow( pIClient, (IntPtr)0 );
				Thread.Sleep(200);
				iClientLib.iClientDelete (pIClient, false);
				pIClient = (IntPtr)0;
			}

		}
	


		/*private void CameraID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			IntPtr pTemp;
			pTemp = pIClient;
			pIClient = (IntPtr)0;
			if (CameraID.SelectedIndex != nLastCameraID) 
			{
				if (iClientLib.iClientSetCurrentCameraID(pTemp, CameraID.SelectedIndex) )
				{
					nLastCameraID = CameraID.SelectedIndex;
				}
				else 
				{
					CameraID.SelectedIndex = nLastCameraID;
				}
			}		
			pIClient = pTemp;
		}*/

		private bool SetSolutionIDComboIndex(int nSolutionID )
		{
			int i;
			for (i = 0; i < SolutionID.Items.Count; i++) 
			{
				if (nSolutionID == ((SolIdType)(SolutionID.Items[i])).SolID ) 
				{
					SolutionID.SelectedIndex = i;
					return true;
				}
			}
			return false;
		}

		private void SolutionID_SelectedIndexChanged(object sender, System.EventArgs e)
		{		
			IntPtr pTemp;
			pTemp = pIClient;
			pIClient = (IntPtr)0;
			int curSolID = ((SolIdType)SolutionID.Items[SolutionID.SelectedIndex]).SolID;
			if (nLastSolutionID != curSolID) 
			{
				if (iClientLib.iClientChangeSolution(pTemp,  curSolID))
				{
					//VarTree1.Nodes.Clear();
					//UpdateCameraIDCombo (iClientLib.iClientGetNumOfCameras(pTemp), iClientLib.iClientGetCurrentCameraID(pTemp));
					nLastSolutionID = curSolID;
				}
				else 
				{
					SetSolutionIDComboIndex (nLastSolutionID);
				}
			}
			pIClient = pTemp;
		}


		/*private void VarTree1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
		
		}*/

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (pIClient == (IntPtr)0 ) 
			{
				return;
			}

			GetCurrentState();
			//UpdateCameraIDCombo (iClientLib.iClientGetNumOfCameras(pIClient), iClientLib.iClientGetCurrentCameraID(pIClient));
    
			int nCurrentSolutionID ;
			nCurrentSolutionID = iClientLib.iClientGetCurrentSolutionID(pIClient);
			if (nLastSolutionID != nCurrentSolutionID) 
			{
				UpdateSolutionIDCombo (nCurrentSolutionID);
			}

			Inspected.Text = Convert.ToString(iClientLib.iClientGetProcessCount(pIClient));
			Skipped.Text = Convert.ToString(iClientLib.iClientGetSkipCount(pIClient));
			Pass.Text = Convert.ToString(iClientLib.iClientGetPassCount(pIClient));
			Reject.Text = Convert.ToString(iClientLib.iClientGetFailCount(pIClient));
			Recycle.Text = Convert.ToString(iClientLib.iClientGetRecycleCount(pIClient));
			ProcessTime.Text = Convert.ToString(iClientLib.iClientGetProcessTime(pIClient));
    
			PassL.BackColor = Pass.BackColor;
			RejectL.BackColor = Reject.BackColor;
			RecycleL.BackColor = Recycle.BackColor;
    
			if (nLastState == (int)iClientLib.IFRAMEWORK_STATE.IFW_STATE_RUNNING ) 
			{
				int nCurrentResult ;
				nCurrentResult = iClientLib.iClientGetResult(pIClient);
				if (nCurrentResult == (int)iClientLib.IFW_REJECTOR_RESULT.IFW_REJECTOR_PASS ) 
				{
					PassL.BackColor = System.Drawing.ColorTranslator.FromWin32(0xFF00);
				}
				else if (nCurrentResult == (int)iClientLib.IFW_REJECTOR_RESULT.IFW_REJECTOR_RECYCLE) 
				{
					RecycleL.BackColor = System.Drawing.ColorTranslator.FromWin32(0xFFFF);
				}
				else 
				{
					RejectL.BackColor = System.Drawing.ColorTranslator.FromWin32(0xFF);
				}
			}

			/*IntPtr pRootVar;
			pRootVar = iClientLib.iClientGetVarRoot(pIClient);
    
			if (pRootVar != (IntPtr)0)
			{    
				VarTree1.BeginUpdate();

				AddVarToTree (null, pRootVar);

				VarTree1.EndUpdate();
			}*/
		}

        private void btnTrigger_Click(object sender, EventArgs e)
        {
			byte[] inStream = new byte[(int)clientSocket.ReceiveBufferSize];
			NetworkStream serverStream = clientSocket.GetStream();
			byte[] outStream = { 0x54, (byte)(Byte.Parse(updUnit.Text) + 0x30), 10, 13 };
			serverStream.Write(outStream, 0, outStream.Length);
			serverStream.Flush();

			serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
			string serverText = System.Text.Encoding.ASCII.GetString(inStream);
			//serverText
			txtOp.Text = parseVosOpString(serverText);
			//MessageBox.Show(serverText);
		}

		private string parseVosOpString(string ipStr)
        {
			string tmpStr = ipStr;
			tmpStr = tmpStr.Substring(0,tmpStr.LastIndexOf('\n')+1);
			tmpStr = tmpStr.Replace("units", DefaultUnit);
			tmpStr = tmpStr.Replace("?", "°");
			return tmpStr;
        } 
    }
}
