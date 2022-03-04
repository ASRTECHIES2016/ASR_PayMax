<%@ Page Title="Qualification" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="Qualifications.aspx.cs" Inherits="ASR_PayMax.Masters.Qualifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Qualification Master</li>
        </ol>
    </section>--%>

    <div class="card">
        <div class="card-body">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">&nbsp;&nbsp;Qualification Details</h3>
                </div>
                <div class="card-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Qualification"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtQualification"></asp:TextBox>
                                        <input id="hddQualID" type="hidden" runat="server" value="0" />
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
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridQualification" EventName="RowCommand" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:GridView ID="GridQualification" OnRowCommand="GridQualification_RowCommand" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%"
                                        CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="QualificationMasterID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQualificationMasterID" Text='<%# Eval("QualificationMasterID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualification Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQualificationName" runat="server" Text='<%# Eval("QualificationName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Active">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="IsActive" EventName="CheckedChanged" />
                                                        </Triggers>
                                                        <ContentTemplate>
                                                            <asp:CheckBox ID="IsActive" runat="server" Checked='<%# Eval("Active") %>' AutoPostBack="true" CssClass="custom-checkbox" OnCheckedChanged="IsActive_CheckedChanged" />
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
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

            GridMasters('<%=GridQualification.ClientID%>', '', '', '', '', '', '', '', '', '');
        }
    </script>
</asp:Content>
