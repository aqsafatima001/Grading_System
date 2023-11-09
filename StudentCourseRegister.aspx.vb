Imports System.Data.SqlClient


Public Class StudentCourseRegister
    Inherits System.Web.UI.Page

    Private WithEvents aspSubmitBtn As Button

    ' Private ReadOnly connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Remove the If Not IsPostBack condition, it is not needed in this version of the code
        ' Hide the successLabel on every Page_Load event
        successLabel.Visible = False
    End Sub


    Protected Sub SubmitBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedSemester As Integer = Integer.Parse(Request.Form("semesterSelect"))
        Debug.WriteLine("selectedSemester = " & selectedSemester.ToString())

        Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand("SELECT course_id, course_seq_num, course_name FROM course WHERE course_sem = @semester", connection)
            command.Parameters.AddWithValue("@semester", selectedSemester)
            connection.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()
            If reader.HasRows Then
                Dim courseListHtml As New StringBuilder()
                courseListHtml.AppendLine("<fieldset>")
                courseListHtml.AppendLine("<legend>Courses for Semester " & selectedSemester & "</legend>")
                While reader.Read()
                    courseListHtml.AppendLine("<input type=""checkbox"" name=""courseSelect"" value=""" & reader("course_id") & """ />")
                    courseListHtml.AppendLine(reader("course_seq_num") & " - " & reader("course_name") & "<br />")
                End While
                courseList.Text = courseListHtml.ToString()
                courseList.Visible = True ' Show the course list
                RegisterBtn.Visible = True ' Show the register button
                semesterForm.Visible = True

            Else
                courseList.Text = "No courses available for Semester " & selectedSemester
                courseList.Visible = True ' Show the message
            End If
            reader.Close()
            connection.Close()
        End Using
    End Sub
    Protected Sub RegisterBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Check if there are any selected courses
        If Request.Form("courseSelect") IsNot Nothing Then
            Dim selectedCourses As String() = Request.Form.GetValues("courseSelect")
            Dim username As String = Session("username")

            Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim transaction As SqlTransaction = connection.BeginTransaction()
                Try
                    For Each courseId In selectedCourses
                        Dim command As New SqlCommand("INSERT INTO student_course (username, course_id) VALUES (@username, @course_id)", connection, transaction)
                        command.Parameters.AddWithValue("@username", username)
                        command.Parameters.AddWithValue("@course_id", Integer.Parse(courseId))
                        command.ExecuteNonQuery()
                    Next
                    transaction.Commit()
                    successLabel.Visible = True ' Display success message
                    courseList.Visible = False ' Hide courseList
                Catch ex As Exception
                    transaction.Rollback()
                    successLabel.Visible = False ' Display error message
                    courseList.Visible = True
                    courseList.Text = "An error occurred while registering for courses."
                End Try
                connection.Close()
            End Using
        Else
            successLabel.Visible = False ' Display error message
            courseList.Visible = True
            courseList.Text = "Please select at least one course."
        End If
    End Sub

End Class