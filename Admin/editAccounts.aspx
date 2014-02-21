<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="editAccounts.aspx.cs" Inherits="Admin_editAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Edit Accounts | Administration | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>Username</td>
            <td><asp:TextBox runat="server" ID="txtUsername" /></td>
        </tr>
        <tr>
            <td>Email</td>
            <td><asp:TextBox runat="server" ID="txtEmail" /></td>
        </tr>
        <tr>
            <td>Password (Encrypted)</td>
            <td><asp:TextBox runat="server" ID="txtPassword" /></td>
        </tr>
        <tr>
            <td>Salt</td>
            <td><asp:TextBox runat="server" ID="txtSalt" /></td>
        </tr>
        <tr>
            <td>Member Level</td>
            <td><asp:TextBox runat="server" ID="txtMemberLevel" /></td>
        </tr>
        <tr>
            <td>Admin Trust</td>
            <td><asp:TextBox runat="server" ID="txtAdminTrust" /></td>
        </tr>
        <tr>
            <td>Account Balance</td>
            <td><asp:TextBox runat="server" ID="txtAccountBalance" /></td>
        </tr>
        <tr>
            <td>Bitcoin String</td>
            <td><asp:TextBox runat="server" ID="txtCoinBankVal1" /></td>
        </tr>
        <tr>
            <td>Litecoin String</td>
            <td><asp:TextBox runat="server" ID="txtCoinBankVal2" /></td>
        </tr>
    </table>
    <asp:Button runat="server" Text="Edit" ID="btnEdit" OnClick="btnEdit_onclick" />
</asp:Content>

