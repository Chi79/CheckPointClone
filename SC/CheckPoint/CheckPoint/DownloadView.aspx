<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HostMaster.Master" CodeBehind="DownloadView.aspx.cs" Inherits="CheckPoint.Views.DownloadView" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Download page</title>
    <style>
        h3{
            margin-top:20%;
            color:white;
            line-height:2;
            display:inline-block;
        }
        h1{
            margin-bottom:3%;
        }
.button{
    display:inline-block;
    padding:0.5%;
    text-align:center;
    color:white;
    text-decoration: none;
    width:auto;
    border-radius: 5px;
    border-width:0px;
    border-color:darkgreen;
    text-align:center;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    font-weight: 600;
    background-image:url(/Images/buttonshade1.png);
}
.button:hover {
        -webkit-animation: flashingbutton;
        -webkit-animation-duration: 2s;
        -webkit-animation-iteration-count: infinite;
}

.containter{
    width: 100%;
    height: 500px;
    background: #333333;
    margin-top:0%;
    padding: 0px;
    text-align:center;
    color:white;
}
.container-usermanual{
    float:left;
    width: 40%;
    height: 485px;
    margin-left: 3%;
    list-style:none;
    background-color: #333333;
    border: darkgreen;
    border-width: 20px;
    border-style: solid;
    border-radius: 36px;
    display:inline-block;
}
.container-reading-terminal{    
 display:inline-block;
    list-style:none;
    width: 40%;
    height: 485px;  
    background-color: #333333;
    border: darkgreen;
    border-width: 20px;
    border-style: solid;
    border-radius: 36px;
   
}
.list-item{
    display:inline-block;
    width:100%;
    min-height:10%;
    

}


    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   
     <div class="containter">
         <h1> Please choose what to download</h1>
    

             <ul class="container-usermanual">
                 <li class="list-item">
                              <h3>
                 Download the user manual and get started with the checkpoint system!
             </h3>   
                 </li>
                 <li class="list-item">
                      <a class="button" href="Downloadable/Host/CheckPoint%20Host%20User%20Manual.pdf">Download user manual</a>
                 </li>
             </ul>
              
            
      
    <ul class="container-reading-terminal">
        <li class="list-item">
             <h3>
                 Download the reading terminal installer file and get started with logging attendance!
             </h3>
        </li>
        <li class="list-item">
                <a class="button" href="Downloadable/Host/ReadingTerminalSetup.zip">Download reading terminal installer</a>
        </li>
    </ul>
        
             
                  

         

</asp:Content>
