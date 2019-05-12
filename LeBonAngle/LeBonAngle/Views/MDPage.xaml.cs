using LeBonAngle.Models;
using LeBonAngle.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeBonAngle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPage : MasterDetailPage
    {
        MDPageViewModel viewmodel;
        public MDPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new MDPageViewModel(Navigation);
        }

        private void ListViewMenu_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                HomeMenuItem selected = ((HomeMenuItem)e.Item);
                switch(selected.Id)
                {
                    case MenuItemType.AnnounceList:
                        Detail = new NavigationPage(new ProductListPage());
                        break;
                    case MenuItemType.AnnounceDeposit:
                        Detail = new NavigationPage(new CreateAnnouncePage());
                        break;
                    case MenuItemType.Messages:
                        Detail = new NavigationPage(new ProductListPage());
                        break;
                    
                }

                IsPresented = false;
            }
        }
    }
}