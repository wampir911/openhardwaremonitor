using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    public class CPULoadChecker : CheckerBase, IChecker
    {
        private PersistentSettings settings;
        private IComputer computer;

        public CPULoadChecker(PersistentSettings settings, IComputer computer)
        {
            this.settings = settings;
            this.computer = computer;
        }

        public static Identifier ThresholdIdentifier
        {
            get
            {
                return new Identifier("notification", "CpuLoadThreshold");
            }
        }

        public static Identifier GraterLessSignIdentifier
        {
            get
            {
                return new Identifier("notification", "graterLessSignCPULoad");
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
                ISensor cpuLoadSensor = hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load && x.DefaultName == "CPU Total");
                if (cpuLoadSensor != null)
                {
                    var graterLessSignCPULoad = settings.GetValue(GraterLessSignIdentifier.ToString(), 0);
                    var cpuLoadThreshold = settings.GetValue(ThresholdIdentifier.ToString(), -1);

                    if (base.CheckValue(cpuLoadSensor, graterLessSignCPULoad, cpuLoadThreshold))
                    {
                        return true;
                    }
                }
            }

            return false;
        }       
    }
}
