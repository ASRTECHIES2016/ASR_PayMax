<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="EmplyeeAdditionalDetails.aspx.cs" Inherits="ASR_PayMax.Registrations.EmplyeeAdditionalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Accounts & Licenses Master</li>
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
                            <h3 class="card-title">&nbsp;&nbsp;Accounts Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Employee Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtEmployee" CssClass="form-control RoundText"></asp:TextBox>
                                        <input id="hddEmployeeDetailID" type="hidden" runat="server" value="0" class="hide" />
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlBankName" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:Label CssClass="lblText" runat="server" Text="Bank Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                                <asp:DropDownList ID="ddlBankName" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Payment Mode"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlPaymentMode" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Bank Branch"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlBankBranch" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Account No. "></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtAccount" MaxLength="20" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Re - Account No. "></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtReAccountNo" MaxLength="20" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="IFSC Code"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtIFSCCode" CssClass="form-control RoundText" MinLength="11" MaxLength="11"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Reference No. "></asp:Label>
                                        <asp:TextBox runat="server" ID="txtReferenceNo" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Existing Member Of ESIC"></asp:Label>
                                        <asp:DropDownList ID="ddlESIC" CssClass="form-control RoundText" runat="server">
                                            <asp:ListItem Value="No" Selected="True" Text="No"></asp:ListItem>
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="ESIC No"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtESICNo" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Existing Member Of PF"></asp:Label>
                                        <asp:DropDownList ID="ddlPF" CssClass="form-control RoundText" runat="server">
                                            <asp:ListItem Value="No" Selected="True" Text="No"></asp:ListItem>
                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="PF No"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtPFNo"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="UAN No. "></asp:Label>
                                        <asp:TextBox runat="server" ID="txtUANNo" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="PF Statutory Deduction"></asp:Label><br />
                                        <asp:CheckBox ID="chkIsAdmin" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <hr />
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;License Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="card">
                                        <div class="card-header">
                                            <h5 class="card-title">&nbsp;&nbsp;Gun Details</h5>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Holding Gun"></asp:Label>
                                                        <asp:DropDownList ID="ddlTypeOfGun" CssClass="form-control RoundText" runat="server">
                                                            <asp:ListItem Value="No" Selected="True" Text="No"></asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Gun License No"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtGunLicenseNo" CssClass="form-control RoundText"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Gun No"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtGunNo" CssClass="form-control RoundText"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Issuing Authority"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtGunIssuingAuthority" CssClass="form-control RoundText"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Date of Issue"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtGunDateOfIssue" CssClass="form-control RoundText Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Date of Expiry"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtGunDateOfExpiry" CssClass="form-control RoundText Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="card">
                                        <div class="card-header">
                                            <h5 class="card-title">&nbsp;&nbsp; Driving License</h5>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Holding Driving License"></asp:Label>
                                                        <asp:DropDownList ID="ddlDrivingLicense" CssClass="form-control RoundText" runat="server">
                                                            <asp:ListItem Value="No" Selected="True" Text="No"></asp:ListItem>
                                                            <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Driving License No"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtDrivingLicenseNo" CssClass="form-control RoundText"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Issuing Authority"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtDLIssuingAuthority" CssClass="form-control RoundText"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Date Of Issue"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtDLDateOfIssue" CssClass="form-control RoundText Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div class="form-group">
                                                        <asp:Label CssClass="lblText" runat="server" Text="Date Of Expiry"></asp:Label>
                                                        <asp:TextBox runat="server" ID="txtDLDateOfExpiry" CssClass="form-control RoundText Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <hr />
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" />
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
