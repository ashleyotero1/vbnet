Imports System.Data.OleDb


Public Module Module1

    Public intPassengerID As Integer
    Public intPilotRoleID As Integer
    Public intPilotID As Integer
    Public intLoginID As Integer
    Public intFlightID As Integer
    Public intAttendantId As Integer
    Public m_conAdministrator As OleDb.OleDbConnection



    Private m_strDatabaseConnectionStringSQLServerV1 As String =
    "Provider=MSOLEDBSQL;" &
    "Data Source=DESKTOP-AB140SL;" &
    "Initial Catalog=dbFlyMe2theMoon;" &
    "Integrated Security=SSPI;"


#Region "Open/Close Connection"

    ' --------------------------------------------------------------------------------
    ' Name: OpenDatabaseConnectionMSAccess
    ' Abstract: Open a connection to the database.

    ' --------------------------------------------------------------------------------
    Public Function OpenDatabaseConnectionSQLServer() As Boolean

        Dim blnResult As Boolean = False

        Try

            ' Open a connection to the database
            m_conAdministrator = New OleDb.OleDbConnection
            m_conAdministrator.ConnectionString = m_strDatabaseConnectionStringSQLServerV1
            m_conAdministrator.Open()


            ' Success
            blnResult = True

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

        Return blnResult

    End Function



    ' --------------------------------------------------------------------------------
    ' Name: CloseDatabaseConnection
    ' Abstract: If the database connection is open then close it.  Release the
    '           memory.
    ' --------------------------------------------------------------------------------
    Public Function CloseDatabaseConnection() As Boolean

        Dim blnResult As Boolean = False

        Try

            ' Anything there?
            If m_conAdministrator IsNot Nothing Then

                ' Open?
                If m_conAdministrator.State <> ConnectionState.Closed Then

                    ' Yes, close it
                    m_conAdministrator.Close()

                End If

                ' Clean up
                m_conAdministrator = Nothing

            End If

            ' Success
            blnResult = True

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

        Return blnResult

    End Function

#End Region


    Public Sub Main()
        Application.Run(frmLogin)
    End Sub



End Module

