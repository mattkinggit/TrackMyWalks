using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyWalks.Models;
using Xamarin.Forms;

namespace TrackMyWalks.ViewModels
{
    public class WalksEntryViewModel:WalkBaseViewModel
    {
        string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }

        double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }

        double _kilometers;
        public double Kilometers
        {
            get { return _kilometers; }
            set
            {
                _kilometers = value;
                OnPropertyChanged();
            }
        }

        string _difficulty;
        public string Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                OnPropertyChanged();
            }
        }

        double _distance;
        public double Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged();
            }
        }

        string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        public WalksEntryViewModel()
        {
            Title = "New Walk";

            Difficulty = "Easy";

            Distance = 1.0;
        }

        Command _saveCommand;
        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(ExecuteSaveCommand, ValidateFormDetails));
            }
        }

        void ExecuteSaveCommand()
        {
            var newWalkItem = new WalkEntries
            {
                Title = this.Title,
                Notes = this.Notes,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Kilometers = this.Kilometers,
                Difficulty = this.Difficulty,
                Distance = this.Distance,
                ImageUrl = this.ImageUrl
            };

            // Here, we will save the details entered in a later chapter.
        }

        // method to check for any form errors
        bool ValidateFormDetails()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }
    }
}
