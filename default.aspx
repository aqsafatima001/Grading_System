<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="SemesterProject._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CssFiles/CustomStyleSheet.css" rel="stylesheet" />
    <link href="CssFiles/Navigation.css" rel="stylesheet" />
    <title>Student Grading System</title>
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <ul>
                <li><a href="#">Home</a></li>
                <li><a href="About.aspx">About</a></li>
                <li><a href="Contact.aspx">Contact</a></li>
            </ul>
        </nav>
        <h1>Welcome to PIEAS Student Grading System</h1>
        <p>Please select your role:</p>
        <div style="text-align: center;">
            <asp:Button ID="btnStudent" runat="server" Text="Login as Student" CssClass="btn" />
            <asp:Button ID="btnTeacher" runat="server" Text="Login as Teacher" CssClass="btn" />

            <%--Registration Buttons--%>
            <asp:Button ID="btnRegTeacher" runat="server" Text="Register as Teacher" CssClass="btn" />
            <asp:Button ID="btnRegStudent" runat="server" Text="Register as Studenr" CssClass="btn" />
        </div>
    </form>
</body>
</html>
