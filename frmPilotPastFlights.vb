Imports System.Data.OleDb

Public Class frmPilotPastFlights
    Private Sub frmPilotPastFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ListBox1.Items.Clear()
        lblPastMiles.Text = ""


        OpenDatabaseConnectionSQLServer()


        Dim strSQL As String = "SELECT TFlights.strFlightNumber, TFlights.dtmFlightDate, TFlights.intMilesFlown " &
                               "FROM TFlights " &
                               "INNER JOIN TPilotFlights ON TFlights.intFlightID = TPilotFlights.intFlightID " &
                               "WHERE TPilotFlights.intPilotID = ? AND TFlights.dtmFlightDate < GETDATE()"

        Dim cmd As New OleDbCommand(strSQL, m_conAdministrator)
        cmd.Parameters.AddWithValue("?", intPilotID)

        Dim rdr As OleDbDataReader = cmd.ExecuteReader()

        Dim intTotalMiles As Integer = 0

        While rdr.Read()

            Dim strFlightNumber As String = rdr("strFlightNumber").ToString()
            Dim dtmFlightDate As Date = CDate(rdr("dtmFlightDate"))
            Dim intMiles As Integer = CInt(rdr("intMilesFlown"))

            ListBox1.Items.Add("Flight " & strFlightNumber & " - " & dtmFlightDate.ToShortDateString())
            intTotalMiles += intMiles
        End While


        lblPastMiles.Text = intTotalMiles.ToString()


        rdr.Close()
        CloseDatabaseConnection()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


End Class

