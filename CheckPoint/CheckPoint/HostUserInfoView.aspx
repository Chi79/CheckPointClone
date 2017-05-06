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

.parent{
    width: 100%;
    height: 500px;
    background: #333333;
    margin: auto;
    padding: 10px;
}
.container1{
    float:left;
    width: 46%;
    height: 485px;
    margin-left: 3%;
    margin-top: 6%;
 

    background-color: #333333;
    border: #66cc66;
    border-width: 20px;
    border-style: solid;
    border-radius: 36px;
}
.container2{
    width: 46%;
    height: 485px;
    margin-left: 51%;
    margin-top: 6%;
  

    background-color: #333333;
    border: #66cc66;
    border-width: 20px;
    border-style: solid;
    border-radius: 36px;
}

.HostInfoHeaderDiv{

    position: relative;
    width: 100%;
    text-align: center;
    padding-right: 8%;
    margin-top: 5%;
    margin-bottom: 4%;

}
.HostInfoDiv{

    position: relative;
    display: inline-block;
    width: 77%;
    left: 8%;
    text-align: left;
    margin-top: 3%;
}
.UserInfoHeaderDiv{

    position: relative;
    width: 100%;
    text-align: center;
    margin-top: 6%;
    margin-bottom: 7%;

}
.UserInfoDiv{

    position: relative;
    display: inline-block;
    width: 80%;
    left: 8%;
    text-align: left;


}
.button1{

    margin:0 auto;
    display: table;
    margin-top:20%
}
.button2{

    margin:0 auto;
    display: table;
    margin-top:15%

}
.button3{

    position: relative;
    display: inline-block;
    margin-top: 7%;
    right: 3.8%;

}


.RegHeadingslide{
      position:absolute;
      left: 32%;
      animation:slidedown 2s;
      top: 3%;
}
@keyframes slidedown {
      from { top: -100%; }
      to { top: 3%; }
}

.HostInfoHeader{
    font-family: sans-serif;
    font-size: xx-large;
    font-weight: 900;
    color:white;
}
.HostInfo{
    font-size: larger;
    font-family: sans-serif;
    color:white;
}
.UserInfoHeader{
    font-family: sans-serif;
    font-size: xx-large;
    font-weight: 900;
    color:white;
}
.UserInfo{
    font-size: larger;
    font-family: sans-serif;
    color:white;
}

.button{       
    background-color: #66cc66;
    color: white;
    font-weight: normal;
    padding-left: 3%;
    padding-right: 3%;
    font-size: x-large;
    border-radius: 6px;
    border-color: #333333;
}

.button:hover {
border-color:gray;
}



</style>

<title></title>


</head>
<body>
<form id="form1" runat="server">

<div id="AppointmentHeading" class="RegHeadingslide" style="z-index:5"><img src="Images/BeforeYouRegisterHeading1.svg" /></div>

<div id="panel1" class="parent">


<div id="container" class="container1">

 
        <div class ="HostInfoHeaderDiv">   
        <asp:Label CssClass="HostInfoHeader" ID="lblHostInfoHeading" runat="server"></asp:Label>
        </div>  
       

        <div class="HostInfoDiv">        
        <asp:Label CssClass="HostInfo" ID="lblHostInfo" runat="server"></asp:Label>
          
        <div class="button1">
        <asp:Button CssClass="button" ID="btnRegisterHost" runat="server" OnClick="btnRegisterHost_Click" Text="Register as Host" />
        </div>

        </div>

</div>

<div id="container2" class="container2">


        <div class="UserInfoHeaderDiv">        
        <asp:Label CssClass="UserInfoHeader" ID="lblUserInfoHeading" runat="server"></asp:Label>
        </div>

        <div class="UserInfoDiv">        
        <asp:Label CssClass="UserInfo" ID="lblUserInfo" runat="server"></asp:Label>

        <div class="button2">
        <asp:Button CssClass="button" ID="btnRegisterUser" runat="server" OnClick="btnRegisterUser_Click" Text="Register as User" Visible="true" />
        </div>

        </div>

</div>

</div>  
  
     <div class="button3">
     <asp:Button CssClass="button" ID="btnBackToHomePage" runat="server" OnClick="btnBackToHomePage_Click" Text="Back Home" />
     </div>

</form>
</body>
</html>
