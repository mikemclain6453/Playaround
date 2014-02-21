<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title>Login | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
            <td>Username:</td>
            <td><asp:TextBox runat="server" ID="txtUsername" /></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><asp:TextBox runat="server" ID="txtPassword" TextMode="Password" /></td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_onclick" Text="Login" />
</asp:Content>