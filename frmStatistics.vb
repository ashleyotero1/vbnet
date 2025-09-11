Imports System.Data.OleDb

Public Class frmStatistics

    Private Sub frmStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show("Database connection failed.")
            Me.Close()
            Exit Sub
        End If

        ' Total Customers - Stored Procedure: usp_TotalPassengers
        Dim cmdTotalCustomers As New OleDbCommand("usp_TotalPassengers", m_conAdministrator)
        cmdTotalCustomers.CommandType = CommandType.StoredProcedure
        lblTotalCustomers.Text = CInt(cmdTotalCustomers.ExecuteScalar()).ToString()

        ' Total Flights - Stored Procedure: usp_TotalFlights
        Dim cmdTotalFlights As New OleDbCommand("usp_TotalFlights", m_conAdministrator)
        cmdTotalFlights.CommandType = CommandType.StoredProcedure
        lblTotalFlights.Text = CInt(cmdTotalFlights.ExecuteScalar()).ToString()

        ' Average Miles - Stored Procedure: usp_AverageFlightMiles
        Dim cmdAvgMiles As New OleDbCommand("usp_AverageFlightMiles", m_conAdministrator)
        cmdAvgMiles.CommandType = CommandType.StoredProcedure
        Dim avgMiles As Object = cmdAvgMiles.ExecuteScalar()
        If avgMiles IsNot DBNull.Value Then
            lblAverageMiles.Text = CInt(avgMiles).ToString()
        Else
            lblAverageMiles.Text = "0"
        End If

        ' Pilot Miles - Stored Procedure: usp_PilotMiles
        Dim cmdPilotMiles As New OleDbCommand("usp_PilotMiles", m_conAdministrator)
        cmdPilotMiles.CommandType = CommandType.StoredProcedure
        Dim rdrPilot As OleDbDataReader = cmdPilotMiles.ExecuteReader()
        lstPilotMiles.Items.Clear()
        While rdrPilot.Read()
            lstPilotMiles.Items.Add(rdrPilot("FullName").ToString() & " - " & rdrPilot("TotalMiles").ToString())
        End While
        rdrPilot.Close()

        ' Attendant Miles - Stored Procedure: usp_AttendantMiles
        Dim cmdAttMiles As New OleDbCommand("usp_AttendantMiles", m_conAdministrator)
        cmdAttMiles.CommandType = CommandType.StoredProcedure
        Dim rdrAtt As OleDbDataReader = cmdAttMiles.ExecuteReader()
        lstAttendantMiles.Items.Clear()
        While rdrAtt.Read()
            lstAttendantMiles.Items.Add(rdrAtt("FullName").ToString() & " - " & rdrAtt("TotalMiles").ToString())
        End While
        rdrAtt.Close()

        CloseDatabaseConnection()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class

