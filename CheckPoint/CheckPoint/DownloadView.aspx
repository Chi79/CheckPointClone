﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HostMaster.Master" CodeBehind="DownloadView.aspx.cs" Inherits="CheckPoint.Views.DownloadView" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Download page</title>
    <style>
        h3{     
            color:white;
            line-height:2;
            display:inline-block;
        }
        h1{
            margin-bottom:3%;
        }
.button{
    display:inline-block; 
    color:white;
    text-decoration: none;
    width:auto;
    border-radius: 5px;
    border-width:0px;
    border-color:darkgreen;
    text-align:center;
    padding-left:1%;
    padding-right:1%;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    font-weight: 600;
    padding-top:2%;
    padding-bottom: 0%;
    background-image:url(/Images/buttonshade1.png);
    margin-bottom:3%;


}
@-webkit-keyframes flashingbutton{
    from{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:5px;  -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333; }
}
.button:hover {
        -webkit-animation: flashingbutton;
        -webkit-animation-duration: 2s;
        -webkit-animation-iteration-count: infinite;
}

.containter{
   
    width: 100%;
    height: 100%;
    background: #333333;
    margin-top:5%;
    padding: 0px;
    text-align:center;
    color:white;
}
.container-usermanual{
    float:left;
    width: 40%;
    height: 95%;
    margin-left: 3%;
    list-style:none;
    background-color: #333333;
    border: darkgreen;
    border-width: 20px;
    border-style: solid;
    border-radius: 36px;
    display:inline-block;
    padding:0%;
}
.container-reading-terminal{    
 display:inline-block;
    list-style:none;
    width: 40%;
    height: 95%;  
    background-color: #333333;
    border: darkgreen;
    border-width: 20px;
    border-style: solid;
    border-radius: 36px;
    padding:0%;
   
}
.list-item{
    margin-top:3%;
   
   margin-left:0;
    display:inline-block;
    width:77%;
    min-height:10%;
    

}
.imgclass{

    border:none;
    margin:0;
    padding:0%; 
    width:30%;
    height: auto;
    vertical-align:middle;
    line-height:3;

}

.heading{
    position:absolute;
    left:42%;
    display:inline-block;
    width:20%;
    text-align:center;
    z-index:5;

}

    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
   
         <img class="heading" src="Images/DownloadPage.svg">

     <div class="containter">
        


             <ul class="container-usermanual">
                 

                 <li class="list-item">
                     <img class="imgclass" src="Images/pdf2.svg" />
                 </li>
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
            <img class="imgclass" src="Images/installer2.svg" />
        </li>
                <li class="list-item">
             <h3>
                 Download the reading terminal installer file and get started with logging attendance!
             </h3>
        </li>
        <li class="list-item">
                <a class="button" href="Downloadable/Host/CheckPointReaderSetup.zip">Download reading terminal installer</a>
        </li>
    </ul>
        
             
                  

         

</asp:Content>
