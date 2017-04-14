<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HostMaster.Master" CodeBehind="CreateCourseView.aspx.cs" Inherits="CheckPoint.Views.CreateCourseView" %>
<%@ Register Src="~/UserControls/CourseCreator.ascx" TagPrefix="uc1" TagName="CourseCreator" %>





<%--<body>
<form id="form1" runat="server">




<asp:Button ID="btnBackToCoursesPage" runat="server" OnClick="btnBackToCoursesPage_Click" Text="Back To Courses Page" />
<asp:Button ID="btnCreateCourse" runat="server" Text="Create Course" OnClick="btnCreateCourse_Click" />
<asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False" />
<asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />

   
</form>
</body>
</html>--%>



<asp:Content ContentPlaceHolderID="head" runat="server">




<style type="text/css">

#create_course_buttons{
    position:fixed;
    top:40%;
    left:15%;
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
 

        <div id="create_course_buttons">

            <asp:Button CssClass="button" ID="btnCreateCourse" runat="server" Text="Create Course" OnClick="btnCreateCourse_Click" />
            <asp:Button CssClass="button" ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False" />
            <asp:Button CssClass="button" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />

        </div>

 
    
 
</asp:Content>

