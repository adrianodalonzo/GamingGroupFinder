using System.Collections.Generic;
using System.Collections.ObjectModel;
using GamingGroupFinderGUI.Models;

namespace GamingGroupFinderGUI.ViewModels
{
    public class EventDisplayViewModel : ViewModelBase
    {
        public EventDisplayViewModel(EventDB e)
        {
            Event = e;
        }

        public EventDB Event { get; }
    }
}