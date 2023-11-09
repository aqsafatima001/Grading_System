Imports System.Data.SqlClient
Imports System.Web.Script.Services
Imports System.Web.Services

<ScriptService>
Public Class WebForm1
    Inherits System.Web.UI.Page

    Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"

    '-----GLOBAL VARIABLEE FOR COURSE_ID---------
    Public COURSE_ID As Integer

    '----------------------Page load-----------------------------------------------------
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub


    '----------------------btnShowCourses-----------------------------------------------------
    Protected Sub btnShowCourses_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowCourses.Click
        ' Populate courses dropdown based on semester value
        ddlCourses.Items.Clear()
        lstStudents.Items.Clear()
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("SELECT course_id, course_name FROM course WHERE course_sem = @sem", con)
                cmd.Parameters.AddWithValue("@sem", semester.Text)
                con.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    ddlCourses.DataSource = reader
                    ddlCourses.DataTextField = "course_name"
                    ddlCourses.DataValueField = "course_id"
                    ddlCourses.DataBind()
                End Using
            End Using
        End Using
    End Sub


    '----------------------ddlCourses-----------------------------------------------------
    Protected Sub ddlCourses_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourses.SelectedIndexChanged
        ' Populate students listbox based on selected course
        lstStudents.Items.Clear()
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("SELECT su.username FROM student_users su JOIN student_course sc ON su.username = sc.username WHERE sc.course_id = @course_id", con)
                cmd.Parameters.AddWithValue("@course_id", ddlCourses.SelectedValue)
                con.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim item As New ListItem()
                        item.Text = reader("username").ToString()
                        lstStudents.Items.Add(item)
                    End While
                End Using
            End Using
        End Using

        ' Store the selected course ID in the public variable
        'COURSE_ID = Convert.ToInt32(ddlCourses.SelectedValue)
        COURSE_ID = ddlCourses.SelectedValue


        'hdnCourseID.Value = ddlCourses.SelectedValue
    End Sub


    Protected WithEvents updateButton As Button
    Public courseId As Integer = COURSE_ID
    Protected Sub updateButton_Click(sender As Object, e As EventArgs) Handles updateButton.Click
        Dim name As String = Request.Form("nameField")
        Dim gradeId As Integer = getGradeId(Request.Form("hiddenGrade"))
        nameLabel.Text = name
        courseIdLabel.Text = courseId
        gradeIdLabel.Text = gradeId.ToString()
        ' Dim name As String = "Aqsa Fatima"
        'Dim courseId As String = 5
        'Dim gradeId As Integer = 1

        Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
        Dim queryString As String = "INSERT INTO user_course_grade VALUES (@name, @courseId, @gradeId)"

        'Using connection As New SqlConnection(connectionString)
        'Using command As New SqlCommand(queryString, connection)
        'Command.Parameters.AddWithValue("@name", name)
        'Command.Parameters.AddWithValue("@courseId", courseId)
        ' Command.Parameters.AddWithValue("@gradeId", gradeId)
        'connection.Open()
        'Command.ExecuteNonQuery()
        'End Using
        'End Using

        'Optional: Show a message to confirm that the record has been inserted
        'MessageBox.Show("Record inserted successfully.")
    End Sub

    Private Function getGradeId(ByVal grade As String) As Integer
        Select Case grade
            Case "A+"
                Return 1
            Case "A"
                Return 2
            Case "A-"
                Return 3
            Case "B+"
                Return 4
            Case "B"
                Return 5
            Case "B-"
                Return 6
            Case "C+"
                Return 7
            Case "C"
                Return 8
            Case "C-"
                Return 9
            Case "D"
                Return 10
            Case "F"
                Return 11
            Case Else
                Return 0
        End Select
    End Function


    <WebMethod()>
    Public Shared Function InsertGrade(name As String, courseId As Integer, gradeId As Integer) As String
        Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
        Dim queryString As String = "INSERT INTO user_course_grade VALUES (@name, @courseId, @gradeId)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(queryString, connection)
                command.Parameters.AddWithValue("@name", name)
                command.Parameters.AddWithValue("@courseId", courseId)
                command.Parameters.AddWithValue("@gradeId", gradeId)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using

        Return "Grade inserted successfully"
    End Function

End Class