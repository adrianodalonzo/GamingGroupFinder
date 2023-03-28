namespace GamingGroupFinder {
    public class Game {
        private string game {get;}
        private List<string> availablePlatforms;
        private List<string> rank;

        public Game(string game, List<string> platforms, List<string> rank) {
            this.game = game;
            this.availablePlatforms = platforms;
            this.rank = rank;
        }
    }
}