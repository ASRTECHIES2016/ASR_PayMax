<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="SiteManpower.aspx.cs" Inherits="ASR_PayMax.Masters.SiteManpower" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Site Manpower Master</li>
        </ol>
    </section>--%>

    <div class="card">
        <div class="card-body">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">&nbsp;&nbsp;Site Manpower Details</h3>
                </div>
                <div class="card-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="GridSiteManPower" EventName="RowCommand" />
                        </Triggers>
                        <ContentTemplate>

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                        <input id="hddSiteManPowerID" type="hidden" runat="server" value="0" />
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Client Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" CssClass="form-control RoundText"></asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
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

                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Designation"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Duty"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlDuty" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="No. Of Employee"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtNoOfEmployee" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="RadioSalary" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txtSalary" EventName="TextChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="row">
                                        <asp:Label CssClass="lblText col-sm-3" runat="server"><b>Salary Calculation&nbsp;:-</b>
                                        </asp:Label>
                                        <div class="col-sm-7">
                                            <asp:RadioButtonList ID="RadioSalary" AutoPostBack="true" OnSelectedIndexChanged="RadioSalary_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Value="Total Month Days" Selected="True"> &nbsp;&nbsp;Total Month Days&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="Total Working Days">&nbsp;Total Working Days&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="Per Day">&nbsp;Per Day&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="Fixed Days">&nbsp;Fixed Days&nbsp;</asp:ListItem>
                                                <%--<asp:ListItem Value="Month Days">&nbsp;Month Days</asp:ListItem>--%>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:TextBox runat="server" ID="txtSalary" CssClass="form-control RoundText" AutoPostBack="true" OnTextChanged="txtSalary_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="row">&nbsp;</div>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always" >
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="RadioBilling" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="txtBilling" EventName="TextChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="row">
                                        <asp:Label CssClass="lblText col-sm-3" runat="server"><b>Billing Calculation&nbsp;:-</b>
                                        </asp:Label>
                                        <div class="col-sm-7">
                                            <asp:RadioButtonList ID="RadioBilling" AutoPostBack="true" OnSelectedIndexChanged="RadioBilling_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Value="Total Month Days" Selected="True"> &nbsp;&nbsp;Total Month Days&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="Total Working Days">&nbsp;Total Working Days&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="Per Day">&nbsp;Per Day&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="Fixed Days">&nbsp;Fixed Days&nbsp;</asp:ListItem>
                                                <%--<asp:ListItem Value="Month Days">&nbsp;Month Days</asp:ListItem>--%>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:TextBox runat="server" ID="txtBilling" TextMode="Number"  MaxLength="2" AutoPostBack="true" OnTextChanged="txtBilling_TextChanged"   CssClass="form-control RoundText"></asp:TextBox>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                                <div class="col-sm-10">
                                    <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                                </div>
                            </asp:Panel>
                            <hr />
                            <asp:GridView ID="GridSiteManPower" OnRowCommand="GridSiteManPower_RowCommand" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="DocumentID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Text='<%# Eval("ID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DocumentID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchID" Text='<%# Eval("BranchID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ClientGroupMasterID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientGroupMasterID" Text='<%# Eval("ClientID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SiteMasterID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSiteMasterID" Text='<%# Eval("SiteID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DesignationMasterId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignationMasterId" Text='<%# Eval("DesignationMasterId") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Client Group">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientGroupName" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Site Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSite" runat="server" Text='<%# Eval("Site") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active">
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel123" runat="server">
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
                            </asp:GridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
