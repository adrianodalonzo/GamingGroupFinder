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
        private List<Platform> _availablePlatforms;
        public List<Platform> AvailablePlatforms{
            get{ return _availablePlatforms; }
            set {
                if (value == null){
                    throw new ArgumentNullException("AvailablePlatforms is null");
                }
                this._availablePlatforms = value;
            }
        }
        // key 1: rank name. key 2: rank value
        private List<Rank> _ranks;
        public List<Rank> Ranks{
            get{ return _ranks; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Rank is null");
                }
                this._ranks = value;
            }
        }

        public Game(string name, List<Platform> platforms, List<Rank> ranks) {
            if (name == null || platforms == null || ranks == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            this.Name = name;
            this.AvailablePlatforms = platforms;
            this.Ranks = ranks;
        }
        private Game(){
        }
    }
}