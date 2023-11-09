Imports System.Data.SqlClient

Public Class TeacherLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Value
        Dim password As String = txtPassword.Value

        Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
        Dim queryString As String = "SELECT * FROM Teacher_users WHERE username = @username AND user_password = @password"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)
            command.Parameters.AddWithValue("@username", username)
            command.Parameters.AddWithValue("@password", password)

            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                ' Login successful, start session
                Session("username") = username
                Response.Redirect("TeacherGradeEnter.aspx")
                'Response.Redirect("WebForm1.aspx")
            Else
                ' Login failed, display error message
                lblError.Visible = True
                lblError.Text = "Invalid username or password"
            End If
        End Using
    End Sub

End Class