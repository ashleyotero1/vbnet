<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistics
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
        Me.lblTotalCustomers = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalFlights = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAverageMiles = New System.Windows.Forms.Label()
        Me.lstPilotMiles = New System.Windows.Forms.ListBox()
        Me.lstAttendantMiles = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTotalCustomers
        '
        Me.lblTotalCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCustomers.Location = New System.Drawing.Point(99, 12)
        Me.lblTotalCustomers.Name = "lblTotalCustomers"
        Me.lblTotalCustomers.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalCustomers.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Customers:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Total Customer Flights:"
        '
        'lblTotalFlights
        '
        Me.lblTotalFlights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalFlights.Location = New System.Drawing.Point(358, 11)
        Me.lblTotalFlights.Name = "lblTotalFlights"
        Me.lblTotalFlights.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalFlights.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(513, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Average Miles Customer Flown:"
        '
        'lblAverageMiles
        '
        Me.lblAverageMiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAverageMiles.Location = New System.Drawing.Point(674, 9)
        Me.lblAverageMiles.Name = "lblAverageMiles"
        Me.lblAverageMiles.Size = New System.Drawing.Size(100, 23)
        Me.lblAverageMiles.TabIndex = 5
        '
        'lstPilotMiles
        '
        Me.lstPilotMiles.FormattingEnabled = True
        Me.lstPilotMiles.Location = New System.Drawing.Point(22, 96)
        Me.lstPilotMiles.Name = "lstPilotMiles"
        Me.lstPilotMiles.Size = New System.Drawing.Size(346, 277)
        Me.lstPilotMiles.TabIndex = 6
        '
        'lstAttendantMiles
        '
        Me.lstAttendantMiles.FormattingEnabled = True
        Me.lstAttendantMiles.Location = New System.Drawing.Point(444, 96)
        Me.lstAttendantMiles.Name = "lstAttendantMiles"
        Me.lstAttendantMiles.Size = New System.Drawing.Size(344, 277)
        Me.lstAttendantMiles.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Pilots/ Miles:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(444, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Attendants/Miles:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(368, 396)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lstAttendantMiles)
        Me.Controls.Add(Me.lstPilotMiles)
        Me.Controls.Add(Me.lblAverageMiles)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblTotalFlights)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTotalCustomers)
        Me.Name = "frmStatistics"
        Me.Text = "frmStatistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTotalCustomers As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalFlights As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblAverageMiles As Label
    Friend WithEvents lstPilotMiles As ListBox
    Friend WithEvents lstAttendantMiles As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnExit As Button
End Class
