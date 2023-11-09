Imports System.Data.SqlClient

Public Class gradingSample2
    Inherits System.Web.UI.Page

    Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
    'Protected WithEvents gradesTable As System.Web.UI.WebControls.GridView
    'Private gradesTable As HtmlTable
    Dim gradesTable As Table = TryCast(Page.FindControl("gradesTable"), Table)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            'BindGrid()
        End If
    End Sub

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
    End Sub



    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Dim courseId As Integer = Convert.ToInt32(ddlCourses.SelectedValue)
        Dim gradeId As Integer = 0
        Dim marks As Decimal = 0.0
        Dim grade As String = ""
        For Each item As ListItem In lstStudents.Items
            Dim username As String = item.Value
            marks = Convert.ToDecimal(DirectCast(FindControl("txtMarks"), TextBox).Text)
            ' get grade_id from grade table based on marks
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("SELECT grade_id FROM grade WHERE @marks BETWEEN CAST(SUBSTRING(mark_range, 1, CHARINDEX('-', mark_range)-1) AS DECIMAL) AND CAST(SUBSTRING(mark_range, CHARINDEX('-', mark_range)+1, LEN(mark_range)-CHARINDEX('-', mark_range)) AS DECIMAL)", con)
                    cmd.Parameters.AddWithValue("@marks", marks)
                    con.Open()
                    gradeId = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
            ' get grade and gpa from grade table based on grade_id
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("SELECT grade, gpa FROM grade WHERE grade_id = @grade_id", con)
                    cmd.Parameters.AddWithValue("@grade_id", gradeId)
                    con.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            grade = reader("grade").ToString()
                        End If
                    End Using
                End Using
            End Using
            Dim gpa As Decimal = Convert.ToDecimal(DirectCast(FindControl("txtGPA"), TextBox).Text)
            ' insert grade, gpa, and marks into user_course_grade table
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("INSERT INTO user_course_grade(username, course_id, grade_id) VALUES (@username, @course_id, @grade_id)", con)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@course_id", courseId)
                    cmd.Parameters.AddWithValue("@grade_id", gradeId)
                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Next
        lblMessage.Text = "Grades saved successfully."
    End Sub

    Private Sub updateRow(ByVal button As Button)
        Dim row As HtmlTableRow = DirectCast(button.Parent.Parent, HtmlTableRow)
        Dim name As String = DirectCast(row.Cells(0).Controls(0), HtmlInputText).Value
        Dim grade As String = DirectCast(row.Cells(2).Controls(0), HtmlSelect).Value
        Dim gradeId As Integer = getGradeId(grade)
        Dim courseId As String = Request.QueryString("course_id")

        If Not String.IsNullOrEmpty(name) AndAlso Not String.IsNullOrEmpty(grade) AndAlso gradeId > 0 Then
            insertData(name, courseId, gradeId)
        End If
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

    Private Sub insertData(ByVal name As String, ByVal courseId As String, ByVal gradeId As Integer)
        Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
            Using cmd As New SqlCommand("INSERT INTO user_course_grade (username, course_id, grade_id) VALUES (@name, @courseId, @gradeId)", conn)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@courseId", courseId)
                cmd.Parameters.AddWithValue("@gradeId", gradeId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'Protected Sub BindGrid()
    'Using conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    'Using cmd As New SqlCommand("SELECT * FROM grade WHERE course_id = @course_id", conn)
    '           cmd.Parameters.AddWithValue("@course_id", Request.QueryString("course_id"))
    '          conn.Open()
    'Using reader As SqlDataReader = cmd.ExecuteReader()
    '               gradesTable.DataSource = reader
    '              gradesTable.DataBind()
    'End Using
    'End Using
    'End Using
    'End Sub

End Class