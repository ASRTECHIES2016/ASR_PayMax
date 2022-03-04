<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ASR_PayMax.Registrations.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Company Master</li>
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
                            <h3 class="card-title">&nbsp;&nbsp;User's Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="First Name"> </asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <%-- <div class="row">
                                            <div class="col-sm-11">
                                        --%>
                                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control RoundText"></asp:TextBox>
                                        <%-- </div>
                                            <div class="col-sm-1">
                                                <a href="#" class="btn btn-xs btn-info"><b><i class="text-right fa fa-search"></i></b></a>
                                            </div>
                                        </div>--%>
                                        <input id="hddUserID" type="hidden" class="hide" value="0" runat="server" />
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Middle Name"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtMiddleName" CssClass="form-control RoundText"></asp:TextBox>
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
                                        <asp:Label CssClass="lblText" runat="server" Text="Email"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Contact No."></asp:Label>
                                        <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label CssClass="lblText" runat="server" Text="Address"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control RoundText"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">&nbsp;&nbsp;Login Details</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Role Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Designation Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control RoundText"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="User Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Maker / Checker Options"></asp:Label>
                                        <asp:RadioButtonList ID="RadioBilling" RepeatDirection="Horizontal" runat="server">
                                            <asp:ListItem Value="1" Selected="True"> &nbsp;&nbsp;Maker&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="2">&nbsp;Checker&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="3">&nbsp;Approver&nbsp;</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <asp:Label CssClass="lblText" runat="server" Text="Password"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control RoundText"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label CssClass="lblText" runat="server" Text="Confirm Password"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                    <asp:TextBox runat="server" ID="txtConPassword" CssClass="form-control RoundText"></asp:TextBox>
                                </div>
                            </div>
                        </div>
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
