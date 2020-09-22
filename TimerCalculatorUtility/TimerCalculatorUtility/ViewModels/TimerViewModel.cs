using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TimerCalculatorUtility.Models;
using Xamarin.Forms;

namespace TimerCalculatorUtility.ViewModels
{
    public class TimerViewModel
    {
        private int _lapCount;
        private Stopwatch _stopwatch = new Stopwatch();
        private TimeSpan _overallTime = new TimeSpan(0, 00, 00);

        public TimerViewModel()
        {
            StopCommand = new Command(StopLap);
            LapCommand = new Command(StartLap);
        }

        public TimeSpan Time { get; set; } = new TimeSpan(0, 00, 00);
        public string Text { get; set; }
        public ObservableCollection<TimerItem> Times { get; set; } = new ObservableCollection<TimerItem>();
        public Command StopCommand { get; set; }
        public Command LapCommand { get; set; }

        public void StopLap()
        {
            _stopwatch.Stop();
            _lapCount++;
            _overallTime =  _overallTime.Add(_stopwatch.Elapsed);
            Times.Add(new TimerItem
            {
                LapNumber = _lapCount,
                LapTime = _stopwatch.Elapsed,
                OverallTime = _overallTime
            }) ;
           
        }
        public void StartLap()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }
    }
}
