using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TimerCalculatorUtility.ViewModels;

namespace TimerCalculatorUtility.Converters
{
    public class ResumetButtonVisibiliryConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (StopwatchStatus)value;
            if (status == StopwatchStatus.Stopped)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
