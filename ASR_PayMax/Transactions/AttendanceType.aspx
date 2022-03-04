<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="AttendanceType.aspx.cs" Inherits="ASR_PayMax.Transactions.AttendanceType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<link type="text/css" rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.10/css/select2.css" />
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/select2@4.0.12/dist/js/select2.min.js"></script>--%>
   <%-- <link href="../Content/select2.css" rel="stylesheet" />
    <script src="../Scripts/select2.js"></script>--%>
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Open  /  Close  Attendance</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Open / Close  Attendance Details</h3>
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <%--   <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>--%>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlHeadGroup" runat="server" CssClass="form-control RoundText ddlClass">
                                    <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Client Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control RoundText">
                                    <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Month"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control RoundText">
                                    <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Year"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control RoundText">
                                    <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                    <asp:ListItem Value="Earning">Earning</asp:ListItem>
                                    <asp:ListItem Value="Deduction">Deduction</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" />
                        </div>
                    </asp:Panel>
                    <hr />
                    <asp:GridView ID="GridMonthAttendance" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%"
                        CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--    <asp:TemplateField HeaderText="Str_DesignationID ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationID" Text='<%# Eval("Str_DesignationID") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DesignationGroupID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationGroupID" Text='<%# Eval("Str_DesignationGroupID") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DesignationCategoryTypeID ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationCategoryTypeID" runat="server" Text='<%# Eval("Str_DesignationCategoryTypeID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationName" runat="server" Text='<%# Eval("Str_DesignationName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation Group">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationGroupName" runat="server" Text='<%# Eval("Str_DesignationGroupName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation Category">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationCategoryType" runat="server" Text='<%# Eval("Str_DesignationCategoryTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:CheckBox ID="IsActive" runat="server"  />
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
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                    <script type="text/javascript">
                        $(function () {
                            auto();
                            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                                auto();
                            });
                        });
                        function auto() {
                            //$('.ddlClass').select2({
                            //    selectOnClose: true
                            //});
                            GridMasters('<%=GridMonthAttendance.ClientID%>', '', '', '', '', '', '', '', '', '');
                        }
                    </script>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
