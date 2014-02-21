using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_addCoinAccount : System.Web.UI.Page
{
    private functionality func = new functionality();

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];

        dynamic val = func.cookieStatus(cookie);

        if (val.GetType() == typeof(RepoMapConnect))
        {
            if (val.map.coinBankVal1 != "" && val.map.coinBankVal2 != "")
            {
                Response.Redirect("view.aspx");
            }
            else
            {
                if (val.map.coinBankVal1 != "")
                {
                    btnBitcoinBank.Enabled = false;
                    btnBitcoinBank.Visible = false;
                }

                if (val.map.coinBankVal2 != "")
                {
                    btnLitecoinBank.Enabled = false;
                    btnLitecoinBank.Visible = false;
                }
            }
        }
        else
        {
            Response.Redirect("../default.aspx");
        }
    }
    protected void btnBitcoinBank_onclick(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];

        dynamic val = func.cookieStatus(cookie);

        if (val.GetType() == typeof(RepoMapConnect))
        {
            if (val.map.coinBankVal1 == "")
            {
                addAccounts(coinType.Bitcoin, val);
                btnBitcoinBank.Enabled = false;
            }
        }
        else
        {
            Response.Redirect("../default.aspx");
        }

    }
    protected void btnLitecoinBank_onclick(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];

        dynamic val = func.cookieStatus(cookie);

        if (val.GetType() == typeof(RepoMapConnect))
        {
            if (val.map.coinBankVal2 == "")
            {
                addAccounts(coinType.Litecoin, val);
                btnLitecoinBank.Enabled = false;
            }

        }
        else
        {
            Response.Redirect("../default.aspx");
        }

    }

    private void addAccounts(coinType CT, RepoMapConnect primaryAccount)
    {
        RepoMapConnect coinBank = new RepoMapConnect(databaseTable.CoinBank);
        if (CT == coinType.Bitcoin)
        {
            primaryAccount.map.coinBankVal1 = func.randomCharacterSet(20);
            coinBank.map.coinBankVal = primaryAccount.map.coinBankVal1;
        }
        else if (CT == coinType.Litecoin)
        {
            primaryAccount.map.coinBankVal2 = func.randomCharacterSet(20);
            coinBank.map.coinBankVal = primaryAccount.map.coinBankVal2;
        }
        primaryAccount.repo.executeData(primaryAccount.map, sqlStatementType.Update);
        coinBank.map.CT = CT;
        coinBank.map.totalCoinString = "2NgR99HxbtgzdA7kweJzQ6TZdsshYf";
        coinBank.repo.executeData(coinBank.map, sqlStatementType.Insert);
        btnLitecoinBank.Enabled = false;
    }

}