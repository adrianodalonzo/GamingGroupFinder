using System.Reactive;
using GamingGroupFinderGUI.Models;
using GamingGroupFinderGUI.ViewModels;
using ReactiveUI;

namespace StudyApp.ViewModels
{
    public class ProfileEditViewModel : ViewModelBase
    {
        
        public ProfileDB Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ProfileEditViewModel(ProfileDB p)
        {
            Profile = p;

            Ok = ReactiveCommand.Create(() => { });

        }


        
    }
}
