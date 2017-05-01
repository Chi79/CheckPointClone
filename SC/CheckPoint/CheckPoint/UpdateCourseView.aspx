<%@ Page Language="C#" MasterPageFile="~/HostMaster.Master"  AutoEventWireup="true" CodeBehind="UpdateCourseView.aspx.cs" Inherits="CheckPoint.Views.UpdateCourseView"  %>

<%@ Register Src="~/UserControls/CourseCreator.ascx" TagPrefix="uc1" TagName="CourseCreator" %>



<asp:Content ContentPlaceHolderID="head" runat="server">
<style type="text/css">

#Update_course_buttons{
    margin-top:5%;
    margin-left:15%;
    }

.button{

   
    border-radius:6px;
    border:outset gray 2px;
    padding:3px;
}



</style>

<title></title>
</asp:Content>


<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">



<uc1:CourseCreator runat="server" id="CourseCreator" />

      <div id="Update_course_buttons">
     
<asp:Button class="button" ID="btnUpdateCourse" runat="server" Text="Update Course" OnClick="btnUpdateCourse_Click1" />
<asp:Button class="button" ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False" />
<asp:Button class="button" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />
          </div>


   
</asp:Content>









