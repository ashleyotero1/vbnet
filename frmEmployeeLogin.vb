Imports System.Data.OleDb

Public Class frmEmployeeLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim strLoginID As String = txtUsername.Text.Trim()
        Dim strPassword As String = txtPassword.Text.Trim()

        If strLoginID = "" Or strPassword = "" Then
            MessageBox.Show("Please enter both Login ID and Password.")
            Exit Sub
        End If

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show("Database connection failed.")
                Exit Sub
            End If

            Dim cmdSelect As New OleDbCommand("usp_EmployeeLogin", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure
            cmdSelect.Parameters.AddWithValue("@EmployeeLoginID", strLoginID)
            cmdSelect.Parameters.AddWithValue("@EmployeePassword", strPassword)

            Dim rdr As OleDbDataReader = cmdSelect.ExecuteReader()

            If rdr.Read() Then
                Dim strRole As String = rdr("EmployeeRole").ToString()
                Dim intEmpID As Integer = If(IsDBNull(rdr("EmployeeID")), 0, CInt(rdr("EmployeeID")))

                rdr.Close()
                CloseDatabaseConnection()

                Select Case strRole
                    Case "Admin"
                        frmAdminMainMenu.Show()
                    Case "Pilot"
                        intPilotID = intEmpID
                        frmPilotMainMenu.Show()
                    Case "Attendant"
                        intAttendantId = intEmpID
                        frmAttendantMainMenu.Show()
                    Case Else
                        MessageBox.Show("Invalid role detected.")
                        Exit Sub
                End Select

                Me.Hide()
            Else
                rdr.Close()
                CloseDatabaseConnection()
                MessageBox.Show("Invalid login ID or password.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            CloseDatabaseConnection()
        End Try
    End Sub

End Class