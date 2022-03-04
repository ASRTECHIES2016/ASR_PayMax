<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="LeaveApproval.aspx.cs" Inherits="ASR_PayMax.ManageLeave.LeaveApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Leave Approval</li>
        </ol>
    </section>--%>

    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Leave Approval Status</h3>
        </div>
        <div class="card-body">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <label class="col-sm-2 col-form-label text-right">Select Type:&nbsp;&nbsp;<span class="star">*</span></label>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                                <asp:ListItem Text="All" Value=""></asp:ListItem>
                                <asp:ListItem Text="Pending" Value="Pending" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                <asp:ListItem Text="Rejected" Value="Rejected"></asp:ListItem>
                                <asp:ListItem Text="Revoked" Value="Revoked"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-sm-2 col-form-label text-right">Search Employee:&nbsp;&nbsp;<span class="star">*</span></label>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control RoundText"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <hr />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="table-responsive">
                        <asp:GridView ID="GridLeaveApproval" OnRowCommand="GridLeaveApproval_RowCommand" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" RowStyle-CssClass="text-center">

                            <Columns>
                                <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="text-center" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Tr_EmpLeaveDetailsID" HeaderText="LeaveID" Visible="false" />

                                <asp:TemplateField HeaderText="Employee Code" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpCode" Text='<%# Eval("EmpCode") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpName" runat="server" Text='<%# Eval("EmpFullName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Start" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStart" runat="server" Text='<%# Eval("LeaveStartDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="End" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEnd" runat="server" Text='<%# Eval("LeaveEndDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>




                                <asp:BoundField DataField="Reason" HeaderText="Reason" HeaderStyle-CssClass="text-center" />

                                <asp:TemplateField HeaderText=" Remark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Approve" Visible="false" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>

                                        <asp:LinkButton ID="btnApprove" Text="<span class='glyphicon glyphicon-ok'></span>" CssClass="btn btn-info btn-sm" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Reject" Visible="false" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="temp" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lkbtnReject" EventName="Click" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lkbtnReject" Text="<span class='glyphicon glyphicon-remove'></span>" CommandName="Reject" CssClass="btn btn-danger" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                    ClientIDMode="Static" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Revoke" Visible="false" HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="temp1" UpdateMode="Always">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lkbtnRevoke" EventName="Click" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lkbtnRevoke" Text="<span class='glyphicon glyphicon-share-alt'></span>" CommandName="Revoke" CssClass="btn btn-primary" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:ButtonField Text="<span class='glyphicon glyphicon-remove'></span>" ControlStyle-CssClass="btn btn-danger" CommandName="Reject" ItemStyle-Width="150" HeaderText="Reject" />--%>
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

            GridMasters('<%=GridLeaveApproval.ClientID%>', '', '', '', '', '', '', '', '', '');
        }
    </script>
</asp:Content>


