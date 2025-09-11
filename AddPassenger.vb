Imports System.Data.OleDb
Public Class AddPassenger

        Private Sub AddPassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim strSelect As String
            Dim cmdSelect As OleDbCommand
            Dim drSourceTable As OleDbDataReader
            Dim dt As New DataTable()

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show("Database connection failed.")
                Me.Close()
                Exit Sub
            End If

            strSelect = "SELECT intStateID, strState FROM TStates"
            cmdSelect = New OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader()
            dt.Load(drSourceTable)

            cboState.DisplayMember = "strState"
            cboState.ValueMember = "intStateID"
            cboState.DataSource = dt

            CloseDatabaseConnection()
        End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strInsert As String
        Dim strSelect As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim strState As String
        Dim strZip As String
        Dim strPhone As String
        Dim strEmail As String

        Dim cmdSelect As OleDbCommand
        Dim cmdInsert As OleDbCommand
        Dim drSourceTable As OleDbDataReader
        Dim intNextPrimaryKey As Integer
        Dim intRowsAffected As Integer

        If txtFirstName.Text = "" Then
            MessageBox.Show("First Name is required")
            Exit Sub
        End If

        If txtLastName.Text = "" Then
            MessageBox.Show("Last Name is required")
            Exit Sub
        End If

        If txtAddress.Text = "" Then
            MessageBox.Show("Address is required")
            Exit Sub
        End If

        If txtCity.Text = "" Then
            MessageBox.Show("City is required")
            Exit Sub
        End If

        If cboState.Text = "" Then
            MessageBox.Show("State is required")
            Exit Sub
        End If

        If txtZip.Text = "" Then
            MessageBox.Show("Zip Code is required")
            Exit Sub
        End If

        If txtPhone.Text = "" Then
            MessageBox.Show("Phone Number is required")
            Exit Sub
        End If

        If txtEmail.Text = "" Then
            MessageBox.Show("Email is required")
            Exit Sub
        End If

        If InStr(txtEmail.Text, "@") = 0 Then
            MessageBox.Show("Email must contain '@'")
            Exit Sub
        End If

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If

        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strAddress = txtAddress.Text
        strCity = txtCity.Text
        strState = cboState.SelectedValue.ToString()
        strZip = txtZip.Text
        strPhone = txtPhone.Text
        strEmail = txtEmail.Text

        strSelect = "SELECT MAX(intPassengerID) + 1 AS intNextPrimaryKey FROM TPassengers"
        cmdSelect = New OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader()
        drSourceTable.Read()

        If drSourceTable.IsDBNull(0) = True Then
            intNextPrimaryKey = 1
        Else
            intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))
        End If

        strInsert = "INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail) " &
            "VALUES (" & intNextPrimaryKey & ", '" & strFirstName & "', '" & strLastName & "', '" & strAddress & "', '" & strCity & "', " & strState & ", '" & strZip & "', '" & strPhone & "', '" & strEmail & "')"


        cmdInsert = New OleDbCommand(strInsert, m_conAdministrator)
        intRowsAffected = cmdInsert.ExecuteNonQuery()

        If intRowsAffected > 0 Then
            MessageBox.Show("Passenger has been added.")
            Me.Close()
        End If

        CloseDatabaseConnection()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


End Class