<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="UserManagementApp.ForgotPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link href="css/bootstrap-5.3.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: linear-gradient(to right, #e0eafc, #cfdef3); /* Light gradient background */
        }
        .card {
            border-radius: 15px;
        }
        .card-header {
            background: linear-gradient(135deg, #6a11cb, #2575fc); /* Modern gradient for header */
            color: white;
        }
        .btn-primary {
            background-color: #6a11cb;
            border-color: #6a11cb;
        }
        .btn-primary:hover {
            background-color: #2575fc;
            border-color: #2575fc;
        }
        .text-primary {
            color: #2575fc !important;
        }
    </style>
    <script src="js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-5">
            <div class="row justify-content-center">
                <div class="col-lg-5 col-md-7">
                    <div class="card border-0 shadow-lg">
                        <div class="card-header text-center">
                            <h4 class="fw-bold">Forgot Password</h4>
                        </div>
                        <div class="card-body">
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Placeholder="Enter your username"></asp:TextBox>
                                <label for="txtUsername">Username</label>
                                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                                    ControlToValidate="txtUsername" 
                                    ErrorMessage="Username is required" 
                                    CssClass="text-danger small"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter new password"></asp:TextBox>
                                <label for="txtNewPassword">New Password</label>
                                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" 
                                    ControlToValidate="txtNewPassword" 
                                    ErrorMessage="New password is required" 
                                    CssClass="text-danger small"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Confirm new password"></asp:TextBox>
                                <label for="txtConfirmPassword">Re-enter New Password</label>
                                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" 
                                    ControlToValidate="txtConfirmPassword" 
                                    ErrorMessage="Please confirm your password" 
                                    CssClass="text-danger small"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvPasswords" runat="server" 
                                    ControlToCompare="txtNewPassword" 
                                    ControlToValidate="txtConfirmPassword" 
                                    ErrorMessage="Passwords do not match" 
                                    CssClass="text-danger small"></asp:CompareValidator>
                            </div>

                            <div class="d-grid">
                                <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="btn btn-primary btn-lg fw-bold" OnClick="btnResetPassword_Click" />
                            </div>
                        </div>
                        <div class="card-footer text-center bg-light">
                            <a href="Default.aspx" class="text-decoration-none small text-primary">Back to Login</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="css/bootstrap-5.3.3-dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
