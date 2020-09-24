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
            TimerView timerView = new TimerView();
            NavigationPage.SetHasNavigationBar(timerView, false);
            App.Navigation.PushAsync(timerView);
           
        }
        private void NavigateToCalculator()
        {
            CalculatorView calculatorView = new CalculatorView();
            NavigationPage.SetHasNavigationBar(calculatorView, false);
            App.Navigation.PushAsync(calculatorView);
        }
    }
}

