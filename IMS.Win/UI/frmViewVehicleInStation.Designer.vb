<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewVehicleInStation
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
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Station Code")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Station Name")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Vehicle Code")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Vehicle Name")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("StationApplianceID")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Station Code")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Statiion Name")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Address")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Station Manager")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("StationID")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Station Code")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Statiion Name")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Vehicle Code")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Vehicle Name")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("StationApplianceID")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraDataSource5 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.ultraDataSource3 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.ultraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.ultraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraDataSource4 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnDelete = New Infragistics.Win.Misc.UltraButton()
        Me.btnEdit = New Infragistics.Win.Misc.UltraButton()
        Me.btnAdd = New Infragistics.Win.Misc.UltraButton()
        Me.ultraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grvVehicleInStation = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnNext = New Infragistics.Win.Misc.UltraButton()
        Me.btnPrevious = New Infragistics.Win.Misc.UltraButton()
        CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraDataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.grvVehicleInStation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ultraDataSource3
        '
        Me.ultraDataSource3.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5})
        '
        'ultraDataSource1
        '
        Me.ultraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10})
        '
        'ultraDataSource2
        '
        Me.ultraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15})
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnNext)
        Me.ultraGroupBox2.Controls.Add(Me.btnClose)
        Me.ultraGroupBox2.Controls.Add(Me.btnPrevious)
        Me.ultraGroupBox2.Controls.Add(Me.btnDelete)
        Me.ultraGroupBox2.Controls.Add(Me.btnEdit)
        Me.ultraGroupBox2.Controls.Add(Me.btnAdd)
        Me.ultraGroupBox2.Location = New System.Drawing.Point(1, 483)
        Me.ultraGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(1012, 98)
        Me.ultraGroupBox2.TabIndex = 1
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnClose
        '
        Appearance2.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnClose.Appearance = Appearance2
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(834, 18)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Drawing.Size(20, 0)
        Me.btnClose.Size = New System.Drawing.Size(160, 63)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        '
        'btnDelete
        '
        Appearance4.Image = Global.IMS.Win.My.Resources.Resources.Delete
        Me.btnDelete.Appearance = Appearance4
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnDelete.Location = New System.Drawing.Point(671, 18)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Drawing.Size(20, 0)
        Me.btnDelete.Size = New System.Drawing.Size(160, 63)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "&Delete"
        '
        'btnEdit
        '
        Appearance5.Image = Global.IMS.Win.My.Resources.Resources.Edit
        Me.btnEdit.Appearance = Appearance5
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnEdit.Location = New System.Drawing.Point(508, 18)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Drawing.Size(20, 0)
        Me.btnEdit.Size = New System.Drawing.Size(160, 63)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'btnAdd
        '
        Appearance6.Image = Global.IMS.Win.My.Resources.Resources.Add
        Me.btnAdd.Appearance = Appearance6
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAdd.Location = New System.Drawing.Point(19, 18)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Drawing.Size(20, 0)
        Me.btnAdd.Size = New System.Drawing.Size(160, 63)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "&Add"
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.grvVehicleInStation)
        Me.ultraGroupBox1.Location = New System.Drawing.Point(1, 3)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(1012, 480)
        Me.ultraGroupBox1.TabIndex = 0
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'grvVehicleInStation
        '
        Me.grvVehicleInStation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grvVehicleInStation.DataSource = Me.UltraDataSource5
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grvVehicleInStation.DisplayLayout.Appearance = Appearance7
        Me.grvVehicleInStation.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grvVehicleInStation.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grvVehicleInStation.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.BorderColor = System.Drawing.SystemColors.Window
        Me.grvVehicleInStation.DisplayLayout.GroupByBox.Appearance = Appearance8
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvVehicleInStation.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance9
        Me.grvVehicleInStation.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance10.BackColor2 = System.Drawing.SystemColors.Control
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grvVehicleInStation.DisplayLayout.GroupByBox.PromptAppearance = Appearance10
        Me.grvVehicleInStation.DisplayLayout.MaxColScrollRegions = 1
        Me.grvVehicleInStation.DisplayLayout.MaxRowScrollRegions = 1
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grvVehicleInStation.DisplayLayout.Override.ActiveCellAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.Highlight
        Appearance12.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grvVehicleInStation.DisplayLayout.Override.ActiveRowAppearance = Appearance12
        Me.grvVehicleInStation.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grvVehicleInStation.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Me.grvVehicleInStation.DisplayLayout.Override.CardAreaAppearance = Appearance13
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Appearance14.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grvVehicleInStation.DisplayLayout.Override.CellAppearance = Appearance14
        Me.grvVehicleInStation.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.grvVehicleInStation.DisplayLayout.Override.CellPadding = 0
        Appearance15.BackColor = System.Drawing.SystemColors.Control
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.grvVehicleInStation.DisplayLayout.Override.GroupByRowAppearance = Appearance15
        Appearance16.TextHAlignAsString = "Left"
        Me.grvVehicleInStation.DisplayLayout.Override.HeaderAppearance = Appearance16
        Me.grvVehicleInStation.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grvVehicleInStation.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Me.grvVehicleInStation.DisplayLayout.Override.RowAppearance = Appearance17
        Me.grvVehicleInStation.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grvVehicleInStation.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
        Me.grvVehicleInStation.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grvVehicleInStation.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grvVehicleInStation.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvVehicleInStation.Location = New System.Drawing.Point(5, 7)
        Me.grvVehicleInStation.Margin = New System.Windows.Forms.Padding(4)
        Me.grvVehicleInStation.Name = "grvVehicleInStation"
        Me.grvVehicleInStation.Size = New System.Drawing.Size(1003, 466)
        Me.grvVehicleInStation.TabIndex = 0
        Me.grvVehicleInStation.Text = "ultraGrid1"
        '
        'btnNext
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources._Next
        Me.btnNext.Appearance = Appearance1
        Me.btnNext.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnNext.Location = New System.Drawing.Point(345, 18)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Padding = New System.Drawing.Size(20, 0)
        Me.btnNext.Size = New System.Drawing.Size(160, 63)
        Me.btnNext.TabIndex = 8
        Me.btnNext.Text = "&Next"
        '
        'btnPrevious
        '
        Appearance3.Image = Global.IMS.Win.My.Resources.Resources.Previous
        Me.btnPrevious.Appearance = Appearance3
        Me.btnPrevious.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnPrevious.Location = New System.Drawing.Point(182, 18)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Padding = New System.Drawing.Size(20, 0)
        Me.btnPrevious.Size = New System.Drawing.Size(160, 63)
        Me.btnPrevious.TabIndex = 7
        Me.btnPrevious.Text = "&Previous"
        '
        'frmViewVehicleInStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 583)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmViewVehicleInStation"
        Me.Text = "View Vehicle Assignments In Station"
        CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraDataSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        CType(Me.grvVehicleInStation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents ultraDataSource3 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Private WithEvents ultraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Private WithEvents ultraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnDelete As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnEdit As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnAdd As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraDataSource4 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Private WithEvents grvVehicleInStation As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource5 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Private WithEvents btnNext As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnPrevious As Infragistics.Win.Misc.UltraButton
End Class
