using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;

using UWP_UAapp.Models;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(UWP_UAapp.Services.MockDataStore))]
namespace UWP_UAapp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            MessagingCenter.Subscribe<App, List<Item>>(this, "LoadItems", async (obj, item) =>
            {
                items = item as List<Item>;
                MessagingCenter.Send(this, "Refresh");
                await Task.CompletedTask;
            });
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);
            await SaveToFile();
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);
            await SaveToFile();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);
            await SaveToFile();
            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task SaveToFile()
        {
            IFolder root = FileSystem.Current.LocalStorage;
            IFolder folder = await root.CreateFolderAsync("UAappStorage", CreationCollisionOption.OpenIfExists);
            string fileName = "places.txt";
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            List<Item> wizytowki = new List<Item>();
            file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string json = JsonConvert.SerializeObject(items);
            await file.WriteAllTextAsync(json);
        }
    }
}