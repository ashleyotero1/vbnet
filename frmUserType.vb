

Public Class frmUserType

    Private Sub frmUserType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboUserType.Items.Clear()
        cboUserType.Items.Add("Customer")
        cboUserType.Items.Add("Pilot")
        cboUserType.Items.Add("Attendant")
        cboUserType.Items.Add("Admin")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboUserType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a user type.")
            Exit Sub
        End If

        Select Case cboUserType.SelectedItem.ToString()
            Case "Customer"
                Dim frmCustomerLogin As New frmCustomerLogin
                frmCustomerLogin.ShowDialog()

            Case "Pilot"
                Dim frmPilotLogin As New frmPilotLogin
                frmPilotLogin.ShowDialog()

            Case "Attendant"
                Dim frmAttendantLogin As New frmAttendantLogin
                frmAttendantLogin.ShowDialog()

            Case "Admin"
                Dim frmAdminMainMenu As New frmAdminMainMenu
                frmAdminMainMenu.ShowDialog()
        End Select
    End Sub


End Class

