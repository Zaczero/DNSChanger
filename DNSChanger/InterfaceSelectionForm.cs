using DNSChanger.Structs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DNSChanger
{
	public partial class InterfaceSelectionForm : Form
	{
		public bool Success;
		public Interface SelectedInterface;

		public InterfaceSelectionForm()
		{
			InitializeComponent();
			Text = GlobalVars.Name + @" Interface Selector";
			Icon = Properties.Resources.Icon;

			if (Utilities.IsSystemDarkMode())
			{
				BackColor = Color.FromArgb(0x20, 0x20, 0x20);
				ForeColor = Color.FromArgb(0xF0, 0xF0, 0xF0);

				foreach (Control control in Controls)
				{
					if (control is Button)
					{
						var btn = control as Button;
						btn.FlatStyle = FlatStyle.Flat;
						btn.UseVisualStyleBackColor = false;
					}
				}
			}


			FillInterfaces();
		}
		
		private void FillInterfaces()
		{
			interfacesCombo.Items.Clear();

			foreach (var @interface in NetshHelper.GetInterfaces())
			{
				interfacesCombo.Items.Add(new ComboBoxItem(@interface.ToString(), @interface));
			}

			interfacesCombo.SelectedIndex = 0;
		}

		private Interface GetSelectedInterface()
		{
			return (Interface) ((ComboBoxItem) interfacesCombo.SelectedItem).Value;
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			Success = true;
			SelectedInterface = GetSelectedInterface();
			Close();
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			Success = false;
			Close();
		}
	}
}
