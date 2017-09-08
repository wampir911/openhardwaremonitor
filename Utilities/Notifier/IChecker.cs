using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenHardwareMonitor.Utilities.Notifier
{
    public interface IChecker
    {        
        bool Check();
    }
}
