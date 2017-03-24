<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="HostHomeView.aspx.cs"  Inherits="CheckPoint.Views.HostHomeView"  EnableEventValidation="false"  MasterPageFile="~/HostMaster.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">


<title></title>

<style type="text/css">
  


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

.roundedButtons {
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
}


.selectColumnItem{
    width: 9.09%;
}
.appointmentIdColumnItem{
    width: 9.09%;
    padding-left: 3%;
    margin: auto;
}
.courseIdColumnItem{
    width: 9.09%;
    padding-left: 4.5%;
    margin: auto;
}
.appointmentNameColumnItem{
    width: 9.09%;
    padding-left: 4%;
    margin: auto;
}
.descriptionColumnItem{
    width: 9.09%;
    padding-left: 4%;
    margin: auto;
}
.dateColumnItem{
    width: 11.09%;
    padding-left: 6%;
    margin: auto;
}
.startTimeColumnItem{
    width: 9.09%;
    padding-left: 5%;
    margin: auto;
}
.endTimeColumnItem{
    width: 9.09%;
    padding-left: 5%;
    margin: auto;
}
.addressColumnItem{
    width: 9.09%;
    margin: auto;
    padding-left:4%;
}
.postalCodeColumnItem{
    width: 9.09%;
    margin: auto;
    padding-left:3%;
}
.isObligatoryColumnItem{
    width: 9.09%;
    padding-left: 4%;
    margin: auto;
}
.isCancelledColumnItem{
    width: 9.09%;
    padding-left: 3%;
    margin: auto;
}


.selectHeader{

}
.appointmentIdHeader{
    width: 12%;
    margin: auto;
}
.courseIdHeader{
    width: 7.5%;
    margin: auto;
}
.appointmentNameHeader{
    width: 11%;
    margin: auto;
    padding-right:1%;
}
.descriptionHeader{
    width: 9%;
    margin: auto;
    padding-right: 3%;
}
.dateHeader{
    width: 9.5%;
    margin: auto;
    padding-right: 2%;
}
.startTimeHeader{
    width: 9%;
    margin: auto;
    padding-right: 1%;
}
.endTimeHeader{
    width: 8.1%;
    margin: auto;
    padding-right: 1%;
}
.addressHeader{
    width: 8.1%;
    margin: auto;
}
.postalCodeHeader{
    width: 9%;
    margin: auto;
}
.isObligatoryHeader{
    width: 9%;
    margin: auto;
}
.isCancelledHeader{
    width: 9%;
    margin: auto;
}

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
    padding-bottom: 12px;
    position:relative;
    right:1%;
}

