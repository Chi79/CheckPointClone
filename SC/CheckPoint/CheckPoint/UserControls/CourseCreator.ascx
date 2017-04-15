﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseCreator.ascx.cs" Inherits="CheckPoint.Views.UserControls.CourseCreator" %>


<style type="text/css">

    

.list{   
    display:block;
    margin-top:15%;
    margin-left:15%;
    border:none;
    list-style:none;
    width:70%;    
    padding:0%;


}
.list-item{    
    color:white;
    font-size:large;
    font-family:'Times New Roman', Times, serif;
    font:bolder;
    width:100%;
    display:block;
    margin-top:2%;
    
}
.label{
    width:25%;
    float:left;
}
.message{
    margin-top:3%;
    width:25%;
    color:rgb(0, 255, 33)  ;

}
</style>


<div id="container" class="container">
<div id="panel" class="panel">
    
   
    <ul class="list">
        <li class="list-item">
              <div class="label">
                  Course name
              </div> 
               <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
        </li>

        <li class="list-item">
               <div class="label">  
            Description
                   </div>
             
        <asp:TextBox ID="txtDescription" runat="server" Width="275px"></asp:TextBox>

        </li>

        <li class="list-item">
            <div class="label"> 
             Private
                </div>
             

           <asp:DropDownList ID="ddlIsPrivate" runat="server">
            <asp:ListItem Value="False">No</asp:ListItem>
            <asp:ListItem Value="True">Yes</asp:ListItem>
           </asp:DropDownList>

        </li >

        <li class="list-item">
            <div class="label">   
            Obligatory
                    </div>

        <asp:DropDownList ID="ddlIsObligatory" runat="server">
            <asp:ListItem Value="False">No</asp:ListItem>
            <asp:ListItem Value="True">Yes</asp:ListItem>
        </asp:DropDownList>

        </li>

        <li class="list-item">
            
                  <asp:Label ID="lblMessage" CssClass="message" runat="server"></asp:Label>

        </li>

        </ul>
    
</div>
</div>