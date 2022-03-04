<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="Zone.aspx.cs" Inherits="ASR_PayMax.Masters.Zone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Zone Master</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Zone Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Zone Code"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtZoneCode" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Zone Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtZoneName" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Region Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                        <input id="hddZoneID" type="hidden" runat="server" value="0" />
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
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="GridZone" EventName="RowCommand" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:GridView ID="GridZone" runat="server" EmptyDataText="No Data Available" OnRowCommand="GridZone_RowCommand" AutoGenerateColumns="false" Width="100%"
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
                                            <asp:TemplateField HeaderText="RegionID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRegionID" runat="server" Text='<%# Eval("RegionID") %>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="Region Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRegionCode" runat="server" Text='<%# Eval("RegionCode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Region Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRegionName" runat="server" Text='<%# Eval("RegionName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Active">
                                                <ItemTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
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

            GridMasters('<%=GridZone.ClientID%>', '', '', '', '', '', '', '', '', '');
        }
    </script>
</asp:Content>
