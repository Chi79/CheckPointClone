<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppointmentCreator.ascx.cs" Inherits="CheckPoint.Views.UserControls.AppointmentCreator" %>



<style type="text/css">
  

.container{
    width: 100%;
    height: auto;
    margin:0;
    padding:0%;
    background-color: #333333;
    border: none;

}

.panel{
    position:relative;
}

.list{
    color:white;
    position:fixed;
    top:10%;
    left:30%;
    list-style:none;
    width:60%;
    padding:0%;
    margin:0;
    border:none;
}

.list-item{

    width:100%;
    display:inline-block;
    border:none;
    padding:0%;
    margin:0;
    line-height:3;   
    background-color: #333333;
}
.list-item-label{
    display: inline-block;
    font-family: sans-serif;
    font-size: large;
    font-weight:bolder;
    width: 22%;
    color: white;
    border: none;
    padding: 0%;
    margin: 0;
    zoom: 101%;
}
.list-item-box{
    display: inline-block;
    border:none;
    padding:0%;
    margin:0;
    zoom: 171%;
}
</style>


<div id="container" class="container">
<div id="panel" class="panel">
    
    <ul class="list">
        <li class="list-item">
                    <asp:Label CssClass="list-item-label" ID="lblAppointmentName" runat="server" Text="Appointment Name"></asp:Label>
        <asp:TextBox CssClass="list-item-box" ID="txtAppointmentName" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">
             <asp:Label CssClass="list-item-label" ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox CssClass="list-item-box" ID="txtAppointmentDescription" runat="server" ></asp:TextBox>
        </li>
        <li class="list-item">
                    <asp:Label CssClass="list-item-label" ID="lblDate" runat="server" Text="Date"></asp:Label>
        <asp:TextBox CssClass="list-item-box" ID="txtDate" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">
                   <asp:Label CssClass="list-item-label" ID="lblStartTime" runat="server" Text="Start Time"></asp:Label>
        <asp:TextBox CssClass="list-item-box" ID="txtStartTime" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">  
                    <asp:Label CssClass="list-item-label" ID="lblEndTime" runat="server" Text="End Time"></asp:Label>
        <asp:TextBox CssClass="list-item-box" ID="txtEndTime" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">
                    <asp:Label CssClass="list-item-label" ID="lblPostalCode" runat="server" Text="Postal Code"></asp:Label>
        <asp:TextBox CssClass="list-item-box" ID="txtPostalCode" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">
                    <asp:Label CssClass="list-item-label" ID="lblAddress" runat="server" Text="Address"></asp:Label>
        <asp:TextBox CssClass="list-item-box" ID="txtAddress" runat="server"></asp:TextBox>
        </li>
        <li class="list-item">
            
        <asp:Label CssClass="list-item-label" ID="lblObligatory" runat="server" Text="Obligatory"></asp:Label>

        <asp:DropDownList CssClass="list-item-box" ID="ddlIsObligatory" runat="server">
            <asp:ListItem Value="False">No</asp:ListItem>
            <asp:ListItem Value="True">Yes</asp:ListItem>
        </asp:DropDownList>
        </li>
        <li class="list-item">
            
        <asp:Label CssClass="list-item-label" ID="lblPrivate" runat="server" Text="Private"></asp:Label>

        <asp:DropDownList CssClass="list-item-box" ID="ddlIsPrivate" runat="server">
            <asp:ListItem Value="False">No</asp:ListItem>
            <asp:ListItem Value="True">Yes</asp:ListItem>
        </asp:DropDownList>
        </li>
        <li class="list-item">
                    
        <asp:Label CssClass="list-item-label" ID="lblCancelled" runat="server" Text="Cancelled"></asp:Label>

        <asp:DropDownList CssClass="list-item-box" ID="ddlIsCancelled" runat="server">
            <asp:ListItem Value="False" >No</asp:ListItem>
            <asp:ListItem Value="True" >Yes</asp:ListItem>
        </asp:DropDownList>
        </li>
              
        <li class="list-item">
            <asp:Label  ID="lblMessage1" runat="server"></asp:Label>
        </li>
    </ul>



      

       





 










  
    
</div>
</div>
