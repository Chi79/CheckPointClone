<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HostMaster.Master" CodeBehind="CreateCourseView.aspx.cs" Inherits="CheckPoint.Views.CreateCourseView" %>

<asp:Content ContentPlaceHolderID="head" runat="server">




<style type="text/css">



.list{   
    position:fixed;
    top:15%;
    left:15%;
    border:none;
    list-style:none;
    width:70%;
    margin:0;
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
    margin-top:5px;
    width:25%;
    border:dotted rgb(0, 255, 33) 2px;
    border-radius:6px;
}
.button{
    border-radius:6px;
    border:outset gray 2px;
    padding:3px;
}

</style>

<title></title>
</asp:Content>


<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">


    
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

        <li class="list-item">

            <asp:Button CssClass="button" ID="btnCreateCourse" runat="server" Text="Create Course" OnClick="btnCreateCourse_Click" />
            <asp:Button CssClass="button" ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes"  Visible="False" />
            <asp:Button CssClass="button" ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No"  Visible="False" />

        </li>

          <li class="list-item">
              <asp:Button CssClass="button" ID="btnBackToCoursesPage" runat="server" OnClick="btnBackToCoursesPage_Click" Text="Back To Courses Page" />
              </li>

    </ul>
 

      
      
       




        
        




    


</asp:Content>
























