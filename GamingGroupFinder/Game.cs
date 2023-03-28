namespace GamingGroupFinder {
    public class Game {
        private string game {get;}
        private List<string> availablePlatforms;
        // key 1: rank name. key 2: rank value
        private Tuple<List<string>, List<int>> rank;

        public Game(string game, List<string> platforms, Tuple<List<string>, List<int>> rank) {
            this.game = game;
            this.availablePlatforms = platforms;
            this.rank = rank;
        }
    }
}