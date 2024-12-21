<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="UserManagementApp.UpdateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>   
    <div class="modal-dialog modal-fullscreen-lg-down">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5 mb-4" id="exampleModalLabel">Update User</h1>
        
      </div>
          <div class="modal-body">
        <div class="row">
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
<%--                AssociatedControlID="txtUserName"--%>
               <asp:Label ID="lblUserName" runat="server" Text="User Name" ></asp:Label>
               <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" EnableViewState="true" ClientIDMode="Predictable"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Please Enter User Name" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
               <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No." AssociatedControlID="txtMobileNo"></asp:Label>
               <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Please Enter Mobile Number" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
             <asp:Label ID="lblEmail" runat="server" Text="E-mail" AssociatedControlID="txtEmail"></asp:Label>
             <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please Enter Email ID" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please Enter Valid Email" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SubmitGroup">*</asp:RegularExpressionValidator>
            </div>
          </div>
         <%-- <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
               <asp:Label ID="lblAddress" runat="server" Text="Address" AssociatedControlID="txtAddress"></asp:Label>
               <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" EnableViewState="true" ClientIDMode="Predictable"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Please Enter Address" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
            </div>
          </div>--%>
             <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
               <div class="form-group">
                    <asp:Label ID="lblRole" runat="server" Text="Role" AssociatedControlID="ddlRole"></asp:Label>
                   
                   <asp:DropDownList ID="ddlRole" runat="server" class="form-select" >

<%--                   <asp:ListItem>Select Role</asp:ListItem>
                   <asp:ListItem>Admin</asp:ListItem>
                   <asp:ListItem>User</asp:ListItem>
                    <asp:ListItem>Guest</asp:ListItem>--%>
                   </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRole" Display="Dynamic" ErrorMessage="Please Enter Role" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup" InitialValue="Select Role">*</asp:RequiredFieldValidator>
                <%-- <asp:TextBox ID="txtRole" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRole" Display="Dynamic" ErrorMessage="Please Enter Role" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
               --%>
               </div>
           </div>

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                    <asp:Label ID="LabelRegion" runat="server" Text="Region" AssociatedControlID="ddlRegion"></asp:Label>

                    <asp:DropDownList ID="ddlRegion" runat="server" class="form-select"  AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">


<%--                        <asp:ListItem>Select Region</asp:ListItem>--%>

                    </asp:DropDownList>
                    <%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlRegion" Display="Dynamic" ErrorMessage="Please Enter Region" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup" InitialValue="Select Region">*</asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                    <asp:Label ID="LabelCircle" runat="server" Text="Circle" AssociatedControlID="ddlCircle"></asp:Label>

                    <asp:DropDownList ID="ddlCircle" runat="server" class="form-select"  AutoPostBack="true" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">

<%--                        <asp:ListItem>Select Circle</asp:ListItem>--%>

                    </asp:DropDownList>
                    <%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlCircle" Display="Dynamic" ErrorMessage="Please Enter Circle" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup" InitialValue="Select Circle">*</asp:RequiredFieldValidator>--%>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                    <asp:Label ID="LabelDivision" runat="server" Text="Division" AssociatedControlID="ddlDivision"></asp:Label>

                    <asp:DropDownList ID="ddlDivision" runat="server" class="form-select">

<%--                        <asp:ListItem>Select Division</asp:ListItem>--%>

                    </asp:DropDownList>
                    <%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlDivision" Display="Dynamic" ErrorMessage="Please Enter Division" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup" InitialValue="Select Division">*</asp:RequiredFieldValidator>--%>
                </div>
            </div>


          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
               <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="txtPassword"></asp:Label>
               <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Please Enter Password" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="form-group">
               <asp:Label ID="lblConfirmPass" runat="server" Text="Confirm Password" AssociatedControlID="txtConfirmPass"></asp:Label>
               <asp:TextBox ID="txtConfirmPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirmPass" Display="Dynamic" ErrorMessage="Please Enter Confirm Password" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SubmitGroup">*</asp:RequiredFieldValidator>
            </div>
          </div>

            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
    <div class="form-group">
       <asp:Label ID="Label1" runat="server" Text="" AssociatedControlID="checkboxid"></asp:Label>
       <asp:CheckBox ID="checkboxid" CssClass="form-check" runat="server" Text ="Block User"></asp:CheckBox>
    </div>
  </div>
         
         
        </div>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btnClose" CssClass="btn btn-secondary me-2" runat="server" Text="Close" OnClick ="btn_Close" />
        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnSave_Click" ValidationGroup="SubmitGroup"/>
      </div>
    </div>
  </div>
    </main>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="#CCCCCC" Font-Size="Larger" ForeColor="Red" ValidationGroup="SubmitGroup" />
</asp:Content>
