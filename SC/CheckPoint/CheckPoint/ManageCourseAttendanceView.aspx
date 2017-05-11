<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCourseAttendanceView.aspx.cs" Inherits="CheckPoint.Views.ManageCourseAttendanceView" EnableEventValidation="false"   MasterPageFile="~/HostMaster.Master" %>

<%@ Register Src="~/UserControls/CourseGridViewHeader.ascx" TagPrefix="uc1" TagName="CourseGridViewHeader" %>
<%@ Register Src="~/UserControls/CourseGridView.ascx" TagPrefix="uc1" TagName="CourseGridView" %>
<%@ Register Src="~/UserControls/MessagePanel.ascx" TagPrefix="uc1" TagName="MessagePanel" %>
<%@ Register Src="~/UserControls/ClientGridViewHeader.ascx" TagPrefix="uc1" TagName="ClientGridViewHeader" %>
<%@ Register Src="~/UserControls/ClientGridView.ascx" TagPrefix="uc1" TagName="ClientGridView" %>






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
     right:1%;
}
.PanelAppGrid{
    position:relative; 
    height:237px;
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

.GridviewLabel{
     font-size: 38px;
     color: white;            
}

.navButtons{
   margin-left: 8px;
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
.AttendeePanelHeader{
    width: 100%;
    border-top-left-radius: 9px;
    border-top-right-radius: 9px;
    margin-left:-13px;
}
.AttendeePanel{
    width: 100%;
    margin-left:-13px;
    height:55px;
}

#<%=UpdatePanel7.ClientID%>{
    overflow-x: hidden;
    overflow-y:auto;
    height: 150px;
}
.buttonsDiv{
    margin-top:1%;
}
.AttendeeRequestHeader{
   position:absolute;
    left: 0%;
    top: 299px;
   animation: slideright 2s ;
}
@keyframes slideright {
   from { left: 200%; }
   to { left: 0%; }
}

    </style>

</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

     
<div id="outercontainer"style="height:100%; width:auto;">

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

    <uc1:MessagePanel runat="server" ID="MessagePanel" Visible="true"/>
      
    <uc1:CourseGridViewHeader runat="server" id="CourseGridViewHeader" Visible="true" />
 
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
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div id="AttendeeHeader" runat="server" class="AttendeeRequestHeader" style="z-index:5;" >
            <img src="Images/AttendeeRequests1.svg" />
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
<br />
<br />
<%-- Attendee Header --%>
<asp:Panel CssClass="AttendeePanelHeader" ID="panelAttendeeHeader" runat="server" ScrollBars="None" BackImageUrl="~/Images/headershade3.png" Visible="true">

    <asp:UpdatePanel 
    ID="UpdatePanel3"  
    runat="server" >

    <ContentTemplate> 

        <uc1:ClientGridViewHeader runat="server" id="ClientGridViewHeader" />

    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Panel>

 
<%-- Attendee Gridview --%>
<asp:Panel CssClass="AttendeePanel" ID="panelAttendeeGridView" runat="server" Visible="true">

    <asp:UpdatePanel 
    ID="UpdatePanel7"  
    runat="server" >
    <ContentTemplate>
        <uc1:ClientGridView runat="server" id="ClientGridView" />
    </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
    <ContentTemplate>

<div id="buttoncontainer" class="buttonsDiv">

<asp:Button CssClass="navButtons" ID="btnManageAppointmentAttendance" runat="server" Text="Manage Attendance For Appointments" OnClick="btnManageAppointmentAttendance_Click"/>
<asp:Button CssClass="navButtons" ID="btnAcceptAttendanceRequest" runat="server" Text="Accept Selected Attendance Request" Visible="false" OnClick="btnAcceptAttendanceRequest_Click" />
<asp:Button CssClass="navButtons" ID="btnAcceptAllAttendeeRequestsForSelectedCourse" runat="server" Text="Accept All Attendance Requests For Selected Course" OnClick="btnAcceptAllAttendeeRequestsForSelectedCourse_Click"  Visible="false"/>

</div> 

    </ContentTemplate>
    </asp:UpdatePanel>
  
        

</asp:Panel>           
     </div>    
    </div>
</asp:Content>