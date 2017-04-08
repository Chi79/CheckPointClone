<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppointmentCreator.ascx.cs" Inherits="CheckPoint.Views.UserControls.AppointmentCreator" %>



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
#AppointmentCreator_lblAppointmentName{
    position: absolute;
    top:5.2em;
    left:4em;
    color:white;
}
#AppointmentCreator_txtAppointmentName{
    position: absolute;
    top:6em;
    left:16em;
}
#AppointmentCreator_lblDate{
    position: absolute;
    top:10.2em;
    left:4em;
    color:white;
}
#AppointmentCreator_txtDate{
    position: absolute;
    top:12em;
    left:16em;
}
#AppointmentCreator_lblDescription{
    position: absolute;
    top:8.5em;
    left:4em;
    color:white;
}
#AppointmentCreator_txtAppointmentDescription{
    position: absolute;
    top:9.8em;
    left:16em;
}
#AppointmentCreator_lblCourseId{
    position: absolute;
    top:6.8em;
    left:4em;
    color:white;
}
#AppointmentCreator_txtCourseId{
    position: absolute;
    top:7.9em;
    left:16em;
}
#AppointmentCreator_lblStartTime{
    position: absolute;
    top:11.9em;
    left:4em;
    color:white;
}
#AppointmentCreator_txtStartTime{
    position: absolute;
    top:14em;
    left:16em;
}
#AppointmentCreator_lblEndTime{
    position: absolute;
    top:13.6em;
    left:4em;
    color:white;
}
#AppointmentCreator_txtEndTime{
    position: absolute;
    top:16em;
    left:16em;
}
#AppointmentCreator_lblPostalCode{
    position: absolute;
    top:16.8em;
    left:4em;
    color:white;
}
#AppointmentCreator_txtPostalCode{
    position: absolute;
    top:20em;
    left:16em;
}
#AppointmentCreator_lblAddress{
    position: absolute;
    top:15.2em;
    left:4em;
    color:white;
}
#AppointmentCreator_txtAddress{
    position: absolute;
    top:18em;
    left:16em;
}
#AppointmentCreator_lblUserName{
    position: absolute;
    top:18.5em;
    left:4em;
    color:white;
}
#AppointmentCreator_txtUserName{
    position: absolute;
    top:22em;
    left:16em;
}
#AppointmentCreator_lblObligatory{
    position: absolute;
    top:20em;
    left:4em;
    color:white;
}
#AppointmentCreator_ddlIsObligatory{
    position: absolute;
    top:24.1em;
    left:16em;
}
#AppointmentCreator_lblCancelled{
    position: absolute;
    top:21.8em;
    left:4em;
    color:white;
}

#AppointmentCreator_ddlIsCancelled{
    position: absolute;
    top:26em;
    left:16em;
}
#AppointmentCreator_lblPrivate{
    position: absolute;
    top:18.4em;
    left:4em;
    color:white;
}

#AppointmentCreator_ddlIsPrivate{
    position: absolute;
    top:22.2em;
    left:16em;
}
#AppointmentCreator_lblMessage{
    position: absolute;
    top:30em;
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
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>

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
    
</div>
</div>
