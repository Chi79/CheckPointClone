<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppointmentGridViewHeader.ascx.cs" Inherits="CheckPoint.Views.UserControls.AppointmentGridViewHeader" %>


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
                             <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId" HeaderStyle-CssClass="appointmentIdHeader" >
                                 <HeaderTemplate>
                                     <h3 style="color:white;">AppointmentId</h3>
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
                             <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId" HeaderStyle-CssClass="courseIdHeader" >
                                 <HeaderTemplate>
                                     <h3 style="color:white;">CourseId</h3>
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
                             <asp:TemplateField AccessibleHeaderText="AppointmentName" HeaderText="AppointmentName" HeaderStyle-CssClass="appointmentNameHeader">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">Name</h3>
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
                                     <h3 style="color:white;">Description</h3>
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
                             <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date" HeaderStyle-CssClass="dateHeader">
                                 <HeaderTemplate>
                                     <h3 style="color:white;">Date</h3>
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
                                     <h3 style="color:white;" >StartTime</h3>
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
                                     <h3  style="color:white;">EndTime</h3>
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
                                     <h3  style="color:white;">Address</h3>
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
                                     <h3 style="color:white;">PostalCode</h3>
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
                                     <h3 style="color:white;">Obligatory</h3>
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
                             <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled" HeaderStyle-CssClass="isCancelledHeader">
                                 <HeaderTemplate>
                                     <h3  style="color:white;">Cancelled</h3>
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