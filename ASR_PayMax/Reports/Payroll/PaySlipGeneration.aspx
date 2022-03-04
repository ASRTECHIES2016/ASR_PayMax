<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="PaySlipGeneration.aspx.cs" Inherits="ASR_PayMax.Reports.Payroll.PaySlipGeneration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Pay Slip</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Employee Pay Slip</h3>
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Search" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="ddlSite" EventName="SelectedIndexChanged" />
                </Triggers>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText">
                                </asp:DropDownList>
                                <input id="hddEmployeeID" type="hidden" runat="server" value="0" />
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Month"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control RoundText">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Year"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control RoundText">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Client Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlClient" runat="server" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Site Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlSite" runat="server" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-2">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Pay Slip Type"></asp:Label>
                                <asp:DropDownList ID="ddlPaySlip" runat="server" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--  <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Employee Name"></asp:Label>
                                <asp:TextBox runat="server" ID="txtEmployeeName" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>--%>

                        <div class="col-sm-2">
                            <div class="form-group">
                                <asp:Panel ID="pnlButtons" runat="server">
                                    <asp:Button ID="Btn_Search" Style="margin-top: 23px" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="Btn_Search_Click" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="Btn_Cancel" Style="margin-top: 23px" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="table-responsive">
                        <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:GridView ID="GridMonthAttendance" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%"
                                    CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr#" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
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
</asp:Content>
