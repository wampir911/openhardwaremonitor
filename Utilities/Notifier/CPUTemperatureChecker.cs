using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    class CPUTemperatureChecker : CheckerBase, IChecker
    {
        private PersistentSettings settings;
        private IComputer computer;

        public CPUTemperatureChecker(PersistentSettings settings, IComputer computer)
        {
            this.settings = settings;
            this.computer = computer;
        }

        public static Identifier ThresholdIdentifier
        {
            get
            {
                return new Identifier("notification", "CpuTemperatureThreshold");
            }
        }

        public static Identifier GraterLessSignIdentifier
        {
            get
            {
                return new Identifier("notification", "graterLessSignCPUTemperature");
            }
        }

        /// <summary>
        /// Checks notification conditions for all of GPU hardware.
        /// </summary>
        /// <returns>true if condition is positive for one of the gpu.</returns>
        public bool Check()
        {
            foreach (var hardware in computer.Hardware.Where(x => x.HardwareType == HardwareType.CPU).ToList())
            {
                ISensor cpuTemperatureSensor = hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature);
                if (cpuTemperatureSensor != null)
                {
                    var graterLessSignCPUTemperature = settings.GetValue(GraterLessSignIdentifier.ToString(), 0);
                    var cpuTemperatureThreshold = settings.GetValue(ThresholdIdentifier.ToString(), -1);

                    if (base.CheckValue(cpuTemperatureSensor.Value, graterLessSignCPUTemperature, cpuTemperatureThreshold))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    } 
}
