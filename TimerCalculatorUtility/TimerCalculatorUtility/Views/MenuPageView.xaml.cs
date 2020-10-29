using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimerCalculatorUtility.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageView : ContentPage
    {
        public MenuPageView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text == "Timer")
            {
                NavigateTo(new TimerView());
            }
            if (button.Text == "Calculator")
            {
                NavigateTo(new CalculatorView());
            }
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