Imports System.Data.OleDb

Public Class frmAddAttendant

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtEmployeeID.Text = "" Or
           txtDateOfHire.Text = "" Or txtDateOfTermination.Text = "" Then
            MessageBox.Show("Please fill in all fields.")
            Exit Sub
        End If

        OpenDatabaseConnectionSQLServer()

        Dim intNextPrimaryKey As Integer
        Dim strSelect As String = "SELECT MAX(intAttendantID) + 1 AS intNextPrimaryKey FROM TAttendants"
        Dim cmdSelect As New OleDbCommand(strSelect, m_conAdministrator)
        Dim rdr As OleDbDataReader = cmdSelect.ExecuteReader()

        If rdr.Read() = True Then
            If rdr("intNextPrimaryKey") IsNot DBNull.Value Then
                intNextPrimaryKey = CInt(rdr("intNextPrimaryKey"))
            Else
                intNextPrimaryKey = 1
            End If
        End If

        rdr.Close()

        Dim strInsert As String = "INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination) " &
                                  "VALUES (?, ?, ?, ?, ?, ?)"
        Dim cmdInsert As New OleDbCommand(strInsert, m_conAdministrator)

        cmdInsert.Parameters.AddWithValue("intAttendantID", intNextPrimaryKey)
        cmdInsert.Parameters.AddWithValue("strFirstName", txtFirstName.Text)
        cmdInsert.Parameters.AddWithValue("strLastName", txtLastName.Text)
        cmdInsert.Parameters.AddWithValue("strEmployeeID", txtEmployeeID.Text)
        cmdInsert.Parameters.AddWithValue("dtmDateOfHire", txtDateOfHire.Text)
        cmdInsert.Parameters.AddWithValue("dtmDateOfTermination", txtDateOfTermination.Text)

        Try
            cmdInsert.ExecuteNonQuery()
            MessageBox.Show("Attendant added.")
        Catch ex As Exception
            MessageBox.Show("Error adding attendant: " & ex.Message)
        End Try

        CloseDatabaseConnection()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class