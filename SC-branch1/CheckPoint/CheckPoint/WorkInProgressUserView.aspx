<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserMaster.Master" CodeBehind="WorkInProgressUserView.aspx.cs" Inherits="CheckPoint.Views.WorkInProgressUserView" %>

<asp:Content ContentPlaceHolderID="head" runat="server">


    <title></title>
    <style>
.container{
    width:100%;
    height:100%;
    background:#333333; 
    
}
.image{
    position: fixed;
    top: 25%;
    left: 35%;
    display: block;
    height: auto;
    width: 25%;
    border-radius: 10px;
    margin: 0;
    padding: 0%;
    border: none;
    border-image: none;
}

    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">



        <div class="container">


    <div>
      <img class="image" alt="work in progress" src="Images/WorkInProgress1.png" />
    </div>
            </div>
</asp:Content>