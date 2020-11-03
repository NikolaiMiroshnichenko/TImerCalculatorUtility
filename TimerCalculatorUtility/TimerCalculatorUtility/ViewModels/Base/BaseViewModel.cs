using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TimerCalculatorUtility.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
