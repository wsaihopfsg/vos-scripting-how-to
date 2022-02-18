using System;
using System.Runtime.InteropServices;


public class iClientLib
{

	static public int IFW_MAX_NUM_OF_SOLUTIONS = 1024;

    static public int IFW_STRETCH_TO_FIT = -1;
    static public int IFW_CLIENT_CREATE_NO_MSG_BOX = 1;

	public enum IFRAMEWORK_STATE
	{
    IFW_STATE_NOT_CONFIGURED = 0,
    IFW_STATE_READY_TO_RUN,
    IFW_STATE_RUNNING,
    IFW_STATE_ALARM,
    IFW_STATE_STOPPED,
    IFW_STATE_LIVE_IMG,

    IFRAMEWORK_STATE_COUNT       
	};


	public enum IFW_APP_MODE
	{
		IFW_START_INSPECTION = 0,
	    IFW_STOP_INSPECTION,

		IFW_APP_MODE_COUNT
	};


	public enum IFW_ENG_MODE
	{
		ENG_LIVE_IMG = 0,
		ENG_PROCESS_SOLUTION,
		ENG_STOP,

		IFW_ENG_MODE_COUNT   
	};

	public enum IFW_REJECTOR_RESULT
	{
		IFW_REJECTOR_PASS = 0,
		IFW_REJECTOR_RECYCLE,
		IFW_REJECTOR_FAIL,

		IFW_REJECTOR_RESULT_COUNT       
	};

	public enum IFW_REPORT_MODE
	{
		IFW_REPORT_DATA_IMAGE_GRAPHICS = 0,
		IFW_REPORT_DATA_GRAPHICS,
		IFW_REPORT_DATA_ONLY,

		IFW_REPORT_MODE_COUNT
	};

	public enum IFW_IMG_TYPE
	{
		IFW_BMP_IMG = 0,
		IFW_JPEG_IMG
	};

	public enum HISTORY_DOMAIN_TYPE
	{
		DOMAIN_ALL = -1,
		DOMAIN_PASS,
		DOMAIN_RECYCLE,
		DOMAIN_FAIL
	};


