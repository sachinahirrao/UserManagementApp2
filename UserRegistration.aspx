<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="UserManagementApp.UserRegistration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <link href="css/bootstrap-5.3.3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/datatables.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" />
    <link href="css/dashboard.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-5">
            <div class="row justify-content-center">
                <div class="col-lg-10">
                    <div class="card">
                        <div class="card-header bg-primary text-white">
                            <h3 class="text-center">User Registration</h3>
                        </div>
                        <div class="card-body">
                            <div class="row g-3">
                                <!-- User Name -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblUserName" runat="server" Text="User Name" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Please Enter User Name" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <!-- Mobile Number -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No." CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Please Enter Mobile Number" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter a valid 10-digit mobile number." ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[0-9]{10}$" ValidationGroup="SubmitGroup">*</asp:RegularExpressionValidator>

                                    </div>
                                </div>
                                <!-- Email -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblEmail" runat="server" Text="E-mail" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please Enter Email ID" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please Enter Valid Email" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SubmitGroup">*</asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <!-- Role -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblRole" runat="server" Text="Role" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select">
                                          <%--  <asp:ListItem Text="Select Role" Value="0" />
                                            <asp:ListItem Text="Admin" Value="Admin" />
                                            <asp:ListItem Text="User" Value="User" />
                                            <asp:ListItem Text="Guest" Value="Guest" />--%>
                                        </asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRole" Display="Dynamic" ErrorMessage="Please Enter Role" ForeColor="Red" SetFocusOnError="True"  InitialValue="Select Role" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <!-- Region -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="LabelRegion" runat="server" Text="Region" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlRegion" Display="Dynamic" ErrorMessage="Please Enter Region" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup" InitialValue="Select Region">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <!-- Circle -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="LabelCircle" runat="server" Text="Circle" CssClass="form-label"></asp:Label>
                                        <asp:DropDownList ID="ddlCircle" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlCircle" Display="Dynamic" ErrorMessage="Please Enter Circle" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup" InitialValue="Select Circle">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                    <asp:Label ID="LabelDivision" runat="server" Text="Division" AssociatedControlID="ddlDivision"></asp:Label>

                    <asp:DropDownList ID="ddlDivision" runat="server" class="form-select">

<%--                        <asp:ListItem>Select Division</asp:ListItem>--%>

                    </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlDivision" Display="Dynamic" ErrorMessage="Please Enter Division" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup" InitialValue="Select Division">*</asp:RequiredFieldValidator>
                </div>
            </div>
                                <!-- Password -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Please Enter Password" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <!-- Confirm Password -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblConfirmPass" runat="server" Text="Confirm Password" CssClass="form-label"></asp:Label>
                                        <asp:TextBox ID="txtConfirmPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirmPass" Display="Dynamic" ErrorMessage="Please Enter Confirm Password" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer text-center">
                            <asp:Button ID="btnClose" CssClass="btn btn-secondary me-2" runat="server" Text="Close" OnClick="btn_Close" />
                            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="SubmitGroup" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="#CCCCCC" Font-Size="Larger" ForeColor="Red" ValidationGroup="SubmitGroup" />

    </form>
    <script src="js/datatables.js"></script>
    <script src="js/datatables.min.js"></script>
    <script src="js/script.js"></script>
    <script src="css/bootstrap-5.3.3-dist/js/bootstrap.bundle.js"></script>
</body>

</html>
