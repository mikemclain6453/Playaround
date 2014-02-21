﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_viewTotalCoins : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sqlFunction<PrimaryAccountMap> sqlFunc = new sqlFunction<PrimaryAccountMap>();
            SqlCommand command = new SqlCommand(string.Format("SELECT * FROM totalCoins WHERE amount > {0} AND amount < {1} ORDER BY id;", Request.QueryString["min"].ToString(), Request.QueryString["max"].ToString()));
            DataTable dt = sqlFunc.dbActionSet(command, databaseAction.Read);
            Session["tableData"] = dt;
            dgTotalCoins.DataSource = dt;
            dgTotalCoins.DataBind();
        }
    }
}