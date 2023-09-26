using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
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
            ProfilePictureUrl = Profile.ProfilePicture;
        }
        private string profilePictureUrl;
        public string ProfilePictureUrl
        {
            get => profilePictureUrl;
            set {
                this.RaiseAndSetIfChanged(ref profilePictureUrl, value);
                DownloadImage(ProfilePictureUrl);
                System.Diagnostics.Debug.WriteLine(ProfilePictureUrl);
            }
        }

        private Avalonia.Media.Imaging.Bitmap profilePicture = null;
        public Avalonia.Media.Imaging.Bitmap ProfilePicture
        {
            get => profilePicture;
            set => this.RaiseAndSetIfChanged(ref profilePicture, value);
        }
        public void DownloadImage(string url)
        {
            if(url == null) {
                url = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Default_pfp.svg/1200px-Default_pfp.svg.png";
            }
            using (WebClient client = new WebClient())
            {
                try {
                    client.DownloadDataAsync(new Uri(url));
                    client.DownloadDataCompleted += DownloadComplete;
                } catch (Exception e) {
                    url = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Default_pfp.svg/1200px-Default_pfp.svg.png";
                    client.DownloadDataAsync(new Uri(url));
                    client.DownloadDataCompleted += DownloadComplete;
                }
            }
        }
        private void DownloadComplete(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                byte[] bytes = e.Result;

                Stream stream = new MemoryStream(bytes);

                var image = new Avalonia.Media.Imaging.Bitmap(stream);
                ProfilePicture = image;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                ProfilePicture = null; // Could not download...
            }
            
        }

    }
}