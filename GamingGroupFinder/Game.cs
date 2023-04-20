namespace GamingGroupFinder {
    public class Game {
        private string _name;
        public string Name{
            get{ return _name; }
            set {
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Name is null");
                }
                this._name = value;
            }
        }
        private List<string> _availablePlatforms;
        public List<string> AvailablePlatforms{
            get{ return _availablePlatforms; }
            set {
                if (value == null){
                    throw new ArgumentNullException("AvailablePlatforms is null");
                }
                this._availablePlatforms = value;
            }
        }
        // key 1: rank name. key 2: rank value
        private List<Rank> _rank;
        public List<Rank> Rank{
            get{ return _rank; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Rank is null");
                }
                this._rank = value;
            }
        }

        public Game(string name, List<string> platforms, List<Rank> rank) {
            if (name == null || platforms == null || rank == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            this.Name = name;
            this.AvailablePlatforms = platforms;
            this.Rank = rank;
        }
        private Game(){
        }
    }
}