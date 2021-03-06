﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/RegisterHostView.aspx.cs" Inherits="CheckPoint.Views.RegisterHostView" %>

<%@ Register Src="~/UserControls/MessagePanel.ascx" TagPrefix="uc1" TagName="MessagePanel" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport"   content="width=device-width, initial-scale=2"/>
<style type="text/css">
    *{
           box-sizing: border-box;
   
}
body{      background:#333333;}
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
}.list{
     margin-top:18%;
     line-height:2;
display:inline-block;
width:100%;
list-style:none;
padding:0%;
border:none;
color:white;
}
.list-item{

    position: relative;
    display: inline-block;
    width: 100%;
    left: 15%;
    text-align: left;
    padding: 0%;
    margin: 3px;
    border: none;
}
.list-item-message {
position: relative;
display: inline-block;
width: 100%;
left: 24%;
text-align: left;
padding: 0%;
margin: 0;
margin-top: 3%;
border: none;
}
.message{
   font-size: x-large;
}

.list-item-label{
    display: inline-block;
    width: 26%;
    text-align: left;
    margin: 0%;
    padding: 0%;
    font-family: sans-serif;
    font-weight: bolder;

}
.list-item-box{
    display: inline-block;
    background: bisque;
    zoom: 132%;
}

.RegHeadingslide{
      position:absolute;
      left: 21%;
      animation:slidedown 2s;
      top:5%;
}
@keyframes slidedown {
      from { top: -100%; }
      to { top: 5%; }
}


.button{
    background-color: #66cc66;
    color: white;
    font-weight: normal;
    padding-left: 2%;
    padding-right: 2%;
    font-size:x-large;
    border-radius: 6px;
    border-color: #333333;
    margin-right: 0%;
    margin-top: 0%;
    margin-left: 6%;
}
.button:hover {
border-color:gray;
}






</style>

<title></title>


</head>
<body>
<form id="form1" runat="server">

     <uc1:MessagePanel runat="server" ID="MessagePanel" />

<div id="container" class="container">
<div id="panel" class="panel">

    <div id="AppointmentHeading" class="RegHeadingslide" style="z-index:5"><img src="Images/RegisterAsHostHeading1.svg" /></div>
    
   

    <ul class="list">
        <li class="list-item">
            <asp:Label CssClass=" list-item-label" ID="lblUserName" runat="server" Text="User Name"></asp:Label>
<asp:TextBox CssClass="list-item-box" ID="txtUserName" runat="server"></asp:TextBox>

        </li>
        <li class="list-item">

            <asp:Label CssClass=" list-item-label" ID="lblPassword" runat="server" Text="Password"></asp:Label>
<asp:TextBox CssClass="list-item-box" ID="txtPassword" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">

            <asp:Label CssClass=" list-item-label" ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
<asp:TextBox CssClass="list-item-box" ID="txtFirstName" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">
            <asp:Label CssClass=" list-item-label" ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
<asp:TextBox CssClass="list-item-box" ID="txtLastName" runat="server"></asp:TextBox>

        </li>
        <li class="list-item">
            <asp:Label CssClass=" list-item-label" ID="lblEmail" runat="server" Text="Email"></asp:Label>
<asp:TextBox  CssClass="list-item-box" ID="txtEmail" runat="server"></asp:TextBox>

        </li>
        <li class="list-item">

            

<asp:Label CssClass=" list-item-label" ID="lblStreetAddress" runat="server" Text="Street Address"></asp:Label>
<asp:TextBox CssClass="list-item-box" ID="txtStreetAddress" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">

            
<asp:Label CssClass=" list-item-label" ID="lblPostalCode" runat="server" Text="Postal Code"></asp:Label>
<asp:TextBox CssClass="list-item-box" ID="txtPostalCode" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">

            <asp:Label CssClass=" list-item-label" ID="lblPhoneNumber" runat="server" Text="Phone Number"></asp:Label>
<asp:TextBox CssClass="list-item-box" ID="txtPhoneNumber" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">

<asp:Label CssClass=" list-item-label" ID="lblClientType" runat="server" Text="Client Type"></asp:Label>
<asp:TextBox CssClass="list-item-box" ID="txtClientTrype" runat="server" ReadOnly="true" >Host</asp:TextBox>

        </li>
        <li class="list-item-message">

            
<asp:Label  CssClass="message" ID="lblMessage" runat="server"></asp:Label>

        </li>
        <li  class="list-item">

<asp:Button CssClass="button" ID="btnRegisterClient" runat="server" OnClick="btnRegisterClient_Click" Text="Register" />
<asp:Button CssClass="button" ID="btnBackToHomePage" runat="server" OnClick="btnBackToHomePage_Click" Text="Back Home" />
<asp:Button CssClass="button" ID="btnGoToLogin" runat="server" OnClick="btnGoToLogin_Click" Text="Login" Visible="False" />
        </li>
    </ul>


</div>    
</div>
</form>
</body>
</html>
