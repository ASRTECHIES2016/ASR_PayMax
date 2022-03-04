<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="ASR_PayMax.Masters.Designation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Designation Master</li>
        </ol>
    </section>--%>

    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Designation Details</h3>
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="GridDesignation" EventName="RowCommand" />
                </Triggers>
                <ContentTemplate>

                    <div class="row">
                        <div class="col-sm-5">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Label CssClass="lblText" runat="server" Text="Designation Group Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                    <asp:DropDownList ID="ddlDesignationGroupID" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <%--</div>
                    <div class="row">--%>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Label CssClass="lblText" runat="server" Text="Designation Category Type"></asp:Label>
                                    <asp:DropDownList ID="ddlDesignationCategoryID" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <%--  </div>
                    <div class="row">--%>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Label CssClass="lblText" runat="server" Text="Designation"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                    <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control RoundText"></asp:TextBox>
                                    <input id="hddDesignationID" type="hidden" runat="server" value="0" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <asp:GridView ID="GridSkill" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%"
                                CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label CssClass="lblText" runat="server"  Text='<%# Eval("SkillName") %>' ID="lblCategory"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BA" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDesignation1" CssClass="GridFormControl RoundText"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DA" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDesignation2" CssClass="GridFormControl RoundText"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HRA" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDesignation3" CssClass="GridFormControl RoundText"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OT" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDesignation4" CssClass="GridFormControl RoundText"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Min Wages" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDesignation5" CssClass="GridFormControl RoundText"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-secondary" OnClick="Btn_Cancel_Click" />
                        </div>
                    </asp:Panel>
                    <hr />
                    <asp:GridView ID="GridDesignation" runat="server" EmptyDataText="No Data Available" OnRowCommand="GridDesignation_RowCommand" AutoGenerateColumns="false" Width="100%"
                        CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Str_DesignationID ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationID" Text='<%# Eval("DesignationMasterID") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DesignationGroupID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationGroupID" Text='<%# Eval("DesignationGroupMasterID") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DesignationCategoryTypeID ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationCategoryTypeID" runat="server" Text='<%# Eval("CategoryID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationName" runat="server" Text='<%# Eval("DesignationName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation Group">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationGroupName" runat="server" Text='<%# Eval("DesignationGroupName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation Category">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationCategoryType" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="IsActive" EventName="CheckedChanged" />
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:CheckBox ID="IsActive" runat="server" Checked='<%# Eval("Active") %>' AutoPostBack="true" OnCheckedChanged="IsActive_CheckedChanged" CssClass="custom-checkbox" />
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
           
            GridMasters('<%=GridDesignation.ClientID%>', '', '', '', '', '', '', '', '', '');
        }
    </script>
</asp:Content>

