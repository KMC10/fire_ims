<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOccurrenceBook
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
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnLoad = New Infragistics.Win.Misc.UltraButton()
        Me.dtpDateTo = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.label1 = New System.Windows.Forms.Label()
        Me.ultraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grvOccarenceBook = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnReopen = New Infragistics.Win.Misc.UltraButton()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnDetails = New Infragistics.Win.Misc.UltraButton()
        Me.btnNext = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrevious = New Infragistics.Win.Misc.UltraButton()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.dtpDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.grvOccarenceBook, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox3.Controls.Add(Me.btnLoad)
        Me.UltraGroupBox3.Controls.Add(Me.dtpDateTo)
        Me.UltraGroupBox3.Controls.Add(Me.Label2)
        Me.UltraGroupBox3.Controls.Add(Me.dtpDateFrom)
        Me.UltraGroupBox3.Controls.Add(Me.label1)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(1, 3)
        Me.UltraGroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(1012, 88)
        Me.UltraGroupBox3.TabIndex = 0
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnLoad
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources.Load
        Me.btnLoad.Appearance = Appearance1
        Me.btnLoad.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnLoad.Location = New System.Drawing.Point(795, 16)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Padding = New System.Drawing.Size(20, 0)
        Me.btnLoad.Size = New System.Drawing.Size(162, 60)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Text = "&Load"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateTo.Location = New System.Drawing.Point(531, 32)
        Me.dtpDateTo.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(175, 29)
        Me.dtpDateTo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(449, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date To :"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.Location = New System.Drawing.Point(155, 32)
        Me.dtpDateFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(175, 29)
        Me.dtpDateFrom.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(55, 37)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(94, 19)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Date From :"
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.grvOccarenceBook)
        Me.ultraGroupBox1.Location = New System.Drawing.Point(1, 94)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(1012, 386)
        Me.ultraGroupBox1.TabIndex = 1
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'grvOccarenceBook
        '
        Me.grvOccarenceBook.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grvOccarenceBook.DataSource = Me.UltraDataSource1
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grvOccarenceBook.DisplayLayout.Appearance = Appearance2
        Me.grvOccarenceBook.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grvOccarenceBook.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grvOccarenceBook.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.grvOccarenceBook.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvOccarenceBook.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.grvOccarenceBook.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvOccarenceBook.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.grvOccarenceBook.DisplayLayout.MaxColScrollRegions = 1
        Me.grvOccarenceBook.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grvOccarenceBook.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grvOccarenceBook.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.grvOccarenceBook.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grvOccarenceBook.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.grvOccarenceBook.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grvOccarenceBook.DisplayLayout.Override.CellAppearance = Appearance9
        Me.grvOccarenceBook.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.grvOccarenceBook.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.grvOccarenceBook.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.grvOccarenceBook.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.grvOccarenceBook.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grvOccarenceBook.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.grvOccarenceBook.DisplayLayout.Override.RowAppearance = Appearance12
        Me.grvOccarenceBook.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grvOccarenceBook.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.grvOccarenceBook.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grvOccarenceBook.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grvOccarenceBook.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvOccarenceBook.Location = New System.Drawing.Point(6, 8)
        Me.grvOccarenceBook.Margin = New System.Windows.Forms.Padding(4)
        Me.grvOccarenceBook.Name = "grvOccarenceBook"
        Me.grvOccarenceBook.Size = New System.Drawing.Size(999, 374)
        Me.grvOccarenceBook.TabIndex = 1
        Me.grvOccarenceBook.Text = "ultraGrid1"
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnReopen)
        Me.ultraGroupBox2.Controls.Add(Me.btnClose)
        Me.ultraGroupBox2.Controls.Add(Me.btnDetails)
        Me.ultraGroupBox2.Controls.Add(Me.btnNext)
        Me.ultraGroupBox2.Controls.Add(Me.btnPrevious)
        Me.ultraGroupBox2.Location = New System.Drawing.Point(1, 483)
        Me.ultraGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(1012, 98)
        Me.ultraGroupBox2.TabIndex = 2
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnReopen
        '
        Appearance14.Image = Global.IMS.Win.My.Resources.Resources.Load
        Me.btnReopen.Appearance = Appearance14
        Me.btnReopen.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReopen.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnReopen.Location = New System.Drawing.Point(607, 18)
        Me.btnReopen.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReopen.Name = "btnReopen"
        Me.btnReopen.Padding = New System.Drawing.Size(20, 0)
        Me.btnReopen.Size = New System.Drawing.Size(160, 63)
        Me.btnReopen.TabIndex = 5
        Me.btnReopen.Text = "Re&open"
        '
        'btnClose
        '
        Appearance15.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnClose.Appearance = Appearance15
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(788, 18)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Drawing.Size(20, 0)
        Me.btnClose.Size = New System.Drawing.Size(160, 63)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        '
        'btnDetails
        '
        Appearance16.Image = Global.IMS.Win.My.Resources.Resources.Edit
        Me.btnDetails.Appearance = Appearance16
        Me.btnDetails.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetails.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnDetails.Location = New System.Drawing.Point(64, 18)
        Me.btnDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDetails.Name = "btnDetails"
        Me.btnDetails.Padding = New System.Drawing.Size(20, 0)
        Me.btnDetails.Size = New System.Drawing.Size(160, 63)
        Me.btnDetails.TabIndex = 1
        Me.btnDetails.Text = "&Details"
        '
        'btnNext
        '
        Appearance17.Image = Global.IMS.Win.My.Resources.Resources._Next
        Me.btnNext.Appearance = Appearance17
        Me.btnNext.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnNext.Location = New System.Drawing.Point(426, 18)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Padding = New System.Drawing.Size(20, 0)
        Me.btnNext.Size = New System.Drawing.Size(160, 63)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "&Next"
        '
        'btnPrevious
        '
        Appearance18.Image = Global.IMS.Win.My.Resources.Resources.Previous
        Me.btnPrevious.Appearance = Appearance18
        Me.btnPrevious.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnPrevious.Location = New System.Drawing.Point(245, 18)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Padding = New System.Drawing.Size(20, 0)
        Me.btnPrevious.Size = New System.Drawing.Size(160, 63)
        Me.btnPrevious.TabIndex = 0
        Me.btnPrevious.Text = "&Previous"
        '
        'frmOccurrenceBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 583)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmOccurrenceBook"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Occurrence Book"
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.dtpDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDateFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        CType(Me.grvOccarenceBook, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnDetails As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnPrevious As Infragistics.Win.Misc.UltraButton
    Private WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDateFrom As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dtpDateTo As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents btnLoad As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnNext As Infragistics.Win.Misc.UltraButton
    Private WithEvents grvOccarenceBook As Infragistics.Win.UltraWinGrid.UltraGrid
    Private WithEvents btnReopen As Infragistics.Win.Misc.UltraButton
End Class
