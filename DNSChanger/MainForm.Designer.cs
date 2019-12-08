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
			this.v4primary = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dnsCombo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.v4secondary = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.v6secondary = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.v6primary = new System.Windows.Forms.TextBox();
			this.validateCb = new System.Windows.Forms.CheckBox();
			this.validateLbl = new System.Windows.Forms.Label();
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
			this.interfacesCombo.TabIndex = 0;
			// 
			// saveBtn
			// 
			this.saveBtn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.saveBtn.Location = new System.Drawing.Point(12, 251);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(82, 23);
			this.saveBtn.TabIndex = 7;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(100, 251);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(82, 23);
			this.cancelBtn.TabIndex = 8;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// resetBtn
			// 
			this.resetBtn.Location = new System.Drawing.Point(188, 251);
			this.resetBtn.Name = "resetBtn";
			this.resetBtn.Size = new System.Drawing.Size(82, 23);
			this.resetBtn.TabIndex = 9;
			this.resetBtn.Text = "Default";
			this.resetBtn.UseVisualStyleBackColor = true;
			this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
			// 
			// v4primary
			// 
			this.v4primary.Location = new System.Drawing.Point(108, 106);
			this.v4primary.MaxLength = 128;
			this.v4primary.Name = "v4primary";
			this.v4primary.Size = new System.Drawing.Size(162, 20);
			this.v4primary.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Network interface:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "DNS server:";
			// 
			// dnsCombo
			// 
			this.dnsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dnsCombo.FormattingEnabled = true;
			this.dnsCombo.Location = new System.Drawing.Point(12, 70);
			this.dnsCombo.Name = "dnsCombo";
			this.dnsCombo.Size = new System.Drawing.Size(259, 21);
			this.dnsCombo.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 109);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Primary (IPV4):";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 135);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Secondary (IPV4):";
			// 
			// v4secondary
			// 
			this.v4secondary.Location = new System.Drawing.Point(108, 132);
			this.v4secondary.MaxLength = 128;
			this.v4secondary.Name = "v4secondary";
			this.v4secondary.Size = new System.Drawing.Size(162, 20);
			this.v4secondary.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 195);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(93, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Secondary (IPV6):";
			// 
			// v6secondary
			// 
			this.v6secondary.Location = new System.Drawing.Point(109, 192);
			this.v6secondary.MaxLength = 128;
			this.v6secondary.Name = "v6secondary";
			this.v6secondary.Size = new System.Drawing.Size(162, 20);
			this.v6secondary.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(27, 169);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Primary (IPV6):";
			// 
			// v6primary
			// 
			this.v6primary.Location = new System.Drawing.Point(109, 166);
			this.v6primary.MaxLength = 128;
			this.v6primary.Name = "v6primary";
			this.v6primary.Size = new System.Drawing.Size(162, 20);
			this.v6primary.TabIndex = 4;
			// 
			// validateCb
			// 
			this.validateCb.AutoSize = true;
			this.validateCb.Location = new System.Drawing.Point(12, 228);
			this.validateCb.Name = "validateCb";
			this.validateCb.Size = new System.Drawing.Size(150, 17);
			this.validateCb.TabIndex = 6;
			this.validateCb.Text = "Validate on Windows boot";
			this.validateCb.UseVisualStyleBackColor = true;
			// 
			// validateLbl
			// 
			this.validateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.validateLbl.Location = new System.Drawing.Point(155, 229);
			this.validateLbl.Name = "validateLbl";
			this.validateLbl.Size = new System.Drawing.Size(127, 16);
			this.validateLbl.TabIndex = 16;
			// 
			// MainForm
			// 
			this.AcceptButton = this.saveBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(282, 286);
			this.Controls.Add(this.validateLbl);
			this.Controls.Add(this.validateCb);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.v6secondary);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.v6primary);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.v4secondary);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dnsCombo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.v4primary);
			this.Controls.Add(this.resetBtn);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.interfacesCombo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox interfacesCombo;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.TextBox v4primary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dnsCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox v4secondary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox v6secondary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox v6primary;
        private System.Windows.Forms.CheckBox validateCb;
        private System.Windows.Forms.Label validateLbl;
    }
}

