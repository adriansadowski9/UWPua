using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UWP_UAapp.Models;
using System.Text.RegularExpressions;

namespace UWP_UAapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Name = "",
                Description = "",
                Street = "",
                Zip_Code = "",
                City = "",
                GMaps_Link = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Add", "Are you sure you want to add this item?", "Yes", "No");
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
                    MessagingCenter.Send(this, "AddItem", Item);
                    await Navigation.PopModalAsync();
                }
            }
        }
    }
}