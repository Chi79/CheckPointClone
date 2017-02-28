<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HostHomeView.aspx.cs" Inherits="CheckPoint.Views.HostHomeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" ScrollBars="vertical" Height="575px">
            <asp:GridView ID="gvAppointments" runat="server" BackColor="White" BorderColor="#006600" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="351px"  Width="1000px" Font-Bold="False" Font-Names="Century" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" PageSize="3" AllowSorting="True" OnSelectedIndexChanged="gvAppointments_SelectedIndexChanged" OnSorting="gvAppointments_Sorting" >
                <AlternatingRowStyle BackColor="#C6F5B8" VerticalAlign="Middle" Wrap="True" />
                <Columns>
                    <asp:CommandField ButtonType="Image" ShowSelectButton="True"  SelectImageUrl="~/Images/small_logo.png" runat="server"/>
                </Columns>
                <EditRowStyle BorderStyle="Groove" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#12A73F" Font-Bold="True" ForeColor="White" BorderColor="#006600" BorderStyle="None" Height="70px" Wrap="True" />
                <PagerSettings Position="TopAndBottom" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#20E643" Font-Bold="True" ForeColor="#214323" BorderColor="#CCFFCC" Wrap="True" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#00CC00" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </asp:Panel>
        <p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <asp:GridView ID="gv2" runat="server" AutoGenerateColumns="False" Height="57px" Width="928px">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId" />
                    <asp:BoundField AccessibleHeaderText="CourseId" HeaderText="CourseId" />
                    <asp:BoundField AccessibleHeaderText="AppointmentName" HeaderText="AppointmentName" />
                    <asp:BoundField AccessibleHeaderText="Description" HeaderText="Description" />
                    <asp:BoundField AccessibleHeaderText="Date" HeaderText="Date" />
                    <asp:BoundField AccessibleHeaderText="StartTime" HeaderText="StartTime" />
                    <asp:BoundField AccessibleHeaderText="EndTime" HeaderText="EndTime" />
                    <asp:BoundField AccessibleHeaderText="Address" HeaderText="Address" />
                    <asp:BoundField AccessibleHeaderText="PostalCode" HeaderText="PostalCode" />
                    <asp:BoundField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory" />
                    <asp:BoundField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled" />
                    <asp:BoundField />
                </Columns>
            </asp:GridView>
        </p>
    </form>
</body>
</html>
