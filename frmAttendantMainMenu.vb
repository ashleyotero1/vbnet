Public Class frmAttendantMainMenu

    Private Sub btnUpdateAttendant_Click(sender As Object, e As EventArgs) Handles btnUpdateAttendant.Click

        Me.Hide()

        frmUpdateAttendant.ShowDialog()

    End Sub




    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click

        Me.Hide()

        frmAttendantPastFlights.ShowDialog()

    End Sub




    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click

        Me.Hide()

        frmAttendantFutureFlights.ShowDialog()

    End Sub



    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Me.Close()

        frmUserType.Show()

    End Sub



End Class