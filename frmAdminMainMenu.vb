Public Class frmAdminMainMenu

    Private Sub btnAddPilot_Click(sender As Object, e As EventArgs) Handles btnAddPilot.Click
        Me.Hide()
        frmAddPilot.ShowDialog()
    End Sub

    Private Sub btnDeletePilot_Click(sender As Object, e As EventArgs) Handles btnDeletePilot.Click
        Me.Hide()
        frmDeletePilot.ShowDialog()
    End Sub

    Private Sub btnAssignPilotFlight_Click(sender As Object, e As EventArgs) Handles btnAssignPilotFlight.Click
        Me.Hide()
        frmAssignPilotFlight.ShowDialog()
    End Sub

    Private Sub btnAddAttendant_Click(sender As Object, e As EventArgs) Handles btnAddAttendant.Click
        Me.Hide()
        frmAddAttendant.ShowDialog()
    End Sub

    Private Sub btnDeleteAtendant_Click(sender As Object, e As EventArgs) Handles btnDeleteAtendant.Click
        Me.Hide()
        frmDeleteAttendant.ShowDialog()
    End Sub

    Private Sub btnAssignAttendantFlight_Click(sender As Object, e As EventArgs) Handles btnAssignAttendantFlight.Click
        Me.Hide()
        frmAssignAttendantFlight.ShowDialog()
    End Sub

    Private Sub btnViewStats_Click(sender As Object, e As EventArgs) Handles btnViewStats.Click
        Me.Hide()
        frmStatistics.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        frmUserType.Show()
    End Sub

    Private Sub btnCreateFutureFlights_Click(sender As Object, e As EventArgs) Handles btnCreateFutureFlights.Click
        OpenDatabaseConnectionSQLServer()
        frmCreateFutureFlights.Show()
    End Sub
End Class