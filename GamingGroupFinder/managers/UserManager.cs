using GamingGroupFinderDatabase;

namespace GamingGroupFinder {
    public class UserManager {

        // methods:
        // check if they can join an event
        // check if a user can view messages by either them sending a message or recieving one

        private static UserManager? _instance;
        private ApplicationContext _db = null;
        private User _loggedInUser { get; set; }

        private UserManager() {
        }

        public static UserManager GetInstance() {
            if (_instance == null) {
                _instance = new UserManager();
            }
            return _instance;
        }

        public void setApplicationContext(ApplicationContext db) {
            _db = db;
        }

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
            _db.UsersDB.Add(userEntity);
            _db.SaveChanges();
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
            UserDB testUser = (from user in _db.UsersDB where user.Username.Equals(LoggedInUser.Username) select user).Single();
            testUser.Password = password;
            _db.SaveChanges();
        }

        public void DeleteAccount() {
            UserDB testUser = (from user in _db.UsersDB where user.Username.Equals(LoggedInUser.Username) select user).Single();
            _db.UsersDB.Remove(testUser);
            _db.SaveChanges();
        }
    }
}