<%@ Page Language="C#" MasterPageFile="~/HostMaster.Master"  AutoEventWireup="true" CodeBehind="UpdateCourseView.aspx.cs" Inherits="CheckPoint.Views.UpdateCourseView"  %>

<%@ Register Src="~/UserControls/CourseCreator.ascx" TagPrefix="uc1" TagName="CourseCreator" %>
<%@ Register Src="~/UserControls/MessagePanel.ascx" TagPrefix="uc1" TagName="MessagePanel" %>




<asp:Content ContentPlaceHolderID="head" runat="server">
<style type="text/css">

#Update_course_buttons{
    margin-top:5%;
    margin-left:15%;
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

<div id="AppointmentHeading" class="Headerslide" style="z-index:5"><img src="Images/UpdateCourseHeading1.svg" /></div>

<uc1:MessagePanel runat="server" ID="MessagePanel" />

<uc1:CourseCreator runat="server" id="CourseCreator" />

      <div id="Update_course_buttons">
     
<asp:Button class="button" ID="btnUpdateCourse" runat="server" Text="Update Course" OnClick="btnUpdateCourse_Click1" />
          </div>


   
</asp:Content>









