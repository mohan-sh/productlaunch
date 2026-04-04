<%@ Page Title="Admin Dashboard" Language="C#" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs"
    Inherits="ProductLaunch.Web.Admin.Dashboard" %>
<!DOCTYPE html>
<html>
<head>
    <title>Admin Dashboard</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
<div class="container" style="margin-top:30px;">
    <form id="form1" runat="server">
        <div class="clearfix">
            <h2 style="display:inline-block;">
                Welcome, <asp:Label ID="lblWelcome" runat="server" />
            </h2>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger pull-right" OnClick="btnLogout_Click" />
        </div>
        <hr />
        <asp:Label ID="lblTotal" runat="server" CssClass="lead" />
        <div class="row" style="margin-top:15px; margin-bottom:15px;">
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" />
            </div>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" />
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search name or email" />
            </div>
            <div class="col-sm-3">
                <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnFilter_Click" />
                <asp:Button ID="btnExport" runat="server" Text="Export CSV" CssClass="btn btn-default" OnClick="btnExport_Click" />
            </div>
        </div>
        <asp:GridView ID="gvProspects" runat="server" AutoGenerateColumns="false"
            CssClass="table table-bordered table-striped"
            EmptyDataText="No prospects found">
            <Columns>
                <asp:BoundField DataField="FirstName"    HeaderText="First Name" />
                <asp:BoundField DataField="LastName"     HeaderText="Last Name" />
                <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                <asp:BoundField DataField="CompanyName"  HeaderText="Company" />
                <asp:BoundField DataField="Country.CountryName" HeaderText="Country" />
                <asp:BoundField DataField="Role.RoleName"       HeaderText="Role" />
            </Columns>
        </asp:GridView>
    </form>
</div>
</body>
</html>
