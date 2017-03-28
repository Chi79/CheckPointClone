<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AppointmentGridView.ascx.cs" Inherits="CheckPoint.Views.UserControls.GridView" %>


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
                  DataKeyNames="AppointmentId"
                  >
                  
                <RowStyle BackColor="White" CssClass="Row"/>
                <AlternatingRowStyle
                    CssClass="AltRow"
                    VerticalAlign="Middle" 
                    Wrap="True"
                    BackColor="#99FF99" />
                <Columns>

                   
                    <asp:TemplateField AccessibleHeaderText="AppointmentId" HeaderText="AppointmentId"  ItemStyle-CssClass="appointmentIdColumnItem" >
                        <HeaderTemplate>
                            <h3 style="color:white" >AppointmentId</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppId" runat="server" Text='<%# Bind("AppointmentId") %>' ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
 

                    </asp:TemplateField>
                    <asp:TemplateField AccessibleHeaderText="CourseId" HeaderText="CourseId" ItemStyle-CssClass="courseIdColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">CourseId</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCourseId" runat="server" Text='<%# Bind("CourseId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle  />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="AppointmentName"  HeaderText="AppointmentName" ItemStyle-CssClass="appointmentNameColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">AppointmentName</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAppName"  runat="server" Text='<%# Bind("AppointmentName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Description" HeaderText="Description" ItemStyle-CssClass="descriptionColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">Description</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDescription"  runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date" ItemStyle-CssClass="dateColumnItem">
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


                    <asp:TemplateField AccessibleHeaderText="StartTime" HeaderText="StartTime" ItemStyle-CssClass="startTimeColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">StartTime</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("StartTime") %>' ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle  />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="EndTime" HeaderText="EndTime" ItemStyle-CssClass="endTimeColumnItem" >
                        <HeaderTemplate>
                            <h3 style="color:white">EndTime</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblEndTime"  runat="server" Text='<%# Bind("EndTIme") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle  />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="Address" HeaderText="Address" ItemStyle-CssClass="addressColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">Address</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAddress"  runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle  />
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="PostalCode" HeaderText="PostalCode" ItemStyle-CssClass="postalCodeColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">PostalCode</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPostalCode"  runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsObligatory" HeaderText="IsObligatory" ItemStyle-CssClass="isObligatoryColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">IsObligatory</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Image ID="IsObligTrue"   runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsObligatory").Equals(true) %>'/>
                            <asp:Image ID="IsObligFalse"  runat="server"  ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsObligatory").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>


                    <asp:TemplateField AccessibleHeaderText="IsCancelled" HeaderText="IsCancelled" ItemStyle-CssClass="isCancelledColumnItem">
                        <HeaderTemplate>
                            <h3 style="color:white">IsCancelled</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                              <asp:Image ID="IsCancelledTrue"  runat="server" ImageUrl="~/images/tick.png" Visible='<%# Eval("IsCancelled").Equals(true) %>' />
                            <asp:Image ID="IsCancelledFalse"   runat="server"  ImageUrl="~/images/cross.png" Visible ='<%# Eval("IsCancelled").Equals(false) %>' /> 
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>

                </Columns>
                <SelectedRowStyle 
                    BackColor="#32E236" ForeColor="White" />
            </asp:GridView>