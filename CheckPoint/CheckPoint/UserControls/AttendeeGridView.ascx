﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttendeeGridView.ascx.cs" Inherits="CheckPoint.Views.UserControls.AttendeeGridView" %>

<style type="text/css">


html, body, div, applet,span, object, iframe,
h1, h2, h3, h4, h5, h6, p, blockquote, pre,
a, abbr, acronym, address, big, cite, code,
del, dfn, em, img, ins, kbd, q, s, samp,
small, strike, strong, sub, sup, tt, var,
b, u, i, center,
dl, dt, dd, ol, ul, li,
fieldset, form, label, legend,
table, caption, tbody, tfoot, thead, tr, th, td,
article, aside, canvas, details, embed, 
figure, figcaption, footer, header, hgroup, 
menu, nav, output, ruby, section, summary,
time, mark, audio, video 
{
margin: 0;
padding: 0;
border: 0;
font-size: 100%;
font: inherit;
}
/* HTML5 display-role reset for older browsers */
article, aside, details, figcaption, figure, 
footer, header, hgroup, menu, nav, section {
	display: block;
}
body {
	line-height: 1;
}
ol, ul {
	list-style: none;
}
blockquote, q {
	quotes: none;
}
blockquote:before, blockquote:after,
q:before, q:after {
	content: '';
	content: none;
}
table {
	border-collapse: collapse;
	border-spacing: 0;
}


.courseIdColumnItem{
    width: 9.09%;
    padding-left: 0%;
    padding-right:1%;
    margin: auto;
}
.courseNameColumnItem{
    width: 12.09%;
    padding-left: 0%;
    margin: auto;
}
.descriptionColumnItem{
    width: 11.09%;
    padding-left: 0%;
    margin: auto;
}
.isPrivateColumnItem{
    width: 10.09%;
    padding-left: 2%;
    margin: auto;
}
.isObligatoryColumnItem{
    width: 10.09%;
    padding-left: 0%;
    margin: auto;
}

.datediv{
    width: 117px;
    margin: auto;
    padding-right: 8px;
}

.Row td{
    padding-top: 0.5%;
    padding-bottom: 0.5%;
    vertical-align: middle;
    text-align:center;
    font-family: sans-serif;
    font-size: 16px;

}
.AltRow td{
    padding-top: 0.5%;
    padding-bottom: 0.5%;
    vertical-align: middle;
    text-align:center;
    font-family: sans-serif;
    font-size: 16px;

}
.Row:hover{
      background:url(/Images/greenshade7.png) repeat-x;
      color:white;
      fill:#32E236;  
      -webkit-animation:glowingrow;
      -webkit-animation-duration:2s;
      -webkit-animation-iteration-count:infinite;
}
.AltRow:hover{
      background:url(/Images/greenshade7.png) repeat-x; 
      background-color:#32E236;
      color:white;
      fill:#32E236;  
      -webkit-animation:glowingrow;
      -webkit-animation-duration:2s;
      -webkit-animation-iteration-count:infinite;     
}
@-webkit-keyframes glowingrow{
    from{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 12px #333;}
     50%{ background-color:#00ff00; border-radius:10px; -webkit-box-shadow: 0 0 24px #00ff00; }
      to{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 12px #333; }
}



</style>


<asp:GridView
ID="gvAttendeeTable"
runat="server"
AutoGenerateColumns="False" 
Height="100%" 
Width="100%"  
style=" table-layout:fixed;
z-index:1" 
AllowSorting="True" 
OnSelectedIndexChanged="gvAttendeeTable_SelectedIndexChanged"
OnRowDataBound="gvAttendeeTable_RowDataBound"
ShowHeaderWhenEmpty="True" 
ShowHeader="false" 
DataKeyNames="CourseId" >
                 
<RowStyle BackColor="White" CssClass="Row"/>
<AlternatingRowStyle
CssClass="AltRow"
VerticalAlign="Middle" 
Wrap="True"
BackColor="#99FF99" />
<Columns>

                   
<asp:TemplateField AccessibleHeaderText="Username" HeaderText="Username" ItemStyle-CssClass="courseIdColumnItem">
<HeaderTemplate>
<h3 style="color:white">Username</h3>
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="lblCourseId" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
</ItemTemplate>
<ItemStyle  />
</asp:TemplateField>


<asp:TemplateField AccessibleHeaderText="Email"  HeaderText="Email" ItemStyle-CssClass="courseNameColumnItem">
<HeaderTemplate>
<h3 style="color:white">Email</h3>
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="lblCourseName"  runat="server" Text='<%# Bind("Email") %>'></asp:Label>
</ItemTemplate>
<ItemStyle />
</asp:TemplateField>


<asp:TemplateField AccessibleHeaderText="PhoneNumber" HeaderText="PhoneNumber" ItemStyle-CssClass="descriptionColumnItem">
<HeaderTemplate>
<h3 style="color:white">PhoneNumber</h3>
</HeaderTemplate>
<ItemTemplate>
<asp:Label ID="lblDescription"  runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
</ItemTemplate>
<ItemStyle />
</asp:TemplateField>


</Columns>
<SelectedRowStyle 
BackColor="#32E236" ForeColor="White" />
</asp:GridView>