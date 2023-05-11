using System.Collections.ObjectModel;
using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels;

// TODO
    // Fix bug where when logging out then registering, throws exception
    // Mini:
        // can only edit event if you're the owner

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
            DisplayProfile(ProfileManager.GetInstance().GetProfile(LoggedInUser));
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
                    ProfileDB p = ProfileManager.GetInstance().GetProfile(LoggedInUser);
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
            EventDisplayViewModel edvm = (EventDisplayViewModel) Content;
            var vm = new AddEventViewModel(LoggedInUser);

            vm.Ok.Subscribe(x => {Content = new EventDisplayViewModel(new ObservableCollection<EventDB>(EventManager.GetInstance().GetEvents()));});
            Content = vm;
        }

        private void DisplayEvents(ObservableCollection<EventDB> e)
        {
            Content = new EventDisplayViewModel(e);
        }
       

        public void ViewEvents()
        {
            ObservableCollection<EventDB> eventDBs = new ObservableCollection<EventDB>(EventManager.GetInstance().GetEvents());

            Content = new EventDisplayViewModel(eventDBs);
        }

        public void DetailEvent(EventDB e)
        {
            ViewModelBase dispvm = new ViewModelBase();
            if(Content.GetType() == typeof(EventDisplayViewModel)) {
                dispvm = (EventDisplayViewModel) Content;
            } else {
                dispvm = (SearchViewModel) Content;
            }
            var vm = new DetailEventViewModel(e, LoggedInUser.Username);

            vm.Attend.Subscribe(x => {Content = dispvm;});
            vm.Leave.Subscribe(x => {Content = dispvm;});

            Content = vm;
        }

        public void EditEvent(EventDB e)
        {
            DetailEventViewModel dispvm = (DetailEventViewModel) Content;
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
            ProfileManager.GetInstance().EditProfile(LoggedInUser.Profile);
            DisplayProfile(LoggedInUser.Profile);
        }

        public void DeleteAccount() {
            UserManager.GetInstance().DeleteAccount();
            Login();
        }

    }
