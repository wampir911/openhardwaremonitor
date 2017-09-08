using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Utilities;
using OpenHardwareMonitor.Utilities.Notifier;
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
            settings.SetValue(GPULoadChecker.ThresholdIdentifier.ToString(), GPULoadNumUpDown.Value.ToString());
            settings.SetValue(GPULoadChecker.GraterLessSignIdentifier.ToString(), GPULoadDDL.SelectedIndex);

            settings.SetValue(GPUTemperatureChecker.ThresholdIdentifier.ToString(), GPUTemperatureNumUpDown.Value.ToString());            
            settings.SetValue(GPUTemperatureChecker.GraterLessSignIdentifier.ToString(), GPUTemperatureDDL.SelectedIndex);

            settings.SetValue(CPUTemperatureChecker.ThresholdIdentifier.ToString(), CPUTemperatureNumUpDown.Value.ToString());
            settings.SetValue(CPUTemperatureChecker.GraterLessSignIdentifier.ToString(), CPUTemperatureDDL.SelectedIndex);

            settings.SetValue(CPULoadChecker.ThresholdIdentifier.ToString(), CPULoadNumUpDown.Value.ToString());
            settings.SetValue(CPULoadChecker.GraterLessSignIdentifier.ToString(), CPULoadDDL.SelectedIndex);

            settings.SetValue(MemoryUsageChecker.ThresholdIdentifier.ToString(), MemoryUsageNumUpDown.Value.ToString());
            settings.SetValue(MemoryUsageChecker.GraterLessSignIdentifier.ToString(), MemoryUsageDDL.SelectedIndex);
        }

        private void NotificationsForm_Load(object sender, EventArgs e)
        {
            notificationEmailTxtBox.Text = settings.GetValue(EmailNotificationManager.EmailIdentifier.ToString(), string.Empty);
            GPULoadNumUpDown.Value = Convert.ToDecimal(settings.GetValue(GPULoadChecker.ThresholdIdentifier.ToString(), 0));
            GPULoadDDL.SelectedIndex = Convert.ToInt32(settings.GetValue(GPULoadChecker.GraterLessSignIdentifier.ToString(), 0));
            GPUTemperatureNumUpDown.Value = Convert.ToDecimal(settings.GetValue(GPUTemperatureChecker.ThresholdIdentifier.ToString(), 0));           
            GPUTemperatureDDL.SelectedIndex = Convert.ToInt32(settings.GetValue(GPUTemperatureChecker.GraterLessSignIdentifier.ToString(), 0));

            CPULoadNumUpDown.Value = Convert.ToDecimal(settings.GetValue(CPULoadChecker.ThresholdIdentifier.ToString(), 0));
            CPULoadDDL.SelectedIndex = Convert.ToInt32(settings.GetValue(CPULoadChecker.GraterLessSignIdentifier.ToString(), 0));
            CPUTemperatureNumUpDown.Value = Convert.ToDecimal(settings.GetValue(CPUTemperatureChecker.ThresholdIdentifier.ToString(), 0));
            CPUTemperatureDDL.SelectedIndex = Convert.ToInt32(settings.GetValue(CPUTemperatureChecker.GraterLessSignIdentifier.ToString(), 0));

            MemoryUsageNumUpDown.Value = Convert.ToDecimal(settings.GetValue(MemoryUsageChecker.ThresholdIdentifier.ToString(), 0));
            MemoryUsageDDL.SelectedIndex = Convert.ToInt32(settings.GetValue(MemoryUsageChecker.GraterLessSignIdentifier.ToString(), 0));

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
