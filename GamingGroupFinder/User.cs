namespace GamingGroupFinder {
    public class User {
        public string Username {get {return Username;} 
            set{
                    if (string.IsNullOrEmpty(value)){
                        throw new ArgumentNullException("Username is null");
                    }
                    this.Username = value;
            }
        }
        public string Password {get {return Password;}
            set{
                    if (string.IsNullOrEmpty(value)){
                        throw new ArgumentNullException("Password is null");
                    }
                    this.Password = value;
            }
        }
        public List<User> ContactList {get {return ContactList;}
            set{
                    if (value == null){
                        throw new ArgumentNullException("ContactList is null");
                    }
                    this.ContactList = value;
            }
        }

        public User(string username, string password, List<User> contactList) {
            if(username == null || password == null || contactList == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            this.Username = username;
            this.Password = password;
            this.ContactList = contactList;
        }

        public bool VerifyUser(string username, string password) {
            if(username == null || password == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            return false;
        }   

        public void AddToContacts(string userName) {
            // add checking for seeing if user exists in database
            if(userName == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
        }

        public void ChangePassword(string newPassword) {
            if(newPassword == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            this.Password = newPassword;
        }

        public void DeleteAccount() {
            
        }

        public override string ToString() {
            return Username;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) {
                return false;
            }
            if (obj.GetType() == typeof(User)) {
                if (((User)obj).Username == this.Username && ((User)obj).Password == this.Password) {
                    return true;
                }
            }
            return false;
        }
    }
}