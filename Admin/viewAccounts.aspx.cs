using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_viewAccounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sqlFunction<PrimaryAccountMap> sqlFunc = new sqlFunction<PrimaryAccountMap>();
            SqlCommand command = new SqlCommand("SELECT * FROM primaryAccount;");
            DataTable dt = sqlFunc.dbActionSet(command,databaseAction.Read);
            Session["tableData"] = dt;
            dgAccountsView.DataSource = dt;
            dgAccountsView.DataBind();
        }
    }
}