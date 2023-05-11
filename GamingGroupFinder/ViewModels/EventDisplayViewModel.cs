using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class EventDisplayViewModel : ViewModelBase
    {
        private bool _eventCreation;
        public bool EventCreation {
            get => _eventCreation;
            private set => this.RaiseAndSetIfChanged(ref _eventCreation, value);
        }
        public ObservableCollection<EventDB> Events { get; }
        public EventDisplayViewModel(ObservableCollection<EventDB> e)
        {
            Events = e;
            EventCreation = DetermineEventCreation();
        }

        private bool DetermineEventCreation() {
            foreach(EventDB ev in Events) {
                if(ev.Owner.Username.Equals(UserManager.GetInstance().LoggedInUser.Username)) {
                    return false;
                }
            }
            return true;
        }
    }
}