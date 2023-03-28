namespace GamingGroupFinder {
    public class User {
        private string username {get;}
        private string password;
        private List<User> contactList;

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
    }
}