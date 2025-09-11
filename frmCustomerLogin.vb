Imports System.Data.OleDb

Public Class frmCustomerLogin

    Private Sub frmCustomerLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim cmd As OleDbCommand
        Dim rdr As OleDbDataReader
        Dim dt As New DataTable


        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If


        strSQL = "SELECT intPassengerID, strLastName FROM TPassengers"
        cmd = New OleDbCommand(strSQL, m_conAdministrator)
        rdr = cmd.ExecuteReader()
        dt.Load(rdr)


        cboCustomer.DisplayMember = "strLastName"
        cboCustomer.ValueMember = "intPassengerID"
        cboCustomer.DataSource = dt


        rdr.Close()
        CloseDatabaseConnection()
    End Sub


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboCustomer.SelectedIndex <> -1 Then

            intPassengerID = CInt(cboCustomer.SelectedValue)


            frmCustomerMainMenu.ShowDialog()
        Else
            MessageBox.Show("Please select a passenger from the list.")
        End If
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Me.Close()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        AddPassenger.Show()
        Me.Hide()
    End Sub


End Class
