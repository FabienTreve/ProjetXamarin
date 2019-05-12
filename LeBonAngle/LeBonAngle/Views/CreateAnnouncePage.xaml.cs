using LeBonAngle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeBonAngle.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateAnnouncePage : ContentPage
	{
        CreateAnnouncePageViewModel viewmodel;
        public CreateAnnouncePage ()
		{
			InitializeComponent ();
            BindingContext = viewmodel = new CreateAnnouncePageViewModel(Navigation);
        }
	}
}