using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class EventEditViewModel : ViewModelBase
    {
        public EventDB _event;
        public EventDB Event {
            get => _event; 
            private set => this.RaiseAndSetIfChanged(ref _event, value);
        }
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ObservableCollection<string> GameNames { get; } = ProfileEditViewModel.GetGameNames();
        public ObservableCollection<string> PlatformNames { get; } = ProfileEditViewModel.GetPlatformNames();
        public DateTimeOffset Date {
            get => Event.Time.Date;
            set { Event.Time = value.Add(Event.Time.TimeOfDay).DateTime; }
        }
        public TimeSpan TimeOfDay {
            get => Event.Time.TimeOfDay;
            set { Event.Time = Event.Time.Date.Add(value); }
        }
        private string _selectedGame;
        public string SelectedGame
        {
            get => _selectedGame;
            private set {
                this.RaiseAndSetIfChanged(ref _selectedGame, value);
                Event.Game = GameManager.GetGame(value);
            } 
        }
        private string _selectedPlatform;
        public string SelectedPlatform
        {
            get => _selectedPlatform;
            private set {
                this.RaiseAndSetIfChanged(ref _selectedPlatform, value);
                Event.Platform = PlatformManager.GetPlatform(value);
            }
        }
        public EventEditViewModel(EventDB e)
        {
            Event = e;
            Date = DateTime.Now;
            Ok = ReactiveCommand.Create(() => {saveEvent(Event);});
                // this.WhenAnyValue(x => x.Event), (x => (x != null)));
        }

        private EventDB saveEvent(EventDB e) {
            EventManager.GetInstance().EditEvent(e);
            return e;
        }
        
    }
}
