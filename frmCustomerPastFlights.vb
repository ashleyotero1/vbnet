Imports System.Data.OleDb

Public Class frmCustomerPastFlights
    Private Sub frmCustomerPastFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lstPastFlights.Items.Clear()
        lblTotalMiles.Text = ""


        OpenDatabaseConnectionSQLServer()


        Dim strSQL As String = "SELECT TFlights.strFlightNumber, TFlights.dtmFlightDate, TFlights.intMilesFlown " &
                               "FROM TFlights " &
                               "INNER JOIN TFlightPassengers ON TFlights.intFlightID = TFlightPassengers.intFlightID " &
                               "WHERE TFlightPassengers.intPassengerID = ? AND TFlights.dtmFlightDate < GETDATE()"

        Dim cmd As New OleDbCommand(strSQL, m_conAdministrator)
        cmd.Parameters.AddWithValue("?", intPassengerID)

        Dim rdr As OleDbDataReader = cmd.ExecuteReader()

        Dim intTotalMiles As Integer = 0

        While rdr.Read()

            Dim strFlightNumber As String = rdr("strFlightNumber").ToString()
            Dim dtmFlightDate As Date = CDate(rdr("dtmFlightDate"))
            Dim intMiles As Integer = CInt(rdr("intMilesFlown"))

            lstPastFlights.Items.Add("Flight " & strFlightNumber & " - " & dtmFlightDate.ToShortDateString())
            intTotalMiles += intMiles
        End While


        lblTotalMiles.Text = intTotalMiles.ToString()


        rdr.Close()
        CloseDatabaseConnection()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub



End Class








