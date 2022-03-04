<%@ Page Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ASR_PayMax.Registrations.ChangePassword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                            <h3 class="card-title">&nbsp;&nbsp;Change Password</h3>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group" id="DivOldPassword" runat="server">
                                        <asp:Label CssClass="OldPassword" runat="server" Text="Current Password"> </asp:Label>&nbsp;&nbsp;<span class="star">*</span>
                                        <asp:TextBox runat="server" ID="txtOldPassword" CssClass="form-control RoundText" TextMode="Password" Text="Current Password"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label CssClass="NewPassword" runat="server" Text="New Password"> </asp:Label>&nbsp;&nbsp;
                                        <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control RoundText" TextMode="Password" Text="New Password"></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <asp:Label CssClass="ConfirmPassword" runat="server" Text="Confirm New Password"  > </asp:Label>&nbsp;&nbsp;
                                        <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control RoundText" TextMode="Password" Text="Confirm New Password" ></asp:TextBox>

                                    </div>
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
                            &nbsp;&nbsp;
                            <asp:Label CssClass="lblMsg" runat="server"> </asp:Label>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
