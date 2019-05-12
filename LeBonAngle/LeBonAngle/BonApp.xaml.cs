using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LeBonAngle.Views;
using LeBonAngle.Interfaces;
using LeBonAngle.ViewModels;
using LeBonAngle.Services;
using LeBonAngle.Models;
using System.Threading.Tasks;
using LeBonAngle.Utils;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LeBonAngle
{
    public partial class BonApp : Application
    {

        public BonApp()
        {
            InitializeComponent();
            //DependencyService.Register<IDataStore<Announce>>();
            DependencyService.Register<IDataStore<Product>>();
            var currentSmartphoneLanguage = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            
            if (Settings.IsUserConnected)
            {
                DisplayHome();
            }
            else
            {
                DisplayLogin();
            }
        }

        public void DisplayLogin()
        {
            //Affectation Mainpage
            MainPage = new LoginPage();
        }

        public void DisplayHome()
        {
            //Affectation Mainpage
            MainPage = new MDPage();
        }

        
    }
}
