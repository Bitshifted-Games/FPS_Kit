using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum LogSeverity
{
    Debug,
    Info,
    Warning,
    Error,
    Critical
}

public class Logger : MonoBehaviour
{
    public static Logger instance;

    public static string logPath;
    public static string logFilename = "latest";
    public static string logFileExtension = ".log";
    public static SerializableLog myLog;

    private bool isInitialized = false;
    public bool Initialized
    {
        get { return isInitialized; }
        set { isInitialized = value; }
    }

    private void Initialize ()
    {
        if ( string.IsNullOrEmpty ( logPath ) )
            logPath = System.IO.Path.Combine ( Application.streamingAssetsPath, "log" );

        if ( myLog == null ) myLog = new SerializableLog ();
        isInitialized = true;
    }

    #region MonoBehaviours
    private void Awake ()
    {

    }

    private void OnEnable ()
    {
        Initialize ();
    }

    private void Start ()
    {

    }

    private void Update ()
    {

    }
    #endregion

    #region Public API
    public static void LogDebug ( string message )
    {
        myLog.Log ( message );
    }

    public static void LogInfo ( string message )
    {
        myLog.Log ( message, LogSeverity.Info );
    }

    public static void LogWarning ( string message )
    {
        myLog.Log ( message, LogSeverity.Warning );
    }

    public static void LogError ( string message )
    {
        myLog.Log ( message, LogSeverity.Error );
    }

    public static void LogCritical ( string messaage )
    {
        myLog.Log ( messaage, LogSeverity.Error );
    }

    public void FlushLog ()
    {
        SaveLog ();
        myLog.LogFile.Clear ();
    }
    #endregion

    private void SaveLog ()
    {
        string jsonData = JsonUtility.ToJson ( myLog, true );
        string fullPath = System.IO.Path.Combine ( logPath, logFilename + logFileExtension );
        if ( !System.IO.File.Exists ( fullPath ) )
        {
            System.IO.File.Create ( fullPath );
        } else
        {
            System.IO.File.Move ( fullPath, System.IO.Path.Combine ( logPath, "old" + logFileExtension ) );
            System.IO.File.Create ( fullPath );
        }
        System.IO.File.WriteAllText ( fullPath, jsonData );
    }
}
