﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBookFlight
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFlights = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.radReservedSeat = New System.Windows.Forms.RadioButton()
        Me.radDesignatedSeat = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Flight:"
        '
        'cboFlights
        '
        Me.cboFlights.FormattingEnabled = True
        Me.cboFlights.Location = New System.Drawing.Point(141, 28)
        Me.cboFlights.Name = "cboFlights"
        Me.cboFlights.Size = New System.Drawing.Size(121, 21)
        Me.cboFlights.TabIndex = 1
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(31, 192)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Book Flight"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(187, 192)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'radReservedSeat
        '
        Me.radReservedSeat.AutoSize = True
        Me.radReservedSeat.Location = New System.Drawing.Point(85, 106)
        Me.radReservedSeat.Name = "radReservedSeat"
        Me.radReservedSeat.Size = New System.Drawing.Size(96, 17)
        Me.radReservedSeat.TabIndex = 4
        Me.radReservedSeat.TabStop = True
        Me.radReservedSeat.Text = "Reserved Seat"
        Me.radReservedSeat.UseVisualStyleBackColor = True
        '
        'radDesignatedSeat
        '
        Me.radDesignatedSeat.AutoSize = True
        Me.radDesignatedSeat.Location = New System.Drawing.Point(85, 142)
        Me.radDesignatedSeat.Name = "radDesignatedSeat"
        Me.radDesignatedSeat.Size = New System.Drawing.Size(104, 17)
        Me.radDesignatedSeat.TabIndex = 5
        Me.radDesignatedSeat.TabStop = True
        Me.radDesignatedSeat.Text = "Designated Seat"
        Me.radDesignatedSeat.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Select a seat:"
        '
        'frmBookFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 238)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.radDesignatedSeat)
        Me.Controls.Add(Me.radReservedSeat)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cboFlights)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmBookFlight"
        Me.Text = "frmBookFlight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboFlights As ComboBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents radReservedSeat As RadioButton
    Friend WithEvents radDesignatedSeat As RadioButton
    Friend WithEvents Label2 As Label
End Class
