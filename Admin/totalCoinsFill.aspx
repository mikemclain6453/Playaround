<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="totalCoinsFill.aspx.cs" Inherits="Admin_totalCoinsFill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Fill Total Coins | Administration | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button runat="server" ID="btnFillCoinsList" Text="Fill Total Coins" OnClick="btnFillCoinsList_onclick" />
</asp:Content>

