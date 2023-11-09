Imports System.Data.SqlClient

Public Class Result
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
        Dim username As String = Session("username")
        usernameLabel.Text = username

        Dim query As String = "SELECT ucg.username, c.course_name, g.gpa, g.grade " &
                              "FROM user_course_grade ucg " &
                              "INNER JOIN course c ON ucg.course_id = c.course_id " &
                              "INNER JOIN grade g ON ucg.grade_id = g.grade_id " &
                              "WHERE ucg.username = @username"

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@username", username)
            Dim reader As SqlDataReader = command.ExecuteReader()
            resultRepeater.DataSource = reader
            resultRepeater.DataBind()

            reader.Close()
        End Using
    End Sub

End Class
'Dim command As New SqlCommand("SELECT ucg.username, c.course_name, g.gpa, g.grade FROM user_course_grade ucg INNER JOIN course c ON ucg.course_id = c.course_id  INNER JOIN grade g ON ucg.grade_id = g.grade_id  WHERE ucg.username = @username", connection)