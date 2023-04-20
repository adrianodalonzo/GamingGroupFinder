namespace GamingGroupFinder {
    public class Manager {

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

        public void SetLoggedInUser(User user) {
            if (user == null){
                throw new ArgumentNullException("user is null");
            }
            this.LoggedInUser = user;
        }
    }
}