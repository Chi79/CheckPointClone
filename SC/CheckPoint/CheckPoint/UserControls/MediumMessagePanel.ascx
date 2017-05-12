<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediumMessagePanel.ascx.cs" Inherits="CheckPoint.Views.UserControls.MediumMessagePanel"  %>

<style type="text/css">

.container2{
    position: absolute;
    width: 28%;
    height: 311px;
    margin-top: 22%;
    margin-left: 61.5%;
    background-color: #333333;
    border: #66cc66;
    border-width: 20px;
    border-style: solid;
    border-radius: 36px;
    z-index: 30;
}
.Message{
    display: block;
    font-family: sans-serif;
    text-align: center;
    color: white;
    font-size: larger;
    margin: 0 auto;
    padding: 26px;
}
.MessagePanelButton{
    position: relative;
    text-align: center;
    display: block;
    margin: 0 auto;
}
.PanelButton{  

    margin: 32px;
    color: white;
    border-radius: 5px;
    border-width: 0px;
    border-color: darkgreen;
    padding-top: 0.5%;
    padding-bottom: 0.5%;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    font-weight: 600;
    background-image: url(/Images/buttonshade1.png);

}

.MessagePanelContinueButton{
    position: relative;
    color: white;
    display: block;
    margin: 0 auto;
    border-radius: 5px;
    border-width: 0px;
    border-color: darkgreen;
    padding-top: 0.5%;
    padding-bottom: 0.5%;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    font-weight: 600;
    background-image: url(/Images/buttonshade1.png);
 }
.PanelButton:hover {
        border-radius: 5px;
        -webkit-animation: flashingbutton;
        -webkit-animation-duration: 2s;
        -webkit-animation-iteration-count: infinite;
}
.MessagePanelContinueButton:hover {
        border-radius: 5px;
        -webkit-animation: flashingbutton;
        -webkit-animation-duration: 2s;
        -webkit-animation-iteration-count: infinite;
}

@-webkit-keyframes flashingbutton{
    from{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:5px;  -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333; }
}


</style>

     <asp:panel runat="server" ID="MediumMessageDisplayPanel"  CssClass="container2"  Visible="false">
        
          <asp:Label  CssClass="Message" ID="lblMediumMessage" runat="server"></asp:Label>
          <div class="MessagePanelButton">
          <asp:Button CssClass="PanelButton" ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Visible="False" Width="70px" />
          <asp:Button CssClass="PanelButton" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" Width="70px" />
          </div>
          <asp:Button CssClass="MessagePanelContinueButton" ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue" Width="130px" Visible="False" />
          <asp:Button CssClass="MessagePanelContinueButton" ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login.." Width="130px" Visible="False" />
          <asp:Button CssClass="MessagePanelContinueButton" ID="btnBackToFindAppointmentsMedium" runat="server" OnClick="btnBackToFindAppointments_Click" Text="Back To Find Appointments" Visible="False" />

    </asp:panel>