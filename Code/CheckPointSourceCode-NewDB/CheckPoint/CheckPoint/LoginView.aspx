<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="CheckPoint.Views.LoginView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/login.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <title>CheckPoint System Login</title>
    "Scripts/jquery-ui-1.10.3.min.js"
</head>
<body>
    <form id="form1" runat="server" defaultFocus="txtUserName" DefaultButton="btnLogin">>
    <div id="container">
    <div id="logo" ></div>
        <asp:Label ID="lblUserName" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtUserName" runat="server" TabIndex="0"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <asp:Button ID="btnLogIn" runat="server" Text="Log In"  CssClass="btnLogIn" OnClick="btnLogIn_Click" TabIndex="1"/>
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
