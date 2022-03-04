<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="Branch.aspx.cs" Inherits="ASR_PayMax.Masters.Branch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--  <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Branch Master</li>
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
                            <h3 class="card-title">&nbsp;&nbsp;Branch Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Code"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtBranchCode" CssClass="form-control RoundText" MaxLength="10"></asp:TextBox>
                                        <input id="hddBranchID" type="hidden" runat="server" value="0" />
                                        <input id="hddPinCode" type="hidden" runat="server" value="0" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Region"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Pay Pro Bank Acc No."></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText OnlyNum" ID="txtPayProAccNo" MaxLength="16"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Pay Pro Bank Code"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" MaxLength="11"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch No."></asp:Label>
                                        <asp:TextBox runat="server" ID="txtBranchNo" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtBranchName"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Tel No. (1)"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtTelNo1" TextMode="phone" MaxLength="12"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Tel No. (2)"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtTelNo2" TextMode="phone" MaxLength="12"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Admin Charges"></asp:Label><br />
                                        <asp:CheckBox ID="chkIsAdmin" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <%-- <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="ERP Branch"></asp:Label>
                                        <asp:DropDownList ID="ddlERPBranch" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>--%>



                                <%-- <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Emp Reg Approval"></asp:Label><br />
                                        <asp:CheckBox ID="chkRegApproval" runat="server" />
                                    </div>
                                </div>--%>
                            </div>
                            <div class="row">
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Address Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Address 1"></asp:Label><%--&nbsp;&nbsp;<span class="star">*</span>--%>
                                        <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Address 2"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Pincode"></asp:Label><%--&nbsp;&nbsp;<span class="star">*</span>--%>
                                        <asp:TextBox runat="server" ID="txtPincode" CssClass="form-control RoundText OnlyNum" MaxLength="6"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="City"></asp:Label>
                                        <%--<asp:TextBox runat="server" ID="txtCity" CssClass="form-control RoundText"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="State"></asp:Label>
                                        <%--<asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtState"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Country"></asp:Label>
                                        <%--<asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtCountry"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="card" style="display: none">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Contact Person Details&nbsp;&nbsp;<span class="star">*</span></h3>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:GridView ID="Gridview2" runat="server" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" RowStyle-CssClass="text-center" OnRowCreated="Gridview2_RowCreated">
                                        <Columns>
                                            <asp:BoundField DataField="ContactDetailID" HeaderText="Sr No." />

                                            <asp:TemplateField HeaderText="Contact Person Name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtName" CssClass="form-control OnlyChar" runat="server" MaxLength="100"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtContactNo" CssClass="form-control OnlyNum" TextMode="Number" minlength="10" MaxLength="10" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lknButton" runat="server" OnClick="lknButton_Click" CssClass="btn btn-danger" Text="Remove"></asp:LinkButton>
                                                    <footerstyle horizontalalign="Right" />
                                                    <footertemplate>
                                                        <asp:Button runat="server" ID="ButtonAdd" CssClass="btn btn-primary" Text="Add" OnClick="ButtonAdd_Click"></asp:Button>
                                                    </footertemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <%--<div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Code"></asp:Label>
                                        <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch No."></asp:Label>
                                        <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Region"></asp:Label>
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>--%>
                    </div>
                    <hr />
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
