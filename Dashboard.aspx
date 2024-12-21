<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="UserManagementApp.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>

    <div class="main">
         <h2 class="text-center mb-4">Number of Users</h2>
  <div class="d-flex justify-content-between">
    <div class="card-kpi">
<%--      <div class="kpi-title">Region</div>--%>
         <div class="kpi-title">
              <label for="ddlRegion" class="form-label">Region</label>
        <asp:DropDownList ID="ddlRegion" runat="server" class="form-select form-select-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                <asp:ListItem Value="0">Select Region</asp:ListItem>
                <%--<asp:ListItem Value="1">Option 1.1</asp:ListItem>
                <asp:ListItem Value="2">Option 1.2</asp:ListItem>--%>
            </asp:DropDownList>
             </div>
      <div class="kpi-value text-success">
          <asp:Label ID="lblRegion" runat="server" CssClass="kpi-value-label" Text ="0"></asp:Label>
      </div>
    </div>
    <div class="card-kpi">
      <div class="kpi-title">
           <label for="ddlCircle" class="form-label">Circle</label>
          <asp:DropDownList ID="ddlCircle" runat="server" class="form-select form-select-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">
                <asp:ListItem Value="0">Select Circle</asp:ListItem>
               <%-- <asp:ListItem Value="1">Option 2.1</asp:ListItem>
                <asp:ListItem Value="2">Option 2.2</asp:ListItem>--%>
            </asp:DropDownList>

      </div>
      <div class="kpi-value text-primary">
          <asp:Label ID="lblCircle" runat="server" CssClass="kpi-value-label" Text ="0"></asp:Label>
      </div>
    </div>
    <div class="card-kpi">
      <div class="kpi-title">
            <label for="ddlDivision" class="form-label">Division</label>
          <asp:DropDownList ID="ddlDivision" runat="server" class="form-select form-select-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                <asp:ListItem Value="0">Select Division</asp:ListItem>
               <%-- <asp:ListItem Value="1">Option 3.1</asp:ListItem>
                <asp:ListItem Value="2">Option 3.2</asp:ListItem>--%>
            </asp:DropDownList>

      </div>
      <div class="kpi-value text-warning">
          <asp:Label ID="lblDivision" runat="server" CssClass="kpi-value-label" Text ="0" ></asp:Label>
      </div>
    </div>
    <%--<div class="card-kpi">
      <div class="kpi-title">
          <asp:DropDownList ID="ddlDistrict" runat="server" class="form-select form-select-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                <asp:ListItem Value="0">Select District</asp:ListItem>
               <%-- <asp:ListItem Value="1">Option 4.1</asp:ListItem>
                <asp:ListItem Value="2">Option 4.2</asp:ListItem>--%>
            <%-- </asp:DropDownList>

      </div>
      <div class="kpi-value text-danger">
          <asp:Label ID="lblDistrict" runat="server" CssClass="kpi-value-label" Text ="0" ></asp:Label>
      </div>
    </div>--%>
  </div>
  <%--<div class="row pt-3">
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 mb-2">
      <div class="card p-3 border-0 h-100">
        <div class="card-head">Region</div>
        <div class="card-data"></div>
      </div>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 mb-2">
      <div class="card p-3 border-0 h-100">
        <div class="card-head">Region</div>
        <div class="card-data"></div>
      </div>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
      <div class="card p-3 border-0 h-100">
        <div class="card-head">District</div>
        <div class="card-data"></div>
      </div>
    </div>
    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
      <div class="card p-3 border-0 h-100">
        <div class="card-head">Vilage</div>
        <div class="card-data"></div>
      </div>
    </div>
  </div>
</div>--%>
   
  </body>

</asp:Content>
