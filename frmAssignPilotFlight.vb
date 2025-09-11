Imports System.Data.OleDb

Public Class frmAssignPilotFlight

    Private Sub frmAssignPilotFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Me.Close()
            Exit Sub
        End If

        Dim strSQLPilot As String = "SELECT intPilotID, strLastName FROM TPilots"
        Dim cmdPilot As New OleDbCommand(strSQLPilot, m_conAdministrator)
        Dim rdrPilot As OleDbDataReader = cmdPilot.ExecuteReader()

        cboPilot.Items.Clear()
        While rdrPilot.Read()
            cboPilot.Items.Add(rdrPilot("intPilotID") & " " & rdrPilot("strLastName"))
        End While
        rdrPilot.Close()

        Dim strSQLFlight As String = "SELECT intFlightID, strFlightNumber FROM TFlights"
        Dim cmdFlight As New OleDbCommand(strSQLFlight, m_conAdministrator)
        Dim rdrFlight As OleDbDataReader = cmdFlight.ExecuteReader()

        cboFlights.Items.Clear()
        While rdrFlight.Read()
            cboFlights.Items.Add(rdrFlight("intFlightID") & " " & rdrFlight("strFlightNumber"))
        End While
        rdrFlight.Close()

        CloseDatabaseConnection()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboPilot.SelectedIndex = -1 Or cboFlights.SelectedIndex = -1 Then
            MessageBox.Show("Please select both a pilot and a flight.")
            Exit Sub
        End If

        Dim intPilotID As Integer = CInt(cboPilot.SelectedItem.ToString().Split(" "c)(0))
        Dim intFlightID As Integer = CInt(cboFlights.SelectedItem.ToString().Split(" "c)(0))

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to assign pilot to flight?", "Confirm Assignment", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then Exit Sub

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If

        Dim strPK As String = "SELECT MAX(intPilotFlightID) + 1 AS intNextPrimaryKey FROM TPilotFlights"
        Dim cmdPK As New OleDbCommand(strPK, m_conAdministrator)
        Dim rdrPK As OleDbDataReader = cmdPK.ExecuteReader()
        Dim intNextPrimaryKey As Integer = 1
        If rdrPK.Read() AndAlso Not IsDBNull(rdrPK("intNextPrimaryKey")) Then
            intNextPrimaryKey = CInt(rdrPK("intNextPrimaryKey"))
        End If
        rdrPK.Close()

        Dim strInsert As String = "INSERT INTO TPilotFlights (intPilotFlightID, intPilotID, intFlightID) " &
                                  "VALUES (" & intNextPrimaryKey & ", " & intPilotID & ", " & intFlightID & ")"
        Dim cmdInsert As New OleDbCommand(strInsert, m_conAdministrator)

        Try
            cmdInsert.ExecuteNonQuery()
            MessageBox.Show("Pilot assigned to flight.")
        Catch ex As Exception
            MessageBox.Show("Error assigning pilot: " & ex.Message)
        End Try

        CloseDatabaseConnection()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class