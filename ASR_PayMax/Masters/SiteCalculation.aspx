<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="SiteCalculation.aspx.cs" Inherits="ASR_PayMax.Masters.SiteCalculation1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Site Calculation</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                    <%--<asp:AsyncPostBackTrigger ControlID="GridClientGroup" EventName="RowCommand" />--%>
                </Triggers>
                <ContentTemplate>
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Site Calculation Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <%--         <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Client Code"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtClientCode" CssClass="form-control RoundText"></asp:TextBox>
                                       <input id="hddClientID" type="hidden" runat="server" value="0" />  </div>
                                </div>--%>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Client"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlClient" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <input id="hddSiteCalID" type="hidden" runat="server" value="0" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <%--   <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Site Selection"></asp:Label>
                                        <asp:RadioButtonList ID="RadioSite" RepeatDirection="Horizontal" runat="server">
                                            <asp:ListItem Value="All" Selected="True"> &nbsp;&nbsp;All Site&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="Single">&nbsp;Single Site&nbsp;</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>--%>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Site Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlSite" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Extra Manpower Per Day"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtExtraManpower" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="RadioSalaryCalculation" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="row">

                                        <asp:Label CssClass="lblText col-sm-3" runat="server"><b>Salary Calculation Type : - </b></asp:Label>

                                        <div class="col-sm-3">
                                            <br />
                                            <asp:RadioButtonList ID="RadioSalaryCalculation" AutoPostBack="true" OnSelectedIndexChanged="RadioSalaryCalculation_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Value="D" Selected="True"> &nbsp;&nbsp;Date Wise&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="M">&nbsp;Month Wise&nbsp;</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="From"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control RoundText NumOnly " OnTextChanged="txtFromDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="To"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtToDate" CssClass="form-control RoundText NumOnly"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="row">
                                <asp:Label CssClass="lblText col-sm-2" runat="server"><b>Salary Calculation On : - </b></asp:Label>
                                <div class="col-sm-8">
                                    <br />
                                    <asp:RadioButtonList ID="RadioSalaryCalculationOn" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="Total Month Days" Selected="True"> &nbsp;Total Month Days&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="Total Working Days">&nbsp;Total Working Days&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="Per Days"> &nbsp;Per Days&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="Fixed Days">&nbsp;Fixed Days&nbsp;</asp:ListItem>
                                        <%--<asp:ListItem Value="Month Days"> &nbsp;Month Days&nbsp;</asp:ListItem>--%>
                                    </asp:RadioButtonList>
                                </div>

                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Value"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCalculationOn" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            </div>
                            <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                                <div class="col-sm-10">
                                    <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                                    &nbsp;&nbsp;
                                     <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                                </div>
                            </asp:Panel>
                            <%-- <hr />
                           
                            <asp:GridView ID="GridClientDetails" runat="server" EmptyDataText="No Data Available" OnRowCommand="GridClientGroup_RowCommand" AutoGenerateColumns="false" Width="100%"
                                CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ZoneMasterID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblZoneMasterID" Text='<%# Eval("ZoneMasterID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Zone Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblZoneCode" runat="server" Text='<%# Eval("ZoneCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Zone Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblZoneName" runat="server" Text='<%# Eval("ZoneName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchCode" runat="server" Text='<%# Eval("BranchCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BranchMasterID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchMasterID" runat="server" Text='<%# Eval("BranchMasterID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active">
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="IsActive" EventName="CheckedChanged" />
                                                </Triggers>
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="IsActive" runat="server" Checked='<%# Eval("Active") %>' AutoPostBack="true" OnCheckedChanged="IsActive_CheckedChanged" CssClass="custom-checkbox" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkEdit" runat="server" CommandName="Change" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-info btn-sm"><span class='fa fa-edit'></span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lkDeleted" runat="server" CommandName="Deleted" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-danger btn-sm"><span class='fa fa-trash'></span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>--%>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
