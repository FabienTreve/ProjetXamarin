using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LeBonAngle.Models;
using LeBonAngle.ViewModels;

namespace LeBonAngle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        ProductDetailPageViewModel viewmodel;
        public ProductDetailPage(Product item)
        {
            InitializeComponent();
            BindingContext = viewmodel = new ProductDetailPageViewModel(Navigation, item);
        }
    }
}