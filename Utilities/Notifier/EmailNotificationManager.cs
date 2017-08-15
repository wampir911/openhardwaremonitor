using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            // var GPUHardwares = computer.Hardware.ToList().Where(x => x.HardwareType == HardwareType.GpuNvidia || x.HardwareType == HardwareType.GpuAti).ToList();

            var notificationReport = this.PrepareNotificationReport();                

            return true;           
        }

        public bool ChechIfNotificationShouldBeSend()
        {
            return checkers.ToList().Any(x => x.Check());            
        }

        private string PrepareNotificationReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Environment.MachineName);
            sb.AppendLine(Environment.OSVersion.ToString());

            // zrobić aby odpowienie rzeczy były brane do raportu bo teraz wchodzi cały hardware a nie tylko GPU

            foreach (var hardware in computer.Hardware.ToList())
            {
                sb.Append(hardware.Name);
                sb.AppendFormat(" - CORE : {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock && x.DefaultName == "GPU Core")));
                sb.AppendFormat(" , Load : {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load && x.DefaultName == "GPU Core")));
                sb.AppendFormat(" TEMP : {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature)));
                sb.AppendFormat(" , FAN : {0} ({1})",
                    sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Control)),
                    sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Fan)));

                sb.AppendFormat(" MEMORY : {0}", sensorTextManager.ValueToString(hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock && x.DefaultName == "GPU Memory")));

                sb.AppendLine();
            }

            return sb.ToString();
        }       
      
    }
}
