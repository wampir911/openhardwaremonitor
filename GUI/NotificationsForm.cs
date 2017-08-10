using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenHardwareMonitor.GUI
{
    public partial class NotificationsForm : Form
    {
        private PersistentSettings settings;

        public NotificationsForm(PersistentSettings settings)
        {
            this.settings = settings;
            InitializeComponent();
        }
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GPULoadTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void GPUTemperatureTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NotificationsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            settings.SetValue(new Identifier("notification","Email").ToString(), notificationEmailTxtBox.Text);
        }
    }
}
