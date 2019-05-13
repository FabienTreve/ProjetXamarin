using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ListingOgGang.Models;
using ListingOgGang.ViewModels;

namespace ListingOgGang.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        ProductDetailPageViewModel viewmodel;
        public ProductDetailPage(Post item)
        {
            InitializeComponent();
            BindingContext = viewmodel = new ProductDetailPageViewModel(Navigation, item);
        }
    }
}