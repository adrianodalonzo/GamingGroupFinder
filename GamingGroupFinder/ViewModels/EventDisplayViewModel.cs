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
        private bool _canEdit;
        public bool CanEdit {
            get => _canEdit;
            private set => this.RaiseAndSetIfChanged(ref _canEdit, value);
        }
        public ObservableCollection<EventDB> Events { get; }
        public EventDisplayViewModel(ObservableCollection<EventDB> e)
        {
            Events = e;
            EventCreation = DetermineEventCreation();
            CanEdit = DetermineCanEdit();
        }

        private bool DetermineEventCreation() {
            if (Events is null) {
                return true;
            }

            foreach(EventDB ev in Events) {
                if(ev.Owner.Username.Equals(UserManager.GetInstance().LoggedInUser.Username)) {
                    return false;
                }
            }
            return true;
        }

        private bool DetermineCanEdit() {
            foreach(EventDB ev in Events) {
                if(ev.Owner.Username.Equals(UserManager.GetInstance().LoggedInUser.Username)) {
                    return true;
                }
            }
            return false;
        }
    }
}