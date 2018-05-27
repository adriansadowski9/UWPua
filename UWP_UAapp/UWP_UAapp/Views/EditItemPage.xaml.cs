using System;
using System.Text.RegularExpressions;
using UWP_UAapp.Models;
using UWP_UAapp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UWP_UAapp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditItemPage : ContentPage
	{
        EditViewModel viewModel;
        public Item Item { get; set; }

        internal EditItemPage(EditViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            Item = this.viewModel.Item;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Edit", "Are you sure you want to edit this item?", "Yes", "No");
            if (answer)
            {
                string error = "";
                if (Item.Name.Length < 3)
                {
                    error += "Name has less than 3 characters\n";
                }
                if (Item.Description.Length < 3)
                {
                    error += "Description has less than 3 characters\n";
                }
                if (Item.Street.Length < 3)
                {
                    error += "Street has less than 3 characters\n";
                }
                var zip_code_regex = "[0-9][0-9]-[0-9][0-9][0-9]";
                if (!Regex.Match(Item.Zip_Code, zip_code_regex).Success)
                {
                    error += "Wrong Zip Code format (ex. 01-100)\n";
                }
                if (Item.City.Length < 3)
                {
                    error += "City has less than 3 characters\n";
                }

                if (error != "")
                {
                    await DisplayAlert("Something went wrong", error, "Ok");
                }
                else
                {
                    Item.Id = Guid.NewGuid().ToString("N");
                    Item.GMaps_Link = "https://www.google.com/maps/place/" + Item.Street + Item.City;
                    MessagingCenter.Send(this, "EditItem", Item);
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                    await Navigation.PopAsync();
                }
            }
        }
    }
}