using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_editBalances : System.Web.UI.Page
{
    private RepoMapConnect RMC = new RepoMapConnect(databaseTable.CoinBank);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RMC.map.id = int.Parse(Request.QueryString["id"].ToString());
            RMC.map = RMC.repo.selectData(RMC.map);
            txtCoinBankVal.Text = RMC.map.coinBankVal;
            txtValueString.Text = RMC.map.totalCoinString;
            lblCoinType.Text = RMC.func.coinTypeEnumToString(RMC.map.CT);
            lblRealAmount.Text = RMC.func.getValueByCoinString(RMC.map.totalCoinString).ToString();
        }
    }

    protected void btnEditBalance_onclick(object sender, EventArgs e)
    {
        RMC.map.id = int.Parse(Request.QueryString["id"].ToString());
        RMC.map = RMC.repo.selectData(RMC.map);
        RMC.map.coinBankVal = txtCoinBankVal.Text;
        RMC.map.totalCoinString = txtValueString.Text;
        RMC.repo.executeData(RMC.map, sqlStatementType.Update);
    }
}