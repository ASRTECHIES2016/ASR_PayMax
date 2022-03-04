<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeBankDetails.aspx.cs" Inherits="ASR_PayMax.Registrations.EmployeeBankDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Employee Bank Details</li>
        </ol>
    </section>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">&nbsp;&nbsp;Employee Details</h3>
                                </div>

                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-sm-10">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                                <input id="hddEmployeeID" type="hidden" runat="server" value="0" class="hide" />
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-10">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Employee Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                                <asp:TextBox runat="server" ID="txtEmployeeName" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-10">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Payment Mode"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                                <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-sm-10">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Ref No. "></asp:Label><br />
                                                <asp:TextBox runat="server" ID="txtRefNo" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">&nbsp;&nbsp;Bank Details</h3>
                                </div>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-sm-10">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Bank Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                                <asp:DropDownList ID="ddlBankName" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-10">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Bank Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                                <asp:DropDownList ID="ddlBankBranch" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-10">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="IFSC Code"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                                <asp:TextBox runat="server" ID="txtIFSC_Code" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-sm-10">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Account No. "></asp:Label><br />
                                                <asp:TextBox runat="server" ID="txtAccountNo" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                            <div class="col-sm-10">
                                <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" />
                                &nbsp;&nbsp;
                                <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
