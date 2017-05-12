<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAttendanceHistoryView.aspx.cs" Inherits="CheckPoint.Views.UserAttendanceHistoryView" EnableEventValidation="false"  MasterPageFile="~/UserMaster.Master" %>

<%@ Register Src="~/UserControls/AppointmentGridViewHeader.ascx" TagPrefix="uc1" TagName="AppointmentGridViewHeader" %>
<%@ Register Src="~/UserControls/AppointmentGridView.ascx" TagPrefix="uc1" TagName="AppointmentGridView" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
    <title></title>

    <style>


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
    position: relative;
    height: 237px;
    width: 99%;
    overflow-y: scroll;
    right: 0%;
    border-bottom-left-radius: 10px;
}
.PanelAppGridHeader{
    height: 100%;
    width: 99%;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    padding-bottom: 12px;
    position: relative;
    right: 0%;
}
        
.containerpanel{
   position:relative;
   right:0%;
   animation: slideright 2s;
}
   @keyframes slideright {
   from { right: -100%; }
   to { right: 0%;}
}

.logoslide{
    position: absolute;
    left: 85%;
    top: -2%;
    animation: slideleft 2s;
}
@keyframes slideleft {
   from { left: -100%; }
   to { left: 85%; }
}
   .Appointmentslide{
    position: absolute;
    left: 1%;
    animation: slidedown 4s;
    top: 1%;
}
@keyframes slidedown {
   from { top: -200px; }
   to { top: 1%; }
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

.DateAndTimeAttendedMessage{
    position:absolute;
    left:34%;
    top:100%;
    text-align:center;
    animation:slideup 2s;
}

@keyframes slideup {
   from { top: 250%; }
   to { top: 100%; }
}

.DateAndTimeHeader{
   position:absolute;
    left: 35%;
    top: 303px;
   animation: slidesright 2s ;
}
@keyframes slidesright {
   from { left: 200%; }
   to { left: 35%; }
}

</style>

</asp:Content >

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server" >
    <div id="outercontainer" style="height:530px; width:auto; position:relative; overflow:hidden">

    <div id="logo" class="logoslide" style="z-index:5"><img src="Images/logo4.png" /></div>
    <div id="manageAppointmentHeading" class="Appointmentslide" style="z-index:5"><img src="Images/MyAppointmentAttendanceHistoryHeading.svg" /></div>
       
<div id="appointmentcontainer" class="containerpanel" style="width:auto; margin-top:3.5%;">

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
   
            <uc1:AppointmentGridViewHeader runat="server" ID="AppointmentGridViewHeader" />

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
    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
        <ContentTemplate>

            <div id="TimeAttendedHeader" runat="server" class="DateAndTimeHeader" style="z-index:5" >
            <img src="Images/DateAndTimeAttendedHeader.svg" />
                
                          
            </div>

            <div id="datetimetextbox" runat="server" class="DateAndTimeAttendedMessage" style="z-index:5">
            <asp:TextBox ID="txtDateAndTimeAttended" 
                runat="server" class="DateAndTimeAttendedMessage" 
                Font-Size="XX-Large" 
                BackColor="#006600"
                Font-Bold="true" 
                ForeColor="White" 
                ReadOnly="True" 
                TextMode="DateTime"
                Visible="False"
                style="z-index:5"> 
                </asp:TextBox> 
            </div>

                
           
        </ContentTemplate>
    </asp:UpdatePanel>
        </div>
       
        </div>
</asp:Content>
