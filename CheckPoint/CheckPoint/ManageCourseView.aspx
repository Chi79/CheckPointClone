<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCourseView.aspx.cs" Inherits="CheckPoint.Views.ManageCourseView" EnableEventValidation="false"  MasterPageFile="~/HostMaster.Master" %>


<%@ Register Src="~/UserControls/ManageCourseGrid.ascx" TagPrefix="uc1" TagName="ManageCourseGrid" %>
<%@ Register Src="~/UserControls/ManageCourseHeader.ascx" TagPrefix="uc1" TagName="ManageCourseHeader" %>
<%@ Register Src="~/UserControls/ManageCourseAppGridHeader.ascx" TagPrefix="uc1" TagName="ManageCourseAppGridHeader" %>
<%@ Register Src="~/UserControls/ManageCourseAppGrid.ascx" TagPrefix="uc1" TagName="ManageCourseAppGrid" %>
<%@ Register Src="~/UserControls/DatePicker.ascx" TagPrefix="uc1" TagName="DatePicker" %>



<asp:Content ContentPlaceHolderID="head" runat="server">


<title></title>

<style type="text/css">
  

.PanelCourseGrid{
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
      top:  -9%;
      animation: slideleft 2s ;
}
@keyframes slideleft {
      from { left: -100%; }
      to { left: 85%; }
}
.coursesmanageslide{
      position:absolute;
      top: -7%;
      left: 2%;
      animation:slidedown 4s;
}
@keyframes slidedown {
      from { top: -100%; }
      to { top: -7%; }
}

