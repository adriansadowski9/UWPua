using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UWP_UAapp.Models;
using UWP_UAapp.ViewModels;
using System.Collections;

namespace UWP_UAapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
        ItemsViewModel viewModel;
        int i = 0;
        private IEnumerable mockItems;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (i == 0)
            {
                mockItems = ItemsListView.ItemsSource;
                i++;
            }

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ItemsListView.ItemsSource = mockItems;
            }

            else
            {
                ItemsListView.ItemsSource = mockItems.Cast<Item>().Where(x => x.Name.StartsWith(e.NewTextValue));
            }
        }
    }
}