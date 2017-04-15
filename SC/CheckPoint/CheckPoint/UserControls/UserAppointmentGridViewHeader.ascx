<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAppointmentGridViewHeader.ascx.cs" Inherits="CheckPoint.Views.UserControls.UserAppointmentGridViewHeader" %>

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
    -webkit-animation:glowingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
@-webkit-keyframes glowingbutton{
    from{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 9px #333;}
     50%{ background-color:#00ff00; border-radius:10px; -webkit-box-shadow: 0 0 18px #00ff00; }
      to{ background-color:#4dff4d; border-radius:10px; -webkit-box-shadow: 0 0 9px #333; }
}

.selectHeader{

}
.appointmentIdHeader{
    width: 12%;
    margin: auto;
}
.courseIdHeader{
    width: 7.5%;
    margin: auto;
}
.appointmentNameHeader{
    width: 11%;
    margin: auto;
    padding-right:0%;
}
.descriptionHeader{
    width: 9%;
    margin: auto;
    padding-right: 0%;
}
.dateHeader{
    width: 9.5%;
    margin: auto;
    padding-right: 0%;
}
.startTimeHeader{
    width: 9%;
    margin: auto;
    padding-right: 0%;
}
.endTimeHeader{
    width: 8.1%;
    margin: auto;
    padding-right: 0%;
}
.addressHeader{
    width: 8.1%;
    margin: auto;
}
.postalCodeHeader{
    width: 9%;
    margin: auto;
}
.isObligatoryHeader{
    width: 9%;
    margin: auto;
}
.isPrivateHeader{
    width: 9%;
    margin: auto;
}
.isCancelledHeader{
    width: 9%;
    margin: auto;
}

.headertext {
    padding-bottom: 9%;
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

 <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId" HeaderStyle-CssClass="appointmentIdHeader" Visible="false" >
 <HeaderTemplate>
 <h3  class="headertext" style="color:white;">AppointmentId</h3>
 <asp:ImageButton 
 runat="server" 
 CommandName="AppointmentId" 
 ImageUrl="~/Images/uparrow3.png" 
 OnCommand="Asc_Command" 
 ToolTip="sort by ascending"
 CssClass="roundedButtons" />
 <asp:ImageButton 
 runat="server" 
 CommandName="AppointmentId" 
 ImageUrl="~/Images/downarrow3.png" 
 OnCommand="Desc_Command"  
 ToolTip="sort by descending"
 CssClass="roundedButtons"/>
 </HeaderTemplate>
 <ItemStyle HorizontalAlign="Center"/>
 <HeaderStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderText="AppointmentName" HeaderStyle-CssClass="appointmentNameHeader">
 <HeaderTemplate>
 <h3 class="headertext" style="color:white;">Name</h3>
 <asp:ImageButton 
 runat="server" 
 CommandName="AppointmentName" 
 ImageUrl="~/Images/uparrow3.png" 
 OnCommand="Asc_Command" 
 ToolTip="sort by ascending"
 CssClass="roundedButtons" />
 <asp:ImageButton 
 runat="server" 
 CommandName="AppointmentName" 
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

 <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId" HeaderStyle-CssClass="courseIdHeader" Visible="false">
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


 <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date" HeaderStyle-CssClass="dateHeader">
 <HeaderTemplate>
 <h3 class="headertext" style="color:white;">Date</h3>
 <asp:ImageButton 
 runat="server" 
 CommandName="Date" 
 ImageUrl="~/Images/uparrow3.png" 
 OnCommand="Asc_Command" 
 ToolTip="sort by ascending"
 CssClass="roundedButtons" />
 <asp:ImageButton 
 runat="server" 
 CommandName="Date" 
 ImageUrl="~/Images/downarrow3.png" 
 OnCommand="Desc_Command"  
 ToolTip="sort by descending"
 CssClass="roundedButtons" />
 </HeaderTemplate>
 <ItemStyle HorizontalAlign="Center" />
 <HeaderStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime" HeaderStyle-CssClass="startTimeHeader">
 <HeaderTemplate>
 <h3 class="headertext" style="color:white;" >StartTime</h3>
 <asp:ImageButton 
 runat="server" 
 CommandName="StartTime" 
 ImageUrl="~/Images/uparrow3.png" 
 OnCommand="Asc_Command"   
 ToolTip="sort by ascending"
 CssClass="roundedButtons"/>
 <asp:ImageButton 
 runat="server" 
 CommandName="StartTime" 
 ImageUrl="~/Images/downarrow3.png" 
 OnCommand="Desc_Command"  
 ToolTip="sort by descending"
 CssClass="roundedButtons" />
 </HeaderTemplate>
 <ItemStyle HorizontalAlign="Center"/>
 <HeaderStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime" HeaderStyle-CssClass="endTimeHeader">
 <HeaderTemplate>
 <h3 class="headertext" style="color:white;">EndTime</h3>
 <asp:ImageButton 
 runat="server" 
 CommandName="EndTime" 
 ImageUrl="~/Images/uparrow3.png"
 OnCommand="Asc_Command"  
 ToolTip="sort by ascending"
 CssClass="roundedButtons" />
 <asp:ImageButton 
 runat="server" 
 CommandName="EndTime" 
 ImageUrl="~/Images/downarrow3.png" 
 OnCommand="Desc_Command" 
 ToolTip="sort by descending"
 CssClass="roundedButtons" />
 </HeaderTemplate>
 <ItemStyle HorizontalAlign="Center"/>
 <HeaderStyle/>
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address" HeaderStyle-CssClass="addressHeader">
 <HeaderTemplate>
 <h3 class="headertext" style="color:white;">Address</h3>
 <asp:ImageButton 
 runat="server" 
 CommandName="Address" 
 ImageUrl="~/Images/uparrow3.png" 
 OnCommand="Asc_Command" 
 ToolTip="sort by ascending"
 CssClass="roundedButtons" />
 <asp:ImageButton 
  runat="server" 
  CommandName="Address" 
  ImageUrl="~/Images/downarrow3.png" 
  OnCommand="Desc_Command"  
  ToolTip="sort by descending"
  CssClass="roundedButtons"/>
  </HeaderTemplate>
  <ItemStyle HorizontalAlign="Center" />
  <ItemStyle />
  <HeaderStyle />
  </asp:TemplateField>


  <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode" HeaderStyle-CssClass="postalCodeHeader">
  <HeaderTemplate>
  <h3 class="headertext" style="color:white;">PostalCode</h3>
  <asp:ImageButton 
  runat="server" 
  CommandName="PostalCode" 
  ImageUrl="~/Images/uparrow3.png" 
  OnCommand="Asc_Command"  
  ToolTip="sort by ascending"
  CssClass="roundedButtons"/>
  <asp:ImageButton 
  runat="server" 
  CommandName="PostalCode" 
  ImageUrl="~/Images/downarrow3.png" 
  OnCommand="Desc_Command"  
  ToolTip="sort by descending"
  CssClass="roundedButtons" />
  </HeaderTemplate>
  <ItemStyle HorizontalAlign="Center" />
  <HeaderStyle />
  </asp:TemplateField>


  <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory" HeaderStyle-CssClass="isObligatoryHeader">
  <HeaderTemplate>
  <h3 class="headertext" style="color:white;">Obligatory</h3>
  <asp:ImageButton 
  runat="server" 
  CommandName="IsObligatory" 
  ImageUrl="~/Images/uparrow3.png" 
  OnCommand="Asc_Command"  
  ToolTip="sort by ascending"
  CssClass="roundedButtons"/>
  <asp:ImageButton 
  runat="server" 
  CommandName="IsObligatory" 
  ImageUrl="~/Images/downarrow3.png" 
  OnCommand="Desc_Command"  
  ToolTip="sort by descending"
  CssClass="roundedButtons" />
  </HeaderTemplate>
  <ItemStyle HorizontalAlign="Center" />
  <HeaderStyle />
  </asp:TemplateField>


  <asp:TemplateField AccessibleHeaderText="IsPrivate" HeaderText="IsPrivate" HeaderStyle-CssClass="isPrivateHeader" Visible="false">
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


  <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled" HeaderStyle-CssClass="isCancelledHeader">
  <HeaderTemplate>
  <h3 class="headertext" style="color:white;">Cancelled</h3>
  <asp:ImageButton 
  runat="server" 
  CommandName="IsCancelled" 
  ImageUrl="~/Images/uparrow3.png" 
  OnCommand="Asc_Command" 
  ToolTip="sort by ascending"
  CssClass="roundedButtons" />
  <asp:ImageButton 
  runat="server" 
  CommandName="IsCancelled" 
  ImageUrl="~/Images/downarrow3.png" 
  OnCommand="Desc_Command"  
  ToolTip="sort by descending"
  CssClass="roundedButtons" />
  </HeaderTemplate>
  <ItemStyle HorizontalAlign="Center" />
  <HeaderStyle/>
  </asp:TemplateField>


  </Columns>
  <HeaderStyle />
  <SelectedRowStyle BackColor="#32E236" />
  </asp:GridView>