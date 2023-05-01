using System.Collections.Generic;
using System.Collections.ObjectModel;
using GamingGroupFinderGUI.Models;

namespace GamingGroupFinderGUI.ViewModels
{
    public class ProfileDisplayViewModel : ViewModelBase
    {
        public ProfileDisplayViewModel(ProfileDB p)
        {
            Profile = p;
        }

        public ProfileDB Profile { get; }
    }
}