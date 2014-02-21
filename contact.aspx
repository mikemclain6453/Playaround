<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title>Contact | Coins Share</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <td>Topic:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlTopic">
                    <asp:ListItem Selected Text="Other" Value="Other" />
                    <asp:ListItem Text="Persinal" Value="Persinal" />
                    <asp:ListItem Text="Business" Value="Business" />
                    <asp:ListItem Text="Dispute" Value="Dispute" />

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Urgency:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlUrgency">
                    <asp:ListItem Selected Text="Low" Value="Low" />
                    <asp:ListItem Text="Medium" Value="Medium" />
                    <asp:ListItem Text="High" Value="High" />
                    <asp:ListItem Text="Extreme" Value="Extreme" />
                    <asp:ListItem Text="Emergency" Value="Emergency" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Subject:</td>
            <td><asp:TextBox runat="server" ID="txtSubject" /></td>
        </tr>
        <tr>
            <td>Email:</td>
            <td><asp:TextBox runat="server" ID="txtEmail" /></td>
        </tr>
    </table>

    <p>Message:</p>
    <p><asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" style="width: 600px;height: 200px;" /></p>
    <p><asp:Button runat="server" Text="Send Message" ID="btnSendMessage" OnClick="btnSendMessage_onclick" /></p>
    <p><asp:Label runat="server" ID="lblError" /></p>
</asp:content>