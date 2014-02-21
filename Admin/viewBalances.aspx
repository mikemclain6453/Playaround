<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="viewBalances.aspx.cs" Inherits="Admin_viewBalances" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>View Balances | Administration | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:DataGrid ID="dgBalanceView" runat="server" AllowSorting="true" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundColumn HeaderText="ID" HeaderStyle-Font-Bold="true" DataField="id" SortExpression="id" />
        <asp:BoundColumn HeaderText="Coin Type" HeaderStyle-Font-Bold="true" DataField="CT" SortExpression="CT" />
        <asp:BoundColumn HeaderText="Account String" HeaderStyle-Font-Bold="true" DataField="coinBankVal" SortExpression="coinBankVal" />
        <asp:BoundColumn HeaderText="Account Balance" HeaderStyle-Font-Bold="true" DataField="totalCoinString" SortExpression="totalCoinString" />
    </Columns>
</asp:DataGrid>
</asp:Content>

