using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenHardwareMonitor.GUI
{
    public class NotificationManager
    {
        public Identifier EmailIdentifier
        {
            get
            {
                return new Identifier("notification","email");
            }
        }
    }
}
