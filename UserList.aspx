<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="UserManagementApp.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main>
   <%-- <div class="d-flex justify-content-end mb-3">
     <asp:LinkButton 
         ID="btnAdd" 
         runat="server" 
         CssClass="btn btn-primary btn-sm d-flex align-items-center" 
         OnClick="btnAdd_Click" 
         UseSubmitBehavior="false">
         <i class="bi bi-person-plus-fill me-2"></i>
         <span>Add</span>
     </asp:LinkButton>
 </div>--%>
     <%--<div class="d-flex justify-content-end mb-3">
     <asp:LinkButton 
     class="btn btn-primary btnAdd btn-sm mb-3"
     id="btnAdd"
     runat="server" 
     OnClick ="addUserClicked"
   >
     <i class="bi bi-person-plus-fill me-2"></i>Add User</asp:LinkButton>


 </div>--%>
         <div id="userDetails">
         <div class="table-reponsive pb-3">
             <%--DataSourceID="SqlDataSource1"--%>
     <asp:GridView ID="GridView1"   CssClass="table table-sm table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="objectid" ClientIDMode="Predictable" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
         <Columns>
             <asp:TemplateField HeaderText="Sr. No." InsertVisible="False" SortExpression="objectid">
                 <EditItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToInt32(Eval("objectid")) %>'></asp:Label>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("objectid") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="User Name" SortExpression="username">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("username") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Mobile No." SortExpression="mobileno">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("phonenumber") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label3" runat="server" Text='<%# Bind("phonenumber") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Email ID" SortExpression="email">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("emailid") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label4" runat="server" Text='<%# Bind("emailid") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <%--<asp:TemplateField HeaderText="Address" SortExpression="address">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("address") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>--%>
             <asp:TemplateField HeaderText="Role" SortExpression="role">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("role") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label6" runat="server" Text='<%# Bind("role") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>


             <asp:TemplateField HeaderText="Region" SortExpression="region">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("region") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label7" runat="server" Text='<%# Bind("region") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Circle" SortExpression="circle">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("circle") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label8" runat="server" Text='<%# Bind("circle") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Division" SortExpression="division">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("division") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label9" runat="server" Text='<%# Bind("division") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
          <%--   <asp:TemplateField HeaderText="Password" SortExpression="password">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("password") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label8" runat="server" Text='<%# Bind("password") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Confirm Password" SortExpression="confirmpass">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("confirmpass") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label7" runat="server" Text='<%# Bind("confirmpass") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>--%>
             <asp:TemplateField HeaderText="Edit">
            <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditRow" CommandArgument='<%# Eval("objectid") %>' CssClass="editUser text-center text-success" ToolTip="Edit">
            <i class="bi bi-pencil-square"></i>
        </asp:LinkButton>
<%--                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Active") %>' />--%>
            </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
                <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteRow"  CommandArgument='<%# Eval("objectid") %>' CssClass="btn-icon btn-delete text-danger" ToolTip="Delete">
            <i class="bi bi-trash"></i>
        </asp:LinkButton>
            </ItemTemplate>
                 
            </asp:TemplateField>        

         </Columns>
         <%--<FooterStyle BackColor="#CCCCCC" />
         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
         <RowStyle BackColor="White" />
         <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F1F1F1" />
         <SortedAscendingHeaderStyle BackColor="#808080" />
         <SortedDescendingCellStyle BackColor="#CAC9C9" />
         <SortedDescendingHeaderStyle BackColor="#383838" />--%>
   </asp:GridView>
      </div>
             </div>
        <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:PostgreSQL 14 %>" 
    SelectCommand="SELECT [Id], [username], [mobileno], [email], [address], [role], [region],[password], [confirmpass] FROM [Admin]" 
    UpdateCommand="UPDATE [Admin] SET [username] = @username, [mobileno] = @mobileno, [email] = @email, [address] = @address, [role] = @role, [password] = @password, [confirmpass] = @confirmpasse WHERE [Id] = @Id"
    DeleteCommand="DELETE FROM [Admin] WHERE [Id] = @Id">
