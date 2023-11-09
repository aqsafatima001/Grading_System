<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="gradingSample2.aspx.vb" Inherits="SemesterProject.gradingSample2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }
        th, td {
            padding: 10px;
            text-align: center;
        }
        th {
            background-color: #4CAF50;
            color: white;
        }
    </style>

<body>
   <form id="form1" runat="server">
        <div>
            <label for="semester">Semester:</label>
            <asp:TextBox ID="semester" runat="server"></asp:TextBox>
            <asp:Button ID="btnShowCourses" runat="server" Text="Show Courses" OnClick="btnShowCourses_Click" />
            <br />
            <asp:DropDownList ID="ddlCourses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:ListBox ID="lstStudents" runat="server" SelectionMode="Multiple"></asp:ListBox>
            <br />
            <asp:DropDownList ID="grade" runat="server"></asp:DropDownList>
           <%-- <asp:Button ID="btnEnterGrades" runat="server" Text="Enter Grades" OnClick="btnEnterGrades_Click" />--%>            
            <br /><br />
            <%--<asp:Button ID="btnShow" runat="server" Text="Show Grades" OnClick="btnShow_Click" />--%>
            <br /><br />
            <asp:GridView ID="gvGrades" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="Student" />
                    <asp:TemplateField HeaderText="Marks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtMarks" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="grade" HeaderText="Grade" />
                    <asp:BoundField DataField="gpa" HeaderText="GPA" />
                </Columns>
            </asp:GridView>
            <br /><br />

<table id="gradesTable">
        <thead>
            <tr>
                <th>Name</th>
                <th>Marks</th>
                <th>Grade</th>
                <th>GPA</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody id="gradesTableBody"></tbody>
    </table>
    <br />

          
 <button type="button" onclick="addRow()">Add Row</button>
    <script>
        function addRow() {
            var table = document.getElementById("gradesTableBody");
            var row = table.insertRow(-1);
            var nameCell = row.insertCell(0);
            var marksCell = row.insertCell(1);
            var gradeCell = row.insertCell(2);
            var gpaCell = row.insertCell(3);
            nameCell.innerHTML = "<input type='text' />";
            marksCell.innerHTML = "<input type='number' />";
            gradeCell.innerHTML = "<select><option value='A+'>A+</option><option value='A'>A</option><option value='A-'>A-</option><option value='B+'>B+</option><option value='B'>B</option><option value='B-'>B-</option><option value='C+'>C+</option><option value='C'>C</option><option value='C-'>C-</option><option value='D+'>D+</option><option value='D'>D</option><option value='F'>F</option></select>";
            gpaCell.innerHTML = "<input type='number' step='0.01' />";
        }
       

      < function updateRow(button) {
            var row = button.parentNode.parentNode;
            var name = row.cells[0].querySelector("input").value;
            var grade = row.cells[2].querySelector("select").value;
            var gradeId = getGradeId(grade);
            var courseId = 6;
            if (name !== "" && grade !== "" && gradeId !== "") {
                insertData(name, courseId, gradeId);
            }
       
    </script>






            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
               <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <%--<asp:Button ID="btnSave" runat="server" Text="Save Grades" OnClick="btnSave_Click" />--%>
        </div>

    </form>
</body>
</html>
