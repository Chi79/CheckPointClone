<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvalidNavigationView.aspx.cs" Inherits="CheckPoint.Views.InvalidNavigationView" %>

<%@ Register Src="~/UserControls/NavigationMessage.ascx" TagPrefix="uc1" TagName="NavigationMessage" %>


<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<style  type="text/css">

#btnBackToCoursesView{
    position: relative;
    margin: 0 auto;
    display: block;
    top: -24em;
}
.navButtons{
    border-radius: 5px;
    border-width: 0px;
    border-color: darkgreen;
    padding-bottom: 1%;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    color: white;
    padding-top: 0.5%;
    font-weight: 600;
    background-image: url(/Images/buttonshade1.png);
}
 .navButtons:hover{
    border-radius:5px;
    -webkit-animation:flashingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
    @-webkit-keyframes flashingbutton {
        from {
            background-color: #4dff4d;
            border-radius: 5px;
            -webkit-box-shadow: 0 0 9px #333;
        }

        50% {
            background-color: #00ff00;
            border-radius: 5px;
            -webkit-box-shadow: 0 0 18px #00ff00;
        }

        to {
            background-color: #4dff4d;
            border-radius: 5px;
            -webkit-box-shadow: 0 0 9px #333;
        }
    }

</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>

        <uc1:NavigationMessage runat="server" id="NavigationMessage" />

        <asp:Button CssClass="navButtons" ID="btnBackToCoursesView" runat="server" OnClick="btnBackToCoursesView_Click" Text="Back To View Courses" />
    
    </div>
    </form>
</body>
</html>
