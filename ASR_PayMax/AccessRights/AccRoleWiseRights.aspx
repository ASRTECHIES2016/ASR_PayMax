<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="AccRoleWiseRights.aspx.cs" Inherits="ASR_PayMax.AccessRights.AccRoleWiseRights" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--   <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Role Master</li>
        </ol>
    </section>
    <link href="/Content/hummingbird-treeview.css" rel="stylesheet" />
    <script src="/Scripts/hummingbird-treeview.js"></script>--%>
    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Role Right's</h3>
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Role Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlRoleName" runat="server" CssClass="form-control RoundText">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Menu Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlMenuMaster" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlMenuMaster" AutoPostBack="true" OnSelectedIndexChanged="ddlMenuMaster_SelectedIndexChanged" runat="server" CssClass="form-control RoundText">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <asp:Panel ID="pnlButtons" runat="server" CssClass="col-sm-4">
                            <div class="col-sm-10">
                                <asp:Button ID="Btn_Submit" Style="margin-top: 23px;" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="Btn_Cancel" Style="margin-top: 23px;" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="row">
                        &nbsp;
                    </div>

                    <div class="row table-responsive">
                        <asp:GridView ID="GridAccessRole" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0">
                            <Columns>
                                <asp:TemplateField HeaderText="PID ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPID" Text='<%# Eval("MenuID") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Menu Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblP_Name" runat="server" Text='<%# Eval("MenuName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="All">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Add">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkAdd" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkEdit" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkView" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDelete" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Print">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkPrint" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkEmail" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="In Excel">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkInExcel" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="In Pdf">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkInPdf" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="row">
                        &nbsp;
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
         //  
         //   GridMasters('<%=GridAccessRole.ClientID%>', '', '', '', '', '', '', '', '', '');
            $("[id*=chkAll]").click(function () {
                var chkHeader = $(this);
                var grid = $(this).closest("tr");
                $("input[type=checkbox]", grid).each(function () {
                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        $("td", grid);
                    } else {
                         $(this).attr("checked", false);
                        $("td", grid);
                    }
                });
            });
        }
    </script>
</asp:Content>
