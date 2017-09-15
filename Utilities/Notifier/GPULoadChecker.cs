using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    public class GPULoadChecker : CheckerBase, IChecker
    {
        private PersistentSettings settings;
        private IComputer computer;

        public GPULoadChecker(PersistentSettings settings, IComputer computer)
        {
            this.settings = settings;
            this.computer = computer;
        }

        public static Identifier ThresholdIdentifier
        {
            get
            {
                return new Identifier("notification", "GpuLoadThreshold");
            }
        }

        public static Identifier GraterLessSignIdentifier
        {
            get
            {
                return new Identifier("notification", "graterLessSignGPULoad");
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
                ISensor gpuLoadSensor = hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load && x.DefaultName == "GPU Core");
                if (gpuLoadSensor != null)
                {
                    var graterLessSignGPULoad = settings.GetValue(GraterLessSignIdentifier.ToString(), 0);
                    var gpuLoadThreshold = settings.GetValue(ThresholdIdentifier.ToString(), -1);

                    if (base.CheckValue(gpuLoadSensor, graterLessSignGPULoad, gpuLoadThreshold))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
