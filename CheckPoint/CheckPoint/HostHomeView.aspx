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
            Height="501px"
            Width="1162px" 
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
                  Height="398px" 
                  Width="662px"  
                  style="margin-left: 0px; margin-top: 0px" 
                  AllowSorting="True" 
                  OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged" >
                <AlternatingRowStyle 
                    BackColor="#C6F5B8" 
                    VerticalAlign="Middle" 
                    Wrap="True" />
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/small_logo.png" ShowSelectButton="True"/>


                    <asp:TemplateField HeaderText="AppointmentId" AccessibleHeaderText="AppointmentId">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText" runat="server" Text='<%# Bind("AppointmentId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentId</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png"   OnCommand="Asc_Command" CommandName="AppointmentId"/>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png"  OnCommand="Desc_Command" CommandName="AppointmentId"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("AppointmentId") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#10591B" />
                    </asp:TemplateField>
           

                    <asp:TemplateField HeaderText="CourseId" AccessibleHeaderText="CourseId" ItemStyle-Width="100px" ControlStyle-Width="120px">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText2" runat="server" Text='<%# Bind("CourseId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">CourseId</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="CourseId" />
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="CourseId" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor ="#10591B" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderStyle-BackColor="#168927" HeaderText="AppointmentName">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText3" runat="server" Text='<%# Bind("AppointmentName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentName</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="AppointmentName" />
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="AppointmentName" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("AppointmentName") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <HeaderStyle BackColor="#10591B" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description" ControlStyle-Width="120px">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText4" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">Description</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="Description" />
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="Description" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#10591B" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

              
                    <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText5" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">Date</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="Date"  />
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="Date"  />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#10591B" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText6" runat="server" Text='<%# Bind("StartTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">StartTime</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="StartTime" />
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="StartTime" />
                        </HeaderTemplate>
                        <ItemTemplate>
                           <asp:Label ID="Label6" runat="server" Text='<%# Bind("StartTime") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#10591B" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText7" runat="server" Text='<%# Bind("EndTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">EndTime</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="EndTime" />
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="EndTime" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("EndTIme") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor ="#10591B" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText8" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">Address</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="Address" />
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="Address" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#10591B" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText9" runat="server" Text='<%# Bind("PostalCode") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">PostalCode</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="PostalCode" />
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="PostalCode" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#10591B" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText10" runat="server" Text='<%# Bind("IsObligatory") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">IsObligatory</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="IsObligatory" />
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="IsObligatory" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("IsObligatory") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#10591B" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText11" runat="server" Text='<%# Bind("IsCancelled") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">IsCancelled</h3>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/uparrow.png" OnCommand="Asc_Command" CommandName="IsCancelled"/>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/downarrow.png" OnCommand="Desc_Command" CommandName="IsCancelled" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("IsCancelled") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#10591B" />
                        <HeaderStyle Width="100px" />
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



