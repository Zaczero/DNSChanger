namespace DNSChanger
{
    partial class MainForm
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
			this.interfacesCombo = new System.Windows.Forms.ComboBox();
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.resetBtn = new System.Windows.Forms.Button();
			this.v4primaryText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dnsCombo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.v4secondaryText = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.v6secondaryText = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.v6primaryText = new System.Windows.Forms.TextBox();
			this.settingsLabel = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// interfacesCombo
			// 
			this.interfacesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.interfacesCombo.FormattingEnabled = true;
			this.interfacesCombo.Location = new System.Drawing.Point(12, 25);
			this.interfacesCombo.Name = "interfacesCombo";
			this.interfacesCombo.Size = new System.Drawing.Size(259, 21);
			this.interfacesCombo.Sorted = true;
			this.interfacesCombo.TabIndex = 1;
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(12, 251);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(82, 23);
			this.saveBtn.TabIndex = 13;
			this.saveBtn.Text = "Save";
			this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(100, 251);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(82, 23);
			this.cancelBtn.TabIndex = 14;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// resetBtn
			// 
			this.resetBtn.Location = new System.Drawing.Point(188, 251);
			this.resetBtn.Name = "resetBtn";
			this.resetBtn.Size = new System.Drawing.Size(82, 23);
			this.resetBtn.TabIndex = 15;
			this.resetBtn.Text = "Default";
			this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
			// 
			// v4primary
			// 
			this.v4primaryText.Location = new System.Drawing.Point(108, 106);
			this.v4primaryText.MaxLength = 128;
			this.v4primaryText.Name = "v4primaryText";
			this.v4primaryText.Size = new System.Drawing.Size(162, 20);
			this.v4primaryText.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Network interface:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "DNS server:";
			// 
			// dnsCombo
			// 
			this.dnsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dnsCombo.FormattingEnabled = true;
			this.dnsCombo.Location = new System.Drawing.Point(12, 70);
			this.dnsCombo.Name = "dnsCombo";
			this.dnsCombo.Size = new System.Drawing.Size(259, 21);
			this.dnsCombo.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 109);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Primary (IPV4):";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 135);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Secondary (IPV4):";
			// 
			// v4secondary
			// 
			this.v4secondaryText.Location = new System.Drawing.Point(108, 132);
			this.v4secondaryText.MaxLength = 128;
			this.v4secondaryText.Name = "v4secondaryText";
			this.v4secondaryText.Size = new System.Drawing.Size(162, 20);
			this.v4secondaryText.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 195);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(93, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Secondary (IPV6):";
			// 
			// v6secondary
			// 
			this.v6secondaryText.Location = new System.Drawing.Point(109, 192);
			this.v6secondaryText.MaxLength = 128;
			this.v6secondaryText.Name = "v6secondaryText";
			this.v6secondaryText.Size = new System.Drawing.Size(162, 20);
			this.v6secondaryText.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 169);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Primary (IPV6):";
			// 
			// v6primary
			// 
			this.v6primaryText.Location = new System.Drawing.Point(109, 166);
			this.v6primaryText.MaxLength = 128;
			this.v6primaryText.Name = "v6primaryText";
			this.v6primaryText.Size = new System.Drawing.Size(162, 20);
			this.v6primaryText.TabIndex = 9;
			// 
			// settingsLabel
			// 
			this.settingsLabel.AutoSize = true;
			this.settingsLabel.Location = new System.Drawing.Point(153, 220);
			this.settingsLabel.Name = "settingsLabel";
			this.settingsLabel.Size = new System.Drawing.Size(118, 13);
			this.settingsLabel.TabIndex = 12;
			this.settingsLabel.TabStop = true;
			this.settingsLabel.Text = "DNSCrypt configuration";
			this.settingsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.settingsLabel_LinkClicked);
			// 
			// MainForm
			// 
			this.AcceptButton = this.saveBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(282, 286);
			this.Controls.Add(this.settingsLabel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.v6secondaryText);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.v6primaryText);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.v4secondaryText);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dnsCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.v4primaryText);
			this.Controls.Add(this.resetBtn);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.interfacesCombo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox interfacesCombo;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.TextBox v4primaryText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dnsCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox v4secondaryText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox v6secondaryText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox v6primaryText;
		private System.Windows.Forms.LinkLabel settingsLabel;
	}
}

