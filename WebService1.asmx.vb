Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Shared Function InsertGrade(name As String, courseId As Integer, gradeId As Integer) As String

        Console.WriteLine("Inserting grade for: name={0}, courseId={1}, gradeId={2}", name, courseId, gradeId)
        Try
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

        Catch ex As System.Net.WebException
            Return "Error: Unable to connect to web service. Please try again later."
        End Try
    End Function

End Class