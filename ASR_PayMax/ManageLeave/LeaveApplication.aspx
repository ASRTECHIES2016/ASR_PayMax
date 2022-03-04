<%@ Page Title="Leave Application" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="LeaveApplication.aspx.cs" Inherits="ASR_PayMax.ManageLeave.LeaveApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Leave Master</li>
        </ol>
    </section>--%>

    <div class="card">
        <div class="card-body">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Label CssClass="lblText" runat="server" Text="Leave Type"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                            <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">&nbsp;</div>
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Label CssClass="lblText" runat="server" Text="From Date"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                            <asp:TextBox runat="server" ID="txtFromDates" CssClass="form-control RoundText"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <asp:Label CssClass="lblText" runat="server" Text="To Date"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                            <asp:TextBox runat="server" ID="txtToDates" CssClass="form-control RoundText"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">&nbsp;</div>
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:Label CssClass="lblText" runat="server" Text="Reason"></asp:Label>
                            <asp:TextBox ID="txtReason" runat="server" CssClass="form-control RoundText" TextMode="MultiLine" Rows="5" Columns="500"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">&nbsp;</div>
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:Label CssClass="lblText" runat="server" Text="Upload Document"></asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                            <asp:FileUpload runat="server" CssClass="form-control" dir="rtl"></asp:FileUpload>&nbsp;&nbsp;
                        </div>
                    </div>
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="Btn_Cancel_Click" />
                        </div>
                    </asp:Panel>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
