using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        functionality func = new functionality();
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];

        dynamic val = func.cookieStatus(cookie);

        if (val.GetType() == typeof(RepoMapConnect))
        {
            if (val.map.username != "Divinityfound")
            {
                Response.Redirect("../Default.aspx");
            }
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }
}
