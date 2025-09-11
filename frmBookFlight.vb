Imports System.Data.OleDb

Public Class frmBookFlight
    Private intSelectedFlightID As Integer

    Private Sub frmBookFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        radReservedSeat.Visible = False
        radDesignatedSeat.Visible = False
        btnSubmit.Visible = False
        LoadFlights()
    End Sub

    Private Sub LoadFlights()
        Try
            OpenDatabaseConnectionSQLServer()
            Dim strSQL As String = "SELECT intFlightID, strFlightNumber FROM TFlights"
            Dim cmd As New OleDbCommand(strSQL, m_conAdministrator)
            Dim rdr As OleDbDataReader = cmd.ExecuteReader()
            cboFlights.Items.Clear()

            While rdr.Read()
                cboFlights.Items.Add(rdr("strFlightNumber").ToString())
            End While

            rdr.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error loading flights: " & ex.Message)
        End Try
    End Sub

    Private Sub cboFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFlights.SelectedIndexChanged
        If cboFlights.SelectedIndex <> -1 Then
            radReservedSeat.Visible = True
            radDesignatedSeat.Visible = True
            btnSubmit.Visible = True
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboFlights.SelectedIndex = -1 OrElse (radReservedSeat.Checked = False AndAlso radDesignatedSeat.Checked = False) Then
            MessageBox.Show("Please select a flight and seat type.")
            Exit Sub
        End If

        Try
            OpenDatabaseConnectionSQLServer()


            Dim strFlightNumber As String = cboFlights.SelectedItem.ToString()
            Dim cmdFlightID As New OleDbCommand("SELECT intFlightID FROM TFlights WHERE strFlightNumber = ?", m_conAdministrator)
            cmdFlightID.Parameters.AddWithValue("?", strFlightNumber)
            intSelectedFlightID = CInt(cmdFlightID.ExecuteScalar())


            Dim cmdDetails As New OleDbCommand("usp_GetFlightDetailsForCost", m_conAdministrator)
            cmdDetails.CommandType = CommandType.StoredProcedure
            cmdDetails.Parameters.AddWithValue("@FlightID", intSelectedFlightID)
            Dim rdr As OleDbDataReader = cmdDetails.ExecuteReader()

            Dim intMiles As Integer = 0
            Dim strPlaneType As String = ""
            Dim strDestination As String = ""

            If rdr.Read() Then
                intMiles = CInt(rdr("intMilesFlown"))
                strPlaneType = rdr("strPlaneType").ToString()
                strDestination = rdr("intToAirportID").ToString()
            End If
            rdr.Close()


            Dim cmdReserved As New OleDbCommand("usp_CountReservedSeats", m_conAdministrator)
            cmdReserved.CommandType = CommandType.StoredProcedure
            cmdReserved.Parameters.AddWithValue("@FlightID", intSelectedFlightID)
            Dim intReservedSeats As Integer = CInt(cmdReserved.ExecuteScalar())


            Dim cmdPast As New OleDbCommand("usp_CountPastFlights", m_conAdministrator)
            cmdPast.CommandType = CommandType.StoredProcedure
            cmdPast.Parameters.AddWithValue("@PassengerID", intPassengerID)
            cmdPast.Parameters.AddWithValue("@CurrentDate", DateTime.Now.Date)
            Dim intPastFlights As Integer = CInt(cmdPast.ExecuteScalar())


            Dim cost As Decimal = 250

            If intMiles > 750 Then cost += 50
            If intReservedSeats > 8 Then cost += 100
            If intReservedSeats < 4 Then cost -= 50
            If strPlaneType = "Airbus A350" Then cost += 35
            If strPlaneType = "Boeing 747-8" Then cost -= 25
            If strDestination = "MIA" Then cost += 15
            If radReservedSeat.Checked Then cost += 125


            Dim cmdAge As New OleDbCommand("SELECT PassengerDateOfBirth FROM TPassengers WHERE intPassengerID = ?", m_conAdministrator)
            cmdAge.Parameters.AddWithValue("?", intPassengerID)

            Dim dtmDOB As Date = CDate(cmdAge.ExecuteScalar())
            Dim today As Date = Date.Today

            Dim intAge As Integer = today.Year - dtmDOB.Year
            If dtmDOB > today.AddYears(-intAge) Then intAge -= 1


            If intAge >= 65 Then
                cost *= 0.8
            ElseIf intAge <= 5 Then
                cost *= 0.35
            End If


            If intPastFlights > 10 Then
                cost *= 0.8
            ElseIf intPastFlights > 5 Then
                cost *= 0.9
            End If


            Dim seatType As String = If(radReservedSeat.Checked, "Reserved", "Designated")
            Dim result = MessageBox.Show("Total Cost for " & seatType & " Seat: " & cost.ToString("C") & vbCrLf & "Confirm booking?", "Confirm", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then


                Dim intNextFlightPassengerID As Integer
                Dim cmdNextID As New OleDbCommand("SELECT MAX(intFlightPassengerID) FROM TFlightPassengers", m_conAdministrator)
                Dim objNextID As Object = cmdNextID.ExecuteScalar()

                If IsDBNull(objNextID) Then
                    intNextFlightPassengerID = 1
                Else
                    intNextFlightPassengerID = CInt(objNextID) + 1
                End If




                Dim strInsert As String = "INSERT INTO TFlightPassengers (intFlightPassengerID, intFlightID, intPassengerID, strSeat, FlightCost) VALUES (?, ?, ?, ?, ?)"

                Dim cmdInsert As New OleDbCommand(strInsert, m_conAdministrator)
                cmdInsert.Parameters.AddWithValue("intFlightPassengerID", intNextFlightPassengerID)
                cmdInsert.Parameters.AddWithValue("intFlightID", intSelectedFlightID)
                cmdInsert.Parameters.AddWithValue("intPassengerID", intPassengerID)
                cmdInsert.Parameters.AddWithValue("strSeat", seatType)
                cmdInsert.Parameters.AddWithValue("FlightCost", cost)
                cmdInsert.ExecuteNonQuery()
                MessageBox.Show("Flight booked successfully!", "Booking confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            CloseDatabaseConnection()
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
