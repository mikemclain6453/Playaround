<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="editBalances.aspx.cs" Inherits="Admin_editBalances" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Edit Balances | Administration | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>Cointype</td>
            <td><asp:Label runat="server" ID="lblCoinType" /></td>
        </tr>
        <tr>
            <td>Coin Bank Value</td>
            <td><asp:TextBox runat="server" ID="txtCoinBankVal" /></td>
        </tr>
        <tr>
            <td>Value String</td>
            <td><asp:TextBox runat="server" ID="txtValueString" /><br />Translation: <asp:Label runat="server" ID="lblRealAmount" /></td>
        </tr>
    </table>
    <asp:Button runat="server" Text="Edit Balance" ID="btnEditBalance" OnClick="btnEditBalance_onclick" />
</asp:Content>

