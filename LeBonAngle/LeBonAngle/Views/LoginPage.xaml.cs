using ListingOgGang.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListingOgGang.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        LoginPageViewModel viewmodel;

        public LoginPage ()
		{
			InitializeComponent ();
            BindingContext = viewmodel = new LoginPageViewModel(Navigation);
        }
	}
}