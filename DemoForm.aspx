<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoForm.aspx.cs" Inherits="UserManagementApp.DemoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--            <i class="bi bi-person-plus-fill me-2"></i>Add--%>

         
<%--  <div class="modal-dialog modal-fullscreen-lg-down">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">Add User</h1>
        <button
          type="button"
          class="btn-close"
          data-bs-dismiss="modal"
          aria-label="Close"
        ></button>
      </div>
      <div class="modal-body">
        <div class="row">
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
               <asp:Label ID="lblUserName" runat="server" Text="User Name" AssociatedControlID="txtUserName"></asp:Label>
               <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Please Enter User Name" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
               <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No." AssociatedControlID="txtMobileNo"></asp:Label>
               <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Please Enter Mobile Number" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
             <asp:Label ID="lblEmail" runat="server" Text="E-mail" AssociatedControlID="txtEmail"></asp:Label>
             <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please Enter Email ID" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
               <asp:Label ID="lblAddress" runat="server" Text="Address" AssociatedControlID="txtAddress"></asp:Label>
               <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Please Enter Address" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
               <asp:Label ID="lblPersonalInfo" runat="server" Text="Personal Info" AssociatedControlID="txtPersonalInfo"></asp:Label>
               <asp:TextBox ID="txtPersonalInfo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPersonalInfo" Display="Dynamic" ErrorMessage="Please Enter Personal Info" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
               <asp:Label ID="lblOfficeId" runat="server" Text="Office Id" AssociatedControlID="txtOfficeId"></asp:Label>
               <asp:TextBox ID="txtOfficeId" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOfficeId" Display="Dynamic" ErrorMessage="Please Enter Office ID" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
              <asp:Label ID="lblRole" runat="server" Text="Role" AssociatedControlID="txtRole"></asp:Label>
              <asp:TextBox ID="txtRole" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRole" Display="Dynamic" ErrorMessage="Please Enter Role" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
              <asp:Label ID="lblLoginId" runat="server" Text="Login Id" AssociatedControlID="txtLoginId"></asp:Label>
               <asp:TextBox ID="txtLoginId" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtLoginId" Display="Dynamic" ErrorMessage="Please Enter Login ID" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </div>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btnClose" CssClass="btn btn-secondary" runat="server" Text="Close" OnClientClick="return false;" data-bs-dismiss="modal" />
        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" />
      </div>
    </div>
  </div>--%>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
</div>
    </form>
</body>
</html>
