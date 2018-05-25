using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UWP_UAapp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public bool _darkMode;

        public bool DarkMode
        {
            get
            {
                return _darkMode;
            }
            set
            {
                SetProperty(ref _darkMode, value);

            }
        }

        public SettingsViewModel()
        {
            Title = "Settings";

            if (Application.Current.Properties.ContainsKey("DarkMode"))
            {
                DarkMode = (bool)Application.Current.Properties["DarkMode"];
            }
            else
            {          
                Application.Current.Properties["DarkMode"] = false;
            }

        }

        public Task ToggleDarkMode()
        {
            Application.Current.Properties["DarkMode"] = !(bool)Application.Current.Properties["DarkMode"];

            if (!DarkMode)
            {
                Application.Current.Resources["backgroundColor"] = Color.FromHex("f5f5f5");
                Application.Current.Resources["textColor"] = Color.FromHex("181818");
                Application.Current.Resources["backgroundButtonColor"] = Color.LightGray;

                Debug.WriteLine(Application.Current.Resources);
            }
            else
            {
                Application.Current.Resources["backgroundColor"] = Color.FromHex("181818");
                Application.Current.Resources["textColor"] = Color.FromHex("f5f5f5");
                Application.Current.Resources["backgroundButtonColor"] = Color.DarkGray;

            }

            //Debug.WriteLine(_darkMode);
            return Task.CompletedTask;
        }

    }
}
