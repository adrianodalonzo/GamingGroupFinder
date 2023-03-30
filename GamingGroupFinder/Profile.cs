namespace GamingGroupFinder {
    public class Profile {
        public User User {
            get{ return User; }
            set {
                if (value == null) {
                    throw new ArgumentNullException("User is null");
                }
                _ = value;
            }
        }
        public string Name {get {return Name;}
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Name is null");
                }
                this.Name = value;
            }
        }
        public string Pronouns {get {return Pronouns;}
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Description is null");
                }
                this.Pronouns = value;
            }
        }
        public int Age {get {return Age;}
            set{
                if (value <= 0){
                    throw new ArgumentNullException("Age is not in acceptable range (can't be negative)");
                }
                this.Age = value;
            }
        }
        public List<string> Platforms {get {return Platforms;}
            set{
                if (value == null){
                    throw new ArgumentNullException("Platforms is null");
                }
                this.Platforms = value;
            }
        }
        public List<Game> Games {get {return Games;}
            set{
                if (value == null){
                    throw new ArgumentNullException("Games is null");
                }
                this.Games = value;
            }
        }
        public string Bio {get {return Bio;}
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Bio is null");
                }
                this.Bio = value;
            }
        }
        public string ProfilePicture {get {return ProfilePicture;}
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("ProfilePicture is null");
                }
                this.ProfilePicture = value;
            }
        }
        public List<string> Interests {get {return Interests;}
            set{
                if (value == null){
                    throw new ArgumentNullException("Interests is null");
                }
                this.Interests = value;
            }
        }

        public Profile(User user, string name, string pronouns, int age, List<string> platforms, List<Game> games, string bio, string profilePicture, List<string> interests) {
            if(user == null || name == null || pronouns == null || platforms == null || games == null || bio == null || profilePicture == null || interests == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            this.User = user;
            this.Name = name;
            this.Pronouns = pronouns;
            this.Age = age;
            this.Platforms = platforms;
            this.Games = games;
            this.Bio = bio;
            this.ProfilePicture = profilePicture;
            this.Interests = interests;
        }

        public void ClearData() {
            
        }
    }
}