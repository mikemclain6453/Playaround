using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_editAccounts : System.Web.UI.Page
{
    private RepoMapConnect RMC = new RepoMapConnect(databaseTable.PrimaryAccount);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RMC.map.id = int.Parse(Request.QueryString["id"].ToString());
            RMC.map = RMC.repo.selectData(RMC.map);
            
            txtEmail.Text = RMC.map.email;
            txtUsername.Text = RMC.map.username;
            txtPassword.Text = RMC.map.password;
            txtSalt.Text = RMC.map.salt;
            txtMemberLevel.Text = RMC.func.memberEnumToString(RMC.map.memberLevel);
            txtAdminTrust.Text = RMC.func.adminTrustEnumToString(RMC.map.adminTrust);
            txtAccountBalance.Text = RMC.map.accountBalance.ToString();
            txtCoinBankVal1.Text = RMC.map.coinBankVal1;
            txtCoinBankVal2.Text = RMC.map.coinBankVal2;
        }
    }

    protected void btnEdit_onclick(object sender, EventArgs e)
    {
        RMC.map.id = int.Parse(Request.QueryString["id"].ToString());
        RMC.map = RMC.repo.selectData(RMC.map);

        RMC.map.email = txtEmail.Text;
        RMC.map.username = txtUsername.Text;
        RMC.map.password = txtPassword.Text;
        RMC.map.salt = txtSalt.Text;
        RMC.map.memberLevel = RMC.func.memberStringToEnum(txtMemberLevel.Text);
        RMC.map.adminTrust = RMC.func.adminTrustStringToEnum(txtAdminTrust.Text);
        RMC.map.accountBalance = decimal.Parse(txtAccountBalance.Text);
        RMC.map.coinBankVal1 = txtCoinBankVal1.Text;
        RMC.map.coinBankVal2 = txtCoinBankVal2.Text;
        RMC.repo.executeData(RMC.map, sqlStatementType.Update);
    }
}