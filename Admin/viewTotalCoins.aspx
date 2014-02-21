<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="viewTotalCoins.aspx.cs" Inherits="Admin_viewTotalCoins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>View Total Coins | Administration | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:DataGrid ID="dgTotalCoins" runat="server" AllowSorting="true" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundColumn HeaderText="ID" HeaderStyle-Font-Bold="true" DataField="id" SortExpression="id" />
        <asp:BoundColumn HeaderText="Total String Value" HeaderStyle-Font-Bold="true" DataField="totalCoinString" SortExpression="totalCoinString" />
        <asp:BoundColumn HeaderText="Quantity" HeaderStyle-Font-Bold="true" DataField="amount" SortExpression="amount" />
    </Columns>
</asp:DataGrid>
</asp:Content>