.appointmentaddedslide{
      z-index:5;
      position:absolute;
      left:61%;
      top:93%;
      animation:slideup 3s;
  
}
@keyframes slideup {
      from { top: 150%; }
      to { top: 93%; }
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
      margin-left: 0%;
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



<div id ="outercontainer" class="outercontainer" >
<div id="container" class="container" style="width:auto; margin-top:3.5%; " >

<asp:ScriptManager
ID="ScriptManager1"
runat="server">
</asp:ScriptManager> 


<div id="logo" class="logoslide" style="z-index:5"><img src="Images/logo4.png" /></div>

<div id="courseManagerHeading" class="coursesmanageslide" style="z-index:5"><img src="Images/CourseManagerHeading1.svg" /></div>

<asp:Image ID="appointmentAddedMessage" Visible="false" CssClass="appointmentaddedslide" runat="server" ImageUrl="~/Images/AppointmentAddedMessage1.svg"  />

<asp:Image ID="appointmentDeletedMessage" Visible="false" CssClass="appointmentaddedslide" runat="server" ImageUrl="~/Images/AppointmentDeletedMessage1.svg"  />

<asp:Image ID="courseUpdatedMessage" Visible="false" CssClass="appointmentaddedslide" runat="server" ImageUrl="~/Images/CourseUpdatedMessage1.svg"  />

<asp:Panel
ID="Panel2"
runat="server" 
ScrollBars="None"
BackImageUrl="~/Images/headershade3.png"
CssClass="PanelCourseHeader">

       
<asp:UpdatePanel 
ID="UpdatePanel2"  
runat="server" >
<ContentTemplate>

<asp:Label 
ID="lblMessage" 
runat="server" 
Text="HostPage">
</asp:Label>

<uc1:ManageCourseHeader runat="server" id="ManageCourseHeader" />

</ContentTemplate>
</asp:UpdatePanel>

</asp:Panel> 


<asp:Panel 
ID="Panel1"
runat="server" 
CssClass="PanelCourseGrid">


 
<asp:UpdatePanel 
ID="UpdatePanel1"  
runat="server" >
<ContentTemplate>
<asp:Label 
ID="lblIndex" 
runat="server">
</asp:Label>
                        
                   
 <uc1:ManageCourseGrid runat="server" id="ManageCourseGrid" />


</ContentTemplate>
</asp:UpdatePanel>

</asp:Panel>


    <asp:Panel
    ID="Panel3"
    runat="server" 
    ScrollBars="None"
    BackImageUrl="~/Images/headershade3.png"
    CssClass="PanelAppGridHeader">  

    <asp:UpdatePanel 
    ID="UpdatePanel3"  
    runat="server" >
   
    <ContentTemplate>
   
    <asp:Label 
    ID="Label1" 
    runat="server" 
    Text="HostPage">
    </asp:Label>

   <uc1:ManageCourseAppGridHeader runat="server" id="ManageCourseAppGridHeader" />
   
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel> 


    <asp:Panel 
    ID="Panel4"
    runat="server" 
    CssClass="PanelAppGrid">

    <asp:UpdatePanel 
    ID="UpdatePanel4"  
    runat="server" >

    <ContentTemplate>

    <asp:Label 
    ID="Label2" 
    runat="server">
    </asp:Label>
                        
    <uc1:DatePicker runat="server" ID="DatePicker" />                 

    <uc1:ManageCourseAppGrid runat="server" id="ManageCourseAppGrid" />

    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>




<div id="buttonscontainer" style="margin:auto; width:auto;" class="buttonscontainer" >

<div id="slidebuttons1" class="buttonslider">

<div id="Div1" runat="server" style="z-index:5;" class="buttons0">
<asp:UpdatePanel ID="buttonspanel0" runat="server" > 
<ContentTemplate>
<asp:Button ID="btnBackToAppointmentsView"
    CssClass="navButtons" 
    runat="server" 
    OnClick="btnBackToAppointmentsView_Click" 
    Text="View Appointments"  
    Visible="True" 
    ForeColor="White"/>
</ContentTemplate>
</asp:UpdatePanel>
</div>


<div id="buttonsdiv1" runat="server" style="z-index:5;" class="buttons1">
<asp:UpdatePanel ID="buttonspanel1" runat="server" > 
<ContentTemplate>
<asp:Button ID="btnBackToCoursesView" 
    CssClass="navButtons" 
    runat="server" 
    OnClick="btnBackToCoursesView_Click" 
    Text="View Courses"  
    Visible="True" 
    ForeColor="White" />
</ContentTemplate>
</asp:UpdatePanel>
</div>


<div id="buttonsdiv2" runat="server" style="z-index:5;" class="buttons1">
<asp:UpdatePanel ID="buttonspanel2" runat="server" > 
<ContentTemplate>
<asp:Button ID="btnRemoveSelectedAppointmentFromCourse" 
    CssClass="navButtons" 
    runat="server" 
    OnClick="btnRemoveSelectedAppointmentFromCourse_Click" 
    Text="Remove the Selected Appointment"  
    Visible="true"
    ForeColor="White" />
</ContentTemplate>
</asp:UpdatePanel>
</div>

<div id="buttonsdiv3" runat="server" style="z-index:5;" class="buttons1">
<asp:UpdatePanel ID="buttonspanel3" runat="server" > 
<ContentTemplate>
<asp:Button ID="btnMoveSelectedAppointmentToAnotherCourse" 
    CssClass="navButtons" 
    runat="server" 
    OnClick="btnMoveSelectedAppointmentToAnotherCourse_Click" 
    Text="Move the Selected Appointment to Another Course"  
    Visible="True" 
    ForeColor="White" />
</ContentTemplate>
</asp:UpdatePanel>
</div>


<div id="buttonsdiv4" runat="server" style="z-index:5;" class="buttons1">
<asp:UpdatePanel ID="buttonspanel4" runat="server" > 
<ContentTemplate>
<asp:Button ID="btnAddAnotherAppointmentToThisCourse" 
    CssClass="navButtons" 
    runat="server" 
    OnClick="btnAddAnotherAppointmentToThisCourse_Click" 
    Text="Add Another Appointment to this Course"  
    Visible="True" 
    ForeColor="White" />
</ContentTemplate>
</asp:UpdatePanel>
</div>


<div id="buttonsdiv5" runat="server" style="z-index:5;" class="buttons5">
<asp:UpdatePanel ID="buttonspanel5" runat="server" > 
<ContentTemplate>
<asp:Button ID="btnUpdateCourse" 
    CssClass="navButtons" 
    runat="server" 
    OnClick="btnUpdateCourse_Click" 
    Text="Update Course"  
    Visible="True" 
    ForeColor="White" />
</ContentTemplate>
</asp:UpdatePanel>
</div>


<div id="buttonsdiv6" runat="server" style="z-index:5;" class="buttons6">
<asp:UpdatePanel ID="buttonspanel6" runat="server" > 
<ContentTemplate>
<asp:Button ID="btnDeleteCourse" 
    CssClass="navButtons" 
    runat="server" 
    OnClick="btnDeleteCourse_Click" 
    Text="Delete Course"  
    Visible="True" 
    ForeColor="White" />
</ContentTemplate>
</asp:UpdatePanel>
</div>


<%--<div id="buttonsdiv0" runat="server" style="z-index:5;" class="buttons1">
<asp:UpdatePanel ID="buttonspanel" runat="server" > 
<ContentTemplate>
<asp:Button ID="btnCancel" 
    CssClass="navButtons" 
    runat="server" 
    OnClick="btnCancel_Click" 
    Text="Cancel"  
    Visible="True" 
    ForeColor="White" />
</ContentTemplate>
</asp:UpdatePanel>
</div>--%>

</div>
</div>
</div>
</div>

</asp:Content>
