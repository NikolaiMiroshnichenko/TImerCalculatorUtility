using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using TimerCalculatorUtility.ViewModels.Base;
using Xamarin.Forms;

namespace TimerCalculatorUtility.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        private StringBuilder _stringBuilder = new StringBuilder();

        public CalculatorViewModel()
        {
            InputSymbolCommand = new Command<string>(AddSymbolToString);
            ResultCommand = new Command(Resulting);
            ClearCommand = new Command(Clear);
            DeleteLastSymbolCommand = new Command(DeleteLastSymbol);
            PrecentCommand = new Command(CalculateProcent);
        }

        public string InputString { get; set; }
        public string ResultString { get; set; }
        public Command<string> InputSymbolCommand { get; }
        public Command ClearCommand { get; }
        public Command ResultCommand { get; }
        public Command DeleteLastSymbolCommand { get; }
        public Command PrecentCommand { get; }
        public Command CangePoliarityCommand { get; }

        private void AddSymbolToString(string symbol)
        {
            InputString = _stringBuilder.Append(symbol).ToString();
            WriteInResultString(symbol);
        }

        private void CalculatePercent()
        {
            InputString = _stringBuilder.Append("/100").ToString();
            ResultString = Convert.ToDouble(new DataTable().Compute(InputString, null)).ToString();
        }

        private void WriteInResultString(string symbol)
        {
            if ((symbol == "-") || (symbol == "+") || (symbol == "*") || (symbol == "/"))
                return;

            ResultString = Convert.ToDouble(new DataTable().Compute(InputString, null)).ToString();
        }

        private void Resulting()
        {
            _stringBuilder.Clear();
            _stringBuilder.Append(ResultString);
            InputString = ResultString;
        }

        private void DeleteLastSymbol()
        {
            if (ResultString.Length == 1)
                return;

            InputString = InputString.Remove(InputString.Length - 1);
            ResultString = ResultString.Remove(ResultString.Length - 1);
            _stringBuilder = _stringBuilder.Remove(_stringBuilder.Length - 1, 1);
        }

        private void Clear()
        {
            InputString = string.Empty;
            ResultString = string.Empty;
            _stringBuilder.Clear();
        }
    }
}
