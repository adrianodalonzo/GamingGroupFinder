using System.Collections.ObjectModel;
using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> SearchProfile { get; }
        public ReactiveCommand<Unit, Unit> SearchEvent { get; }
        public ObservableCollection<ProfileDB> QueriedProfiles { get; set; } = new ObservableCollection<ProfileDB>();
        public ObservableCollection<EventDB> QueriedEvents { get; set; } = new ObservableCollection<EventDB>();
        private string _searchQuery;
        public string SearchQuery {
            get => _searchQuery;
            private set => this.RaiseAndSetIfChanged(ref _searchQuery, value);
        }
        private bool _noProfilesFound;
        public bool NoProfilesFound {
            get => _noProfilesFound;
            private set => this.RaiseAndSetIfChanged(ref _noProfilesFound, value);
        }
        private bool _noEventsFound;
        public bool NoEventsFound {
            get => _noEventsFound;
            private set => this.RaiseAndSetIfChanged(ref _noEventsFound, value);
        }
        public SearchViewModel()
        {
            var buttonEnabled = this.WhenAnyValue(
                x => x.SearchQuery,
                x => !string.IsNullOrWhiteSpace(x)
            );

            NoProfilesFound = false;
            NoEventsFound = false;
            SearchProfile = ReactiveCommand.Create(() => {this.RetrieveProfiles();}, buttonEnabled);
            SearchEvent = ReactiveCommand.Create(() => {this.RetrieveEvents();}, buttonEnabled);
        }

        public void RetrieveProfiles() {
            ClearOptions();
            var profiles = ProfileManager.getInstance().SearchProfile(SearchQuery);
            if(profiles.Count == 0) {
                NoProfilesFound = true;
            } else {
                foreach(var profile in profiles) {
                    QueriedProfiles.Add(profile);
                }
            }
        }

        public void RetrieveEvents() {
            ClearOptions();
            var events = EventManager.GetInstance().SearchEvent(SearchQuery);
            if(events.Count == 0) {
                NoEventsFound = true;
            } else {
                foreach(var retrievedEvent in events) {
                    QueriedEvents.Add(retrievedEvent);
                }
            }
        }

        private void ClearOptions() {
            NoProfilesFound = false;
            NoEventsFound = false;

            if(QueriedEvents.Count > 0) {
                QueriedEvents.Clear();
            }
            
            if(QueriedProfiles.Count > 0) {
                QueriedProfiles.Clear();
            }
        }
        
    }
}
