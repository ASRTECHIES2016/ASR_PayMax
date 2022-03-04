<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeIDCard.aspx.cs" Inherits="ASR_PayMax.Reports.Payroll.EmployeeIDCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Wage Register</li>
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
                    
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Branch Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Client Name"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlClient" runat="server" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Site Name" ></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                <asp:DropDownList ID="ddlSite" runat="server" CssClass="form-control RoundText" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Date"></asp:Label>
                                <asp:TextBox runat="server" ID="txtDate" CssClass="form-control RoundText Date"></asp:TextBox>
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
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
