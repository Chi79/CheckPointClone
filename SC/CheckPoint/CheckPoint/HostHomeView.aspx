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
                        <HeaderStyle BackColor ="#168927" />
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
                    <asp:TemplateField HeaderStyle-BackColor="#168927"></asp:TemplateField>
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



