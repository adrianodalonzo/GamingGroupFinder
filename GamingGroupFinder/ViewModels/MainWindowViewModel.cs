using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels;

class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        UserDB? LoggedInUser;

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }


        public MainWindowViewModel()
        {

            LogInViewModel vm = new LogInViewModel();
            ProfileEditViewModel pvm = new ProfileEditViewModel(null);
            
            vm.Login.Subscribe(x => {PrepareMainPage(vm.LoginUser());});
            vm.Register.Subscribe(x => {PrepareMainPage(vm.RegisterUser());});
            Content = vm;
        }


        public void PrepareMainPage(UserDB u) {
            LoggedInUser = u;
            ProfileDB p = new ProfileDB(u, null, null, 0, null, null);
            Content = new ProfileDisplayViewModel(p);
        }
       

        public void ViewEvent()
        {
            Content = new EventDisplayViewModel(new EventDB(null, null, DateTime.Now, null, null, null, null, null, null)) ;
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
    }
