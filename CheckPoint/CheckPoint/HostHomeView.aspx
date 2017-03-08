<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="HostHomeView.aspx.cs"  Inherits="CheckPoint.Views.HostHomeView"  EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form 
        id="form1" 
        runat="server">
    <div>
         <asp:ScriptManager
              ID="ScriptManager1"
              runat="server">
        </asp:ScriptManager> 

        
             <asp:UpdatePanel 
                 ID="UpdatePanel2"  
                 runat="server" >
                 <ContentTemplate>
                     <asp:Label 
                         ID="lblMessage" 
                         runat="server" 
                         Text="HostHomePage">
                     </asp:Label>
                 </ContentTemplate>
                 </asp:UpdatePanel>


        <asp:Panel 
            ID="Panel1"
            runat="server" 
            Height="484px" 
            Width="87.3%" 
            ScrollBars="Vertical" 
            BorderWidth="1" 
            BorderColor="#336699" 
            style="margin-left: 127px; margin-right: 0px;">
 
 
            <asp:UpdatePanel 
                ID="UpdatePanel1"  
                runat="server">
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

                      <script>
                       

                      $(function() {
                      $( "[id$=datepicker]" ).datepicker({
                                  showOn: "button",
                      buttonImage: "/images/calendar2.png",
                      buttonImageOnly: true,
                      buttonText: "calender"
                      });
                      $("[id$=datepicker]").datepicker("setDate", Date.now())
                      });

                      var prm = Sys.WebForms.PageRequestManager.getInstance();
                      if (prm != null) {
                          prm.add_endRequest(function (sender, e) {
                              if (sender._postBackSettings.panelsToUpdate != null) {
                                  $("[id$=datepicker]").datepicker({
                                      showOn: "button",
                                      buttonImage: "/images/calendar2.png",
                                      buttonImageOnly: true,
                                      buttonText: "calender"
                                  })
                              }
                          });
                      };
                      </script>


              <asp:GridView 
                  ID="gvHostTable" 
                  runat="server"
                  AutoGenerateColumns="False" 
                  Height="395px" 
                  Width="662px"  
                  style="margin-left: 0px; margin-top: 0px" 
                  AllowSorting="True" 
                  OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged"
                  ShowHeaderWhenEmpty="True" 
                  CssClass="grhosttable">
                  <HeaderStyle CssClass="header" />
                <AlternatingRowStyle 
                    BackColor="#C6F5B8" 
                    VerticalAlign="Middle" 
                    Wrap="True" />
                <Columns>
                    <asp:TemplateField ShowHeader="true">
                        <ItemTemplate>
                            <asp:ImageButton ID="SelectButton" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="~/Images/small_logo.png" Text="Select" />
                        </ItemTemplate>
                       <ControlStyle Width="25px" />
                        <HeaderStyle BackColor ="#10591B"  Width="25px" Height="80px"/>
                        <ItemStyle Width="2.3%" />
                    </asp:TemplateField>  
                   
                    <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText" runat="server" Text='<%# Bind("AppointmentId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentId</h3>
                            <asp:ImageButton runat="server" CommandName="AppointmentId" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="AppointmentId" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppId" runat="server" Text='<%# Bind("AppointmentId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"  Width="11%"/>
                        <HeaderStyle BackColor="#10591B" />


                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText2" runat="server" Text='<%# Bind("CourseId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">CourseId</h3>
                            <asp:ImageButton runat="server" CommandName="CourseId" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="CourseId" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCourseId" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7.4%" />
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderStyle-BackColor="#168927" HeaderText="AppointmentName">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText3" runat="server" Text='<%# Bind("AppointmentName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentName</h3>
                            <asp:ImageButton runat="server" CommandName="AppointmentName" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="AppointmentName" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppName" runat="server" Text='<%# Bind("AppointmentName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="13.5%" />
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText4" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">Description</h3>
                            <asp:ImageButton runat="server" CommandName="Description" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="Description" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8.3%" />
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText5" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">Date</h3>
                            <asp:ImageButton runat="server" CommandName="Date" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="Date" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>

                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>' Height="15%"></asp:Label>
                            <input type="hidden" id="datepicker"/> 
    
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7.4%" />
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText6" runat="server" Text='<%# Bind("StartTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">StartTime</h3>
                            <asp:ImageButton runat="server" CommandName="StartTime" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="StartTime" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("StartTime") %>' ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7.4%" />
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText7" runat="server" Text='<%# Bind("EndTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">EndTime</h3>
                            <asp:ImageButton runat="server" CommandName="EndTime" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="EndTime" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEndTime" runat="server" Text='<%# Bind("EndTIme") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7.4%" />
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText8" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">Address</h3>
                            <asp:ImageButton runat="server" CommandName="Address" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="Address" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8.9%" />
                        <HeaderStyle BackColor="#10591B" Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText9" runat="server" Text='<%# Bind("PostalCode") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">PostalCode</h3>
                            <asp:ImageButton runat="server" CommandName="PostalCode" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="PostalCode" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPostalCode" runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8.9%"/>
                        <HeaderStyle BackColor="#10591B" Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText10" runat="server" Text='<%# Bind("IsObligatory") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">IsObligatory</h3>
                            <asp:ImageButton runat="server" CommandName="IsObligatory" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="IsObligatory" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
<%--                            <asp:Label ID="lblIsObligatory" runat="server"  Text='<%# Bind("IsObligatory") %>' Width="102px"></asp:Label>--%>
                            <asp:Image ID="IsObligTrue" runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsObligatory").Equals(true) %>'/>
                            <asp:Image ID="IsObligFalse" runat="server"  ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsObligatory").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="9.1%" />
                        <HeaderStyle BackColor="#10591B" Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled">
                        <HeaderStyle Width="100px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="myText11" runat="server" Text='<%# Bind("IsCancelled") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">IsCancelled</h3>
                            <asp:ImageButton runat="server" CommandName="IsCancelled" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="IsCancelled" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
<%--                            <asp:Label ID="lblIsCancelled" runat="server" Text='<%# Bind("IsCancelled") %>'  Width="100px"></asp:Label>--%>
                              <asp:Image ID="IsCancelledTrue" runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsCancelled").Equals(true) %>' />
                            <asp:Image ID="IsCancelledFalse" runat="server"  ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsCancelled").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#10591B"/>
                    </asp:TemplateField>

                </Columns>
                  <HeaderStyle BackColor="#10591B" />
                <SelectedRowStyle 
                    BackColor="#32E236" />
            </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </asp:Panel>
     </div>
       
    </form>
</body>
</html>



