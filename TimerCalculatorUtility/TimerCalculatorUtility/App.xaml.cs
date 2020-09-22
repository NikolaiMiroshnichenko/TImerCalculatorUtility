﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimerCalculatorUtility
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage());
            Navigation = MainPage.Navigation;
        }
        public static INavigation Navigation { get; private set; }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}