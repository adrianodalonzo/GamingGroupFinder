namespace GamingGroupFinder {
    public class Manager {

        // methods:
        // check if they can join an event
        // check if a user can view messages by either them sending a message or recieving one
        private User loggedInUser;

        public void SetLoggedInUser(User user) {
            this.loggedInUser = user;
        }
    }
}