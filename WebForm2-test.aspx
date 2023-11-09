<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm2-test.aspx.vb" Inherits="SemesterProject.WebForm2_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Page</title>
    <style>
        body {
            background-color: #0B0C10;
            color: #C5C6C7;
            font-family: Arial, sans-serif;
            text-align: center;
        }

        h1 {
            color: #66FCF1;
        }

        table {
            margin: 0 auto;
            border-collapse: collapse;
            text-align: left;
        }

        th, td {
            padding: 10px;
            border: 1px solid #C5C6C7;
        }

        th {
            background-color: #1F2833;
            color: #66FCF1;
        }

        input[type="text"], select {
            width: 100%;
            box-sizing: border-box;
            padding: 5px;
        }

        input[type="submit"] {
            background-color: #45A29E;
            color: #C5C6C7;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
        }

        input[type="submit"]:hover {
            background-color: #66FCF1;
            color: #0B0C10;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Teacher Page</h1>

        <div>
            <label for="semester">Enter Semester Number:</label>
            <input type="text" id="semester" runat="server" />
            <asp:Button runat="server" ID="btnGetCourses" Text="Get Courses" OnClick="btnGetCourses_Click" />
        </div>

        <br />

        <table runat="server" id="tblCourses" visible="false">
            <tr>
                <th>Course ID</th>
            </tr>
        </table>

        <br />

        <div>
            <asp:ListBox runat="server" ID="lstStudents" SelectionMode="Multiple"></asp:ListBox>
        </div>

        <br />

        <table runat="server" id="tblMarks" visible="false">
            <tr>
                <th>Username</th>
                <th>Course ID</th>
                <th>Marks</th>
            </tr>
        </table>

        <br />

        <asp:Button runat="server" ID="btnSubmit" Text="Submit Marks" OnClick="btnSubmit_Click" visible="false" />

        <br />
        <br />

        <asp:Label runat="server" ID="lblResult" Visible="false" />
    </form>
</body>
</html>