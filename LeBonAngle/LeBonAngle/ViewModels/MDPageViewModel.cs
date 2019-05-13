using ListingOgGang.Models;
using ListingOgGang.Ressources;
using ListingOgGang.Services;
using ListingOgGang.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListingOgGang.ViewModels
{
    public class MDPageViewModel : BaseViewModel
    {
        public MDPageViewModel(INavigation Navigation) : base(Navigation)
        {
           LogoutCommand = new Command(ExecuteLogoutCommand);
            if (Settings.IsUserConnected)
            {
                Task.Factory.StartNew(async () =>
                {
                    ListingWebServices client = new ListingWebServices();
                    var user = await client.APIV2_GetMyAccount();
                    Settings.UserID = user.Id;
                    //Fake, no image in the API
                    UserImage = ImageSource.FromUri(new Uri("http://www.sefairepayer.com/images/profils-debiteur/profil-irreductible.png"));

                });
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }

        
        private ImageSource userImage;
        public ImageSource UserImage
        {
            get { return userImage; }
            set { SetProperty(ref userImage, value); }
        }


        #region LogoutCommand
        
        public Command LogoutCommand { get; set; }

        private void ExecuteLogoutCommand()
        {
            Settings.Login = String.Empty;
            Settings.Pwd = String.Empty;
            Settings.TokenAPI = String.Empty;
            ((BonApp)Application.Current).DisplayLogin();
        }

        #endregion

    }
}
