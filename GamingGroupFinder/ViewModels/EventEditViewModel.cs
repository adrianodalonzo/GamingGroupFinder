using System.Reactive;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class EventEditViewModel : ViewModelBase
    {
        
        public EventDB Event {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public EventEditViewModel(EventDB e)
        {
            Event = e;

            Ok = ReactiveCommand.Create(() => { });

        }


        
    }
}
