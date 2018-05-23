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
    }
}