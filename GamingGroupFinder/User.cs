namespace GamingGroupFinder {
    public class User {
        private string username;
        private string password;
        private List<User> contactList;
        public string Username {get {return username;}}
        public string Password {get {return password;}}
        public List<User> ContactList {get {return contactList;}}

        public User(string username, string password, List<User> contactList) {
            this.username = username;
            this.password = password;
            this.contactList = contactList;
        }

        public bool VerifyUser(string username, string password) {
            return false;
        }   

        public void AddToContacts(string userName) {
            // add checking for seeing if user exists in database
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