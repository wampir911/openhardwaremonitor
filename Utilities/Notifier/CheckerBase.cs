using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    public abstract class CheckerBase
    {
        protected bool muteChecking;

        protected bool CheckValue(float? value, int grateLessSign, float threshold)
        {
            bool checkedValue = false;          

            switch (grateLessSign)
            {
                case 0: checkedValue = false; break;
                case 1: checkedValue = (threshold == -1) ? false : this.CheckGraterThan(value, threshold); break;
                case 2: checkedValue = (threshold == -1) ? false : this.CheckLessThan(value, threshold); break;
            }

            // do not send the same notification over and over again.
            if (muteChecking && checkedValue)
            {
                return false;
            }
            else
            {
                muteChecking = checkedValue;
                return checkedValue;
            }            
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
