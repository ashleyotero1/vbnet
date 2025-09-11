Imports System.Data.OleDb

Public Class frmAttendantLogin

    Private Sub frmAttendantLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSQL As String
        Dim cmd As OleDbCommand
        Dim rdr As OleDbDataReader
        Dim dt As New DataTable


        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Me.Close()
            Exit Sub
        End If


        strSQL = "SELECT intAttendantID, strLastName FROM TAttendants"
        cmd = New OleDbCommand(strSQL, m_conAdministrator)
        rdr = cmd.ExecuteReader()

        dt.Load(rdr)


        cboAttendantLogin.DisplayMember = "strLastName"
        cboAttendantLogin.ValueMember = "intAttendantID"
        cboAttendantLogin.DataSource = dt


        rdr.Close()
        CloseDatabaseConnection()
    End Sub


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboAttendantLogin.SelectedIndex <> -1 Then
            intAttendantID = CInt(cboAttendantLogin.SelectedValue)
            Me.Hide()
            frmAttendantMainMenu.ShowDialog()
        Else
            MessageBox.Show("Please select an attendant from the list.")
        End If
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
        frmUserType.Show()
    End Sub

End Class