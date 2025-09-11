Imports System.Data.OleDb

Public Class frmDeleteAttendant

    Private Sub frmDeleteAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenDatabaseConnectionSQLServer()

        Dim strSelect As String = "SELECT intAttendantID, strFirstName + ' ' + strLastName AS FullName FROM TAttendants"
        Dim cmdSelect As New OleDbCommand(strSelect, m_conAdministrator)
        Dim rdr As OleDbDataReader = cmdSelect.ExecuteReader()

        While rdr.Read()
            cboAttendant.Items.Add(rdr("intAttendantID") & " - " & rdr("FullName"))
        End While

        rdr.Close()
        CloseDatabaseConnection()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboAttendant.SelectedIndex = -1 Then
            MessageBox.Show("Please select an attendant to delete.")
            Exit Sub
        End If

        Dim intAttendantID As Integer = CInt(cboAttendant.SelectedItem.ToString().Split("-"c)(0).Trim())

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this attendant?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            OpenDatabaseConnectionSQLServer()

            Dim strDelete As String = "DELETE FROM TAttendants WHERE intAttendantID = ?"
            Dim cmdDelete As New OleDbCommand(strDelete, m_conAdministrator)
            cmdDelete.Parameters.AddWithValue("intAttendantID", intAttendantID)

            Try
                cmdDelete.ExecuteNonQuery()
                MessageBox.Show("Attendant deleted.")
            Catch ex As Exception
                MessageBox.Show("Error deleting attendant: " & ex.Message)
            End Try

            CloseDatabaseConnection()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
