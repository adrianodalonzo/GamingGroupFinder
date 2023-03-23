namespace GamingGroupFinder {
    public class User {
        private string username {get;}
        private string password;

        public User(string username, string password) {
            this.username = username;
            this.password = password;
        }

        public bool VerifyUser(string username, string password) {
            return false;
        }   

        public void ChangePassword(string newPassword) {
            this.password = newPassword;
        }

        public void DeleteAccount() {
            
        }
    }
}