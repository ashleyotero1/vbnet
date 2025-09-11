Imports System.Data.OleDb

Public Class frmUpdateAttendant

    Private Sub frmUpdateAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim cmdSelect As OleDbCommand
        Dim rdr As OleDbDataReader
        Dim dt As New DataTable()

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Failed to open database connection.")
            Exit Sub
        End If

        strSelect = "SELECT strLastName, intAttendantID FROM TAttendants ORDER BY strLastName"
        cmdSelect = New OleDbCommand(strSelect, m_conAdministrator)
        rdr = cmdSelect.ExecuteReader()
        dt.Load(rdr)

        cboAttendant.DisplayMember = "strLastName"
        cboAttendant.ValueMember = "intAttendantID"
        cboAttendant.DataSource = dt

        rdr.Close()
        CloseDatabaseConnection()
    End Sub

    Private Sub cboAttendant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAttendant.SelectedIndexChanged
        If cboAttendant.SelectedIndex = -1 Then Exit Sub

        Dim strSelect As String
        Dim cmdSelect As OleDbCommand
        Dim rdr As OleDbDataReader

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Failed to open database connection.")
            Exit Sub
        End If

        strSelect = "SELECT * FROM TAttendants WHERE intAttendantID = " & cboAttendant.SelectedValue
        cmdSelect = New OleDbCommand(strSelect, m_conAdministrator)
        rdr = cmdSelect.ExecuteReader()

        If rdr.Read() Then
            txtFirstName.Text = rdr("strFirstName").ToString()
            txtLastName.Text = rdr("strLastName").ToString()
            txtEmployeeID.Text = rdr("strEmployeeID").ToString()
            txtDateOfHire.Text = rdr("dtmDateOfHire").ToString()
            txtDateOfTermination.Text = rdr("dtmDateOfTermination").ToString()
        End If

        rdr.Close()
        CloseDatabaseConnection()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtFirstName.Text = "" Then
            MessageBox.Show("First Name is required.")
            Exit Sub
        End If

        If txtLastName.Text = "" Then
            MessageBox.Show("Last Name is required.")
            Exit Sub
        End If

        If txtEmployeeID.Text = "" Then
            MessageBox.Show("Employee ID is required.")
            Exit Sub
        End If

        If txtDateOfHire.Text = "" Then
            MessageBox.Show("Hire Date is required.")
            Exit Sub
        End If

        If txtDateOfTermination.Text = "" Then
            MessageBox.Show("Termination Date is required.")
            Exit Sub
        End If

        If cboAttendant.SelectedIndex = -1 Then
            MessageBox.Show("Please select an attendant.")
            Exit Sub
        End If

        Dim strUpdate As String
        Dim cmdUpdate As OleDbCommand

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Failed to open database connection.")
            Exit Sub
        End If

        strUpdate = "UPDATE TAttendants SET " &
                    "strFirstName = '" & txtFirstName.Text & "', " &
                    "strLastName = '" & txtLastName.Text & "', " &
                    "strEmployeeID = '" & txtEmployeeID.Text & "', " &
                    "dtmDateOfHire = '" & txtDateOfHire.Text & "', " &
                    "dtmDateOfTermination = '" & txtDateOfHire.Text & "' " &
                    "WHERE intAttendantID = " & cboAttendant.SelectedValue

        cmdUpdate = New OleDbCommand(strUpdate, m_conAdministrator)
        Dim intRowsAffected As Integer = cmdUpdate.ExecuteNonQuery()

        CloseDatabaseConnection()

        MessageBox.Show("Attendant has been updated.")
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class