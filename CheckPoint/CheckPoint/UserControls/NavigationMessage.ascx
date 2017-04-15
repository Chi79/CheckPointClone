<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationMessage.ascx.cs" Inherits="CheckPoint.Views.UserControls.NavigationMessage" %>

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

.lblNavigationMessage{
    position: absolute;
    top: 3em;
    left: 3em;
    color: white;
    font-size: xx-large;
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
    
        
        <asp:Label ID="lblNavigationMessage" runat="server" CssClass="lblNavigationMessage"></asp:Label>
    
</div>
</div>