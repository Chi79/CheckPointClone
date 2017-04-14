<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseCreator.ascx.cs" Inherits="CheckPoint.Views.UserControls.CourseCreator" %>


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
.lblCourseCreatorName{
    position: absolute;
    top:2.7em;
    left:4em;
    color:white;
}
.txtCourseCreatorName{
    position: absolute;
    top:3em;
    left:16em;
}
.lblCreatorDescription{
    position: absolute;
    top:5em;
    left:4em;
    color:white;
}
.txtCreatorDescription{
    position: absolute;
    top:5.8em;
    left:16em;
}
.lblCreatorCourseId{
    position: absolute;
    top:6.8em;
    left:4em;
    color:white;
}
.txtCreatorCourseId{
    position: absolute;
    top:7.9em;
    left:16em;
}
.lblCreatorPrivate{
    position: absolute;
    top:7.5em;
    left:4em;
    color:white;
}
.ddlCreatorIsPrivate{
    position: absolute;
    top:9em;
    left:16em;
}
.lblCreatorObligatory{
    position: absolute;
    top:9.3em;
    left:4em;
    color:white;
}
.ddlCreatorIsObligatory{
    position: absolute;
    top:11em;
    left:16em;
}

.lblCreatorMessage{
    position: absolute;
    top:22em;
    left:4em;
    color:white;
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


<div id="container" class="container">
<div id="panel" class="panel">
    
        <asp:Label ID="lblCourseName" runat="server" Text="Course Name" CssClass="lblCourseCreatorName"></asp:Label>
        <asp:TextBox ID="txtCourseName" runat="server" CssClass="txtCourseCreatorName"></asp:TextBox>
      
        <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="lblCreatorDescription"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server" Height="19px" Width="275px" CssClass="txtCreatorDescription"></asp:TextBox>

        <asp:Label ID="lblPrivate" runat="server" Text="Private" CssClass="lblCreatorPrivate"></asp:Label>

        <asp:DropDownList ID="ddlIsPrivate" runat="server" CssClass="ddlCreatorIsPrivate">
            <asp:ListItem Value="False">No</asp:ListItem>
            <asp:ListItem Value="True">Yes</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="lblObligatory" runat="server" Text="Obligatory" CssClass="lblCreatorObligatory"></asp:Label>

        <asp:DropDownList ID="ddlIsObligatory" runat="server" CssClass="ddlCreatorIsObligatory">
            <asp:ListItem Value="False">No</asp:ListItem>
            <asp:ListItem Value="True">Yes</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Label ID="lblMessage" runat="server" CssClass="lblCreatorMessage"></asp:Label>
    
</div>
</div>