<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSingleAppointmentView.aspx.cs" Inherits="CheckPoint.Views.ManageSingleAppointmentView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">

.container{
    width: 30%;
    margin-left: 30%;
    margin-top: 10%;
}
.panel{
    position:relative;
}
#lblAppointmentName{
    position: absolute;
    top:0em;
    left:0em;
}
#txtAppointmentName{
    position: absolute;
    top:0em;
    left:10em;
}
#lblDate{
    position: absolute;
    top:5.2em;
    left:0em;
}
#txtDate{
    position: absolute;
    top:6em;
    left:10em;
}
#lblDescription{
    position: absolute;
    top:3.5em;
    left:0em;
}
#txtAppointmentDescription{
    position: absolute;
    top:4em;
    left:10em;
}
#lblCourseId{
    position: absolute;
    top:1.8em;
    left:0em;
}
#txtCourseId{
    position: absolute;
    top:2em;
    left:10em;
}
#lblStartTime{
    position: absolute;
    top:6.8em;
    left:0em;
}
#txtStartTime{
    position: absolute;
    top:8em;
    left:10em;
}
#lblEndTime{
    position: absolute;
    top:8.5em;
    left:0em;
}
#txtEndTime{
    position: absolute;
    top:10em;
    left:10em;
}
#lblPostalCode{
    position: absolute;
    top:11.8em;
    left:0em;
}
#txtPostalCode{
    position: absolute;
    top:14em;
    left:10em;
}
#lblAddress{
    position: absolute;
    top:10.2em;
    left:0em;
}
#txtAddress{
    position: absolute;
    top:12em;
    left:10em;
}
#lblUserName{
    position: absolute;
    top:13.5em;
    left:0em;
}
#txtUserName{
    position: absolute;
    top:16em;
    left:10em;
}
#lblObligatory{
    position: absolute;
    top:14.9em;
    left:0em;
}
#ddlIsObligatory{
    position: absolute;
    top:18em;
    left:10em;
}
#lblCancelled{
    position: absolute;
    top:16.6em;
    left:0em;
}
#ddlIsCancelled{
    position: absolute;
    top:20em;
    left:10em;
}
#lblMessage{
    position: absolute;
    top:24em;
    left:0em;
}
#btnBackToHomePage{
    position: absolute;
    top:22em;
    left:11em;
}
#btnUpdateAppointment{
    position: absolute;
    top:26em;
    left:11em;
}
#btnDeleteAppointment{
    position: absolute;
    top:24em;
    left:11em;
    width:137px;
}
#btnYes{
    position: absolute;
    top:25em;
    left:11em;
}
#btnNo{
    position: absolute;
    top:25em;
    left:18em;
}
#btnContinue{
    position: absolute;
    width:114px;
    top:28em;
    left:11.5em;
}



</style>

<title></title>
</head>
<body>
<form id="form1" runat="server">

<div id="container" class="container">
<div id="panel" class="panel">
    
        
        <asp:Label ID="lblAppointmentName" runat="server" Text="Appointment Name"></asp:Label>
        <asp:TextBox ID="txtAppointmentName" runat="server"></asp:TextBox>
      

        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtAppointmentDescription" runat="server" Height="19px" Width="350px"></asp:TextBox>


        <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>

         <asp:Label ID="lblCourseId" runat="server" Text="CoursedId"></asp:Label>
        <asp:TextBox ID="txtCourseId" runat="server"></asp:TextBox>


        <asp:Label ID="lblStartTime" runat="server" Text="Start Time"></asp:Label>
        <asp:TextBox ID="txtStartTime" runat="server"></asp:TextBox>

        <asp:Label ID="lblEndTime" runat="server" Text="End Time"></asp:Label>
        <asp:TextBox ID="txtEndTime" runat="server"></asp:TextBox>

        <asp:Label ID="lblPostalCode" runat="server" Text="Postal Code"></asp:Label>
        <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>

        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>

        <asp:Label ID="lblUserName" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>

        <asp:Label ID="lblObligatory" runat="server" Text="Obligatory"></asp:Label>

        <asp:DropDownList ID="ddlIsObligatory" runat="server">
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
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Visible="False" Width="56px" />
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" Width="45px" />
        <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue Editing" Visible="False" />
       </div>
 </div>
</form>
</body>
</html>
