<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePageView.aspx.cs" Inherits="CheckPoint.Views.HomePageView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="CSS/homepage.css" rel="stylesheet" type="text/css" />--%>
      <meta name="viewport"   content="width=device-width, initial-scale=1"/>

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
    <style>
html
{
    width: 100%;
    height: 100%;
    margin: 0;
    padding: 0;
    overflow-x: hidden;
    background:#66cc66;
}
 body
 {
    width: 100%;
    height: 100%;
    margin: 0;
    padding: 0;
    overflow-x: hidden;
}

        #wrapper{
            position:absolute;
            width:100%;
            height:100%;

        }

        #body {
            position:absolute;
            height:55%;
            width:100%;
            background:#333333; 
            top:15%;
            left:0%;
        }

        #header {
            position:absolute;
            height:15%;
            width:100%;
            background:#333333; 
        }

        #footer {
            position:absolute;
            height:30%;
            width:100%;
            top:70%;
            background:#59b959;
        }

        #header-logo{
            position:absolute;
            top:29%;
            width:30%;
            height:60%;
            background:url("/Images/logo_white2.png");
            background-repeat:no-repeat;
            background-size:contain;
            left:5%;
        }

        #body-main-headline{
            position:absolute;
            top: 5%;
            color:white;
            font-size:45px;
            left:5%;
            font-family:sans-serif;
            font-weight:bold;
            height: 38%;
            width: 30%;
        }

        #body-main-subtext{
            position:absolute;
            height:25%;
            left:5%;
            width:30%;
            top: 40%;
            color:#999999;
		    font-size:18px;
		    font-family: sans-serif;
		    font-weight:bold;
        }

        #body-action-window {
            position: absolute;
            height: 100%;
            width: 55%;
            left: 40%;
            top:0%;
            background:url("../Images/cheesy-placeholder3.jpg");
            background-size: cover;
            background-repeat:no-repeat;
        }

        #footer-container1{
            left:0%;
            width:25%;
        }

        #footer-container2{
            left:25%;
            width:25%;
        }

        #footer-container3{
            left:50%;
            width:25%;
        }

        #footer-container4{
            left:75%;
            width:25%;
        }

        #footer-container1-img{
            position:absolute;
            background-image:url("../Images/calender-white.png");
            background-repeat:no-repeat;
            background-size:contain;
            height:20%;
            width:100%;
            top:10%;
            left:43%;          
        }

        #footer-container2-img{
            position:absolute;
            height:20%;
            width:100%;
            top:10%;
            left:40%;
            background-image:url("../Images/crowd.png");
            background-repeat:no-repeat;
            background-size:contain;
        }

        #footer-container3-img{
            position:absolute;
            height:20%;
            width:100%;
            top:10%;
            left:42%;      
            background-repeat:no-repeat;
            background-size:contain;        
            background-image:url("../Images/identify.png");
        }

        #footer-container4-img{
            position:absolute;
            height:20%;
            width:100%;
            top:10%;
            left:43%;
            background-image:url("../Images/white-check.png");  
            background-repeat:no-repeat;
            background-size:contain;   
        }
      
        .footer-text {
		    color:white;
		    font-size:16px;
		    font-family:sans-serif;
		    font-weight:bold;
		    position:absolute;
            width:100%; 
            text-align:center;
		    top:20%;  
	    }
         .footer-text h3{
            /*left:15%;*/
		    font-size:28px;				  
	    }

         .footer-container{
            position:absolute;
            width:25%;
            height:100%;
            background:#66cc66;
         }
         #btnLogIn{
		    width:15%;
		    height:40%;
            margin-right:5%;
            right:0%;
            top:57%;
         }

         #btnGetStarted{
            width:30%;
		    height:15%;
            top:58%;
            left:5%;
            font-size:large;
         }

         .default-button-style{
            position:absolute;
            background-color:#66cc66;
		    color:white;
		    font-weight:bold;
		    font-size:20px;	
		    border-radius: 6px;
            border-color:#333333;
         }

         .nav-button-style{
             position:absolute;
             background-color:transparent;
             border:none;
             color:white;
             font-size:24px; 
             top:25%;        
         }

         #btnFeatures{
            left:0%;
        }
          #btnAbout{
            left:40%;
        }
           #btnContact{
            right:0%;
        }

           #getstartedbutton{
               top:50%;
               right:5%;
           }

           #separator1{
               left:30%;
               
           }
           #separator2{
               right:35%;
           }

           #nav-bar-header{
               position:absolute;             
               margin: 0px;
               height:20%;
               width:30%;
               right:20%;
               top:35%;
           }

           
           #twitter-feed{
               position:absolute;
               top:70%;
               left:30%;
           }
           #frmCheckPointUI{
               height:100%;
               width:100%;
               margin:0;
               padding:0;
           }

           .fb-like{
               position:absolute;
               height:15%;
               width:30%;
               left:6%;
               top:78%;
           }

    </style> 
       
</head>
<body>
    <div id="wrapper">
    <div id="fb-root"></div>

    <form id="frmCheckPointUI" runat="server">
        <%-- Header --%>
    <div id="header">
       
        <div id="header-logo"></div>
        <asp:Button ID="btnLogIn" CssClass="default-button-style" runat="server" Text="Login" OnClick="btnLogIn_Click" />
        <%-- Navigation Bar --%>
      <%--  <div id="nav-bar-header"> 
        <asp:Button ID="btnFeatures" CssClass="default-button-style" runat="server" Text="Features" /> 
        <div id="separator1" class="nav-button-style">/</div> 
        <asp:Button ID="btnContact" CssClass="default-button-style" runat="server" Text="Contact Us" />
        <div id="separator2" class="nav-button-style">/</div>
        <asp:Button ID="btnAbout" CssClass="default-button-style" runat="server" Text="About" />
        </div>  --%>     
    </div>
        <%-- Body --%>
    <div id="body">
        <div id="body-main-headline">Attend Anything,<br />Anywhere,<br /> Anytime!</div>
        <div id="body-main-subtext">
            <p style="font-size:20px;">Hosting and attending appointments has never been easier!
            </p>
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
             <%--<asp:Image ID="imgBodyActionWindow" runat="server" ImageUrl="~/Images/cheesy-placeholder3.jpg" style="width:auto" /></div>--%> 
    </div>
        </div>
        <%-- Footer --%>
    <div id="footer">
        <div id="footer-container1" class="footer-container">
             <div id="footer-container1-img"></div>
            <div id="footer-container1-text" class="footer-text">
                <h3>Appointments</h3>
			    <p>Create appointments on the go,</p>
			    <p>both one-time and entire courses</p>
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
  </div>
</body>
</html>
