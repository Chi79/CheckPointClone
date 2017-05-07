<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorView.aspx.cs" Inherits="CheckPoint.Views.Error" %>
<%-- This page is shown when an error accure, you can find the call for this page in the web.config file --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        *{
            background:#333333; 
            color:white;
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            text-align:center;
        }
        h1{
            font-size:50px;
            font-weight:bold;
        }
        h2{
            color:lightgray;
            font-size:small;
        }
.image{
    position: fixed;
    top: 45%;
    left: 35%;
    display: block;
    height: auto;
    width: 25%;
    border-radius: 10px;
    margin: 0;
    padding: 0%;
    border: none;
    border-image: none;
    z-index:-1;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
    
        <h1>Congratulations!
       </h1>
        <h2>
             You found a fault in the CheckPoint software.
        </h2>
        <h2>Please go back to continue.</h2>
        <img class="image" src="Images/bug.png" />

    </div>
    </form>
</body>
</html>
