using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTemplate
{
    public class WorkedPerformedEventArgs : EventArgs
    {
        public WorkedPerformedEventArgs(int hours)
        {
            Hours = hours;
        }
        public int Hours { get; set; }
    }
}
