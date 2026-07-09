<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPark
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
        Me.cmbIncidentReference = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbIncidentType = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbIncidentCategory = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chkVehicleList = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grvAssignedFirestations = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chkEmployeeList = New System.Windows.Forms.CheckedListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.cmbIncidentReference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIncidentType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIncidentCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.grvAssignedFirestations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grvAssignedFirestations.SuspendLayout()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.cmbIncidentReference)
        Me.ultraGroupBox1.Controls.Add(Me.Label3)
        Me.ultraGroupBox1.Controls.Add(Me.cmbIncidentType)
        Me.ultraGroupBox1.Controls.Add(Me.Label1)
        Me.ultraGroupBox1.Controls.Add(Me.cmbIncidentCategory)
        Me.ultraGroupBox1.Controls.Add(Me.Label5)
        Me.ultraGroupBox1.Controls.Add(Me.UltraGroupBox3)
        Me.ultraGroupBox1.Controls.Add(Me.grvAssignedFirestations)
        Me.ultraGroupBox1.Location = New System.Drawing.Point(1, 2)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(837, 381)
        Me.ultraGroupBox1.TabIndex = 8
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cmbIncidentReference
        '
        Me.cmbIncidentReference.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbIncidentReference.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbIncidentReference.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIncidentReference.Location = New System.Drawing.Point(454, 60)
        Me.cmbIncidentReference.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbIncidentReference.Name = "cmbIncidentReference"
        Me.cmbIncidentReference.Size = New System.Drawing.Size(161, 29)
        Me.cmbIncidentReference.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(367, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Incident :"
        '
        'cmbIncidentType
        '
        Me.cmbIncidentType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbIncidentType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbIncidentType.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIncidentType.Location = New System.Drawing.Point(114, 66)
        Me.cmbIncidentType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbIncidentType.Name = "cmbIncidentType"
        Me.cmbIncidentType.Size = New System.Drawing.Size(161, 29)
        Me.cmbIncidentType.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(56, 70)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Type :"
        '
        'cmbIncidentCategory
        '
        Me.cmbIncidentCategory.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbIncidentCategory.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbIncidentCategory.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIncidentCategory.Location = New System.Drawing.Point(113, 22)
        Me.cmbIncidentCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbIncidentCategory.Name = "cmbIncidentCategory"
        Me.cmbIncidentCategory.Size = New System.Drawing.Size(162, 29)
        Me.cmbIncidentCategory.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Category :"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox3.Controls.Add(Me.chkVehicleList)
        Me.UltraGroupBox3.Controls.Add(Me.Label2)
        Me.UltraGroupBox3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGroupBox3.Location = New System.Drawing.Point(454, 106)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(276, 256)
        Me.UltraGroupBox3.TabIndex = 6
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'chkVehicleList
        '
        Me.chkVehicleList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkVehicleList.CheckOnClick = True
        Me.chkVehicleList.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVehicleList.FormattingEnabled = True
        Me.chkVehicleList.Location = New System.Drawing.Point(7, 27)
        Me.chkVehicleList.Name = "chkVehicleList"
        Me.chkVehicleList.Size = New System.Drawing.Size(263, 224)
        Me.chkVehicleList.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 4)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Vehicle List"
        '
        'grvAssignedFirestations
        '
        Me.grvAssignedFirestations.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
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
        Me.chkEmployeeList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.ultraGroupBox2.TabIndex = 9
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top
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
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
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
        'frmPark
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(840, 493)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.Name = "frmPark"
        Me.Text = "Park"
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        Me.ultraGroupBox1.PerformLayout()
        CType(Me.cmbIncidentReference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIncidentType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIncidentCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.grvAssignedFirestations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grvAssignedFirestations.ResumeLayout(False)
        Me.grvAssignedFirestations.PerformLayout()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents cmbIncidentReference As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents cmbIncidentType As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents cmbIncidentCategory As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkVehicleList As System.Windows.Forms.CheckedListBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grvAssignedFirestations As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkEmployeeList As System.Windows.Forms.CheckedListBox
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnSave As Infragistics.Win.Misc.UltraButton
End Class
