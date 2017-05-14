<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppointmentRecordsGridView.ascx.cs" Inherits="CheckPoint.Views.UserControls.AppointmentRecordsGridView" %>


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


.selectColumnItem{
    width: 9.09%;
}
.appointmentIdColumnItem1{
    width: 33.09%;
    padding-left: 1%;
    margin: auto;
}
.courseIdColumnItem1{
    width: 8.09%;
    padding-left: 0%;
    padding-right:0%;
    margin: auto;
}
.appointmentNameColumnItem1{
    width: 12.09%;
    padding-left: 0%;
    margin: auto;
}
.descriptionColumnItem1{
    width: 9.09%;
    padding-left: 0%;
    margin: auto;
}
.dateColumnItem1{
    width: 10.09%;
    padding-left: 0.9%;
    margin: auto;
}
.startTimeColumnItem1{
    width: 10.09%;
    padding-left: 0%;
    margin: auto;
}
.endTimeColumnItem1{
    width: 9.09%;
    padding-left: 0%;
    margin: auto;
}
.addressColumnItem1{
    width: 8.09%;
    margin: auto;
    padding-left:1%;
}
.postalCodeColumnItem1{
    width: 10.09%;
    margin: auto;
    padding-left:1%;
}
.isObligatoryColumnItem1{
    width: 10.09%;
    padding-left: 0%;
    margin: auto;
}
.isPrivateColumnItem1{
    width: 10.09%;
    padding-left: 0%;
    margin: auto;
}
.isCancelledColumnItem1{
    width: 8.09%;
    padding-left: 1%;
    margin: auto;
}

.datediv{
    width: 117px;
    margin: auto;
    padding-right: 8px;
}
.headertext {
    padding-bottom: 9%;
    font-family: sans-serif;
    font-weight: bold;
    font-size: large;
}

