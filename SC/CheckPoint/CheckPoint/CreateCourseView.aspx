<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HostMaster.Master" CodeBehind="CreateCourseView.aspx.cs" Inherits="CheckPoint.Views.CreateCourseView" %>
<%@ Register Src="~/UserControls/CourseCreator.ascx" TagPrefix="uc1" TagName="CourseCreator" %>
<%@ Register Src="~/UserControls/MessagePanel.ascx" TagPrefix="uc1" TagName="MessagePanel" %>




<asp:Content ContentPlaceHolderID="head" runat="server">




<style type="text/css">

#create_course_buttons{
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

    <uc1:MessagePanel runat="server" ID="MessagePanel" />  

    <div id="logo" class="logoslide" style="z-index:5"><img src="Images/logo4.png" /></div>

    <div id="courseManagerHeading" class="Headerslide" style="z-index:5"><img src="Images/CreateaCourseHeading1.svg" /></div>

    <uc1:CourseCreator runat="server" id="CourseCreator" />
    

        <div id="create_course_buttons">

            <asp:Button CssClass="button" ID="btnCreateCourse" runat="server" Text="Create Course" OnClick="btnCreateCourse_Click" />

        </div>

 
    
 
</asp:Content>

