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
        public static List<string> GameNames { get; } = GetGameNames();
        public static List<string> PlatformNames { get; } = GetPlatformNames();
        public string _selectedGame;
        public string SelectedGame
        {
            get => _selectedGame;
            private set => this.RaiseAndSetIfChanged(ref _selectedGame, value);
        }
        public string _selectedInterest;
        public string SelectedInterest
        {
            get => _selectedInterest;
            private set => this.RaiseAndSetIfChanged(ref _selectedInterest, value);
        }
        public string _selectedPlatform;
        public string SelectedPlatform
        {
            get => _selectedPlatform;
            private set => this.RaiseAndSetIfChanged(ref _selectedPlatform, value);
        }
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

        public static void RemoveGame(string gameName) {
            var game = (from g in GameManager.GetListOfGames() where g.GameName.Equals(gameName) select g).FirstOrDefault();
            if(game is null) {
                return;
            }
            Profile.Games.Remove(game);
        }

        public static PlatformDB AddPlatform(string platformName) {
            var platform = (from p in PlatformManager.GetListOfPlatforms() where p.PlatformName.Equals(platformName) select p).FirstOrDefault();
            if(platform is null) {
                return null;
            }
            Profile.Platforms.Add(platform);
            return platform;
        }

        public static void RemovePlatform(string platformName) {
            var platform = (from p in PlatformManager.GetListOfPlatforms() where p.PlatformName.Equals(platformName) select p).FirstOrDefault();
            if(platform is null) {
                return;
            }
            Profile.Platforms.Remove(platform);
        }

        public static void AddInterest(string interestName) {
            Profile.Interests.Add(new InterestDB(interestName));
        }

        public static void RemoveInterest(string interestName) {
            var interest = (from i in InterestManager.GetListOfInterests() where i.InterestName.Equals(interestName) && i.Profiles.Contains(Profile) select i).FirstOrDefault();
            if(interest is null) {
                return;
            }
            Profile.Interests.Remove(interest);
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
