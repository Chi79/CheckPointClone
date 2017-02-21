<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="CheckPoint.Views.LoginView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/login.css" rel="stylesheet" type="text/css" />
    <title>CheckPoint System Login</title>

</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
    <div id="logo" ></div>
        <asp:Label ID="lblUserName" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <asp:Button ID="btnLogIn" runat="server" Text="Log In"  CssClass="btnLogIn" OnClick="btnLogIn_Click"/>
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
