<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="gradingSample.aspx.vb" Inherits="SemesterProject.gradingSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <label>Semester Number:</label>
            <asp:TextBox ID="txtSemester" runat="server"></asp:TextBox>
            <br />
            <label>Available Courses:</label>
            <asp:DropDownList ID="ddlCourses" runat="server"></asp:DropDownList>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
            <asp:ListBox ID="lstStudents" runat="server"></asp:ListBox>

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

        </div>
    </form>
</body>
</html>
