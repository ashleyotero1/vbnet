<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotMainMenu
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
        Me.btnUpdatePilot = New System.Windows.Forms.Button()
        Me.btnPastFlight = New System.Windows.Forms.Button()
        Me.btnFutureFlights = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnUpdatePilot
        '
        Me.btnUpdatePilot.Location = New System.Drawing.Point(48, 49)
        Me.btnUpdatePilot.Name = "btnUpdatePilot"
        Me.btnUpdatePilot.Size = New System.Drawing.Size(89, 39)
        Me.btnUpdatePilot.TabIndex = 0
        Me.btnUpdatePilot.Text = "Update Pilot Profile"
        Me.btnUpdatePilot.UseVisualStyleBackColor = True
        '
        'btnPastFlight
        '
        Me.btnPastFlight.Location = New System.Drawing.Point(207, 49)
        Me.btnPastFlight.Name = "btnPastFlight"
        Me.btnPastFlight.Size = New System.Drawing.Size(86, 39)
        Me.btnPastFlight.TabIndex = 1
        Me.btnPastFlight.Text = "Show Past Flights"
        Me.btnPastFlight.UseVisualStyleBackColor = True
        '
        'btnFutureFlights
        '
        Me.btnFutureFlights.Location = New System.Drawing.Point(48, 127)
        Me.btnFutureFlights.Name = "btnFutureFlights"
        Me.btnFutureFlights.Size = New System.Drawing.Size(89, 45)
        Me.btnFutureFlights.TabIndex = 2
        Me.btnFutureFlights.Text = "Show Future Flights"
        Me.btnFutureFlights.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(207, 127)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(86, 45)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmPilotMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 214)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnFutureFlights)
        Me.Controls.Add(Me.btnPastFlight)
        Me.Controls.Add(Me.btnUpdatePilot)
        Me.Name = "frmPilotMainMenu"
        Me.Text = "frmPilotMainMenu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnUpdatePilot As Button
    Friend WithEvents btnPastFlight As Button
    Friend WithEvents btnFutureFlights As Button
    Friend WithEvents btnExit As Button
End Class
