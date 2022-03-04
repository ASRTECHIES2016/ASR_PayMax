<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="SalaryHead.aspx.cs" Inherits="ASR_PayMax.Masters.SalaryHead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Salary Head Master</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-body">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">&nbsp;&nbsp;Salary Head Details</h3>
                </div>
                <div class="card-body"><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="GridSalaryHead" EventName="RowCommand" />
                        </Triggers>
                        <ContentTemplate>
                                      <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Salary Head Code"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:TextBox runat="server" ID="txtSalaryHeadCode" CssClass="form-control RoundText"></asp:TextBox>
                                <input id="hddSalaryHeadID" type="hidden" runat="server" value="0" />
                            </div>
                        </div>
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Sequence No."></asp:Label>
                                <asp:TextBox runat="server" ID="txtSequenceNo" CssClass="form-control RoundText OnlyNum"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Salary Head Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:TextBox runat="server" ID="txtSalaryHeadName" CssClass="form-control RoundText"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Salary Head Group"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlSalaryHeadGroup" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="PaySlip / Non PaySlip"></asp:Label>
                                <asp:DropDownList ID="ddlPaySlip" runat="server" CssClass="form-control RoundText">                                    
                                    <asp:ListItem Value="Select One" Selected="True">Select One</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Variable"></asp:Label><br />
                                <asp:CheckBox ID="chkVariable" runat="server" />
                            </div>
                        </div>
                    </div>
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            <%-- &nbsp;&nbsp;
                        <asp:Button ID="Btn_Edit" runat="server" Text="Edit" CssClass="btn btn-info" OnClick="Btn_Edit_Click" />
                            --%>   &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                        </div>
                    </asp:Panel>  <hr />
                    <asp:GridView ID="GridSalaryHead" runat="server" EmptyDataText="No Data Available" OnRowCommand="GridSalaryHead_RowCommand" AutoGenerateColumns="false" Width="100%"
                        CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SalaryHeadMasterID ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblSalaryHeadMasterID" Text='<%# Eval("SalaryHeadMasterID") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SalaryHeadGroupMasterID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblSalaryHeadGroupMasterID" Text='<%# Eval("SalaryHeadGroupMasterID") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sequence No" >
                                <ItemTemplate>
                                    <asp:Label ID="lblSequenceNo" runat="server" Text='<%# Eval("SequenceNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Salary Head Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblSalaryHeadCode" runat="server" Text='<%# Eval("SalaryHeadCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Salary Head Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSalaryHeadName" runat="server" Text='<%# Eval("SalaryHeadName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Salary Head Group">
                                <ItemTemplate>
                                    <asp:Label ID="lblSalaryHeadGroupName" runat="server" Text='<%# Eval("SalaryHeadGroupName") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkEdit" runat="server" CommandName="Change" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-info btn-sm"><span class='fa fa-edit'></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkDeleted" runat="server" CommandName="Deleted" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="btn btn-danger btn-sm"><span class='fa fa-trash'></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
</ContentTemplate></asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
