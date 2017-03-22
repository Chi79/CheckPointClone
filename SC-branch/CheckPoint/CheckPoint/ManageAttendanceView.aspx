<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAttendanceView.aspx.cs" Inherits="CheckPoint.Views.ManageAttendanceView" EnableEventValidation="false"  MasterPageFile="~/Master.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title></title>

    <style>
        #wrapper{
            width: 100%;
            height: 100%;
            background: #333333;
        }

        #dgvApplicants{
            position:absolute;
            left:60%;
            top:30%;
        }

        #dgvAppointments{
            position:absolute;
            left:20%;
            top:30%;
        }

        #btnAcceptAttendeeRequest{
            position:absolute;
            left:45%;
            width:10%;
            height:8%;
            top:40%;
        }


    </style>

</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div id="wrapper">
        <asp:GridView ID="dgvApplicants" runat="server" ShowHeaderWhenEmpty="True"></asp:GridView>
        <asp:Button ID="btnAcceptAttendeeRequest" runat="server" Text="Accept as attendee" OnClick="btnAcceptAttendeeRequest_Click" />
        <asp:GridView ID="dgvAppointments" runat="server" ShowHeaderWhenEmpty="True"></asp:GridView>
    </div>

</asp:Content>


