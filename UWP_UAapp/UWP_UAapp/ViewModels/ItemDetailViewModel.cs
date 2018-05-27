using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using UWP_UAapp.Models;
using UWP_UAapp.Views;
using Xamarin.Forms;

namespace UWP_UAapp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
