using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LogsMap : ILogs
{
    private int _id;
    private logType _LT;
    private DateTime _timeOfEvent;
    private int _uid1;
    private int _uid2;
    private string _logData;
    

    public LogsMap()
    {
         this._id = this.id;
         this._LT = this.LT;
         this._timeOfEvent = this.timeOfEvent;
         this._uid1 = this.uid1;
         this._uid2 = this.uid2;
         this._logData = this.logData;
    }

    public int id
    {
        get { return this._id; }
        set
        {
            if (this._id != value)
            {
                this._id = value;
            }
        }
    }
    public logType LT
    {
        get { return this._LT; }
        set
        {
            if (this._LT != value)
            {
                this._LT = value;
            }
        }
    }
    public DateTime timeOfEvent
    {
        get { return this._timeOfEvent; }
        set
        {
            if (this._timeOfEvent != value)
            {
                this._timeOfEvent = value;
            }
        }
    }
    public int uid1
    {
        get { return this._uid1; }
        set
        {
            if (this._uid1 != value)
            {
                this._uid1 = value;
            }
        }
    }
    public int uid2
    {
        get { return this._uid2; }
        set
        {
            if (this._uid2 != value)
            {
                this._uid2 = value;
            }
        }
    }
    public string logData
    {
        get { return this._logData; }
        set
        {
            if (this._logData != value)
            {
                this._logData = value;
            }
        }
    }
}

