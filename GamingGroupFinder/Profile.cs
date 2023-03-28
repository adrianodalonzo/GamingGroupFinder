namespace GamingGroupFinder {
    public class Profile {
        private User user;
        private string name {get;set;}
        private string pronouns {get;set;}
        private int age;
        private List<string> platforms {get;set;}
        private List<Game> games {get;set;}
        private string bio {get;set;}
        private string profilePicture {get;set;}
        private List<string> interests {get;set;}

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