.Row td{
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
    padding-bottom: 9%;
    font-family: sans-serif;
    font-weight: bold;
}
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
.buttons1{
      float:left;
      margin-left: 15%;
      z-index:3;
      margin-top:0.5%;
      animation: buttonsup 2s ;
}
.buttons2{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
      animation: buttonsup 3s ;
}
.buttons3{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
      animation: buttonsup 4s ;
}
.buttons4{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
      animation: buttonsup 5s;
}
.buttons5{
      float:left;
      margin-left: 1%;
      z-index:3;
      margin-top:0.5%;
      animation: buttonsup 6s ;
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

                     <asp:GridView 
                          ID="gvHostTable1" 
                          runat="server" 
                          AllowSorting="True"
                          AutoGenerateColumns="False"
                          Height="100%" 
                          OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged" 
                          ShowHeader="true"
                          ShowHeaderWhenEmpty="True"
                          style="
                          width:100%;
                          z-index:2;"
                          ShowFooter="false">
                          
                         <Columns>
                             <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId" HeaderStyle-CssClass="appointmentIdHeader" >
                                 <HeaderTemplate>
                                     <h3 style="color:white;">AppointmentId</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="AppointmentId" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="AppointmentId" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command"  
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center"/>
                                 <HeaderStyle />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId" HeaderStyle-CssClass="courseIdHeader" >
                                 <HeaderTemplate>
                                     <h3 style="color:white;">CourseId</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="CourseId" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="CourseId" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                                 <HeaderStyle />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderText="AppointmentName" HeaderStyle-CssClass="appointmentNameHeader">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">Name</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="AppointmentName" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="AppointmentName" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center"/>
                                 <HeaderStyle/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description" HeaderStyle-CssClass="descriptionHeader">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">Description</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Description" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command"  
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Description" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                                 <HeaderStyle />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date" HeaderStyle-CssClass="dateHeader">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">Date</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Date" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Date" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command"  
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                                 <HeaderStyle />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime" HeaderStyle-CssClass="startTimeHeader">
                                 <HeaderTemplate>
                                     <h3 style="color:white;" >StartTime</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="StartTime" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command"   
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons"/>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="StartTime" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command"  
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center"/>
                                 <HeaderStyle />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime" HeaderStyle-CssClass="endTimeHeader">
                                 <HeaderTemplate>
                                     <h3  style="color:white;">EndTime</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="EndTime" 
                                         ImageUrl="~/Images/uparrow3.png"
                                         OnCommand="Asc_Command"  
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="EndTime" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command" 
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center"/>
                                 <HeaderStyle/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address" HeaderStyle-CssClass="addressHeader">
                                 <HeaderTemplate>
                                     <h3  style="color:white;">Address</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Address" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="Address" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command"  
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                                 <ItemStyle />
                                 <HeaderStyle />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode" HeaderStyle-CssClass="postalCodeHeader">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">PostalCode</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="PostalCode" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command"  
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons"/>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="PostalCode" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command"  
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                                 <HeaderStyle />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory" HeaderStyle-CssClass="isObligatoryHeader">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">Obligatory</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="IsObligatory" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command"  
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons"/>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="IsObligatory" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command"  
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                                 <HeaderStyle />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled" HeaderStyle-CssClass="isCancelledHeader">
                                 <HeaderTemplate>
                                     <h3  style="color:white;">Cancelled</h3>
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="IsCancelled" 
                                         ImageUrl="~/Images/uparrow3.png" 
                                         OnCommand="Asc_Command" 
                                         ToolTip="sort by ascending"
                                         CssClass="roundedButtons" />
                                     <asp:ImageButton 
                                         runat="server" 
                                         CommandName="IsCancelled" 
                                         ImageUrl="~/Images/downarrow3.png" 
                                         OnCommand="Desc_Command"  
                                         ToolTip="sort by descending"
                                         CssClass="roundedButtons" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" />
                                 <HeaderStyle/>
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


              <asp:GridView
                  ID="gvHostTable"
                  runat="server"
                  AutoGenerateColumns="False" 
                  Height="100%" 
                  Width="100%"  
                  style=" table-layout:fixed;
                  z-index:1" 
                  AllowSorting="True" 
                  OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged"
                  OnRowDataBound="gvHostTable_RowDataBound"
                  ShowHeaderWhenEmpty="True" 
                  ShowHeader="false" 
                  DataKeyNames="AppointmentId"
                  >
                  
                <RowStyle BackColor="White" CssClass="Row"/>
                <AlternatingRowStyle
                    CssClass="AltRow"
                    VerticalAlign="Middle" 
                    Wrap="True"
                    BackColor="#99FF99" />
                <Columns>

                   
                    <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId"  ItemStyle-CssClass="appointmentIdColumnItem" >
                        <HeaderTemplate>
                            <h3 style="color:white" >AppointmentId</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppId" runat="server" Text='<%# Bind("AppointmentId") %>' ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
 

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId" ItemStyle-CssClass="courseIdColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">CourseId</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCourseId" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle  />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="AppointmentName"  HeaderText="AppointmentName" ItemStyle-CssClass="appointmentNameColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentName</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppName"  runat="server" Text='<%# Bind("AppointmentName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description" ItemStyle-CssClass="descriptionColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">Description</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDescription"  runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date" ItemStyle-CssClass="dateColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">Date</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Convert.ToDateTime(Eval("Date")).ToString("MM/dd/yyyy") %>' Height="15%"></asp:Label>
                            <input type="hidden" class="picker" id="datepicker" value='<%# Convert.ToDateTime(Eval("Date")).ToString("MM/dd/yyyy") %>'/>  
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime" ItemStyle-CssClass="startTimeColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">StartTime</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("StartTime") %>' ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle  />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime" ItemStyle-CssClass="endTimeColumnItem" >
                        <HeaderTemplate>
                            <h3 style="color:white">EndTime</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEndTime"  runat="server" Text='<%# Bind("EndTIme") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle  />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address" ItemStyle-CssClass="addressColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">Address</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAddress"  runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle  />
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode" ItemStyle-CssClass="postalCodeColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">PostalCode</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPostalCode"  runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory" ItemStyle-CssClass="isObligatoryColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">IsObligatory</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image ID="IsObligTrue"   runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsObligatory").Equals(true) %>'/>
                            <asp:Image ID="IsObligFalse"  runat="server"  ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsObligatory").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled" ItemStyle-CssClass="isCancelledColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">IsCancelled</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                              <asp:Image ID="IsCancelledTrue"  runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsCancelled").Equals(true) %>' />
                            <asp:Image ID="IsCancelledFalse"   runat="server"  ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsCancelled").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>

                </Columns>
                <SelectedRowStyle 
                    BackColor="#32E236" ForeColor="White" />
            </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </asp:Panel>



        <div id="buttonscontainer" style="margin:auto; width:auto;" class="buttonscontainer" >

        <div id="slidebuttons" class="buttonslider">
        <div id="buttonsdiv0" runat="server" style="z-index:5;" class="buttons1">
        <asp:UpdatePanel ID="buttonspanel" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedButtons" 
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
            CssClass="roundedButtons"
            id="managecourses"
             ImageUrl="~/Images/manageappointmentbutton.png" 
            OnClick="manageAppointment_Click"
            ToolTip="manage the selected appointment"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttonsdiv2" runat="server" style="z-index:5;" class="buttons3">
        <asp:UpdatePanel ID="buttonspanel3" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  
            runat="server" 
            CssClass="roundedButtons" 
            id="manageappointments" 
            ImageUrl="~/Images/managecoursesbutton1.png" 
            OnClick="managecourses_Click" 
            ToolTip="manage your courses" />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttonsdiv3" runat="server" style="z-index:5;" class="buttons4">
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

        <div id="buttonsdiv4" runat="server" style="z-index:5;" class="buttons5">
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


