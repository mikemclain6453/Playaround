<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="viewAccounts.aspx.cs" Inherits="Admin_viewAccounts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>View Accounts | Administration | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:DataGrid ID="dgAccountsView" runat="server" AllowSorting="true" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundColumn HeaderText="ID" HeaderStyle-Font-Bold="true" DataField="id" SortExpression="id" />
        <asp:BoundColumn HeaderText="Username" HeaderStyle-Font-Bold="true" DataField="username" SortExpression="username" />
        <asp:BoundColumn HeaderText="Email" HeaderStyle-Font-Bold="true" DataField="email" SortExpression="email" />
        <asp:BoundColumn HeaderText="Account Balance" HeaderStyle-Font-Bold="true" DataField="accountBalance" SortExpression="accountBalance" />
        <asp:BoundColumn HeaderText="Bitcoin" HeaderStyle-Font-Bold="true" DataField="coinBankVal1" SortExpression="coinBankVal1" />
        <asp:BoundColumn HeaderText="Litecoin" HeaderStyle-Font-Bold="true" DataField="coinBankVal2" SortExpression="coinBankVal2" />
    </Columns>
</asp:DataGrid>
</asp:Content>

