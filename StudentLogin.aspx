<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StudentLogin.aspx.vb" Inherits="SemesterProject.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CssFiles/StudentLogin.css" rel="stylesheet" />
    <link href="CssFiles/Navigation.css" rel="stylesheet" />
    <title>Student Login</title>
    <style type="text/css">
    </style>
</head>
<body>

    <nav>
            <ul>
                <li><a href="default.aspx">Home</a></li>
                <li><a href="About.aspx">About</a></li>
                <li><a href="Contact.aspx">Contact</a></li>
            </ul>
        </nav>

    <form id="form1" runat="server">
    <div class="container">
        <h1>Student Login</h1>
        <label for="txtUsername">Username:</label>
        <input type="text" id="txtUsername" runat="server" />
        <label for="txtPassword">Password:</label>
        <input type="password" id="txtPassword" runat="server" />
        <asp:Label ID="lblError" runat="server" CssClass="error" Visible="false"></asp:Label>
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
    </div>
</form>
</body>
</html>