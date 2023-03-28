namespace GamingGroupFinder {
    public class Game {
        private string game {get;}
        private List<Platform> availablePlatforms;
        private string rank;

        public Game(string game, List<Platform> platforms, string rank) {
            this.game = game;
            this.availablePlatforms = platforms;
            this.rank = rank;
        }
    }
}