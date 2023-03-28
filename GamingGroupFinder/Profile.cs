namespace GamingGroupFinder {
    public class Profile {
        private User user;
        private string name;
        private string pronouns;
        private int age;
        private List<string> platforms;
        private List<Game> games;
        private string bio;
        private string profilePicture;
        private List<string> interests;
        public string Name {get {return name;}}
        public string Pronouns {get {return pronouns;}}
        public int Age {get {return age;}}
        public List<string> Platforms {get {return platforms;}}
        public List<Game> Games {get {return games;}}
        public string Bio {get {return bio;}}
        public string ProfilePicture {get {return profilePicture;}}
        public List<string> Interests {get {return interests;}}

        public Profile(User user, string name, string pronouns, int age, List<string> platforms, List<Game> games, string bio, string profilePicture, List<string> interests) {
            this.user = user;
            this.name = name;
            this.pronouns = pronouns;
            this.age = age;
            this.platforms = platforms;
            this.games = games;
            this.bio = bio;
            this.profilePicture = profilePicture;
            this.interests = interests;
        }

        public void ClearData() {
            
        }
    }
}