using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menus_loggedIn : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        functionality func = new functionality();
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];

        dynamic val = func.cookieStatus(cookie);

        if (val.map.coinBankVal1 == "" || val.map.coinBankVal2 == "")
        {
            lblAddCoinBank.Text = @"
    <li>
        <a href='addCoinAccount.aspx'>Add Coin Bank</a>
    </li>";
        }

    }
}