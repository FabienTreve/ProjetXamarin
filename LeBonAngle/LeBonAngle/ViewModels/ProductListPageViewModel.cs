﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ListingOgGang.Models;
using ListingOgGang.Views;
using ListingOgGang.Ressources;
using ListingOgGang.Utils;
using ListingOgGang.Services;
using System.Threading;

namespace ListingOgGang.ViewModels
{
    public class ProductListPageViewModel : BaseViewModel
    {
        public ProductListPageViewModel(INavigation Navigation) : base(Navigation)
        {
            Title = MyAppRessources.Title_AnnouncesPage;
            Items = new ObservableCollection<Post>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command(async () => await ExecuteAddItemCommand());
            //Au démarrage, on charge les items
            LoadItemsCommand.Execute(null);
        }
        public ObservableCollection<Post> Items { get; set; }

        public Command LoadItemsCommand { get; set; }
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await ProductDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Command AddItemCommand { get; set; }
        private async Task ExecuteAddItemCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await NavigationService.PushAsync(new CreateAnnouncePage(), true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}