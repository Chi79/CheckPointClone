<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCourseView.aspx.cs" Inherits="CheckPoint.Views.CreateCourseView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">

.container{
    width: 42%;
    height: 570px;
    margin-left: 27%;
    margin-top: 2%;
    background-color: #333333;
    border: #66cc66;
    border-width: 20px;
    border-style: solid;
    border-radius:36px;
}
.panel{
    position:relative;
}
#lblCourseName{
    position: absolute;
    top:2.7em;
    left:4em;
    color:white;
}
#txtCourseName{
    position: absolute;
    top:3em;
    left:16em;
}
#lblDescription{
    position: absolute;
    top:5em;
    left:4em;
    color:white;
}
#txtDescription{
    position: absolute;
    top:5.8em;
    left:16em;
}
#lblCourseId{
    position: absolute;
    top:6.8em;
    left:4em;
    color:white;
}
#txtCourseId{
    position: absolute;
    top:7.9em;
    left:16em;
}
#lblPrivate{
    position: absolute;
    top:7.5em;
    left:4em;
    color:white;
}
#ddlIsPrivate{
    position: absolute;
    top:9em;
    left:16em;
}

#lblMessage{
    position: absolute;
    top:22em;
    left:4em;
    color:white;
}

#btnBackToHomePage{
    position: absolute;
    top:12em;
    left:16em;
}
#btnCreateCourse{
    position: absolute;
    top:15em;
    left:16em;
    width:138px;
}

#btnYes{
    position: absolute;
    top:18em;
    left:16em;
}
#btnNo{
    position: absolute;
    top:18em;
    left:23em;
}
#btnContinue{
    position: absolute;
    width:136px;
    top:20em;
    left:16em;
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

<div id="container" class="container">
<div id="panel" class="panel">
    
        <asp:Label ID="lblCourseName" runat="server" Text="Course Name"></asp:Label>
        <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
      
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server" Height="19px" Width="275px"></asp:TextBox>

        <asp:Label ID="lblPrivate" runat="server" Text="Private"></asp:Label>

        <asp:DropDownList ID="ddlIsPrivate" runat="server">
            <asp:ListItem Value="False">No</asp:ListItem>
            <asp:ListItem Value="True">Yes</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Label ID="lblMessage" runat="server"></asp:Label>

<asp:Button ID="btnBackToHomePage" runat="server" OnClick="btnBackToHomePage_Click" Text="Back To Home Page" />
<asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue" Visible="False" />
<asp:Button ID="btnCreateCourse" runat="server" Text="Create Course" OnClick="btnCreateCourse_Click" />
<asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False" />
<asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />
    
</div>
</div>
</form>
</body>
</html>
