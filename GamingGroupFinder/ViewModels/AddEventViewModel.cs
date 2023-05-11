using System.Collections.ObjectModel;
using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class AddEventViewModel : ViewModelBase
    {
        
        public EventDB Event {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public DateTimeOffset Date {
            get => Event.Time.Date;
            set { Event.Time = value.Add(Event.Time.TimeOfDay).DateTime; }
        }
        public TimeSpan TimeOfDay {
            get => Event.Time.TimeOfDay;
            set { Event.Time = Event.Time.Date.Add(value); }
        }
        private string _selectedGame;
        public string SelectedGame {
            get => _selectedGame;
            private set => this.RaiseAndSetIfChanged(ref _selectedGame, value);
        }
        private string _selectedPlatform;
        public string SelectedPlatform {
            get => _selectedPlatform;
            private set => this.RaiseAndSetIfChanged(ref _selectedPlatform, value);
        }
        public ObservableCollection<string> GameNames { get; } = ProfileEditViewModel.GetGameNames();
        public ObservableCollection<string> PlatformNames { get; } = ProfileEditViewModel.GetPlatformNames();
        public AddEventViewModel(UserDB owner)
        {

            Event = new EventDB("", owner);
            Date = DateTime.Now;
            Event.Owner.Profile = ProfileManager.GetProfile(owner);
            Ok = ReactiveCommand.Create(() => { 
                CreateEvent();
            });

        }

        private void CreateEvent() {
            Event.Platform = PlatformManager.GetPlatform(SelectedPlatform);
            Event.Game = GameManager.GetGame(SelectedGame);
            EventManager.GetInstance().CreateEvent(Event);
        }
        
    }
}
