using System;
using System.Collections.Generic;
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
                    Text = "Timer",
                    Command  = new Command(NavigateToTimer)
                },
                new MenuItem
                {
                    Text = "Calculator",
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
         //   NavigationPage.SetHasNavigationBar(timerView, false);
            App.Navigation.PushAsync(timerView);
           
        }
        private void NavigateToCalculator()
        {
            CalculatorView calculatorView = new CalculatorView();
          //  NavigationPage.SetHasNavigationBar(calculatorView, false);
            App.Navigation.PushAsync(calculatorView);
        }
    }
}

