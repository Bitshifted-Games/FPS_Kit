//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LogItem
{
    public System.DateTime timestampInUTC;
    public System.DateTime timestampInLocal;
    public string message;
    public LogSeverity severity;

    public LogItem ( string message, LogSeverity severity )
    {
        timestampInUTC = System.DateTime.UtcNow;
        timestampInLocal = System.DateTime.Now;
        this.severity = severity;
        this.message = message;
    }
}
