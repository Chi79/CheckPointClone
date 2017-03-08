<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="HostHomeView.aspx.cs"  Inherits="CheckPoint.Views.HostHomeView" EnableEventValidation="false" %>

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
                        <ItemStyle Width="25px" />
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
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("AppointmentId") %>' Width="125px"></asp:Label>
                        </ItemTemplate>
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
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("CourseId") %>' Width="82px"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderStyle-BackColor="#168927" HeaderText="AppointmentName"><%-- <ControlStyle Width="100px" />--%><%--   <ItemStyle Width="100px" />--%>
                        <EditItemTemplate>
                            <asp:TextBox ID="myText3" runat="server" Text='<%# Bind("AppointmentName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentName</h3>
                            <asp:ImageButton runat="server" CommandName="AppointmentName" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" />
                            <asp:ImageButton runat="server" CommandName="AppointmentName" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("AppointmentName") %>' Width="152px"></asp:Label>
                        </ItemTemplate>
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
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>' Width="93px"></asp:Label>
                        </ItemTemplate>
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
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Date") %>' Width="83px"></asp:Label>
                        </ItemTemplate>
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
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("StartTime") %>' Width="81px"></asp:Label>
                        </ItemTemplate>
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
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("EndTIme") %>' Width="82px"></asp:Label>
                        </ItemTemplate>
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
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Address") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
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
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("PostalCode") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
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
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("IsObligatory") %>' Width="102px"></asp:Label>
                        </ItemTemplate>
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
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("IsCancelled") %>' Width="100px"></asp:Label>
                        </ItemTemplate>
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



