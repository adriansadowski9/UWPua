using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using UWP_UAapp.Models;
using UWP_UAapp.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UWP_UAapp.Services;

namespace UWP_UAapp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Places";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
                await ExecuteLoadItemsCommand();
            });
            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.DeleteItemAsync(_item.Id);
                await ExecuteLoadItemsCommand();
            });
            MessagingCenter.Subscribe<EditItemPage, Item>(this, "EditItem", async (obj, item) =>
            {
                var _item = item as Item;
                await DataStore.UpdateItemAsync(_item);
                await ExecuteLoadItemsCommand();
            });
            MessagingCenter.Subscribe<MockDataStore>(this, "Refresh", async (obj) =>
            {
                await ExecuteLoadItemsCommand();
            });

        }



        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
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
    }
}