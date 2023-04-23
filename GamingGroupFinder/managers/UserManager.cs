namespace GamingGroupFinder {
    public class UserManager {

        // methods:
        // check if they can join an event
        // check if a user can view messages by either them sending a message or recieving one
        private User _loggedInUser;
        public User LoggedInUser{
            get{ return _loggedInUser; }
            set {
                if (value == null){
                    throw new ArgumentNullException("LoggedInUser is null");
                }
                this._loggedInUser = value;
            }
        }

        public UserManager(User user) {
            this.LoggedInUser = user;
        }

        // this is probably just going to create a new user and add it to the database
        public User CreateUser(User u) {
            return null!;
        }

        public void LogInUser(User user) {
            if (user == null){
                throw new ArgumentNullException("user is null");
            }
            this.LoggedInUser = user;
        }

        public void LogOutUser() {
            this.LoggedInUser = null;
        }

        public void ChangePassword(string password) {

        }

        public void DeleteAccount() {
            
        }
    }
}