<%@ Page Title="Month Attendance" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="MonthAttendance.aspx.cs" Inherits="ASR_PayMax.Transactions.MonthAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Month Attendance Master</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Month Attendance Details</h3>
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="Btn_Add_Employee" EventName="Click" />--%>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:UpdatePanel ID="UpdatePanel1234" runat="server" UpdateMode="Always">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <input id="hddEmployeeID" type="hidden" runat="server" value="0" />
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Month"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control RoundText">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Year"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control RoundText">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Client Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:UpdatePanel ID="UpdatePanel21" runat="server" UpdateMode="Always">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Site Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlSite" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSite" runat="server" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged">
                                            <asp:ListItem Value="Select One">Select One</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-sm-5">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Employee Code"></asp:Label>
                                <%--<asp:TextBox runat="server" ID="txtEmployeeCode" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlEmployeeCode" runat="server" CssClass="form-control RoundText">
                                </asp:DropDownList>
                            </div>
                        </div>
                       <%-- <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Employee Name"></asp:Label>
                                <asp:TextBox runat="server" ID="txtEmployeeName" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>--%>
                        <div class="col-sm-1">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Btn_Add_Employee" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:Button ID="Btn_Add_Employee" runat="server" Text="+" Style="margin-top: 23px;" CssClass="btn btn-primary" OnClick="Btn_Add_Employee_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Salary Cycle"></asp:Label>
                                <asp:TextBox runat="server" ID="txtSalaryCycle" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Panel ID="pnlButtons" runat="server">
                                    <asp:Button ID="Btn_Submit" Style="margin-top: 23px" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Btn_Cancel" Style="margin-top: 23px" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="table-responsive">
                        <asp:UpdatePanel ID="GridMonthAttendancePanel" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:GridView ID="GridMonthAttendance" runat="server" EmptyDataText="No Data Available" OnRowCommand="GridMonthAttendance_RowCommand" AutoGenerateColumns="false" Width="100%"
                                    CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr#" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emp ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeID" Text='<%# Eval("EmployeeID") %>' runat="server" />
                                                <asp:Label ID="lblDesignationID" Text='<%# Eval("DesignationID") %>' runat="server" />
                                                <%--<asp:Label ID="lblDutyID" Text='<%# Eval("DutyID") %>' runat="server" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeCode" Text='<%# Eval("EmployeeCode") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployee" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation Name">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlDesignationID" CssClass="GridDropDownControl RoundText" runat="server"></asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Duty Name">
                                            <ItemTemplate>
                                                <asp:UpdatePanel runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlDuty" runat="server" Style="width: 120px" CssClass="GridDropDownControl RoundText"></asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Month Days">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtMonthDays" Text='<%# Eval("MonthDays") %>' class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emp Month Days">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtEmpMonthDays" Text='<%# Eval("EmployeeDays") %>' class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gross Salary">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtGrossSalary" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Normal Days">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtNormalDays" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Weekly Off">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtWeeklyOff" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Paid Holidays">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtPaidHolidays" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OT Days">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtOTDays" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OT Hours">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtOTHours" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sp OT Days">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtSpOTDays" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sp OT Hours">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtSpOTHours" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Paid Leave">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtPaidLeave" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Casual Leave">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtCasualLeave" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sick Leave">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtSickLeave" class="GridFormControl RoundText"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