.AppRow td{
    padding-right: 3%;
    padding-top: 0.5%;
    padding-bottom: 0.5%;
    vertical-align: middle;
    text-align: center;
    font-family: sans-serif;
    font-size: 16px;
}
.AppAltRow td{
    padding-top: 0.5%;
    padding-bottom: 0.5%;
    vertical-align: middle;
    text-align:center;
    font-family: sans-serif;
    font-size: 16px;

}
.AppRow:hover{
      /*background:#32E236 url(/Images/greenshade1.png) repeat-x;*/
      background:url(/Images/greenshade7.png) repeat-x;
      color:white;
      fill:#32E236;  
      -webkit-animation:glowingrow;
      -webkit-animation-duration:2s;
      -webkit-animation-iteration-count:infinite;
}
.AppAltRow:hover{
      /*background: #32E236 url(/Images/greenshade1.png) repeat-x;*/ 
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
 ID="gvHostTable"
 runat="server"
 AutoGenerateColumns="False" 
 Height="100%" 
 Width="100%"  
 style=" table-layout:fixed;
 z-index:1" 
 AllowSorting="True" 
 OnSelectedIndexChanged="gvHostTable_SelectedIndexChanged"
 OnRowDataBound="gvHostTable_RowDataBound"
 ShowHeaderWhenEmpty="True" 
 ShowHeader="false" 
 DataKeyNames="AppointmentId">
                  
 <RowStyle BackColor="White" CssClass="AppRow"/>

 <AlternatingRowStyle
 CssClass="AppAltRow"
 VerticalAlign="Middle" 
 Wrap="True"
 BackColor="#99FF99" />

 <Columns>

                   
 <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId"  ItemStyle-CssClass="appointmentIdColumnItem1" Visible="false" >
 <HeaderTemplate>
 <h3 style="color:white" >AppointmentId</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Label ID="lblAppId" runat="server" Text='<%# Bind("AppointmentId") %>' ></asp:Label>
 </ItemTemplate>
 <ItemStyle />
 </asp:TemplateField>



 <asp:TemplateField AccessibleHeaderText="AppointmentName"  HeaderText="AppointmentName" ItemStyle-CssClass="appointmentNameColumnItem1">
 <HeaderTemplate>
 <h3 style="color:white">AppointmentName</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Label ID="lblAppName"  runat="server" Text='<%# Bind("AppointmentName") %>'></asp:Label>
 </ItemTemplate>
 <ItemStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description" ItemStyle-CssClass="descriptionColumnItem1">
 <HeaderTemplate>
 <h3 style="color:white">Description</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Label ID="lblDescription"  runat="server" Text='<%# Bind("Description") %>'></asp:Label>
 </ItemTemplate>
 <ItemStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId" ItemStyle-CssClass="courseIdColumnItem1" Visible="false">
 <HeaderTemplate>
 <h3 style="color:white">CourseId</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Label ID="lblCourseId" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
 </ItemTemplate>
 <ItemStyle  />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date" ItemStyle-CssClass="dateColumnItem1">
 <HeaderTemplate>
 <h3 style="color:white">Date</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <div id="datediv" class="datediv">
 <asp:Label ID="lblDate" runat="server" Text='<%# Convert.ToDateTime(Eval("Date")).ToString("MM/dd/yyyy") %>' Height="15%"></asp:Label>
 <input type="hidden" class="picker" id="datepicker" value='<%# Convert.ToDateTime(Eval("Date")).ToString("MM/dd/yyyy") %>'/>  
 </div>
 </ItemTemplate>
 <ItemStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime" ItemStyle-CssClass="startTimeColumnItem1">
 <HeaderTemplate>
 <h3 style="color:white">StartTime</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("StartTime") %>' ></asp:Label>
 </ItemTemplate>
 <ItemStyle  />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime" ItemStyle-CssClass="endTimeColumnItem1" >
 <HeaderTemplate>
 <h3 style="color:white">EndTime</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Label ID="lblEndTime"  runat="server" Text='<%# Bind("EndTIme") %>'></asp:Label>
 </ItemTemplate>
 <ItemStyle  />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address" ItemStyle-CssClass="addressColumnItem1">
 <HeaderTemplate>
 <h3 style="color:white">Address</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Label ID="lblAddress"  runat="server" Text='<%# Bind("Address") %>'></asp:Label>
 </ItemTemplate>
 <ItemStyle  />
 <ItemStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode" ItemStyle-CssClass="postalCodeColumnItem1">
 <HeaderTemplate>
 <h3 style="color:white">PostalCode</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Label ID="lblPostalCode"  runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
 </ItemTemplate>
 <ItemStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory" ItemStyle-CssClass="isObligatoryColumnItem1">
 <HeaderTemplate>
 <h3 style="color:white">IsObligatory</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Image ID="IsObligTrue"   runat="server" ImageUrl="~/Images/tick3.svg" Visible='<%# Eval("IsObligatory").Equals(true) %>'/>
 <asp:Image ID="IsObligFalse"  runat="server"  ImageUrl="~/Images/cross2.svg" Visible ='<%# Eval("IsObligatory").Equals(false) %>' /> 
 </ItemTemplate>
 <ItemStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="IsPrivate" HeaderText="IsPrivate" ItemStyle-CssClass="isPrivateColumnItem1">
 <HeaderTemplate>
 <h3 style="color:white">IsPrivate</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Image ID="IsPrivateTrue"   runat="server" ImageUrl="~/Images/tick3.svg" Visible='<%# Eval("IsPrivate").Equals(true) %>'/>
 <asp:Image ID="IsPrivateFalse"  runat="server"  ImageUrl="~/Images/cross2.svg" Visible ='<%# Eval("IsPrivate").Equals(false) %>' /> 
 </ItemTemplate>
 <ItemStyle />
 </asp:TemplateField>


 <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled" ItemStyle-CssClass="isCancelledColumnItem1">
 <HeaderTemplate>
 <h3 style="color:white">IsCancelled</h3>
 </HeaderTemplate>
 <ItemTemplate>
 <asp:Image ID="IsCancelledTrue"  runat="server" ImageUrl="~/Images/tick3.svg" Visible='<%# Eval("IsCancelled").Equals(true) %>' />
 <asp:Image ID="IsCancelledFalse"   runat="server"  ImageUrl="~/Images/cross2.svg" Visible ='<%# Eval("IsCancelled").Equals(false) %>' /> 
 </ItemTemplate>
 <ItemStyle />
 </asp:TemplateField>


 </Columns>
 <SelectedRowStyle 
 BackColor="#32E236" ForeColor="White" />
 </asp:GridView>