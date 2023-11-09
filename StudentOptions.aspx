<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StudentOptions.aspx.vb" Inherits="SemesterProject.StudentOptions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CssFiles/Navigation.css" rel="stylesheet" />
    <link href="CssFiles/StudentOptions.css" rel="stylesheet" />
    <title></title>
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

             <div id="content">
            <h1>Welcome to the Student Portal</h1>
            <asp:Button ID="btnRegisterCourses" runat="server" CssClass="button" Text="Register Courses" OnClick="btnRegisterCourses_Click" />
            <asp:Button ID="btnCheckResults" runat="server" CssClass="button" Text="Check Results" OnClick="btnCheckResults_Click" />
        </div>
        
    </form>
</body>
</html>
