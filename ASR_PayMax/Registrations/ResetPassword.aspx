<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="ASR_PayMax.Registrations.ResetPassword1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>ASR | Dashboard</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="/Scripts/jquery-3.0.0.js"></script>
    <script src="/Scripts/bootstrap.js"></script>
    <script src="/Scripts/adminlte.js"></script>
    <script src="/Scripts/CommonValidation.js"></script>
</head>

<body>


    <form id="form1" runat="server">
        <div class="container">
            <%--<h2>Card Header and Footer</h2>--%>
            <div class="card border-info" style="max-width: 35rem;">
                <div class="card-header">Reset Password</div>
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <div>
                                <asp:Label ID="lblUserName" runat="server" Text="User Name" CssClass="form-group"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-group"></asp:TextBox>
                            </div>

                            <div>
                                <asp:Button ID="Btn_Submit" runat="server" CssClass="form-group btn btn-primary" OnClick="Btn_Submit_Click" Text="Submit" />
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>


    </form>
</body>
</html>


