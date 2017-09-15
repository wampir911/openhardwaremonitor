using OpenHardwareMonitor.Hardware;
using System.Linq;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    public class MemoryUsageChecker : CheckerBase, IChecker
    {
        private PersistentSettings settings;
        private IComputer computer;

        public MemoryUsageChecker(PersistentSettings settings, IComputer computer)
        {
            this.settings = settings;
            this.computer = computer;
        }

        public static Identifier ThresholdIdentifier
        {
            get
            {
                return new Identifier("notification", "MemoryUsageThreshold");
            }
        }

        public static Identifier GraterLessSignIdentifier
        {
            get
            {
                return new Identifier("notification", "graterLessSignMemoryUsage");
            }
        }

        /// <summary>
        /// Checks notification conditions for all of GPU hardware.
        /// </summary>
        /// <returns>true if condition is positive for one of the gpu.</returns>
        public bool Check()
        {
            foreach (var hardware in computer.Hardware.Where(x => x.HardwareType == HardwareType.RAM).ToList())
            {
                ISensor memoryUsageSensor = hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Load);
                if (memoryUsageSensor != null)
                {
                    var graterLessSignMemoryUsage = settings.GetValue(GraterLessSignIdentifier.ToString(), 0);
                    var memoryUsageThreshold = settings.GetValue(ThresholdIdentifier.ToString(), -1);

                    if (base.CheckValue(memoryUsageSensor, graterLessSignMemoryUsage, memoryUsageThreshold))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
