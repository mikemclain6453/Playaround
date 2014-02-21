using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CoinOrderMap : ICoinOrder
{
    private int _id;
    private orderType _OT;
    private coinType _CT;
    private string _coinBankVal;
    private decimal _perCoin;
    private decimal _coinsToBeTraded;
    

    public CoinOrderMap()
    {
         this._id = this.id;
         this._OT = this.OT;
         this._CT = this.CT;
         this._coinBankVal = this.coinBankVal;
         this._perCoin = this.perCoin;
         this._coinsToBeTraded = this.coinsToBeTraded;
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
    public orderType OT
    {
        get { return this._OT; }
        set
        {
            if (this._OT != value)
            {
                this._OT = value;
            }
        }
    }
    public coinType CT
    {
        get { return this._CT; }
        set
        {
            if (this._CT != value)
            {
                this._CT = value;
            }
        }
    }
    public string coinBankVal
    {
        get { return this._coinBankVal; }
        set
        {
            if (this._coinBankVal != value)
            {
                this._coinBankVal = value;
            }
        }
    }
    public decimal perCoin
    {
        get { return this._perCoin; }
        set
        {
            if (this._perCoin != value)
            {
                this._perCoin = value;
            }
        }
    }
    public decimal coinsToBeTraded
    {
        get { return this._coinsToBeTraded; }
        set
        {
            if (this._coinsToBeTraded != value)
            {
                this._coinsToBeTraded = value;
            }
        }
    }
}

