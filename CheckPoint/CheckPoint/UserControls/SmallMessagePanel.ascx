﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SmallMessagePanel.ascx.cs" Inherits="CheckPoint.Views.UserControls.SmallMessagePanel" %>

<style type="text/css">

.container1{
    position: absolute;
    width: 24%;
    height: 150px;
    margin-top: 32.5%;
    margin-left: 63.5%;
    background-color: #333333;
    border: #66cc66;
    border-width: 15px;
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
    padding: 7px;
}
.MessagePanelButton{
    position: relative;
    text-align: center;
    display: block;
    margin: -17px auto;
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
          <div class="MessagePanelButton">
          <asp:Button CssClass="PanelButton" ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Visible="False" Width="70px" />
          <asp:Button CssClass="PanelButton" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Visible="False" Width="70px" />
          </div>
          <asp:Button CssClass="MessagePanelContinueButton" ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continue" Width="130px" Visible="False" />

    </asp:panel>