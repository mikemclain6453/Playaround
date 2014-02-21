using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TotalCoinsMap : ITotalCoins
{
    private int _id;
    private string _totalCoinString;
    private decimal _amount;
    

    public TotalCoinsMap()
    {
         this._id = this.id;
         this._totalCoinString = this.totalCoinString;
         this._amount = this.amount;
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
    public string totalCoinString
    {
        get { return this._totalCoinString; }
        set
        {
            if (this._totalCoinString != value)
            {
                this._totalCoinString = value;
            }
        }
    }
    public decimal amount
    {
        get { return this._amount; }
        set
        {
            if (this._amount != value)
            {
                this._amount = value;
            }
        }
    }
}

