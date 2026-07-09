<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimeOfArrival
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
        Me.dtpTimeOfArrival = New System.Windows.Forms.DateTimePicker()
        Me.label2 = New System.Windows.Forms.Label()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOK = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.dtpTimeOfArrival)
        Me.ultraGroupBox1.Controls.Add(Me.label2)
        Me.ultraGroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ultraGroupBox1.Location = New System.Drawing.Point(1, -12)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(879, 137)
        Me.ultraGroupBox1.TabIndex = 2
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'dtpTimeOfArrival
        '
        Me.dtpTimeOfArrival.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpTimeOfArrival.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTimeOfArrival.Location = New System.Drawing.Point(442, 55)
        Me.dtpTimeOfArrival.Name = "dtpTimeOfArrival"
        Me.dtpTimeOfArrival.Size = New System.Drawing.Size(200, 27)
        Me.dtpTimeOfArrival.TabIndex = 14
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Red
        Me.label2.Location = New System.Drawing.Point(236, 60)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(200, 19)
        Me.label2.TabIndex = 13
        Me.label2.Text = "Vehicle Arrival Date Time :"
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnCancel)
        Me.ultraGroupBox2.Controls.Add(Me.btnOK)
        Me.ultraGroupBox2.Location = New System.Drawing.Point(1, 128)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(879, 97)
        Me.ultraGroupBox2.TabIndex = 3
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnCancel
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnCancel.Appearance = Appearance1
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(453, 17)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Drawing.Size(20, 0)
        Me.btnCancel.Size = New System.Drawing.Size(160, 63)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnOK
        '
        Appearance2.Image = Global.IMS.Win.My.Resources.Resources.Approve
        Me.btnOK.Appearance = Appearance2
        Me.btnOK.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnOK.Location = New System.Drawing.Point(266, 17)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Padding = New System.Drawing.Size(20, 0)
        Me.btnOK.Size = New System.Drawing.Size(160, 63)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&Ok"
        '
        'frmTimeOfArrival
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 213)
        Me.ControlBox = False
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTimeOfArrival"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        Me.ultraGroupBox1.PerformLayout()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dtpTimeOfArrival As System.Windows.Forms.DateTimePicker
    Private WithEvents label2 As System.Windows.Forms.Label
End Class
