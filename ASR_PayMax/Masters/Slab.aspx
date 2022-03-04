<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="Slab.aspx.cs" Inherits="ASR_PayMax.Masters.Slab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Slab Master</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Slab Details</h3>
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="State Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control RoundText">
                                    <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                    <asp:ListItem Value="1">MAH</asp:ListItem>
                                    <asp:ListItem Value="2">UP</asp:ListItem>
                                </asp:DropDownList>
                                <input id="hddSlabID" type="hidden" runat="server" value="0" class="hide" />
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Salary Head Type"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlSalaryHead" runat="server" CssClass="form-control RoundText">
                                    <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Amount From"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:TextBox runat="server" ID="txtAmountFrom" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Amount To"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:TextBox runat="server" ID="txtAmountTo" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Period From"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:TextBox runat="server" ID="txtPeriodFrom" CssClass="form-control RoundText Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Period To"></asp:Label>
                                <asp:TextBox runat="server" ID="txtPeriodTo" CssClass="form-control RoundText Date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    </div><div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Value"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:TextBox runat="server" ID="txtValue" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Gender"></asp:Label>
                                <asp:RadioButtonList ID="RadioGender" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Value="Male" Selected="True"> &nbsp;&nbsp;Male&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="Female">&nbsp;Female&nbsp;</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Remarks"></asp:Label>
                                <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                        </div>
                    </asp:Panel>
                    <hr />
                    <div class="table-responsive">

                        <asp:UpdatePanel ID="UpdatePanel123" runat="server" UpdateMode="Always">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridSlab" EventName="RowCommand" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:GridView ID="GridSlab" OnRowCommand="GridSlab_RowCommand" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalaryHeadSlabMasterId" Text='<%# Eval("SalaryHeadSlabMasterId") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StateID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStateID" Text='<%# Eval("StateID") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Salary Head Code" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalaryHeadCode" runat="server" Text='<%# Eval("SalaryHeadCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="State">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStateName" runat="server" Text='<%# Eval("StateName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Head Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalaryHeadName" runat="server" Text='<%# Eval("SalaryHeadName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSlabFrom" runat="server" Text='<%# Eval("SlabFrom") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSlabTo" runat="server" Text='<%# Eval("SlabTo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Value">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue" runat="server" Text='<%# Eval("Value") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFromDate" runat="server" Text='<%# Eval("FromDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblToDate" runat="server" Text='<%# Eval("ToDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gender">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remark">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDetails" runat="server" Text='<%# Eval("Details") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Active">
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="IsActive" EventName="CheckedChanged" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:CheckBox ID="IsActive" runat="server" Checked='<%# Eval("Active") %>' OnCheckedChanged="IsActive_CheckedChanged" AutoPostBack="true" CssClass="custom-checkbox" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            auto();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                auto();
            });
        });
        function auto() {

           // GridMasters('<%=GridSlab.ClientID%>', '', '', '', '', '', '', '', '', '');
        }
    </script>
</asp:Content>
