using GamingGroupFinderGUI.Models;
using ReactiveUI;
using System.Reactive;

namespace GamingGroupFinderGUI.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        public string Username {get; set;}
        public string Password {get; set;}

        public ReactiveCommand<Unit, Unit> Login { get; } = ReactiveCommand.Create(() => { });

        public ReactiveCommand<Unit, Unit> Register { get; } = ReactiveCommand.Create(() => { });

        public UserDB? User { get; private set;}
        public UserDB RegisterUser(){
            this.User = new UserDB(Username, Password, "salt", null);
            return this.User;
        }

        public UserDB LoginUser(){
            this.User = new UserDB(Username, Password, "salt", null);
            return this.User;
        }



    }
}