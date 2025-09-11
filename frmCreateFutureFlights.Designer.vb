<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateFutureFlights
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
        Me.txtLandingTime = New System.Windows.Forms.TextBox()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.txtMilesFlown = New System.Windows.Forms.TextBox()
        Me.txtFlightDate = New System.Windows.Forms.TextBox()
        Me.txtDepartureTime = New System.Windows.Forms.TextBox()
        Me.cboFromAirport = New System.Windows.Forms.ComboBox()
        Me.cboPilot = New System.Windows.Forms.ComboBox()
        Me.cboToAirport = New System.Windows.Forms.ComboBox()
        Me.cboPlane = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cboAtendant = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtLandingTime
        '
        Me.txtLandingTime.Location = New System.Drawing.Point(116, 127)
        Me.txtLandingTime.Name = "txtLandingTime"
        Me.txtLandingTime.Size = New System.Drawing.Size(100, 20)
        Me.txtLandingTime.TabIndex = 0
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Location = New System.Drawing.Point(116, 12)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtFlightNumber.TabIndex = 1
        '
        'txtMilesFlown
        '
        Me.txtMilesFlown.Location = New System.Drawing.Point(116, 248)
        Me.txtMilesFlown.Name = "txtMilesFlown"
        Me.txtMilesFlown.Size = New System.Drawing.Size(100, 20)
        Me.txtMilesFlown.TabIndex = 3
        '
        'txtFlightDate
        '
        Me.txtFlightDate.Location = New System.Drawing.Point(116, 50)
        Me.txtFlightDate.Name = "txtFlightDate"
        Me.txtFlightDate.Size = New System.Drawing.Size(100, 20)
        Me.txtFlightDate.TabIndex = 4
        '
        'txtDepartureTime
        '
        Me.txtDepartureTime.Location = New System.Drawing.Point(116, 89)
        Me.txtDepartureTime.Name = "txtDepartureTime"
        Me.txtDepartureTime.Size = New System.Drawing.Size(100, 20)
        Me.txtDepartureTime.TabIndex = 5
        '
        'cboFromAirport
        '
        Me.cboFromAirport.FormattingEnabled = True
        Me.cboFromAirport.Location = New System.Drawing.Point(116, 166)
        Me.cboFromAirport.Name = "cboFromAirport"
        Me.cboFromAirport.Size = New System.Drawing.Size(121, 21)
        Me.cboFromAirport.TabIndex = 6
        '
        'cboPilot
        '
        Me.cboPilot.FormattingEnabled = True
        Me.cboPilot.Location = New System.Drawing.Point(116, 330)
        Me.cboPilot.Name = "cboPilot"
        Me.cboPilot.Size = New System.Drawing.Size(121, 21)
        Me.cboPilot.TabIndex = 7
        '
        'cboToAirport
        '
        Me.cboToAirport.FormattingEnabled = True
        Me.cboToAirport.Location = New System.Drawing.Point(116, 212)
        Me.cboToAirport.Name = "cboToAirport"
        Me.cboToAirport.Size = New System.Drawing.Size(121, 21)
        Me.cboToAirport.TabIndex = 8
        '
        'cboPlane
        '
        Me.cboPlane.FormattingEnabled = True
        Me.cboPlane.Location = New System.Drawing.Point(117, 287)
        Me.cboPlane.Name = "cboPlane"
        Me.cboPlane.Size = New System.Drawing.Size(121, 21)
        Me.cboPlane.TabIndex = 9
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(12, 433)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 10
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(163, 433)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cboAtendant
        '
        Me.cboAtendant.FormattingEnabled = True
        Me.cboAtendant.Location = New System.Drawing.Point(116, 372)
        Me.cboAtendant.Name = "cboAtendant"
        Me.cboAtendant.Size = New System.Drawing.Size(121, 21)
        Me.cboAtendant.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Landing Time:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Departure Time:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 251)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Miles Flown:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "From Airport:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 295)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Name Of Plane:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "To Airport:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Flight Number:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 333)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Select a Pilot:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Flight Date:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 375)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Select a Attendant:"
        '
        'frmCreateFutureFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 468)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboAtendant)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cboPlane)
        Me.Controls.Add(Me.cboToAirport)
        Me.Controls.Add(Me.cboPilot)
        Me.Controls.Add(Me.cboFromAirport)
        Me.Controls.Add(Me.txtDepartureTime)
        Me.Controls.Add(Me.txtFlightDate)
        Me.Controls.Add(Me.txtMilesFlown)
        Me.Controls.Add(Me.txtFlightNumber)
        Me.Controls.Add(Me.txtLandingTime)
        Me.Name = "frmCreateFutureFlights"
        Me.Text = "frmCreateFutureFlights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtLandingTime As TextBox
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents txtMilesFlown As TextBox
    Friend WithEvents txtFlightDate As TextBox
    Friend WithEvents txtDepartureTime As TextBox
    Friend WithEvents cboFromAirport As ComboBox
    Friend WithEvents cboPilot As ComboBox
    Friend WithEvents cboToAirport As ComboBox
    Friend WithEvents cboPlane As ComboBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents cboAtendant As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
End Class
