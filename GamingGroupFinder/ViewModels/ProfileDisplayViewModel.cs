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
            using (WebClient client = new WebClient())
            {
                client.DownloadDataAsync(new Uri(url));
                client.DownloadDataCompleted += DownloadComplete;
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