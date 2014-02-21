using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PrimaryAccountMap : IPrimaryAccount
{
    private int _id;
    private string _email;
    private string _username;
    private string _password;
    private string _salt;
    private membership _memberLevel;
    private administrativeTrust _adminTrust;
    private decimal _accountBalance;
    private string _coinBankVal1;
    private string _coinBankVal2;
    

    public PrimaryAccountMap()
    {
         this._id = this.id;
         this._email = this.email;
         this._username = this.username;
         this._password = this.password;
         this._salt = this.salt;
         this._memberLevel = this.memberLevel;
         this._adminTrust = this.adminTrust;
         this._accountBalance = this.accountBalance;
         this._coinBankVal1 = this.coinBankVal1;
         this._coinBankVal2 = this.coinBankVal2;
    }

    public PrimaryAccountMap(bool defaultMap)
    {
        this._id = this.id;
        if (defaultMap)
        {
            this._email = "";
            this._username = "";
            this._password = "";
            functionality func = new functionality();
            this._salt = func.randomCharacterSet(20);
            this._memberLevel = membership.Unverified;
            this._adminTrust = administrativeTrust.Unknown;
            this._accountBalance = 0.00m;
            this._coinBankVal1 = "";
            this._coinBankVal2 = "";
        }
        else
        {
            this._email = this.email;
            this._username = this.username;
            this._password = this.password;
            this._salt = this.salt;
            this._memberLevel = this.memberLevel;
            this._adminTrust = this.adminTrust;
            this._accountBalance = this.accountBalance;
            this._coinBankVal1 = this.coinBankVal1;
            this._coinBankVal2 = this.coinBankVal2;
        }
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
    public string email
    {
        get { return this._email; }
        set
        {
            if (this._email != value)
            {
                this._email = value;
            }
        }
    }
    public string username
    {
        get { return this._username; }
        set
        {
            if (this._username != value)
            {
                this._username = value;
            }
        }
    }
    public string password
    {
        get { return this._password; }
        set
        {
            if (this._password != value)
            {
                this._password = value;
            }
        }
    }
    public string salt
    {
        get { return this._salt; }
        set
        {
            if (this._salt != value)
            {
                this._salt = value;
            }
        }
    }
    public membership memberLevel
    {
        get { return this._memberLevel; }
        set
        {
            if (this._memberLevel != value)
            {
                this._memberLevel = value;
            }
        }
    }
    public administrativeTrust adminTrust
    {
        get { return this._adminTrust; }
        set
        {
            if (this._adminTrust != value)
            {
                this._adminTrust = value;
            }
        }
    }
    public decimal accountBalance
    {
        get { return this._accountBalance; }
        set
        {
            if (this._accountBalance != value)
            {
                this._accountBalance = value;
            }
        }
    }
    public string coinBankVal1
    {
        get { return this._coinBankVal1; }
        set
        {
            if (this._coinBankVal1 != value)
            {
                this._coinBankVal1 = value;
            }
        }
    }
    public string coinBankVal2
    {
        get { return this._coinBankVal2; }
        set
        {
            if (this._coinBankVal2 != value)
            {
                this._coinBankVal2 = value;
            }
        }
    }
}

