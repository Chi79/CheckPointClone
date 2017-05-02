<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCourseAttendanceView.aspx.cs" Inherits="CheckPoint.Views.ManageCourseAttendanceView" EnableEventValidation="false"   MasterPageFile="~/HostMaster.Master" %>

<%@ Register Src="~/UserControls/CourseGridViewHeader.ascx" TagPrefix="uc1" TagName="CourseGridViewHeader" %>
<%@ Register Src="~/UserControls/CourseGridView.ascx" TagPrefix="uc1" TagName="CourseGridView" %>
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
            overflow-y:scroll;
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
        .PanelAttendeeGrid{

        }

        .PanelAttendeeHeader{

        }

        .GridviewLabel{
            font-size: 38px;
            color: white;            
        }
        #buttonRow{
            
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

    <asp:ScriptManager
ID="ScriptManager1"
runat="server">
</asp:ScriptManager> 

    <div id="courseGridContainer">
    <
<%-- Course Header --%> 
<asp:Panel ID="panelCourseHeader" runat="server" ScrollBars="None" BackImageUrl="~/Images/headershade3.png" CssClass="PanelCourseHeader">
    <asp:Label ID="lblattendeecourserequest" runat="server" Text="Courses with active attendee requests" CssClass="GridviewLabel"></asp:Label>
    <uc1:CourseGridViewHeader runat="server" id="CourseGridViewHeader" />

</asp:Panel>

<%-- Course Gridview --%>
<asp:Panel ID="panelCourseGrid" runat="server" CssClass="PanelCourseGrid">

     <asp:UpdatePanel 
    ID="UpdatePanel4"  
    runat="server" >

    <ContentTemplate>
    <uc1:CourseGridView runat="server" id="CourseGridView" />
       
        </ContentTemplate>
         </asp:UpdatePanel>

</asp:Panel> 
</div>
<div id="attendeeGridContainer">
<%-- Attendee Header --%>
<asp:Panel ID="panelAttendeeHeader" runat="server" ScrollBars="None" BackImageUrl="~/Images/headershade3.png" CssClass="PanelAppGridHeader" Visible="true">
<asp:Label ID="lblAttendeesApplying" runat="server" Text="Attendees Requesting to be Accepted" CssClass="GridviewLabel"></asp:Label> 
    <uc1:AttendeeGridViewHeader runat="server" id="AttendeeGridViewHeader" />
</asp:Panel>

 
<%-- Attendee Gridview --%>
<asp:Panel ID="panelAttendeeGrid" runat="server" CssClass="PanelAppGrid" Visible="true">
    <uc1:AttendeeGridView runat="server" id="AttendeeGridView" />

</asp:Panel>
</div>
 <div id="buttonRow"> 
              
 <asp:Button CssClass="navButtons" ID="btnAcceptAttendanceRequest" runat="server" Text="Accept Attendance Request" OnClick="btnAcceptAttendanceRequest_Click" />
 <asp:Button CssClass="navButtons" ID="btnManageAppointmentAttendance" runat="server" Text="Manage Attendance For Appointments" OnClick="btnManageAppointmentAttendance_Click"/>   
  </div>  
             


</asp:Content>