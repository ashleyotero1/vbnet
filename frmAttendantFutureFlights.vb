Imports System.Data.OleDb

Public Class frmAttendantFutureFlights
    Private Sub frmAttendantFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSQL As String
        Dim cmdSelect As OleDbCommand
        Dim rdr As OleDbDataReader

        ListBox1.Items.Clear()


        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Me.Close()
            Exit Sub
        End If

        strSQL = "SELECT strFlightNumber, dtmFlightDate, dtmTimeOfDeparture, dtmTimeOfLanding " &
                 "FROM TFlights INNER JOIN TAttendantFlights ON TFlights.intFlightID = TAttendantFlights.intFlightID " &
                 "WHERE TAttendantFlights.intAttendantID = " & intAttendantId & " AND dtmFlightDate > GETDATE()"


        cmdSelect = New OleDbCommand(strSQL, m_conAdministrator)
        rdr = cmdSelect.ExecuteReader()


        If rdr.HasRows Then
            While rdr.Read()
                ListBox1.Items.Add("Flight: " & rdr("strFlightNumber") &
                                   " | Date: " & CDate(rdr("dtmFlightDate")).ToShortDateString() &
                                   " | Depart: " & rdr("dtmTimeOfDeparture").ToString &
                                   " | Arrive: " & rdr("dtmTimeOfLanding").ToString)
            End While
        Else
            ListBox1.Items.Add("No future flights.")
        End If

        rdr.Close()
        CloseDatabaseConnection()
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


End Class