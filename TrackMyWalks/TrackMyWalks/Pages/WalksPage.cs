using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using TrackMyWalks.Models;
using TrackMyWalks.ViewModels;

namespace TrackMyWalks.Pages
{
    public class WalksPage : ContentPage
    {
        public WalksPage()
        {
            var newWalkItem = new ToolbarItem
            {
                Text = "Add Walk"
            };

            newWalkItem.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new WalkEntryPage());
            };

            ToolbarItems.Add(newWalkItem);

            // Declare and initialize our Model Binding Context

            BindingContext = new WalksPageViewModel();

            // Define our Item Template
            var itemTemplate = new DataTemplate(typeof(ImageCell));
            itemTemplate.SetBinding(TextCell.TextProperty, "Title");
            itemTemplate.SetBinding(TextCell.DetailProperty, "Notes");
            itemTemplate.SetBinding(ImageCell.ImageSourceProperty, "ImageUrl");

            var walksList = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = itemTemplate,
                SeparatorColor = Color.FromHex("#ddd"),
            };

            // Set the binding property for our walks Entries
            walksList.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "walkEntries");

            // Set up our event handler
            walksList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                var item = (WalkEntries)e.Item;
                if (item == null) return;
                Navigation.PushAsync(new WalkTrailPage(item));
                item = null;
            };
            Content = walksList;
        }
    }
}
