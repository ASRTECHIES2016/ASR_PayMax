<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="DesignationCategory.aspx.cs" Inherits="ASR_PayMax.Masters.DesignationCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <section class="content-header">
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
                </Triggers>
                <ContentTemplate>

                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Designation Category"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:TextBox runat="server" ID="txtCategoryName" CssClass="form-control RoundText"></asp:TextBox>
                                <input id="hddCategoryID" type="hidden" runat="server" value="0" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-9">
                            <asp:GridView ID="GridSkill" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%"
                                CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label CssClass="lblText" runat="server" Text='<%# Eval("SkillName") %>' ID="lblCategory"></asp:Label>
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
                                            <asp:TextBox runat="server" ID="txtDesignation3" CssClass="GridFormControl RoundText"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Min Wages" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDesignation4" CssClass="GridFormControl RoundText"></asp:TextBox>
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
            len = 0;
            len = $("#<%=GridSkill.ClientID%>").find('tr').length;
            if (len > 1) {
                $("#'<%=GridSkill.ClientID%>" + " thead").remove();
                $("#'<%=GridSkill.ClientID%>").prepend($("<thead></thead>").append($("#<%=GridSkill.ClientID%>").find("tr:first"))).dataTable({
                    destroy: true,
                    // pageLength: 10,
                    responsive: true,
                    //  pagingType: "first_last_numbers",
                    //  bFilter: true,
                });
            }
        }
    </script>
</asp:Content>

