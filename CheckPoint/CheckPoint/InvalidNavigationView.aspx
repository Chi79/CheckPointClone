<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvalidNavigationView.aspx.cs" Inherits="CheckPoint.Views.InvalidNavigationView" %>

<%@ Register Src="~/UserControls/NavigationMessage.ascx" TagPrefix="uc1" TagName="NavigationMessage" %>


<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<style  type="text/css">

#btnBackToCoursesView{
    position: absolute;
    top:19em;
    left:45em;
}

</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>

        <uc1:NavigationMessage runat="server" id="NavigationMessage" />

        <asp:Button ID="btnBackToCoursesView" runat="server" OnClick="btnBackToCoursesView_Click" Text="Back To View Courses" />
    
    </div>
    </form>
</body>
</html>
