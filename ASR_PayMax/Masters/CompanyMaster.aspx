<%@ Page Title="Register Company" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="ASR_PayMax.Masters.CompanyMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Company Master</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-body">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">&nbsp;&nbsp;Company Details</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <asp:Label CssClass="lblText" runat="server" Text="Company Name"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control RoundText"></asp:TextBox>
                                            <input id="hddCompanyID" type="hidden" runat="server" value="0" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <asp:Label CssClass="lblText" runat="server" Text="Address"></asp:Label>
                                            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control RoundText"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <asp:Label CssClass="lblText" runat="server" Text="Salary Start Month/Year"></asp:Label>
                                            <asp:TextBox runat="server" CssClass="form-control date RoundText" ID="txtSalaryStart"></asp:TextBox>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="col-sm-6">
                            <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                                <ContentTemplate>--%>

                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Image ID="ImgCompany" ImageUrl="https://www.google.com/images/branding/googleg/1x/googleg_standard_color_128dp.png" runat="server" CssClass="rounded" Style="min-width: 0px; max-width: 500px; min-height: 0px; max-height: 500px;" />
                                </div>
                            </div>

                            <%--       </ContentTemplate>
                            </asp:UpdatePanel>--%>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Label CssClass="lblText" runat="server" Text="Company Logo"></asp:Label>
                                    <ajaxToolkit:AsyncFileUpload ID="FileUploading" runat="server" PersistFile="true" OnUploadedComplete="FileUploading_UploadedComplete" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="row">
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
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Pincode"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtPincode" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <hr />
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">&nbsp;&nbsp;Contact Person Details</h3>
                </div>
                <div class="card-body">
                    <asp:UpdatePanel ID="UpdatePanel5" class="row" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:GridView ID="GridPersonDetails" runat="server" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" RowStyle-CssClass="text-center">
                                <Columns>
                                    <asp:BoundField DataField="RowNumber" HeaderText="Sr No." />
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Person Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtName" CssClass="form-control OnlyChar" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtContactNo" CssClass="form-control OnlyNum" minlength="10" MaxLength="10" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LknButton" runat="server" OnClick="LknButton_Click" CssClass="btn btn-danger" Text="Remove"></asp:LinkButton>
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
            <br />
            <asp:UpdatePanel ID="UpdatePanel12345" runat="server" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                </Triggers>
                <ContentTemplate>

                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            &nbsp;&nbsp;
                    <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--        <hr />
          <div class="card">
                <div class="card-header">
                    <h3 class="card-title">&nbsp;&nbsp;Contact Person Details</h3>
                </div>
                <div class="card-body">
                    <asp:UpdatePanel ID="UpdatePanel1" class="row" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:GridView ID="GridCompanyDetails"  runat="server" ShowFooter="true" AutoGenerateColumns="false" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" RowStyle-CssClass="text-center" >
                                <Columns>
                                    <asp:BoundField DataField="RowNumber" HeaderText="Sr No." />
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Person Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtName" CssClass="form-control OnlyChar" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtContactNo" CssClass="form-control OnlyNum" minlength="10" MaxLength="10" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>--%>
        </div>
    </div>
</asp:Content>
