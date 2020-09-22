using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using TimerCalculatorUtility.Models;
using TimerCalculatorUtility.Views;
using Xamarin.Forms;
using MenuItem = TimerCalculatorUtility.Models.MenuItem;

namespace TimerCalculatorUtility.ViewModels
{
    public class MenuPageViewModel
    {
        public MenuPageViewModel()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Text = "To Timer page",
                    Command  = new Command(NavigateToTimer)
                },
                new MenuItem
                {
                    Text = "To Calculator page",
                    Command  = new Command(NavigateToCalculator)
                },
            };
        }

        public List<MenuItem> MenuItems { get; set; }

        public Command ToTimerCommand { get; set; }
        public Command ToCalculatorCommand { get; set; }
        private void NavigateToTimer()
        {
            App.Navigation.PushAsync(new NavigationPage(new TimerView()));
        }
        private void NavigateToCalculator()
        {
            App.Navigation.PushAsync(new NavigationPage(new CalculatorView()));
        }
    }
}

