using System.Collections.ObjectModel;
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
        public static ObservableCollection<string> GameNames { get; } = GetGameNames();
        public static ObservableCollection<string> PlatformNames { get; } = GetPlatformNames();
        private string _selectedGame;
        public string SelectedGame
        {
            get => _selectedGame;
            private set => this.RaiseAndSetIfChanged(ref _selectedGame, value);
        }
        private string _selectedInterest;
        public string SelectedInterest
        {
            get => _selectedInterest;
            private set => this.RaiseAndSetIfChanged(ref _selectedInterest, value);
        }
        private string _selectedPlatform;
        public string SelectedPlatform
        {
            get => _selectedPlatform;
            private set => this.RaiseAndSetIfChanged(ref _selectedPlatform, value);
        }
        private string _profilePictureUrl;
        public string ProfilePictureUrl
        {
            get => _profilePictureUrl;
            set  {this.RaiseAndSetIfChanged(ref _profilePictureUrl, value); 
                Profile.ProfilePicture = value;
            }
        }
        public ProfileEditViewModel(ProfileDB p)
        {
            Profile = p;

            Ok = ReactiveCommand.Create(() => {
                ProfileManager.EditProfile(Profile);
            });

        }

        public GameDB AddGame(string gameName) {
            var game = (from g in GameManager.GetListOfGames() where g.GameName.Equals(gameName) select g).FirstOrDefault();
            if(game is null) {
                return null;
            }
            Profile.Games.Add(game);
            return game;
        }

        public PlatformDB AddPlatform(string platformName) {
            var platform = (from p in PlatformManager.GetListOfPlatforms() where p.PlatformName.Equals(platformName) select p).FirstOrDefault();
            if(platform is null) {
                return null;
            }
            Profile.Platforms.Add(platform);
            return platform;
        }

        public void AddInterest(string interestName) {
            Profile.Interests.Add(new InterestDB(interestName));
        }
        
        public void RemoveInterest(string interestName) {
            InterestDB interest = Profile.Interests
                                    .FirstOrDefault(i => i.InterestName.Equals(interestName));
            if(interest != null) {
                Profile.Interests.Remove(interest);
            }
        }

        public static ObservableCollection<string> GetGameNames() {
            ObservableCollection<string> gameNames = new ObservableCollection<string>();
            foreach(GameDB game in GameManager.GetListOfGames()) {
                gameNames.Add(game.GameName);
            }
            return gameNames;
        }

        public static ObservableCollection<string> GetPlatformNames() {
            ObservableCollection<string> platformNames = new ObservableCollection<string>();
            foreach(PlatformDB platform in PlatformManager.GetListOfPlatforms()) {
                platformNames.Add(platform.PlatformName);
            }
            return platformNames;
        }
        
    }
}
