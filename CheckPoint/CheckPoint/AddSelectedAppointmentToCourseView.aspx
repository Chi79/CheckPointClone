<%@ Page Language="C#" MasterPageFile="~/HostMaster.Master" AutoEventWireup="true" CodeBehind="AddSelectedAppointmentToCourseView.aspx.cs" Inherits="CheckPoint.Views.AddSelectedAppointmentToCourseView" %>

<%@ Register Src="~/UserControls/AppointmentCreator.ascx" TagPrefix="uc1" TagName="AppointmentCreator" %>

<%@ Register Src="~/UserControls/SmallMessagePanel.ascx" TagPrefix="uc1" TagName="SmallMessagePanel" %>





<asp:Content ContentPlaceHolderID="head" runat="server">


<style type="text/css">

.list1{
    position:fixed;
top:10%;
left:30%;
list-style:none;
width:100%;
padding:0%;
margin:0;
border:none;
}
.list1-item{
position:fixed;
top:90%;
left:30%;
list-style:none;
width:100%;
padding:0%;
margin:0;
border:none;
}

@-webkit-keyframes flashingbutton{
    from{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:5px;  -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333; }
}
.button{
    color:white;

    border-radius: 5px;
    border-width:0px;
    border-color:darkgreen;
    margin-right:1%;
    padding-top:0.5%;
    padding-bottom: 0.5%;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    font-weight: 600;
    background-image:url(/Images/buttonshade1.png);
}
.button:hover {
        border-radius: 0px;
        -webkit-animation: flashingbutton;
        -webkit-animation-duration: 2s;
        -webkit-animation-iteration-count: infinite;
}
.logoslide{
      position:absolute;
      left: 85%;
      top:  -8%;
      animation: slideleft 2s ;
}
@keyframes slideleft {
      from { left: -100%; }
      to { left: 85%; }
}
.Headerslide{
      position:absolute;
      left: 6%;
      animation:slidedown 4s;
      top:5px;
}
@keyframes slidedown {
     from { top: -200px; }
      to { top: 5px; }
}




</style>

<title></title>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">


    <div id="logo" class="logoslide" style="z-index:5"><img src="Images/logo4.png" /></div>

    <div id="AppointmentHeading" class="Headerslide" style="z-index:5"><img src="Images/AddAppointmentToCourseHeading1.svg" /></div>

    <uc1:SmallMessagePanel runat="server" id="SmallMessagePanel" />
        
<ul class="list1">
    <li class="list1-item">
 <uc1:AppointmentCreator runat="server" ID="AppointmentCreator" />
        </li >
    </ul>

</asp:Content>

