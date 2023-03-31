namespace GamingGroupFinder {
    public class Game {
        public string Name{
            get{ return Name; }
            set {
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Name is null");
                }
                this.Name = value;
            }
        }
        public List<string> AvailablePlatforms{
            get{ return AvailablePlatforms; }
            set {
                if (value == null){
                    throw new ArgumentNullException("AvailablePlatforms is null");
                }
                this.AvailablePlatforms = value;
            }
        }
        // key 1: rank name. key 2: rank value
        public Tuple<List<string>, List<int>> Rank{
            get{ return Rank; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Rank is null");
                }
                this.Rank = value;
            }
        }

        public Game(string name, List<string> platforms, Tuple<List<string>, List<int>> rank) {
            if (name == null || platforms == null || rank == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            this.Name = name;
            this.AvailablePlatforms = platforms;
            this.Rank = rank;
        }
    }
}