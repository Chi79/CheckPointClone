<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="HostHomeView.aspx.cs"  Inherits="CheckPoint.Views.HostHomeView"  EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"> 

    <title></title>

   <style type="text/css">
        /*.auto-style1 {
            z-index: 50;
        }*/
        .gvRow:hover{
            background:#32E236 url(/Images/greenshade2.png) repeat-x;
            color:white;
            fill:#32E236;  
        }
        .gvRowAlt:hover{
            background: #32E236 url(/Images/greenshade2.png) repeat-x; 
            background-color:#32E236;
            color:white;
            fill:#32E236;       
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
           z-index:5;
           position: absolute;
           left: 40%;
           top: 81%;
           margin: 7em -244px;
           animation: buttonsup 2s ;
        }
        .buttons2{
           z-index:5;
           position: absolute;
           left: 53%;
           top: 81%;
           margin: 7em -244px;
           animation: buttonsup 3s ;
        }
       .buttons3{
           z-index:5;
           position: absolute;
           left: 66%;
           top: 81%;
           margin: 7em -244px;
           animation: buttonsup 4s ;
        }
       .buttons4{
           z-index:5;
           position: absolute;
           left: 79%;
           top: 81%;
           margin: 7em -244px;
           animation: buttonsup 5s ;
        }
       @keyframes buttonsup {
           from { top: 150%; }
             to { top: 81%;}
       }
       .buttons5{
           z-index:5;
           position: absolute;
           left: 92%;
           top: 81%;
           margin: 7em -244px;
           animation: buttonsup5 6s ;
        }
       @keyframes buttonsup5 {
           from { top: 150%; }
             to { top: 81%;}
       }
         .fabiotop {
           position: absolute;
           left: 25%;
           top: 70%;
           margin: 7em -244px;
           animation: fabiotop 7s ;
        }
          @keyframes fabiotop {
          from { top: 150%; }
            to { top: 70%; }
        }
         .goosebottom {
           position: absolute;
           left: 110%;
           top: 70%;
           margin: 7em -244px;
           animation: goosebottom 9s;
        }   
          @keyframes goosebottom {  
           from {top:150%;}
             to {top:70%;}   
        }

        .slideleft {
           position: absolute;
           left: 100%;
           top: -27%;
           margin: 7em -244px;
           animation: slideleft 2s ;
        }
          @keyframes slideleft {
          from { left: -150%; }
            to { left: 100%; }
        }
        .slideright {
           position: absolute;
           right: 18%;
           top: -10%;
           margin: 7em -244px;
           animation: slideright 2s;
        }
          @keyframes slideright {
          from { right: -150%; }
            to { right: 18%; }
        }



       .auto-style1 {
           height: 248px;
       }



    </style>

    </head>
