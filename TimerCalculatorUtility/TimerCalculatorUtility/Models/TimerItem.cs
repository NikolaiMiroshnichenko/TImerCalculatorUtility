using System;
using System.Collections.Generic;
using System.Text;

namespace TimerCalculatorUtility.Models
{
    public class TimerItem
    {
        public int LapNumber { get; set; }
        public TimeSpan LapTime { get; set; }
        public TimeSpan OverallTime { get; set; }
    }
}
