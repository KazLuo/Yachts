﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApplyLayout2.WebForm2" EnableEventValidation="false" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Bhumlu | B4+ admin template by Srthemesvilla</title>
    
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0">
    <meta name="description" content="Bhumlu Bootstrap admin template made using Bootstrap 4, it has tons of ready made feature, UI components, pages which completely fulfills any dashboard needs." />
    <meta name="keywords" content="Bhumlu, bootstrap admin template, bootstrap admin panel, bootstrap 4 admin template, admin template">
    <meta name="author" content="Srthemesvilla" />
    <link rel="icon" type="image/x-icon" href="assets/img/favicon.ico">

    <!-- Google fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700" rel="stylesheet">

    <!-- Icon fonts -->
    <link rel="stylesheet" href="assets/fonts/fontawesome.css">
    <link rel="stylesheet" href="assets/fonts/ionicons.css">
    <link rel="stylesheet" href="assets/fonts/linearicons.css">
    <link rel="stylesheet" href="assets/fonts/open-iconic.css">
    <link rel="stylesheet" href="assets/fonts/pe-icon-7-stroke.css">
    <link rel="stylesheet" href="assets/fonts/feather.css">

    <!-- Core stylesheets -->
    <link rel="stylesheet" href="assets/css/bootstrap-material.css">
    <link rel="stylesheet" href="assets/css/shreerang-material.css">
    <link rel="stylesheet" href="assets/css/uikit.css">

    <!-- Libs -->
    <link rel="stylesheet" href="assets/libs/perfect-scrollbar/perfect-scrollbar.css">
    <!-- Page -->
    <link rel="stylesheet" href="assets/css/pages/authentication.css">
</head>
<body>
    <form id="form1" runat="server">
        <!-- [ Preloader ] Start -->
        <div class="page-loader">
            <div class="bg-primary"></div>
        </div>
        <!-- [ Preloader ] End -->

        <!-- [ content ] Start -->
        <div class="authentication-wrapper authentication-1 px-4">
            <div class="authentication-inner py-5">

                <!-- [ Logo ] Start -->
                <div class="d-flex justify-content-center align-items-center">
                    <div class="ui-w-60">
                        <div class="w-100 position-relative">
                            <img src="assets/img/logo-dark.png" alt="Brand Logo" class="img-fluid">
                        </div>
                    </div>
                </div>
                <!-- [ Logo ] End -->

                <!-- [ Form ] Start -->
                <form class="my-5">
                    <div class="form-group">
                        <label class="form-label">Name</label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        <%-- <input type="text" class="form-control">--%>
                        <div class="clearfix"></div>
                    </div>
                    <div class="form-group">
                        <label class="form-label d-flex justify-content-between align-items-end">
                            <span>Password</span>
                            <a href="pages_authentication_password-reset.html" class="d-block small">Forgot password?</a>
                        </label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <%-- <input type="password" class="form-control">--%>
                        <div class="clearfix"></div>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <div class="d-flex justify-content-between align-items-center m-0">
                        <label class="custom-control custom-checkbox m-0">
                            <input type="checkbox" class="custom-control-input">
                            <span class="custom-control-label">Remember me</span>
                        </label>
                        <asp:Button ID="Button1" runat="server" Text="Sign In" CssClass="btn-primary btn-block" style="padding: 0.5rem 1rem; border-radius: 0.125rem; border: 0px;" Width="100px" OnClick="Button1_Click" />
                        <br />
                       <%-- <button type="button" class="btn btn-primary">Sign In</button>--%>
                    </div>
                </form>
                <!-- [ Form ] End -->

                <div class="text-center text-muted">
                    Don't have an account yet?
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Sign Up" NavigateUrl="~/Register.aspx"></asp:HyperLink>
             <%--   <a href="pages_authentication_register-v1.html">Sign Up</a>--%>
                </div>

            </div>
        </div>
        <!-- [ content ] End -->

        <!-- Core scripts -->
        <script src="assets/js/pace.js"></script>
        <script src="assets/js/jquery-3.3.1.min.js"></script>
        <script src="assets/libs/popper/popper.js"></script>
        <script src="assets/js/bootstrap.js"></script>
        <script src="assets/js/sidenav.js"></script>
        <script src="assets/js/layout-helpers.js"></script>
        <script src="assets/js/material-ripple.js"></script>

        <!-- Libs -->
        <script src="assets/libs/perfect-scrollbar/perfect-scrollbar.js"></script>

        <!-- Demo -->
        <script src="assets/js/demo.js"></script>
        <script src="assets/js/analytics.js"></script>
    </form>
</body>
</html>
