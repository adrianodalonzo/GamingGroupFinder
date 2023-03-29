namespace GamingGroupFinder {
    public class User {
        private string username;
        private string password;
        public string Username {get {return username;}}
        public string Password {get {return password;}}

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

        public override string ToString() {
            return username;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) {
                return false;
            }
            if (obj.GetType() == typeof(User)) {
                if (((User)obj).username == this.username && ((User)obj).password == this.password) {
                    return true;
                }
            }
            return false;
        }
    }
}