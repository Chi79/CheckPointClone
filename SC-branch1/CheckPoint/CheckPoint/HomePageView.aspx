<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePageView.aspx.cs" Inherits="CheckPoint.Views.HomePageView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/homepage.css" rel="stylesheet" type="text/css" />
      <meta name="viewport"   content="width=device-width, initial-scale=2"/>

    <title>Welcome To CheckPoint!</title>  
    
     <%-- Scripts to be put in separate .js file later --%>
        <script>
            (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/nb_NO/sdk.js#xfbml=1&version=v2.8";
            fjs.parentNode.insertBefore(js, fjs);
            }
            (document, 'script', 'facebook-jssdk'));
   
            function LogInPopUp() {
                window.open("LogIn.aspx", "", "height=400, width=200 left=50%", true); return false;;
            }
           
        </script>  
       
</head>
<body>
    <div id="fb-root"></div>

    <form id="frmCheckPointUI" runat="server">
        <%-- Header --%>
    <div id="header">
       
        <script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script>
        <div id="header-logo"></div>
        <asp:Button ID="btnLogIn" CssClass="default-button-style" runat="server" Text="Login" OnClick="btnLogIn_Click" />
        <%-- Navigation Bar --%>
        <div id="nav-bar-header"> 
        <asp:Button ID="btnFeatures" CssClass="default-button-style" runat="server" Text="Features" /> 
        <div id="separator1" class="nav-button-style">/</div> 
        <asp:Button ID="btnContact" CssClass="default-button-style" runat="server" Text="Contact Us" />
        <div id="separator2" class="nav-button-style">/</div>
        <asp:Button ID="btnAbout" CssClass="default-button-style" runat="server" Text="About" />
        </div>       
    </div>
        <%-- Body --%>
    <div id="body">
        <div id="body-main-headline">Attend Anything,<br />Anywhere,<br /> Anytime..</div>
        <div id="body-main-subtext">
            Hosting and attending courses and appointments have never been easier!<br/>
			The CheckPoint Attendance System provides a simple and efficient way of <br/>
			some useful information about the checkpoint product later on.
        </div>    
         <asp:Button ID="btnGetStarted" CssClass="default-button-style" runat="server" Text="Get Started With CheckPoint" OnClick="btnGetStarted_Click" />    
        <%-- FB like button --%>
        <div class="fb-like" data-href="https://www.facebook.com/CheckPointAttendanceSystem/" data-layout="standard" 
        data-action="like" data-show-faces="true" data-share="true" 	
        data-colorscheme="dark" data-size="large"></div>
        <%-- Twitter feed --%>
        <%--<div id="twitter-feed"><a class="twitter-timeline" data-width="220" data-height="200" data-theme="dark" data-link-color="#66cc66" href="https://twitter.com/CheckPointAS">Tweets by CheckPointAS</a> <script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script></div>--%>
         <%-- Action Window Content --%>       
         <div id="body-action-window">
             <asp:Image ID="imgBodyActionWindow" runat="server" ImageUrl="~/Images/cheesy-placeholder3.jpg" style="margin-left: 0px; margin-bottom: 0px" /></div> 
    </div>
        <%-- Footer --%>
    <div id="footer">
        <div id="footer-container1" class="footer-container">
             <div id="footer-container1-img"></div>
            <div id="footer-container1-text" class="footer-text">
                <h3>Appointments</h3>
			    <p>Create appointments on the go,</p>
			    <p>both one-time and periodic events</p>
			    <p>and monitor them in realtime</p>
            </div>
            
        </div>
        <div id="footer-container2" class="footer-container">
             <div id="footer-container2-img"></div>
            <div id="footer-container2-text" class="footer-text">
                <h3>Attendees</h3>
			    <p>Register attendance at your school,</p>
			    <p>workplace, music festival, sporting event,</p>
			    <p>nightclub; anywhere!</p>
            </div>
            
        </div>
        <div id="footer-container3" class="footer-container">
             <div id="footer-container3-img"></div>
             <div id="footer-container3-text" class="footer-text">
                 <h3>Identification</h3>
			    <p>Use the type of identification that fits your needs</p>
			    <p>including tags, cards, bracelets, fingerprint </p>
			    <p>scanning and voice recognition</p>
             </div>
            
        </div>
        <div id="footer-container4" class="footer-container">
             <div id="footer-container4-img"></div>
            <div id="footer-container4-text" class="footer-text">
                <h3>Validate</h3>
			    <p>No more manual attendance validation!</p>
			    <p>Receive automatically generated reports</p>
			    <p>for all of your registered appointments</p>
            </div>
           
        </div>
    </div>
    </form>
</body>
</html>
