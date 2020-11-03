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
                    ImageSource = "x_27_512.png",
                    Command  = new Command(NavigateToTimer)
                },
                new MenuItem
                {
                    Text = "Calculator",
                    ImageSource = "Stopwatch_512.png",
                    Command  = new Command(NavigateToCalculator)
                },
            };
        }

        public List<MenuItem> MenuItems { get; }

        private void NavigateToTimer()
        {
            NavigateTo(new TimerView());    
        }

        private void NavigateToCalculator()
        {
            NavigateTo(new CalculatorView());
        }

        private void NavigateTo(Page page)
        {
            var detailPage = Application.Current.MainPage as MasterDetailPage;
            if (detailPage != null)
            {
                detailPage.Detail = new NavigationPage(page);
                detailPage.IsPresented = false;
            }
        }
    }
}

