<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="PaysheetGenerate.aspx.cs" Inherits="ASR_PayMax.Transactions.PaysheetGenerate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Salary Generation</li>
        </ol>
    </section>--%>

    <div class="card">
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <%-- <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Fetch" EventName="Click" />                    
                    <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddlSite" EventName="SelectedIndexChanged" />
                </Triggers>--%>
                <ContentTemplate>
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Generate Salary</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Month Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Year"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Client"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Site"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlSite" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Button ID="Btn_Fetch" runat="server" Text="Fetch" Style="margin-top: 23px" CssClass="btn btn-primary" OnClick="Btn_Fetch_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" Style="margin-top: 23px" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="Btn_Submit" runat="server" Text="Submit" Style="margin-top: 23px" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                                       
                                    </div>
                                </div>
                            </div>
                            <hr />

                            <asp:GridView ID="GridSiteMaster" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%"
                                CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="SiteID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSiteID" Text='<%# Eval("SiteID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ClientID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientID" Text='<%# Eval("ClientID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BranchID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchID" Text='<%# Eval("BranchID") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Site Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSiteCode" runat="server" Text='<%# Eval("SiteCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Site Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSiteName" runat="server" Text='<%# Eval("SiteName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Client Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientName" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BranchName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ActiveAll" runat="server" Checked="false" onclick="CheckedAll()" CssClass="custom-checkbox" />
                                            Select All </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="IsActive" runat="server" Checked="false" CssClass="custom-checkbox" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
                        //GridPageLength('<%=GridSiteMaster.ClientID%>', '', '', '', '', '', '', '', '', '',200,false);

        }
        function CheckedAll() {
            if ($('[id*="ActiveAll"]').is(':checked')) {
                $('[id*="IsActive"]').prop('checked', true);
            }
            else {
                $('[id*="IsActive"]').prop('checked', false);
            }
        }
    </script>
</asp:Content>
