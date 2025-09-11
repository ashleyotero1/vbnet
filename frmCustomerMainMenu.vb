
Imports System.Data.OleDb

Public Class frmCustomerMainMenu

    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click
        Me.Hide()
        UpdatePassenger.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnBookFlight_Click(sender As Object, e As EventArgs) Handles btnBookFlight.Click
        Me.Hide()
        frmBookFlight.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        Me.Hide()
        frmCustomerPastFlights.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        Me.Hide()
        frmCustomerFutureFlights.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        frmUserType.ShowDialog()
        Me.Close()
    End Sub

End Class


