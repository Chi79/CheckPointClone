<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HostUserInfoView.aspx.cs" Inherits="CheckPoint.Views.HostUserInfoView" %>


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
    width: 82%;
    height: 570px;
    margin-left: 8%;
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
     margin-top:6%;
     line-height:2;
display:inline-block;
width:100%;
list-style:none;
padding:0%;
border:none;
color:white;
}
.list-item{

position:relative;
display:inline-block;
width:100%;
left:15%;
text-align:left;
padding:0%;
margin:0;
margin-top: 2%;
border:none;
}
.list-item-message{

    position: relative;
    display: inline-block;
    width: 70%;
    left: 15%;
    text-align: left;
    padding: 0%;
    margin: 0;
    margin-top: 2%;
    border: none;
}
.list-item-HostInfoHeader{

position:relative;
display:inline-block;
width:100%;
left:15%;
text-align:left;
padding:0%;
margin:0;
border:none;
}
.list-item-HostInfo{

position: relative;
display: inline-block;
width: 77%;
left: 15%;
text-align: left;
padding: 0%;
margin: 0;
border: none;
}
.list-item-UserInfoHeader{

position:relative;
display:inline-block;
width:100%;
left:15%;
text-align:left;
padding:0%;
margin:0;
border:none;
}
.list-item-UserInfo{

position: relative;
display: inline-block;
width: 79%;
left: 15%;
text-align: left;
padding: 0%;
margin: 0;
border: none;
}


.list-item-label{
    display:inline-block;
    width:30%;
    text-align:left;
    margin:0%;
    padding:0%;

}
.list-item-box{
    display:inline-block;
    background:white;
}

.RegHeadingslide{
      position:absolute;
      left: 32%;
      animation:slidedown 3s;
      top:5%;
}
@keyframes slidedown {
      from { top: -100%; }
      to { top: 5%; }
}
.Message{
    font-family: sans-serif;
    font-size: larger;
}
.HostInfoHeader{
    font-family: sans-serif;
    font-size: x-large;
    font-weight: 900;
}
.HostInfo{
    font-size: larger;
    font-family: sans-serif;
}
.UserInfoHeader{
    font-family: sans-serif;
    font-size: x-large;
    font-weight: 900;
}
.UserInfo{
    font-size: larger;
    font-family: sans-serif;
}


.button{
        
            background-color:#66cc66;
		    color:white;
		    font-weight:normal;
            padding-left:2%;
            padding-right:2%;
		    font-size:medium;	
		    border-radius: 6px;
            border-color:#333333;
            margin-right: 4%;
            margin-left: 5%;
}
.button:hover {
border-color:gray;
}






</style>

<title></title>


</head>
<body>
<form id="form1" runat="server">
<div id="container" class="container">
<div id="panel" class="panel">

    <div id="AppointmentHeading" class="RegHeadingslide" style="z-index:5"><img src="Images/BeforeYouRegisterHeading1.svg" /></div>
    

    <ul class="list">

        <li class="list-item-message">        
        <asp:Label CssClass="Message"  ID="lblMessage" runat="server" ></asp:Label>
        </li>

        <li class="list-item-HostInfoHeader">        
        <asp:Label CssClass="HostInfoHeader" ID="lblHostInfoHeading" runat="server"></asp:Label>
        </li>

        <li class="list-item-HostInfo">        
        <asp:Label CssClass="HostInfo" ID="lblHostInfo" runat="server"></asp:Label>
        </li>

        <li class="list-item-UserInfoHeader">        
        <asp:Label CssClass="UserInfoHeader" ID="lblUserInfoHeading" runat="server"></asp:Label>
        </li>

        <li class="list-item-UserInfo">        
        <asp:Label CssClass="UserInfo" ID="lblUserInfo" runat="server"></asp:Label>
        </li>


        <li  class="list-item">
<asp:Button CssClass="button" ID="btnRegisterHost" runat="server" OnClick="btnRegisterHost_Click" Text="Register as Host" />
<asp:Button CssClass="button" ID="btnBackToHomePage" runat="server" OnClick="btnBackToHomePage_Click" Text="Back Home" />
<asp:Button CssClass="button" ID="btnRegisterUser" runat="server" OnClick="btnRegisterUser_Click" Text="Register as User" Visible="true" />
        </li>



    </ul>


</div>    
</div>
</form>
</body>
</html>
