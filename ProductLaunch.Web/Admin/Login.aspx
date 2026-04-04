<%@ Page Title="Admin Login" Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="ProductLaunch.Web.Admin.Login" %>
<!DOCTYPE html>
<html>
<head>
    <title>Admin Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
<div class="container" style="max-width:400px; margin-top:100px;">
    <h2>Admin Login</h2>
    <form id="form1" runat="server">
        <div class="form-group">
            <label>Username</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label>Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
        </div>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
    </form>
</div>
</body>
</html>
