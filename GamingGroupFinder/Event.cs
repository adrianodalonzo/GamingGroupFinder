namespace GamingGroupFinder {
    public class Event {
        private string _title;
        public string Title{
            get{ return _title; }
            set {
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Title is null");
                }
                this._title = value;
            }
        }
        private DateTime _dateTime;
        public DateTime DateTime{
            get{ return _dateTime; }
            set {
                if (value == null) {
                    throw new ArgumentNullException("Date is null");
                }
                _dateTime = value;
            }
        }
        private string _location;
        public string Location{
            get{ return _location; }
            set {
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Location is null");
                }
                this._location = value;
            }
        }
        private Game _game;
        public Game Game{
            get{ return _game; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Game is null");
                }
                this._game = value;
            }
        }
        private string _platform;
        public string Platform {
            get{return _platform;} 
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Platform is null");
                }
                this._platform = value;
            }
        }
        private Rank _minRank;
        public Rank MinRank {
            get{return _minRank;} 
            set{
                if (value == null){
                    throw new ArgumentNullException("Rank is null");
                }
                this._minRank = value;
            }
        }
        private Rank _maxRank;
        public Rank MaxRank {
            get{return _maxRank;} 
            set{
                if (value == null){
                    throw new ArgumentNullException("Rank is null");
                }
                this._maxRank = value;
            }
        }
        private string _description;
        public string Description {
            get{return _description;} 
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Description is null");
                }
                this._description = value;
            }
        }
        private User _owner;
        public User Owner {
            get{ return _owner; }
            set {
                if (value == null) {
                    throw new ArgumentNullException("Owner is null");
                }
                _owner = value;
            }
        }
        private List<User> _attendees;
        public List<User> Attendees {
            get{ return _attendees; }
            set {
                if (value == null) {
                    throw new ArgumentNullException("Attendees is null");
                }
                _attendees = value;
            }
        }

        public Event(string title, DateTime dateTime, string location, Game game, string platform, Rank minRank, Rank maxRank, string description, User owner, List<User> attendees) {
            if (title == null || dateTime == null || location == null || game == null || platform == null || minRank == null || maxRank == null || description == null || owner == null || attendees == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            this.Title = title;
            this.DateTime = dateTime;
            this.Location = location;
            this.Game = game;
            this.Platform = platform;
            this.MinRank = minRank;
            this.MaxRank = maxRank;
            this.Description = description;
            this.Owner = owner;
            this.Attendees = attendees;
        }
    }
}