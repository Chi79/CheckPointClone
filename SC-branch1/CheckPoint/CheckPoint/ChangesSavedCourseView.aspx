<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangesSavedCourseView.aspx.cs" Inherits="CheckPoint.Views.ChangesSavedCourseView" %>


<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" style="background-color:#333333">
<head runat="server">
    <title></title>

<style  type="text/css">

.parent{
    width: 100%;
    height: 500px;
    background: #333333;
    margin: auto;
    padding: 10px;
}
.container1{
    width: 46%;
    height: 485px;
    margin-top: 2%;
    margin-left: 25.5%;


    background-color: #333333;
    border: #66cc66;
    border-width: 20px;
    border-style: solid;
    border-radius: 36px;
}
.HeaderDiv{

    position: relative;
    display:block;
    width: 100%;
    text-align: center;
    padding-right: 8%;
    margin-top: 5%;
    margin-bottom: 4%;

}
.MessageDiv{

    position: relative;
    display:block;
    width: 77%;
    left: 11%;
    text-align: center;
    margin-top: 3%;
}
.lblHeading{
    font-family: sans-serif;
    font-size: xx-large;
    font-weight: 900;
    color:white;
}
.lblMessage{
    font-size: larger;
    font-family: sans-serif;
    color:white;
}
.btnBackToCoursesView{

    margin: 0 auto;
    display: block;
    margin-top: 0%;
}
.image{
    margin: 0 auto;
    position: relative;
    display: block;
    zoom: 192%;
    margin-top: 6%;
    margin-bottom: 5%;
}



.navButtons{
    border-radius: 5px;
    border-width: 0px;
    border-color: darkgreen;
    padding-bottom: 0.5%;
    height: 40px;
    font-family: sans-serif;
    font-size: 15px;
    font-weight: 600;
    background-image: url(/Images/buttonshade1.png);
    color: white;
}
.navButtons:hover{
    border-radius:0px;
    -webkit-animation:flashingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
@-webkit-keyframes flashingbutton{
    from{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:5px;  -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:5px;  -webkit-box-shadow: 0 0 9px #333; }
}
.panel{

    position:relative;
}



</style>


</head>
<body>
    <form id="form1" runat="server" style="background-color:#333333">

       <div id="panel1" class="parent">

        <div id="container" class="container1">

        <div class="HeaderDiv">   
        <asp:Label ID="lblHeading" runat="server" CssClass="lblHeading"></asp:Label>
        </div>  

        <div class="MessageDiv">        
        <asp:Label ID="lblMessage" runat="server" CssClass="lblMessage"></asp:Label>

        <img class="image" src="Images/vector_smiley.svg"/>
         
        <div class="btnBackToCoursesView">
        <asp:Button CssClass="navButtons" ID="btnBackToCoursessView" runat="server" OnClick="btnBackToCoursessView_Click" Text="Back To View Courses" />
        </div> 


        </div>  

      
    
    </div>

   



 </div>

    </form>
</body>
</html>
