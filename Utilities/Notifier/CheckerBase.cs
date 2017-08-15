using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    public abstract class CheckerBase
    {
        protected bool CheckValue(float? value, int grateLessSign, float threshold)
        {
            switch (grateLessSign)
            {
                case 0: return false;
                case 1: return (threshold == -1) ? false : this.CheckGraterThan(value, threshold);
                case 2: return (threshold == -1) ? false : this.CheckLessThan(value, threshold);
            }

            return false;
        }

        private bool CheckGraterThan(float? sensorValue, float thresholdValue)
        {
            return (sensorValue == null) ? false : sensorValue > thresholdValue;
        }

        private bool CheckLessThan(float? sensorValue, float thresholdValue)
        {
            return (sensorValue == null) ? false : sensorValue < thresholdValue;
        }
    }
}
