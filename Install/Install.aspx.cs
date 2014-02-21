using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using data.construct;

public partial class Install_Install : System.Web.UI.Page
{
    private dbConstruct dbC = new dbConstruct();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void installUpdate_onclick(object sender, EventArgs e)
    {
        dbC.buildUpdateDB();
    }

    protected void truncate_onclick(object sender, EventArgs e)
    {
        dbC.truncateDB();
    }

    protected void delete_onclick(object sender, EventArgs e)
    {
        dbC.dropTableDB();
    }
}