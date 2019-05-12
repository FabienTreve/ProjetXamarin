using LeBonAngle.Models;
using LeBonAngle.Ressources;
using LeBonAngle.Services;
using LeBonAngle.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeBonAngle.ViewModels
{
    public class MDPageViewModel : BaseViewModel
    {
        public MDPageViewModel(INavigation Navigation) : base(Navigation)
        {
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.AnnounceList, Title=MyAppRessources.ItemMenu1, Icon="IconMenu1", IsEnable=true},
                new HomeMenuItem {Id = MenuItemType.AnnounceDeposit, Title=MyAppRessources.ItemMenu2, Icon="IconMenu2", IsEnable=true },
                new HomeMenuItem {Id = MenuItemType.Messages, Title=MyAppRessources.ItemMenu3, Icon="IconMenu3", IsEnable=true}
            };
            LogoutCommand = new Command(ExecuteLogoutCommand);
            if (Settings.IsUserConnected)
            {
                Task.Factory.StartNew(async () =>
                {
                    BonAngleWebServices client = new BonAngleWebServices();
                    var user = await client.APIV2_GetMyAccount();
                    UserName = user.Email;
                    Settings.UserID = user.Id;
                    //Fake, no image in the API
                    UserImage = ImageSource.FromUri(new Uri("http://www.sefairepayer.com/images/profils-debiteur/profil-irreductible.png"));

                });
            }
        }

        private List<HomeMenuItem> menuItems;
        public List<HomeMenuItem> MenuItems
        {
            get { return menuItems; }
            set { SetProperty(ref menuItems, value);}
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
