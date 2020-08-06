namespace DNSChanger
{
	partial class SettingsForm
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
			this.installButton = new System.Windows.Forms.Button();
			this.serviceButton = new System.Windows.Forms.Button();
			this.configButton = new System.Windows.Forms.Button();
			this.runButton = new System.Windows.Forms.Button();
			this.configRecommendedButton = new System.Windows.Forms.Button();
			this.configPrivacyButton = new System.Windows.Forms.Button();
			this.saveConfigButton = new System.Windows.Forms.Button();
			this.loadConfigButton = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.statusLabel = new System.Windows.Forms.Label();
			this.ipv4_servers = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dnscrypt_servers = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.doh_servers = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ipv6_servers = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.fallback_resolvers = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.require_nolog = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.require_nofilter = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.require_dnssec = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.netprobe_address = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tls_disable_session_tickets = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.netprobe_timeout = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.dnscrypt_ephemeral_keys = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.reject_ttl = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.block_ipv6 = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// installButton
			// 
			this.installButton.Location = new System.Drawing.Point(12, 12);
			this.installButton.Name = "installButton";
			this.installButton.Size = new System.Drawing.Size(125, 23);
			this.installButton.TabIndex = 0;
			this.installButton.Text = "installButton";
			this.installButton.UseVisualStyleBackColor = true;
			this.installButton.Click += new System.EventHandler(this.installButton_Click);
			// 
			// serviceButton
			// 
			this.serviceButton.Location = new System.Drawing.Point(145, 12);
			this.serviceButton.Name = "serviceButton";
			this.serviceButton.Size = new System.Drawing.Size(125, 23);
			this.serviceButton.TabIndex = 1;
			this.serviceButton.Text = "serviceButton";
			this.serviceButton.UseVisualStyleBackColor = true;
			this.serviceButton.Click += new System.EventHandler(this.serviceButton_Click);
			// 
			// configButton
			// 
			this.configButton.Location = new System.Drawing.Point(12, 41);
			this.configButton.Name = "configButton";
			this.configButton.Size = new System.Drawing.Size(125, 23);
			this.configButton.TabIndex = 2;
			this.configButton.Text = "Open config file";
			this.configButton.UseVisualStyleBackColor = true;
			this.configButton.Click += new System.EventHandler(this.configButton_Click);
			// 
			// runButton
			// 
			this.runButton.Location = new System.Drawing.Point(145, 41);
			this.runButton.Name = "runButton";
			this.runButton.Size = new System.Drawing.Size(125, 23);
			this.runButton.TabIndex = 3;
			this.runButton.Text = "Debug process";
			this.runButton.UseVisualStyleBackColor = true;
			this.runButton.Click += new System.EventHandler(this.runButton_Click);
			// 
			// configRecommendedButton
			// 
			this.configRecommendedButton.Location = new System.Drawing.Point(12, 365);
			this.configRecommendedButton.Name = "configRecommendedButton";
			this.configRecommendedButton.Size = new System.Drawing.Size(125, 23);
			this.configRecommendedButton.TabIndex = 4;
			this.configRecommendedButton.Text = "Config: Balanced";
			this.configRecommendedButton.UseVisualStyleBackColor = true;
			this.configRecommendedButton.Click += new System.EventHandler(this.configRecommendedButton_Click);
			// 
			// configPrivacyButton
			// 
			this.configPrivacyButton.Location = new System.Drawing.Point(145, 365);
			this.configPrivacyButton.Name = "configPrivacyButton";
			this.configPrivacyButton.Size = new System.Drawing.Size(125, 23);
			this.configPrivacyButton.TabIndex = 6;
			this.configPrivacyButton.Text = "Config: Privacy";
			this.configPrivacyButton.UseVisualStyleBackColor = true;
			this.configPrivacyButton.Click += new System.EventHandler(this.configPrivacyButton_Click);
			// 
			// saveConfigButton
			// 
			this.saveConfigButton.Location = new System.Drawing.Point(12, 394);
			this.saveConfigButton.Name = "saveConfigButton";
			this.saveConfigButton.Size = new System.Drawing.Size(125, 23);
			this.saveConfigButton.TabIndex = 7;
			this.saveConfigButton.Text = "Save config";
			this.saveConfigButton.UseVisualStyleBackColor = true;
			this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
			// 
			// loadConfigButton
			// 
			this.loadConfigButton.Location = new System.Drawing.Point(145, 394);
			this.loadConfigButton.Name = "loadConfigButton";
			this.loadConfigButton.Size = new System.Drawing.Size(125, 23);
			this.loadConfigButton.TabIndex = 8;
			this.loadConfigButton.Text = "Load config";
			this.loadConfigButton.UseVisualStyleBackColor = true;
			this.loadConfigButton.Click += new System.EventHandler(this.loadConfigButton_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 441);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(258, 10);
			this.progressBar.TabIndex = 9;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(12, 425);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(184, 13);
			this.statusLabel.TabIndex = 10;
			this.statusLabel.Text = "Nothing is running in the background.";
			// 
			// ipv4_servers
			// 
			this.ipv4_servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ipv4_servers.FormattingEnabled = true;
			this.ipv4_servers.Location = new System.Drawing.Point(12, 88);
			this.ipv4_servers.Name = "ipv4_servers";
			this.ipv4_servers.Size = new System.Drawing.Size(125, 21);
			this.ipv4_servers.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Use IPv4 servers:";
			// 
			// dnscrypt_servers
			// 
			this.dnscrypt_servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dnscrypt_servers.FormattingEnabled = true;
			this.dnscrypt_servers.Location = new System.Drawing.Point(12, 128);
			this.dnscrypt_servers.Name = "dnscrypt_servers";
			this.dnscrypt_servers.Size = new System.Drawing.Size(125, 21);
			this.dnscrypt_servers.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Use DNSCrypt protocol:";
			// 
			// doh_servers
			// 
			this.doh_servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.doh_servers.FormattingEnabled = true;
			this.doh_servers.Location = new System.Drawing.Point(145, 128);
			this.doh_servers.Name = "doh_servers";
			this.doh_servers.Size = new System.Drawing.Size(125, 21);
			this.doh_servers.TabIndex = 18;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(142, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Use DOH protocol:";
			// 
			// ipv6_servers
			// 
			this.ipv6_servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ipv6_servers.FormattingEnabled = true;
			this.ipv6_servers.Location = new System.Drawing.Point(145, 88);
			this.ipv6_servers.Name = "ipv6_servers";
			this.ipv6_servers.Size = new System.Drawing.Size(125, 21);
			this.ipv6_servers.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(142, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Use IPv6 servers:";
			// 
			// fallback_resolvers
			// 
			this.fallback_resolvers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.fallback_resolvers.FormattingEnabled = true;
			this.fallback_resolvers.Location = new System.Drawing.Point(145, 208);
			this.fallback_resolvers.Name = "fallback_resolvers";
			this.fallback_resolvers.Size = new System.Drawing.Size(125, 21);
			this.fallback_resolvers.TabIndex = 26;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(142, 192);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(95, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "Fallback resolvers:";
			// 
			// require_nolog
			// 
			this.require_nolog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.require_nolog.FormattingEnabled = true;
			this.require_nolog.Location = new System.Drawing.Point(145, 168);
			this.require_nolog.Name = "require_nolog";
			this.require_nolog.Size = new System.Drawing.Size(125, 21);
			this.require_nolog.TabIndex = 24;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(142, 152);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "Require NOLOG:";
			// 
			// require_nofilter
			// 
			this.require_nofilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.require_nofilter.FormattingEnabled = true;
			this.require_nofilter.Location = new System.Drawing.Point(12, 208);
			this.require_nofilter.Name = "require_nofilter";
			this.require_nofilter.Size = new System.Drawing.Size(125, 21);
			this.require_nofilter.TabIndex = 22;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 192);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(103, 13);
			this.label7.TabIndex = 21;
			this.label7.Text = "Require NOFILTER:";
			// 
			// require_dnssec
			// 
			this.require_dnssec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.require_dnssec.FormattingEnabled = true;
			this.require_dnssec.Location = new System.Drawing.Point(12, 168);
			this.require_dnssec.Name = "require_dnssec";
			this.require_dnssec.Size = new System.Drawing.Size(125, 21);
			this.require_dnssec.TabIndex = 20;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 152);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(94, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Require DNSSEC:";
			// 
			// netprobe_address
			// 
			this.netprobe_address.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.netprobe_address.FormattingEnabled = true;
			this.netprobe_address.Location = new System.Drawing.Point(145, 288);
			this.netprobe_address.Name = "netprobe_address";
			this.netprobe_address.Size = new System.Drawing.Size(125, 21);
			this.netprobe_address.TabIndex = 34;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(142, 272);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(94, 13);
			this.label9.TabIndex = 33;
			this.label9.Text = "Netprobe address:";
			// 
			// tls_disable_session_tickets
			// 
			this.tls_disable_session_tickets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tls_disable_session_tickets.FormattingEnabled = true;
			this.tls_disable_session_tickets.Location = new System.Drawing.Point(145, 248);
			this.tls_disable_session_tickets.Name = "tls_disable_session_tickets";
			this.tls_disable_session_tickets.Size = new System.Drawing.Size(125, 21);
			this.tls_disable_session_tickets.TabIndex = 32;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(142, 232);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(117, 13);
			this.label10.TabIndex = 31;
			this.label10.Text = "Disable session tickets:";
			// 
			// netprobe_timeout
			// 
			this.netprobe_timeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.netprobe_timeout.FormattingEnabled = true;
			this.netprobe_timeout.Location = new System.Drawing.Point(12, 288);
			this.netprobe_timeout.Name = "netprobe_timeout";
			this.netprobe_timeout.Size = new System.Drawing.Size(125, 21);
			this.netprobe_timeout.TabIndex = 30;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(9, 272);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(91, 13);
			this.label11.TabIndex = 29;
			this.label11.Text = "Netprobe timeout:";
			// 
			// dnscrypt_ephemeral_keys
			// 
			this.dnscrypt_ephemeral_keys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dnscrypt_ephemeral_keys.FormattingEnabled = true;
			this.dnscrypt_ephemeral_keys.Location = new System.Drawing.Point(12, 248);
			this.dnscrypt_ephemeral_keys.Name = "dnscrypt_ephemeral_keys";
			this.dnscrypt_ephemeral_keys.Size = new System.Drawing.Size(125, 21);
			this.dnscrypt_ephemeral_keys.TabIndex = 28;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(9, 232);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(94, 13);
			this.label12.TabIndex = 27;
			this.label12.Text = "Disable key reuse:";
			// 
			// reject_ttl
			// 
			this.reject_ttl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.reject_ttl.FormattingEnabled = true;
			this.reject_ttl.Location = new System.Drawing.Point(145, 328);
			this.reject_ttl.Name = "reject_ttl";
			this.reject_ttl.Size = new System.Drawing.Size(125, 21);
			this.reject_ttl.TabIndex = 38;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(142, 312);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(106, 13);
			this.label13.TabIndex = 37;
			this.label13.Text = "Block response TTL:";
			// 
			// block_ipv6
			// 
			this.block_ipv6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.block_ipv6.FormattingEnabled = true;
			this.block_ipv6.Location = new System.Drawing.Point(12, 328);
			this.block_ipv6.Name = "block_ipv6";
			this.block_ipv6.Size = new System.Drawing.Size(125, 21);
			this.block_ipv6.TabIndex = 36;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(9, 312);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(105, 13);
			this.label14.TabIndex = 35;
			this.label14.Text = "Block IPv6 requests:";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(282, 461);
			this.Controls.Add(this.reject_ttl);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.block_ipv6);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.netprobe_address);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.tls_disable_session_tickets);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.netprobe_timeout);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.dnscrypt_ephemeral_keys);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.fallback_resolvers);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.require_nolog);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.require_nofilter);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.require_dnssec);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.doh_servers);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ipv6_servers);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dnscrypt_servers);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ipv4_servers);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.loadConfigButton);
			this.Controls.Add(this.saveConfigButton);
			this.Controls.Add(this.configPrivacyButton);
			this.Controls.Add(this.configRecommendedButton);
			this.Controls.Add(this.runButton);
			this.Controls.Add(this.configButton);
			this.Controls.Add(this.serviceButton);
			this.Controls.Add(this.installButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SettingsForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button installButton;
		private System.Windows.Forms.Button serviceButton;
		private System.Windows.Forms.Button configButton;
		private System.Windows.Forms.Button runButton;
		private System.Windows.Forms.Button configRecommendedButton;
		private System.Windows.Forms.Button configPrivacyButton;
		private System.Windows.Forms.Button saveConfigButton;
		private System.Windows.Forms.Button loadConfigButton;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.ComboBox ipv4_servers;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox dnscrypt_servers;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox doh_servers;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox ipv6_servers;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox fallback_resolvers;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox require_nolog;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox require_nofilter;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox require_dnssec;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox netprobe_address;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox tls_disable_session_tickets;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox netprobe_timeout;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox dnscrypt_ephemeral_keys;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox reject_ttl;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox block_ipv6;
		private System.Windows.Forms.Label label14;
	}
}