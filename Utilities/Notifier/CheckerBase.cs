using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    public abstract class CheckerBase
    {
        protected bool CheckValue(ISensor sensor, int grateLessSign, float threshold)
        {
            if (sensor == null)
            {
                throw new ArgumentNullException(nameof(sensor));
            }

            bool checkedValue = false;          

            switch (grateLessSign)
            {
                case 0: break;
                case 1: checkedValue = (threshold == -1) ? false : this.CheckGraterThan(sensor.Value, threshold); break;
                case 2: checkedValue = (threshold == -1) ? false : this.CheckLessThan(sensor.Value, threshold); break;
            }

            // do not send the same notification over and over again.
            if (sensor.NotificationStatus == NotificationStatus.Error && checkedValue)
            {
                return false;
            }

            sensor.SetNotificationErrorStatus(checkedValue);

            if (sensor.NotificationStatus == NotificationStatus.Fixed)
            {
                return true;
            }

            return checkedValue;
        }

        private bool CheckGraterThan(float? sensorValue, float thresholdValue)
        {
            return (sensorValue != null) && sensorValue > thresholdValue;
        }

        private bool CheckLessThan(float? sensorValue, float thresholdValue)
        {
            return (sensorValue != null) && sensorValue < thresholdValue;
        }
    }
}
