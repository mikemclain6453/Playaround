<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="placeOrder.aspx.cs" Inherits="Account_placeOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title>Place Order | Coins Share</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <b>WARNING: IF YOUR OFFER IS MET, THEN IT WILL BE AUTOCOMPLETED within a few hours.</b>
    <table>
        <tr>
            <td width="150px">Coin Type:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCoinType" Width="100px">
                    <asp:ListItem Selected Text="Bitcoin" Value="Bitcoin" />
                    <asp:ListItem Text="Litecoin" Value="Litecoin" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Order Type:</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlBuySell" Width="100px">
                    <asp:ListItem Selected Text="Buy" Value="Buy" />
                    <asp:ListItem Text="Sell" Value="Sell" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top">Quantity</td>
            <td><asp:TextBox runat="server" ID="txtQuantity" OnTextChanged="txtOffer_textchange" AutoPostBack="true" />
            <asp:Button runat="server" Text="Calculate Quantity Value" ID="btnCalculateQuantityValue" OnClick="btnCalculateQuantityValue_onclick" /></td>
        </tr>
        <tr>
            <td valign="top">Offer per Coin:</td>
            <td>
                <asp:TextBox runat="server" ID="txtOffer" OnTextChanged="txtOffer_textchange" AutoPostBack="true" /><br />
                <asp:Button runat="server" Text="Calculate Market Value" ID="btnCalculateMarketValue" OnClick="btnCalculateMarketValue_onclick" />
            </td>
        </tr>
        <tr>
            <td>Value of Contract</td>
            <td><asp:Label runat="server" Text="$0.00" ID="lblTotalOffered" /></td>
        </tr>
    </table>
    <asp:Button runat="server" Text="Submit Order" ID="btnSubmitOrder" OnClick="btnSubmitOrder_onclick" /><br />
    <asp:Button runat="server" Text="Auto-Buy 1" ID="btnAutoBuyOne" OnClick="btnAutoBuyOne_onclick" /><br />
    <asp:Button runat="server" Text="Auto-Sell 1" ID="btnAutoSellOne" OnClick="btnAutoSellOne_onclick" /><br />
    <asp:Label runat="server" ID="lblErrorInfo" />
</asp:Content>

