using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        functionality func = new functionality();
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];
        if (cookie != null)
        {
            RepoMapConnect RMC = new RepoMapConnect(databaseTable.Sessions);
            RMC.map.sessionVal = cookie.Value.ToString();
            RMC.repo.executeData(RMC.map, sqlStatementType.Delete);

            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
        }

        Response.Redirect("../Default.aspx");
    }
}