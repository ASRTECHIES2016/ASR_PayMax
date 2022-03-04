<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="AttendanceEmployee.aspx.cs" Inherits="ASR_PayMax.Transactions.AttendanceEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .table th, .table td {
            padding: 0.25rem;
            vertical-align: top;
            border-top: 1px solid #dee2e6;
        }
    </style>
  <%--  <section class="content-header">
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
                    <asp:AsyncPostBackTrigger ControlID="Btn_Search" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Clear" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="row">
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
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText">
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
                        <div class="col-sm-2">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Employee Code"></asp:Label>
                                <asp:TextBox runat="server" ID="txtEmployeeCode" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Employee Name"></asp:Label>
                                <asp:TextBox runat="server" ID="txtEmployeeName" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Salary Cycle"></asp:Label>
                                <asp:TextBox runat="server" ID="txtSalaryCycle" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Panel ID="pnlSearch" runat="server">
                                    <asp:Button ID="Btn_Search" Style="margin-top: 23px" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="Btn_Search_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Btn_Clear" Style="margin-top: 23px" runat="server" Text="Clear" CssClass="btn btn-danger" OnClick="Btn_Clear_Click" />
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-sm-2">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control RoundText">
                                <asp:ListItem Value="Select One">Select One</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-sm-1">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Always">
                                <%-- <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlSite" EventName="SelectedIndexChanged" />
                                </Triggers>--%>
                                <ContentTemplate>
                                    <asp:Button ID="Button1" runat="server" Text="Clear" CssClass="btn btn-info" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-sm-9">
                            <asp:Label ID="lblNote" Text="Note : NH = National Holiday" runat="server" />
                        </div>
                    </div>

                    <div class="table-responsive">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:GridView ID="GridMonthAttendance" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="true" Width="100%"
                                    CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Emp ID" Visible="false">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="lblEmployeeID" Text='<%# Eval("EmployeeID") %>' runat="server" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code">
                                            <ItemTemplate>
                                                <%--<asp:Label ID="lblEmployeeCode" Text='<%# Eval("EmployeeCode") %>' runat="server" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <b>
                                                    <asp:Label ID="lblEmployee" runat="server" Text='<%# Eval("BankName") %>'></asp:Label></b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day Type">
                                            <ItemTemplate>
                                                <b>
                                                    <asp:Label ID="Label1" runat="server" Text='Status'></asp:Label><br />
                                                    <asp:Label ID="Label2" runat="server" Text='OT Hours'></asp:Label>
                                                </b>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 1">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD1" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD1OT" class="GridFormControl RoundText" Width="50px" Text="0.0"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 2">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD2" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD2OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 3">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD3" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD3OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 4">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD4" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD4OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 5">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD5" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD5OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 6">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD6" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD6OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 7">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD7" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD7OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 8">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD8" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD8OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 9">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD9" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD9OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 10">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD10" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD10OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 11">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD11" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD11OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 12">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD12" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD12OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 13">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD13" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD13OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 14">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD14" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD14OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 15">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD15" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD15OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 16">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD16" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD16OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 17">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD17" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD17OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 18">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD18" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD18OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 19">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD19" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD19OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 20">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD20" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD20OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 21">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD21" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD21OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 22">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD22" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD22OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 23">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD23" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD23OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 24">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD24" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD24OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 25">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD25" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD25OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 26">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD26" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD26OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 27">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD27" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD27OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 28">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD28" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD28OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 29">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD29" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD29OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 30">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD30" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD30OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day 31">
                                            <ItemTemplate>
                                                <asp:TextBox Enabled="false" runat="server" ID="txtD31" class="GridFormControl RoundText" Width="50px"></asp:TextBox>

                                                <asp:TextBox Enabled="false" runat="server" ID="txtD31OT" class="GridFormControl RoundText" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <asp:Panel ID="pnlButtons" runat="server">
                        <asp:Button ID="Btn_Submit" Style="margin-top: 23px" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                        &nbsp;&nbsp;
                                    <asp:Button ID="Btn_Cancel" Style="margin-top: 23px" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
