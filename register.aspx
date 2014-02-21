<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title>Register | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table>
            <tr>
                <td>Username:</td>
                <td><asp:TextBox runat="server" ID="txtUsername" /></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td><asp:TextBox runat="server" ID="txtEmail" /></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox runat="server" ID="txtPass" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>Repeat Password:</td>
                <td><asp:TextBox runat="server" ID="txtPass2" TextMode="Password" /></td>
            </tr>
        </table>
        <asp:Button runat="server" Text="Register" ID="btnRegister" onclick="btnRegister_onclick" />
        <p><asp:Label runat="server" ID="lblError" /></p>
    </div>
</asp:Content>

