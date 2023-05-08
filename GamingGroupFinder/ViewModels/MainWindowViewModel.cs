using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels;

// TODO
// figure out how to get a clean login page when logging out
    // when logging out, then try to log in again (with first acc or another, user is still "logged in"). need to figure out how log out should work.
    // reset password
    // delete account
// figure out how to save profile without errors (unique constraint violated when saving new edits (even when no changes were made))
// figure out events
    // show all events?
    // add event
    // leave event
// figure out search
    // profile
    // event

class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        private bool _visibleNavigation;
        public bool VisibleNavigation {
            get => _visibleNavigation;
            private set => this.RaiseAndSetIfChanged(ref _visibleNavigation, value);
        }
        UserDB? LoggedInUser;

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
            throw new NotImplementedException();
        }

        private void CreateEvent()
        {
            // DisplayEvent(new EventDB());
        }

        private void DisplayEvent(EventDB e)
        {
            Content = new EventDisplayViewModel(e);
        }
       

        public void ViewEvents()
        {
            // possibly take in a lis of events and display them in the view
            Content = new EventDisplayViewModel(new EventDB(null, null, DateTime.Now, null, null, null, null, null, null));
        }

        public void EditEvent()
        {
            EventDisplayViewModel dispvm = (EventDisplayViewModel) Content;
            var vm = new EventEditViewModel(dispvm.Event);
            
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
    }
