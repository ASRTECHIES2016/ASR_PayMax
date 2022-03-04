<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="SiteMaster.aspx.cs" Inherits="ASR_PayMax.Masters.SiteMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Site Master</li>
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
                            <h3 class="card-title">&nbsp;&nbsp;Site Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Region"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Service Type"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Client"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>       <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Industry Segment"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlIndustrySegment" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                        <input id="hddSiteID" type="hidden" runat="server" value="0" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <%--   <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Client Group"></asp:Label>
                                        <asp:DropDownList ID="ddlClientGroup" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>--%>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Site Code"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtSiteCode" CssClass="form-control RoundText" Enabled="false" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Site Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtSiteName" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Weekly Off Division By"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtWeeklyOff" CssClass="form-control RoundText" Text="7" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                              <%--  <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Financial Branch"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlFinanceBranch" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="row">

                                <%-- <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Group"></asp:Label>
                                        <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Site Address 1"></asp:Label><%--&nbsp;&nbsp;<span class="star">*</span>--%>
                                        <asp:TextBox runat="server" ID="txtSiteAddressOne" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Site Address 2"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtSiteAddressTwo" CssClass="form-control RoundText"></asp:TextBox>
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
                            <%--<div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Pincode"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtPincode" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="City"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtCity" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="State"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtState"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Country"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtCountry"></asp:TextBox>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <%--<hr />--%>
                    <div class="card" >
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Billing Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Bill Type"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlBillType" runat="server" CssClass="form-control RoundText">
                                            <asp:ListItem Value="Muster Billing" Selected="True">Muster Billing</asp:ListItem>
                                            <asp:ListItem Value="Non Muster Billing">No Muster Billing</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Compliance / Non-Compliance "></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlCompliance" runat="server" CssClass="form-control RoundText">
                                            <asp:ListItem Value="Yes" Selected="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Bill Duty Division By"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtBillDuty" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>

                                <%-- <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Zone"></asp:Label>
                                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="PF On Basic DA OT"></asp:Label><br />
                                        <asp:CheckBox ID="chkPFOn" runat="server" CssClass="custom-checkbox" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Statuary Applicable"></asp:Label>

                                        <asp:CheckBoxList ID="chkStatuaryApp" RepeatDirection="Horizontal" runat="server" CssClass="custom-checkbox">
                                            <asp:ListItem Value="PF" Selected="True">&nbsp;&nbsp;PF&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="ESIC">&nbsp;&nbsp;ESIC&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="LWF"> &nbsp;&nbsp;LWF&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="PT">&nbsp;&nbsp;PT&nbsp;&nbsp;</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Implement Area For New ESIC"></asp:Label><br />
                                        <asp:CheckBox ID="chkNewESIC" runat="server" CssClass="custom-checkbox" />
                                    </div>
                                </div>
                            </div>
                            <%--    <div class="row">
                        
                            </div>--%>
                        </div>
                    </div>
                    <%--<hr />--%>
                    <div class="card" style="display: none">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Contact Person Details</h3>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel5" CssClass="row" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <asp:GridView ID="GridContactPerson" runat="server" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" RowStyle-CssClass="text-center" OnRowCreated="GridContactPerson_RowCreated">
                                        <Columns>
                                            <asp:BoundField DataField="RowNumber" HeaderText="Sr No." />
                                            <asp:TemplateField HeaderText="Contact Person Name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtName" CssClass="form-control OnlyChar" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtContactNo" CssClass="form-control OnlyNum" Minlength="10" MaxLength="10" runat="server"></asp:TextBox>
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
                                                        <asp:Button runat="server"  ID="ButtonAdd"  CssClass="btn btn-primary"  Text="Add" OnClick="ButtonAdd_Click"></asp:Button>
                                </footertemplate>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <hr />
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Detail" runat="server" Text="Details" CssClass="btn btn-info" OnClick="Btn_Detail_Click" />
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
