Imports System.Data.OleDb

Public Class frmAssignAttendantFlight

    Private Sub frmAssignAttendantFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenDatabaseConnectionSQLServer()

        Dim strSelectAttendant As String = "SELECT intAttendantID, strFirstName + ' ' + strLastName AS FullName FROM TAttendants"
        Dim cmdSelectAttendant As New OleDb.OleDbCommand(strSelectAttendant, m_conAdministrator)
        Dim rdrAttendant As OleDb.OleDbDataReader = cmdSelectAttendant.ExecuteReader()

        While rdrAttendant.Read()
            cboAttendant.Items.Add(rdrAttendant("intAttendantID").ToString() & " - " & rdrAttendant("FullName").ToString())
        End While
        rdrAttendant.Close()

        Dim strSelectFlight As String = "SELECT intFlightID, strFlightNumber FROM TFlights"
        Dim cmdSelectFlight As New OleDb.OleDbCommand(strSelectFlight, m_conAdministrator)
        Dim rdrFlight As OleDb.OleDbDataReader = cmdSelectFlight.ExecuteReader()

        While rdrFlight.Read()
            cboFlight.Items.Add(rdrFlight("intFlightID").ToString() & " - " & rdrFlight("strFlightNumber").ToString())
        End While
        rdrFlight.Close()

        CloseDatabaseConnection()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboAttendant.SelectedIndex = -1 Or cboFlight.SelectedIndex = -1 Then
            MessageBox.Show("Please select both an attendant and a flight.")
            Exit Sub
        End If

        Dim intAttendantID As Integer = CInt(cboAttendant.SelectedItem.ToString().Split("-"c)(0).Trim())
        Dim intFlightID As Integer = CInt(cboFlight.SelectedItem.ToString().Split("-"c)(0).Trim())

        OpenDatabaseConnectionSQLServer()
        Dim strPK As String = "SELECT MAX(intAttendantFlightID) + 1 FROM TAttendantFlights"
        Dim cmdPK As New OleDb.OleDbCommand(strPK, m_conAdministrator)
        Dim intNextPK As Integer = CInt(cmdPK.ExecuteScalar())
        CloseDatabaseConnection()

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to assign this attendant to the flight?", "Confirm Assignment", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            OpenDatabaseConnectionSQLServer()

            Dim strInsert As String = "INSERT INTO TAttendantFlights (intAttendantFlightID, intAttendantID, intFlightID) VALUES (?, ?, ?)"
            Dim cmdInsert As New OleDb.OleDbCommand(strInsert, m_conAdministrator)
            cmdInsert.Parameters.AddWithValue("intAttendantFlightID", intNextPK)
            cmdInsert.Parameters.AddWithValue("intAttendantID", intAttendantID)
            cmdInsert.Parameters.AddWithValue("intFlightID", intFlightID)

            Try
                cmdInsert.ExecuteNonQuery()
                MessageBox.Show("Attendant assigned to flight.")
            Catch ex As Exception
                MessageBox.Show("Error assigning attendant: " & ex.Message)
            End Try

            CloseDatabaseConnection()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class