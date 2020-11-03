using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using TimerCalculatorUtility.Enums;
using TimerCalculatorUtility.Models;
using TimerCalculatorUtility.ViewModels.Base;
using Xamarin.Forms;

namespace TimerCalculatorUtility.ViewModels
{
    public class TimerViewModel : BaseViewModel
    {
        private int _lapCount;
        private readonly Stopwatch _stopwatchLap = new Stopwatch();
        private readonly Stopwatch _stopwatchOverall = new Stopwatch();

        public TimerViewModel()
        {
            Status = StopwatchStatus.OnStart;
            StopCommand = new Command(Stop);
            LapCommand = new Command(StartLap);
            ResetCommand = new Command(Reset);
            ResumeCommand = new Command(StartTimeRunning);
            StartCommand = new Command(StartTimeRunning);
        }
        public string TimeString { get; set; } = "00:00.00";
        public string LapTimeString { get; set; } = "00:00.00";
        public string Text { get; set; }
        public ObservableCollection<TimerItem> Times { get; set; } = new ObservableCollection<TimerItem>();
        public Command StopCommand { get; }
        public Command LapCommand { get; }
        public Command ResetCommand { get; }
        public Command ResumeCommand { get; }
        public Command StartCommand { get; }
        public StopwatchStatus Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void StartTimeRunning()
        {
            Status = StopwatchStatus.Processing;
            _stopwatchLap.Start();
            _stopwatchOverall.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                LapTimeString = string.Format("{0:00}:{1:00}.{2:00}", _stopwatchLap.Elapsed.Minutes, _stopwatchLap.Elapsed.Seconds,
                   _stopwatchLap.Elapsed.Milliseconds);
                TimeString = string.Format("{0:00}:{1:00}.{2:00}", _stopwatchOverall.Elapsed.Minutes, _stopwatchOverall.Elapsed.Seconds,
                   _stopwatchOverall.Elapsed.Milliseconds);
                return (_stopwatchOverall.IsRunning);
            });
        }

        private void StartLap()
        {
            _lapCount++;
            Times.Insert(0,
                new TimerItem
                {
                    LapNumber = _lapCount,
                    LapTime = _stopwatchLap.Elapsed,
                    OverallTime = _stopwatchOverall.Elapsed
                });

            _stopwatchLap.Reset();
            _stopwatchLap.Start();
        }

        private void Reset()
        {
            Status = StopwatchStatus.OnStart;
            Times.Clear();
            _stopwatchLap.Reset();
            _stopwatchLap.Start();
            _stopwatchOverall.Reset();
            _stopwatchOverall.Start();
            TimeString = "00:00.00";
            LapTimeString = "00:00.00";
        }

        private void Stop()
        {
            Status = StopwatchStatus.Stopped;
            _stopwatchOverall.Stop();
            _stopwatchLap.Stop();
        }
    }
}
