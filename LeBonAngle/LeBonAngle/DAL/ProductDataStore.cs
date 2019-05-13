using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListingOgGang.DAL;
using ListingOgGang.Interfaces;
using ListingOgGang.Models;
using ListingOgGang.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProductDataStore))]
namespace ListingOgGang.DAL
{
    public class ProductDataStore : IDataStore<Post>
    {

        public ProductDataStore()
        {

        }

        public async Task<bool> AddItemAsync(Post item)
        {
            //Need API
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Post item)
        {
            //Need API !!!

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //Need API !!!

            return await Task.FromResult(true);
        }

        public async Task<Post> GetItemAsync(string id)
        {
            ListingWebServices WSclient = new ListingWebServices();
            return await WSclient.APIV2_GetAnnounce(id);
        }

        public async Task<List<Post>> GetItemsAsync(bool forceRefresh = false)
        {
            ListingWebServices WSclient = new ListingWebServices();
            return await WSclient.APIV2_GetAnnounces();
        }
    }
}