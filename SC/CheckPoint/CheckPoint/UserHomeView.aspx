<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="UserHomeView.aspx.cs"  Inherits="CheckPoint.Views.UserHomeView"  EnableEventValidation="false"  MasterPageFile="~/Master.Master" %>

<!DOCTYPE html>


<title></title>

<style type="text/css">
        /*.auto-style1 {
            z-index: 50;
        }*/
html, body, div, applet,span, object, iframe,
h1, h2, h3, h4, h5, h6, p, blockquote, pre,
a, abbr, acronym, address, big, cite, code,
del, dfn, em, img, ins, kbd, q, s, samp,
small, strike, strong, sub, sup, tt, var,
b, u, i, center,
dl, dt, dd, ol, ul, li,
fieldset, form, label, legend,
table, caption, tbody, tfoot, thead, tr, th, td,
article, aside, canvas, details, embed, 
figure, figcaption, footer, header, hgroup, 
menu, nav, output, ruby, section, summary,
time, mark, audio, video 
{
margin: 0;
padding: 0;
border: 0;
font-size: 100%;
font: inherit;
vertical-align: baseline;
}
/* HTML5 display-role reset for older browsers */
article, aside, details, figcaption, figure, 
footer, header, hgroup, menu, nav, section {
	display: block;
}
body {
	line-height: 1;
}
ol, ul {
	list-style: none;
}
blockquote, q {
	quotes: none;
}
blockquote:before, blockquote:after,
q:before, q:after {
	content: '';
	content: none;
}
table {
	border-collapse: collapse;
	border-spacing: 0;
}



