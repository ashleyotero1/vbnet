
Imports System.Data.OleDb

Public Class UpdatePassenger

    Private m_blnIsLoading As Boolean = True

    Private Sub UpdatePassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDbCommand
        Dim drSourceTable As OleDbDataReader
        Dim dt As New DataTable()

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Failed to open database connection.")
            Exit Sub
        End If


        strSelect = "SELECT intPassengerID, strFirstName + ' ' + strLastName AS FullName FROM TPassengers"
        cmdSelect = New OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader()
        dt.Load(drSourceTable)
        cboPassengers.ValueMember = "intPassengerID"
        cboPassengers.DisplayMember = "FullName"
        cboPassengers.DataSource = dt
        drSourceTable.Close()


        strSelect = "SELECT intStateID, strState FROM TStates"
        cmdSelect = New OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader()
        Dim dtStates As New DataTable()
        dtStates.Load(drSourceTable)
        cboState.ValueMember = "intStateID"
        cboState.DisplayMember = "strState"
        cboState.DataSource = dtStates
        drSourceTable.Close()

        CloseDatabaseConnection()
        m_blnIsLoading = False
    End Sub

    Private Sub cboPassengers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPassengers.SelectedIndexChanged
        If m_blnIsLoading = True Then Exit Sub

        If cboPassengers.SelectedIndex >= 0 Then
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show("Failed to open database connection.")
                Exit Sub
            End If

            Dim intSelectedID As Integer = CInt(cboPassengers.SelectedValue)
            Dim strSelect As String = "SELECT * FROM TPassengers WHERE intPassengerID = " & intSelectedID
            Dim cmdSelect As New OleDbCommand(strSelect, m_conAdministrator)
            Dim drSourceTable As OleDbDataReader = cmdSelect.ExecuteReader()

            If drSourceTable.Read() Then
                txtFirstName.Text = drSourceTable("strFirstName").ToString()
                txtLastName.Text = drSourceTable("strLastName").ToString()
                txtAddress.Text = drSourceTable("strAddress").ToString()
                txtCity.Text = drSourceTable("strCity").ToString()
                txtZip.Text = drSourceTable("strZip").ToString()
                txtPhone.Text = drSourceTable("strPhoneNumber").ToString()
                txtEmail.Text = drSourceTable("strEmail").ToString()
                txtUsername.Text = drSourceTable("PassengerLoginID").ToString()
                txtPassword.Text = drSourceTable("PassengerPassword").ToString()
                txtDOB.Text = drSourceTable("PassengerDateOfBirth").ToString()
                cboState.SelectedValue = drSourceTable("intStateID")
            End If

            drSourceTable.Close()
            CloseDatabaseConnection()
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If

        Dim cmdUpdate As New OleDbCommand("usp_UpdatePassenger", m_conAdministrator)
        cmdUpdate.CommandType = CommandType.StoredProcedure

        Try
            cmdUpdate.Parameters.AddWithValue("@strFirstName", txtFirstName.Text)
            cmdUpdate.Parameters.AddWithValue("@strLastName", txtLastName.Text)
            cmdUpdate.Parameters.AddWithValue("@strAddress", txtAddress.Text)
            cmdUpdate.Parameters.AddWithValue("@strCity", txtCity.Text)
            cmdUpdate.Parameters.AddWithValue("@intStateID", CInt(cboState.SelectedValue))
            cmdUpdate.Parameters.AddWithValue("@strZip", txtZip.Text)
            cmdUpdate.Parameters.AddWithValue("@strPhoneNumber", txtPhone.Text)
            cmdUpdate.Parameters.AddWithValue("@strEmail", txtEmail.Text)
            cmdUpdate.Parameters.AddWithValue("@PassengerLoginID", txtUsername.Text)
            cmdUpdate.Parameters.AddWithValue("@PassengerPassword", txtPassword.Text)
            cmdUpdate.Parameters.AddWithValue("@PassengerDateOfBirth", txtDOB.Text)
            cmdUpdate.Parameters.AddWithValue("@intPassengerID", CInt(cboPassengers.SelectedValue))

            Dim intRowsAffected As Integer = cmdUpdate.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Passenger has been updated.")
            Else
                MessageBox.Show("No record was updated.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseDatabaseConnection()
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class