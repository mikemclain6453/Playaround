using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("SessionCookie");
        cookie = Request.Cookies["SessionCookie"];
        Control menuType = new Control();
        string startUrl;

        if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("/Account/"))
        {
            startUrl = "../menus/";
        }
        else
        {
            startUrl = "menus/";
        }

        if (cookie != null)
        {
            menuType = Page.LoadControl(startUrl + "loggedIn.ascx");
        }
        else
        {
            menuType = Page.LoadControl(startUrl + "loggedOut.ascx");
        }
        phMenu.Controls.Add(menuType);
    }
}
