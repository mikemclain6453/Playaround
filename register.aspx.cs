using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_onclick(object sender, EventArgs e)
    {
        RepoMapConnect RMC = new RepoMapConnect(databaseTable.PrimaryAccount);
        PrimaryAccountMap map = new PrimaryAccountMap(true);
        if (txtPass.Text == txtPass2.Text && txtUsername.Text != "Divinityfound")
        {
            map.email = txtEmail.Text;
            map.username = txtUsername.Text;
            map.password = RMC.func.hashedValue(txtPass.Text + map.salt);
            RMC.map = map;
            RMC.repo.executeData(RMC.map, sqlStatementType.Insert);
            RMC.func.sendemail("jakethewizard04@gmail.com", map.email, "Coins Share || Account Created", string.Format(@"Welcome {0},<br /><br />
Your account has been created.<br />
<br />
Username: {0}<br />
Password: {1}<br />
<br />
Your account currently is unverified. In order to verify your account, you must make a deposit in Bitcoins, Litecoins, or Credit Card.<br />
<br />
Any amount of bitcoins, litecoins will do. A minimum of $5.00 USD must be deposited to be verified.<br />
<br />
If you did not create this account, simply ignore this email.<br />
<br />
Thank you for joining us.<br />
<br />
- Coins Share Team", map.username, txtPass.Text));
            lblError.Text = "Account created. Login anytime.";
        }
        else
        {
            lblError.Text = "Passwords do not match. Please try again.";
        }

    }
}