<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="IndustrySegment.aspx.cs" Inherits="ASR_PayMax.Masters.IndustrySegment1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Industry Segment Master</li>
        </ol>
    </section>--%>

    <div class="card">
        <div class="card-body">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">&nbsp;&nbsp;Industry Segment Details</h3>
                </div>
                <div class="card-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Industry Segment Code"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtIndustrySegmentCode"></asp:TextBox>
                                        <input id="hddIndustryID" type="hidden" runat="server" value="0" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Industry Segment Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtIndustrySegment"></asp:TextBox>
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
                            <asp:GridView ID="GridIndustry" OnRowCommand="GridIndustry_RowCommand" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%"
                                CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IndustryID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIndustryID" Text='<%# Eval("IndustrySegmentID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Industry Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIndustryCode" runat="server" Text='<%# Eval("IndustrySegmentCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                                    <asp:TemplateField HeaderText="Industry Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIndustrySegmentName" runat="server" Text='<%# Eval("IndustrySegmentName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active">
                                        <ItemTemplate>
                                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="IsActive" EventName="CheckedChanged" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:CheckBox ID="IsActive" runat="server" Checked='<%# Eval("Active") %>'   AutoPostBack="true" OnCheckedChanged="IsActive_CheckedChanged" CssClass="custom-checkbox" />
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
    <script type="text/javascript">
        $(function () {
            auto();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                auto();
            });
        });
        function auto() {
           
            GridMasters('<%=GridIndustry.ClientID%>', '', '', '', '', '', '', '', '', '');
        }
    </script>
</asp:Content>
