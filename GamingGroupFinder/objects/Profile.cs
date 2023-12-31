namespace GamingGroupFinder {
    public class Profile {
        private User _user;
        public User User {
            get{ return _user; }
            set {
                if (value == null) {
                    throw new ArgumentNullException("User is null");
                }
                _user = value;
            }
        }
        private string _name;
        public string Name {get {return _name;}
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Name is null");
                }
                this._name = value;
            }
        }
        private string _pronouns;
        public string Pronouns {get {return _pronouns;}
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Pronouns are null");
                }
                this._pronouns = value;
            }
        }
        private int _age;
        public int Age {get {return _age;}
            set{
                if (value <= 0){
                    throw new ArgumentNullException("Age is not in acceptable range (can't be negative)");
                }
                this._age = value;
            }
        }
        private List<Platform> _platforms;
        public List<Platform> Platforms{
            get{ return _platforms; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Platforms are null");
                }
                this._platforms = value;
            }
        }
        private List<Game> _games;
        public List<Game> Games {get {return _games;}
            set{
                if (value == null){
                    throw new ArgumentNullException("Games is null");
                }
                this._games = value;
            }
        }
        private string _bio;
        public string Bio {get {return _bio;}
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Bio is null");
                }
                this._bio = value;
            }
        }
        private string _profilePicture;
        public string ProfilePicture {get {return _profilePicture;}
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("ProfilePicture is null");
                }
                this._profilePicture = value;
            }
        }
        private List<Interest> _interests;
        public List<Interest> Interests {get {return _interests;}
            set{
                if (value == null){
                    throw new ArgumentNullException("Interests is null");
                }
                this._interests = value;
            }
        }

        public Profile(User user, string name, string pronouns, int age, List<Platform> platforms, List<Game> games, string bio, string profilePicture, List<Interest> interests) {
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

        public Profile(User user) {
            this.User = user;
        }
        private Profile() {
        }

        public void ClearData() {
            this.Name = " ";
            this.Pronouns = " ";
            this.Age = 1;
            this.Platforms = new List<Platform>();
            this.Games = new List<Game>();
            this.Bio = " ";
            this.ProfilePicture = " ";
            this.Interests = new List<Interest>();
        }

        public override string ToString() {
            string PlatformsString = "";
            foreach(Platform platform in Platforms) {
                PlatformsString += $"{platform}, ";
            }
            string GamesString = "";
            foreach(Game game in Games) {
                GamesString += $"{game.Name}, ";
            }
            string InterestsString = "";
            foreach(Interest interest in Interests) {
                InterestsString += $"{interest}, ";
            }
            return $"{User}:\n\t{Pronouns}\n\t{Age} years old\n\tPlays on {PlatformsString}\n\tPlays {GamesString}\n\tBio: {Bio}\n\tOther interests: {InterestsString}";
        }
    }
}