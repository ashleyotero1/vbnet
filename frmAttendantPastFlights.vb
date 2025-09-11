Imports System.Data.OleDb

Public Class frmAttendantPastFlights

    Private Sub frmAttendantPastFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strSQL As String
        Dim cmdSelect As OleDbCommand
        Dim rdr As OleDbDataReader
        Dim dt As New DataTable
        Dim intTotalMiles As Integer = 0


        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Me.Close()
            Exit Sub
        End If


        strSQL = "SELECT TFlights.strFlightNumber, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, TFlights.dtmTimeofLanding, TFlights.intMilesFlown " &
                 "FROM TFlights INNER JOIN TAttendantFlights " &
                 "ON TFlights.intFlightID = TAttendantFlights.intFlightID " &
                 "WHERE TAttendantFlights.intAttendantID = " & intAttendantId & " AND TFlights.dtmFlightDate < GETDATE() " &
                 "ORDER BY TFlights.dtmFlightDate DESC"


        cmdSelect = New OleDbCommand(strSQL, m_conAdministrator)


        rdr = cmdSelect.ExecuteReader

        If rdr.HasRows Then
            Do While rdr.Read
                Dim strFlightDetails As String = "Flight #: " & rdr("strFlightNumber").ToString() &
                                                  " | Date: " & CDate(rdr("dtmFlightDate")).ToShortDateString() &
                                                  " | Depart: " & rdr("dtmTimeofDeparture").ToString() &
                                                  " | Land: " & rdr("dtmTimeofLanding").ToString() &
                                                  " | Miles: " & rdr("intMilesFlown").ToString()

                ListBox1.Items.Add(strFlightDetails)


                intTotalMiles += CInt(rdr("intMilesFlown"))
            Loop


            lblTotalMiles.Text = intTotalMiles.ToString()

        Else
            ListBox1.Items.Add("No past flights found.")
            lblTotalMiles.Text = "0"
        End If


        rdr.Close()
        CloseDatabaseConnection()
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class