.gvHeadSelect{
    z-index:12;
    position:fixed;
    width:0%;
    padding-left:0%;
    visibility:hidden;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-bottom-left-radius:10px 10px;
    border-top-left-radius:10px;
}
.gvHeadSelectItem{

}
.gvHeaderSelectTitle{
    padding-top:0%;
}
.gvHeadAppointmentId{
    z-index:11;
    position:fixed;
    width:11%;
    padding-left:0%;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px;
    clip: rect(10px,153px,83px,15px);
}
.gvHeadAppointmentIdAsc{
    margin-top:13%;
    border-radius:10px;
}
.gvHeadAppointmentIdDes{
    border-radius:10px;
}
.gvHeadAppointmentIdAsc:hover{
    margin-top:13%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadAppointmentIdDes:hover{
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadAppointmentIdTitle{
    padding-top:11%;
    font-size:22px;
}
.gvHeadAppointmentIdItem{
       
}
.gvHeadCourseId{
    z-index:10;
    position:fixed;
    width:17%;
    padding-left:8.9%;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px
}
.gvHeadCourseIdAsc{
    margin-top:18%;
    border-radius:10px;
}
.gvHeadCourseIdDes{
    padding-top:5%;
    border-radius:10px;
}
.gvHeadCourseIdAsc:hover{
    margin-top:18%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadCourseIdDes:hover{
    padding-top:0%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadCourseIdTitle{
    padding-top:15%;
    font-size:22px;
}
.gvHeadCourseIdItem{

}
.gvHeadAppointmentName{
    z-index:9;
    position:fixed;
    width:27%;
    padding-left:15.7%;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px
}
.gvHeadAppointmentNameAsc{
    margin-top:12%;
    border-radius:10px;
}
.gvHeadAppointmentNameDes{
    padding-top:1%;
    border-radius:10px;
}
.gvHeadAppointmentNameAsc:hover{
    margin-top:12%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadAppointmentNameDes:hover{
    padding-top:1%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadAppointmentNameTitle{
    padding-top:11%;
    font-size:22px;
}
.gvHeadAppointmentNameItem{

}
.gvHeadDescription{
    z-index:8;
    position:fixed;
    width:34%;
    padding-left:26.7%;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px
}
.gvHeadDescriptionAsc{
    margin-top:20%;
    border-radius:10px;
}
.gvHeadDescriptionDes{
    padding-top:0%;
    border-radius:10px;
}
.gvHeadDescriptionAsc:hover{
    margin-top:20%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadDescriptionDes:hover{
    padding-top:0%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadDescriptionTitle{
    padding-top:17%;
    font-size:22px;
}
.gvHeadDescriptionItem{

}
.gvHeadDate{
    z-index:7;
    position:fixed;
    width:43%;
    padding-left:34%;
    padding-top:7px;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px
}
.gvHeadDateAsc{
    margin-top:16%;
    border-radius:10px;
}
.gvHeadDateDes{
    padding-top:0%;
    border-radius:10px;
}
.gvHeadDateAsc:hover{
    margin-top:16%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadDateDes:hover{
    padding-top:0%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadDateTitle{
    padding-top:9%;
    font-size:22px;
}
.gvHeadDateItem{

}
.gvHeadStartTime{
    z-index:6;
    position:fixed;
    width:50%;
    padding-left:41.7%;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px
}
.gvHeadStartTimeAsc{
    margin-top:19%;
    border-radius:10px;
}
.gvHeadStartTimeDes{
    padding-top:5%;
    border-radius:10px;
}
.gvHeadStartTimeAsc:hover{
    margin-top:19%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadStartTimeDes:hover{
    padding-top:0%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadStartTimeTitle{
    padding-top:14%;
    font-size:22px;
}
.gvHeadStartTimeItem{

}
.gvHeadEndTime{
    z-index:5;
    position:fixed;
    width:57%;
    padding-left:49%;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px
}
.gvHeadEndTimeeAsc{
    margin-top:19%;
    border-radius:10px;
}
.gvHeadEndTimeDes{
    margin-top:10%;
    border-radius:10px;
}
.gvHeadEndTimeeAsc:hover{
    margin-top:19%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadEndTimeDes:hover{
    margin-top:10%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadEndTimeTitle{
    padding-top:15%;
    font-size:22px;
}
.gvHeadEndTimeItem{

}
.gvHeadAddress{
    z-index:4;
    position:fixed;
    width:64%;
    padding-left:55.5%;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px
}
.gvHeadAddresseAsc{
    margin-top:18%;
    border-radius:10px;
}
.gvHeadAddressDes{
    padding-top:2%;
    border-radius:10px;
}
.gvHeadAddresseAsc:hover{
    margin-top:18%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadAddressDes:hover{
    padding-top:0%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadAddressTitle{
    padding-top:14%;
    font-size:22px;
}
.gvHeadAddressItem{

}
.gvHeadPostalCode{
    z-index:3;
    position:fixed;
    width:71%;
    height: 95px;
    padding-left:64.6%;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px
}
.gvHeadPostalCodeAsc{
    margin-top:24%;
    border-radius:10px;
}
.gvHeadPostalCodeDes{
    padding-top:0%;
    border-radius:10px;
}
.gvHeadPostalCodeAsc:hover{
    margin-top:24%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadPostalCodeDes:hover{
    padding-top:0%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadPostalCodeTitle{
    padding-top:18%;
    font-size:22px;
}
.gvHeadPostalCodeItem{

}
.gvHeadIsObligatory{
    z-index:2;
    position:fixed;
    width:80%;
    height: 94px;
    padding-left:72.3%;
    background: url(/Images/headershade3.png) repeat-x;
    border-style:hidden;
    border-radius:10px
}
.gvHeadIsObligatoryAsc{
    margin-top:20%;
    border-radius:10px;
}
.gvHeadIsObligatoryDes{
    padding-top:0%;
    border-radius:10px;
}
.gvHeadIsObligatoryAsc:hover{
    margin-top:20%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadIsObligatoryDes:hover{
    padding-top:0%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadIsObligatoryTitle{
    padding-top:15%;
    font-size:22px;
}
.gvHeadIsObligatoryItem{

}
.gvHeadIsCancelled{
    z-index:1;
    position:fixed;
    width:88.6%;
    padding-left:80.1%;
    height: 96px;
  
    background: url(/Images/headershade3.png) repeat-x;
    border-bottom-right-radius:10px;
    border-top-right-radius:10px;
    border-radius:10px
}
.gvHeadIsCancelledAsc{
    margin-top:17.7%;
    border-radius:10px;
}
.gvHeadIsCancelledDes{
    padding-top:0%;
    border-radius:10px;
}
.gvHeadIsCancelledAsc:hover{
    margin-top:17.7%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadIsCancelledDes:hover{
    padding-top:0%;
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
.gvHeadIsCancelledTitle{
    padding-top:13%;
    font-size:22px;
}
.gvHeadIsCancelledItem{

}
.gvRow td{
    vertical-align:middle;
    padding-top:10px;
    padding-bottom:10px;
}
.gvRowAlt td{
    vertical-align:middle;
    padding-top:10px;
    padding-bottom:10px;
}
.gvHostTable1 tbody{
    background-color:transparent;
}
.gvHostTable1  tr{
    background-color:transparent;
    border-radius:10px
}
tbody{
    background-color:transparent;
}
tr{
    background-color:transparent;
}
th{
    background-color:transparent;
}
td{
font-family:'Yu Gothic';
font-weight:bold;
}



.SelectImage{
    width:24px;
    margin-right:auto
}
.AppointmentIdLabel{
    width:49px;
    margin-right:9px;
}
.CourseIdLabel{
    width:49px;
    margin-right:26px;
}
.AppointmentNameLabel{
    width:49px;
    margin-right:auto
}
.DescriptionLabel{
    width:49px;
    margin-right:auto
}
.DateLabel{
    width:49px;
    margin-right:-36px;
    vertical-align:text-bottom;
}
.StartTimeLabel{
    width:49px;
    margin-right:-14px;
}
.EndTimeLabel{
    width:49px;
    margin-right:-11px;
}
.AddressLabel{
    width:49px;
    margin-right:-20px
}
.PostCodeLabel{
    width:49px;
    margin-right:-20px
}
.IsObligatoryImageTrue{
    width:49px;
    margin-right:-22px;
}
.IsObligatoryImageFalse{
    width:49px;
    margin-right:-22px;
}

.IsCancelledImageTrue{
    width:49px;
    margin-right:auto
}
.IsCancelledImageFalse{
    width:49px;
    margin-right:auto
}






.gvRow:hover{
      background:#32E236 url(/Images/greenshade1.png) repeat-x;
      color:white;
      fill:#32E236;  
      -webkit-animation:glowingrow;
      -webkit-animation-duration:2s;
      -webkit-animation-iteration-count:infinite;
}
.gvRowAlt:hover{
      background: #32E236 url(/Images/greenshade1.png) repeat-x; 
      background-color:#32E236;
      color:white;
      fill:#32E236;  
      -webkit-animation:glowingrow;
      -webkit-animation-duration:2s;
      -webkit-animation-iteration-count:infinite;     
}
.gvRowAlt {
      background-color: #C6F5B8;
      color: black;
      fill: #C6F5B8;
}
.gvHeadcenter {
      background: url(/Images/headershade3.png) repeat-x;
      border-style:hidden;
}
.gvHeadleft {
      background: url(/Images/headershade3.png) repeat-x;
      border-style:hidden;
      border-bottom-left-radius:10px 10px;
      border-top-left-radius:10px;
}
.gvHeadright {
      background: url(/Images/headershade3.png) repeat-x;
      border-style:hidden;
      border-bottom-right-radius:10px 10px;
      border-top-right-radius:10px;
}
.roundedleft{
      border-bottom-left-radius:10px;
      border-top-left-radius:10px;
      border:hidden;
}
.roundedright{
      border-bottom-right-radius:10px;
      border-top-right-radius:10px;
      border:hidden;
}
.centerborders{
      border:hidden;
}
.roundedbutton{
      border-radius:10px 10px;
}





.buttons1{
      z-index:3;
      position: absolute;
      left: 27%;
      top: 81%;
      margin: 39.5em -244px;
      animation: buttonsup 2s ;
}
.buttons2{
      z-index:3;
      position: absolute;
      left: 38%;
      top: 81%;
      margin: 39.5em -244px;
      animation: buttonsup 3s ;
}
.buttons3{
      z-index:3;
      position: absolute;
      left: 49%;
      top: 81%;
      margin: 39.5em -244px;
      animation: buttonsup 4s ;
}
.buttons4{
      z-index:3;
      position: absolute;
      left: 60%;
      top: 81%;
      margin: 39.5em -244px;
      animation: buttonsup 5s;
}
.buttons5{
      z-index:3;
      position: absolute;
      left: 71%;
      top: 81%;
      margin: 39.5em -244px;
      animation: buttonsup 6s ;
}
@keyframes buttonsup {
      from { top: 300%; }
      to { top: 81%;}
}
.fabiotop {
      position: absolute;
      left: 15%;
      top: 73%;
      margin: 37em -244px;
      animation: fabiotop 7s;
      -webkit-animation:lazereyes;
      -webkit-animation-duration:6s;
      -webkit-animation-iteration-count:infinite;
}
@keyframes fabiotop {
      from { top: 300%; }
      to { top: 73%; }
}
.goosebottom {
      position: absolute;
      left: 92%;
      top: 70%;
      margin: 35.5em -244px;
      animation: goosebottom 9s;
}   
@keyframes goosebottom {  
      from {top:300%;}
      to {top:70%;}   
}

.slideleft {
      position: absolute;
      left: 85%;
      top: -27%;
      margin: 0em -244px;
      animation: slideleft 2s ;
}
@keyframes slideleft {
      from { left: -100%; }
      to { left: 85%; }
}
@keyframes slideright {
      from { right: -100%; }
      to { right: 3%; }
}
.auto-style1 {
      height: 248px;
}
.fabiotop span {
      visibility: hidden;
}
.fabiotop:hover span{
      visibility: visible;
}
.outercontainer{
      z-index:0;
      width:100%;
      height:0%;
      background-color:#333333;
}
.container{
      width:95%;
      position: absolute;
      right: 3%;
      margin: 2.5em -244px;
      animation: slideright 2s;
}

.griddata{
      margin-top:-5.0%;
}
@-webkit-keyframes glowingbutton{
    from{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:10px; -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 9px #333; }
}
@-webkit-keyframes glowingrow{
    from{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 12px #333;}
     50%{ background-color:#00ff00; border-radius:10px; -webkit-box-shadow: 0 0 24px #00ff00; }
      to{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 12px #333; }
}
@-webkit-keyframes lazereyes{
    from{ background-image:url(Images/fabio.png); opacity:0.2; }
    20%{ background-image:url(Images/fabioeyes1.png); opacity:0.4; }
    30%{ background-image:url(Images/fabioeyes.png); opacity:0.6; }
    40%{ background-image:url(Images/fabioeyes1.png); opacity:0.7; }
    50%{ background-image:url(Images/fabiolazereyes.png); opacity:0.8; }
    60%{ background-image:url(Images/fabiolazereyes2.png); opacity:0.9; }
    70%{ background-image:url(Images/fabiolazereyes4.png); opacity:0.9; }
    80%{ background-image:url(Images/fabiolazereyes5.png); opacity:0.9; }
    90%{ background-image:url(Images/fabiolazereyes6.png); opacity:0.9; }
    to{ background-image:url(Images/fabiolazereyes3.png); opacity:1; }
}
    </style>

   </asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">



    <div id ="outercontainer" class="outercontainer" >
    <div id="container" class="container" style="width: 106.2%; top: -34px;" >

         <asp:ScriptManager
              ID="ScriptManager1"
              runat="server">
        </asp:ScriptManager> 


        <div id="fabio" class="fabiotop" style="z-index:4"><img src="Images/fabio.png" style="opacity:0.2;" /><span style="position:absolute; z-index:5; top:-80%;"><img src="Images/angrygoose.png"/></span></div>
        <div id="goose" class="goosebottom" style="z-index:3"><img src="Images/goose.png"/></div>
        <div id="logo" class="slideleft" style="z-index:5"><img src="Images/logo4.png" /></div>


        <div id="buttons" runat="server" style="z-index:5;" class="buttons1">
        <asp:UpdatePanel ID="buttonspanel" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedbutton" 
            id="update" ImageUrl="~/Images/createappointmentbutton.png" 
            OnClick="createAppointment_Click"
            ToolTip="create a new appointment" />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttons2" runat="server" style="z-index:5;" class="buttons2">
        <asp:UpdatePanel ID="buttonspanel2" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedbutton" 
            id="managecourses"
             ImageUrl="~/Images/manageappointmentbutton.png" 
            OnClick="manageAppointment_Click"
            ToolTip="manage the selected appointment"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttons3" runat="server" style="z-index:5;" class="buttons3">
        <asp:UpdatePanel ID="buttonspanel3" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedbutton" 
            id="manageappointments" 
            ImageUrl="~/Images/managecoursesbutton1.png" 
            OnClick="managecourses_Click" 
            ToolTip="manage your courses" />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttons4" runat="server" style="z-index:5;" class="buttons4">
        <asp:UpdatePanel ID="buttonspanel4" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server"
             CssClass="roundedbutton" 
            id="manageattendance" 
            ImageUrl="~/Images/manageattendancebutton1.png"
            OnClick="manageattendance_Click" 
            ToolTip="manage attendance"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttons5" runat="server" style="z-index:5;" class="buttons5">
        <asp:UpdatePanel ID="buttonspanel5" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedbutton" 
            id="createreport" 
            ImageUrl="~/Images/createreportbutton1.png" 
            OnClick="createreport_Click"  
            ToolTip="create a report" />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>



            <asp:Panel
            ID="Panel2"
            runat="server" 
            Height="15%"           
            Width="85%" 
            ScrollBars="None"
            BorderWidth="1" 
            BorderColor="#333333" 
            style="margin-left: 0%; 
            margin-right: 0px;"
            BackColor="#333333" 
            BorderStyle="None">

       
             <asp:UpdatePanel 
                 ID="UpdatePanel2"  
                 runat="server" >
                 <ContentTemplate>
                     <asp:Label 
                         ID="lblMessage" 
                         runat="server" 
                         Text="HostHomePage">
                     </asp:Label>
                     <asp:GridView 
                          ID="gvHostTable1" 
                          runat="server" 
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                          Height="70%" 
                          OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged" 
                          ShowHeader="true"
                          ShowHeaderWhenEmpty="True"
                          style="margin-left: 0px; 
                          margin-top: 25px; 
                          margin-right:10%;
                          z-index:2;"
                          Width="98.7%"
                          ShowFooter="false">
                          
                         <Columns>
                             <asp:TemplateField ShowHeader="true">
                                 <HeaderStyle CssClass="gvHeadSelect" />
                                       <ItemTemplate>
                                       <asp:ImageButton 
                                           ID="SelectButton" 
                                           runat="server" 
                                           CausesValidation="False" 
                                           CommandName="Select" 
                                           ImageUrl="~/Images/small_logo.png" />
                                     </ItemTemplate>
                                 <ItemStyle 
                                     CssClass="gvHeadSelectItem" />
                                 <HeaderStyle Width="2.5%" />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId" >
                                 <HeaderTemplate>
                                     <h3 class="gvHeadAppointmentIdTitle" style="color:white;">AppointmentId</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="AppointmentId" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         CssClass="gvHeadAppointmentIdAsc" 
                                         ToolTip="sort by ascending" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="AppointmentId" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command"  
                                         CssClass="gvHeadAppointmentIdDes" 
                                         ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="2.3%" CssClass="gvHeadAppointmentIdItem" />
                                 <HeaderStyle  CssClass="gvHeadAppointmentId" />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadCourseIdTitle" style="color:white;">CourseId</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="CourseId" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         CssClass="gvHeadCourseIdAsc" 
                                         ToolTip="sort by ascending" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="CourseId" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadCourseIdDes" 
                                         ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="gvHeadCourseIdItem" />
                                 <HeaderStyle  CssClass="gvHeadCourseId"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderText="AppointmentName">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadAppointmentNameTitle" style="color:white;">Name</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="AppointmentName" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         CssClass="gvHeadAppointmentNameAsc" 
                                         ToolTip="sort by ascending" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="AppointmentName" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadAppointmentNameDes" 
                                         ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%"  CssClass="gvHeadAppointmentNameItem"/>
                                 <HeaderStyle  CssClass="gvHeadAppointmentName"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadDescriptionTitle" style="color:white;">Description</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Description" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         CssClass="gvHeadDescriptionAsc" 
                                         ToolTip="sort by ascending" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Description" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadDescriptionDes" 
                                         ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="gvHeadDescriptionItem" />
                                 <HeaderStyle  CssClass="gvHeadDescription"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadDateTitle" style="color:white;">Date</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Date" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         CssClass="gvHeadDateAsc" 
                                         ToolTip="sort by ascending" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Date" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadDateDes" 
                                         ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="gvHeadDateItem" />
                                 <HeaderStyle CssClass="gvHeadDate"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadStartTimeTitle" style="color:white;" >StartTime</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="StartTime" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command"  
                                         CssClass="gvHeadStartTimeAsc" 
                                         ToolTip="sort by ascending"/>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="StartTime" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadStartTimeDes" 
                                         ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="8%"  CssClass="gvHeadStartTimeItem"/>
                                 <HeaderStyle  CssClass="gvHeadStartTime" />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadEndTimeTitle" style="color:white;">EndTime</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="EndTime" 
                                         ImageUrl="~/Images/uparrow3.png"
                                         OnCommand="Asc_Command" 
                                         CssClass="gvHeadEndTimeeAsc" 
                                         ToolTip="sort by ascending" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="EndTime" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadEndTimeDes" 
                                         ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="gvHeadEndTimeItem" />
                                 <HeaderStyle CssClass="gvHeadEndTime"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadAddressTitle" style="color:white;">Address</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Address" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         CssClass="gvHeadAddresseAsc" 
                                         ToolTip="sort by ascending" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Address" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadAddressDes" 
                                         ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="gvHeadAddressItem" />
                                 <ItemStyle Width="2%" />
                                 <HeaderStyle  CssClass="gvHeadAddress"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadPostalCodeTitle" style="color:white;">PostalCode</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="PostalCode" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         CssClass="gvHeadPostalCodeAsc" 
                                         ToolTip="sort by ascending"/>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="PostalCode" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadPostalCodeDes" 
                                         ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="gvHeadPostalCodeItem" />
                                 <HeaderStyle  CssClass="gvHeadPostalCode"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadIsObligatoryTitle" style="color:white;">Obligatory</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="IsObligatory" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command"  
                                         CssClass="gvHeadIsObligatoryAsc" 
                                         ToolTip="sort by ascending"/>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="IsObligatory" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadIsObligatoryDes" 
                                         ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="gvHeadIsObligatoryItem" />
                                 <HeaderStyle CssClass="gvHeadIsObligatory"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled">
                                 <HeaderTemplate>
                                     <h3 class="gvHeadIsCancelledTitle" style="color:white;">Cancelled</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="IsCancelled" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         CssClass="gvHeadIsCancelledAsc" 
                                         ToolTip="sort by ascending" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="IsCancelled" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         CssClass="gvHeadIsCancelledDes" 
                                         ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="gvHeadIsCancelledItem" />
                                 <HeaderStyle CssClass="gvHeadIsCancelled"/>
                             </asp:TemplateField>
                         </Columns>
                         <HeaderStyle />
                         <SelectedRowStyle BackColor="#32E236" />
                     </asp:GridView>
                 </ContentTemplate>
                 </asp:UpdatePanel>

                </asp:Panel> 


           <asp:Panel 
            ID="Panel1"
            runat="server" 
            style="margin-left: 0.0%;
                   margin-top:6%;
                   position:absolute; 
                   height:32.5em; 
                   width:84.5%;
                   overflow-y:scroll">


 
            <asp:UpdatePanel 
                ID="UpdatePanel1"  
                runat="server" >
                <ContentTemplate>
                  <asp:Label 
                      ID="lblIndex" 
                      runat="server">
                  </asp:Label>
                        
                      
                      <script type="text/javascript">
 
                      $(function () {
                      $(".picker").datepicker({
                      showOn: "button",
                      buttonImage: "/images/calendar2.png",
                      buttonImageOnly: true,
                      buttonText: "calender"
                          });
                              $(".picker").datepicker("setDate", $(".picker"))
                          });

                      var prm = Sys.WebForms.PageRequestManager.getInstance();
                      if (prm != null) {
                          prm.add_endRequest(function (sender, e) {
                                  if (sender._postBackSettings.panelsToUpdate != null) {
                                      $(".picker").datepicker({
                                          showOn: "button",
                                          buttonImage: "/images/calendar2.png",
                                          buttonImageOnly: true,
                                          buttonText: "calender"
                                      });
                              }
                              });
                      };
            </script>


              <asp:GridView
                  ID="gvHostTable"
                  runat="server"
                  AutoGenerateColumns="False" 
                  Height="70%" 
                  Width="100%"  
                  style="margin-left:0px; 
                  margin-top:0%; 
                  margin-right:10%;
                  z-index:1" 
                  AllowSorting="True" 
                  OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged"
                  OnRowDataBound="gvHostTable_RowDataBound"
                  ShowHeaderWhenEmpty="True" 
                  ShowHeader="false" 
                  DataKeyNames="AppointmentId"
                  CssClass="griddata">
                  
                <RowStyle CssClass="gvRow" BackColor="White"  />
                <AlternatingRowStyle
                    VerticalAlign="Middle" 
                    Wrap="True"
                    CssClass="gvRowAlt" BackColor="#99FF99" />
                <Columns>
                    <asp:TemplateField ShowHeader="true" > 
                        <ItemTemplate>
                            <asp:ImageButton ID="SelectButton" CssClass="SelectImage" runat="server"  CausesValidation="False" CommandName="Select" ImageUrl="~/Images/small_logo.png" />
                        </ItemTemplate>
                        <HeaderStyle BackColor ="#10591B" />
                        <ItemStyle Width="1%" CssClass="roundedleft" />
                    </asp:TemplateField>  
                   
                    <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId">
                        <HeaderTemplate>
                            <h3 style="color:white" >AppointmentId</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppId" CssClass="AppointmentIdLabel" runat="server" Text='<%# Bind("AppointmentId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"  CssClass="centerborders" />
 

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId">
                        <HeaderTemplate>
                            <h3 style="color:white">CourseId</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCourseId" CssClass="CourseIdLabel" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="centerborders" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderStyle-BackColor="#168927" HeaderText="AppointmentName">
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentName</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppName" CssClass="AppointmentNameLabel" runat="server" Text='<%# Bind("AppointmentName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="centerborders" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description">
                        <HeaderTemplate>
                            <h3 style="color:white">Description</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" CssClass="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10.2%"  CssClass="centerborders"/>
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date">
                        <HeaderTemplate>
                            <h3 style="color:white">Date</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDate" CssClass="DateLabel" runat="server" Text='<%# Convert.ToDateTime(Eval("Date")).ToString("MM/dd/yyyy") %>' Height="15%"></asp:Label>
                            <input type="hidden" class="picker" id="datepicker" value='<%# Convert.ToDateTime(Eval("Date")).ToString("MM/dd/yyyy") %>'/>   
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8.4%"  CssClass="centerborders" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime">
                        <HeaderTemplate>
                            <h3 style="color:white">StartTime</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStartTime" CssClass="StartTimeLabel" runat="server" Text='<%# Bind("StartTime") %>' ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8%"  CssClass="centerborders" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime" >
                        <HeaderTemplate>
                            <h3 style="color:white">EndTime</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEndTime" CssClass="EndTimeLabel" runat="server" Text='<%# Bind("EndTIme") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="centerborders" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address">
                        <HeaderTemplate>
                            <h3 style="color:white">Address</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" CssClass="AddressLabel" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="centerborders" />
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode">
                        <HeaderTemplate>
                            <h3 style="color:white">PostalCode</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPostalCode" CssClass="PostCodeLabel" runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"  CssClass="centerborders"/>
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory">
                        <HeaderTemplate>
                            <h3 style="color:white">IsObligatory</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image ID="IsObligTrue" CssClass="IsObligatoryImageTrue" runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsObligatory").Equals(true) %>'/>
                            <asp:Image ID="IsObligFalse" CssClass="IsObligatoryImageFalse" runat="server"  ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsObligatory").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="centerborders" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled">
                        <HeaderTemplate>
                            <h3 style="color:white">IsCancelled</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                              <asp:Image ID="IsCancelledTrue" CssClass="IsCancelledImageTrue" runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsCancelled").Equals(true) %>' />
                            <asp:Image ID="IsCancelledFalse" CssClass="IsCancelledImageFalse" runat="server" ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsCancelled").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="roundedright"/>
                    </asp:TemplateField>

                </Columns>
                <SelectedRowStyle 
                    BackColor="#32E236" ForeColor="White" />
            </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </asp:Panel>
       </div>
       </div>

    </asp:Content>
