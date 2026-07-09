<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVehicleCheckInOut
    Inherits IMS.Win.BaseForm

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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ultraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbCheckInStation = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cmbSerials = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbStationName = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbVehicleCode = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtVehicleName = New System.Windows.Forms.TextBox()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.cmbCheckInStation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSerials, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStationName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbVehicleCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.cmbCheckInStation)
        Me.ultraGroupBox1.Controls.Add(Me.lblStation)
        Me.ultraGroupBox1.Controls.Add(Me.cmbSerials)
        Me.ultraGroupBox1.Controls.Add(Me.cmbStationName)
        Me.ultraGroupBox1.Controls.Add(Me.cmbVehicleCode)
        Me.ultraGroupBox1.Controls.Add(Me.label6)
        Me.ultraGroupBox1.Controls.Add(Me.Label1)
        Me.ultraGroupBox1.Controls.Add(Me.label3)
        Me.ultraGroupBox1.Controls.Add(Me.label5)
        Me.ultraGroupBox1.Controls.Add(Me.label4)
        Me.ultraGroupBox1.Controls.Add(Me.txtVehicleName)
        Me.ultraGroupBox1.Controls.Add(Me.txtReason)
        Me.ultraGroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(833, 212)
        Me.ultraGroupBox1.TabIndex = 0
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cmbCheckInStation
        '
        Me.cmbCheckInStation.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCheckInStation.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCheckInStation.Location = New System.Drawing.Point(153, 89)
        Me.cmbCheckInStation.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCheckInStation.Name = "cmbCheckInStation"
        Me.cmbCheckInStation.Size = New System.Drawing.Size(184, 29)
        Me.cmbCheckInStation.TabIndex = 3
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.BackColor = System.Drawing.Color.Transparent
        Me.lblStation.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStation.ForeColor = System.Drawing.Color.Red
        Me.lblStation.Location = New System.Drawing.Point(8, 94)
        Me.lblStation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(136, 19)
        Me.lblStation.TabIndex = 5
        Me.lblStation.Text = "Check In Station :"
        '
        'cmbSerials
        '
        Me.cmbSerials.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbSerials.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSerials.Location = New System.Drawing.Point(528, 53)
        Me.cmbSerials.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSerials.Name = "cmbSerials"
        Me.cmbSerials.Size = New System.Drawing.Size(184, 29)
        Me.cmbSerials.TabIndex = 2
        '
        'cmbStationName
        '
        Me.cmbStationName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbStationName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStationName.Location = New System.Drawing.Point(153, 13)
        Me.cmbStationName.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbStationName.Name = "cmbStationName"
        Me.cmbStationName.Size = New System.Drawing.Size(184, 29)
        Me.cmbStationName.TabIndex = 0
        '
        'cmbVehicleCode
        '
        Me.cmbVehicleCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbVehicleCode.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVehicleCode.Location = New System.Drawing.Point(528, 13)
        Me.cmbVehicleCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbVehicleCode.Name = "cmbVehicleCode"
        Me.cmbVehicleCode.Size = New System.Drawing.Size(184, 29)
        Me.cmbVehicleCode.TabIndex = 1
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.BackColor = System.Drawing.Color.Transparent
        Me.label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.Location = New System.Drawing.Point(37, 58)
        Me.label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(116, 19)
        Me.label6.TabIndex = 1
        Me.label6.Text = "Vehicle Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(462, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Serials :"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.Red
        Me.label3.Location = New System.Drawing.Point(30, 18)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(124, 19)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Vehicle Station :"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.Transparent
        Me.label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.Red
        Me.label5.Location = New System.Drawing.Point(417, 18)
        Me.label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(111, 19)
        Me.label5.TabIndex = 1
        Me.label5.Text = "Vehicle Code :"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.Transparent
        Me.label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(82, 127)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(71, 19)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Reason :"
        '
        'txtVehicleName
        '
        Me.txtVehicleName.Enabled = False
        Me.txtVehicleName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleName.Location = New System.Drawing.Point(153, 54)
        Me.txtVehicleName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtVehicleName.MaxLength = 60
        Me.txtVehicleName.Name = "txtVehicleName"
        Me.txtVehicleName.Size = New System.Drawing.Size(184, 27)
        Me.txtVehicleName.TabIndex = 0
        '
        'txtReason
        '
        Me.txtReason.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReason.Location = New System.Drawing.Point(153, 127)
        Me.txtReason.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReason.MaxLength = 200
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReason.Size = New System.Drawing.Size(397, 71)
        Me.txtReason.TabIndex = 4
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnClose)
        Me.ultraGroupBox2.Controls.Add(Me.btnSave)
        Me.ultraGroupBox2.Location = New System.Drawing.Point(3, 216)
        Me.ultraGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(835, 106)
        Me.ultraGroupBox2.TabIndex = 1
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnClose
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnClose.Appearance = Appearance1
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(428, 22)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Drawing.Size(20, 0)
        Me.btnClose.Size = New System.Drawing.Size(160, 63)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        '
        'btnSave
        '
        Appearance2.Image = Global.IMS.Win.My.Resources.Resources.Save
        Me.btnSave.Appearance = Appearance2
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnSave.Location = New System.Drawing.Point(247, 22)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Drawing.Size(20, 0)
        Me.btnSave.Size = New System.Drawing.Size(160, 63)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'frmVehicleCheckInOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 324)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVehicleCheckInOut"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vehicle Check In/Out"
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        Me.ultraGroupBox1.PerformLayout()
        CType(Me.cmbCheckInStation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSerials, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStationName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbVehicleCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents cmbVehicleCode As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtVehicleName As System.Windows.Forms.TextBox
    Private WithEvents txtReason As System.Windows.Forms.TextBox
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents cmbSerials As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents cmbStationName As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Private WithEvents cmbCheckInStation As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents lblStation As System.Windows.Forms.Label
End Class
