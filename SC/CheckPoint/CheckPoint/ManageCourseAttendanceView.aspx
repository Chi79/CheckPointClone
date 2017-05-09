<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCourseAttendanceView.aspx.cs" Inherits="CheckPoint.Views.ManageCourseAttendanceView" EnableEventValidation="false"   MasterPageFile="~/HostMaster.Master" %>

<%@ Register Src="~/UserControls/CourseGridViewHeader.ascx" TagPrefix="uc1" TagName="CourseGridViewHeader" %>
<%@ Register Src="~/UserControls/CourseGridView.ascx" TagPrefix="uc1" TagName="CourseGridView" %>
<%@ Register Src="~/UserControls/AttendeeGridViewHeader.ascx" TagPrefix="uc1" TagName="AttendeeGridViewHeader" %>
<%@ Register Src="~/UserControls/AttendeeGridView.ascx" TagPrefix="uc1" TagName="AttendeeGridView" %>
<%@ Register Src="~/UserControls/MessagePanel.ascx" TagPrefix="uc1" TagName="MessagePanel" %>




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
                .container{
      position:relative;
      right:0%;
      height:auto;
      animation: slideright 2s;
}
        @keyframes slideright {
      from { right: -100%; }
      to { right: 0%;}
}

        .logoslide{
      position:absolute;
      left: 85%;
      top: -11px;
      animation: slideleft 2s ;
}
@keyframes slideleft {
      from { left: -100%; }
      to { left: 85%; }
        }
      .Appointmentslide{
      position:absolute;
      left: 6%;
      animation:slidedown 4s;
      top:4px;
}
@keyframes slidedown {
     from { top: -200px; }
      to { top: 4px; }
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
            overflow-y:hidden;
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

     
<div id="outercontainer">
    <div id="logo" class="logoslide" style="z-index:5"><img src="Images/logo4.png" /></div>

<div id="manageCourseHeading" class="Appointmentslide" style="z-index:5"><img src="Images/ManageCourseAttendanceHeading.svg" /></div>

<div id="coursecontainer" class="container" style="width:auto; margin-top:3.5%;">

<asp:ScriptManager
ID="ScriptManager1"
runat="server">
</asp:ScriptManager> 



    
<%-- Course Header --%> 
<asp:Panel ID="panelCourseHeader" runat="server" ScrollBars="None" BackImageUrl="~/Images/headershade3.png" CssClass="PanelAppGridHeader">

     <asp:UpdatePanel 
    ID="UpdatePanel1"  
    runat="server" >
    <ContentTemplate>

      
    <uc1:CourseGridViewHeader runat="server" id="CourseGridViewHeader" Visible="true" />
 <uc1:MessagePanel runat="server" ID="MessagePanel"/>
    </ContentTemplate>

    </asp:UpdatePanel>

</asp:Panel>

<%-- Course Gridview --%>
<asp:Panel ID="panelCourseGridView" runat="server" CssClass="PanelAppGrid">

     <asp:UpdatePanel 
    ID="UpdatePanel0"  
    runat="server" >

    <ContentTemplate>
        
    <uc1:CourseGridView runat="server" id="CourseGridView" />
       
        </ContentTemplate>
         </asp:UpdatePanel>

</asp:Panel> 

<br />
<br />
<asp:Button CssClass="navButtons" ID="btnManageAppointmentAttendance" runat="server" Text="Manage Attendance For Appointments" OnClick="btnManageAppointmentAttendance_Click"/>
<br />
<br />
<br />


<%-- Attendee Header --%>
<asp:Panel ID="panelAttendeeHeader" runat="server" ScrollBars="None" BackImageUrl="~/Images/headershade3.png" Visible="true">

    <asp:UpdatePanel 
    ID="UpdatePanel3"  
    runat="server" >

    <ContentTemplate> 

    <uc1:AttendeeGridViewHeader runat="server" id="AttendeeGridViewHeader" Visible="true"/>

    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Panel>

 
<%-- Attendee Gridview --%>
<asp:Panel ID="panelAttendeeGridView" runat="server" Visible="true">

    <asp:UpdatePanel 
    ID="UpdatePanel7"  
    runat="server" >
    <ContentTemplate>
    <uc1:AttendeeGridView runat="server" id="AttendeeGridView" Visible="true"/>
<br />
<br />
        <div id="buttoncontainer">
<asp:Button CssClass="navButtons" ID="btnAcceptAttendanceRequest" runat="server" Text="Accept Selected Attendance Request" Visible="false" OnClick="btnAcceptAttendanceRequest_Click" /> &nbsp &nbsp
<asp:Button CssClass="navButtons" ID="btnAcceptAllAttendeeRequestsForSelectedCourse" runat="server" Text="Accept All Attendance Requests For Selected Course" OnClick="btnAcceptAllAttendeeRequestsForSelectedCourse_Click"  Visible="false"/>
</div> 
    </ContentTemplate>
         </asp:UpdatePanel>

</asp:Panel>           
     </div>    
    </div>
</asp:Content>