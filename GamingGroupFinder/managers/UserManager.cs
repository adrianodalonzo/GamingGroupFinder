using GamingGroupFinderDatabase;

namespace GamingGroupFinder {
    public class UserManager {

        // methods:
        // check if they can join an event
        // check if a user can view messages by either them sending a message or recieving one

        private static UserManager? _instance;
        private static ApplicationContext db = null!;
        private User _loggedInUser;
        public User LoggedInUser{
            get{ return _loggedInUser; }
            set { this._loggedInUser = value; }
        }

        private UserManager() {

        }

        public static UserManager GetInstance() {
            if(_instance == null) {
                _instance = new UserManager();
            }
            return _instance;
        }

        public void SetApplicationContext(ApplicationContext context) {
            db = context;
        }

        public static List<UserDB> GetListOfUsers() {
            List<UserDB> users = db.UsersDB.ToList();
            return users;
        }

        private static bool UserExists(User user, List<UserDB> users) {
            foreach(UserDB testUser in users) {
                if(testUser.Username.Equals(user.Username)) {
                    return true;
                }
            }
            return false;
        }

        // this is probably just going to create a new user and add it to the database
        public void CreateUser(User u) {
            // add checking for an existing user
            if(UserExists(u, GetListOfUsers())) {
                throw new Exception("User already exists!");
            }
            UserDB userEntity = new UserDB(u.Username, u.Password, u.Salt, null);
            db.Add(userEntity);
            db.SaveChanges();
            this.LoggedInUser = u;
        }

        public void LogInUser(User user) {
            if (user == null){
                throw new ArgumentNullException("user is null");
            }
            try {
                if(LoggedInUser.Username.Equals(user.Username)) {
                    throw new Exception("This user is already logged in!");
                }
            } catch (NullReferenceException) {
                // this is fine, it just means that no one is logged in
                this.LoggedInUser = user;
            }
        }

        public void LogOutUser() {
            if(LoggedInUser == null) {
                throw new Exception("User is already logged out/never logged in!");
            }
            this.LoggedInUser = null;
        }

        public void ChangePassword(string password) {
            UserDB testUser = (from user in db.UsersDB where user.Username.Equals(LoggedInUser.Username) select user).SingleOrDefault();
            if(testUser == null) {
                throw new NullReferenceException("User could not be found!");
            }
            if(LoggedInUser.Username.Equals(testUser.Username)) {
                if(testUser.Password.Equals(password)) {
                    throw new ArgumentException("New password must not match old password!");
                }
                testUser.Password = password;
                db.SaveChanges();
            } else {
                throw new Exception("Only the user of the requested account may change their password!");
            }
        }

        public void DeleteAccount() {
            UserDB testUser = (from user in db.UsersDB where user.Username.Equals(LoggedInUser.Username) select user).SingleOrDefault();
            if(testUser == null) {
                throw new NullReferenceException("There is no user which exists following the criteria of the logged in user!");
            }
            if(LoggedInUser.Username.Equals(testUser.Username)) {
                db.UsersDB.Remove(testUser);
                db.SaveChanges();
            } else {
                throw new Exception("Only the user of the requested account may delete their account!");
            }
        }

        public void DeleteAccount(User u) {
            if(u == null) {
                throw new NullReferenceException("User inputed can't be null!");
            }
            UserDB testUser = (from user in db.UsersDB where user.Username.Equals(u.Username) select user).SingleOrDefault();
            if(testUser == null) {
                throw new NullReferenceException("No user can be found with the user you inputed!");
            }
            if(LoggedInUser.Username.Equals(testUser.Username)) {
                db.UsersDB.Remove(testUser);
                db.SaveChanges();
            } else {
                throw new Exception("Only the user of the requested account may delete their account!");
            }
        }
    }
}