using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TimerCalculatorUtility.ViewModels
{
    public class CalculatorViewModel
    {
        private int _action;
        public string InjectedString { get; set; }
        public int Result { get; set; }
        public Command DeleteLastSymbolCommandd { get; set; }
        public Command ClearCommand { get; set; }
        public Command DivisionCommand { get; set; }
        public Command MultiplicationCommand { get; set; }
        public Command SumCommand { get; set; }
        public Command SubstractCommand { get; set; }
        public Command ResultCommand { get; set; }
        
    }
}
