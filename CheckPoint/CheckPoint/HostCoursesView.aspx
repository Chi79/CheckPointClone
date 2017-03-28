<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HostCoursesView.aspx.cs" Inherits="CheckPoint.Views.HostCoursesView" EnableEventValidation="false"  MasterPageFile="~/HostMaster.Master" %>

<%@ Register Src="~/UserControls/CourseGridView.ascx" TagPrefix="uc1" TagName="CourseGridView" %>
<%@ Register Src="~/UserControls/CourseGridViewHeader.ascx" TagPrefix="uc1" TagName="CourseGridViewHeader" %>




<asp:Content ContentPlaceHolderID="head" runat="server">


<title></title>

<style type="text/css">
  


/*html, body, div, applet,span, object, iframe,
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
}
/* HTML5 display-role reset for older browsers */
/*article, aside, details, figcaption, figure, 
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
}*/


/*.roundedButtons {
    border-radius: 10px;
}
.roundedButtons:hover{
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
@-webkit-keyframes glowingbutton{
    from{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:10px; -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 9px #333; }
}*/


/*.courseIdColumnItem{
    width: 9.09%;
    padding-left: 0%;
    padding-right:1%;
    margin: auto;
}
.courseNameColumnItem{
    width: 12.09%;
    padding-left: 0%;
    margin: auto;
}
.descriptionColumnItem{
    width: 11.09%;
    padding-left: 2%;
    margin: auto;
}
.isPrivateColumnItem{
    width: 10.09%;
    padding-left: 1%;
    margin: auto;
}*/


/*.courseIdHeader{
    width: 7.5%;
    margin: auto;
}
.courseNameHeader{
    width: 11%;
    margin: auto;
    padding-right:0%;
}
.descriptionHeader{
    width: 9%;
    margin: auto;
    padding-right: 0%;
}
.isPrivateHeader{
    width: 9%;
    margin: auto;
}*/



/*.datediv{
    width: 117px;
    margin: auto;
    padding-right: 8px;
}*/

.Panel1{
    position:relative; 
    height:470px; 
    width:100%;
    overflow-y:scroll;
    right:1%;
    border-bottom-left-radius: 10px;
}
.Panel2{
    height:100%;
    width:100%;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    padding-bottom: 5px;
    position:relative;
    right:1%;
}

/*.Row td{
    padding-top: 0.5%;
    padding-bottom: 0.5%;
    vertical-align: middle;
    text-align:center;
    font-family: sans-serif;
    font-size: 15px;
}
.AltRow td{
    padding-top: 0.5%;
    padding-bottom: 0.5%;
    vertical-align: middle;
    text-align:center;
    font-family: sans-serif;
    font-size: 15px;
}
.Row:hover{
      background:#32E236 url(/Images/greenshade1.png) repeat-x;
      color:white;
      fill:#32E236;  
      -webkit-animation:glowingrow;
      -webkit-animation-duration:2s;
      -webkit-animation-iteration-count:infinite;
}
.AltRow:hover{
      background: #32E236 url(/Images/greenshade1.png) repeat-x; 
      background-color:#32E236;
      color:white;
      fill:#32E236;  
      -webkit-animation:glowingrow;
      -webkit-animation-duration:2s;
      -webkit-animation-iteration-count:infinite;     
}
@-webkit-keyframes glowingrow{
    from{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 12px #333;}
     50%{ background-color:#00ff00; border-radius:10px; -webkit-box-shadow: 0 0 24px #00ff00; }
      to{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 12px #333; }
}

h3{
    padding-bottom: 3%;
    font-family: sans-serif;
    font-weight: bold;
}*/
.container{
      position:relative;
      right:0%;
      animation: slideright 2s;
}
@keyframes slideright {
      from { right: -100%; }
      to { right: 0%;}
}
.logoslide{
      position:absolute;
      left: 85%;
      top:  -8%;
      animation: slideleft 2s ;
}
@keyframes slideleft {
      from { left: -100%; }
      to { left: 85%; }
}
.buttons0{
      float:left;
      margin-left: 11%;
      z-index:3;
      margin-top:0.5%;
}
.buttons1{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
}
.buttons2{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
}
.buttons4{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
}
.buttons5{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
}
@keyframes buttonsup {
      from { top: 300%; }
      to { top: 0%;}
}
.buttonscontainer {
        position: static;
        top: 10px;
        height: auto;
        width: auto;
        overflow:hidden;

}
.buttonslider{
    position:relative;
    animation:buttonsup;
}



</style>

</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">



    <div id ="outercontainer" class="outercontainer" >
    <div id="container" class="container" style="width:auto; margin-top:3.5%; " >

         <asp:ScriptManager
              ID="ScriptManager1"
              runat="server">
        </asp:ScriptManager> 

        <div id="logo" class="logoslide" style="z-index:5"><img src="Images/logo4.png" /></div>


            <asp:Panel
            ID="Panel2"
            runat="server" 
            ScrollBars="None"
            BackImageUrl="~/Images/headershade3.png"
            CssClass="Panel2">

       
             <asp:UpdatePanel 
                 ID="UpdatePanel2"  
                 runat="server" >
                 <ContentTemplate>

                     <asp:Label 
                         ID="lblMessage" 
                         runat="server" 
                         Text="HostPage">
                     </asp:Label>

                     <uc1:CourseGridViewHeader runat="server" id="CourseGridViewHeader" />

                 </ContentTemplate>
                 </asp:UpdatePanel>

                </asp:Panel> 


           <asp:Panel 
            ID="Panel1"
            runat="server" 
            CssClass="Panel1">


 
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


                    <uc1:CourseGridView runat="server" id="CourseGridView" />

                </ContentTemplate>
            </asp:UpdatePanel>

        </asp:Panel>



        <div id="buttonscontainer" style="margin:auto; width:auto;" class="buttonscontainer" >

        <div id="slidebuttons1" class="buttonslider">

        <div id="Div1" runat="server" style="z-index:5;" class="buttons0">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedButtons" 
            id="ViewAppointments" ImageUrl="~/Images/viewappointmentsbutton.png" 
            OnClick="ViewAppointments_Click"
            ToolTip="view all courses" />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>


        <div id="buttonsdiv0" runat="server" style="z-index:5;" class="buttons1">
        <asp:UpdatePanel ID="buttonspanel" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedButtons" 
            id="createcourse" ImageUrl="~/Images/createcoursebutton.png" 
            OnClick="createcourse_Click"
            ToolTip="create a new appointment" />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttons2" runat="server" style="z-index:5;" class="buttons2">
        <asp:UpdatePanel ID="buttonspanel2" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedButtons"
            id="managecourse"
             ImageUrl="~/Images/managecoursebutton.png" 
            OnClick="managecourse_Click"
            ToolTip="manage the selected course"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttonsdiv4" runat="server" style="z-index:5;" class="buttons4">
        <asp:UpdatePanel ID="buttonspanel4" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server"
             CssClass="roundedButtons"
            id="manageattendance" 
            ImageUrl="~/Images/manageattendancebutton1.png"
            OnClick="manageattendance_Click" 
            ToolTip="manage attendance"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttonsdiv5" runat="server" style="z-index:5;" class="buttons5">
        <asp:UpdatePanel ID="buttonspanel5" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedButtons" 
            id="createreport" 
            ImageUrl="~/Images/createreportbutton1.png" 
            OnClick="createreport_Click"  
            ToolTip="create a report" />
        </ContentTemplate>
        </asp:UpdatePanel>

        </div>
        </div>



       </div>
       </div>
       </div>

    </asp:Content>
