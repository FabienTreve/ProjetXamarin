using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LeBonAngle.Models;
using LeBonAngle.Views;
using LeBonAngle.ViewModels;

namespace LeBonAngle.Views
{
    public partial class ProductListPage : ContentPage
    {
        ProductListPageViewModel viewmodel;
        public ProductListPage()
        {
            InitializeComponent();

            BindingContext = viewmodel = new ProductListPageViewModel(Navigation);
        }

        private async void ItemsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                Product selected = ((Product)e.Item);
                await Navigation.PushAsync(new ProductDetailPage(selected));
            }
        }
    }
}