<body>

    <form 
        id="form1" 
        runat="server">

    <div id ="outercontainer" style="z-index:0; width:4000px; height:1500px; background-color:#333333">
    <div id="container" style="width:1335px;" class="slideright" >

         <asp:ScriptManager
              ID="ScriptManager1"
              runat="server">
        </asp:ScriptManager> 

        <div id="fabio" class="fabiotop" style="z-index:4"><img src="Images/fabio.png"/></div>
        <div id="goose" class="goosebottom" style="z-index:3"><img src="Images/goose.png"/></div>
        <div id="logo" class="slideleft" style="z-index:5"><img src="Images/logo4.png" /></div>

        <div id="buttons" runat="server" style="z-index:5;" class="buttons1">
        <asp:UpdatePanel ID="buttonspanel" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  runat="server" CssClass="roundedbutton" id="update" ImageUrl="~/Images/updatebutton.png" OnClick="update_Click" />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttons2" runat="server" style="z-index:5;" class="buttons2">
        <asp:UpdatePanel ID="buttonspanel2" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  runat="server" CssClass="roundedbutton" id="managecourses" ImageUrl="~/Images/managecoursesbutton.png" OnClick="managecourses_Click"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttons3" runat="server" style="z-index:5;" class="buttons3">
        <asp:UpdatePanel ID="buttonspanel3" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  runat="server" CssClass="roundedbutton" id="manageappointments" ImageUrl="~/Images/manageappointmentsbutton.png" OnClick="manageappointments_Click"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttons4" runat="server" style="z-index:5;" class="buttons4">
        <asp:UpdatePanel ID="buttonspanel4" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  runat="server" CssClass="roundedbutton" id="manageattendance" ImageUrl="~/Images/manageattendancebutton.png" OnClick="manageattendance_Click"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>

        <div id="buttons5" runat="server" style="z-index:5;" class="buttons5">
        <asp:UpdatePanel ID="buttonspanel5" runat="server" > 
        <ContentTemplate>
        <asp:ImageButton  runat="server" CssClass="roundedbutton" id="createreport" ImageUrl="~/Images/createreportbutton.png" OnClick="createreport_Click"  />
        </ContentTemplate>
        </asp:UpdatePanel>
        </div>



            <asp:Panel
            ID="Panel2"
            runat="server" 
            Height="15%"           
            Width="92%" 
            ScrollBars="None"
            BorderWidth="1" 
            BorderColor="#333333" 
            style="margin-left: 6.6%; margin-right: 0px;" BackColor="#333333" BorderStyle="None">

       
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
                          style="margin-left: 0px; margin-top: 0px; margin-right:10%;
                          z-index:2;"
                          Width="98.7%"
                          ShowFooter="false">
                          
                         <Columns>
                             <asp:TemplateField ShowHeader="true">
                                 <HeaderStyle BackColor="#10591B"  CssClass="gvHeadleft" />
                                       <ItemTemplate>
                                       <asp:ImageButton ID="SelectButton" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="~/Images/small_logo.png" CssClass="roundedbutton" />
                                     </ItemTemplate>
                                 <ItemStyle Width="1%" />
                                 <HeaderStyle Width="2.5%" />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">AppointmentId</h3>
                                     <asp:ImageButton runat="server" CommandName="AppointmentId" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command" CssClass="roundedbutton" ToolTip="sort by ascending" />
                                     <asp:ImageButton runat="server" CommandName="AppointmentId" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command"  CssClass="roundedbutton" ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="2.3%" />
                                 <HeaderStyle BackColor="#10591B" Width="2.3%" CssClass="gvHeadcenter" />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">CourseId</h3>
                                     <asp:ImageButton runat="server" CommandName="CourseId" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command" CssClass="roundedbutton" ToolTip="sort by ascending" />
                                     <asp:ImageButton runat="server" CommandName="CourseId" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command" CssClass="roundedbutton" ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="8%" />
                                 <HeaderStyle BackColor="#10591B" Width="7.1%" CssClass="gvHeadcenter"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderStyle-BackColor="#168927" HeaderText="AppointmentName">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">AppointmentName</h3>
                                     <asp:ImageButton runat="server" CommandName="AppointmentName" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command" CssClass="roundedbutton" ToolTip="sort by ascending" />
                                     <asp:ImageButton runat="server" CommandName="AppointmentName" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command" CssClass="roundedbutton" ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                                 <HeaderStyle BackColor="#10591B" Width="8%"  CssClass="gvHeadcenter"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">Description</h3>
                                     <asp:ImageButton runat="server" CommandName="Description" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command" CssClass="roundedbutton" ToolTip="sort by ascending" />
                                     <asp:ImageButton runat="server" CommandName="Description" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command" CssClass="roundedbutton" ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                                 <HeaderStyle BackColor="#10591B" Width="9%"  CssClass="gvHeadcenter"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">Date</h3>
                                     <asp:ImageButton runat="server" CommandName="Date" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command" CssClass="roundedbutton" ToolTip="sort by ascending" />
                                     <asp:ImageButton runat="server" CommandName="Date" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command" CssClass="roundedbutton" ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="8%" />
                                 <HeaderStyle BackColor="#10591B" Width="7.192%"  CssClass="gvHeadcenter"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime">
                                 <HeaderTemplate>
                                     <h3 style="color:white;" >StartTime</h3>
                                     <asp:ImageButton runat="server" CommandName="StartTime" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command"  CssClass="roundedbutton" ToolTip="sort by ascending"/>
                                     <asp:ImageButton runat="server" CommandName="StartTime" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command" CssClass="roundedbutton" ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="8%" />
                                 <HeaderStyle BackColor="#10591B" Width="7.4%" CssClass="gvHeadcenter" />
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">EndTime</h3>
                                     <asp:ImageButton runat="server" CommandName="EndTime" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command" CssClass="roundedbutton" ToolTip="sort by ascending" />
                                     <asp:ImageButton runat="server" CommandName="EndTime" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command" CssClass="roundedbutton" ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="8%" />
                                 <HeaderStyle BackColor="#10591B" Width="7.25%" CssClass="gvHeadcenter"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">Address</h3>
                                     <asp:ImageButton runat="server" CommandName="Address" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command" CssClass="roundedbutton" ToolTip="sort by ascending" />
                                     <asp:ImageButton runat="server" CommandName="Address" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command" CssClass="roundedbutton" ToolTip="sort by descending"/>
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                                 <ItemStyle Width="2%" />
                                 <HeaderStyle BackColor="#10591B" Width="9.4%" CssClass="gvHeadcenter"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">PostalCode</h3>
                                     <asp:ImageButton runat="server" CommandName="PostalCode" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command" CssClass="roundedbutton" ToolTip="sort by ascending"/>
                                     <asp:ImageButton runat="server" CommandName="PostalCode" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command" CssClass="roundedbutton" ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                                 <HeaderStyle BackColor="#10591B" Width="8.8%" CssClass="gvHeadcenter"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">IsObligatory</h3>
                                     <asp:ImageButton runat="server" CommandName="IsObligatory" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command"  CssClass="roundedbutton" ToolTip="sort by ascending"/>
                                     <asp:ImageButton runat="server" CommandName="IsObligatory" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command" CssClass="roundedbutton" ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                                 <HeaderStyle BackColor="#10591B" Width="9.4%" CssClass="gvHeadcenter"/>
                             </asp:TemplateField>
                             <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">IsCancelled</h3>
                                     <asp:ImageButton runat="server" CommandName="IsCancelled" ImageUrl="~/Images/uparrow3.png" OnCommand="Asc_Command" CssClass="roundedbutton" ToolTip="sort by ascending" />
                                     <asp:ImageButton runat="server" CommandName="IsCancelled" ImageUrl="~/Images/downarrow3.png" OnCommand="Desc_Command"  CssClass="roundedbutton" ToolTip="sort by descending" />
                                 </HeaderTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                                 <HeaderStyle BackColor="#10591B" Width="9%" CssClass="gvHeadright"/>
                             </asp:TemplateField>
                         </Columns>
                         <HeaderStyle BackColor="#10591B" />
                         <SelectedRowStyle BackColor="#32E236" />
                     </asp:GridView>
                 </ContentTemplate>
                 </asp:UpdatePanel>

                </asp:Panel> 

           <asp:Panel 
            ID="Panel1"
            runat="server" 
            Height="430px"           
            Width="92%" 
            ScrollBars="Vertical" 
            BorderStyle="None"
            style="margin-left:6.59%;
            margin-right: 0px;
            overflow-y:scroll;
            z-index:1;
            position:relative;">


 
            <asp:UpdatePanel 
                ID="UpdatePanel1"  
                runat="server" >
                <ContentTemplate>
                  <asp:Label 
                      ID="lblIndex" 
                      runat="server">
                  </asp:Label>
                        

                      <link rel="stylesheet" href="CSS/hosthome.css" />
                
                      <link rel="stylesheet" href="CSS/jquery-ui.css" /> 
                      <link rel="stylesheet" href="/resources/demos/style.css">
                      <link rel="stylesheet" href="CSS/jquery-ui.min.css" />
                      <link rel="stylesheet" href="CSS/jquery-ui.structure.css" />
                      <link rel="stylesheet" href="CSS/jquery-ui.theme.css" />
               

                      <script src="Scripts/jquery-ui.min.js"></script>
                      <script src="Scripts/jquery.js"></script>
                      <script src="Scripts/jquery-ui.js"></script>
                      
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
                  margin-top:-5.2%; 
                  margin-right:10%;
                  z-index:1" 
                  AllowSorting="True" 
                  OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged"
                  OnRowDataBound="gvHostTable_RowDataBound"
                  ShowHeaderWhenEmpty="True" 
                  ShowHeader="true" >
                  
                <RowStyle CssClass="gvRow" BackColor="White" />
                <AlternatingRowStyle
                    VerticalAlign="Middle" 
                    Wrap="True"
                    CssClass="gvRowAlt" BackColor="#99FF99" />
                <Columns>
                    <asp:TemplateField ShowHeader="true"> 
                        <ItemTemplate>
                            <asp:ImageButton ID="SelectButton" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="~/Images/small_logo.png" />
                        </ItemTemplate>
                        <HeaderStyle BackColor ="#10591B" />
                        <ItemStyle Width="1%" CssClass="roundedleft"/>
                        <HeaderStyle  />
                    </asp:TemplateField>  
                   
                    <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId">
                        <HeaderTemplate>
                            <h3 style="color:white" >AppointmentId</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppId" runat="server" Text='<%# Bind("AppointmentId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"  CssClass="centerborders" />
                        <HeaderStyle BackColor="#10591B"/>
                    


                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId">
                        <HeaderTemplate>
                            <h3 style="color:white">CourseId</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCourseId" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="centerborders" />
                        <HeaderStyle BackColor="#10591B"/>
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderStyle-BackColor="#168927" HeaderText="AppointmentName">
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentName</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppName" runat="server" Text='<%# Bind("AppointmentName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="centerborders" />
                        <HeaderStyle BackColor="#10591B"/>
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description">
                        <HeaderTemplate>
                            <h3 style="color:white">Description</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10.2%"  CssClass="centerborders"/>
                        <HeaderStyle BackColor="#10591B"/>
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date">
                        <HeaderTemplate>
                            <h3 style="color:white">Date</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Convert.ToDateTime(Eval("Date")).ToString("MM/dd/yyyy") %>' Height="15%"></asp:Label>
                            <input type="hidden" class="picker" id="datepicker" value='<%# Convert.ToDateTime(Eval("Date")).ToString("MM/dd/yyyy") %>'/>   
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8.4%"  CssClass="centerborders" />
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime">
                        <HeaderTemplate>
                            <h3 style="color:white">StartTime</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("StartTime") %>' ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8%"  CssClass="centerborders" />
                        <HeaderStyle BackColor="#10591B"/>
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime" >
                        <HeaderTemplate>
                            <h3 style="color:white">EndTime</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEndTime" runat="server" Text='<%# Bind("EndTIme") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="centerborders" />
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address">
                        <HeaderTemplate>
                            <h3 style="color:white">Address</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="centerborders" />
                        <ItemStyle Width="2%" />
                        <HeaderStyle BackColor="#10591B"/>
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode">
                        <HeaderTemplate>
                            <h3 style="color:white">PostalCode</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPostalCode" runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%"  CssClass="centerborders"/>
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory">
                        <HeaderTemplate>
                            <h3 style="color:white">IsObligatory</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image ID="IsObligTrue" runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsObligatory").Equals(true) %>'/>
                            <asp:Image ID="IsObligFalse" runat="server"  ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsObligatory").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="centerborders" />
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled">
                        <HeaderTemplate>
                            <h3 style="color:white">IsCancelled</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                              <asp:Image ID="IsCancelledTrue" runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsCancelled").Equals(true) %>' />
                            <asp:Image ID="IsCancelledFalse" runat="server"  ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsCancelled").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="roundedright"/>
                        <HeaderStyle BackColor="#10591B"/>
                    </asp:TemplateField>

                </Columns>
                  <HeaderStyle BackColor="#10591B" />
                <SelectedRowStyle 
                    BackColor="#32E236" ForeColor="White" />
            </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </asp:Panel>
       </div>
       </div>
    </form>
</body>
</html>



