using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrackMyWalks.Models;

namespace TrackMyWalks.ViewModels
{
    public class WalksTrailViewModel:WalkBaseViewModel
    {
        WalkEntries _walkEntry;

        public WalkEntries WalkEntry
        {
            get { return _walkEntry;}

            set
            {
                _walkEntry = value;
                OnPropertyChanged();
            }
        }

        public WalksTrailViewModel(WalkEntries walkEntry)
        {
            WalkEntry = walkEntry;
        }
    }
}
