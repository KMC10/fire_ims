<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEmployee
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
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.chkCanDrive = New System.Windows.Forms.CheckBox()
        Me.cmbEmployeeType = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbEmployeeGroup = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbStation = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.cmbEmployeeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEmployeeGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.txtCode)
        Me.ultraGroupBox1.Controls.Add(Me.chkCanDrive)
        Me.ultraGroupBox1.Controls.Add(Me.cmbEmployeeType)
        Me.ultraGroupBox1.Controls.Add(Me.cmbEmployeeGroup)
        Me.ultraGroupBox1.Controls.Add(Me.cmbStation)
        Me.ultraGroupBox1.Controls.Add(Me.Label9)
        Me.ultraGroupBox1.Controls.Add(Me.Label6)
        Me.ultraGroupBox1.Controls.Add(Me.Label8)
        Me.ultraGroupBox1.Controls.Add(Me.Label1)
        Me.ultraGroupBox1.Controls.Add(Me.Label7)
        Me.ultraGroupBox1.Controls.Add(Me.label3)
        Me.ultraGroupBox1.Controls.Add(Me.label5)
        Me.ultraGroupBox1.Controls.Add(Me.label2)
        Me.ultraGroupBox1.Controls.Add(Me.label4)
        Me.ultraGroupBox1.Controls.Add(Me.txtEmail)
        Me.ultraGroupBox1.Controls.Add(Me.txtPhone)
        Me.ultraGroupBox1.Controls.Add(Me.txtName)
        Me.ultraGroupBox1.Controls.Add(Me.txtAddress)
        Me.ultraGroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ultraGroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(1008, 274)
        Me.ultraGroupBox1.TabIndex = 0
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(179, 81)
        Me.txtCode.MaxLength = 7
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(258, 26)
        Me.txtCode.TabIndex = 1
        '
        'chkCanDrive
        '
        Me.chkCanDrive.AutoSize = True
        Me.chkCanDrive.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCanDrive.Location = New System.Drawing.Point(185, 214)
        Me.chkCanDrive.Name = "chkCanDrive"
        Me.chkCanDrive.Size = New System.Drawing.Size(15, 14)
        Me.chkCanDrive.TabIndex = 4
        Me.chkCanDrive.UseVisualStyleBackColor = True
        '
        'cmbEmployeeType
        '
        Me.cmbEmployeeType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbEmployeeType.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmployeeType.Location = New System.Drawing.Point(614, 37)
        Me.cmbEmployeeType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEmployeeType.Name = "cmbEmployeeType"
        Me.cmbEmployeeType.Size = New System.Drawing.Size(204, 29)
        Me.cmbEmployeeType.TabIndex = 5
        '
        'cmbEmployeeGroup
        '
        Me.cmbEmployeeGroup.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbEmployeeGroup.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmployeeGroup.Location = New System.Drawing.Point(614, 119)
        Me.cmbEmployeeGroup.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEmployeeGroup.Name = "cmbEmployeeGroup"
        Me.cmbEmployeeGroup.Size = New System.Drawing.Size(204, 29)
        Me.cmbEmployeeGroup.TabIndex = 7
        '
        'cmbStation
        '
        Me.cmbStation.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbStation.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStation.Location = New System.Drawing.Point(614, 80)
        Me.cmbStation.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbStation.Name = "cmbStation"
        Me.cmbStation.Size = New System.Drawing.Size(204, 29)
        Me.cmbStation.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(89, 212)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 19)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Can Drive :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(470, 124)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 19)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Employee Group :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(470, 85)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 19)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Employee Station :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(489, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 19)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Employee type :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(39, 171)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 19)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Employee E-mail :"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.Red
        Me.label3.Location = New System.Drawing.Point(48, 85)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(130, 19)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Employee Code :"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.Transparent
        Me.label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.Red
        Me.label5.Location = New System.Drawing.Point(40, 128)
        Me.label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(138, 19)
        Me.label5.TabIndex = 4
        Me.label5.Text = "Employee Phone :"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Red
        Me.label2.Location = New System.Drawing.Point(43, 42)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(135, 19)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Employee Name :"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.Transparent
        Me.label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.Red
        Me.label4.Location = New System.Drawing.Point(462, 195)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(151, 19)
        Me.label4.TabIndex = 16
        Me.label4.Text = "Employee Address :"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(179, 167)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(258, 27)
        Me.txtEmail.TabIndex = 3
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(179, 124)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPhone.MaxLength = 60
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(258, 27)
        Me.txtPhone.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(179, 38)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtName.MaxLength = 100
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(258, 27)
        Me.txtName.TabIndex = 0
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(614, 159)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddress.MaxLength = 200
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAddress.Size = New System.Drawing.Size(361, 90)
        Me.txtAddress.TabIndex = 8
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnClose)
        Me.ultraGroupBox2.Controls.Add(Me.btnSave)
        Me.ultraGroupBox2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ultraGroupBox2.Location = New System.Drawing.Point(2, 277)
        Me.ultraGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(1008, 113)
        Me.ultraGroupBox2.TabIndex = 1
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnClose
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnClose.Appearance = Appearance1
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(527, 25)
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
        Me.btnSave.Location = New System.Drawing.Point(322, 25)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Drawing.Size(20, 0)
        Me.btnSave.Size = New System.Drawing.Size(160, 63)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'frmAddEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 393)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddEmployee"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Employee"
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        Me.ultraGroupBox1.PerformLayout()
        CType(Me.cmbEmployeeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEmployeeGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents cmbStation As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents txtAddress As System.Windows.Forms.TextBox
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents chkCanDrive As System.Windows.Forms.CheckBox
    Private WithEvents cmbEmployeeType As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtEmail As System.Windows.Forms.TextBox
    Private WithEvents txtPhone As System.Windows.Forms.TextBox
    Private WithEvents cmbEmployeeGroup As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
End Class
