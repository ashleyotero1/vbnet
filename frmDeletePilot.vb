Imports System.Data.OleDb

Public Class frmDeletePilot

    Private Sub frmDeletePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Me.Close()
        End If

        Dim strSelect As String = "SELECT intPilotID, strFirstName + ' ' + strLastName AS FullName FROM TPilots"
        Dim cmdSelect As New OleDbCommand(strSelect, m_conAdministrator)
        Dim rdr As OleDbDataReader = cmdSelect.ExecuteReader()

        While rdr.Read()
            cboPilot.Items.Add(rdr("intPilotID") & " - " & rdr("FullName"))
        End While

        rdr.Close()
        CloseDatabaseConnection()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If cboPilot.SelectedIndex = -1 Then
            MessageBox.Show("Please select a pilot to delete.")
            Exit Sub
        End If

        Dim strSelected As String = cboPilot.SelectedItem.ToString()
        Dim intPilotID As Integer = CInt(strSelected.Substring(0, strSelected.IndexOf(" - ")))

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this pilot?", "Confirm Delete", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show("Database connection failed.")
                Exit Sub
            End If

            Try
                Dim cmdDelete As New OleDbCommand("usp_DeletePilot", m_conAdministrator)
                cmdDelete.CommandType = CommandType.StoredProcedure
                cmdDelete.Parameters.AddWithValue("@intPilotID", intPilotID)

                cmdDelete.ExecuteNonQuery()

                MessageBox.Show("Pilot deleted successfully.")

                cboPilot.Items.Clear()
                frmDeletePilot_Load(Nothing, Nothing) ' Reload list
            Catch ex As Exception
                MessageBox.Show("Error deleting pilot: " & ex.Message)
            Finally
                CloseDatabaseConnection()
            End Try
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        frmAdminMainMenu.Show()
    End Sub

End Class