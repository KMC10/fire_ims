<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBulkCheckInOut
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
        Me.grvAssignedFirestations = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chkEmployeeList = New System.Windows.Forms.CheckedListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbEmployeeGroup = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbStationName = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.grvAssignedFirestations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grvAssignedFirestations.SuspendLayout()
        CType(Me.cmbEmployeeGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbStationName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.grvAssignedFirestations)
        Me.ultraGroupBox1.Controls.Add(Me.cmbEmployeeGroup)
        Me.ultraGroupBox1.Controls.Add(Me.cmbStationName)
        Me.ultraGroupBox1.Controls.Add(Me.lblShift)
        Me.ultraGroupBox1.Controls.Add(Me.Label2)
        Me.ultraGroupBox1.Controls.Add(Me.label6)
        Me.ultraGroupBox1.Controls.Add(Me.label3)
        Me.ultraGroupBox1.Controls.Add(Me.label4)
        Me.ultraGroupBox1.Controls.Add(Me.txtReason)
        Me.ultraGroupBox1.Location = New System.Drawing.Point(1, 2)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(837, 381)
        Me.ultraGroupBox1.TabIndex = 4
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'grvAssignedFirestations
        '
        Me.grvAssignedFirestations.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grvAssignedFirestations.Controls.Add(Me.chkEmployeeList)
        Me.grvAssignedFirestations.Controls.Add(Me.Label9)
        Me.grvAssignedFirestations.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvAssignedFirestations.Location = New System.Drawing.Point(113, 106)
        Me.grvAssignedFirestations.Name = "grvAssignedFirestations"
        Me.grvAssignedFirestations.Size = New System.Drawing.Size(276, 256)
        Me.grvAssignedFirestations.TabIndex = 6
        Me.grvAssignedFirestations.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'chkEmployeeList
        '
        Me.chkEmployeeList.CheckOnClick = True
        Me.chkEmployeeList.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmployeeList.FormattingEnabled = True
        Me.chkEmployeeList.Location = New System.Drawing.Point(7, 27)
        Me.chkEmployeeList.Name = "chkEmployeeList"
        Me.chkEmployeeList.Size = New System.Drawing.Size(263, 224)
        Me.chkEmployeeList.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(7, 4)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Employee List"
        '
        'cmbEmployeeGroup
        '
        Me.cmbEmployeeGroup.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbEmployeeGroup.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmployeeGroup.Location = New System.Drawing.Point(205, 62)
        Me.cmbEmployeeGroup.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEmployeeGroup.Name = "cmbEmployeeGroup"
        Me.cmbEmployeeGroup.Size = New System.Drawing.Size(184, 29)
        Me.cmbEmployeeGroup.TabIndex = 1
        '
        'cmbStationName
        '
        Me.cmbStationName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbStationName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStationName.Location = New System.Drawing.Point(205, 18)
        Me.cmbStationName.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbStationName.Name = "cmbStationName"
        Me.cmbStationName.Size = New System.Drawing.Size(184, 29)
        Me.cmbStationName.TabIndex = 0
        '
        'lblShift
        '
        Me.lblShift.AutoSize = True
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.Location = New System.Drawing.Point(531, 23)
        Me.lblShift.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(37, 19)
        Me.lblShift.TabIndex = 1
        Me.lblShift.Text = "N/A"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(480, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Shift :"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.BackColor = System.Drawing.Color.Transparent
        Me.label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.Color.Red
        Me.label6.Location = New System.Drawing.Point(66, 67)
        Me.label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(138, 19)
        Me.label6.TabIndex = 1
        Me.label6.Text = "Employee Group :"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.Red
        Me.label3.Location = New System.Drawing.Point(59, 23)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(143, 19)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Employee Station :"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.Transparent
        Me.label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(461, 121)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(71, 19)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Reason :"
        '
        'txtReason
        '
        Me.txtReason.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReason.Location = New System.Drawing.Point(535, 118)
        Me.txtReason.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReason.MaxLength = 200
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReason.Size = New System.Drawing.Size(248, 238)
        Me.txtReason.TabIndex = 3
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnClose)
        Me.ultraGroupBox2.Controls.Add(Me.btnSave)
        Me.ultraGroupBox2.Location = New System.Drawing.Point(2, 385)
        Me.ultraGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(837, 106)
        Me.ultraGroupBox2.TabIndex = 5
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
        'frmBulkCheckInOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 493)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBulkCheckInOut"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bulk Check In / Out"
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        Me.ultraGroupBox1.PerformLayout()
        CType(Me.grvAssignedFirestations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grvAssignedFirestations.ResumeLayout(False)
        Me.grvAssignedFirestations.PerformLayout()
        CType(Me.cmbEmployeeGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbStationName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents cmbEmployeeGroup As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents cmbStationName As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents lblShift As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtReason As System.Windows.Forms.TextBox
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents grvAssignedFirestations As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkEmployeeList As System.Windows.Forms.CheckedListBox
    Private WithEvents Label9 As System.Windows.Forms.Label
End Class
