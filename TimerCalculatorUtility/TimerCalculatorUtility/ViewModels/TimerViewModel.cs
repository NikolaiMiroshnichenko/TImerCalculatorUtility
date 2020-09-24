using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using TimerCalculatorUtility.Models;
using Xamarin.Forms;

namespace TimerCalculatorUtility.ViewModels
{
    public enum StopwatchStatus
    {
        Onstart,
        Processing,
        Stopped
    }
    public class TimerViewModel : INotifyPropertyChanged
    {
        private int _lapCount;
        private Stopwatch _stopwatch = new Stopwatch();
        private TimeSpan _overallTime = new TimeSpan(0, 00, 00);

        public TimerViewModel()
        {
            Status = StopwatchStatus.Onstart;
            StopCommand = new Command(Stop);
            LapCommand = new Command(StartLap);
            ResetCommand = new Command(Reset);
            ResumeCommand = new Command(ResumeLap);
            StartCommand = new Command(StartMain);
        }

        public TimeSpan Time { get; set; } = new TimeSpan(0, 00, 00);
        public string TimeString { get; set; }
        public string Text { get; set; }
        public ObservableCollection<TimerItem> Times { get; set; } = new ObservableCollection<TimerItem>();
        public Command StopCommand { get; set; }
        public Command LapCommand { get; set; }
        public Command ResetCommand { get; set; }
        public Command ResumeCommand { get; set; }
        public Command StartCommand { get; set; }
        public StopwatchStatus Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void StartMain()
        {
            Status = StopwatchStatus.Processing;
            _stopwatch.Start();
            
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                
                TimeString = string.Format("{0:00}:{0:00}:{0:00}", _stopwatch.Elapsed.Minutes, _stopwatch.Elapsed.Seconds,
                   _stopwatch.Elapsed.Milliseconds);

                if (!_stopwatch.IsRunning)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            );
        }

        private void ResumeLap()
        {
            Status = StopwatchStatus.Processing;
        }

        private void Reset()
        {
            Status = StopwatchStatus.Onstart;
            _stopwatch.Reset();
            Times.Clear();
        }

        private void Stop()
        {
            Status = StopwatchStatus.Stopped;
            _stopwatch.Stop();
            _lapCount++;
            Time = _stopwatch.Elapsed;
            _overallTime = _overallTime.Add(_stopwatch.Elapsed);            
        }

        private void StartLap()
        {
            _lapCount++;
            Time = _stopwatch.Elapsed;
            _overallTime = _overallTime.Add(_stopwatch.Elapsed);
            Times.Add(new TimerItem
            {
                LapNumber = _lapCount,
                LapTime = _stopwatch.Elapsed,
                OverallTime = _overallTime
            });
            _stopwatch.Reset();
            _stopwatch.Start();
        }
    }
}
