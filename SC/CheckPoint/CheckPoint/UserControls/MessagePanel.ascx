<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessagePanel.ascx.cs" Inherits="CheckPoint.Views.UserControls.MessagePanel"  %>

<style type="text/css">

.container1{
    position: relative;
    width: 46%;
    height: 317px;
    margin-top: 11%;
    margin-left: 24.5%;

    background-color: #333333;
    border: #66cc66;
    border-width: 20px;
    border-style: solid;
    border-radius: 36px;
    z-index: 1;
}
.Message{
    display: block;
    font-family: sans-serif;
    color: white;
    font-size: larger;
    margin: 0 auto;
    padding: 47px;
}
.MessagePanelButton{
    position: relative;
    color: white;
    margin-left: 134px;
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
    margin-left: 210px;
    margin-bottom: 0px;
    border-radius: 5px;
    border-width: 0px;
    border-color: darkgreen;
    margin-right: 8%;
    padding-top: 0.5%;
    padding-bottom: 0.5%;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    font-weight: 600;
    background-image: url(/Images/buttonshade1.png);
 }
.MessagePanelButton:hover {
        border-radius: 0px;
        -webkit-animation: flashingbutton;
        -webkit-animation-duration: 2s;
        -webkit-animation-iteration-count: infinite;
}
.MessagePanelContinueButton:hover {
        border-radius: 0px;
        -webkit-animation: flashingbutton;
        -webkit-animation-duration: 2s;
        -webkit-animation-iteration-count: infinite;
}


</style>

     <asp:panel runat="server" ID="MessageDisplayPanel"  CssClass="container1"  Visible="false">
        
          <asp:Label  CssClass="Message" ID="lblMessage" runat="server"></asp:Label>

          <asp:Button CssClass="MessagePanelButton" ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Visible="False" Width="70px" />
          <asp:Button CssClass="MessagePanelButton" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" Width="70px" />
          <asp:Button CssClass="MessagePanelContinueButton" ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue Editing" Visible="False" />

    </asp:panel>