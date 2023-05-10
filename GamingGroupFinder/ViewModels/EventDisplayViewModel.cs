using System.Collections.Generic;
using System.Collections.ObjectModel;
using GamingGroupFinderGUI.Models;

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