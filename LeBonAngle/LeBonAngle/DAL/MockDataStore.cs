using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListingOgGang.DAL;
using ListingOgGang.Interfaces;
using ListingOgGang.Models;
using Xamarin.Forms;

//[assembly: Dependency(typeof(MockDataStore))]
//namespace ListingOgGang.DAL
//{
//    public class MockDataStore : IDataStore<Product>
//    {
//        List<Product> items;

//        public MockDataStore()
//        {
//            items = new List<Product>()
//            {
//                new Product { Id = 0, Title = "Title1", Description="This is an item description.", Price=10.5 },
//                new Product { Id = 1, Title = "Title2", Description="This is an item description.", Price=10.5 },
//                new Product { Id = 2, Title = "Title3", Description="This is an item description.", Price=10.5 },
//                new Product { Id = 3, Title = "Title4", Description="This is an item description.", Price=10.5 },
//                new Product { Id = 4, Title = "Title5", Description="This is an item description.", Price=10.5 },
//                new Product { Id = 5, Title = "Title6", Description="This is an item description.", Price=10.5 },
//            };
//        }

//        public async Task<bool> AddItemAsync(Product item)
//        {
//            items.Add(item);

//            return await Task.FromResult(true);
//        }

//        public async Task<bool> UpdateItemAsync(Product item)
//        {
//            var oldItem = items.Where((Product arg) => arg.Id == item.Id).FirstOrDefault();
//            items.Remove(oldItem);
//            items.Add(item);

//            return await Task.FromResult(true);
//        }

//        public async Task<bool> DeleteItemAsync(string id)
//        {
//            var oldItem = items.Where((Product arg) => arg.Id.ToString() == id).FirstOrDefault();
//            items.Remove(oldItem);

//            return await Task.FromResult(true);
//        }

//        public async Task<Product> GetItemAsync(string id)
//        {
//            return await Task.FromResult(items.FirstOrDefault(s => s.Id.ToString() == id));
//        }

//        public async Task<List<Product>> GetItemsAsync(bool forceRefresh = false)
//        {
//            return await Task.FromResult(items);
//        }
//    }
//}