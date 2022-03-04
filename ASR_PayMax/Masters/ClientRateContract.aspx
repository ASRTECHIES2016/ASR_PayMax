<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="ClientRateContract.aspx.cs" Inherits="ASR_PayMax.Masters.ClientRateContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Client Rate Contract Master</li>
        </ol>
    </section>--%>
    <style type="text/css">
        table.dataTable.nowrap td {
            white-space: nowrap;
            padding: 4px;
        }
    </style>
    <div class="card">
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Client Rate Contract Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Client"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" CssClass="form-control RoundText"></asp:DropDownList>
                                                <input id="hddClientRateID" type="hidden" runat="server" value="0" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Designation"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Month Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Year Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Duty Type"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlDuty" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Type"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlType" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" runat="server" CssClass="form-control RoundText">
                                                    <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                                    <asp:ListItem Value="SalaryType">Salary</asp:ListItem>
                                                    <asp:ListItem Value="BillingType">Billing</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="row">&nbsp;</div>
                            <asp:Panel ID="pnl" runat="server" Visible="true" CssClass="row col-sm-11">
                                <div class="col-sm-6">
                                    <label class="control-label" runat="server">Un Assign Site Name &nbsp;</label>
                                    <asp:ListBox ID="ddlAllSite" CssClass="form-control" SelectionMode="Multiple" runat="server" Height="130"></asp:ListBox>
                                </div>
                                <div class="col-sm-1">
                                    <br />
                                    <button type="button" runat="server" class="btn btn-sm btn-primary  btn-block mb-1" id="Button1" onserverclick="Button1_Click"><i class="fa fa-angle-right"></i></button>
                                    <button type="button" runat="server" class="btn btn-sm btn-primary btn-block mb-1" id="Button2" onserverclick="Button2_Click"><i class="fa fa-angle-left"></i></button>
                                    <button type="button" runat="server" class="btn btn-sm btn-primary btn-block mb-1" id="Button3" onserverclick="Button3_Click"><i class="fa fa-angle-double-right"></i></button>
                                    <button type="button" runat="server" class="btn btn-sm btn-primary btn-block mb-1" id="Button4" onserverclick="Button4_Click"><i class="fa fa-angle-double-left"></i></button>
                                </div>
                                <div class="col-sm-5">
                                    <label class="control-label" runat="server">Assign Site Name</label>
                                    <asp:ListBox ID="ddlSelectedSite" CssClass="form-control" SelectionMode="Multiple" runat="server" Height="130"></asp:ListBox>
                                </div>
                            </asp:Panel>

                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlSalary" runat="server" Visible="true">
                                        <div class="row table-responsive">
                                            <asp:GridView ID="GridSalaryRateDetails" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                                <Columns>
                                                    <%-- <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                               --%>
                                                    <asp:TemplateField HeaderText="Head ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSalaryHeadID" Text='<%# Eval("SalaryHeadMasterID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Head Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSalaryHeadName" Text='<%# Eval("SalaryHeadName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Head Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSalaryHeadCode" Text='<%# Eval("SalaryHeadCode") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Computation">
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlSalaryComputation" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlSalaryComputation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSalaryComputation_SelectedIndexChanged" CssClass="GridDropDownControl RoundText">
                                                                        <asp:ListItem Value="Pro-Rated" Selected="True">Pro-Rated</asp:ListItem>
                                                                        <asp:ListItem Value="Formula">Formula</asp:ListItem>
                                                                        <asp:ListItem Value="Fixed Value">Fixed Value</asp:ListItem>
                                                                        <asp:ListItem Value="Fixed_Parameter">Fixed-Parameter</asp:ListItem>
                                                                        <asp:ListItem Value="Slab Rate">Slab Rate</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Percentage">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtSalaryPercentage" Name="txtSalaryPercentage" CssClass="GridFormControl RoundText"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Formula">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtSalaryFormula" ClientIDMode="Static" CssClass="GridFormControl RoundText"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtSalaryAmount" CssClass="GridFormControl RoundText"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Monthly / Yearly">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlSalaryMonthlyOrYearly" runat="server" CssClass="GridDropDownControl RoundText">
                                                                <asp:ListItem Value="Monthly" Selected="True">Monthly</asp:ListItem>
                                                                <asp:ListItem Value="Yearly">Yearly</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Min Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtSalaryMinAmount" CssClass="GridFormControl RoundText"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Max Amount">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtSalaryMaxAmount" CssClass="GridFormControl RoundText"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkDeleted" runat="server" CommandName="Deleted" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-danger btn-sm"><span class='fa fa-trash'></span></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="row">&nbsp;&nbsp;</div>
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <asp:Label CssClass="lblText" runat="server" Text="OT Type"></asp:Label>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Always">
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlOTType" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlOTType" AutoPostBack="true" OnSelectedIndexChanged="ddlOTType_SelectedIndexChanged" runat="server" CssClass="form-control RoundText">
                                                                <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                                                <asp:ListItem Value="On Amount">On Amount</asp:ListItem>
                                                                <asp:ListItem Value="Fixed Parameter">Fixed Parameter</asp:ListItem>
                                                                <asp:ListItem Value="Formula">Formula</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <div class="col-sm-1">
                                                <div class="form-group">
                                                    <asp:Label CssClass="lblText" runat="server" Text="Rate"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtOTMinAmount" CssClass="form-control RoundText"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label CssClass="lblText" runat="server" Text=" X "></asp:Label>
                                                <asp:TextBox runat="server" ID="txtOTSalaryValue" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label CssClass="lblText" runat="server" Text="Formula"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtOTFormula" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-2">
                                                <br />
                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Always">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlOTSalary" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlOTSalary" OnSelectedIndexChanged="ddlOTSalary_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="form-control RoundText">
                                                            <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                                            <asp:ListItem Value="Total Month Days"> Total Month Days</asp:ListItem>
                                                            <asp:ListItem Value="Total Working Days">Total Working Days</asp:ListItem>
                                                            <asp:ListItem Value="Per Day">Per Day</asp:ListItem>
                                                            <asp:ListItem Value="Fixed Days">Fixed Days</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label CssClass="lblText" runat="server" Text="Days"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtOTSalaryDays" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <asp:Label CssClass="lblText" runat="server" Text="Special OT Type"></asp:Label>
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Always">
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlSpeacialOTType" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlSpeacialOTType" AutoPostBack="true" OnSelectedIndexChanged="ddlSpeacialOTType_SelectedIndexChanged" runat="server" CssClass="form-control RoundText">
                                                                <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                                                <asp:ListItem Value="On Amount">On Amount</asp:ListItem>
                                                                <asp:ListItem Value="Fixed Parameter">Fixed Parameter</asp:ListItem>
                                                                <asp:ListItem Value="Formula">Formula</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <%--   <div class="col-sm-1">
                                                <div class="form-group">
                                                    <asp:Label CssClass="lblText" runat="server" Text="OT Rate"></asp:Label>

                                                    <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control RoundText"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-1">
                                                <br />
                                                <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control  RoundText"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <br />
                                                <asp:TextBox runat="server" ID="TextBox6" CssClass="form-control  RoundText"></asp:TextBox>
                                            </div>--%>
                                            <div class="col-sm-1">
                                                <div class="form-group">
                                                    <asp:Label CssClass="lblText" runat="server" Text="Rate"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtSpOTMinAmount" CssClass="form-control RoundText"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label CssClass="lblText" runat="server" Text=" X "></asp:Label>
                                                <asp:TextBox runat="server" ID="txtSpOTSalaryValue" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label CssClass="lblText" runat="server" Text="Formula"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtSpOTFormula" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-2">

                                                <br />
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Always">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlSpOT" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlSpOT" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSpOT_SelectedIndexChanged" CssClass="form-control  RoundText">
                                                            <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                                            <asp:ListItem Value="Total Month Days"> Total Month Days</asp:ListItem>
                                                            <asp:ListItem Value="Total Working Days">Total Working Days</asp:ListItem>
                                                            <asp:ListItem Value="Per Day">Per Day</asp:ListItem>
                                                            <asp:ListItem Value="Fixed Days">Fixed Days</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label CssClass="lblText" runat="server" Text="Days"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtSpOTDays" CssClass="form-control  RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3">
                                                <div class="form-group">
                                                    <asp:Label CssClass="lblText" runat="server" Text="Week Off Type"></asp:Label>
                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Always">
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlWeekOffType" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlWeekOffType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWeekOffType_SelectedIndexChanged" CssClass="form-control RoundText">
                                                                <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                                                <asp:ListItem Value="On Amount">On Amount</asp:ListItem>
                                                                <asp:ListItem Value="Fixed Parameter">Fixed Parameter</asp:ListItem>
                                                                <asp:ListItem Value="Formula">Formula</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <%--<div class="col-sm-1">
                                                <div class="form-group">
                                                    <asp:Label CssClass="lblText" runat="server" Text="Wk Off"></asp:Label>
                                                    <asp:TextBox runat="server" ID="TextBox8" CssClass="form-control RoundText"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-1">
                                                <br />
                                                <asp:TextBox runat="server" ID="TextBox9" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <br />
                                                <asp:TextBox runat="server" ID="TextBox10" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>--%>
                                            <div class="col-sm-1">
                                                <div class="form-group">
                                                    <asp:Label CssClass="lblText" runat="server" Text="Rate"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtWkOTMinAmount" CssClass="form-control RoundText"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label CssClass="lblText" runat="server" Text=" X "></asp:Label>
                                                <asp:TextBox runat="server" ID="txtWkOTSalaryValue" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label CssClass="lblText" runat="server" Text="Formula"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtWkOTFormula" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-2">

                                                <br />
                                                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Always">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlWKOff" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlWKOff" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWKOff_SelectedIndexChanged" CssClass="form-control RoundText">
                                                            <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                                            <asp:ListItem Value="Total Month Days"> Total Month Days</asp:ListItem>
                                                            <asp:ListItem Value="Total Working Days">Total Working Days</asp:ListItem>
                                                            <asp:ListItem Value="Per Day">Per Day</asp:ListItem>
                                                            <asp:ListItem Value="Fixed Days">Fixed Days</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="col-sm-1">
                                                <asp:Label CssClass="lblText" runat="server" Text="Days"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtWkOff" CssClass="form-control  RoundText"></asp:TextBox>
                                            </div>

                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlBilling" runat="server" Visible="false">
                                        <div class="row table-responsive">
                                            <asp:GridView ID="GridBillingRateDetails" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Str_DesignationID ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control RoundText"></asp:TextBox>
                                                            <%--<asp:Label ID="lblDesignationID" Text='<%# Eval("DesignationMasterID") %>' runat="server" />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DesignationGroupID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control RoundText"></asp:TextBox>
                                                            <%--<asp:Label ID="lblDesignationGroupID" Text='<%# Eval("DesignationGroupMasterID") %>' runat="server" />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DesignationCategoryTypeID ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control RoundText"></asp:TextBox>
                                                            <%--<asp:Label ID="lblDesignationCategoryTypeID" runat="server" Text='<%# Eval("DesignationCategoryMasterID") %>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation Name">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control RoundText"></asp:TextBox>
                                                            <%--<asp:Label ID="lblDesignationName" runat="server" Text='<%# Eval("DesignationName") %>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation Group">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control RoundText"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation Category">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control RoundText"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lkEdit" runat="server" CommandName="Change" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-info btn-sm"><span class='fa fa-edit'></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lkDeleted" runat="server" CommandName="Deleted" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-danger btn-sm"><span class='fa fa-trash'></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Panel ID="pnlButton" runat="server" CssClass="row">
                                <div class="col-sm-5">
                                    <asp:Button ID="Btn_Submit" runat="server" OnClick="Btn_Submit_Click" Text="Submit" CssClass="btn btn-primary" />
                                    &nbsp;
                                <asp:Button ID="Btn_Cancel" OnClick="Btn_Cancel_Click" runat="server" Text="Reset" CssClass="btn btn-danger" />
                                </div>
                                <div class="col-sm-6 float-right">
                                    <div class="container row">
                                        <asp:Label CssClass="lblText col-sm-4" runat="server" Text="Gross Amount"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtGrossAmount" ReadOnly="true" CssClass="form-control RoundText col-sm-8"></asp:TextBox>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">  
        $(function () { Calculation(); Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () { Calculation(); }); });

        function Calculation() {
            $('[id*=txtSalaryAmount]').change(function () {
                var Len = 0, Value = 0, Grid = $('#<%=GridSalaryRateDetails.ClientID%>');
                Len = Grid.find('tr').length;
                if (Len > 0) {
                    for (var i = 0; i < Len; i++) {
                       

                        Value = Grid.find('tr:eq(' + i + ')').find('td:eq(5)').find('txtSalaryAmount').val();
                        //alert(Value);
                    }
                }
                $('#<%=txtGrossAmount.ClientID%>').Value = Value;
            });
            //$('#txtSalaryFormula').keydown(function (event) {
            //   
            //    var key = event.keyCode;
            //    if (key === 27) {
            //        $("#ModalFormula").modal();
            //    }

            //});
        }
    </script>


<%--    <div id="ModalFormula" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Formula</h4>
                </div>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                       
                        <ContentTemplate>
                            <asp:Button ID="Button5" runat="server" OnClick="Btn_Submit_Click" Text="Close" CssClass="btn btn-secondary" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

        </div>
    </div>--%>
</asp:Content>
