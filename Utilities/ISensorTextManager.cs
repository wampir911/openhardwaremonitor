using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenHardwareMonitor.Utilities
{
    public interface ISensorTextManager
    {
        /// <summary>
        /// Gets the sensor value and returns like user frendly string.
        /// </summary>
        /// <param name="sensor">The sensor.</param>
        /// <returns>User freadly string with unit of measure.</returns>
        string ValueToString(ISensor sensor);

        string ValueToString(ISensor sensor, float? value);
    }
}
