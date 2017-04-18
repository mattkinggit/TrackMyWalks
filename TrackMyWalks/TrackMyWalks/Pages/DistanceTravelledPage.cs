using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using TrackMyWalks.Models;
using TrackMyWalks.ViewModels;

namespace TrackMyWalks.Pages
{
    public class DistanceTravelledPage : ContentPage
    {
        DistTravelledViewModel _viewModel
        {
            get { return BindingContext as DistTravelledViewModel; }

        }
        public DistanceTravelledPage(WalkEntries walkItem)
        {
            Title = "Distance Traveled";

            // Declare and initialize our Model Binding Context
            BindingContext = new DistTravelledViewModel(walkItem);

            // Instantiate our map object
            var trailMap = new Map();

            // Place a pin on the map for the chosen walk type
            trailMap.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = _viewModel.WalkEntry.Title,
                Position = new Position(_viewModel.WalkEntry.Latitude,_viewModel.WalkEntry.Longitude)
            });

            // Center the map around the list of walks entry's location
            trailMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(_viewModel.WalkEntry.Latitude, _viewModel.WalkEntry.Longitude), Distance.FromKilometers(1.0)));

            var trailNameLabel = new Label()
            {
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
            };
            trailNameLabel.SetBinding(Label.TextProperty, "WalkEntry.Title");

            var trailDistanceTravelledLabel = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center
            };
            trailDistanceTravelledLabel.SetBinding(Label.TextProperty, "Travelled", stringFormat: "Distance Travelled: {0} km");

            var totalDistanceTaken = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Text = $"{walkItem.Distance} km",
                HorizontalTextAlignment = TextAlignment.Center
            };

            var totalTimeTakenLabel = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center
            };
            totalTimeTakenLabel.SetBinding(Label.TextProperty, "TimeTaken",stringFormat: "Time Taken: {0}");

            var totalTimeTaken = new Label()
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Text = "0h 0m 0s",
                HorizontalTextAlignment = TextAlignment.Center
            };

            var walksHomeButton = new Button
            {
                BackgroundColor = Color.FromHex("#008080"),
                TextColor = Color.White,
                Text = "End this Trail"
            };

            // Set up our event handler
            walksHomeButton.Clicked += (sender, e) =>
            {
                if (walkItem == null) return;
                Navigation.PopToRootAsync(true);
                walkItem = null;
            };

            this.Content = new ScrollView
            {
                Padding = 10,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children =
                    {
                        trailMap,
                        trailNameLabel,
                        trailDistanceTravelledLabel,
                        totalDistanceTaken,
                        totalTimeTakenLabel,
                        totalTimeTaken,
                        walksHomeButton
                    }
                }
            };
        }
    }
}
