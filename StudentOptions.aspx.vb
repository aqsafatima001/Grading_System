Public Class StudentOptions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub btnRegisterCourses_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegisterCourses.Click
        Response.Redirect("StudentCourseRegister.aspx")
    End Sub

    Protected Sub btnCheckResults_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCheckResults.Click
        Response.Redirect("Result.aspx")
    End Sub

End Class