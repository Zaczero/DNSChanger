using DNSChanger.Structs;
using System;
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
