using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_placeOrder : System.Web.UI.Page
{
    private functionality func = new functionality();
    private trading trade = new trading();

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];

        dynamic accountData = func.cookieStatus(cookie);

        if (accountData.GetType() != typeof(RepoMapConnect))
        {
            Response.Redirect("../login.aspx");
        }
    }
    protected void btnCalculateQuantityValue_onclick(object sender, EventArgs e)
    {
        if (testPass(txtOffer.Text))
        {
            createBestPrice(decimal.Parse(txtOffer.Text), "QuantityNeeded");
        }
    }
    protected void btnCalculateMarketValue_onclick(object sender, EventArgs e)
    {
        if (testPass(txtQuantity.Text))
        {
            createBestPrice(decimal.Parse(txtQuantity.Text), "OfferNeeded");
        }
    }
    protected void btnSubmitOrder_onclick(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];

        dynamic accountData = func.cookieStatus(cookie);

        if (accountData.GetType() == typeof(RepoMapConnect))
        {
            if (continuePermit(accountData.map))
            {
                RepoMapConnect RMC = new RepoMapConnect(databaseTable.CoinOrder);

                RMC.map.CT = func.coinTypeStringToEnum(ddlCoinType.SelectedValue.ToString());
                RMC.map.coinsToBeTraded = decimal.Parse(txtQuantity.Text);
                RMC.map.perCoin = decimal.Parse(txtOffer.Text);
                if (RMC.map.CT == coinType.Bitcoin)
                {
                    RMC.map.coinBankVal = accountData.map.coinBankVal1;
                }
                else
                {
                    RMC.map.coinBankVal = accountData.map.coinBankVal2;
                }
                RMC.map.OT = func.orderTypeStringToEnum(ddlBuySell.SelectedValue.ToString());

                RMC.repo.executeData(RMC.map, sqlStatementType.Insert);
                lblErrorInfo.Text = "Order submitted.";
            }
        }

    }
    protected void btnAutoBuyOne_onclick(object sender, EventArgs e)
    {

    }
    protected void btnAutoSellOne_onclick(object sender, EventArgs e)
    {

    }
    protected void txtOffer_textchange(object sender, EventArgs e)
    {
        try
        {
            lblTotalOffered.Text = "$" + (decimal.Parse(txtOffer.Text) * decimal.Parse(txtQuantity.Text)).ToString();
        }
        catch
        {
            lblTotalOffered.Text = "Incorrect offer/quantity inputs.";
        }
    }

    private bool continuePermit(PrimaryAccountMap map)
    {
        if (ddlBuySell.SelectedValue.ToString() == "Buy")
        {
            if (map.accountBalance >= (decimal.Parse(txtOffer.Text) * decimal.Parse(txtQuantity.Text)))
            {
                return true;
            }
        }
        else if (ddlBuySell.SelectedValue.ToString() == "Sell")
        {
            decimal coinCount = new decimal();
            if (ddlCoinType.SelectedValue.ToString() == "Bitcoin")
            {
                coinCount = func.getValueByBankValue(map.coinBankVal1);
            }
            else if (ddlCoinType.SelectedValue.ToString() == "Litecoin")
            {
                coinCount = func.getValueByBankValue(map.coinBankVal2);
            }

            if (coinCount >= decimal.Parse(txtQuantity.Text))
            {
                return true;
            }
        }
        return false;
    }

    private bool testPass(string val)
    {
        decimal number;
        bool canConvert = decimal.TryParse(val, out number);
        return canConvert;
    }

    private void createBestPrice(decimal val, string typeOfCalculate)
    {
        CoinOrderMap map = new CoinOrderMap();
        if (ddlBuySell.SelectedValue.ToString() == "Buy")
        {
            map = trade.cheapestCoin(orderType.Buy);
        }
        else if (ddlBuySell.SelectedValue.ToString() == "Sell")
        {
            map = trade.cheapestCoin(orderType.Sell);
        }

        if (typeOfCalculate == "QuantityNeeded")
        {
            txtQuantity.Text = (map.perCoin / decimal.Parse(txtOffer.Text)).ToString();
        }
        else if (typeOfCalculate == "OfferNeeded")
        {
            txtOffer.Text = (map.perCoin * decimal.Parse(txtQuantity.Text)).ToString();
        }
    }
}