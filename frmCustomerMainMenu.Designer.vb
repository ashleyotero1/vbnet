﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerMainMenu
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
        Me.btnUpdateProfile = New System.Windows.Forms.Button()
        Me.btnBookFlight = New System.Windows.Forms.Button()
        Me.btnPastFlights = New System.Windows.Forms.Button()
        Me.btnFutureFlights = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdateProfile
        '
        Me.btnUpdateProfile.Location = New System.Drawing.Point(168, 20)
        Me.btnUpdateProfile.Name = "btnUpdateProfile"
        Me.btnUpdateProfile.Size = New System.Drawing.Size(94, 35)
        Me.btnUpdateProfile.TabIndex = 0
        Me.btnUpdateProfile.Text = "Update Profile"
        Me.btnUpdateProfile.UseVisualStyleBackColor = True
        '
        'btnBookFlight
        '
        Me.btnBookFlight.Location = New System.Drawing.Point(21, 20)
        Me.btnBookFlight.Name = "btnBookFlight"
        Me.btnBookFlight.Size = New System.Drawing.Size(89, 36)
        Me.btnBookFlight.TabIndex = 1
        Me.btnBookFlight.Text = "Book Flight"
        Me.btnBookFlight.UseVisualStyleBackColor = True
        '
        'btnPastFlights
        '
        Me.btnPastFlights.Location = New System.Drawing.Point(16, 94)
        Me.btnPastFlights.Name = "btnPastFlights"
        Me.btnPastFlights.Size = New System.Drawing.Size(94, 39)
        Me.btnPastFlights.TabIndex = 2
        Me.btnPastFlights.Text = "View Past Flights"
        Me.btnPastFlights.UseVisualStyleBackColor = True
        '
        'btnFutureFlights
        '
        Me.btnFutureFlights.Location = New System.Drawing.Point(168, 94)
        Me.btnFutureFlights.Name = "btnFutureFlights"
        Me.btnFutureFlights.Size = New System.Drawing.Size(89, 39)
        Me.btnFutureFlights.TabIndex = 3
        Me.btnFutureFlights.Text = "View Future Flights"
        Me.btnFutureFlights.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(120, 184)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnPastFlights)
        Me.GroupBox1.Controls.Add(Me.btnBookFlight)
        Me.GroupBox1.Controls.Add(Me.btnUpdateProfile)
        Me.GroupBox1.Controls.Add(Me.btnFutureFlights)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 166)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Main Menu:"
        '
        'frmCustomerMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 219)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Name = "frmCustomerMainMenu"
        Me.Text = "frmCustomerMainMenu"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnUpdateProfile As Button
    Friend WithEvents btnBookFlight As Button
    Friend WithEvents btnPastFlights As Button
    Friend WithEvents btnFutureFlights As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
