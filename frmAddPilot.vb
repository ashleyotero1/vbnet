Imports System.Data.OleDb

Public Class frmAddPilot

    Private Sub frmAddPilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Me.Close()
            Exit Sub
        End If

        Dim strSelect As String = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"
        Dim cmdSelect As New OleDbCommand(strSelect, m_conAdministrator)
        Dim drSourceTable As OleDbDataReader = cmdSelect.ExecuteReader()
        Dim dt As New DataTable()
        dt.Load(drSourceTable)

        cboRole.DisplayMember = "strPilotRole"
        cboRole.ValueMember = "intPilotRoleID"
        cboRole.DataSource = dt

        drSourceTable.Close()
        CloseDatabaseConnection()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtEmployeeID.Text = "" Or
           txtDateOfHire.Text = "" Or txtDateOfLicense.Text = "" Or
           txtUsername.Text = "" Or txtPassword.Text = "" Then

            MessageBox.Show("All fields are required.")
            Exit Sub
        End If

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If

        Try

            Dim intNextPrimaryKey As Integer
            Dim strSelectPK As String = "SELECT MAX(intPilotID) + 1 AS intNextPrimaryKey FROM TPilots"
            Dim cmdSelectPK As New OleDbCommand(strSelectPK, m_conAdministrator)
            Dim drPK As OleDbDataReader = cmdSelectPK.ExecuteReader()
            drPK.Read()

            If drPK.IsDBNull(0) Then
                intNextPrimaryKey = 1
            Else
                intNextPrimaryKey = CInt(drPK("intNextPrimaryKey"))
            End If
            drPK.Close()


            Dim strInsertPilot As String =
                "INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination, dtmDateOfLicense, intPilotRoleID) " &
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?)"

            Dim cmdInsertPilot As New OleDbCommand(strInsertPilot, m_conAdministrator)
            cmdInsertPilot.Parameters.AddWithValue("@intPilotID", intNextPrimaryKey)
            cmdInsertPilot.Parameters.AddWithValue("@strFirstName", txtFirstName.Text)
            cmdInsertPilot.Parameters.AddWithValue("@strLastName", txtLastName.Text)
            cmdInsertPilot.Parameters.AddWithValue("@strEmployeeID", txtEmployeeID.Text)
            cmdInsertPilot.Parameters.AddWithValue("@dtmDateOfHire", txtDateOfHire.Text)
            cmdInsertPilot.Parameters.AddWithValue("@dtmDateOfTermination", txtDateOfTermination.Text)
            cmdInsertPilot.Parameters.AddWithValue("@dtmDateOfLicense", txtDateOfLicense.Text)
            cmdInsertPilot.Parameters.AddWithValue("@intPilotRoleID", CInt(cboRole.SelectedValue))

            Dim intRowsAffected As Integer = cmdInsertPilot.ExecuteNonQuery()


            Dim strInsertEmp As String =
                "INSERT INTO TEmployee (EmployeeLoginID, EmployeePassword, EmployeeRole, EmployeeID) " &
                "VALUES (?, ?, 'Pilot', ?)"

            Dim cmdInsertEmp As New OleDbCommand(strInsertEmp, m_conAdministrator)
            cmdInsertEmp.Parameters.AddWithValue("@EmployeeLoginID", txtUsername.Text)
            cmdInsertEmp.Parameters.AddWithValue("@EmployeePassword", txtPassword.Text)
            cmdInsertEmp.Parameters.AddWithValue("@EmployeeID", intNextPrimaryKey)

            cmdInsertEmp.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Pilot and login credentials added successfully.")
                Me.Close()
            Else
                MessageBox.Show("No pilot was added.")
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