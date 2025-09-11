Imports System.Data.OleDb

Public Class frmCustomerFutureFlights
    Private Sub frmCustomerFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstFutureFlights.Items.Clear()
        lblTotalMiles.Text = ""

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Exit Sub
        End If

        Dim cmdSelect As New OleDbCommand("usp_GetCustomerFutureFlights", m_conAdministrator)
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.AddWithValue("@PassengerID", intPassengerID)

        Dim rdr As OleDbDataReader = cmdSelect.ExecuteReader()
        Dim intTotalMiles As Integer = 0

        If rdr.HasRows = False Then
            lstFutureFlights.Items.Add("No future flights currently")
        Else
            While rdr.Read()
                Dim strFlightDetails As String = "Flight: " & rdr("strFlightNumber").ToString() &
                ", Date: " & CDate(rdr("dtmFlightDate")).ToShortDateString() &
                ", Miles: " & rdr("intMilesFlown").ToString()
                lstFutureFlights.Items.Add(strFlightDetails)

                intTotalMiles += CInt(rdr("intMilesFlown"))
            End While
        End If

        lblTotalMiles.Text = intTotalMiles.ToString()

        rdr.Close()
        CloseDatabaseConnection()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


End Class