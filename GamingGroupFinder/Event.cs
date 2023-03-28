namespace GamingGroupFinder {
    public class Event {
        private string title {get;set;}
        private DateTime dateTime {get;set;}
        private string location {get;set;}
        private Game game {get;set;}
        private Platform platform {get;set;}
        private string rank {get;set;}
        private string description {get;set;}
        private User owner {get;set;}
        private List<User> attendees {get;set;}
        public List<User> Attendees {get {return attendees;}}

        public Event(string title, DateTime dateTime, string location, Game game, Platform platform, string rank, string description, User owner, List<User> attendees) {
            this.title = title;
            this.dateTime = DateTime.Now;
            this.location = location;
            this.game = game;
            this.platform = platform;
            this.rank = rank;
            this.description = description;
            this.owner = owner;
            this.attendees = attendees;
        }

        public void AttendEvent(User user) {
            this.attendees.Add(user);
        }

        public void LeaveEvent(User user) {
            this.attendees.Remove(user);
        }

        public string ViewAttendees() {
            string builder = "";
            foreach (User user in attendees) {
                builder += user.ToString();
                builder += ", ";
            }
            return builder;
        }
    }
}