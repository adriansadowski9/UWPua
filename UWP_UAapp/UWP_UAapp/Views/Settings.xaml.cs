using System;
using System.Diagnostics;
using UWP_UAapp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UWP_UAapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        SettingsViewModel viewModel;
        public Settings()
        {
            InitializeComponent();
            BindingContext = viewModel = new SettingsViewModel();
        }


        async void ToggleDarkMode(object sender, EventArgs e)
        {
            await viewModel.ToggleDarkMode();
        }

    }
}