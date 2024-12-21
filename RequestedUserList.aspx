<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RequestedUserList.aspx.cs" Inherits="UserManagementApp.RequestedUserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    
    <script>
        // Function to show the modal
        function showModal() {
            $('#exampleModal').modal('show');
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="userDetails">
        <div class="table-responsive pb-3">
            <asp:GridView ID="Gridview_requestedUSer" CssClass="table table-sm table-striped table-bordered" runat="server" AutoGenerateColumns="False" ClientIDMode="Predictable" OnRowCommand="Gridview_requestedUSer_RowCommand">
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
                        <ItemTemplate>
                            <asp:Label ID="LabelUserName" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mobile No." SortExpression="mobileno">
                        <ItemTemplate>
                            <asp:Label ID="LabelMobileNo" runat="server" Text='<%# Bind("phonenumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email ID" SortExpression="email">
                        <ItemTemplate>
                            <asp:Label ID="LabelEmailID" runat="server" Text='<%# Bind("emailid") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Role" SortExpression="role">
                        <ItemTemplate>
                            <asp:Label ID="LabelRole" runat="server" Text='<%# Bind("role") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Region" SortExpression="region">
                        <ItemTemplate>
                            <asp:Label ID="LabelRegion" runat="server" Text='<%# Bind("region") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Circle" SortExpression="circle">
                        <ItemTemplate>
                            <asp:Label ID="LabelCircle" runat="server" Text='<%# Bind("circle") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Division" SortExpression="division">
                        <ItemTemplate>
                            <asp:Label ID="LabelDivision" runat="server" Text='<%# Bind("division") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Approval Status" SortExpression="approvalstatus">
     <ItemTemplate>
         <asp:Label ID="LabelApprovalStatus" runat="server" Text='<%# Bind("approvalstatus") %>'></asp:Label>
     </ItemTemplate>
 </asp:TemplateField>

                    <asp:TemplateField HeaderText="Approve">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnApprove" runat="server" CommandName="Approve" CommandArgument='<%# Eval("objectid") %>' CssClass="btn btn-success text-white" ToolTip="Approve">
                                Approve
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Reject">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnReject" runat="server" CommandName="Reject" CommandArgument='<%# Eval("objectid") %>' CssClass="btn btn-danger text-white" ToolTip="Reject">
                                Reject
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Hierarchy Selection</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:DropDownList ID="ddlOptions" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Option 1" Value="1" />
                            <asp:ListItem Text="Option 2" Value="2" />
                            <asp:ListItem Text="Option 3" Value="3" />
                        </asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
   

     <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.4.4/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</asp:Content>
