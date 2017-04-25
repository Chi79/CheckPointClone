<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAttendanceView.aspx.cs" Inherits="CheckPoint.Views.ManageAttendanceView" EnableEventValidation="false"   MasterPageFile="~/HostMaster.Master" %>

<%@ Register Src="~/UserControls/CourseGridViewHeader.ascx" TagPrefix="uc1" TagName="CourseGridViewHeader" %>
<%@ Register Src="~/UserControls/CourseGridView.ascx" TagPrefix="uc1" TagName="CourseGridView" %>
<%@ Register Src="~/UserControls/AppointmentGridViewHeader.ascx" TagPrefix="uc1" TagName="AppointmentGridViewHeader" %>
<%@ Register Src="~/UserControls/AppointmentGridView.ascx" TagPrefix="uc1" TagName="AppointmentGridView" %>





<asp:Content ContentPlaceHolderID="head" runat="server">
    <title></title>

    <style>
        #wrapper{
            width: 100%;
            height: 100%;
            background: #333333;
        }


    </style>

</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div id="wrapper">
        <uc1:CourseGridViewHeader runat="server" id="CourseGridViewHeader" />
        <uc1:CourseGridView runat="server" id="CourseGridView" />
        <br/>
        <uc1:AppointmentGridViewHeader runat="server" id="AppointmentGridViewHeader" />
        <uc1:AppointmentGridView runat="server" id="AppointmentGridView" />
        <asp:Button ID="btnAcceptAttendanceRequest" runat="server" Text="Accept Attendance Request" />
    </div>


</asp:Content>


