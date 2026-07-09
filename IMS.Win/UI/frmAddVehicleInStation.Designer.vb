<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddVehicleInStation
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
        Me.cmbVehicleCode = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbStationCode = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtSerial = New System.Windows.Forms.TextBox()
        Me.txtApplienceName = New System.Windows.Forms.TextBox()
        Me.txtStationName = New System.Windows.Forms.TextBox()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.cmbVehicleCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStationCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.cmbVehicleCode)
        Me.ultraGroupBox1.Controls.Add(Me.cmbStationCode)
        Me.ultraGroupBox1.Controls.Add(Me.label4)
        Me.ultraGroupBox1.Controls.Add(Me.label2)
        Me.ultraGroupBox1.Controls.Add(Me.label3)
        Me.ultraGroupBox1.Controls.Add(Me.label1)
        Me.ultraGroupBox1.Controls.Add(Me.label5)
        Me.ultraGroupBox1.Controls.Add(Me.txtSerial)
        Me.ultraGroupBox1.Controls.Add(Me.txtApplienceName)
        Me.ultraGroupBox1.Controls.Add(Me.txtStationName)
        Me.ultraGroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ultraGroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(868, 202)
        Me.ultraGroupBox1.TabIndex = 0
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cmbVehicleCode
        '
        Me.cmbVehicleCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbVehicleCode.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVehicleCode.Location = New System.Drawing.Point(138, 72)
        Me.cmbVehicleCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbVehicleCode.Name = "cmbVehicleCode"
        Me.cmbVehicleCode.Size = New System.Drawing.Size(217, 29)
        Me.cmbVehicleCode.TabIndex = 3
        '
        'cmbStationCode
        '
        Me.cmbStationCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbStationCode.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStationCode.Location = New System.Drawing.Point(138, 25)
        Me.cmbStationCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbStationCode.Name = "cmbStationCode"
        Me.cmbStationCode.Size = New System.Drawing.Size(217, 29)
        Me.cmbStationCode.TabIndex = 1
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.Transparent
        Me.label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.Red
        Me.label4.Location = New System.Drawing.Point(445, 124)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(59, 19)
        Me.label4.TabIndex = 4
        Me.label4.Text = "Serial :"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(388, 77)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(116, 19)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Vehicle Name :"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(389, 30)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(115, 19)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Station Name :"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Red
        Me.label1.Location = New System.Drawing.Point(25, 77)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(111, 19)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Vehicle Code :"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.Transparent
        Me.label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.Red
        Me.label5.Location = New System.Drawing.Point(26, 30)
        Me.label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(110, 19)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Station Code :"
        '
        'txtSerial
        '
        Me.txtSerial.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerial.Location = New System.Drawing.Point(505, 120)
        Me.txtSerial.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSerial.MaxLength = 50
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.Size = New System.Drawing.Size(299, 27)
        Me.txtSerial.TabIndex = 5
        '
        'txtApplienceName
        '
        Me.txtApplienceName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApplienceName.Location = New System.Drawing.Point(505, 73)
        Me.txtApplienceName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtApplienceName.MaxLength = 100
        Me.txtApplienceName.Name = "txtApplienceName"
        Me.txtApplienceName.ReadOnly = True
        Me.txtApplienceName.Size = New System.Drawing.Size(299, 27)
        Me.txtApplienceName.TabIndex = 3
        '
        'txtStationName
        '
        Me.txtStationName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStationName.Location = New System.Drawing.Point(505, 26)
        Me.txtStationName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStationName.MaxLength = 100
        Me.txtStationName.Name = "txtStationName"
        Me.txtStationName.ReadOnly = True
        Me.txtStationName.Size = New System.Drawing.Size(299, 27)
        Me.txtStationName.TabIndex = 1
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnClose)
        Me.ultraGroupBox2.Controls.Add(Me.btnSave)
        Me.ultraGroupBox2.Location = New System.Drawing.Point(3, 208)
        Me.ultraGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(868, 98)
        Me.ultraGroupBox2.TabIndex = 1
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnClose
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnClose.Appearance = Appearance1
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(450, 18)
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
        Me.btnSave.Location = New System.Drawing.Point(258, 18)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Drawing.Size(20, 0)
        Me.btnSave.Size = New System.Drawing.Size(160, 63)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'frmAddVehicleInStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 308)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddVehicleInStation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Vehicle Assignments In Station"
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        Me.ultraGroupBox1.PerformLayout()
        CType(Me.cmbVehicleCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStationCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents cmbVehicleCode As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents cmbStationCode As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtSerial As System.Windows.Forms.TextBox
    Private WithEvents txtApplienceName As System.Windows.Forms.TextBox
    Private WithEvents txtStationName As System.Windows.Forms.TextBox
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnSave As Infragistics.Win.Misc.UltraButton
End Class
