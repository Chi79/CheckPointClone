<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSingleAppointmentView.aspx.cs" Inherits="CheckPoint.Views.ManageSingleAppointmentView" %>

<%@ Register Src="~/UserControls/AppointmentCreator.ascx" TagPrefix="uc1" TagName="AppointmentCreator" %>


<!DOCTYPE html>

<html  xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">


#btnBackToHomePage{
    position: absolute;
    top: 33em;
    left: 45em;
}
#btnUpdateAppointment{
    position: absolute;
    top: 37em;
    left: 45em;
    width:136px;
}
#btnDeleteAppointment{
    position: absolute;
    top: 35em;
    left: 45em;
    width:137px;
}
#btnYes{
    position: absolute;
    top: 35em;
    left: 45em;
}
#btnNo{
    position: absolute;
    top: 35em;
    left: 52em;
}

#btnContinue{
    position: absolute;
    width:136px;
    top: 35em;
    left: 45em;
}



</style>

<title></title>
</head>
<body>
<form id="form1" runat="server">

<uc1:AppointmentCreator runat="server" ID="AppointmentCreator" />


        <asp:Button ID="btnBackToHomePage" runat="server" OnClick="btnBackToHomePage_Click" Text="Back To Home Page" />
        <asp:Button ID="btnUpdateAppointment" runat="server" Text="Update Appointment" OnClick="btnCreateAppointment_Click" />
        <asp:Button ID="btnDeleteAppointment" runat="server" Text="Delete Appointment" OnClick="btnDelete_Click" />
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Visible="False" Width="47px" />
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" Width="45px" />
        <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue Editing" Visible="False" />

</form>
</body>
</html>
