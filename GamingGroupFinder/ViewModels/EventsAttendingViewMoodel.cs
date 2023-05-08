using System.Reactive;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class EventsAttendingViewModel : ViewModelBase
    {
        
        public EventDB Event {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public EventsAttendingViewModel(EventDB e)
        {
            Event = e;

            Ok = ReactiveCommand.Create(() => { });

        }


        
    }
}
