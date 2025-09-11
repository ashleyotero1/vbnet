Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub btnPassengerLogin_Click(sender As Object, e As EventArgs) Handles btnPassengerLogin.Click
        Me.Hide()
        frmPassengerLogin.Show()
    End Sub

    Private Sub btnEmployeeLogin_Click(sender As Object, e As EventArgs) Handles btnEmployeeLogin.Click
        Me.Hide()
        frmEmployeeLogin.Show()
    End Sub


End Class