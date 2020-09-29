using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
        private Stopwatch _stopwatchLap = new Stopwatch();
        private Stopwatch _stopwatchOverall = new Stopwatch();

        public TimerViewModel()
        {
            Status = StopwatchStatus.Onstart;
            StopCommand = new Command(Stop);
            LapCommand = new Command(StartLap);
            ResetCommand = new Command(Reset);
            ResumeCommand = new Command(ResumeLap);
            StartCommand = new Command(StartMain);
        }
        public string TimeString { get; set; } = "00:00.00";
        public string LapTimeString { get; set; } = "00:00.00";
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
            _stopwatchLap.Start();
            _stopwatchOverall.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {

                LapTimeString = string.Format("{0:00}:{1:00}.{2:00}", _stopwatchLap.Elapsed.Minutes, _stopwatchLap.Elapsed.Seconds,
                   _stopwatchLap.Elapsed.Milliseconds);
                TimeString = string.Format("{0:00}:{1:00}.{2:00}", _stopwatchOverall.Elapsed.Minutes, _stopwatchOverall.Elapsed.Seconds,
                   _stopwatchOverall.Elapsed.Milliseconds);
                if (!_stopwatchOverall.IsRunning)
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
            _stopwatchOverall.Start();
            _stopwatchLap.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                LapTimeString = string.Format("{0:00}:{1:00}.{2:00}", _stopwatchLap.Elapsed.Minutes, _stopwatchLap.Elapsed.Seconds,
                   _stopwatchLap.Elapsed.Milliseconds);
                TimeString = string.Format("{0:00}:{1:00}.{2:00}", _stopwatchOverall.Elapsed.Minutes, _stopwatchOverall.Elapsed.Seconds,
                   _stopwatchOverall.Elapsed.Milliseconds);

                if (!_stopwatchOverall.IsRunning)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });
        }

        private void Reset()
        {
            Status = StopwatchStatus.Onstart;
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

        private void StartLap()
        {
            _lapCount++;
            Times.Insert (0,
                new TimerItem
            {
                LapNumber = _lapCount,
                LapTime = _stopwatchLap.Elapsed,
                OverallTime = _stopwatchOverall.Elapsed
            });
            
            _stopwatchLap.Reset();
            _stopwatchLap.Start();
        }
    }
}
