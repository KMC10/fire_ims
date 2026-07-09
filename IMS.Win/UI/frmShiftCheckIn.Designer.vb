<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShiftCheckIn
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
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.ultraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnBulkCheckOut = New System.Windows.Forms.Button()
        Me.btnEmployeeCheckOut = New System.Windows.Forms.Button()
        Me.btnBulkCheckIn = New System.Windows.Forms.Button()
        Me.btnEmployeeCheckIn = New System.Windows.Forms.Button()
        Me.btnIncidentCheckIn = New System.Windows.Forms.Button()
        Me.btnVehicleCheckOut = New System.Windows.Forms.Button()
        Me.btnVehicleCheckIn = New System.Windows.Forms.Button()
        Me.grvEmoloyee = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grvVehicles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblCurrentShift = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbFireStationEmployee = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbFireStation = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.grvEmoloyee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvVehicles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbFireStationEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbFireStation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnClose)
        Me.ultraGroupBox2.Location = New System.Drawing.Point(3, 633)
        Me.ultraGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(1162, 96)
        Me.ultraGroupBox2.TabIndex = 2
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnClose
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnClose.Appearance = Appearance1
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(501, 17)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Drawing.Size(20, 0)
        Me.btnClose.Size = New System.Drawing.Size(160, 63)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "&Close"
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.btnBulkCheckOut)
        Me.ultraGroupBox1.Controls.Add(Me.btnEmployeeCheckOut)
        Me.ultraGroupBox1.Controls.Add(Me.btnBulkCheckIn)
        Me.ultraGroupBox1.Controls.Add(Me.btnEmployeeCheckIn)
        Me.ultraGroupBox1.Controls.Add(Me.btnIncidentCheckIn)
        Me.ultraGroupBox1.Controls.Add(Me.btnVehicleCheckOut)
        Me.ultraGroupBox1.Controls.Add(Me.btnVehicleCheckIn)
        Me.ultraGroupBox1.Controls.Add(Me.grvEmoloyee)
        Me.ultraGroupBox1.Controls.Add(Me.grvVehicles)
        Me.ultraGroupBox1.Controls.Add(Me.lblCurrentShift)
        Me.ultraGroupBox1.Controls.Add(Me.Label11)
        Me.ultraGroupBox1.Controls.Add(Me.Label8)
        Me.ultraGroupBox1.Controls.Add(Me.Label7)
        Me.ultraGroupBox1.Controls.Add(Me.cmbFireStationEmployee)
        Me.ultraGroupBox1.Controls.Add(Me.cmbFireStation)
        Me.ultraGroupBox1.Controls.Add(Me.Label1)
        Me.ultraGroupBox1.Controls.Add(Me.Label9)
        Me.ultraGroupBox1.Location = New System.Drawing.Point(2, 1)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(1162, 630)
        Me.ultraGroupBox1.TabIndex = 0
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnBulkCheckOut
        '
        Me.btnBulkCheckOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBulkCheckOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBulkCheckOut.Location = New System.Drawing.Point(909, 574)
        Me.btnBulkCheckOut.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBulkCheckOut.Name = "btnBulkCheckOut"
        Me.btnBulkCheckOut.Size = New System.Drawing.Size(222, 38)
        Me.btnBulkCheckOut.TabIndex = 8
        Me.btnBulkCheckOut.Text = "Bulk Check-Out"
        Me.btnBulkCheckOut.UseVisualStyleBackColor = True
        '
        'btnEmployeeCheckOut
        '
        Me.btnEmployeeCheckOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEmployeeCheckOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmployeeCheckOut.Location = New System.Drawing.Point(908, 516)
        Me.btnEmployeeCheckOut.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEmployeeCheckOut.Name = "btnEmployeeCheckOut"
        Me.btnEmployeeCheckOut.Size = New System.Drawing.Size(222, 38)
        Me.btnEmployeeCheckOut.TabIndex = 8
        Me.btnEmployeeCheckOut.Text = "Employee Check-Out"
        Me.btnEmployeeCheckOut.UseVisualStyleBackColor = True
        '
        'btnBulkCheckIn
        '
        Me.btnBulkCheckIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBulkCheckIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBulkCheckIn.Location = New System.Drawing.Point(653, 574)
        Me.btnBulkCheckIn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBulkCheckIn.Name = "btnBulkCheckIn"
        Me.btnBulkCheckIn.Size = New System.Drawing.Size(215, 38)
        Me.btnBulkCheckIn.TabIndex = 7
        Me.btnBulkCheckIn.Text = "Bulk Check-In"
        Me.btnBulkCheckIn.UseVisualStyleBackColor = True
        '
        'btnEmployeeCheckIn
        '
        Me.btnEmployeeCheckIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEmployeeCheckIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmployeeCheckIn.Location = New System.Drawing.Point(652, 516)
        Me.btnEmployeeCheckIn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEmployeeCheckIn.Name = "btnEmployeeCheckIn"
        Me.btnEmployeeCheckIn.Size = New System.Drawing.Size(215, 38)
        Me.btnEmployeeCheckIn.TabIndex = 7
        Me.btnEmployeeCheckIn.Text = "Employee Check-In"
        Me.btnEmployeeCheckIn.UseVisualStyleBackColor = True
        '
        'btnIncidentCheckIn
        '
        Me.btnIncidentCheckIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnIncidentCheckIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncidentCheckIn.Location = New System.Drawing.Point(347, 574)
        Me.btnIncidentCheckIn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnIncidentCheckIn.Name = "btnIncidentCheckIn"
        Me.btnIncidentCheckIn.Size = New System.Drawing.Size(176, 38)
        Me.btnIncidentCheckIn.TabIndex = 4
        Me.btnIncidentCheckIn.Text = "Incident CheckIn"
        Me.btnIncidentCheckIn.UseVisualStyleBackColor = True
        '
        'btnVehicleCheckOut
        '
        Me.btnVehicleCheckOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnVehicleCheckOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleCheckOut.Location = New System.Drawing.Point(347, 516)
        Me.btnVehicleCheckOut.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVehicleCheckOut.Name = "btnVehicleCheckOut"
        Me.btnVehicleCheckOut.Size = New System.Drawing.Size(176, 38)
        Me.btnVehicleCheckOut.TabIndex = 4
        Me.btnVehicleCheckOut.Text = "Vehicle Check-Out"
        Me.btnVehicleCheckOut.UseVisualStyleBackColor = True
        '
        'btnVehicleCheckIn
        '
        Me.btnVehicleCheckIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnVehicleCheckIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVehicleCheckIn.Location = New System.Drawing.Point(45, 516)
        Me.btnVehicleCheckIn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVehicleCheckIn.Name = "btnVehicleCheckIn"
        Me.btnVehicleCheckIn.Size = New System.Drawing.Size(171, 38)
        Me.btnVehicleCheckIn.TabIndex = 3
        Me.btnVehicleCheckIn.Text = "Vehicle Check-In"
        Me.btnVehicleCheckIn.UseVisualStyleBackColor = True
        '
        'grvEmoloyee
        '
        Me.grvEmoloyee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grvEmoloyee.DisplayLayout.Appearance = Appearance2
        Me.grvEmoloyee.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grvEmoloyee.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grvEmoloyee.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.grvEmoloyee.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvEmoloyee.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.grvEmoloyee.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvEmoloyee.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.grvEmoloyee.DisplayLayout.MaxColScrollRegions = 1
        Me.grvEmoloyee.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grvEmoloyee.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grvEmoloyee.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.grvEmoloyee.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grvEmoloyee.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.grvEmoloyee.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grvEmoloyee.DisplayLayout.Override.CellAppearance = Appearance9
        Me.grvEmoloyee.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grvEmoloyee.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.grvEmoloyee.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.grvEmoloyee.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grvEmoloyee.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grvEmoloyee.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.grvEmoloyee.DisplayLayout.Override.RowAppearance = Appearance12
        Me.grvEmoloyee.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grvEmoloyee.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.grvEmoloyee.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grvEmoloyee.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grvEmoloyee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvEmoloyee.Location = New System.Drawing.Point(653, 99)
        Me.grvEmoloyee.Margin = New System.Windows.Forms.Padding(4)
        Me.grvEmoloyee.Name = "grvEmoloyee"
        Me.grvEmoloyee.Size = New System.Drawing.Size(478, 395)
        Me.grvEmoloyee.TabIndex = 6
        Me.grvEmoloyee.Text = "ultraGrid1"
        '
        'grvVehicles
        '
        Me.grvVehicles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grvVehicles.DisplayLayout.Appearance = Appearance14
        Me.grvVehicles.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grvVehicles.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grvVehicles.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.grvVehicles.DisplayLayout.GroupByBox.Appearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvVehicles.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.grvVehicles.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance17.BackColor2 = System.Drawing.SystemColors.Control
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvVehicles.DisplayLayout.GroupByBox.PromptAppearance = Appearance17
        Me.grvVehicles.DisplayLayout.MaxColScrollRegions = 1
        Me.grvVehicles.DisplayLayout.MaxRowScrollRegions = 1
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grvVehicles.DisplayLayout.Override.ActiveCellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.SystemColors.Highlight
        Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grvVehicles.DisplayLayout.Override.ActiveRowAppearance = Appearance19
        Me.grvVehicles.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grvVehicles.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.grvVehicles.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grvVehicles.DisplayLayout.Override.CellAppearance = Appearance21
        Me.grvVehicles.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grvVehicles.DisplayLayout.Override.CellPadding = 0
        Appearance22.BackColor = System.Drawing.SystemColors.Control
        Appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance22.BorderColor = System.Drawing.SystemColors.Window
        Me.grvVehicles.DisplayLayout.Override.GroupByRowAppearance = Appearance22
        Appearance23.TextHAlignAsString = "Left"
        Me.grvVehicles.DisplayLayout.Override.HeaderAppearance = Appearance23
        Me.grvVehicles.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grvVehicles.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Me.grvVehicles.DisplayLayout.Override.RowAppearance = Appearance24
        Me.grvVehicles.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grvVehicles.DisplayLayout.Override.TemplateAddRowAppearance = Appearance25
        Me.grvVehicles.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grvVehicles.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grvVehicles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvVehicles.Location = New System.Drawing.Point(61, 99)
        Me.grvVehicles.Margin = New System.Windows.Forms.Padding(4)
        Me.grvVehicles.Name = "grvVehicles"
        Me.grvVehicles.Size = New System.Drawing.Size(478, 395)
        Me.grvVehicles.TabIndex = 2
        Me.grvVehicles.Text = "ultraGrid1"
        '
        'lblCurrentShift
        '
        Me.lblCurrentShift.AutoSize = True
        Me.lblCurrentShift.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentShift.Location = New System.Drawing.Point(753, 18)
        Me.lblCurrentShift.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCurrentShift.Name = "lblCurrentShift"
        Me.lblCurrentShift.Size = New System.Drawing.Size(35, 20)
        Me.lblCurrentShift.TabIndex = 0
        Me.lblCurrentShift.Text = "N/A"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(656, 55)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Employee Details"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(57, 51)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 20)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Vehicle Details "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(649, 18)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Current Shift :"
        '
        'cmbFireStationEmployee
        '
        Me.cmbFireStationEmployee.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbFireStationEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFireStationEmployee.Location = New System.Drawing.Point(932, 51)
        Me.cmbFireStationEmployee.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFireStationEmployee.Name = "cmbFireStationEmployee"
        Me.cmbFireStationEmployee.Size = New System.Drawing.Size(189, 28)
        Me.cmbFireStationEmployee.TabIndex = 5
        '
        'cmbFireStation
        '
        Me.cmbFireStation.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbFireStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFireStation.Location = New System.Drawing.Point(354, 47)
        Me.cmbFireStation.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFireStation.Name = "cmbFireStation"
        Me.cmbFireStation.Size = New System.Drawing.Size(189, 28)
        Me.cmbFireStation.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(861, 55)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Station :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(285, 51)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 20)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Station :"
        '
        'frmShiftCheckIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 732)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmShiftCheckIn"
        Me.Text = "Shift Check In"
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        Me.ultraGroupBox1.PerformLayout()
        CType(Me.grvEmoloyee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvVehicles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbFireStationEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbFireStation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents lblCurrentShift As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents cmbFireStation As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents cmbFireStationEmployee As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents grvEmoloyee As Infragistics.Win.UltraWinGrid.UltraGrid
    Private WithEvents grvVehicles As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnVehicleCheckOut As System.Windows.Forms.Button
    Friend WithEvents btnVehicleCheckIn As System.Windows.Forms.Button
    Friend WithEvents btnEmployeeCheckOut As System.Windows.Forms.Button
    Friend WithEvents btnEmployeeCheckIn As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnBulkCheckOut As System.Windows.Forms.Button
    Friend WithEvents btnBulkCheckIn As System.Windows.Forms.Button
    Friend WithEvents btnIncidentCheckIn As System.Windows.Forms.Button
End Class
