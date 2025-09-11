Imports System.Data.OleDb

Public Class frmPassengerLogin

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If

        Try
            Dim cmdSelect As New OleDbCommand("usp_PassengerLogin", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Parameters.AddWithValue("@PassengerLoginID", txtUsername.Text.Trim())
            cmdSelect.Parameters.AddWithValue("@PassengerPassword", txtPassword.Text.Trim())

            Dim rdr As OleDbDataReader = cmdSelect.ExecuteReader()

            If rdr.Read() Then
                intPassengerID = CInt(rdr("intPassengerID"))
                rdr.Close()
                CloseDatabaseConnection()
                frmCustomerMainMenu.Show()
                Me.Hide()
            Else
                rdr.Close()
                CloseDatabaseConnection()
                MessageBox.Show("Invalid username or password.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            CloseDatabaseConnection()
        End Try
    End Sub

    Private Sub btnAddPassenger_Click(sender As Object, e As EventArgs) Handles btnAddPassenger.Click
        AddPassenger.ShowDialog()
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub
End Class