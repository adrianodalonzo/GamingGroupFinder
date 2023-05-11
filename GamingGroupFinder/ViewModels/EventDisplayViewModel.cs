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
        public EventDisplayViewModel(ObservableCollection<EventDB> e)
        {
            Events = e;
        }

        public ObservableCollection<EventDB> Events { get; }
    }
}