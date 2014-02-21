using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class bids : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlFunction<CoinOrderMap> sqlFunc = new sqlFunction<CoinOrderMap>();
        SqlCommand command1 = new SqlCommand(string.Format("SELECT * FROM coinOrder WHERE CT = '{0}' AND OT = 'Sell' ORDER BY perCoin ASC;",ddlCoinType.SelectedValue.ToString()));
        DataTable dt1 = sqlFunc.dbActionSet(command1, databaseAction.Read);
        dgSell.DataSource = dt1;
        dgSell.DataBind();

        SqlCommand command2 = new SqlCommand(string.Format("SELECT * FROM coinOrder WHERE CT = '{0}' AND OT = 'Buy' ORDER BY perCoin ASC;", ddlCoinType.SelectedValue.ToString()));
        DataTable dt2 = sqlFunc.dbActionSet(command2, databaseAction.Read);
        dgBuy.DataSource = dt2;
        dgBuy.DataBind();
    }
}