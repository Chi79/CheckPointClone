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
            Height="469px"
            Width="1010px" 
            ScrollBars="Vertical" 
            BorderWidth="1" 
            BorderColor="#336699" 
            style="margin-left: 203px">
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
                  OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged" 
                  OnSorting="gvHostTable_Sorting"
                  SelectionMode ="FullRowSelect" >
                <AlternatingRowStyle 
                    BackColor="#C6F5B8" 
                    VerticalAlign="Middle" 
                    Wrap="True" />
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/small_logo.png" ShowSelectButton="True" />
                    <asp:TemplateField HeaderText="AppointmentId" AccessibleHeaderText="AppointmentId">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText" runat="server" Text='<%# Bind("AppointmentId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentId</h3>
                            <asp:Button runat="server"  Text="ASC" OnClick="AppIdAsc_Click"/>
                            <asp:Button runat="server"  Text="DESC" OnClick="AppIdDesc_Click"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("AppointmentId") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#168927" />
                    </asp:TemplateField>
           
                    <asp:TemplateField HeaderText="CourseId" AccessibleHeaderText="CourseId" ItemStyle-Width="100px" ControlStyle-Width="120px">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText2" runat="server" Text='<%# Bind("CourseId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">CourseId</h3>
                            <asp:Button runat="server" Text="ASC" OnClick="CourseIdAsc_Click" />
                            <asp:Button runat="server" Text="DESC" OnClick="CourseIdDesc_Click" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor ="#168927" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderStyle-BackColor="#168927" HeaderText="AppointmentName">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText3" runat="server" Text='<%# Bind("AppointmentName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentName</h3>
                            <asp:Button runat="server" OnClick="AppNameAsc_Click" Text="ASC" />
                            <asp:Button runat="server" OnClick="AppNameDesc_Click" Text="DESC" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("AppointmentName") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <HeaderStyle BackColor="#168927" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description" ControlStyle-Width="120px">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText4" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">Description</h3>
                            <asp:Button runat="server" OnClick="DescriptionAsc_Click" Text="ASC"/>
                            <asp:Button runat="server" OnClick="DescriptionDesc_Click" Text="DESC" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#168927" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
              
                    <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText5" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">Date</h3>
                            <asp:Button runat="server" OnClick="DateAsc_Click" Text="ASC" />
                            <asp:Button runat="server" OnClick="DateDesc_Click" Text="DESC" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#168927" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText6" runat="server" Text='<%# Bind("StartTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">StartTime</h3>
                            <asp:Button runat="server" OnClick="StartTimeAsc_Click" Text="ASC" />
                            <asp:Button runat="server" OnClick="StartTimeDesc_Click" Text="DESC" />
                        </HeaderTemplate>
                        <ItemTemplate>
                           <asp:Label ID="Label6" runat="server" Text='<%# Bind("StartTime") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#168927" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText7" runat="server" Text='<%# Bind("EndTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">EndTime</h3>
                            <asp:Button runat="server" OnClick="EndTimeAsc_Click" Text="ASC" />
                            <asp:Button runat="server" OnClick="EndTimeDesc_Click" Text="DESC" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("EndTIme") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor ="#168927" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText8" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">Address</h3>
                            <asp:Button runat="server" OnClick="AddressAsc_Click" Text="ASC" />
                            <asp:Button runat="server" OnClick="AddressDesc_Click" Text="DESC" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#168927" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText9" runat="server" Text='<%# Bind("PostalCode") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">PostalCode</h3>
                            <asp:Button runat="server" OnClick="PostalCodeAsc_Click" Text="ASC" />
                            <asp:Button runat="server" OnClick="PostalCodeDesc_Click" Text="DESC" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#168927" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText10" runat="server" Text='<%# Bind("IsObligatory") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">IsObligatory</h3>
                            <asp:Button runat="server" OnClick="IsObligAsc_Click" Text="ASC" />
                            <asp:Button runat="server" OnClick="IsObligDesc_Click" Text="DESC" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("IsObligatory") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#168927" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled">
                        <EditItemTemplate>
                            <asp:TextBox ID="myText11" runat="server" Text='<%# Bind("IsCancelled") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <h3 style="color:white">IsCancelled</h3>
                            <asp:Button runat="server" OnClick="IsPrivateAsc_Click" Text="ASC" />
                            <asp:Button runat="server" OnClick="IsPrivateDesc_Click" Text="DESC" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("IsCancelled") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Width="120px" />
                        <HeaderStyle BackColor="#168927" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>


                    <asp:BoundField AccessibleHeaderText="AppointmentId" DataField="AppointmentId" HeaderText="AppointmentId" SortExpression="SortByAppointmentId">
                    <ControlStyle Font-Bold="True" />
                    <HeaderStyle BackColor="#168927" ForeColor="White" Height="70px" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="CourseId" DataField="CourseId" HeaderText="CourseId" SortExpression="SortByCourseId">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="AppointmentName" DataField="AppointmentName" HeaderText="AppointmentName" SortExpression="SortByAppointmentName">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="Description" DataField="Description" HeaderText="Description" SortExpression="SortByDescription">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="Date" DataField="Date" HeaderText="Date" SortExpression="SortByDate">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="StartTime" DataField="StartTime" HeaderText="StartTime" SortExpression="SortByStartTime">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="EndTime" DataField="EndTime" HeaderText="EndTime" SortExpression="SortByEndTime">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="Address" DataField="Address" HeaderText="Address" SortExpression="SortByAddress">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="PostalCode" DataField="PostalCode" HeaderText="PostalCode" SortExpression="SortByPostalCode">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="IsObligatory" DataField="IsObligatory" HeaderText="IsObligatory" SortExpression="SortByIsObligatory">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                    <asp:BoundField AccessibleHeaderText="IsCancelled" DataField="IsCancelled" HeaderText="IsCancelled" SortExpression="SortByIsCancelled">
                    <HeaderStyle BackColor="#168927" ForeColor="White" />
                    </asp:BoundField>
                </Columns>
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



