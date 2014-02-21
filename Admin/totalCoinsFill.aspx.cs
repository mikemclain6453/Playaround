using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_totalCoinsFill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnFillCoinsList_onclick(object sender, EventArgs e)
    {
        RepoMapConnect RMC = new RepoMapConnect(databaseTable.TotalCoins);
        for (decimal i = 1000.000m; i < 1000.001m; i += 0.001m)
        {
            RMC.map.totalCoinString = RMC.func.randomCharacterSet(30);
            RMC.map.amount = i;
            RMC.repo.executeData(RMC.map, sqlStatementType.Insert);
        }
    }
}