using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TimerCalculatorUtility.Enums;
using TimerCalculatorUtility.ViewModels;
using Xamarin.Forms;

namespace TimerCalculatorUtility.Converters
{
    public class StopButtonVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (StopwatchStatus)value;
            if (status == StopwatchStatus.Processing)
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
