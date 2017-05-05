﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAppointmentAttendanceView.aspx.cs" Inherits="CheckPoint.Views.ManageAppointmentAttendanceView" EnableEventValidation="false"   MasterPageFile="~/HostMaster.Master" %>

<%@ Register Src="~/UserControls/AppointmentGridViewHeader.ascx" TagPrefix="uc1" TagName="AppointmentGridViewHeader" %>
<%@ Register Src="~/UserControls/AppointmentGridView.ascx" TagPrefix="uc1" TagName="AppointmentGridView" %>
<%@ Register Src="~/UserControls/AttendeeGridViewHeader.ascx" TagPrefix="uc1" TagName="AttendeeGridViewHeader" %>
<%@ Register Src="~/UserControls/AttendeeGridView.ascx" TagPrefix="uc1" TagName="AttendeeGridView" %>




<asp:Content ContentPlaceHolderID="head" runat="server">
    <title></title>

    <style>
        #wrapper{
            width: 100%;
            height: 100%;
            background: #333333;
        }

        #courseGridContainer{
            position:relative;        
        }

        #appointmentGridContainer{
            position:relative;          
        }

        #attendeeGridContainer{
            position:relative;
            top:50%;
            width:100%;

        }

        .PanelCourseGrid {
            position: relative;
            height: 79px;
            width: 100%;
            overflow-y: hidden;
            right: 1%;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
        }
        .PanelCourseHeader{
            height:100%;
            width:100%;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            padding-bottom: 5px;
            position:relative;
            right:1%;
        }
        .PanelAppGrid{
            position:relative; 
            height:315px;
            width:100%;
            overflow-y:auto;
            right:1%;
            border-bottom-left-radius: 10px;
        }
        .PanelAppGridHeader{
            height:100%;
            width:100%;
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            padding-bottom: 5px;
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
      top:  -12%;
      animation: slideleft 2s ;
}
@keyframes slideleft {
      from { left: -100%; }
      to { left: 85%; }
        }
      .Appointmentslide{
      position:absolute;
      left: 2%;
      animation:slidedown 4s;
      top:-8%;
        }

      @keyframes slidedown {
      from { top: -100%; }
      to { top: -8%; }
        }

        .GridviewLabel{
            font-size: 38px;
            color: white;            
        }
        .navButtons{
        border-radius: 5px;
        border-width: 0px;
        border-color: darkgreen;
        padding-bottom: 1%;
        height: 40px;
        font-family: sans-serif;
        font-size: 15px;
        color: white;
        padding-top: 0.5%;
        font-weight: 600;
        background-image: url(/Images/buttonshade1.png);
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
    <div id="outercontainer" style="height:100%; width:auto;">
        <div id="logo" class="logoslide" style="z-index:5"><img src="Images/logo4.png" /></div>
    <div id="manageAppointmentHeading" class="Appointmentslide" style="z-index:5"><img src="Images/ManageAppointmentAttendanceHeading.svg" /></div>
<div id="appointmentcontainer" class="container" style="width:auto; margin-top:3.5%;">
    <asp:ScriptManager
ID="ScriptManager1"
runat="server">
</asp:ScriptManager> 
    
   
        
<%-- Appointment Header --%>    
<asp:Panel ID="panelAppointmentHeader" runat="server" ScrollBars="None" BackImageUrl="~/Images/headershade3.png" CssClass="PanelAppGridHeader" Visible="true">
    <asp:UpdatePanel
    ID="UpdatePanel7"  
    runat="server" > 
        <ContentTemplate>
            <uc1:AppointmentGridViewHeader runat="server" ID="AppointmentGridViewHeader"/>
        </ContentTemplate>
         </asp:UpdatePanel>
</asp:Panel>

<%-- Appointment Gridview --%>
<asp:Panel ID="panelAppointmentGridView" runat="server" CssClass="PanelAppGrid" Visible="true">
    
     <asp:UpdatePanel 
    ID="UpdatePanel1"  
    runat="server" >

    <ContentTemplate>
        <uc1:AppointmentGridView runat="server" ID="AppointmentGridView" />

        </ContentTemplate>
         </asp:UpdatePanel>

</asp:Panel>


<br />
<br />
<asp:Button CssClass="navButtons" ID="btnManageCourseAttendance" runat="server" Text="Manage Attendance For Courses" OnClick="btnManageCourseAttendance_Click"/>

<br />
<br />
<br />
<%-- Attendee Header --%>
<asp:Panel ID="panelAttendeeHeader" runat="server" ScrollBars="None" BackImageUrl="~/Images/headershade3.png" Visible="true">
    <asp:UpdatePanel 
    ID="UpdatePanel2"  
    runat="server" >

    <ContentTemplate>
<%--<asp:Label ID="lblAttendeesApplying" runat="server" Text="Attendees Requesting to be Accepted" CssClass="GridviewLabel"></asp:Label> --%>
    <uc1:AttendeeGridViewHeader runat="server" id="AttendeeGridViewHeader" Visible="true"/>
        </ContentTemplate>
         </asp:UpdatePanel>
</asp:Panel>

 
<%-- Attendee Gridview --%>
<asp:Panel ID="panelAttendeeGridView" runat="server" Visible="true">
    <asp:UpdatePanel 
    ID="UpdatePanel3"  
    runat="server" >

    <ContentTemplate>
    <uc1:AttendeeGridView runat="server" id="AttendeeGridView" Visible="true"/> 
        <br />
<br />
                <asp:Button CssClass="navButtons" ID="btnAcceptAttendanceRequest" runat="server" Text="Accept Attendance Request" OnClick="btnAcceptAttendanceRequest_Click" Visible="false"/> &nbsp &nbsp
<asp:Button CssClass="navButtons" ID="btnAcceptAllAttendeeRequestsForSelectedAppointment" runat="server" Text="Accept All Attendance Requests For Selected Appointment" OnClick="btnAcceptAllAttendeeRequestsForSelectedAppointment_Click" Visible="false"/>
        </ContentTemplate>
         </asp:UpdatePanel>
</asp:Panel>

             
 
         
    
  </div>
        </div>


</asp:Content>