using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSendMessage_onclick(object sender, EventArgs e)
    {
        functionality func = new functionality();
        string subject;
        if (ddlUrgency.SelectedValue.ToString() == "High")
        {
            subject = "URGENT!!! --- " + ddlUrgency.SelectedValue.ToString() + " | " + ddlTopic.SelectedValue.ToString() + ": " + txtSubject.Text;
        }
        else
        {
            subject = ddlUrgency.SelectedValue.ToString() + " | " + ddlTopic.SelectedValue.ToString() + ": " + txtSubject.Text;
        }
        string message = Regex.Replace(txtMessage.Text, Environment.NewLine, "<br />") + "<br /><br />" + txtEmail.Text;
        func.sendemail("jakethewizard04@gmail.com", "jacob@mathisonenterprises.com", subject, message);
        lblError.Text = "Email successfully sent.";
    }
}