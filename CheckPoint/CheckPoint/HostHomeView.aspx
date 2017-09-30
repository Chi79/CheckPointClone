<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="HostHomeView.aspx.cs"  Inherits="CheckPoint.Views.HostHomeView"  EnableEventValidation="false"  MasterPageFile="~/HostMaster.Master" %>

<%@ Register Src="~/UserControls/AppointmentGridView.ascx" TagPrefix="uc1" TagName="AppointmentGridView" %>
<%@ Register Src="~/UserControls/AppointmentGridViewHeader.ascx" TagPrefix="uc1" TagName="AppointmentGridViewHeader" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc1" TagName="DatePicker" %>
<%@ Register Src="~/UserControls/MessagePanel.ascx" TagPrefix="uc1" TagName="MessagePanel" %>



<asp:Content ContentPlaceHolderID="head" runat="server">


<title></title>

<style type="text/css">
  

.Panel1{
    position:relative; 
    height:470px; 
    width:100%;
    overflow-y:scroll;
    overflow-x: hidden;
    right:1%;
    border-bottom-left-radius: 10px;
}
.Panel2{
    height:100%;
    width:100%;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    padding-bottom: 12px;
    position:relative;
    right:1%;
}

.container{
      position:relative;
      right:0%;
      animation: slideright 2s;
}
@keyframes slideright {
      from { right: -100%; }
      to { right: 0%;}
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
.Appointmentslide{
      position:absolute;
      top: -7%;
      left: 2%;
      animation:slidedown 4s;
      top:-7%;
}
@keyframes slidedown {
      from { top: -100%; }
      to { top: -7%; }
}
.buttons0{
      float:left;
      margin-left: 0%;
      z-index:3;
      margin-top:0.5%;
}
.buttons1{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
}
.buttons2{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
}
.buttons4{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
}
.buttons5{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
}
.buttons6{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
}
@keyframes buttonsup {
      from { top: 300%; }
      to { top: 0%;}
}
.buttonscontainer {
        position: static;
        top: 10px;
        height: auto;
        width: auto;
        overflow:hidden;
}
.buttonslider{
    position:relative;
    animation:buttonsup;
}

.navButtons{
    border-radius: 5px;
    border-width:0px;
    border-color:darkgreen;
    padding-bottom: 1%;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    font-weight: 600;
    background-image:url(/Images/buttonshade1.png);
   
}
.navButtons:hover{
    border-radius:0px;
    -webkit-animation:flashingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
@-webkit-keyframes flashingbutton{
    from{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:5px;  -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333; }
}



</style>

</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

 

    <div id ="outercontainer" >

    <div id="container" class="container" style="width:auto; margin-top:3.5%; " >

   
    <asp:ScriptManager
    ID="ScriptManager1"
    runat="server">
    </asp:ScriptManager> 

    <div id="logo" class="logoslide" style="z-index:5"><img src="Images/logo4.png" /></div>

    <div id="AppointmentHeading" class="Appointmentslide" style="z-index:5"><img src="Images/AppointmentHeading1.svg" /></div>


    <asp:Panel
    ID="Panel2"
    runat="server" 
    ScrollBars="None"
    BackImageUrl="~/Images/headershade3.png"
    CssClass="Panel2">  

    <asp:UpdatePanel 
    ID="UpdatePanel2"  
    runat="server" >
   
    <ContentTemplate>

    <uc1:MessagePanel runat="server" ID="MessagePanel" />
   
    <asp:Label 
    ID="lblMessage" 
    runat="server" 
    Text="HostPage">
    </asp:Label>
   
    <uc1:AppointmentGridViewHeader runat="server" id="AppointmentGridViewHeader" />
   
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel> 

    <asp:Panel 
    ID="Panel1"
    runat="server" 
    CssClass="Panel1">

    <asp:UpdatePanel 
    ID="UpdatePanel1"  
    runat="server" >

    <ContentTemplate>

    <asp:Label 
    ID="lblIndex" 
    runat="server">
    </asp:Label>
                        
    <uc1:DatePicker runat="server" ID="DatePicker" />                    

    <uc1:AppointmentGridView runat="server" id="AppointmentGridView" />

    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>



    <div id="buttonscontainer" style="margin:auto; width:auto;" class="buttonscontainer" >

    <div id="slidebuttons1" class="buttonslider">

    <div id="Div1" runat="server" style="z-index:5;" class="buttons0">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" > 
    <ContentTemplate>
    <asp:Button ID="btnViewCourses" 
        CssClass="navButtons" 
        runat="server" 
        OnClick="btnViewCourses_Click" 
        Text="View Courses"  
        Visible="True" 
        ForeColor="White"/>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>


    <div id="buttonsdiv0" runat="server" style="z-index:5;" class="buttons1">
    <asp:UpdatePanel ID="buttonspanel" runat="server" > 
    <ContentTemplate>
    <asp:Button ID="btnCreateAppointment" 
        CssClass="navButtons" 
        runat="server" 
        OnClick="btnCreateAppointment_Click" 
        Text="Create Appointment"  
        Visible="True" 
        ForeColor="White"/>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>


    <div id="buttons2" runat="server" style="z-index:5;" class="buttons2">
    <asp:UpdatePanel ID="buttonspanel2" runat="server" > 
    <ContentTemplate>
    <asp:Button ID="btnManageAppointment" 
        CssClass="navButtons" 
        runat="server" 
        OnClick="btnManageAppointment_Click" 
        Text="Manage Appointment"  
        Visible="True" 
        ForeColor="White" />
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>




    <div id="buttonsdiv6" runat="server" style="z-index:5;" class="buttons6">
    <asp:UpdatePanel ID="buttonspanel6" runat="server" > 
    <ContentTemplate>
    <asp:Button ID="btnAddSelectedAppointmentToCourse" 
        CssClass="navButtons" 
        runat="server" 
        OnClick="btnAddSelectedAppointmentToCourse_Click1"
        Text="Add Selected Appointment To Course"  
        Visible="True"  
        ForeColor="White"/>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </div>
    </div>
    </div>
    </div>

    </asp:Content>


