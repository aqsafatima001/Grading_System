Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class RegStudent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub RegisterButton_Click(sender As Object, e As EventArgs) Handles RegisterButton.Click

        'Creating connection with Database
        'Dim connectionString As String = "Data Source=LAPTOP-G5TDHLRV\SQL_IAD;Initial Catalog=SemesterProject;Integrated Security=True"
        Dim connectionString As String = WebConfigurationManager.ConnectionStrings("SemesterProject").ConnectionString
        Dim myConnection As New SqlConnection(connectionString)


        Dim insertSQL As String
        insertSQL = "INSERT INTO student_users ("
        insertSQL &= "username, user_password) "
        insertSQL &= "VALUES ('"
        insertSQL &= username.Text & "', '"
        insertSQL &= password.Text & "')"

        Dim myCommand As New SqlCommand(insertSQL, myConnection)

        ' Try to open the database and execute the update.
        Dim added As Integer = 0
        Try
            myConnection.Open()
            added = myCommand.ExecuteNonQuery()
            Results.Text = added.ToString() & " records inserted."
        Catch err As Exception
            Results.Text = "Error inserting record. "
            Results.Text &= err.Message
        Finally
            myConnection.Close()
        End Try



    End Sub



End Class