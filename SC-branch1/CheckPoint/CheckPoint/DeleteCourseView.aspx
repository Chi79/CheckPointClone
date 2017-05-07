<%@ Page Language="C#" MasterPageFile="~/HostMaster.Master" AutoEventWireup="true" CodeBehind="DeleteCourseView.aspx.cs" Inherits="CheckPoint.Views.DeleteCourseView" %>

<%@ Register Src="~/UserControls/CourseCreator.ascx" TagPrefix="uc1" TagName="CourseCreator" %>


<asp:Content ContentPlaceHolderID="head" runat="server">


<style type="text/css">

#Delete_course_buttons{
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





</style>

<title></title>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">



<uc1:CourseCreator runat="server" id="CourseCreator" />

    
      <div id="Delete_course_buttons">

<asp:Button CssClass="button" ID="btnDeleteCourse" runat="server" Text="Delete Course" OnClick="btnDeleteCourse_Click" />
<asp:Button CssClass="button" ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False" />
<asp:Button CssClass="button" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />
          </div>

</asp:Content>







     




