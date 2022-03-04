<%@ Page Title="" Language="C#" MasterPageFile="~/PayMaxMaster.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="ASR_PayMax.Masters.Group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <section class="content-header">
        <h1>Department Of Payroll</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li class="active">Group Master</li>
        </ol>
    </section>--%>
    <div class="card">
        <div class="card-body">
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">&nbsp;&nbsp;Group Details</h3>
                </div>
                <div class="card-body">
                 
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Btn_Cancel" EventName="Click" />
                        </Triggers>
                        <ContentTemplate><div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label CssClass="lblText" runat="server" Text="Client Group"></asp:Label>
                                <asp:TextBox runat="server" ID="txtGroupName" CssClass="form-control RoundText"></asp:TextBox>
                                <input id="hddGroupID" type="hidden" runat="server" value="0" />
                            </div>
                        </div>
                    </div>
                    <asp:Panel ID="pnlButtons" runat="server" CssClass="row">
                        <div class="col-sm-10">
                            <asp:Button ID="Btn_Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Btn_Submit_Click" />
                            <%-- &nbsp;&nbsp;
                        <asp:Button ID="Btn_Edit" runat="server" Text="Edit" CssClass="btn btn-info" OnClick="Btn_Edit_Click" />
                            --%>   &nbsp;&nbsp;
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Reset" CssClass="btn btn-danger"  OnClick="Btn_Cancel_Click"/>
                        </div>
                    </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                </div>
            </div>
        </div>
    </div>

    <%--<script type="text/javascript">
        $(document).ready(function () {
            validation();
            var parameter = Sys.WebForms.PageRequestManager.getInstance();
            parameter.add_endRequest(function () {
                validation();
            });
        });
        function validation() {
            //$('.OnlyChar').keypress(function (e) {
            //    return OnlyCharacter(e);
            //});
            //$('.OnlyNum').keypress(function (e) {
            //    return OnlyNumber(e);
            //});

        }
        function AddClient() {
            var _Parameters = {};
            _Parameters.Str_ClientGroupID = $('#<%=hddGroupID.ClientID %>').val();
            _Parameters.Str_ClientGroupCode = $('#<%=txtGroupCode.ClientID %>').val();
            _Parameters.Str_ClientGroupName = $('#<%=txtGroupName.ClientID%>').val();


            $.ajax({
                type: "post",
                url: "http://192.168.100.1:8088/api/clientgroup/Post",
                contentType: "application/json; charset=utf-8",
                data: "{ _Parameters :'" + _Parameters + "'}",
                dataType: "json",
                success: function (data) {
                   
                    //response($.map(data.d, function (item) {
                    //    return {
                    //        label: item.strRegisterFormName, value: item.strRegisterFormName, ID: item.strRegisterMasterId
                    //    }
                    //}))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest, textStatus, errorThrown)
                }
            });
        }
        function ClearBox() {
            $('#<%=hddGroupID.ClientID %>').val('0');
            $('#<%=txtGroupCode.ClientID %>').val('');
            $('#<%=txtGroupName.ClientID%>').val('');
        }
    </script>--%>
</asp:Content>

