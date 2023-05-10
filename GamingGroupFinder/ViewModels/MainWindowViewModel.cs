using System.Collections.ObjectModel;
using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels;

// TODO
// figure out how to get a clean login page when logging out
    // when logging out, then try to log in again (with first acc or another, user is still "logged in"). need to figure out how log out should work.
    // delete account
// figure out events
    // show all events?
    // add event
    // leave event
// figure out search
    // event

class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        private bool _visibleNavigation;
        public bool VisibleNavigation {
            get => _visibleNavigation;
            private set => this.RaiseAndSetIfChanged(ref _visibleNavigation, value);
        }
        UserDB? LoggedInUser {get;set;}

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public ReactiveCommand<Unit, Unit> Profile { get; }
        public ReactiveCommand<Unit, Unit> NewEvent { get; }
        public ReactiveCommand<Unit, Unit> Search { get; }
        public ReactiveCommand<Unit, Unit> Logout { get; }


        public MainWindowViewModel() {
            Profile = ReactiveCommand.Create(() => {ShowPersonalProfile();});
            NewEvent =  ReactiveCommand.Create(() => {CreateEvent();});
            Search  = ReactiveCommand.Create(() => {OpenSearch();});
            Logout = ReactiveCommand.Create(() => {
                Login();
            });

            Login();
        }

        private void ShowPersonalProfile()
        {
            DisplayProfile(ProfileManager.GetProfile(LoggedInUser));
        }

        private void DisplayProfile(ProfileDB profile) {
            Content = new ProfileDisplayViewModel(profile);
        }

        public void Login() {
            if(LoggedInUser != null) {
                UserManager.GetInstance().LogOutUser();
            }
            VisibleNavigation = false;

            LogInViewModel vm = new LogInViewModel();
            vm.Login.Subscribe(x => {PrepareMainPage(vm.LoginUser());});
            vm.Register.Subscribe(x => {PrepareMainPage(vm.RegisterUser());});
            Content = vm;
        }


        public void PrepareMainPage(UserDB u) {
            if(u == null) {
                VisibleNavigation = false;
            } else {
                VisibleNavigation = true;
                if(u != null) {
                    LoggedInUser = u;
                    ProfileDB p = ProfileManager.GetProfile(LoggedInUser);
                    ShowPersonalProfile();
                }
            }
        }

        private void OpenSearch()
        {
            Content = new SearchViewModel();
        }

        private void CreateEvent()
        {
            // DisplayEvent(new EventDB());
        }

        private void DisplayEvents(ObservableCollection<EventDB> e)
        {
            Content = new EventDisplayViewModel(e);
        }
       

        public void ViewEvents()
        {
            // possibly take in a lis of events and display them in the view
            // ObservableCollection<EventDB> eventDBs = new ObservableCollection<EventDB>();
            // UserDB u = new UserDB("OwnerUser", "pass", new byte['s'], null);
            // UserDB u2 = new UserDB("Attending1", "pass", new byte['s'], null);
            // UserDB u3 = new UserDB("AttendingOne", "pass", new byte['s'], null);
            // UserDB u4 = new UserDB("Attending2", "pass", new byte['s'], null);

            // List<UserDB> users1 = new List<UserDB>{u2, u3};
            // List<UserDB> users2 = new List<UserDB>{u4};

            // eventDBs.Add(new EventDB(u, "EventOne", DateTime.Now, "Here", null, null, "EventOne Description", users1));
            // eventDBs.Add(new EventDB(u, "EventTwo", DateTime.Today, "Over There", null, null, "EventTwo Description", users2));

            ObservableCollection<EventDB> eventDBs = new ObservableCollection<EventDB>(){ EventManager.GetInstance().GetEvent(1)};

            Content = new EventDisplayViewModel(eventDBs);
        }

        public void EditEvent(EventDB e)
        {
            EventDisplayViewModel dispvm = (EventDisplayViewModel) Content;
            var vm = new EventEditViewModel(e);
            
            vm.Ok.Subscribe(x => {Content = dispvm;});
            Content = vm;
        }

        public void EditProfile()
        {
            ProfileDisplayViewModel dispvm = (ProfileDisplayViewModel) Content;
            var vm = new ProfileEditViewModel(dispvm.Profile);
            
            vm.Ok.Subscribe(x => {Content = dispvm;});
            Content = vm;
        }

        public void ResetPassword() {
            var vm = new ResetPasswordViewModel(LoggedInUser);
            var oldView = (ProfileDisplayViewModel) Content;

            Content = vm;
            vm.Ok.Subscribe((x) => { 
                if(x) {
                    Content = oldView;
                }
            });
        }

        public void ClearProfile() {
            ProfileDB clearedProfile = new ProfileDB(LoggedInUser, null!, null!, 0, null!, null!, new List<InterestDB>(), new List<PlatformDB>(), new List<GameDB>());
            LoggedInUser.Profile = clearedProfile;
            ProfileManager.EditProfile(LoggedInUser.Profile);
            DisplayProfile(LoggedInUser.Profile);
        }

        public void DeleteAccount() {
            UserManager.GetInstance().DeleteAccount();
            Login();
        }

    }
