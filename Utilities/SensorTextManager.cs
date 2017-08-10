using OpenHardwareMonitor.GUI;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenHardwareMonitor.Utilities
{
    public class SensorTextManager : ISensorTextManager
    {
        private UnitManager unitManager;

        public SensorTextManager(UnitManager unitManager)
        {
            this.unitManager = unitManager;
        }

        /// <summary>
        /// Gets the sensor value and returns like user frendly string.
        /// </summary>
        /// <param name="sensor">The sensor.</param>
        /// <returns>User freadly string with unit of measure.</returns>
        public string ValueToString(ISensor sensor)
        {
            if (sensor != null)
            {
                return this.ValueToString(sensor, sensor.Value);
            }

            return string.Empty;
        }

        public string ValueToString(ISensor sensor, float? value)
        {
            if (value.HasValue)
            {
                return string.Format(GetFormat(sensor), value);
            }
            else
                return "-";
        }

        private string GetFormat(ISensor sensor)
        {
            string format = string.Empty;

            switch (sensor.SensorType)
            {
                case SensorType.Voltage: format = "{0:F3} V"; break;
                case SensorType.Clock: format = "{0:F0} MHz"; break;
                case SensorType.Load: format = "{0:F1} %"; break;
                case SensorType.Temperature:
                    {
                        if (unitManager.TemperatureUnit == TemperatureUnit.Fahrenheit)
                        {
                            format = "{0:F1} °F"; break;
                        }
                        else
                        {
                            format = "{0:F1} °C"; break;
                        }
                    }
                case SensorType.Fan: format = "{0:F0} RPM"; break;
                case SensorType.Flow: format = "{0:F0} L/h"; break;
                case SensorType.Control: format = "{0:F1} %"; break;
                case SensorType.Level: format = "{0:F1} %"; break;
                case SensorType.Power: format = "{0:F1} W"; break;
                case SensorType.Data: format = "{0:F1} GB"; break;
                case SensorType.SmallData: format = "{0:F1} MB"; break;
                case SensorType.Factor: format = "{0:F3}"; break;
            }

            return format;
        }
    }
}
