using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;
using System.Reactive;
using System.Security.Cryptography;

namespace GamingGroupFinderGUI.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        public string Username {get; set;}
        public string Password {get; set;}
        public string Salt {get;set;}
        private UserManager Manager = new UserManager();

        public ReactiveCommand<Unit, Unit> Login { get; } = ReactiveCommand.Create(() => { });

        public ReactiveCommand<Unit, Unit> Register { get; } = ReactiveCommand.Create(() => { });

        public UserDB? User { get; private set;}
        public UserDB RegisterUser(){
            //add checking for if the user exists
                // if a user exists, show a message
                // else
            // byte[] UserSalt = GenerateSalt();
            // byte[] UserHashedPassword = GenerateHash(this.Password, UserSalt);
            // this.User = new UserDB(this.Username, ByteArrayToString(UserHashedPassword), ByteArrayToString(UserSalt), null);
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

    }
}