using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TimerCalculatorUtility.Models
{
    public class MenuItem
    {
        public string Text { get; set; }
        public ICommand Command { get; set; }
    }
}
