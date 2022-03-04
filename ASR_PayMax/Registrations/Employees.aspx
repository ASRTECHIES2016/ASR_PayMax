<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="ASR_PayMax.Registrations.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Branch Master</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <Triggers>
                    <%--    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />--%>
                    <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged" />
                </Triggers>
                <ContentTemplate>
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Employee Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Employee Code"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtEmployeeCode" ReadOnly="true" CssClass="form-control RoundText"></asp:TextBox>
                                        <input id="hddEmployeeID" type="hidden" runat="server" value="0" class="hide" />
                                        <input id="hddPincodeID" type="hidden" runat="server" value="0" class="hide" />
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Rgistration Date"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtRgistrationDate" CssClass="form-control RoundText Date"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Joining Date"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtJoiningDate" CssClass="form-control RoundText Date"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Late Mark Appl"></asp:Label><br />
                                        <asp:CheckBox ID="chkIsLateMarkApplicable" runat="server" Checked="true" CssClass="custom-checkbox" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="First Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Middle Name"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtMiddleName"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Last Name"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Gender"></asp:Label>
                                        <asp:RadioButtonList ID="RadioGender" RepeatDirection="Horizontal" runat="server">
                                            <asp:ListItem Value="Male" Selected="True"> &nbsp;&nbsp;Male&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="Female">&nbsp;Female&nbsp;</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Date Of Birth"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText Date" ID="txtDateOfBirth"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Designation Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlDesignationID" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Contact No"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control RoundText OnlyNum" MinLength="10" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Email ID"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtEmailID" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Aadhar Card No."></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtAadharCardNo" TextMode="Number" MinLength="10" MaxLength="12"> </asp:TextBox>
                                    </div>
                                </div>
                                <%-- <div class="col-sm-1">
                                    <asp:Button ID="Btn_Add_Aadhar" runat="server" Text="+" Style="margin-top: 23px;" CssClass="btn btn-primary" ToolTip="Attach Document" />
                                </div>--%>
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="PAN Card No"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtPANCardNo" MaxLength="11"></asp:TextBox>
                                    </div>
                                </div>
                                <%--<div class="col-sm-1">
                                    <asp:Button ID="Btn_Add_PAN" runat="server" Text="+" Style="margin-top: 23px;" CssClass="btn btn-primary" ToolTip="Attach Document"  />
                                </div>--%>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Monthly Salary Expected"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtMonthlySalary" CssClass="form-control RoundText" TextMode="Number" MaxLength1="12"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Client Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlClient" CssClass="form-control RoundText" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Site Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlSiteName" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Current Status"></asp:Label>
                                        <asp:DropDownList ID="ddlPresentStatus" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Presently Working With-Unit"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtPresently"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Location"></asp:Label>
                                        <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtLocation"></asp:TextBox>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <%--<hr />--%>
                    <div class="card" style="display: none">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Qualification Details</h3>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Btn_Add_Qual" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Qualification"></asp:Label>
                                                <asp:DropDownList ID="ddlQualification" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="University / Board"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtUniversity" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Year Of Passing"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtPassingYear" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-1">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Per"></asp:Label>
                                                <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtPer"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-1">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Grade"></asp:Label>
                                                <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtGrade"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-1">
                                            <asp:Button ID="Btn_Add_Qual" runat="server" Text="+" Style="margin-top: 23px;" CssClass="btn btn-primary" OnClick="Btn_Add_Qual_Click" />
                                        </div>
                                    </div>
                                    <asp:GridView ID="GridQualification" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="QualificationDetailID ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQualificationDetailID" Text='<%# Eval("QualificationDetailID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualification ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQualificationID" Text='<%# Eval("QualificationID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualification Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQualificationName" Text='<%# Eval("QualificationName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Board">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBoard" Text='<%# Eval("Board") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Passing Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPassingYear" Text='<%# Eval("PassingYear") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Per">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPer" Text='<%# Eval("Per") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGrade" Text='<%# Eval("Grade") %>' runat="server" />
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
                    <%-- <hr />--%>
                    <div class="card" style="display: none">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Address Details</h3>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Btn_Add_Address" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Address Type"></asp:Label>
                                                <asp:DropDownList ID="ddlAddressType" CssClass="form-control RoundText" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Address"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Pincode"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtPincode" ClientIDMode="Static" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="City"></asp:Label>
                                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="State"></asp:Label>
                                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Country"></asp:Label>
                                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-1">
                                            <asp:Button ID="Btn_Add_Address" runat="server" Text="+" Style="margin-top: 23px;" CssClass="btn btn-primary" OnClick="Btn_Add_Address_Click" />
                                        </div>
                                    </div>
                                    <asp:GridView ID="GridAddress" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="QualificationDetailID ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddressDetailID" Text='<%# Eval("AddressDetailID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualification ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddressTypeID" Text='<%# Eval("AddressTypeID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddressTypeName" Text='<%# Eval("AddressTypeName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" Text='<%# Eval("Address") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PinCode ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPinCodeID" Text='<%# Eval("PinCodeID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pin Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPinCode" Text='<%# Eval("PinCode") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCityID" Text='<%# Eval("CityID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCityName" Text='<%# Eval("CityName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStateID" Text='<%# Eval("StateID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStateID" Text='<%# Eval("StateName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Country ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCountryID" Text='<%# Eval("CountryID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Country">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCountryName" Text='<%# Eval("CountryName") %>' runat="server" />
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
                    <%--<hr />--%>
                    <div class="card" style="display: none">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Emergency Contact Details</h3>
                        </div>
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Btn_Add_EmgAddress" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Contact Name"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtEmgContactName" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Contact No"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtEmgContactNo" CssClass="form-control RoundText OnlyNum" TextMode="Number" MinLength="10" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Email ID"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtEmgEmail" CssClass="form-control RoundText" TextMode="Email"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Address"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtEmgAddress" CssClass="form-control RoundText"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-sm-2">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Pincode"></asp:Label>
                                                <asp:TextBox runat="server" ID="txtEmgPincode" CssClass="form-control RoundText" MaxLength="6"></asp:TextBox>
                                            </div>
                                        </div>

                                        <%--    <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="City"></asp:Label>
                                                <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtEmgCity"></asp:TextBox>
                                            </div>
                                        </div>
                                        </div>
                                    <div class="row">--%>
                                        <%--                     <div class="col-sm-4">
                                <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="State"></asp:Label>
                                                <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtEmgState"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Country"></asp:Label>
                                                <asp:TextBox runat="server" CssClass="form-control RoundText" ID="txtEmgCountry"></asp:TextBox>
                                            </div>
                                        </div>

                                        --%>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="City"></asp:Label>
                                                <asp:DropDownList ID="ddlEmgCity" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="State"></asp:Label>
                                                <asp:DropDownList ID="ddlEmgState" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <%-- <div class="col-sm-3">
                                            <div class="form-group">
                                                <asp:Label CssClass="lblText" runat="server" Text="Country"></asp:Label>
                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <div class="col-sm-1">
                                            <asp:Button ID="Btn_Add_EmgAddress" runat="server" Text="+" Style="margin-top: 23px;" CssClass="btn btn-primary" OnClick="Btn_Add_EmgAddress_Click" />
                                        </div>
                                    </div>
                                    <asp:GridView ID="GridContactDetails" runat="server" EmptyDataText="No Data Available" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered dt-responsive nowrap dataTable no-footer dtr-inline collapsed" CellSpacing="0" aria-describedby="datatable-responsive_info">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No." HeaderStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EmgContactDetail ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmgContactDetailID" Text='<%# Eval("EmgContactDetailID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactName" Text='<%# Eval("ContactName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactNo" Text='<%# Eval("ContactNo") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmailID" Text='<%# Eval("EmailID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" Text='<%# Eval("Address") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PinCode ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPinCodeID" Text='<%# Eval("PinCodeID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pin Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPinCode" Text='<%# Eval("PinCode") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCityID" Text='<%# Eval("CityID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCityName" Text='<%# Eval("CityName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStateID" Text='<%# Eval("StateID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStateID" Text='<%# Eval("StateName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Country ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCountryID" Text='<%# Eval("CountryID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Country">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCountryName" Text='<%# Eval("CountryName") %>' runat="server" />
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
                    <hr />
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Detail" runat="server" Text="Details" CssClass="btn btn-info" />
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
