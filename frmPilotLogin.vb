Imports System.Data.OleDb

Public Class frmPilotLogin

    Private Sub frmPilotLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSQL As String
        Dim cmd As OleDbCommand
        Dim rdr As OleDbDataReader
        Dim dt As New DataTable


        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If


        strSQL = "SELECT intPilotID, strLastName FROM TPilots"
        cmd = New OleDbCommand(strSQL, m_conAdministrator)
        rdr = cmd.ExecuteReader()
        dt.Load(rdr)


        cboPilot.DisplayMember = "strLastName"
        cboPilot.ValueMember = "intPilotID"
        cboPilot.DataSource = dt


        rdr.Close()
        CloseDatabaseConnection()
    End Sub


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboPilot.SelectedIndex <> -1 Then

            intPilotID = CInt(cboPilot.SelectedValue)


            frmPilotMainMenu.ShowDialog()
        Else
            MessageBox.Show("Please select a pilot from the list.")
        End If
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


End Class
