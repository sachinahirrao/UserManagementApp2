<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserManagementApp.Default" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>
    <link
      rel="stylesheet"
      href="css/bootstrap-5.3.3-dist/css/bootstrap.min.css"
    />
    <link href="css/login.css" rel="stylesheet" />
    <link
      rel="stylesheet"
      href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css"
    />
  </head>
  <body>
    <div class="container-fluid d-flex justify-content-end login-container p-3">
      <div
        class="col-lg-9 col-md-9 col-sm-9 col-xs-12 col-12 ps-3 pe-3 d-xs-none"
      >
        <div class="page-title">User Management</div>
        <div class="login-aside"></div>
      </div>
      <section class="col-lg-3 col-md-3 col-sm-3 col-xs-12 col-12">
        <form id="form1" runat="server">
          <div class="loginSection">
            <div class="d-flex">
              <div class="loginCompLogo"></div>
              <div class="companyName">Digital Project Management System</div>
            </div>
            <div class="form-group mb-3">
              <div class="d-flex">
                <div class="userIcon"><i class="bi bi-person-circle"></i></div>
                <asp:TextBox
                  ID="txtUserName"
                  class="form-control"
                  placeholder="User Name"
                  runat="server"
                />
              </div>
              <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                runat="server"
                ErrorMessage="Please Enter User Name"
                ControlToValidate="txtUserName"
                Display="Dynamic"
                ForeColor="Red"
                SetFocusOnError="True"
              ></asp:RequiredFieldValidator>
            </div>
            <div class="form-group mb-3">
              <div class="d-flex">
                <div class="PasswordIcon"><i class="bi bi-lock"></i></div>
                <asp:TextBox
                  ID="txtPassword"
                  class="form-control"
                  placeholder="Password"
                  runat="server"
                  TextMode="Password"
                />
                <div class="iconEyeClose text-end" onclick="togglePasswordVisibility()">
                  <i id="eyeIcon" class="bi bi-eye-slash"></i>
                </div>
              </div>
              <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2"
                runat="server"
                ErrorMessage="Please Enter Password"
                ControlToValidate="txtPassword"
                Display="Dynamic"
                ForeColor="Red"
                SetFocusOnError="True"
              ></asp:RequiredFieldValidator>
            </div>
            <asp:Button
              ID="idBtnLogin"
              runat="server"
              class="btn btn-primary mb-3 w-100"
              Text="Log In"
              OnClick="Login_Click"
            />
            <div class="text-end mb-3">
              <asp:LinkButton
                ID="btnForgotPassword"
                runat="server"
                class="btn btn-link"
                OnClick="ForgotPassword_Click"
              >
                Forgot Password?
              </asp:LinkButton>
            </div>
            <asp:Button
              ID="btnRegister"
              runat="server"
              class="btn btn-secondary w-100"
              Text="Register"
              OnClick="Register_Click"
            />
          </div>
        </form>
      </section>
    </div>
    <script
      type="text/javascript"
      src="css/bootstrap-5.3.3-dist/js/bootstrap.bundle.js"
    ></script>
    <script>
        function togglePasswordVisibility() {
            var passwordInput = document.getElementById('<%= txtPassword.ClientID %>');
            var eyeIcon = document.getElementById('eyeIcon');

            if (passwordInput.type === 'password') {
                passwordInput.type = 'text'; // Show password
                eyeIcon.classList.remove('bi-eye-slash');
                eyeIcon.classList.add('bi-eye');
            } else {
                passwordInput.type = 'password'; // Hide password
                eyeIcon.classList.remove('bi-eye');
                eyeIcon.classList.add('bi-eye-slash');
            }
        }
    </script>
  </body>
</html>
