using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_onclick(object sender, EventArgs e)
    {
        RepoMapConnect RMCaccount = new RepoMapConnect(databaseTable.PrimaryAccount);
        PrimaryAccountMap PAM = new PrimaryAccountMap();
        PAM.username = txtUsername.Text;
        RMCaccount.map = RMCaccount.repo.selectData(PAM);

        if (RMCaccount.map.password == RMCaccount.func.hashedValue(txtPassword.Text + RMCaccount.map.salt))
        {
            SessionsMap map = new SessionsMap(RMCaccount.map.id);
            SessionsRepository repo = new SessionsRepository();
            repo.executeData(map, sqlStatementType.Insert);
            HttpCookie cookie = RMCaccount.func.createcookie(map.sessionVal, "SessionCookie");
            Response.Cookies.Add(cookie);

            Response.Redirect("Account/view.aspx");
        }
    }

}