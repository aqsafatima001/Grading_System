<%@ Page  Language="vb"  AutoEventWireup="false" CodeBehind="TeacherGradeEnter.aspx.vb" Inherits="SemesterProject.WebForm1"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CssFiles/TeacherGradeEnter.css" rel="stylesheet" />
    <title></title>
</head>
<body>
            <form id="form1" runat="server">
           <h1>Student Grades</h1>

                <div>
                    <label class="semlabel" for="semester">Semester:</label>
                    <asp:TextBox ID="semester" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnShowCourses" runat="server" Text="Show Courses" CssClass="my-button-class" OnClick="btnShowCourses_Click" />
                    <br />
                    <asp:DropDownList ID="ddlCourses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourses_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:ListBox ID="lstStudents" runat="server" SelectionMode="Multiple"></asp:ListBox>
                    <br />
                </div>

                <div>
                     <%--<h1>Current Course ID: <%= COURSE_ID %></h1>--%>
                </div>

            <table id="gradesTable">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Marks</th>
                        <th>Grade</th>
                        <th>GPA</th>
                    </tr>
                </thead>
                <tbody id="gradesTableBody"></tbody>
            </table>
    
            <br />
      
                <%--HIDDEN FIELDS--%> 
                <input type="hidden" id="nameField" name="nameField" />
                <asp:HiddenField ID="hdnCourseID" runat="server" />



            <button type="button"  Class="my-button-class" onclick="addRow()">Add Row</button>
            <%--<asp:Button ID="updateButton" runat="server"  CssClass="my-button-class" Text="Update" OnClick="updateButton_Click" />--%>
       
                <asp:Label ID="nameLabel" runat="server" Text=""></asp:Label>
                <asp:Label ID="courseIdLabel" runat="server" Text=""></asp:Label>
                <asp:Label ID="gradeIdLabel" runat="server" Text=""></asp:Label>

            <script>
                function addRow() {
                    var table = document.getElementById("gradesTableBody");
                    var row = table.insertRow(-1);
                    var nameCell = row.insertCell(0);
                    var marksCell = row.insertCell(1);
                    var gradeCell = row.insertCell(2);
                    var gpaCell = row.insertCell(3);
                    var updateCell = row.insertCell(4); // Add a new cell for the update button
                    nameCell.innerHTML = "<input type='text' />";
                    marksCell.innerHTML = "<input type='number' />";
                    gradeCell.innerHTML = "<select><option value='A+'>A+</option><option value='A'>A</option><option value='A-'>A-</option><option value='B+'>B+</option><option value='B'>B</option><option value='B-'>B-</option><option value='C+'>C+</option><option value='C'>C</option><option value='C-'>C-</option><option value='D+'>D+</option><option value='D'>D</option><option value='F'>F</option></select>";
                    gpaCell.innerHTML = "<input type='number' step='0.01' />";
                    updateCell.innerHTML = "<button type='button' onclick='updateRow(this)'>Update</button>"; // Add the update button
                }
        

                //global variables
                //var nameValue, gradeIdValue;
                function updateRow(button) {

                    var row = button.parentNode.parentNode;
                    var name = row.cells[0].getElementsByTagName("input")[0].value;
                    document.getElementById("nameField").value = name;
                    var marks = row.cells[1].getElementsByTagName("input")[0].value;
                    var grade = row.cells[2].getElementsByTagName("select")[0].value;
                    var gpa = row.cells[3].getElementsByTagName("input")[0].value;
                    var gradeId = getGradeId(grade);
                    var course_id = <%= COURSE_ID %>;

                    var xhr = new XMLHttpRequest();
                             console.log("value of xhr is :",xhr);
                    xhr.open("GET", "https://localhost:44327/WebService1.asmxInsertGrade", true);
                                console.log('XHR initialized with method:', xhr.method, 'and url:', xhr.url);
                    xhr.setRequestHeader("Content-type",'application/x-www-form-urlencoded');
                    xhr.onreadystatechange = function () {
                        if (xhr.readyState === 4) {
                            if (xhr.status === 200) {
                                var response = xhr.responseText;
                                console.log(response);
                            } else {
                                console.log("Error: " + xhr.status);
                            }
                        }
                    };
                    var data = "name=" + encodeURIComponent(name) + "&courseId=" + encodeURIComponent(course_id) + "&gradeId=" + encodeURIComponent(gradeId);
                    console.log("The value of course_id is", course_id)
                    xhr.send('name=' + name + '&courseId=' + course_id + '&gradeId=' + gradeId);
                    //alert("Update row: Name = " + name + ", Course_id = " + course_id + ", Grade = " + grade + "GradeId = " + gradeId);
                    alert("Grades Updated");

                    //var data = {
                    //    nameValue: name,
                    //    courseIdValue: course_id,
                    //    gradeIdValue: gradeId
                    //};
                    //xhr.send(JSON.stringify(data));
                    return true;
                }


                function getGradeId(grade) {
                    switch (grade) {
                        case "A+":
                            return 1;
                        case "A":
                            return 2;
                        case "A-":
                            return 3;
                        case "B+":
                            return 4;
                        case "B":
                            return 5;
                        case "B-":
                            return 6;
                        case "C+":
                            return 7;
                        case "C":
                            return 8;
                        case "C-":
                            return 9;
                        case "D":
                            return 10;
                        case "F":
                            return 11;
                        default:
                            return 0;
                    }
                }

            </script>

                </form>
</body>
</html>
