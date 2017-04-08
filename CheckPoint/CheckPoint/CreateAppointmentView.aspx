<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAppointmentView.aspx.cs" Inherits="CheckPoint.Views.CreateAppointmentView" %>

<%@ Register Src="~/UserControls/AppointmentCreator.ascx" TagPrefix="uc1" TagName="AppointmentCreator" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<style type="text/css">


#btnBackToHomePage{
    position: absolute;
    top:33em;
    left:45em;
}
#btnCreateAppointment{
    position: absolute;
    top: 36em;
    left: 45em;
    width: 137px;
}

#btnYes{
    position: absolute;
    top: 36em;
    left: 45em;
}
#btnNo{
    position: absolute;
    top: 36em;
    left: 53em;
}
#btnContinue{
    position: absolute;
    width:136px;
    top: 35em;
    left: 45em;
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

<uc1:AppointmentCreator runat="server" id="AppointmentCreator" />


<asp:Button ID="btnBackToHomePage" runat="server" OnClick="btnBackToHomePage_Click" Text="Back To Home Page" />
<asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue" Visible="False" />
<asp:Button ID="btnCreateAppointment" runat="server" Text="Create Appointment" OnClick="btnCreateAppointment_Click" />
<asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False" />
<asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />

</form>
</body>
</html>
