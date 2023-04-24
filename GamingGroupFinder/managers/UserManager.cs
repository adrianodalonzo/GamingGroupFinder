using GamingGroupFinderDatabase;

namespace GamingGroupFinder {
    public class UserManager {

        // methods:
        // check if they can join an event
        // check if a user can view messages by either them sending a message or recieving one

        private ApplicationContext db = new ApplicationContext();
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

        // this is probably just going to create a new user and add it to the database
        public void CreateUser(User u) {
            // add checking for an existing user
            UserDB userEntity = new UserDB(u.Username, u.Password, u.Salt, null);
            db.UsersDB.Add(userEntity);
            db.SaveChanges();
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
            UserDB testUser = (from user in db.UsersDB where user.Username.Equals(LoggedInUser.Username) select user).Single();
            testUser.Password = password;
            db.SaveChanges();
        }

        public void DeleteAccount() {
            UserDB testUser = (from user in db.UsersDB where user.Username.Equals(LoggedInUser.Username) select user).Single();
            db.UsersDB.Remove(testUser);
            db.SaveChanges();
        }
    }
}