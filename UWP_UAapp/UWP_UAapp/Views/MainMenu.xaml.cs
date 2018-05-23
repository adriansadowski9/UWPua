﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UWP_UAapp.Models;

namespace UWP_UAapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MainMenu()
        {
            // Set the binding context to this code behind.
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new List<MainMenuItem>()
        {
            new MainMenuItem() { Title = "Items List", Icon = "menu_inbox.png", TargetType = typeof(ItemsPage) },
            new MainMenuItem() { Title = "About Page", Icon = "menu_stock.png", TargetType = typeof(AboutPage) }
        };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new ItemsPage());

            InitializeComponent();
        }

        // When a MenuItem is selected.
        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item != null)
            {
                if (item.Title.Equals("Items List"))
                {
                    Detail = new NavigationPage(new ItemsPage());
                }
                else if (item.Title.Equals("About Page"))
                {
                    Detail = new NavigationPage(new AboutPage());
                }

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}