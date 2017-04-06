<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSingleAppointmentView.aspx.cs" Inherits="CheckPoint.Views.ManageSingleAppointmentView" %>

<!DOCTYPE html>

<html  xmlns="http://www.w3.org/1999/xhtml">
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
}
.panel{
    position:relative;
}
#lblAppointmentName{
    position: absolute;
    top:5.2em;
    left:4em;
    color:white;
}
#txtAppointmentName{
    position: absolute;
    top:6em;
    left:16em;
}
#lblDate{
    position: absolute;
    top:10.2em;
    left:4em;
    color:white;
}
#txtDate{
    position: absolute;
    top:12em;
    left:16em;
}
#lblDescription{
    position: absolute;
    top:8.5em;
    left:4em;
    color:white;
}
#txtAppointmentDescription{
    position: absolute;
    top:9.8em;
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
#lblStartTime{
    position: absolute;
    top:11.9em;
    left:4em;
    color:white;
}
#txtStartTime{
    position: absolute;
    top:14em;
    left:16em;
}
#lblEndTime{
    position: absolute;
    top:13.6em;
    left:4em;
    color:white;
}
#txtEndTime{
    position: absolute;
    top:16em;
    left:16em;
}
#lblPostalCode{
    position: absolute;
    top:16.8em;
    left:4em;
    color:white;
}
#txtPostalCode{
    position: absolute;
    top:20em;
    left:16em;
}
#lblAddress{
    position: absolute;
    top:15.2em;
    left:4em;
    color:white;
}
#txtAddress{
    position: absolute;
    top:18em;
    left:16em;
}
#lblUserName{
    position: absolute;
    top:18.5em;
    left:4em;
    color:white;
}
#txtUserName{
    position: absolute;
    top:22em;
    left:16em;
}
#lblObligatory{
    position: absolute;
    top:20em;
    left:4em;
    color:white;
}
#ddlIsObligatory{
    position: absolute;
    top:24em;
    left:16em;
}
#lblCancelled{
    position: absolute;
    top:21.8em;
    left:4em;
    color:white;
}
#ddlIsCancelled{
    position: absolute;
    top:26em;
    left:16em;
}
#lblPrivate{
    position: absolute;
    top:18.4em;
    left:4em;
    color:white;
}

#ddlIsPrivate{
    position: absolute;
    top:22.2em;
    left:16em;
}
#lblMessage{
    position: absolute;
    top:30em;
    left:4em;
    color:white;
}
#btnBackToHomePage{
    position: absolute;
    top:30em;
    left:16em;
}
#btnUpdateAppointment{
    position: absolute;
    top:34em;
    left:16em;
    width:136px;
}
#btnDeleteAppointment{
    position: absolute;
    top:32em;
    left:16em;
    width:137px;
}
#btnYes{
    position: absolute;
    top:33em;
    left:16em;
}
#btnNo{
    position: absolute;
    top:33em;
    left:23em;
}
#btnAddThisAppointmentToTheCourse{
    position: absolute;
    top:29em;
    left:9em;
    width:350px;
}

#btnContinue{
    position: absolute;
    width:136px;
    top:28em;
    left:16em;
}
#btnBackToCourses{
    position: absolute;
    width:250px;
    top:29em;
    left:12em;
}
#btnSelectDifferentAppointment{
    position: absolute;
    width:250px;
    top:31em;
    left:12em;
}


.auto-style1 {
    width: 42%;
    height: 570px;
    margin-left: 27%;
    margin-top: 2%;
    background-color: #333333;
    border-radius: 36px;
    border: #66cc66;
    border-width: 20px;
    border-style: solid;
}



</style>

<title></title>
</head>
<body>
<form id="form1" runat="server">

<div id="container" class="auto-style1">
<div id="panel" class="panel">
    
        
        <asp:Label ID="lblAppointmentName" runat="server" Text="Appointment Name"></asp:Label>
        <asp:TextBox ID="txtAppointmentName" runat="server"></asp:TextBox>
      

        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtAppointmentDescription" runat="server" Height="19px" Width="275px"></asp:TextBox>


        <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>


        <asp:Label ID="lblStartTime" runat="server" Text="Start Time"></asp:Label>
        <asp:TextBox ID="txtStartTime" runat="server"></asp:TextBox>

        <asp:Label ID="lblEndTime" runat="server" Text="End Time"></asp:Label>
        <asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>

        <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code"></asp:Label>
        <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>

        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server" Width="275px"></asp:TextBox>

        <asp:Label ID="lblObligatory" runat="server" Text="Obligatory"></asp:Label>

        <asp:DropDownList ID="ddlIsObligatory" runat="server">
            <asp:ListItem Value="False">No</asp:ListItem>
            <asp:ListItem Value="True">Yes</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="lblPrivate" runat="server" Text="Private"></asp:Label>

        <asp:DropDownList ID="ddlIsPrivate" runat="server">
            <asp:ListItem Value="False">No</asp:ListItem>
            <asp:ListItem Value="True">Yes</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Label ID="lblCancelled" runat="server" Text="Cancelled"></asp:Label>

        <asp:DropDownList ID="ddlIsCancelled" runat="server">
            <asp:ListItem Value="False" >No</asp:ListItem>
            <asp:ListItem Value="True" >Yes</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="lblMessage" runat="server"></asp:Label>

        <asp:Button ID="btnBackToHomePage" runat="server" OnClick="btnBackToHomePage_Click" Text="Back To Home Page" />
        <asp:Button ID="btnUpdateAppointment" runat="server" Text="Update Appointment" OnClick="btnCreateAppointment_Click" />
        <asp:Button ID="btnDeleteAppointment" runat="server" Text="Delete Appointment" OnClick="btnDelete_Click" />
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Visible="False" Width="47px" />
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" Width="45px" />
        <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue Editing" Visible="False" />
        <asp:Button ID="btnAddThisAppointmentToTheCourse" runat="server" OnClick="btnAddThisAppointmentToTheCourse_Click" Text="Add This Appointment To The Course" Visible="False" />
        <asp:Button ID="btnBackToCourses" runat="server" OnClick="btnBackToCourses_Click" Text="Back To View Courses" Visible="False" />
        <asp:Button ID="btnSelectDifferentAppointment" runat="server" OnClick="btnSelectDifferentAppointment_Click" Text="Select A Different Appointment" Visible="False" />

       </div>
 </div>
</form>
</body>
</html>
