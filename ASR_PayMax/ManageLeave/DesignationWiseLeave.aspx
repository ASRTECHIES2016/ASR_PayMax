<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="DesignationWiseLeave.aspx.cs" Inherits="ASR_PayMax.ManageLeave.DesignationWiseLeave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content><asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Designation Wise Policy</li>
        </ol>
    </section>--%>

    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Designation Wise Leave</h3>
        </div>
        <div class="card-body">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="container row">
                     
                        <div class="col-sm-8">
                            <asp:Label CssClass="lblText" runat="server" Text="Details"></asp:Label>
                            <asp:GridView ID="GridLateMark"  runat="server" EmptyDataText="No Data Available" RowStyle-CssClass="text-center" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No. " HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlAction" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="Full" Selected="True">Select One</asp:ListItem>
                                                <asp:ListItem Value="Full">Full Day</asp:ListItem>
                                                <asp:ListItem Value="Half">Half Day</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hours" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtHours" Text="1" runat="server" CssClass="form-control OnlyNum text-right" MaxLength="2"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Minutes" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMinute" Text="1" runat="server" CssClass="form-control OnlyNum text-right" MaxLength="2"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Max. Late Mark" HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTotalCount" Text="1" runat="server" CssClass="form-control OnlyNum  text-right" MaxLength="2"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">&nbsp;</div>
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" />
                        </div>
                    </asp:Panel>
                    <hr />

                    <div class="table-responsive">
                        <asp:GridView ID="GridLeavePolicy" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" RowStyle-CssClass="text-center" Width="100%"
                            CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed"
                            CellSpacing="0" OnRowCommand="GridLeavePolicy_RowCommand">

                            <Columns>
                                <asp:TemplateField HeaderText="Sr No. " HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Policy Name" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("LateMarkPolicyName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Group Name" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGroupName" runat="server" Text='<%# Eval("WeeklyOffGroupName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="From Date" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFromDate" runat="server" Text='<%# Eval("FromDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="temp" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lkEdit" EventName="Click" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lkEdit" runat="server" CommandName="Change" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-info btn-sm"
                                                    Text=""><span class='glyphicon glyphicon-edit'></span></asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
           
            GridMasters('<%=GridLeavePolicy.ClientID%>', '', '', '', '', '', '', '', '', '');
        }
    </script>
</asp:Content>
