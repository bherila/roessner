<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="admin_AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log in | Elix CMS</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Log in </h1>
        <p>Please log in to manage this web site</p>
        <table>
            <tr><td>Username:</td><td><asp:TextBox runat="server" ID="m_username" /></td></tr>
            <tr><td>Password:</td><td><asp:TextBox runat="server" ID="m_password" TextMode="Password" /></td></tr>
            <tr><td>&nbsp;</td><td><asp:Button runat="server" ID="m_submit" Text="Submit" /></tr>
        </table>
        <hr />
        <p><i>Elix CMS</i></p>
    </form>
</body>
</html>
