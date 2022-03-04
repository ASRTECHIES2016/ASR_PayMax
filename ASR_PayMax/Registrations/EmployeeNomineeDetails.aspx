<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeNomineeDetails.aspx.cs" Inherits="ASR_PayMax.Registrations.EmployeeNomineeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Nominee Master</li>
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
                            <h3 class="card-title">&nbsp;&nbsp;Nominee Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Employee Code"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtEmployeeCode" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                                        <input id="hddEmployeeID" type="hidden" runat="server" value="0" class="hide" />
                                        <input id="hddPincodeID" type="hidden" runat="server" value="0" class="hide" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Employee Name"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtFirstName" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Nominee Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtNomineeName" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Relationship"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlRelationship" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Gaurdian Name"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtGaurdian" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Date Of Birth"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtDOB" CssClass="form-control RoundText Date"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Share ( % )"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtShare" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Address"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
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
                            </div>
                            <div class="row">
                                <div class="col-sm-1">
                                    <asp:Button ID="Btn_Add" runat="server" Text="+" Style="margin-top: 23px;" CssClass="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Panel ID="PanelNomineeDetails" runat="server" CssClass="row" Visible="false">
                        <hr />
                        <asp:GridView ID="GridNomineeDetails" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%"
                            CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Str_DesignationID ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignationID" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DesignationGroupID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignationGroupID" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DesignationCategoryTypeID ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignationCategoryTypeID" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignationName" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation Group">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignationGroupName" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignationCategoryType" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Active">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="IsActive" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkEdit" runat="server" CommandName="Change" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-info btn-sm"><span class='fa fa-edit'></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField><asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkDeleted" runat="server" CommandName="Deleted" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-danger btn-sm"><span class='fa fa-trash'></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
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
