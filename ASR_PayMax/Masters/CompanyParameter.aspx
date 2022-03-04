<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="CompanyParameter.aspx.cs" Inherits="ASR_PayMax.Masters.CompanyParameter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Company Parameter</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Company Parameter Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Retirement Age"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtRetirementAge" CssClass="form-control RoundText"></asp:TextBox>
                                             <input id="hddParameterID" type="hidden" runat="server" value="0" />
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Gratuity Amount"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtGratuityAmount" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Gratuity Age"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtGratuityAge" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Work Age"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtWorkAge" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Admin Charges"></asp:Label><br />
                                        <asp:TextBox runat="server" ID="txtAdminCharges" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Pre Joining Date"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtJoining" CssClass="form-control RoundText Date"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="PF Deduction Rule"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtDeductionRule" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Deduction Round Off"></asp:Label><br />
                                        <asp:CheckBox ID="chkDeductionRoundOff" runat="server" />
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Earning Round Off"></asp:Label><br />
                                        <asp:CheckBox ID="chkEarningRoundOff" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Employee Multiple Instalment"></asp:Label><br />
                                        <asp:CheckBox ID="chkMultipleInstalment_E_E" runat="server" />
                                        &nbsp;&nbsp; (E)
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Staff Multiple Instalment"></asp:Label><br />
                                        <asp:CheckBox ID="chkMultipleInstalment_E_S" runat="server" />
                                        &nbsp;&nbsp; (E)
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Employee Multiple Instalment"></asp:Label><br />
                                        <asp:CheckBox ID="chkMultipleInstalment_D_E" runat="server" />
                                        &nbsp;&nbsp; (D)
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Staff Multiple Instalment"></asp:Label><br />
                                        <asp:CheckBox ID="chkMultipleInstalment_D_S" runat="server" />
                                        &nbsp;&nbsp; (D)
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
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

