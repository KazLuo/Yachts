﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ApplyLayout2.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <!-- [ Logo ] End -->

                <!-- [ Form ] Start -->
                <form class="my-5">
                    <div class="form-group">
                        <label class="form-label">Your name</label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        <%--<input type="text" class="form-control">--%>
                        <div class="clearfix"></div>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Your email</label>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                        <%--  <input type="text" class="form-control">--%>
                        <div class="clearfix"></div>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Password</label>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <%-- <input type="password" class="form-control">--%>
                        <div class="clearfix"></div>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="Sign Up" CssClass=" btn-primary btn-block mt-4" OnClick="Button1_Click" ViewStateMode="Inherit" UseSubmitBehavior="True" style="border:0px;padding: 0.5rem 1rem;"/>
                        <%-- <button type="button" class="btn btn-primary btn-block mt-4">Sign Up</button>--%>
                    <div class="bg-lightest text-muted small p-2 mt-4">
                        By clicking "Sign Up", you agree to our
                    <a href="javascript:void(0)">terms of service and privacy policy</a>. We’ll occasionally send you account related emails.
                    </div>
                </form>
                <!-- [ Form ] End -->

                <div class="text-center text-muted">
                    Already have an account?
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Sign In" NavigateUrl="~/Login.aspx"></asp:HyperLink>
               <%-- <a href="pages_authentication_login-v1.html">Sign In</a>--%>
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
