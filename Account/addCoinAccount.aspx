<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="addCoinAccount.aspx.cs" Inherits="Account_addCoinAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title>Create Coin Account | Administration | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p><asp:Button runat="server" Text="Add Bitcoin Bank" ID="btnBitcoinBank" OnClick="btnBitcoinBank_onclick" /></p>
    <p><asp:Button runat="server" Text="Add Litecoin Bank" ID="btnLitecoinBank" OnClick="btnLitecoinBank_onclick" /></p>
</asp:Content>

