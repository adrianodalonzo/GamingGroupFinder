namespace GamingGroupFinder {
    public class Manager {

        // methods:
        // check if they can join an event
        // check if a user can view messages by either them sending a message or recieving one
        public User LoggedInUser{
            get{ return LoggedInUser; }
            set {
                if (value == null){
                    throw new ArgumentNullException("LoggedInUser is null");
                }
                this.LoggedInUser = value;
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