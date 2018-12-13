using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableLog
{
    public List<LogItem> LogFile;

    public SerializableLog ()
    {
        LogFile = new List<LogItem> ();
    }

    public void Log(string message,LogSeverity severity = LogSeverity.Debug )
    {
        LogFile.Add ( new LogItem ( message, severity ) );
    }
}
