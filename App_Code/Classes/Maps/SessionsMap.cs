using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class SessionsMap : ISessions
{
    private int _id;
    private DateTime _expiration;
    private int _uid;
    private string _sessionVal;
    

    public SessionsMap()
    {
         this._id = this.id;
         this._expiration = this.expiration;
         this._uid = this.uid;
         this._sessionVal = this.sessionVal;
    }

    public SessionsMap(int userId)
    {
        functionality func = new functionality();
        this._id = this.id;
        this._expiration = DateTime.Now.AddHours(3);
        this._uid = userId;
        this._sessionVal = func.randomCharacterSet(20);
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
    public DateTime expiration
    {
        get { return this._expiration; }
        set
        {
            if (this._expiration != value)
            {
                this._expiration = value;
            }
        }
    }
    public int uid
    {
        get { return this._uid; }
        set
        {
            if (this._uid != value)
            {
                this._uid = value;
            }
        }
    }
    public string sessionVal
    {
        get { return this._sessionVal; }
        set
        {
            if (this._sessionVal != value)
            {
                this._sessionVal = value;
            }
        }
    }
}

