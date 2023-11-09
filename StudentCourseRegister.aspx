
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StudentCourseRegister.aspx.vb" Inherits="SemesterProject.StudentCourseRegister" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CssFiles/StudentCourseRegister.css" rel="stylesheet" />
    <title>Course Registration</title>
</head>
<body>
    <h1>Course Registration</h1>
    <form id="semesterForm" runat="server">
        <label for="semesterSelect">Select Semester:</label>
        <select id="semesterSelect" name="semesterSelect">
            <option value="">--Select--</option>
            <% For i = 1 To 8 %>
                <option value="<%= i %>">Semester <%= i %></option>
            <% Next %>
        </select>

        <asp:Button ID="SubmitBtn" runat="server" Text="Select Semester" OnClick="SubmitBtn_Click" />

        <asp:Literal ID="courseList" runat="server" Visible="false" />
        <asp:Label ID="successLabel" runat="server" Visible="false" Text="Course registration successful!" />

        <asp:Button ID="RegisterBtn" runat="server" Text="Register" Visible="false" OnClick="RegisterBtn_Click" />

    </form>

</body>
</html>