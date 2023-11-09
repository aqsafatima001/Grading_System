<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Result.aspx.vb" Inherits="SemesterProject.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        body {
            background-color: #0B0C10;
            color: #C5C6C7;
            font-family: Arial, sans-serif;
        }
        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        table {
            border-collapse: collapse;
            width: 80%;
        }
        th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #C5C6C7;
        }
        th {
            background-color: #1F2833;
            color: #66FCF1;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <h1>Welcome, <asp:Label runat="server" ID="usernameLabel"></asp:Label>!</h1>

        <div class="container">
        <table>
            <tr>
                <th>Course Name</th>
                <th>GPA</th>
                <th>Grade</th>
            </tr>
            <asp:Repeater runat="server" ID="resultRepeater">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("course_name") %></td>
                        <td><%# Eval("gpa") %></td>
                        <td><%# Eval("grade") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
