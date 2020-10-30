using System.Windows.Input;

namespace TimerCalculatorUtility.Models
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string ImageSource { get; set; }
        public ICommand Command { get; set; }
    }
}
