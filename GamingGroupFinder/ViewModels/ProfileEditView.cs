using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class ProfileEditViewModel : ViewModelBase
    {
        
        public ProfileDB Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public List<string> GameNames { get; } = GetGameNames();
        public List<string> PlatformNames { get; } = GetPlatformNames();
        public List<string> Pronouns { get; } = new List<string> { "He/Him", "She/Her", "They/Them", "Other" };
        public string SelectedPronoun { get; set; }
        public ProfileEditViewModel(ProfileDB p)
        {
            Profile = p;

            Ok = ReactiveCommand.Create(() => { });

        }

        public static List<string> GetGameNames() {
            List<string> gameNames = new List<string>();
            foreach(GameDB game in GameManager.GetListOfGames()) {
                gameNames.Add(game.GameName);
            }
            return gameNames;
        }

        public static List<string> GetPlatformNames() {
            List<string> platformNames = new List<string>();
            foreach(PlatformDB platform in PlatformManager.GetListOfPlatforms()) {
                platformNames.Add(platform.PlatformName);
            }
            return platformNames;
        }
        
    }
}
