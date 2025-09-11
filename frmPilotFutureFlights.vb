Imports System.Data.OleDb

Public Class frmPilotFutureFlights


    Private Sub frmPilotFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ListBox1.Items.Clear()
        lblFutureMiles.Text = ""


        Dim strSelect As String = "SELECT strFlightNumber, dtmFlightDate, intMilesFlown, " &
                                  "FromAirports.strAirportCity AS FromCity, " &
                                  "ToAirports.strAirportCity AS ToCity " &
                                  "FROM TFlights " &
                                  "INNER JOIN TPilotFlights ON TFlights.intFlightID = TPilotFlights.intFlightID " &
                                  "INNER JOIN TAirports AS FromAirports ON TFlights.intFromAirportID = FromAirports.intAirportID " &
                                  "INNER JOIN TAirports AS ToAirports ON TFlights.intToAirportID = ToAirports.intAirportID " &
                                  "WHERE TPilotFlights.intPilotID = ? AND dtmFlightDate > GETDATE()"


        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If

        Dim cmdSelect As New OleDbCommand(strSelect, m_conAdministrator)
        cmdSelect.Parameters.AddWithValue("intPilotID", intPilotID)

        Dim rdr As OleDbDataReader = cmdSelect.ExecuteReader()
        Dim intTotalMiles As Integer = 0


        If rdr.HasRows = False Then
            ListBox1.Items.Add("No future flights currently")
        Else
            While rdr.Read()
                Dim strFlightDetails As String = "Flight: " & rdr("strFlightNumber").ToString() &
                                                 ", Date: " & CDate(rdr("dtmFlightDate")).ToShortDateString() &
                                                 ", From: " & rdr("FromCity").ToString() &
                                                 ", To: " & rdr("ToCity").ToString() &
                                                 ", Miles: " & rdr("intMilesFlown").ToString()

                ListBox1.Items.Add(strFlightDetails)
                intTotalMiles += CInt(rdr("intMilesFlown"))
            End While
        End If

        lblFutureMiles.Text = intTotalMiles.ToString()

        rdr.Close()
        CloseDatabaseConnection()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


End Class