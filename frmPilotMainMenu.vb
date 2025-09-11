Public Class frmPilotMainMenu
    Private Sub btnUpdatePilot_Click(sender As Object, e As EventArgs) Handles btnUpdatePilot.Click
        Me.Hide()
        frmUpdatePilot.ShowDialog()
        Me.Close()
    End Sub


    Private Sub btnPastFlight_Click(sender As Object, e As EventArgs) Handles btnPastFlight.Click
        Me.Hide()
        frmPilotPastFlights.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        Me.Hide()
        frmPilotFutureFlights.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class