<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCourseView.aspx.cs" Inherits="CheckPoint.Views.UpdateCourseView"  %>

<%@ Register Src="~/UserControls/CourseCreator.ascx" TagPrefix="uc1" TagName="CourseCreator" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">


#btnBackToCoursesPage{
    position: absolute;
    top:19em;
    left:45em;
}
#btnUpdateCourse{
    position: absolute;
    top:21em;
    left:45em;
    width:151px;
}

#btnYes{
    position: absolute;
    top:21em;
    left:45em;
}
#btnNo{
    position: absolute;
    top:21em;
    left:54em;
}

.auto-style1 {
    width: 59%;
    height: 533px;
    margin-left: 21%;
    margin-top: 2%;
    background-color: #333333;
    border-radius: 36px;
}


</style>

<title></title>
</head>


<body>
<form id="form1" runat="server">

<uc1:CourseCreator runat="server" id="CourseCreator" />


<asp:Button ID="btnBackToCoursesPage" runat="server" OnClick="btnBackToCoursesPage_Click" Text="Back To Courses Page" />
<asp:Button ID="btnUpdateCourse" runat="server" Text="Update Course" OnClick="btnUpdateCourse_Click1" />
<asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False" />
<asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />

   
</form>
</body>
</html>
