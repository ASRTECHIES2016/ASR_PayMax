<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="AllBranchMaster.aspx.cs" Inherits="ASR_PayMax.ShowAllMasterDetails.AllBranchMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">All Branch</li>
        </ol>
    </section>

    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Branch Details <a href="../Masters/Branch.aspx" class="btn btn-primary btn-sm float-right">Add Branch</a>&nbsp;&nbsp; </h3>

        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridBranchMaster" EventName="RowCommand" />
                </Triggers>
                <ContentTemplate>

                    <asp:GridView ID="GridBranchMaster" runat="server" EmptyDataText="No Data Available" OnRowCommand="GridBranchMaster_RowCommand" AutoGenerateColumns="false" Width="100%"
                        CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranchMasterID" Text='<%# Eval("BranchMasterID") %>' runat="server" />
                                    <asp:Label ID="lblCompanyID" Text='<%# Eval("CompanyID") %>' runat="server" />
                                    <asp:Label ID="lblRegionID" Text='<%# Eval("RegionID") %>' runat="server" />
                                    <asp:Label ID="lblShortCode" Text='<%# Eval("ShortCode") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkEdit" runat="server" CommandName="Change" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-info btn-sm"><span class='fa fa-edit'></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranchCode" runat="server" Text='<%# Eval("BranchCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranchStartDate" runat="server" Text='<%# Eval("BranchStartDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Contact No." ItemStyle-Wrap="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblTelephone1" runat="server" Text='<%# Eval("Telephone1") %>'></asp:Label>,
                                    <asp:Label ID="lblTelephone2" runat="server" Text='<%# Eval("Telephone2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fax">
                                <ItemTemplate>
                                    <asp:Label ID="lblFax" runat="server" Text='<%# Eval("Fax") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PF No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPF_No" runat="server" Text='<%# Eval("PF_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ESIC No">
                                <ItemTemplate>
                                    <asp:Label ID="lblESIC_No" runat="server" Text='<%# Eval("ESIC_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PT">
                                <ItemTemplate>
                                    <asp:Label ID="lblPT" runat="server" Text='<%# Eval("PT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LWF">
                                <ItemTemplate>
                                    <asp:Label ID="lblLWF" runat="server" Text='<%# Eval("LWF") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pay Pro Branch Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblPayProBranchCode" runat="server" Text='<%# Eval("PayProBranchCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pay Pro Bank Account No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPayProBankAccountNo" runat="server" Text='<%# Eval("PayProBankAccountNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Attendance Open Month">
                                <ItemTemplate>
                                    <asp:Label ID="lblAtnOpenMonth" runat="server" Text='<%# Eval("AtnOpenMonth") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Attendance Open Year">
                                <ItemTemplate>
                                    <asp:Label ID="lblAtnOpenYear" runat="server" Text='<%# Eval("AtnOpenYear") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Region Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegionName" runat="server" Text='<%# Eval("RegionName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pincode">
                                <ItemTemplate>
                                    <asp:Label ID="lblPinCode" runat="server" Text='<%# Eval("PinCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Admin Charges">
                                <ItemTemplate>
                                    <asp:CheckBox ID="IsAdminChargesApplicable" runat="server" Checked='<%# Eval("IsAdminChargesApplicable") %>' CssClass="custom-checkbox" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Address 1">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress1" runat="server" Text='<%# Eval("Address1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Address 2">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress2" runat="server" Text='<%# Eval("Address2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="IsActive" EventName="CheckedChanged" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:CheckBox ID="IsActive" runat="server" Checked='<%# Eval("Active") %>' AutoPostBack="true" CssClass="custom-checkbox" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
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
    <script type="text/javascript">
        $(function () {
            auto();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                auto();
            });
        });
        function auto() {
           
            GridMasters('<%=GridBranchMaster.ClientID%>', '', '', '', '', '', '', '', '', '');
        }
    </script>
</asp:Content>
