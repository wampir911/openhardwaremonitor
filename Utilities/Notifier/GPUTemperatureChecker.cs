using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    class GPUTemperatureChecker : CheckerBase, IChecker
    {
        private PersistentSettings settings;
        private IComputer computer;

        public GPUTemperatureChecker(PersistentSettings settings, IComputer computer)
        {
            this.settings = settings;
            this.computer = computer;
        }

        public static Identifier ThresholdIdentifier
        {
            get
            {
                return new Identifier("notification", "GpuTemperatureThreshold");
            }
        }

        public static Identifier GraterLessSignIdentifier
        {
            get
            {
                return new Identifier("notification", "graterLessSignGPUTemperature");
            }
        }

        /// <summary>
        /// Checks notification conditions for all of GPU hardware.
        /// </summary>
        /// <returns>true if condition is positive for one of the gpu.</returns>
        public bool Check()
        {
            foreach (var hardware in computer.Hardware.Where(x => x.HardwareType == HardwareType.GpuNvidia || x.HardwareType == HardwareType.GpuAti).ToList())
            {
                ISensor gpuTemperatureSensor = hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature);
                if (gpuTemperatureSensor != null)
                {
                    var graterLessSignGPUTemperature = settings.GetValue(GraterLessSignIdentifier.ToString(), 0);
                    var gpuTemperatureThreshold = settings.GetValue(ThresholdIdentifier.ToString(), -1);

                    if (base.CheckValue(gpuTemperatureSensor.Value, graterLessSignGPUTemperature, gpuTemperatureThreshold))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    } 
}
