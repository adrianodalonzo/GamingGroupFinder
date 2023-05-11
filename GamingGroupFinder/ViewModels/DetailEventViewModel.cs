using System.Reactive;
using GamingGroupFinderGUI.Models;
using ReactiveUI;
using GamingGroupFinder;

namespace GamingGroupFinderGUI.ViewModels
{
    public class DetailEventViewModel : ViewModelBase
    {
        public EventDB _event;

        public EventDB Event {
            get => _event;
            private set => this.RaiseAndSetIfChanged(ref _event, value);
        }

        public string _username;

        public string Username {
            get => _username;
            private set => this.RaiseAndSetIfChanged(ref _username, value);
        }
        private bool _canAttend;
        public bool CanAttend {
            get => _canAttend;
            private set => this.RaiseAndSetIfChanged(ref _canAttend, value);
        }

        public ReactiveCommand<Unit, Unit> Attend { get; }
        public ReactiveCommand<Unit, Unit> Leave { get; }

        public DetailEventViewModel(EventDB eventDB, string username)
        {
            Event = eventDB;

            Username = username;

            Attend = ReactiveCommand.Create(() => {AttendEvent(Event, Username);});

            Leave = ReactiveCommand.Create(() => {LeaveEvent(Event, Username);});

            CanAttend = DetermineCanAttend();
        }

        private void AttendEvent(EventDB eventDB, string username)
        {
            EventManager.GetInstance().AttendEvent(eventDB, username);
        }

        private void LeaveEvent(EventDB eventDB, string username)
        {
            EventManager.GetInstance().LeaveEvent(eventDB, username);
        }

        private bool DetermineCanAttend() {
            foreach(UserDB u in Event.UsersAttending) {
                if(u.Username.Equals(UserManager.GetInstance().LoggedInUser.Username)) {
                    return false;
                }
            }
            return true;
        }
    }
}