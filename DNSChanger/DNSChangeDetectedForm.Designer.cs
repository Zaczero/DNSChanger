namespace DNSChanger
{
    partial class DNSChangeDetectedForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.interfaceTb = new System.Windows.Forms.TextBox();
            this.savedTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.systemTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ignoreBtn = new System.Windows.Forms.Button();
            this.manualBtn = new System.Windows.Forms.Button();
            this.quickBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNS change detected !";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "System DNS differ from the ones set by the application.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Network Interface:";
            // 
            // interfaceTb
            // 
            this.interfaceTb.Location = new System.Drawing.Point(12, 74);
            this.interfaceTb.Name = "interfaceTb";
            this.interfaceTb.ReadOnly = true;
            this.interfaceTb.Size = new System.Drawing.Size(267, 20);
            this.interfaceTb.TabIndex = 3;
            // 
            // savedTb
            // 
            this.savedTb.Location = new System.Drawing.Point(12, 118);
            this.savedTb.Name = "savedTb";
            this.savedTb.ReadOnly = true;
            this.savedTb.Size = new System.Drawing.Size(267, 20);
            this.savedTb.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Saved DNS:";
            // 
            // systemTb
            // 
            this.systemTb.Location = new System.Drawing.Point(12, 162);
            this.systemTb.Name = "systemTb";
            this.systemTb.ReadOnly = true;
            this.systemTb.Size = new System.Drawing.Size(267, 20);
            this.systemTb.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "System DNS:";
            // 
            // ignoreBtn
            // 
            this.ignoreBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ignoreBtn.Location = new System.Drawing.Point(194, 188);
            this.ignoreBtn.Name = "ignoreBtn";
            this.ignoreBtn.Size = new System.Drawing.Size(85, 23);
            this.ignoreBtn.TabIndex = 10;
            this.ignoreBtn.Text = "Ignore";
            this.ignoreBtn.UseVisualStyleBackColor = true;
            this.ignoreBtn.Click += new System.EventHandler(this.ignoreBtn_Click);
            // 
            // manualBtn
            // 
            this.manualBtn.Location = new System.Drawing.Point(103, 188);
            this.manualBtn.Name = "manualBtn";
            this.manualBtn.Size = new System.Drawing.Size(85, 23);
            this.manualBtn.TabIndex = 9;
            this.manualBtn.Text = "Manual fix";
            this.manualBtn.UseVisualStyleBackColor = true;
            this.manualBtn.Click += new System.EventHandler(this.manualBtn_Click);
            // 
            // quickBtn
            // 
            this.quickBtn.Location = new System.Drawing.Point(12, 188);
            this.quickBtn.Name = "quickBtn";
            this.quickBtn.Size = new System.Drawing.Size(85, 23);
            this.quickBtn.TabIndex = 8;
            this.quickBtn.Text = "Quick fix";
            this.quickBtn.UseVisualStyleBackColor = true;
            this.quickBtn.Click += new System.EventHandler(this.quickBtn_Click);
            // 
            // DNSChangeDetectedForm
            // 
            this.AcceptButton = this.quickBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ignoreBtn;
            this.ClientSize = new System.Drawing.Size(291, 223);
            this.Controls.Add(this.quickBtn);
            this.Controls.Add(this.manualBtn);
            this.Controls.Add(this.ignoreBtn);
            this.Controls.Add(this.systemTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.savedTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.interfaceTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DNSChangeDetectedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DNSChangeDetectedForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox interfaceTb;
        private System.Windows.Forms.TextBox savedTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox systemTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ignoreBtn;
        private System.Windows.Forms.Button manualBtn;
        private System.Windows.Forms.Button quickBtn;
    }
}