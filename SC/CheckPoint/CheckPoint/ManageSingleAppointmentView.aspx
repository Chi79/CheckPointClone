<%@ Page Language="C#" MasterPageFile="~/HostMaster.Master" AutoEventWireup="true" CodeBehind="ManageSingleAppointmentView.aspx.cs" Inherits="CheckPoint.Views.ManageSingleAppointmentView" %>

<%@ Register Src="~/UserControls/AppointmentCreator.ascx" TagPrefix="uc1" TagName="AppointmentCreator" %>



<asp:Content ContentPlaceHolderID="head" runat="server">

<style type="text/css">


/*#btnBackToHomePage{
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
}*/
.list1{
    position:fixed;
top:10%;
left:30%;
list-style:none;
width:100%;
padding:0%;
margin:0;
border:none;
}
.list1-item{
position:fixed;
top:90%;
left:30%;
list-style:none;
width:100%;
padding:0%;
margin:0;
border:none;
}





</style>

<title></title>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    
<ul class="list1">
    <li class="list1-item">
        <uc1:AppointmentCreator runat="server" ID="AppointmentCreator" />
        </li >
    <li class="list1-item">
                <asp:Button ID="btnUpdateAppointment" runat="server" Text="Update Appointment" OnClick="btnCreateAppointment_Click" />
        <asp:Button ID="btnDeleteAppointment" runat="server" Text="Delete Appointment" OnClick="btnDelete_Click" />
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Visible="False" Width="47px" />
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" Width="45px" />
        <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue Editing" Visible="False" />
    </li>

    </ul>


    </asp:Content>


