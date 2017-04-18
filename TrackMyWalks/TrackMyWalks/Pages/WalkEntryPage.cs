using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using TrackMyWalks.Models;

namespace TrackMyWalks.Models
{
    public class WalkEntryPage : ContentPage
    {
        public WalkEntryPage()
        {
            // Set the Content Page TItle
            Title = "New Walk Entry";

            // Define our New Walk Entry fields
            var walkTitle = new EntryCell
            {
                Label = "Title:",
                Placeholder = "Trails Title"
            };

            var walkNotes = new EntryCell
            {
                Label = "Notes:",
                Placeholder = "Description"
            };

            var walkLatitude = new EntryCell
            {
                Label = "Latitude:",
                Placeholder = "Latitude",
                Keyboard = Keyboard.Numeric
            };

            var walkLongitude = new EntryCell
            {
                Label = "Longitude:",
                Placeholder = "Longitude",
                Keyboard = Keyboard.Numeric
            };

            var walkKilometers = new EntryCell
            {
                Label = "Kilometers:",
                Placeholder = "Kilometers",
                Keyboard = Keyboard.Numeric
            };

            var walkDifficulty = new EntryCell
            {
                Label = "Difficulty Level:",
                Placeholder = "Walk Difficulty"
            };

            var walkImageUrl = new EntryCell
            {
                Label = "ImageUrl:",
                Placeholder = "Image URL"
            };

            // Define our TableView
            Content = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection()
                    {
                        walkTitle,
                        walkNotes,
                        walkLatitude,
                        walkLongitude,
                        walkKilometers,
                        walkDifficulty,
                        walkImageUrl
                    }
                }
            };

            var saveWalkItem = new ToolbarItem
            {
                Text = "Save"
            };

            saveWalkItem.Clicked += (sender, e) =>
            {
                Navigation.PopToRootAsync(true);
            };

            ToolbarItems.Add(saveWalkItem);
        }
    }
}
