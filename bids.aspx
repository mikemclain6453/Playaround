<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="bids.aspx.cs" Inherits="bids" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title>Bids | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:DropDownList ID="ddlCoinType" runat="server" AutoPostBack="true">
    <asp:ListItem Value="Bitcoin" Text="Bitcoin" />
    <asp:Listitem value="Litcoin" text="Litcoin" />
</asp:DropDownList>
<br />
<table width="100%">
    <tr>
        <th width="50%">
            Sell
        </th>
        <th width="50%">
            Buy
    </tr>
    <tr>
        <td valign="top">
            <asp:DataGrid ID="dgSell" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn HeaderText="Total Coins" HeaderStyle-Font-Bold="true" DataField="coinsToBeTraded" />
                    <asp:BoundColumn HeaderText="Cost Per Coin" HeaderStyle-Font-Bold="true" DataField="perCoin" />
                </Columns>
            </asp:DataGrid>
        </td>
        <td valign="top">
            <asp:DataGrid ID="dgBuy" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundColumn HeaderText="Total Coins" HeaderStyle-Font-Bold="true" DataField="coinsToBeTraded" />
                    <asp:BoundColumn HeaderText="Cost Per Coin" HeaderStyle-Font-Bold="true" DataField="perCoin" />
                </Columns>
            </asp:DataGrid>
        </td>
    </tr>
</table>
</asp:Content>