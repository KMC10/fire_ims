<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewMonthlyReport
    Inherits BaseForm

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
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.ultraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.rptViewerMonthlyReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btnLoad = New Infragistics.Win.Misc.UltraButton()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.cmbMonth = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.cmbYear = New Infragistics.Win.UltraWinGrid.UltraCombo()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.cmbMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 36)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 19)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Year :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(245, 36)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 19)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Month :"
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.rptViewerMonthlyReport)
        Me.ultraGroupBox1.Location = New System.Drawing.Point(1, 93)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(1012, 488)
        Me.ultraGroupBox1.TabIndex = 7
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'rptViewerMonthlyReport
        '
        Me.rptViewerMonthlyReport.ActiveViewIndex = -1
        Me.rptViewerMonthlyReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptViewerMonthlyReport.CachedPageNumberPerDoc = 10
        Me.rptViewerMonthlyReport.Cursor = System.Windows.Forms.Cursors.Default
        Me.rptViewerMonthlyReport.DisplayStatusBar = False
        Me.rptViewerMonthlyReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptViewerMonthlyReport.Location = New System.Drawing.Point(3, 0)
        Me.rptViewerMonthlyReport.Name = "rptViewerMonthlyReport"
        Me.rptViewerMonthlyReport.Size = New System.Drawing.Size(1006, 485)
        Me.rptViewerMonthlyReport.TabIndex = 0
        Me.rptViewerMonthlyReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'btnLoad
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources.Load
        Me.btnLoad.Appearance = Appearance1
        Me.btnLoad.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnLoad.Location = New System.Drawing.Point(577, 15)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Padding = New System.Drawing.Size(20, 0)
        Me.btnLoad.Size = New System.Drawing.Size(162, 60)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Text = "&Load"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox3.Controls.Add(Me.btnClose)
        Me.UltraGroupBox3.Controls.Add(Me.cmbMonth)
        Me.UltraGroupBox3.Controls.Add(Me.cmbYear)
        Me.UltraGroupBox3.Controls.Add(Me.Label6)
        Me.UltraGroupBox3.Controls.Add(Me.Label4)
        Me.UltraGroupBox3.Controls.Add(Me.btnLoad)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(1, 2)
        Me.UltraGroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(1012, 90)
        Me.UltraGroupBox3.TabIndex = 6
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnClose.Appearance = Appearance2
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(830, 14)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Drawing.Size(20, 0)
        Me.btnClose.Size = New System.Drawing.Size(160, 63)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "&Close"
        '
        'cmbMonth
        '
        Appearance3.BackColor = System.Drawing.SystemColors.Window
        Appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbMonth.DisplayLayout.Appearance = Appearance3
        Me.cmbMonth.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbMonth.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbMonth.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbMonth.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.cmbMonth.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbMonth.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.cmbMonth.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbMonth.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbMonth.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbMonth.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.cmbMonth.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmbMonth.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMonth.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbMonth.DisplayLayout.Override.CellAppearance = Appearance10
        Me.cmbMonth.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cmbMonth.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbMonth.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.cmbMonth.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.cmbMonth.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbMonth.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.cmbMonth.DisplayLayout.Override.RowAppearance = Appearance13
        Me.cmbMonth.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbMonth.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.cmbMonth.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbMonth.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbMonth.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbMonth.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonth.Location = New System.Drawing.Point(310, 30)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(117, 30)
        Me.cmbMonth.TabIndex = 10
        '
        'cmbYear
        '
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbYear.DisplayLayout.Appearance = Appearance15
        Me.cmbYear.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbYear.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbYear.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbYear.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance17
        Me.cmbYear.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance18.BackColor2 = System.Drawing.SystemColors.Control
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbYear.DisplayLayout.GroupByBox.PromptAppearance = Appearance18
        Me.cmbYear.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbYear.DisplayLayout.MaxRowScrollRegions = 1
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbYear.DisplayLayout.Override.ActiveCellAppearance = Appearance19
        Appearance20.BackColor = System.Drawing.SystemColors.Highlight
        Appearance20.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbYear.DisplayLayout.Override.ActiveRowAppearance = Appearance20
        Me.cmbYear.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmbYear.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Me.cmbYear.DisplayLayout.Override.CardAreaAppearance = Appearance21
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Appearance22.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbYear.DisplayLayout.Override.CellAppearance = Appearance22
        Me.cmbYear.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cmbYear.DisplayLayout.Override.CellPadding = 0
        Appearance23.BackColor = System.Drawing.SystemColors.Control
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbYear.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Appearance24.TextHAlignAsString = "Left"
        Me.cmbYear.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.cmbYear.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbYear.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.cmbYear.DisplayLayout.Override.RowAppearance = Appearance25
        Me.cmbYear.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbYear.DisplayLayout.Override.TemplateAddRowAppearance = Appearance26
        Me.cmbYear.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbYear.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbYear.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbYear.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbYear.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYear.Location = New System.Drawing.Point(74, 30)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(117, 30)
        Me.cmbYear.TabIndex = 9
        '
        'frmViewMonthlyReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1014, 583)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Name = "frmViewMonthlyReport"
        Me.Text = "Monthly Report"
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.cmbMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents btnLoad As Infragistics.Win.Misc.UltraButton
    Private WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents cmbYear As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbMonth As Infragistics.Win.UltraWinGrid.UltraCombo
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Friend WithEvents rptViewerMonthlyReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
