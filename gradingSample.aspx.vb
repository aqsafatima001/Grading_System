Imports System.Data.SqlClient

Public Class gradingSample
    Inherits System.Web.UI.Page

    Dim connStr As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Dim semester As String = txtSemester.Text

        Using conn As New SqlConnection(connStr)
            conn.Open()

            ' Retrieve available courses for the selected semester
            Dim courseQuery As String = "SELECT course_id, course_name FROM course WHERE course_sem = @semester"
            Dim courseCmd As New SqlCommand(courseQuery, conn)
            courseCmd.Parameters.AddWithValue("@semester", semester)

            Dim courseReader As SqlDataReader = courseCmd.ExecuteReader()

            ddlCourses.Items.Clear()
            While courseReader.Read()
                ddlCourses.Items.Add(New ListItem(courseReader("course_name").ToString(), courseReader("course_id").ToString()))
            End While
            courseReader.Close()

            ' Retrieve students for the selected course
            Dim selectedCourseId As Integer = Convert.ToInt32(ddlCourses.SelectedValue)

            Dim studentQuery As String = "SELECT student_users.username FROM student_users " &
                                  "JOIN student_course ON student_users.username = student_course.username " &
                                  "WHERE student_course.course_id = @course_id"

            Dim studentCmd As New SqlCommand(studentQuery, conn)
            studentCmd.Parameters.AddWithValue("@course_id", selectedCourseId)

            Dim studentReader As SqlDataReader = studentCmd.ExecuteReader()

            lstStudents.Items.Clear()
            While studentReader.Read()
                lstStudents.Items.Add(studentReader("username").ToString())
            End While
            studentReader.Close()
        End Using
    End Sub


End Class