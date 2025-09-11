Imports System.Data.OleDb

Public Class frmCreateFutureFlights

    Private Sub frmCreateFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim strPlanes As String = "SELECT P.intPlaneID, P.strPlaneNumber + ' - ' + T.strPlaneType AS PlaneDisplay " &
                                      "FROM TPlanes P JOIN TPlaneTypes T ON P.intPlaneTypeID = T.intPlaneTypeID"
            Dim cmdPlanes As New OleDbCommand(strPlanes, m_conAdministrator)
            Dim rdrPlanes As OleDbDataReader = cmdPlanes.ExecuteReader()
            Dim dtPlanes As New DataTable()
            dtPlanes.Load(rdrPlanes)
            cboPlane.DataSource = dtPlanes
            cboPlane.DisplayMember = "PlaneDisplay"
            cboPlane.ValueMember = "intPlaneID"


            Dim strFrom As String = "SELECT intAirportID, strAirportCity + ' (' + strAirportCode + ')' AS AirportDisplay FROM TAirports"
            Dim cmdFrom As New OleDbCommand(strFrom, m_conAdministrator)
            Dim rdrFrom As OleDbDataReader = cmdFrom.ExecuteReader()
            Dim dtFrom As New DataTable()
            dtFrom.Load(rdrFrom)
            cboFromAirport.DataSource = dtFrom
            cboFromAirport.DisplayMember = "AirportDisplay"
            cboFromAirport.ValueMember = "intAirportID"


            Dim strTo As String = "SELECT intAirportID, strAirportCity + ' (' + strAirportCode + ')' AS AirportDisplay FROM TAirports"
            Dim cmdTo As New OleDbCommand(strTo, m_conAdministrator)
            Dim rdrTo As OleDbDataReader = cmdTo.ExecuteReader()
            Dim dtTo As New DataTable()
            dtTo.Load(rdrTo)
            cboToAirport.DataSource = dtTo
            cboToAirport.DisplayMember = "AirportDisplay"
            cboToAirport.ValueMember = "intAirportID"


            Dim strPilot As String = "SELECT intPilotID, strFirstName + ' ' + strLastName AS PilotName FROM TPilots"
            Dim cmdPilot As New OleDbCommand(strPilot, m_conAdministrator)
            Dim rdrPilot As OleDbDataReader = cmdPilot.ExecuteReader()
            Dim dtPilot As New DataTable()
            dtPilot.Load(rdrPilot)
            cboPilot.DataSource = dtPilot
            cboPilot.DisplayMember = "PilotName"
            cboPilot.ValueMember = "intPilotID"


            Dim strAttendant As String = "SELECT intAttendantID, strFirstName + ' ' + strLastName AS AttendantName FROM TAttendants"
            Dim cmdAttendant As New OleDbCommand(strAttendant, m_conAdministrator)
            Dim rdrAttendant As OleDbDataReader = cmdAttendant.ExecuteReader()
            Dim dtAttendant As New DataTable()
            dtAttendant.Load(rdrAttendant)
            cboAtendant.DataSource = dtAttendant
            cboAtendant.DisplayMember = "AttendantName"
            cboAtendant.ValueMember = "intAttendantID"

        Catch ex As Exception
            MessageBox.Show("Error loading dropdowns: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim intFlightID As Integer
        Dim strFlightNumber As String = txtFlightNumber.Text
        Dim dtFlightDate As Date = CDate(txtFlightDate.Text)
        Dim tmDeparture As DateTime = DateTime.Parse(txtDepartureTime.Text)
        Dim tmLanding As DateTime = DateTime.Parse(txtLandingTime.Text)
        Dim intFromAirportID As Integer = cboFromAirport.SelectedValue
        Dim intToAirportID As Integer = cboToAirport.SelectedValue
        Dim intMilesFlown As Integer = CInt(txtMilesFlown.Text)
        Dim intPlaneID As Integer = cboPlane.SelectedValue


        Dim cmdGetMax As New OleDb.OleDbCommand("SELECT MAX(intFlightID) + 1 FROM TFlights", m_conAdministrator)
        Try
            OpenDatabaseConnectionSQLServer()

            Dim result = cmdGetMax.ExecuteScalar()
            If IsDBNull(result) Then
                intFlightID = 1
            Else
                intFlightID = CInt(result)
            End If


            Dim cmdInsert As New OleDb.OleDbCommand("usp_AddFlight", m_conAdministrator)
            cmdInsert.CommandType = CommandType.StoredProcedure

            cmdInsert.Parameters.AddWithValue("@intFlightID", intFlightID)
            cmdInsert.Parameters.AddWithValue("@FlightNumber", strFlightNumber)
            cmdInsert.Parameters.AddWithValue("@FlightDate", dtFlightDate)
            cmdInsert.Parameters.AddWithValue("@TimeOfDeparture", tmDeparture)
            cmdInsert.Parameters.AddWithValue("@TimeOfLanding", tmLanding)
            cmdInsert.Parameters.AddWithValue("@FromAirportID", intFromAirportID)
            cmdInsert.Parameters.AddWithValue("@ToAirportID", intToAirportID)
            cmdInsert.Parameters.AddWithValue("@MilesFlown", intMilesFlown)
            cmdInsert.Parameters.AddWithValue("@PlaneID", intPlaneID)

            Dim intRowsAffected As Integer = cmdInsert.ExecuteNonQuery()

            If intRowsAffected > 0 Then
                MessageBox.Show("Flight created successfully!")
            Else
                MessageBox.Show("Failed to create flight.")
            End If

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub



    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class