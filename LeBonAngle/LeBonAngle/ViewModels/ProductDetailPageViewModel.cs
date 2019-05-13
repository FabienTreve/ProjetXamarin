using System;

using ListingOgGang.Models;
using Xamarin.Forms;

namespace ListingOgGang.ViewModels
{
    public class ProductDetailPageViewModel : BaseViewModel
    {
        public Post Item { get; set; }
        public ProductDetailPageViewModel(INavigation Navigation, Post item) : base(Navigation)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
