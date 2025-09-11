Imports System.Data.OleDb

Public Class frmUpdatePilot

    Private m_blnIsLoading As Boolean = True
    Private m_intSelectedPilotID As Integer

    Private Sub frmUpdatePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Me.Close()
            Exit Sub
        End If

        ' Load Pilots into ComboBox
        Dim strSelectPilots As String =
            "SELECT intPilotID, strFirstName + ' ' + strLastName AS FullName FROM TPilots"
        Dim cmdSelectPilots As New OleDbCommand(strSelectPilots, m_conAdministrator)
        Dim drPilots As OleDbDataReader = cmdSelectPilots.ExecuteReader()
        Dim dtPilots As New DataTable()
        dtPilots.Load(drPilots)

        cboPilot.DisplayMember = "FullName"
        cboPilot.ValueMember = "intPilotID"
        cboPilot.DataSource = dtPilots
        drPilots.Close()


        Dim strSelectRoles As String = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"
        Dim cmdSelectRoles As New OleDbCommand(strSelectRoles, m_conAdministrator)
        Dim drRoles As OleDbDataReader = cmdSelectRoles.ExecuteReader()
        Dim dtRoles As New DataTable()
        dtRoles.Load(drRoles)

        cboRole.DisplayMember = "strPilotRole"
        cboRole.ValueMember = "intPilotRoleID"
        cboRole.DataSource = dtRoles
        drRoles.Close()

        CloseDatabaseConnection()
        m_blnIsLoading = False
    End Sub

    Private Sub cboPilots_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPilot.SelectedIndexChanged
        If m_blnIsLoading Then Exit Sub
        m_intSelectedPilotID = CInt(cboPilot.SelectedValue)

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If


        Dim strSelectPilot As String =
            "SELECT p.*, e.EmployeeLoginID, e.EmployeePassword " &
            "FROM TPilots p " &
            "LEFT JOIN TEmployee e ON e.EmployeeID = p.intPilotID AND e.EmployeeRole = 'Pilot' " &
            "WHERE p.intPilotID = " & m_intSelectedPilotID

        Dim cmdSelectPilot As New OleDbCommand(strSelectPilot, m_conAdministrator)
        Dim drPilot As OleDbDataReader = cmdSelectPilot.ExecuteReader()

        If drPilot.Read() Then
            txtFirstName.Text = drPilot("strFirstName").ToString()
            txtLastName.Text = drPilot("strLastName").ToString()
            txtEmployeeID.Text = drPilot("strEmployeeID").ToString()
            txtDateOfHire.Text = drPilot("dtmDateOfHire").ToString()
            txtDateOfTermination.Text = drPilot("dtmDateOfTermination").ToString()
            txtDateOfLicense.Text = drPilot("dtmDateOfLicense").ToString()
            cboRole.SelectedValue = drPilot("intPilotRoleID")
            txtUsername.Text = drPilot("EmployeeLoginID").ToString()
            txtPassword.Text = drPilot("EmployeePassword").ToString()
        End If

        drPilot.Close()
        CloseDatabaseConnection()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If

        Try

            Dim strUpdatePilot As String =
                "UPDATE TPilots SET strFirstName = ?, strLastName = ?, dtmDateOfHire = ?, dtmDateOfTermination = ?, dtmDateOfLicense = ?, intPilotRoleID = ? " &
                "WHERE intPilotID = ?"

            Dim cmdUpdate As New OleDb.OleDbCommand("usp_UpdatePilot", m_conAdministrator)
            cmdUpdate.CommandType = CommandType.StoredProcedure


            cmdUpdate.Parameters.AddWithValue("@intPilotID", CInt(cboPilot.SelectedValue))
            cmdUpdate.Parameters.AddWithValue("@strFirstName", txtFirstName.Text)
            cmdUpdate.Parameters.AddWithValue("@strLastName", txtLastName.Text)
            cmdUpdate.Parameters.AddWithValue("@strEmployeeID", txtEmployeeID.Text)
            cmdUpdate.Parameters.AddWithValue("@dtmDateOfHire", CDate(txtDateOfHire.Text))
            cmdUpdate.Parameters.AddWithValue("@dtmDateOfTermination", CDate(txtDateOfTermination.Text))
            cmdUpdate.Parameters.AddWithValue("@dtmDateOfLicense", CDate(txtDateOfLicense.Text))
            cmdUpdate.Parameters.AddWithValue("@intPilotRoleID", CInt(cboRole.SelectedValue))
            cmdUpdate.Parameters.AddWithValue("@EmployeeLoginID", txtUsername.Text)
            cmdUpdate.Parameters.AddWithValue("@EmployeePassword", txtPassword.Text)

            cmdUpdate.ExecuteNonQuery()


            Dim strUpdateEmp As String =
                "UPDATE TEmployee SET EmployeeLoginID = ?, EmployeePassword = ? " &
                "WHERE EmployeeID = ? AND EmployeeRole = 'Pilot'"

            Dim cmdUpdateEmp As New OleDbCommand(strUpdateEmp, m_conAdministrator)
            cmdUpdateEmp.Parameters.AddWithValue("@EmployeeLoginID", txtUsername.Text)
            cmdUpdateEmp.Parameters.AddWithValue("@EmployeePassword", txtPassword.Text)
            cmdUpdateEmp.Parameters.AddWithValue("@strEmployeeID", m_intSelectedPilotID)

            cmdUpdateEmp.ExecuteNonQuery()

            MessageBox.Show("Pilot and login info updated successfully.")

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