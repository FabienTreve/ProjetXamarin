using System;

using LeBonAngle.Models;
using Xamarin.Forms;

namespace LeBonAngle.ViewModels
{
    public class ProductDetailPageViewModel : BaseViewModel
    {
        public Product Item { get; set; }
        public ProductDetailPageViewModel(INavigation Navigation, Product item) : base(Navigation)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
