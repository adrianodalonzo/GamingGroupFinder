using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class ProfileDisplayViewModel : ViewModelBase
    {
        public ProfileDB Profile { get; set; }
        private bool _visible;
        public bool Visible {
            get => _visible;
            private set => this.RaiseAndSetIfChanged(ref _visible, value);
        }
        public ProfileDisplayViewModel(ProfileDB p)
        {
            Profile = p;
            if(UserManager.GetInstance().LoggedInUser.Username.Equals(p.User.Username)) {
                Visible = true;
            }
        }

    }
}