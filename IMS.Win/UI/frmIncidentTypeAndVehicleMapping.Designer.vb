<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncidentTypeAndVehicleMapping
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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGroupBox5 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtQuantity = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.cmbVehicleName = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbIncidentType = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbIncidentCategory = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ultraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grvApplioenceMapping = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnNext = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrevious = New Infragistics.Win.Misc.UltraButton()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnDelete = New Infragistics.Win.Misc.UltraButton()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox5.SuspendLayout()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbVehicleName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.cmbIncidentType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIncidentCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.grvApplioenceMapping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox5
        '
        Me.UltraGroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox5.Controls.Add(Me.txtQuantity)
        Me.UltraGroupBox5.Controls.Add(Me.btnAdd)
        Me.UltraGroupBox5.Controls.Add(Me.Label8)
        Me.UltraGroupBox5.Controls.Add(Me.Label2)
        Me.UltraGroupBox5.Controls.Add(Me.txtCode)
        Me.UltraGroupBox5.Controls.Add(Me.cmbVehicleName)
        Me.UltraGroupBox5.Controls.Add(Me.Label7)
        Me.UltraGroupBox5.Location = New System.Drawing.Point(0, 83)
        Me.UltraGroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.UltraGroupBox5.Name = "UltraGroupBox5"
        Me.UltraGroupBox5.Size = New System.Drawing.Size(1093, 82)
        Me.UltraGroupBox5.TabIndex = 1
        Me.UltraGroupBox5.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'txtQuantity
        '
        Me.txtQuantity.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(824, 27)
        Me.txtQuantity.Margin = New System.Windows.Forms.Padding(4)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtQuantity.Size = New System.Drawing.Size(100, 29)
        Me.txtQuantity.TabIndex = 2
        '
        'btnAdd
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources.Add
        Me.btnAdd.Appearance = Appearance1
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(951, 22)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Drawing.Size(15, 0)
        Me.btnAdd.Size = New System.Drawing.Size(129, 38)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "&Add"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(745, 32)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 19)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Quantity :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(561, 32)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Code :"
        '
        'txtCode
        '
        Me.txtCode.Enabled = False
        Me.txtCode.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(617, 28)
        Me.txtCode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCode.MaxLength = 1
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(72, 27)
        Me.txtCode.TabIndex = 1
        '
        'cmbVehicleName
        '
        Me.cmbVehicleName.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbVehicleName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVehicleName.Location = New System.Drawing.Point(248, 27)
        Me.cmbVehicleName.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbVehicleName.Name = "cmbVehicleName"
        Me.cmbVehicleName.Size = New System.Drawing.Size(252, 29)
        Me.cmbVehicleName.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(134, 32)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 19)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Vehicle Name :"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox3.Controls.Add(Me.cmbIncidentType)
        Me.UltraGroupBox3.Controls.Add(Me.Label1)
        Me.UltraGroupBox3.Controls.Add(Me.cmbIncidentCategory)
        Me.UltraGroupBox3.Controls.Add(Me.Label3)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(0, 1)
        Me.UltraGroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(1092, 82)
        Me.UltraGroupBox3.TabIndex = 0
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cmbIncidentType
        '
        Me.cmbIncidentType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbIncidentType.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIncidentType.Location = New System.Drawing.Point(793, 25)
        Me.cmbIncidentType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbIncidentType.Name = "cmbIncidentType"
        Me.cmbIncidentType.Size = New System.Drawing.Size(252, 29)
        Me.cmbIncidentType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(629, 30)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Incident Type Name :"
        '
        'cmbIncidentCategory
        '
        Me.cmbIncidentCategory.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbIncidentCategory.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIncidentCategory.Location = New System.Drawing.Point(248, 27)
        Me.cmbIncidentCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbIncidentCategory.Name = "cmbIncidentCategory"
        Me.cmbIncidentCategory.Size = New System.Drawing.Size(252, 29)
        Me.cmbIncidentCategory.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(105, 30)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Incident Category :"
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.grvApplioenceMapping)
        Me.ultraGroupBox1.Location = New System.Drawing.Point(0, 168)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(1093, 315)
        Me.ultraGroupBox1.TabIndex = 2
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'grvApplioenceMapping
        '
        Me.grvApplioenceMapping.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grvApplioenceMapping.DisplayLayout.Appearance = Appearance2
        Me.grvApplioenceMapping.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grvApplioenceMapping.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grvApplioenceMapping.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.grvApplioenceMapping.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvApplioenceMapping.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.grvApplioenceMapping.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvApplioenceMapping.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.grvApplioenceMapping.DisplayLayout.MaxColScrollRegions = 1
        Me.grvApplioenceMapping.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grvApplioenceMapping.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grvApplioenceMapping.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.grvApplioenceMapping.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grvApplioenceMapping.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.grvApplioenceMapping.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grvApplioenceMapping.DisplayLayout.Override.CellAppearance = Appearance9
        Me.grvApplioenceMapping.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.grvApplioenceMapping.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.grvApplioenceMapping.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.grvApplioenceMapping.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grvApplioenceMapping.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grvApplioenceMapping.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.grvApplioenceMapping.DisplayLayout.Override.RowAppearance = Appearance12
        Me.grvApplioenceMapping.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grvApplioenceMapping.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.grvApplioenceMapping.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grvApplioenceMapping.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grvApplioenceMapping.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvApplioenceMapping.Location = New System.Drawing.Point(10, 11)
        Me.grvApplioenceMapping.Margin = New System.Windows.Forms.Padding(4)
        Me.grvApplioenceMapping.Name = "grvApplioenceMapping"
        Me.grvApplioenceMapping.Size = New System.Drawing.Size(1076, 297)
        Me.grvApplioenceMapping.TabIndex = 1
        Me.grvApplioenceMapping.Text = "ultraGrid1"
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnNext)
        Me.ultraGroupBox2.Controls.Add(Me.btnPrevious)
        Me.ultraGroupBox2.Controls.Add(Me.btnClose)
        Me.ultraGroupBox2.Controls.Add(Me.btnDelete)
        Me.ultraGroupBox2.Location = New System.Drawing.Point(0, 485)
        Me.ultraGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(1092, 96)
        Me.ultraGroupBox2.TabIndex = 3
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnNext
        '
        Appearance14.Image = Global.IMS.Win.My.Resources.Resources._Next
        Me.btnNext.Appearance = Appearance14
        Me.btnNext.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnNext.Location = New System.Drawing.Point(383, 17)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Padding = New System.Drawing.Size(20, 0)
        Me.btnNext.Size = New System.Drawing.Size(160, 63)
        Me.btnNext.TabIndex = 8
        Me.btnNext.Text = "&Next"
        '
        'btnPrevious
        '
        Appearance15.Image = Global.IMS.Win.My.Resources.Resources.Previous
        Me.btnPrevious.Appearance = Appearance15
        Me.btnPrevious.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnPrevious.Location = New System.Drawing.Point(216, 17)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Padding = New System.Drawing.Size(20, 0)
        Me.btnPrevious.Size = New System.Drawing.Size(160, 63)
        Me.btnPrevious.TabIndex = 7
        Me.btnPrevious.Text = "&Previous"
        '
        'btnClose
        '
        Appearance16.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnClose.Appearance = Appearance16
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(717, 17)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Drawing.Size(20, 0)
        Me.btnClose.Size = New System.Drawing.Size(160, 63)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        '
        'btnDelete
        '
        Appearance17.Image = Global.IMS.Win.My.Resources.Resources.Delete
        Me.btnDelete.Appearance = Appearance17
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnDelete.Location = New System.Drawing.Point(550, 17)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Drawing.Size(20, 0)
        Me.btnDelete.Size = New System.Drawing.Size(160, 63)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Text = "&Delete"
        '
        'frmIncidentTypeAndVehicleMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 583)
        Me.Controls.Add(Me.UltraGroupBox5)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmIncidentTypeAndVehicleMapping"
        Me.Text = "Incident Type And Vehicle Mapping"
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox5.ResumeLayout(False)
        Me.UltraGroupBox5.PerformLayout()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbVehicleName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.cmbIncidentType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIncidentCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        CType(Me.grvApplioenceMapping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnDelete As Infragistics.Win.Misc.UltraButton
    Private WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents cmbIncidentType As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents cmbIncidentCategory As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents UltraGroupBox5 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents cmbVehicleName As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtCode As System.Windows.Forms.TextBox
    Private WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Friend WithEvents txtQuantity As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Private WithEvents grvApplioenceMapping As Infragistics.Win.UltraWinGrid.UltraGrid
    Private WithEvents btnNext As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnPrevious As Infragistics.Win.Misc.UltraButton
End Class
