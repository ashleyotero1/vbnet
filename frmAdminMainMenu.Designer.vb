<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAddPilot = New System.Windows.Forms.Button()
        Me.btnDeletePilot = New System.Windows.Forms.Button()
        Me.btnAssignPilotFlight = New System.Windows.Forms.Button()
        Me.btnViewStats = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAddAttendant = New System.Windows.Forms.Button()
        Me.btnDeleteAtendant = New System.Windows.Forms.Button()
        Me.btnAssignAttendantFlight = New System.Windows.Forms.Button()
        Me.btnCreateFutureFlights = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddPilot
        '
        Me.btnAddPilot.Location = New System.Drawing.Point(41, 25)
        Me.btnAddPilot.Name = "btnAddPilot"
        Me.btnAddPilot.Size = New System.Drawing.Size(92, 34)
        Me.btnAddPilot.TabIndex = 0
        Me.btnAddPilot.Text = "Add Pilot"
        Me.btnAddPilot.UseVisualStyleBackColor = True
        '
        'btnDeletePilot
        '
        Me.btnDeletePilot.Location = New System.Drawing.Point(177, 89)
        Me.btnDeletePilot.Name = "btnDeletePilot"
        Me.btnDeletePilot.Size = New System.Drawing.Size(92, 35)
        Me.btnDeletePilot.TabIndex = 1
        Me.btnDeletePilot.Text = "Delete Pilot"
        Me.btnDeletePilot.UseVisualStyleBackColor = True
        '
        'btnAssignPilotFlight
        '
        Me.btnAssignPilotFlight.Location = New System.Drawing.Point(177, 150)
        Me.btnAssignPilotFlight.Name = "btnAssignPilotFlight"
        Me.btnAssignPilotFlight.Size = New System.Drawing.Size(92, 56)
        Me.btnAssignPilotFlight.TabIndex = 2
        Me.btnAssignPilotFlight.Text = "Assign Pilot To Future Flight"
        Me.btnAssignPilotFlight.UseVisualStyleBackColor = True
        '
        'btnViewStats
        '
        Me.btnViewStats.Location = New System.Drawing.Point(41, 233)
        Me.btnViewStats.Name = "btnViewStats"
        Me.btnViewStats.Size = New System.Drawing.Size(92, 38)
        Me.btnViewStats.TabIndex = 3
        Me.btnViewStats.Text = "System Statistics"
        Me.btnViewStats.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(100, 295)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(92, 38)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddAttendant
        '
        Me.btnAddAttendant.Location = New System.Drawing.Point(177, 25)
        Me.btnAddAttendant.Name = "btnAddAttendant"
        Me.btnAddAttendant.Size = New System.Drawing.Size(92, 34)
        Me.btnAddAttendant.TabIndex = 5
        Me.btnAddAttendant.Text = "Add Attendant"
        Me.btnAddAttendant.UseVisualStyleBackColor = True
        '
        'btnDeleteAtendant
        '
        Me.btnDeleteAtendant.Location = New System.Drawing.Point(41, 87)
        Me.btnDeleteAtendant.Name = "btnDeleteAtendant"
        Me.btnDeleteAtendant.Size = New System.Drawing.Size(92, 37)
        Me.btnDeleteAtendant.TabIndex = 6
        Me.btnDeleteAtendant.Text = "Delete Attendant"
        Me.btnDeleteAtendant.UseVisualStyleBackColor = True
        '
        'btnAssignAttendantFlight
        '
        Me.btnAssignAttendantFlight.Location = New System.Drawing.Point(41, 150)
        Me.btnAssignAttendantFlight.Name = "btnAssignAttendantFlight"
        Me.btnAssignAttendantFlight.Size = New System.Drawing.Size(92, 56)
        Me.btnAssignAttendantFlight.TabIndex = 7
        Me.btnAssignAttendantFlight.Text = "Assign Attendant to Future Flight"
        Me.btnAssignAttendantFlight.UseVisualStyleBackColor = True
        '
        'btnCreateFutureFlights
        '
        Me.btnCreateFutureFlights.Location = New System.Drawing.Point(177, 233)
        Me.btnCreateFutureFlights.Name = "btnCreateFutureFlights"
        Me.btnCreateFutureFlights.Size = New System.Drawing.Size(92, 38)
        Me.btnCreateFutureFlights.TabIndex = 8
        Me.btnCreateFutureFlights.Text = "Create Future Flights"
        Me.btnCreateFutureFlights.UseVisualStyleBackColor = True
        '
        'frmAdminMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 345)
        Me.Controls.Add(Me.btnCreateFutureFlights)
        Me.Controls.Add(Me.btnAssignAttendantFlight)
        Me.Controls.Add(Me.btnDeleteAtendant)
        Me.Controls.Add(Me.btnAddAttendant)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnViewStats)
        Me.Controls.Add(Me.btnAssignPilotFlight)
        Me.Controls.Add(Me.btnDeletePilot)
        Me.Controls.Add(Me.btnAddPilot)
        Me.Name = "frmAdminMainMenu"
        Me.Text = "frmAdminMainMenu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddPilot As Button
    Friend WithEvents btnDeletePilot As Button
    Friend WithEvents btnAssignPilotFlight As Button
    Friend WithEvents btnViewStats As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnAddAttendant As Button
    Friend WithEvents btnDeleteAtendant As Button
    Friend WithEvents btnAssignAttendantFlight As Button
    Friend WithEvents btnCreateFutureFlights As Button
End Class
