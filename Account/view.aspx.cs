using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        functionality func = new functionality();
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];

        dynamic val = func.cookieStatus(cookie);

        if (val.GetType() == typeof(RepoMapConnect))
        {
            #region lblViewAccount Info
            string htmlAccountTable = @"<table>
    <tr>
        <td width='200px'>Username</td>
        <td>{0}</td>
    </tr>
    <tr>
        <td>Email</td>
        <td>{1}</td>
    </tr>
    <tr>
        <td>Member Level</td>
        <td>{2}</td>
    </tr>
    <tr>
        <td>Admin Trust</td>
        <td>{3}</td>
    </tr>
    <tr>
        <td>Account Balance</td>
        <td>{4}</td>
    </tr>
    <tr>
        <td>Bitcoin Balance</td>
        <td>{5}</td>
    </tr>
    <tr>
        <td>Litecoin balance</td>
        <td>{6}</td>
    </tr>
</table>";
            #endregion

            lblViewAccount.Text = string.Format(htmlAccountTable, val.map.username, val.map.email, func.memberEnumToString(val.map.memberLevel), func.adminTrustEnumToString(val.map.adminTrust), val.map.accountBalance.ToString(), func.getValueByBankValue(val.map.coinBankVal1), func.getValueByBankValue(val.map.coinBankVal2));
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
}