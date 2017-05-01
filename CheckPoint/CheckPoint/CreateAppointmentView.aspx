<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HostMaster.Master" CodeBehind="CreateAppointmentView.aspx.cs" Inherits="CheckPoint.Views.CreateAppointmentView" %>

<%@ Register Src="~/UserControls/AppointmentCreator.ascx" TagPrefix="uc1" TagName="AppointmentCreator" %>


<asp:Content ContentPlaceHolderID="head" runat="server">



<style type="text/css">



.lista{
    position:fixed;
top:10%;
left:30%;
list-style:none;
width:100%;
padding:0%;
margin:0;
border:none;
}
.lista-item{
position:fixed;
top:90%;
left:30%;
list-style:none;
width:100%;
padding:0%;
margin:0;
border:none;
}
@-webkit-keyframes flashingbutton{
    from{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:5px;  -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333; }
}
.button{
    color:white;

    border-radius: 5px;
    border-width:0px;
    border-color:darkgreen;
    margin-right:1%;
    padding-top:0.5%;
    padding-bottom: 0.5%;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    font-weight: 600;
    background-image:url(/Images/buttonshade1.png);
}
.button:hover {
        border-radius: 0px;
        -webkit-animation: flashingbutton;
        -webkit-animation-duration: 2s;
        -webkit-animation-iteration-count: infinite;
}





</style>

<title></title>
</asp:Content>


<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">



<ul class="lista">
    <li class="lista-item">
        <uc1:AppointmentCreator runat="server" id="AppointmentCreator" />
    </li>
    <li class="lista-item">
 <asp:Button CssClass="button" ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue" Visible="False" />
<asp:Button CssClass="button" ID="btnCreateAppointment" runat="server" Text="Create Appointment" OnClick="btnCreateAppointment_Click" />
<asp:Button CssClass="button" ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False"  />
<asp:Button CssClass="button" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />
    </li>
</ul>

</asp:Content>