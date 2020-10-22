using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace TimerCalculatorUtility.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private StringBuilder _readedString = new StringBuilder();

        public CalculatorViewModel()
        {
            InputSymbolCommand = new Command<string>(AddSymbolToString);
            ResultCommand = new Command(Resulting);
            ClearCommand = new Command(Clear);
        }

        public string InputString { get; set; }
        public string ResultString { get; set; }
        public Command<string> InputSymbolCommand { get; set; }
        public Command ClearCommand { get; set; }
        public Command ResultCommand { get; set; }
        public Command DleleteLastSymbolCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void AddSymbolToString(string symbol)
        {
            InputString = _readedString.Append(symbol).ToString();
            WriteInResultString(symbol);
        }

        private void WriteInResultString(string symbol)
        {
            if ((symbol == "-") || (symbol == "+") || (symbol == "*") || (symbol == "/"))
                return;
            ResultString = Convert.ToDouble(new DataTable().Compute(InputString, null)).ToString();
        }

        private void Resulting()
        {
            _readedString.Clear();
            _readedString.Append(ResultString);
            InputString = ResultString;
        }

        private void Clear()
        {
            InputString = string.Empty;
            ResultString = string.Empty;
            _readedString.Clear();
        }
    }
}
