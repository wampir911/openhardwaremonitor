using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    public class EmailNotificationManager
    {
        private IComputer computer;
        private ISensorTextManager sensorTextManager;
        private PersistentSettings settings;
        private IEnumerable<IChecker> checkers;

        public EmailNotificationManager(IComputer computer, ISensorTextManager sensorTextManager, PersistentSettings settings, IEnumerable<IChecker> checkers)
        {
            this.computer = computer;
            this.sensorTextManager = sensorTextManager;
            this.settings = settings;
            this.checkers = checkers;
        }

        public static Identifier EmailIdentifier
        {
            get
            {
                return new Identifier("notification","email");
            }
        }                  

        public bool SendReport()
        {
            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {

                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential("opernhardwareemailnotifier@gmail.com", ConfigurationSettings.AppSettings.Get("EmailPassword"));
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                mail.From = new MailAddress("opernhardwareemailnotifier@gmail.com");
                mail.To.Add(new MailAddress(settings.GetValue(EmailIdentifier.ToString(),"")));
                mail.Body = this.PrepareNotificationReport();
                mail.Subject = this.GetSubject();

                try
                {
                  smtpClient.Send(mail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error during sending email notification");
                }
            }

            return true;           
        }

        public bool ChechIfNotificationShouldBeSend()
        {
            if (!this.ValidateSettings()) return false;

            return this.checkers.ToList().Any(x => x.Check());            
        }

        private bool ValidateSettings()
        {
            if (String.IsNullOrWhiteSpace(ConfigurationSettings.AppSettings.Get("EmailPassword")) ||
                String.IsNullOrWhiteSpace(settings.GetValue(EmailIdentifier.ToString(), ""))) return false;

            return true;
        }

        private string GetSubject()
        {
            if (computer.Hardware.SelectMany(x => x.Sensors).Any(s => s.NotificationStatus == NotificationStatus.Error))
            {
                return "ERROR: Open hardware monitor email notification.";
            }

            return "OK: Open hardware monitor email notification.";
        }

        private string PrepareNotificationReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Environment.MachineName);
            sb.AppendLine(Environment.OSVersion.ToString());
            sb.AppendLine();

            foreach (var hardware in computer.Hardware.Where(x => x.HardwareType == HardwareType.CPU).ToList())
            {
                sb.Append(hardware.Name);
                sb.AppendFormat(" - CORE: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock)));
                sb.AppendFormat(" , Load: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load && x.DefaultName == "CPU Total")));
                sb.AppendFormat(" TEMP: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature)));

                sb.AppendLine();
            }

            sb.AppendLine();

            foreach (var hardware in computer.Hardware.Where(x => x.HardwareType == HardwareType.GpuNvidia || x.HardwareType == HardwareType.GpuAti).ToList())
            {
                sb.Append(hardware.Name);
                sb.AppendFormat(" - CORE: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock && x.DefaultName == "GPU Core")));
                sb.AppendFormat(" , Load: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load && x.DefaultName == "GPU Core")));
                sb.AppendFormat(" TEMP: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature)));
                sb.AppendFormat(" , FAN: {0} ({1})",
                    sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Control)),
                    sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Fan)));

                sb.AppendFormat(" MEMORY: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock && x.DefaultName == "GPU Memory")));

                sb.AppendLine();
            }

            sb.AppendLine();

            foreach (var hardware in computer.Hardware.Where(x => x.HardwareType == HardwareType.RAM).ToList())
            {
                sb.Append(hardware.Name);               
                sb.AppendFormat(" - USED: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Data && x.DefaultName == "Used Memory")));
                sb.AppendFormat(" AVAILABLE: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Data && x.DefaultName == "Available Memory")));
                sb.AppendFormat(" LOAD: {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load)));
            }

            return sb.ToString();
        }       
      
    }
}