    public delegate void ProcessResultsCallback(IntPtr p1);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetConnectToAddress")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetConnectToAddress();

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientCreate")]
	public static extern IntPtr		iClientCreate([MarshalAs(UnmanagedType.BStr)] string bstrIPAddress);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientCreateEx")]
    public static extern IntPtr iClientCreateEx([MarshalAs(UnmanagedType.BStr)] string bstrIPAddress, UInt32 options);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientDelete")]
	public static extern bool		iClientDelete(IntPtr pIClient, bool bShutdownServer);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientStopInspection")]
	public static extern bool		iClientStopInspection(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientStartInspection")]
	public static extern bool		iClientStartInspection(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetVersion")]
	public static extern int			iClientGetVersion(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetAppTitle")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetAppTitle(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetWindow")]
	public static extern bool		iClientSetWindow(IntPtr pIClient, IntPtr hWnd);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientMaxNumOfSolutions")]
	public static extern int		iClientMaxNumOfSolutions(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientDeleteSolution")]
	public static extern bool		iClientDeleteSolution(IntPtr pIClient, int nSolutionID);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientChangeSolution")]
	public static extern bool		iClientChangeSolution(IntPtr pIClient, int nNewSolutionID);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetCurrentSolutionID")]
	public static extern int			iClientGetCurrentSolutionID(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientIsAvailableSolution")]
	public static extern bool		iClientIsAvailableSolution(IntPtr pIClient, int nSolutionID);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetSolutionDescription")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetSolutionDescription(IntPtr pIClient, int nSolutionID);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetSavedSolutionIds")]
	public static extern int			iClientGetSavedSolutionIds(IntPtr pIClient, int[] SolutionIDs, UInt32 maxNumEntries);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetProcessTime")]
	public static extern double		iClientGetProcessTime(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetProcessCount")]
	public static extern int		iClientGetProcessCount(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetSkipCount")]
	public static extern int		iClientGetSkipCount(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetPassCount")]
	public static extern int		iClientGetPassCount(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetFailCount")]
	public static extern int		iClientGetFailCount(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetRecycleCount")]
	public static extern int		iClientGetRecycleCount(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetResult")]
	public static extern int			iClientGetResult(IntPtr pIClient);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetNumOfCameras")]
	public static extern int			iClientGetNumOfCameras(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetCurrentCameraID")]
	public static extern int 		iClientGetCurrentCameraID(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetCurrentCameraID")]
	public static extern bool		iClientSetCurrentCameraID(IntPtr pIClient, int nNewCameraID);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetMode")]
	public static extern int 		iClientGetMode(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetState")]
	public static extern int			iClientGetState(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetModeString")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetModeString(int iMode);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetStateString")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetStateString(int iState);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetVarRoot")]
	public static extern IntPtr		iClientGetVarRoot(IntPtr pIClient);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetFirstChild")]
	public static extern IntPtr		iClientGetFirstChild(IntPtr pAppVar);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetNextChild")]
	public static extern IntPtr		iClientGetNextChild(IntPtr pAppVar, IntPtr pCurrChild);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetVarName")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetVarName(IntPtr pAppVar);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetVarValueStr")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetVarValueStr(IntPtr pIClient, IntPtr pAppVar);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientIsSysAppVar")]
	public static extern bool		iClientIsSysAppVar(IntPtr pAppVar);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetVarValDbl")]
	public static extern double		iClientGetVarValDbl(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetVarValStr")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetVarValStr(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetVarValDbl")]
	public static extern bool		iClientSetVarValDbl(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, double val);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetVarValStr")]
	public static extern bool		iClientSetVarValStr(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, [MarshalAs(UnmanagedType.BStr)]string val);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetVarValDblCamera")]
	public static extern double		iClientGetVarValDblCamera(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetVarValStrCamera")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetVarValStrCamera(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetVarValDblCamera")]
	public static extern bool		iClientSetVarValDblCamera(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex, double val);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetVarValStrCamera")]
	public static extern bool		iClientSetVarValStrCamera(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex, [MarshalAs(UnmanagedType.BStr)]string val);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetVarNumChildren")]
	public static extern int		iClientGetVarNumChildren(IntPtr pAppVar);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetReportMode")]
	public static extern bool		iClientSetReportMode(IntPtr pIClient, int nPassReportMode, int nFailReportMode, int nRecyleReportMode);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetCamWindow")]
	public static extern bool		iClientSetCamWindow(IntPtr pIClient, int camId /* 1...3*/, IntPtr hWnd);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetCamZoom")]
	public static extern bool		iClientSetCamZoom(IntPtr pIClient, int camId /* 1...3*/, double dXZoom, double dYZoom);


	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGenerateManualTrigger")]
	public static extern bool		iClientGenerateManualTrigger(IntPtr pIClient);

 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetTolerances")]
	public static extern bool		iClientSetTolerances(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex, double[] tolerances);

 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetTolerances")]
	public static extern bool		iClientGetTolerances(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex, double[] tolerances);

 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientSetMeasPerfectString")]
	public static extern bool		iClientSetMeasPerfectString(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex, [MarshalAs(UnmanagedType.BStr)]string perfectString);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetMeasPerfectString")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string	iClientGetMeasPerfectString(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex);


 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetMeasStdDeviation")]
	public static extern double	iClientGetMeasStdDeviation(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex);

 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetMeasMean")]
	public static extern double	iClientGetMeasMean(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex);

 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetMeasMin")]
	public static extern double	iClientGetMeasMin(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex);

 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetMeasMax")]
	public static extern double	iClientGetMeasMax(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex);

 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientResetMeasVarStats")]
	public static extern bool	iClientResetMeasVarStats(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex);

 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetMeasType")]
	public static extern int	iClientGetMeasType(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string varName, int iCamIndex);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetMeasName")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string	iClientGetMeasName(IntPtr pIClient, int varIndex, int iCamIndex);

 	[DllImport("iClientApi2258.dll", EntryPoint = "iClientEvalEquation")]
	public static extern double	iClientEvalEquation(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string equation);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientSetResultsCallback")]
    public static extern bool iClientSetResultsCallback(IntPtr pIClient, ProcessResultsCallback resultsCB, IntPtr param);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientSaveSolution")]
    public static extern bool iClientSaveSolution(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string solutionDescription, int iSolutionIndex);


   	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetNumDevices")]
	public static extern int		iClientGetNumDevices();

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientGetDeviceIP")]
	[return: MarshalAs(UnmanagedType.BStr)]public static extern string		iClientGetDeviceIP(int devNum);


    [DllImport("iClientApi2258.dll", EntryPoint = "iClientWaitImage")]
    public static extern bool iClientWaitImage(IntPtr pIClient, int camId, IntPtr imgBuf, UInt32 waitTimeMillisec);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientSetOutputPort")]
    public static extern bool iClientSetOutputPort(IntPtr pIClient, int uLine, int val);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientSetLogHistoryToFile")]
    public static extern bool iClientSetLogHistoryToFile(IntPtr pIClient, bool bLogHistory, bool bLogFailed, bool bLogRecycle, bool bLogPass, 
										   bool logGraphics, IFW_IMG_TYPE fileType, bool bLogSubFolders, [MarshalAs(UnmanagedType.BStr)]string filePrefix );

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientGetLogDomainSize")]
    public static extern int iClientGetLogDomainSize(IntPtr pIClient, HISTORY_DOMAIN_TYPE domain);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientGetLogEntry")]
    public static extern int iClientGetLogEntry(IntPtr pIClient, HISTORY_DOMAIN_TYPE domain, int pos, bool withOverlay, [MarshalAs(UnmanagedType.BStr)]string fileName, IntPtr numInspected);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientSetHistoryLock")]
    public static extern int iClientSetHistoryLock(IntPtr pIClient, bool historyLock);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientExportSolutions")]
    public static extern bool iClientExportSolutions(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string solutionPath);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientImportSolutions")]
    public static extern bool iClientImportSolutions(IntPtr pIClient, [MarshalAs(UnmanagedType.BStr)]string solutionPath);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientResetRejector")]
	public static extern bool iClientResetRejector(IntPtr pIClient, int iPartsBetween);

	[DllImport("iClientApi2258.dll", EntryPoint = "iClientResetStatistics")]
	public static extern bool iClientResetStatistics(IntPtr pIClient);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientSetParameter")]
    public static extern bool iClientSetParameter(IntPtr pIClient, int paramID, double val);

    [DllImport("iClientApi2258.dll", EntryPoint = "iClientGetParameter")]
    public static extern double iClientGetParameter(IntPtr pIClient, int paramID);

}