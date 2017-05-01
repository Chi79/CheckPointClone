<%@ Page Language="C#" MasterPageFile="~/HostMaster.Master" AutoEventWireup="true" CodeBehind="DeleteCourseView.aspx.cs" Inherits="CheckPoint.Views.DeleteCourseView" %>

<%@ Register Src="~/UserControls/CourseCreator.ascx" TagPrefix="uc1" TagName="CourseCreator" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
<style type="text/css">

#Delete_course_buttons{
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

    
      <div id="Delete_course_buttons">

<asp:Button ID="btnDeleteCourse" runat="server" Text="Delete Course" OnClick="btnDeleteCourse_Click" />
<asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False" />
<asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />
          </div>

</asp:Content>







     




