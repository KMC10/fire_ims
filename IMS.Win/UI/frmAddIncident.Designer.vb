<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddIncident
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
        Me.ultraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbPrimaryStation = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grvAssignedFirestations = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chkFireStation = New System.Windows.Forms.CheckedListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grbIncidentType = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chklstIncidentType = New System.Windows.Forms.CheckedListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grbIncidentCategory = New Infragistics.Win.Misc.UltraGroupBox()
        Me.chklstIncidentCategory = New System.Windows.Forms.CheckedListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.rdoPartialCall = New System.Windows.Forms.RadioButton()
        Me.rdoFullCall = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.lblResolution = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtResolution = New System.Windows.Forms.TextBox()
        Me.txtReferenceNo = New System.Windows.Forms.TextBox()
        Me.txtCallerName = New System.Windows.Forms.TextBox()
        Me.txtCallerNumber = New System.Windows.Forms.TextBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.ultraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnReopen = New Infragistics.Win.Misc.UltraButton()
        Me.btnResolve = New Infragistics.Win.Misc.UltraButton()
        Me.btnClose = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddNew = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox1.SuspendLayout()
        CType(Me.cmbPrimaryStation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvAssignedFirestations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grvAssignedFirestations.SuspendLayout()
        CType(Me.grbIncidentType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbIncidentType.SuspendLayout()
        CType(Me.grbIncidentCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbIncidentCategory.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ultraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ultraGroupBox1
        '
        Me.ultraGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox1.Controls.Add(Me.cmbPrimaryStation)
        Me.ultraGroupBox1.Controls.Add(Me.Label10)
        Me.ultraGroupBox1.Controls.Add(Me.grvAssignedFirestations)
        Me.ultraGroupBox1.Controls.Add(Me.grbIncidentType)
        Me.ultraGroupBox1.Controls.Add(Me.grbIncidentCategory)
        Me.ultraGroupBox1.Controls.Add(Me.UltraGroupBox3)
        Me.ultraGroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ultraGroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.ultraGroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox1.Name = "ultraGroupBox1"
        Me.ultraGroupBox1.Size = New System.Drawing.Size(966, 633)
        Me.ultraGroupBox1.TabIndex = 0
        Me.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'cmbPrimaryStation
        '
        Me.cmbPrimaryStation.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbPrimaryStation.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrimaryStation.Location = New System.Drawing.Point(688, 397)
        Me.cmbPrimaryStation.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPrimaryStation.Name = "cmbPrimaryStation"
        Me.cmbPrimaryStation.Size = New System.Drawing.Size(269, 29)
        Me.cmbPrimaryStation.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(688, 369)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 19)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Primary Station :"
        '
        'grvAssignedFirestations
        '
        Me.grvAssignedFirestations.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grvAssignedFirestations.Controls.Add(Me.chkFireStation)
        Me.grvAssignedFirestations.Controls.Add(Me.Label9)
        Me.grvAssignedFirestations.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvAssignedFirestations.Location = New System.Drawing.Point(681, 433)
        Me.grvAssignedFirestations.Name = "grvAssignedFirestations"
        Me.grvAssignedFirestations.Size = New System.Drawing.Size(276, 194)
        Me.grvAssignedFirestations.TabIndex = 5
        Me.grvAssignedFirestations.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'chkFireStation
        '
        Me.chkFireStation.CheckOnClick = True
        Me.chkFireStation.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFireStation.FormattingEnabled = True
        Me.chkFireStation.Location = New System.Drawing.Point(7, 30)
        Me.chkFireStation.Name = "chkFireStation"
        Me.chkFireStation.Size = New System.Drawing.Size(263, 158)
        Me.chkFireStation.TabIndex = 1
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
        Me.Label9.Size = New System.Drawing.Size(151, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Others Fire Stations"
        '
        'grbIncidentType
        '
        Me.grbIncidentType.Controls.Add(Me.chklstIncidentType)
        Me.grbIncidentType.Controls.Add(Me.Label8)
        Me.grbIncidentType.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbIncidentType.Location = New System.Drawing.Point(681, 168)
        Me.grbIncidentType.Name = "grbIncidentType"
        Me.grbIncidentType.Size = New System.Drawing.Size(276, 194)
        Me.grbIncidentType.TabIndex = 2
        Me.grbIncidentType.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'chklstIncidentType
        '
        Me.chklstIncidentType.CheckOnClick = True
        Me.chklstIncidentType.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklstIncidentType.FormattingEnabled = True
        Me.chklstIncidentType.Location = New System.Drawing.Point(6, 30)
        Me.chklstIncidentType.Name = "chklstIncidentType"
        Me.chklstIncidentType.Size = New System.Drawing.Size(263, 158)
        Me.chklstIncidentType.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(7, 8)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Incident Type"
        '
        'grbIncidentCategory
        '
        Me.grbIncidentCategory.Controls.Add(Me.chklstIncidentCategory)
        Me.grbIncidentCategory.Controls.Add(Me.Label7)
        Me.grbIncidentCategory.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbIncidentCategory.ForeColor = System.Drawing.Color.Transparent
        Me.grbIncidentCategory.Location = New System.Drawing.Point(681, 8)
        Me.grbIncidentCategory.Name = "grbIncidentCategory"
        Me.grbIncidentCategory.Size = New System.Drawing.Size(276, 154)
        Me.grbIncidentCategory.TabIndex = 1
        Me.grbIncidentCategory.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'chklstIncidentCategory
        '
        Me.chklstIncidentCategory.CheckOnClick = True
        Me.chklstIncidentCategory.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklstIncidentCategory.FormattingEnabled = True
        Me.chklstIncidentCategory.Location = New System.Drawing.Point(6, 31)
        Me.chklstIncidentCategory.Name = "chklstIncidentCategory"
        Me.chklstIncidentCategory.Size = New System.Drawing.Size(263, 114)
        Me.chklstIncidentCategory.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(7, 8)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Incident Category"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox3.Controls.Add(Me.rdoPartialCall)
        Me.UltraGroupBox3.Controls.Add(Me.rdoFullCall)
        Me.UltraGroupBox3.Controls.Add(Me.Label1)
        Me.UltraGroupBox3.Controls.Add(Me.label3)
        Me.UltraGroupBox3.Controls.Add(Me.lblResolution)
        Me.UltraGroupBox3.Controls.Add(Me.Label5)
        Me.UltraGroupBox3.Controls.Add(Me.label2)
        Me.UltraGroupBox3.Controls.Add(Me.Label6)
        Me.UltraGroupBox3.Controls.Add(Me.label4)
        Me.UltraGroupBox3.Controls.Add(Me.txtResolution)
        Me.UltraGroupBox3.Controls.Add(Me.txtReferenceNo)
        Me.UltraGroupBox3.Controls.Add(Me.txtCallerName)
        Me.UltraGroupBox3.Controls.Add(Me.txtCallerNumber)
        Me.UltraGroupBox3.Controls.Add(Me.txtMessage)
        Me.UltraGroupBox3.Controls.Add(Me.txtAddress)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(5, 8)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(652, 620)
        Me.UltraGroupBox3.TabIndex = 0
        Me.UltraGroupBox3.Text = "Incident Information"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'rdoPartialCall
        '
        Me.rdoPartialCall.AutoSize = True
        Me.rdoPartialCall.BackColor = System.Drawing.Color.Transparent
        Me.rdoPartialCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPartialCall.Location = New System.Drawing.Point(260, 400)
        Me.rdoPartialCall.Name = "rdoPartialCall"
        Me.rdoPartialCall.Size = New System.Drawing.Size(101, 24)
        Me.rdoPartialCall.TabIndex = 12
        Me.rdoPartialCall.Text = "Partial Call"
        Me.rdoPartialCall.UseVisualStyleBackColor = False
        '
        'rdoFullCall
        '
        Me.rdoFullCall.AutoSize = True
        Me.rdoFullCall.BackColor = System.Drawing.Color.Transparent
        Me.rdoFullCall.Checked = True
        Me.rdoFullCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFullCall.Location = New System.Drawing.Point(163, 400)
        Me.rdoFullCall.Name = "rdoFullCall"
        Me.rdoFullCall.Size = New System.Drawing.Size(82, 24)
        Me.rdoFullCall.TabIndex = 11
        Me.rdoFullCall.TabStop = True
        Me.rdoFullCall.Text = "Full Call"
        Me.rdoFullCall.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(82, 402)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 20)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Call Type :"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.BackColor = System.Drawing.Color.Transparent
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.Red
        Me.label3.Location = New System.Drawing.Point(60, 134)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(103, 20)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Caller Name :"
        '
        'lblResolution
        '
        Me.lblResolution.AutoSize = True
        Me.lblResolution.BackColor = System.Drawing.Color.Transparent
        Me.lblResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResolution.ForeColor = System.Drawing.Color.Red
        Me.lblResolution.Location = New System.Drawing.Point(70, 479)
        Me.lblResolution.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(93, 20)
        Me.lblResolution.TabIndex = 13
        Me.lblResolution.Text = "Resolution :"
        Me.lblResolution.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 50)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Reference No :"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.Red
        Me.label2.Location = New System.Drawing.Point(26, 93)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(137, 20)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Caller Cell/Phone :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(81, 321)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Message :"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.BackColor = System.Drawing.Color.Transparent
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.Red
        Me.label4.Location = New System.Drawing.Point(87, 209)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(76, 20)
        Me.label4.TabIndex = 6
        Me.label4.Text = "Address :"
        '
        'txtResolution
        '
        Me.txtResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResolution.Location = New System.Drawing.Point(163, 442)
        Me.txtResolution.Margin = New System.Windows.Forms.Padding(4)
        Me.txtResolution.MaxLength = 200
        Me.txtResolution.Multiline = True
        Me.txtResolution.Name = "txtResolution"
        Me.txtResolution.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResolution.Size = New System.Drawing.Size(425, 94)
        Me.txtResolution.TabIndex = 14
        Me.txtResolution.Visible = False
        '
        'txtReferenceNo
        '
        Me.txtReferenceNo.Enabled = False
        Me.txtReferenceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferenceNo.Location = New System.Drawing.Point(163, 47)
        Me.txtReferenceNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReferenceNo.MaxLength = 50
        Me.txtReferenceNo.Name = "txtReferenceNo"
        Me.txtReferenceNo.Size = New System.Drawing.Size(202, 26)
        Me.txtReferenceNo.TabIndex = 1
        '
        'txtCallerName
        '
        Me.txtCallerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCallerName.Location = New System.Drawing.Point(163, 131)
        Me.txtCallerName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCallerName.MaxLength = 100
        Me.txtCallerName.Name = "txtCallerName"
        Me.txtCallerName.Size = New System.Drawing.Size(425, 26)
        Me.txtCallerName.TabIndex = 5
        '
        'txtCallerNumber
        '
        Me.txtCallerNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCallerNumber.Location = New System.Drawing.Point(163, 90)
        Me.txtCallerNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCallerNumber.MaxLength = 60
        Me.txtCallerNumber.Name = "txtCallerNumber"
        Me.txtCallerNumber.Size = New System.Drawing.Size(202, 26)
        Me.txtCallerNumber.TabIndex = 3
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(163, 284)
        Me.txtMessage.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMessage.MaxLength = 200
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(425, 94)
        Me.txtMessage.TabIndex = 9
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(163, 172)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddress.MaxLength = 200
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAddress.Size = New System.Drawing.Size(425, 94)
        Me.txtAddress.TabIndex = 7
        '
        'ultraGroupBox2
        '
        Me.ultraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ultraGroupBox2.Controls.Add(Me.btnReopen)
        Me.ultraGroupBox2.Controls.Add(Me.btnResolve)
        Me.ultraGroupBox2.Controls.Add(Me.btnClose)
        Me.ultraGroupBox2.Controls.Add(Me.btnAddNew)
        Me.ultraGroupBox2.Controls.Add(Me.btnSave)
        Me.ultraGroupBox2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ultraGroupBox2.Location = New System.Drawing.Point(2, 636)
        Me.ultraGroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ultraGroupBox2.Name = "ultraGroupBox2"
        Me.ultraGroupBox2.Size = New System.Drawing.Size(966, 113)
        Me.ultraGroupBox2.TabIndex = 1
        Me.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        '
        'btnReopen
        '
        Appearance1.Image = Global.IMS.Win.My.Resources.Resources.Load
        Me.btnReopen.Appearance = Appearance1
        Me.btnReopen.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReopen.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnReopen.Location = New System.Drawing.Point(766, 25)
        Me.btnReopen.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReopen.Name = "btnReopen"
        Me.btnReopen.Padding = New System.Drawing.Size(20, 0)
        Me.btnReopen.Size = New System.Drawing.Size(160, 63)
        Me.btnReopen.TabIndex = 4
        Me.btnReopen.Text = "Re&open"
        Me.btnReopen.Visible = False
        '
        'btnResolve
        '
        Appearance2.Image = Global.IMS.Win.My.Resources.Resources.Approve
        Me.btnResolve.Appearance = Appearance2
        Me.btnResolve.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResolve.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnResolve.Location = New System.Drawing.Point(589, 25)
        Me.btnResolve.Margin = New System.Windows.Forms.Padding(4)
        Me.btnResolve.Name = "btnResolve"
        Me.btnResolve.Padding = New System.Drawing.Size(20, 0)
        Me.btnResolve.Size = New System.Drawing.Size(160, 63)
        Me.btnResolve.TabIndex = 3
        Me.btnResolve.Text = "&Resolve"
        Me.btnResolve.Visible = True
        '
        'btnClose
        '
        Appearance3.Image = Global.IMS.Win.My.Resources.Resources.Close
        Me.btnClose.Appearance = Appearance3
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnClose.Location = New System.Drawing.Point(412, 25)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Drawing.Size(20, 0)
        Me.btnClose.Size = New System.Drawing.Size(160, 63)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Close"
        '
        'btnAddNew
        '
        Appearance4.Image = Global.IMS.Win.My.Resources.Resources.Add
        Me.btnAddNew.Appearance = Appearance4
        Me.btnAddNew.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddNew.Location = New System.Drawing.Point(41, 25)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Padding = New System.Drawing.Size(20, 0)
        Me.btnAddNew.Size = New System.Drawing.Size(177, 63)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Add &New"
        '
        'btnSave
        '
        Appearance5.Image = Global.IMS.Win.My.Resources.Resources.Save
        Me.btnSave.Appearance = Appearance5
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnSave.Location = New System.Drawing.Point(235, 25)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Drawing.Size(20, 0)
        Me.btnSave.Size = New System.Drawing.Size(160, 63)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Save"
        '
        'frmAddIncident
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(971, 750)
        Me.Controls.Add(Me.ultraGroupBox1)
        Me.Controls.Add(Me.ultraGroupBox2)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddIncident"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Incident "
        CType(Me.ultraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox1.ResumeLayout(False)
        Me.ultraGroupBox1.PerformLayout()
        CType(Me.cmbPrimaryStation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvAssignedFirestations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grvAssignedFirestations.ResumeLayout(False)
        Me.grvAssignedFirestations.PerformLayout()
        CType(Me.grbIncidentType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbIncidentType.ResumeLayout(False)
        Me.grbIncidentType.PerformLayout()
        CType(Me.grbIncidentCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbIncidentCategory.ResumeLayout(False)
        Me.grbIncidentCategory.PerformLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.ultraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ultraGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ultraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grvAssignedFirestations As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkFireStation As System.Windows.Forms.CheckedListBox
    Friend WithEvents grbIncidentType As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chklstIncidentType As System.Windows.Forms.CheckedListBox
    Friend WithEvents grbIncidentCategory As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chklstIncidentCategory As System.Windows.Forms.CheckedListBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents rdoPartialCall As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFullCall As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents lblResolution As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtResolution As System.Windows.Forms.TextBox
    Private WithEvents txtCallerName As System.Windows.Forms.TextBox
    Private WithEvents txtCallerNumber As System.Windows.Forms.TextBox
    Private WithEvents txtMessage As System.Windows.Forms.TextBox
    Private WithEvents txtAddress As System.Windows.Forms.TextBox
    Private WithEvents btnAddNew As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnClose As Infragistics.Win.Misc.UltraButton
    Private WithEvents ultraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents btnResolve As Infragistics.Win.Misc.UltraButton
    Private WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents txtReferenceNo As System.Windows.Forms.TextBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents btnReopen As Infragistics.Win.Misc.UltraButton
    Private WithEvents cmbPrimaryStation As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Private WithEvents Label10 As System.Windows.Forms.Label
End Class
