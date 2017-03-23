<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterClientView.aspx.cs" Inherits="CheckPoint.Views.RegisterClientView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<style type="text/css">

.container{
    width: 42%;
    height: 570px;
    margin-left: 27%;
    margin-top: 2%;
    background-color: #333333;
    border: #66cc66;
    border-width: 20px;
    border-style: solid;
    border-radius:36px;
}
.panel{
    position:relative;
}
#lblUserName{
    position: absolute;
    top:5.2em;
    left:4em;
    color:white;
}
#txtUserName{
    position: absolute;
    top:6em;
    left:16em;
}
#lblPassword{
    position: absolute;
    top:10.2em;
    left:4em;
    color:white;
}
#txtPassword{
    position: absolute;
    top:12em;
    left:16em;
}
#lblFirstName{
    position: absolute;
    top:8.5em;
    left:4em;
    color:white;
}
#txtFirstName{
    position: absolute;
    top:9.8em;
    left:16em;
}
#lblLastName{
    position: absolute;
    top:6.8em;
    left:4em;
    color:white;
}
#txtLastName{
    position: absolute;
    top:7.9em;
    left:16em;
}
#lblEmail{
    position: absolute;
    top:11.9em;
    left:4em;
    color:white;
}
#txtEmail{
    position: absolute;
    top:14em;
    left:16em;
}
#lblStreetAddress{
    position: absolute;
    top:13.6em;
    left:4em;
    color:white;
}
#txtStreetAddress{
    position: absolute;
    top:16em;
    left:16em;
}
#lblPostalCode{
    position: absolute;
    top:16.8em;
    left:4em;
    color:white;
}
#txtPostalCode{
    position: absolute;
    top:20em;
    left:16em;
}
#lblPhoneNumber{
    position: absolute;
    top:15.2em;
    left:4em;
    color:white;
}
#txtPhoneNumber{
    position: absolute;
    top:18em;
    left:16em;
}
#lblClientType{
    position: absolute;
    top:18.5em;
    left:4em;
    color:white;
}
#ddlClientType{
    position: absolute;
    top:22.5em;
    left:16em;
}
#lblMessage{
    position: absolute;
    top:27em;
    left:4em;
    color:white;
}
#btnRegisterClient{
    position: absolute;
    top:25em;
    left:16em;
    width:145px;
}
#btnBackToHomePage{
    position: absolute;
    top:27em;
    left:16em;
    width:145px;
}
#btnGoToLogin{
    position: absolute;
    top:29em;
    left:16em;
    width:145px;
}



</style>

<title></title>


</head>
<body>
<form id="form1" runat="server">
<div id="container" class="container">
<div id="panel" class="panel">
    

<asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
<asp:TextBox ID="txtUserName" runat="server">Sting</asp:TextBox>

<asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
<asp:TextBox ID="txtPassword" runat="server">Lambda</asp:TextBox>

<asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
<asp:TextBox ID="txtFirstName" runat="server">Sting</asp:TextBox>

<asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
<asp:TextBox ID="txtLastName" runat="server">Stung</asp:TextBox>

<asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
<asp:TextBox ID="txtEmail" runat="server">Sting@Stung.com</asp:TextBox>

<asp:Label ID="lblStreetAddress" runat="server" Text="Street Address:"></asp:Label>
<asp:TextBox ID="txtStreetAddress" runat="server">goldenfields</asp:TextBox>

<asp:Label ID="lblPostalCode" runat="server" Text="Postal Code:"></asp:Label>
<asp:TextBox ID="txtPostalCode" runat="server">3714</asp:TextBox>

<asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
<asp:TextBox ID="txtPhoneNumber" runat="server">87654321</asp:TextBox>

<asp:Label ID="lblClientType" runat="server" Text="Client Type:"></asp:Label>

<asp:DropDownList ID="ddlClientType" runat="server" Height="16px" Width="66px">
<asp:ListItem Value="0">User</asp:ListItem>
<asp:ListItem Value="1">Host</asp:ListItem>
</asp:DropDownList>
  
<asp:Label ID="lblMessage" runat="server"></asp:Label>

<asp:Button ID="btnRegisterClient" runat="server" OnClick="btnRegisterClient_Click" Text="Register" />
<asp:Button ID="btnBackToHomePage" runat="server" OnClick="btnBackToHomePage_Click" Text="Back Home" />
<asp:Button ID="btnGoToLogin" runat="server" OnClick="btnGoToLogin_Click" Text="Login" Visible="False" />


</div>    
</div>
</form>
</body>
</html>
