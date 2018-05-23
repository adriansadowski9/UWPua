using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UWP_UAapp.Models;

[assembly: Xamarin.Forms.Dependency(typeof(UWP_UAapp.Services.MockDataStore))]
namespace UWP_UAapp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "Uniwersytet Gdański", Description="UG.", Street = "Jana Bażyńskiego", Zip_Code = "80-309", City = "Gdańsk", GMaps_Link = "https://www.google.com/maps/place/University+of+Gda%C5%84sk/@54.3961355,18.5721315,17z/data=!3m1!4b1!4m5!3m4!1s0x46fd752f76dddae7:0x4d4128c9a5066e47!8m2!3d54.3961355!4d18.5743203" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Uniwersytet Gdański2", Description="UG.", Street = "Jana Bażyńskiego", Zip_Code = "80-309", City = "Gdańsk", GMaps_Link = "https://www.google.com/maps/place/University+of+Gda%C5%84sk/@54.3961355,18.5721315,17z/data=!3m1!4b1!4m5!3m4!1s0x46fd752f76dddae7:0x4d4128c9a5066e47!8m2!3d54.3961355!4d18.5743203" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Uniwersytet Gdański3", Description="UG.", Street = "Jana Bażyńskiego", Zip_Code = "80-309", City = "Gdańsk", GMaps_Link = "https://www.google.com/maps/place/University+of+Gda%C5%84sk/@54.3961355,18.5721315,17z/data=!3m1!4b1!4m5!3m4!1s0x46fd752f76dddae7:0x4d4128c9a5066e47!8m2!3d54.3961355!4d18.5743203" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Uniwersytet Gdański4", Description="UG.", Street = "Jana Bażyńskiego", Zip_Code = "80-309", City = "Gdańsk", GMaps_Link = "https://www.google.com/maps/place/University+of+Gda%C5%84sk/@54.3961355,18.5721315,17z/data=!3m1!4b1!4m5!3m4!1s0x46fd752f76dddae7:0x4d4128c9a5066e47!8m2!3d54.3961355!4d18.5743203" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Uniwersytet Gdański5", Description="UG.", Street = "Jana Bażyńskiego", Zip_Code = "80-309", City = "Gdańsk", GMaps_Link = "https://www.google.com/maps/place/University+of+Gda%C5%84sk/@54.3961355,18.5721315,17z/data=!3m1!4b1!4m5!3m4!1s0x46fd752f76dddae7:0x4d4128c9a5066e47!8m2!3d54.3961355!4d18.5743203" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Uniwersytet Gdański6", Description="UG.", Street = "Jana Bażyńskiego", Zip_Code = "80-309", City = "Gdańsk", GMaps_Link = "https://www.google.com/maps/place/University+of+Gda%C5%84sk/@54.3961355,18.5721315,17z/data=!3m1!4b1!4m5!3m4!1s0x46fd752f76dddae7:0x4d4128c9a5066e47!8m2!3d54.3961355!4d18.5743203" },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

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
    }
}