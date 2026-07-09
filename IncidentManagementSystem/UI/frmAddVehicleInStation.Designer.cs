namespace IncidentManagementSystem.UI
{
    partial class frmAddVehicleInStation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.cmbStationCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnRefresh = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVehicleCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVehicleCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            appearance10.Image = global::IncidentManagementSystem.Properties.Resources.Close;
            this.btnClose.Appearance = appearance10;
            this.btnClose.Location = new System.Drawing.Point(332, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            // 
            // btnSave
            // 
            appearance11.Image = global::IncidentManagementSystem.Properties.Resources.Save;
            this.btnSave.Appearance = appearance11;
            this.btnSave.Location = new System.Drawing.Point(170, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            // 
            // cmbStationCode
            // 
            this.cmbStationCode.Location = new System.Drawing.Point(93, 10);
            this.cmbStationCode.Name = "cmbStationCode";
            this.cmbStationCode.Size = new System.Drawing.Size(169, 23);
            this.cmbStationCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(282, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Station Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(13, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Station Code";
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(367, 10);
            this.txtStationName.MaxLength = 100;
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.ReadOnly = true;
            this.txtStationName.Size = new System.Drawing.Size(168, 22);
            this.txtStationName.TabIndex = 0;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox1.Controls.Add(this.cmbVehicleCode);
            this.ultraGroupBox1.Controls.Add(this.cmbStationCode);
            this.ultraGroupBox1.Controls.Add(this.label4);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.label3);
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.label5);
            this.ultraGroupBox1.Controls.Add(this.txtSerial);
            this.ultraGroupBox1.Controls.Add(this.textBox1);
            this.ultraGroupBox1.Controls.Add(this.txtStationName);
            this.ultraGroupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGroupBox1.Location = new System.Drawing.Point(3, 2);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(577, 138);
            this.ultraGroupBox1.TabIndex = 1;
            this.ultraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // btnRefresh
            // 
            appearance12.Image = global::IncidentManagementSystem.Properties.Resources.Refresh;
            this.btnRefresh.Appearance = appearance12;
            this.btnRefresh.Location = new System.Drawing.Point(251, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "&Refresh";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ultraGroupBox2.Controls.Add(this.btnClose);
            this.ultraGroupBox2.Controls.Add(this.btnRefresh);
            this.ultraGroupBox2.Controls.Add(this.btnSave);
            this.ultraGroupBox2.Location = new System.Drawing.Point(2, 142);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(577, 67);
            this.ultraGroupBox2.TabIndex = 2;
            this.ultraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(367, 43);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(168, 22);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vehicle Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(280, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vehicle Name";
            // 
            // cmbVehicleCode
            // 
            this.cmbVehicleCode.Location = new System.Drawing.Point(93, 44);
            this.cmbVehicleCode.Name = "cmbVehicleCode";
            this.cmbVehicleCode.Size = new System.Drawing.Size(169, 23);
            this.cmbVehicleCode.TabIndex = 2;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(367, 76);
            this.txtSerial.MaxLength = 50;
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(168, 22);
            this.txtSerial.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(320, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Serial";
            // 
            // frmAddVehicleInStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 211);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.ultraGroupBox2);
            this.Name = "frmAddVehicleInStation";
            this.Text = "Add Vehicle Assignments In Station";
            ((System.ComponentModel.ISupportInitialize)(this.cmbStationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbVehicleCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnSave;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbStationCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStationName;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraButton btnRefresh;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbVehicleCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerial;
    }
}