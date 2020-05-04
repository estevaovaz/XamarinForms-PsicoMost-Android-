using PsicoMost.Models;
using PsicoMost.Views;
using PsicoMost.Views.Home;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PsicoMost
{
    public partial class App : Application
    {
        string crp = null;
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PreLoginPage());
        }

        protected override void OnStart()
        {
            crp = Utils.Settings.CRP;

            if (crp == null || crp == "")
            {
                MainPage = new NavigationPage(new PreLoginPage());
            }
            else 
            {
                MainPage = new NavigationPage(new LoginPage());
            }

        }

        protected override void OnSleep()
        {
            crp = Utils.Settings.CRP;

            if (crp == null || crp == "")
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MenuPage());
            }

            
        }

        protected override void OnResume()
        {
            crp = Utils.Settings.CRP;

            if (crp == null || crp == "")
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MenuPage());
            }

        }
    }
}
