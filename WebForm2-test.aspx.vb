Imports System.Data.SqlClient

Public Class WebForm2_test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGetCourses_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim semester As String = semester.Value
        Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT course_id FROM course WHERE course_sem = @semester"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@semester", semester)

                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.HasRows Then
                    tblCourses.Visible = True
                    While reader.Read()
                        Dim courseId As String = reader("course_id").ToString()
                        Dim row As New TableRow()
                        Dim cell As New TableCell()
                        cell.Text = courseId
                        row.Cells.Add(cell)
                        tblCourses.Rows.Add(row)
                    End While
                End If
                reader.Close()
            End Using
        End Using
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
        For Each listItem As ListItem In lstStudents.Items
            If listItem.Selected Then
                Dim username As String = listItem.Value
                Dim courseId As String = tblMarks.Rows(lstStudents.Items.IndexOf(listItem)).Cells(1).Text
                Dim marks As String = DirectCast(tblMarks.Rows(lstStudents.Items.IndexOf(listItem)).Cells(2).Controls(0), TextBox).Text

                Dim gradeId As Integer = CalculateGradeId(marks)

                Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
                Using connection As New SqlConnection(connectionString)
                    Dim query As String = "INSERT INTO user_course_grade(username, course_id, grade_id) VALUES (@username, @courseId, @gradeId)"
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@username", username)
                        command.Parameters.AddWithValue("@courseId", courseId)
                        command.Parameters.AddWithValue("@gradeId", gradeId)

                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using
            End If
        Next

        lblResult.Text = "Marks submitted successfully."
        lblResult.Visible = True
    End Sub

    Private Function CalculateGradeId(ByVal marks As String) As Integer
        Dim gradeId As Integer = 0
        Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT grade_id FROM grade WHERE @marks >= SUBSTRING_INDEX(mark_range, '-', 1)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@marks", marks)

                connection.Open()
                gradeId = CInt(command.ExecuteScalar())
            End Using
        End Using

        Return gradeId
    End Function

End Class