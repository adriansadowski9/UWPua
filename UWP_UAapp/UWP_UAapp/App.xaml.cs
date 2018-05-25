using System;
using Xamarin.Forms;
using UWP_UAapp.Views;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace UWP_UAapp
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();
            MainPage = new MainMenu();
		}

        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
