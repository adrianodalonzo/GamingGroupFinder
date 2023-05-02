using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;
using System.Reactive;
using System.Security.Cryptography;

namespace GamingGroupFinderGUI.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        public string _username;
        public string _password;
        public bool _userExistsText;
        public bool _userDoesNotExistText;
        public string Username {
            get => _username;
            private set => this.RaiseAndSetIfChanged(ref _username, value);
        }
        public string Password {
            get => _password;
            private set => this.RaiseAndSetIfChanged(ref _password, value);
        }
        public bool UserExistsText {
            get => _userExistsText;
            private set => this.RaiseAndSetIfChanged(ref _userExistsText, value);
        }
        public bool UserDoesNotExistText {
            get => _userDoesNotExistText;
            private set => this.RaiseAndSetIfChanged(ref _userDoesNotExistText, value);
        }
        public string Salt {get;set;}
        private UserManager Manager = UserManager.GetInstance();

        public ReactiveCommand<Unit, Unit> Login { get; }

        public ReactiveCommand<Unit, Unit> Register { get; }
        public LogInViewModel() {
            var loginEnabled = this.WhenAnyValue(
                x => x.Username,
                x => !string.IsNullOrWhiteSpace(x)
            );
            Login = ReactiveCommand.Create(() => { }, loginEnabled);
            Register = ReactiveCommand.Create(() => { }, loginEnabled);
            UserExistsText = false;
            UserDoesNotExistText = false;
        }
        public UserDB? User { get; private set;}
        public UserDB RegisterUser() {
            //add checking for if the user exists
                // if a user exists, show a message
            byte[] UserSalt = GenerateSalt();
            byte[] UserHashedPassword = GenerateHash(this.Password, UserSalt);
            UserDB testUser = new UserDB(this.Username, ByteArrayToString(UserHashedPassword), ByteArrayToString(UserSalt), null);
            if(Manager.UserExists(UserDBToUser(testUser), Manager.GetListOfUsers())) {
                UserExistsText = true;
            } else {
                this.User = testUser;
                Manager.CreateUser(UserDBToUser(User));
            }
            return this.User;
        }

        public UserDB LoginUser() {
            //add checking for if a user exists with credentials given
                // if not, show a message
                // else
            
            // this.User = new UserDB(this.Username, this.Password, this.Salt, null);
            // Manager.SetLoggedInUser(u);
            return this.User;
        }

        private static byte[] GenerateSalt() {
        byte[] salt = new byte[8];
        using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider()) {
            rngCsp.GetBytes(salt);
        }
        return salt;
        }

        private static byte[] GenerateHash(string password, byte[] salt) {
            int numIterations = 1000;
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, numIterations);
            return key.GetBytes(32);
        }

        private static string ByteArrayToString(byte[] array) {
            string ByteString = "";
            foreach(byte val in array) {
                ByteString += val;
            }
            return ByteString;
        }

        private User UserDBToUser(UserDB user) {
            return new User(user.Username, user.Password, user.Salt, new List<User>());
        }

    }
}