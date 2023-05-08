using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;
using System.Reactive;
using System.Security.Cryptography;
using System.Text;

namespace GamingGroupFinderGUI.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        public string _username;
        public string _password;
        public bool _userExistsText;
        public bool _userDoesNotExistText;
        public bool _passwordIncorrect;
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
        public bool PasswordIncorrect {
            get => _passwordIncorrect;
            private set => this.RaiseAndSetIfChanged(ref _passwordIncorrect, value);
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
            PasswordIncorrect = false;
        }
        public UserDB? User { get; private set;}
        public UserDB RegisterUser() {
            byte[] UserSalt = GenerateSalt();
            string UserHashedPassword = GenerateHash(this.Password, UserSalt);
            UserDB testUser = new UserDB(this.Username, UserHashedPassword, UserSalt, null);
            if(Manager.UserExists(UserDBToUser(testUser), Manager.GetListOfUsers())) {
                UserExistsText = true;
            } else {
                this.User = testUser;
                Manager.CreateUser(UserDBToUser(User));
                Profile p = new Profile(UserDBToUser(User));
                ProfileManager.CreateProfile(p, UserDBToUser(this.User));
            }
            return this.User;
        }

        public UserDB LoginUser() {
            //add checking for if a user exists with credentials given
                // if not, show a message
            UserDB testUser = Manager.GetUser(Username);
            if(testUser is null) {
                UserDoesNotExistText = true;
            } else {
                // need to figure out how to check salt and passwords
                string password = testUser.Password;
                byte[] salt = testUser.Salt;

                string testHash = GenerateHash(this.Password, salt);
                if(testHash.Equals(password)) {
                    this.User = testUser;
                    Manager.LogInUser(UserDBToUser(this.User));
                } else {
                    PasswordIncorrect = true;
                }
            }
            return this.User;
        }

        internal static byte[] GenerateSalt() {
            byte[] salt = new byte[8];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider()) {
                rngCsp.GetBytes(salt);
            }
            return salt;
        }

        internal static string GenerateHash(string password, byte[] salt) {
            int numIterations = 1000;
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, numIterations);
            return Convert.ToBase64String(key.GetBytes(32));
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