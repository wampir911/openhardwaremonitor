using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Utilities;
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

        private void SetControlsBehavior()
        {
            GPULoadNumUpDown.Enabled = GPULoadDDL.SelectedIndex > 0;
            GPUTemperatureNumUpDown.Enabled = GPUTemperatureDDL.SelectedIndex > 0;
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
            settings.SetValue(EmailNotificationManager.EmailIdentifier.ToString(), notificationEmailTxtBox.Text);
            settings.SetValue(EmailNotificationManager.GPULoadThresholdIdentifier.ToString(), GPULoadDDL.SelectedIndex);
            settings.SetValue(EmailNotificationManager.GraterLessSignGPULoadIdentifier.ToString(), GPULoadDDL.SelectedIndex);

            settings.SetValue(EmailNotificationManager.GPUTemperatureThresholdIdentifier.ToString(), GPUTemperatureNumUpDown.Value.ToString());            
            settings.SetValue(EmailNotificationManager.GraterLessSignGPUTemperatureThresholdIdentifier.ToString(), GPUTemperatureDDL.SelectedIndex);
        }

        private void NotificationsForm_Load(object sender, EventArgs e)
        {
            notificationEmailTxtBox.Text = settings.GetValue(EmailNotificationManager.EmailIdentifier.ToString(), string.Empty);
            GPULoadNumUpDown.Value = Convert.ToInt32(settings.GetValue(EmailNotificationManager.GPULoadThresholdIdentifier.ToString(), 0));
            GPUTemperatureNumUpDown.Value = Convert.ToInt32(settings.GetValue(EmailNotificationManager.GPUTemperatureThresholdIdentifier.ToString(), 0));
            GPULoadDDL.SelectedIndex = Convert.ToInt32(settings.GetValue(EmailNotificationManager.GraterLessSignGPULoadIdentifier.ToString(), 0));
            GPUTemperatureDDL.SelectedIndex = Convert.ToInt32(settings.GetValue(EmailNotificationManager.GraterLessSignGPUTemperatureThresholdIdentifier.ToString(), 0));

            this.SetControlsBehavior();
        }        

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.SetControlsBehavior();
        }

        private void GPUTemperatureDDL_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.SetControlsBehavior();
        }             
    }
}
