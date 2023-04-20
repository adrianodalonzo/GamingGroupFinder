namespace GamingGroupFinder {
    public class Event {
        public string Title{
            get{ return Title; }
            set {
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Title is null");
                }
                this.Title = value;
            }
        }
        public DateTime DateTime{
            get{ return DateTime; }
            set {
                if (value == null) {
                    throw new ArgumentNullException("Date is null");
                }
                _ = value;
            }
        }
        public string Location{
            get{ return Location; }
            set {
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Location is null");
                }
                this.Location = value;
            }
        }
        public Game Game{
            get{ return Game; }
            set {
                if (value == null){
                    throw new ArgumentNullException("Game is null");
                }
                this.Game = value;
            }
        }
        public string Platform {
            get{return Platform;} 
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Platform is null");
                }
                this.Platform = value;
            }
        }
        public string Rank {
            get{return Rank;} 
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Rank is null");
                }
                this.Rank = value;
            }
        }
        public string Description {
            get{return Description;} 
            set{
                if (string.IsNullOrEmpty(value)){
                    throw new ArgumentNullException("Description is null");
                }
                this.Description = value;
            }
        }
        public User Owner {
            get{ return Owner; }
            set {
                if (value == null) {
                    throw new ArgumentNullException("Owner is null");
                }
                _ = value;
            }
        }
        public List<User> Attendees {
            get{ return Attendees; }
            set {
                if (value == null) {
                    throw new ArgumentNullException("Attendees is null");
                }
                _ = value;
            }
        }

        public Event(string title, DateTime dateTime, string location, Game game, string platform, string rank, string description, User owner, List<User> attendees) {
            if (title == null || dateTime == null || location == null || game == null || platform == null || rank == null || description == null || owner == null || attendees == null){
                throw new ArgumentNullException("one or multiple of the input is null");
            }
            this.Title = title;
            this.DateTime = dateTime;
            this.Location = location;
            this.Game = game;
            this.Platform = platform;
            this.Rank = rank;
            this.Description = description;
            this.Owner = owner;
            this.Attendees = attendees;
        }
    }
}