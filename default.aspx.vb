Public Class _default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnStudent_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStudent.Click
        ' Set user type to student and redirect to login page
        Session("userType") = "student"
        Response.Redirect("StudentLogin.aspx")
    End Sub

    Protected Sub btnTeacher_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTeacher.Click
        ' Set user type to teacher and redirect to login page
        Session("userType") = "teacher"
        Response.Redirect("TeacherLogin.aspx")
    End Sub

    Protected Sub btnRegTeacher_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegTeacher.Click
        ' Set user type to teacher and redirect to login page
        Session("userType") = "teacher"
        Response.Redirect("RegTeacher.aspx")
    End Sub

    Protected Sub btnRegStudent_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegStudent.Click
        ' Set user type to teacher and redirect to login page
        Session("userType") = "teacher"
        Response.Redirect("RegStudent.aspx")
    End Sub

End Class