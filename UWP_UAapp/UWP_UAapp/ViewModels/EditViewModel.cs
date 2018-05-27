using System;
using System.Collections.Generic;
using System.Text;
using UWP_UAapp.Models;

namespace UWP_UAapp.ViewModels
{
    class EditViewModel
    {
        public Item Item { get; set; }
        public EditViewModel(Item item = null)
        {
            Item = item;
        }
    }
}
