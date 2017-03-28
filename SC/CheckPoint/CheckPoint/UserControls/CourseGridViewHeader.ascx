﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseGridViewHeader.ascx.cs" Inherits="CheckPoint.Views.UserControls.CourseGridViewHeader" %>

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



.roundedButtons {
    border-radius: 10px;
    padding-bottom:1%
}
.roundedButtons:hover{
    border-radius:10px;
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
@-webkit-keyframes glowingbutton{
    from{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:10px; -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 9px #333; }
}


.courseIdHeader{
    width: 7.5%;
    margin: auto;
}
.courseNameHeader{
    width: 11%;
    margin: auto;
    padding-right:0%;
}
.descriptionHeader{
    width: 9%;
    margin: auto;
    padding-right: 0%;
}
.isPrivateHeader{
    width: 9%;
    margin: auto;
}

.headertext {
    padding-bottom: 4%;
    font-family: sans-serif;
    font-weight: bold;
}


</style>


<asp:GridView 
ID="gvHostTable1" 
runat="server" 
AllowSorting="True"
AutoGenerateColumns="False"
Height="100%" 
OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged" 
ShowHeader="true"
ShowHeaderWhenEmpty="True"
style="
width:100%;
z-index:2;"
ShowFooter="false">
     
<Columns>

<asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId" HeaderStyle-CssClass="courseIdHeader" >
<HeaderTemplate>
<h3 class="headertext" style="color:white;">CourseId</h3>
<asp:ImageButton 
runat="server" 
CommandName="CourseId" 
ImageUrl="~/Images/uparrow3.png" 
OnCommand="Asc_Command" 
ToolTip="sort by ascending"
CssClass="roundedButtons" />
<asp:ImageButton 
runat="server" 
CommandName="CourseId" 
ImageUrl="~/Images/downarrow3.png" 
OnCommand="Desc_Command" 
ToolTip="sort by descending"
CssClass="roundedButtons"/>
</HeaderTemplate>
<ItemStyle HorizontalAlign="Center" />
<HeaderStyle />
</asp:TemplateField>


<asp:TemplateField AccessibleHeaderText="CourseName" HeaderText="CourseName" HeaderStyle-CssClass="courseNameHeader">
<HeaderTemplate>
<h3 class="headertext" style="color:white;">Name</h3>
<asp:ImageButton 
runat="server" 
CommandName="Name" 
ImageUrl="~/Images/uparrow3.png" 
OnCommand="Asc_Command" 
ToolTip="sort by ascending"
CssClass="roundedButtons" />
<asp:ImageButton 
runat="server" 
CommandName="Name" 
ImageUrl="~/Images/downarrow3.png" 
OnCommand="Desc_Command" 
ToolTip="sort by descending"
CssClass="roundedButtons"/>
</HeaderTemplate>
<ItemStyle HorizontalAlign="Center"/>
<HeaderStyle/>
</asp:TemplateField>


<asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description" HeaderStyle-CssClass="descriptionHeader">
<HeaderTemplate>
<h3 class="headertext" style="color:white;">Description</h3>
<asp:ImageButton 
runat="server" 
CommandName="Description" 
ImageUrl="~/Images/uparrow3.png" 
OnCommand="Asc_Command"  
ToolTip="sort by ascending"
CssClass="roundedButtons" />
<asp:ImageButton 
runat="server" 
CommandName="Description" 
ImageUrl="~/Images/downarrow3.png" 
OnCommand="Desc_Command" 
ToolTip="sort by descending"
CssClass="roundedButtons"/>
</HeaderTemplate>
<ItemStyle HorizontalAlign="Center" />
<HeaderStyle />
</asp:TemplateField>


<asp:TemplateField AccessibleHeaderText="IsPrivate" HeaderText="IsPrivate" HeaderStyle-CssClass="isPrivateHeader">
<HeaderTemplate>
<h3 class="headertext" style="color:white;">Private</h3>
<asp:ImageButton 
runat="server" 
CommandName="IsPrivate" 
ImageUrl="~/Images/uparrow3.png" 
OnCommand="Asc_Command"  
ToolTip="sort by ascending"
CssClass="roundedButtons"/>
<asp:ImageButton 
runat="server" 
CommandName="IsPrivate" 
ImageUrl="~/Images/downarrow3.png" 
OnCommand="Desc_Command"  
ToolTip="sort by descending"
CssClass="roundedButtons" />
</HeaderTemplate>
<ItemStyle HorizontalAlign="Center" />
<HeaderStyle />
</asp:TemplateField>

</Columns>
<HeaderStyle />
<SelectedRowStyle BackColor="#32E236" />
</asp:GridView>