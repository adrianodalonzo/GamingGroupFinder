using System.Reactive;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class ProfileEditViewModel : ViewModelBase
    {
        
        public ProfileDB Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public List<string> Pronouns { get; } = new List<string> { "He/Him", "She/Her", "They/Them", "Other" };
        public ProfileEditViewModel(ProfileDB p)
        {
            Profile = p;

            Ok = ReactiveCommand.Create(() => { });

        }
        
    }
}
