using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenHardwareMonitor.Utilities
{
    public class EmailNotificationManager
    {
        private IComputer computer;
        private ISensorTextManager sensorTextManager;

        public EmailNotificationManager(IComputer computer, ISensorTextManager sensorTextManager)
        {
            this.computer = computer;
            this.sensorTextManager = sensorTextManager;
        }

        public static Identifier EmailIdentifier
        {
            get
            {
                return new Identifier("notification","email");
            }
        }

        public static Identifier GPULoadThresholdIdentifier
        {
            get
            {
                return new Identifier("notification", "GpuLoadThreshold");
            }
        }

        public static Identifier GPUTemperatureThresholdIdentifier
        {
            get
            {
                return new Identifier("notification", "GpuTemperatureThreshold");
            }
        }

        public static Identifier GraterLessSignGPULoadIdentifier
        {
            get
            {
                return new Identifier("notification", "graterLessSignGPULoad");
            }
        }

        public static Identifier GraterLessSignGPUTemperatureThresholdIdentifier
        {
            get
            {
                return new Identifier("notification", "graterLessSignGPUTemperature");
            }
        }

        private void Notify()
        {
            StringBuilder sb = new StringBuilder();
            var GPUHardwares = computer.Hardware.ToList().Where(x => x.HardwareType == HardwareType.GpuNvidia || x.HardwareType == HardwareType.GpuAti);

            foreach (var GPUHardware in GPUHardwares)
            {
                sb.Append(GPUHardware.Name);
                sb.AppendFormat(" - CORE : {0}", sensorTextManager.ValueToString(GPUHardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock && x.DefaultName == "GPU Core")));
                sb.AppendFormat(" , Load : {0}", sensorTextManager.ValueToString(GPUHardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load && x.DefaultName == "GPU Core")));
                sb.AppendFormat(" TEMP : {0}", sensorTextManager.ValueToString(GPUHardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature)));
                sb.AppendFormat(" , FAN : {0} ({1})",
                    sensorTextManager.ValueToString(GPUHardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Control)),
                    sensorTextManager.ValueToString(GPUHardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Fan)));

                sb.AppendFormat(" MEMORY : {0}", sensorTextManager.ValueToString(GPUHardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock && x.DefaultName == "GPU Memory")));

                sb.AppendLine();
            }

            var s = sb.ToString();
        }
    }
}
