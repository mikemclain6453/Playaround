using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CoinBankMap : ICoinBank
{
    private int _id;
    private coinType _CT;
    private string _coinBankVal;
    private string _totalCoinString;
    

    public CoinBankMap()
    {
         this._id = this.id;
         this._CT = this.CT;
         this._coinBankVal = this.coinBankVal;
         this._totalCoinString = this.totalCoinString;
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
}

