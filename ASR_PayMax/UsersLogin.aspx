<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersLogin.aspx.cs" Inherits="ASR_PayMax.UsersLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>ASR | Dashboard</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.7 -->
    <%--<icon rel="icon" type="image/png" src="Images/Logos/icon.png" />--%>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <!-- Font Awesome -->
    <link href="fonts/font-awesome.css" rel="stylesheet" />
    <!-- Ionicons -->
    <link href="fonts/ionicons.css" rel="stylesheet" />
    <link href="Content/AdminLTE.css" rel="stylesheet" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link href="Content/_all-skins.css" rel="stylesheet" />
    <link href="Content/Font_Google.css" rel="stylesheet" />

</head>

<body>
    <script src="/Scripts/jquery-3.0.0.js"></script>
    <script src="/Scripts/bootstrap.js"></script>
    <script src="/Scripts/adminlte.js"></script>
    <script src="/Scripts/CommonValidation.js"></script>
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <style type="text/css">
            /*#Image_ASR {
                padding: 0.05rem;
                background-color: #fff;
                border: 1px solid #dee2e6;
                border-radius: 0.25rem;
                max-width: 100%;
                min-height:5px;
              max-height: 297px;
            }*/
            #userLoginContainer {
                margin-top: 100px;
            }

            #loginside {
                margin-top: 75px;
            }
        </style>
        <script type="text/javascript">
    window.onload = function () { $("#showPassword").hide(); }

    $("#txtPassword").on('change', function () {
        if ($("#txtPassword").val()) {
            $("#showPassword").show();
        }
        else {
            $("#showPassword").hide();
        }
    });

    $(".reveal").on('click', function () {
        var $pwd = $("#txtPassword");
        if ($pwd.attr('type') === 'password') {
            $pwd.attr('type', 'text');
        }
        else {
            $pwd.attr('type', 'password');
        }
    });
        </script>
        <div class="container-fluid" id="userLoginContainer">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Btn_Submit" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <main role="main" class="login-main">
                        <div class="container">
                            <div id="login-container" class="row justify-content-center align-items-center">
                                <div class="col-md-12 col-lg-8">
                                    <div class=" card shadow border-0">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-7">
                                                    <asp:Image ID="Image_ASR" runat="server" ImageUrl="~/Images/Logos/ASR-Logo.png" AlternateText="ASR Techies" CssClass="img-fluid" />
                                                </div>
                                                <div class="col-md-5" id="loginside">
                                                    <form>
                                                        <%--<h1>
                                                            <asp:Label ID="lblHeader" CssClass="h3 mb-3 font-weight-normal text-center" runat="server" Text="ASR"></asp:Label>
                                                        </h1>--%>
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-prepend">
                                                                <label class="input-group-text" for="txtusername">
                                                                    <i class="fa fa-user"></i>
                                                                </label>
                                                            </div>
                                                            <input type="text" id="txtusername" class="form-control" placeholder="Username" runat="server" required="" autofocus="autofocus" />
                                                        </div>
                                                        <div class="input-group mb-3">
                                                            <div class="input-group-prepend">
                                                                <label class="input-group-text" for="txtpassword">
                                                                    <i class="fa fa-lock"></i>
                                                                </label>
                                                            </div>
                                                            <input type="password" id="txtpassword" class="form-control" placeholder="Password" runat="server" required=""/>
                                                            
                                                        </div>
                                                        <div class="row no-gutters">
                                                            <div class="col-md-6">
                                                                <label>
                                                                    <input type="checkbox" value="remember-me" id="chkRememberMe" runat="server" />
                                                                    Remember me
                                                                </label>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <a href="~/Registrations/ResetPassword.aspx" id="ForgotID" runat="server">Forgot Password</a>
                                                            </div>
                                                        </div>
                                                        <asp:Button ID="Btn_Submit" runat="server" CssClass="btn btn-primary btn-block" OnClick="Btn_Submit_Click" Text="Login" />
                                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        <p class="mt-4 mb-3 text-muted" style="font-size: 12px">
                                                            &copy;&nbsp;<%=DateTime.Now.Year %>-<%=DateTime.Now.Year+1 %>ASR Techies. All Rights Reserved.
                                                        </p>
                                                    </form>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </main>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
