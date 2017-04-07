<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="HostHomeView.aspx.cs"  Inherits="CheckPoint.Views.HostHomeView"  EnableEventValidation="false"  MasterPageFile="~/HostMaster.Master" %>

<%@ Register Src="~/UserControls/AppointmentGridView.ascx" TagPrefix="uc1" TagName="AppointmentGridView" %>
<%@ Register Src="~/UserControls/AppointmentGridViewHeader.ascx" TagPrefix="uc1" TagName="AppointmentGridViewHeader" %>



<asp:Content ContentPlaceHolderID="head" runat="server">


<title></title>

<style type="text/css">
  

.Panel1{
    position:relative; 
    height:470px; 
    width:100%;
    overflow-y:scroll;
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
.buttons0{
      float:left;
      margin-left: 11%;
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
      margin-left: 15%;
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




</style>

</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">



    <div id ="outercontainer" class="outercontainer" >
    <div id="container" class="container" style="width:auto; margin-top:3.5%; " >

    <asp:ScriptManager
    ID="ScriptManager1"
    runat="server">
    </asp:ScriptManager> 

    <div id="logo" class="logoslide" style="z-index:5"><img src="Images/logo4.png" /></div>


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
                        
                      
    <script type="text/javascript">


    $(function () {
    $(".picker").datepicker({
    showOn: "button",
    buttonImage: "/images/calendar2.png",
    buttonImageOnly: true,
    buttonText: "calender",
    onSelect: $(".picker").datepicker("setDate", $(".picker")) 
    });
    $(".picker").datepicker("setDate", $(".picker"))
    });
   
    
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    if (prm != null) {
    prm.add_endRequest(function (sender, e) {
    if (sender._postBackSettings.panelsToUpdate != null) {
    $(".picker").datepicker({
    showOn: "button",
    buttonImage: "/images/calendar2.png",
    buttonImageOnly: true,
    buttonText: "calender",
    onSelect: $(".picker").datepicker("setDate", $(".picker"))
    });
    }
    });
    };
    </script>

    <uc1:AppointmentGridView runat="server" id="AppointmentGridView" />

    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>



    <div id="buttonscontainer" style="margin:auto; width:auto;" class="buttonscontainer" >

    <div id="slidebuttons1" class="buttonslider">

    <div id="Div1" runat="server" style="z-index:5;" class="buttons0">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" > 
    <ContentTemplate>
    <asp:ImageButton  
    runat="server" 
    CssClass="roundedButtons" 
    id="btnViewCourses" ImageUrl="~/Images/viewcoursesbutton.png" 
    OnClick="ViewCourses_Click"
    ToolTip="view all courses" />
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>


    <div id="buttonsdiv0" runat="server" style="z-index:5;" class="buttons1">
    <asp:UpdatePanel ID="buttonspanel" runat="server" > 
    <ContentTemplate>
    <asp:ImageButton  
    runat="server" 
    CssClass="roundedButtons" 
    id="btnCreateAppointment" ImageUrl="~/Images/createappointmentbutton.png" 
    OnClick="createAppointment_Click"
    ToolTip="create a new appointment" />
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>


    <div id="buttons2" runat="server" style="z-index:5;" class="buttons2">
    <asp:UpdatePanel ID="buttonspanel2" runat="server" > 
    <ContentTemplate>
    <asp:ImageButton  
    runat="server" 
    CssClass="roundedButtons"
    id="btnManageAppointment"
    ImageUrl="~/Images/manageappointmentbutton.png" 
    OnClick="manageAppointment_Click"
    ToolTip="manage the selected appointment"  />
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>


    <div id="buttonsdiv4" runat="server" style="z-index:5;" class="buttons4">
    <asp:UpdatePanel ID="buttonspanel4" runat="server" > 
    <ContentTemplate>
    <asp:ImageButton  
    runat="server"
    CssClass="roundedButtons"
    id="btnManageAttendance" 
    ImageUrl="~/Images/manageattendancebutton1.png"
    OnClick="manageattendance_Click" 
    ToolTip="manage attendance"  />
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>


    <div id="buttonsdiv5" runat="server" style="z-index:5;" class="buttons5">
    <asp:UpdatePanel ID="buttonspanel5" runat="server" > 
    <ContentTemplate>
    <asp:ImageButton  
    runat="server" 
    CssClass="roundedButtons" 
    id="btnCreateReport" 
    ImageUrl="~/Images/createreportbutton1.png" 
    OnClick="createreport_Click"  
    ToolTip="create a report" />
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>


    <div id="buttonsdiv6" runat="server" style="z-index:5;" class="buttons6">
    <asp:UpdatePanel ID="buttonspanel6" runat="server" > 
    <ContentTemplate>
    <asp:ImageButton
    runat="server" 
    CssClass="roundedButtons"
    id="btnAddSelectedAppointmentToCourse" 
    ImageUrl="~/Images/addselectedappointmentbutton.png" 
    OnClick="btnAddSelectedAppointmentToCourse_Click"
    ToolTip="add the selected appointment to the course"
    Visible="false" />
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>

    </div>

    </div>
    </div>
    </div>

    </asp:Content>


