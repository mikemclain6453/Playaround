<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Install.aspx.cs" Inherits="Install_Install" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Button runat="server" Text="Install --- Update" ID="btnInstallUpdate" OnClick="installUpdate_onclick" />
    <br />
    <asp:Button runat="server" Text="Truncate" ID="btnTruncate" OnClick="truncate_onclick" />
    <br />
    <asp:Button runat="server" Text="Delete" ID="btnDelete" OnClick="delete_onclick" />
    </div>
    </form>
</body>
</html>