</asp:SqlDataSource>--%>
  <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbum %>" DeleteCommand="DELETE FROM [Admin] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Admin] ([username], [mobileno], [email], [address], [role], [password], [confirmpass]) VALUES (@username, @mobileno, @email, @address, @role, @password, @confirmpass)" SelectCommand="SELECT * FROM [Admin]" UpdateCommand="UPDATE [Admin] SET [username] = @username, [mobileno] = @mobileno, [email] = @email, [address] = @address, [role] = @role, [password] = @password, [confirmpass] = @confirmpass WHERE [Id] = @Id">
       <DeleteParameters>
           <asp:Parameter Name="Id" Type="Int32" />
       </DeleteParameters>
       <InsertParameters>
           <asp:Parameter Name="username" Type="String" />
           <asp:Parameter Name="mobileno" Type="String" />
           <asp:Parameter Name="email" Type="String" />
           <asp:Parameter Name="address" Type="String" />
           <asp:Parameter Name="role" Type="String" />
           <asp:Parameter Name="password" Type="String" />
           <asp:Parameter Name="confirmpass" Type="String" />
       </InsertParameters>
       <UpdateParameters>
           <asp:Parameter Name="username" Type="String" />
           <asp:Parameter Name="mobileno" Type="String" />
           <asp:Parameter Name="email" Type="String" />
           <asp:Parameter Name="address" Type="String" />
           <asp:Parameter Name="role" Type="String" />
           <asp:Parameter Name="password" Type="String" />
           <asp:Parameter Name="confirmpass" Type="String" />
           <asp:Parameter Name="Id" Type="Int32" />
       </UpdateParameters>
   </asp:SqlDataSource>--%>
 </main>
  <%--  <div
      class="modal fade"
      id="pageModal"
      tabindex="-1"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-fullscreen-lg-down">
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
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                   <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No." AssociatedControlID="txtMobileNo"></asp:Label>
                   <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                 <asp:Label ID="lblEmail" runat="server" Text="E-mail" AssociatedControlID="txtEmail"></asp:Label>
                 <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                   <asp:Label ID="lblAddress" runat="server" Text="Address" AssociatedControlID="txtAddress"></asp:Label>
                   <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                   <asp:Label ID="lblPersonalInfo" runat="server" Text="Personal Info" AssociatedControlID="txtPersonalInfo"></asp:Label>
                   <asp:TextBox ID="txtPersonalInfo" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                   <asp:Label ID="lblOfficeId" runat="server" Text="Office Id" AssociatedControlID="txtOfficeId"></asp:Label>
                   <asp:TextBox ID="txtOfficeId" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <asp:Label ID="lblRole" runat="server" Text="Role" AssociatedControlID="txtRole"></asp:Label>
                  <asp:TextBox ID="txtRole" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <asp:Label ID="lblLoginId" runat="server" Text="Login Id" AssociatedControlID="txtLoginId"></asp:Label>
                   <asp:TextBox ID="txtLoginId" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <asp:Button ID="btnClose" CssClass="btn btn-secondary" runat="server" Text="Close" OnClientClick="return false;" data-bs-dismiss="modal" />
            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" />
          </div>
        </div>
      </div>
    </div>
    <div
      class="modal fade"
      id="userUpdateModel"
      tabindex="-1"
      aria-labelledby="userUpdateModelLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-fullscreen-lg-down">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="userUpdateModelLabel">
              Update User
            </h1>
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
                  <label for="User Name">User Name</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label for="User Name">Mobile No.</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label for="">E-mail</label>
                  <input type="mail" class="form-control" />
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label for="">Address</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label for="">Personal Info</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label for="User Name">Office Id</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label for="User Name">Role</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label for="">Login Id</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button
              type="button"
              class="btn btn-secondary"
              data-bs-dismiss="modal"
            >
              Close
            </button>
            <button type="button" class="btn btn-primary">Save</button>
          </div>
        </div>
      </div>
    </div>--%>
   
   
</asp:Content>
