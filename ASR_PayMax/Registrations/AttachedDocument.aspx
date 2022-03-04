<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="AttachedDocument.aspx.cs" Inherits="ASR_PayMax.Registrations.AttachedDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Attach Document Master</li>
        </ol>
    </section>--%>

    <div class="card">
        <div class="card-header">
            <h3 class="card-title">&nbsp;&nbsp;Attach Document Details</h3>
        </div>
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <input id="hddEmployeeID" type="hidden" runat="server" value="0" class="hide" />
                    <div class="row">
                        <div class="col-sm-6">
                            <%--<div class="col-sm-12">--%>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <asp:Label CssClass="lblText" runat="server" Text="Employee Code"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                    <asp:TextBox runat="server" ID="txtEmployeeCode" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <div class="form-group">
                                    <asp:Label CssClass="lblText" runat="server" Text="Employee Name"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtFirstName" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                                </div>
                            </div>
                            <%--</div>--%>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Label CssClass="lblText" runat="server" Text="Document Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                    <asp:DropDownList ID="ddlDocument" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <asp:Label CssClass="lblText" runat="server" Text="Select Document"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <div class="row">
                                    <div class="col-sm-10">

                                        <ajaxToolkit:AsyncFileUpload ID="AsyncUpload" CssClass="form-control" dir="rtl" runat="server" OnUploadedComplete="AsyncUpload_UploadedComplete" />
                                        <%--<asp:FileUpload runat="server" ></asp:FileUpload>&nbsp;&nbsp;--%>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:Button ID="Btn_Add_Doc" runat="server" Text="Add" CssClass="btn btn-primary" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Image ID="ImgDoccument" runat="server" CssClass="rounded" ImageUrl="~/Images/Cards/paypal.png" Width="300" Height="230" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <hr />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row" Visible="false">
                        <div class="col-sm-10">
                            &nbsp;&nbsp;    
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-secondary" OnClick="Btn_Cancel_Click" />
                        </div>
                    </asp:Panel>
                    <asp:GridView ID="GridDocument" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Str_DesignationID ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationID" Text="1" runat="server" />
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
            GridMasters('<%=GridDocument.ClientID%>', '', '', '', '', '', '', '', '', '');
        }



    </script>
</asp:Content>
