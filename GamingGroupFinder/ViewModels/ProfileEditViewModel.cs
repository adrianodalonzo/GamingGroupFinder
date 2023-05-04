using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class ProfileEditViewModel : ViewModelBase
    {
        
        public static ProfileDB Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public List<string> GameNames { get; } = GetGameNames();
        public List<string> PlatformNames { get; } = GetPlatformNames();
        public string Pronouns { get; set; }
        public ProfileEditViewModel(ProfileDB p)
        {
            Profile = p;

            Ok = ReactiveCommand.Create(() => {
                ProfileManager.EditProfile(Profile);
            });

        }

        public static GameDB AddGame(string gameName) {
            var game = (from g in GameManager.GetListOfGames() where g.GameName.Equals(gameName) select g).FirstOrDefault();
            if(game is null) {
                return null;
            }
            Profile.Games.Add(game);
            return game;
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
