using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UWP_UAapp.Models;
using UWP_UAapp.ViewModels;

namespace UWP_UAapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Name = "Place",
                Description = "This is an place description.",
                Street = "Street name and number",
                Zip_Code = "Zip Code",
                City = "City",
                GMaps_Link = "Link to place on GMaps"
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete", "Are you sure you want to delete this item?", "Yes", "No");
            if (answer)
            {
                MessagingCenter.Send(this, "DeleteItem", viewModel.Item);
                await Navigation.PopAsync();
            }
        }
        async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditItemPage(new EditViewModel(this.viewModel.Item)));
        }

        async void OpenGmaps(object sender, EventArgs args)
        {
            var answer = await DisplayAlert("Find this place", "Are you sure you want to show this place on Google Maps?", "Yes", "No");
            if (answer)
            {
                Device.OpenUri(new Uri(viewModel.Item.GMaps_Link));
            }
        }
    }
}