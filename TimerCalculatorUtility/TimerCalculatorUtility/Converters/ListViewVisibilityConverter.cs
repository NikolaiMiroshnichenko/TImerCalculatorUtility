﻿using System;
using System.Globalization;
using TimerCalculatorUtility.Enums;
using Xamarin.Forms;

namespace TimerCalculatorUtility.Converters
{
    public class ListViewVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (StopwatchStatus)value;
            if (status == StopwatchStatus.OnStart)
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
