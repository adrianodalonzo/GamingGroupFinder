using GamingGroupFinderDatabase;

Console.Clear();
Console.WriteLine("Welcome to GamingGroupFinder!");

ApplicationContext db = new ApplicationContext();
User user = new User("adriano", "pass", "salt", null);
List<Event> events = new List<Event>();
events.Add(new Event(user, "Event 1", DateTime.Now, "here", new Game("Game 1"), new Platform("PC"), new Rank(1, "Gold"), new Rank(3, "Master"), "desc"));
user.Profile = new Profile(user, "Adriano", "he/him", 19, "I like to play games", "https://i.imgur.com/0Y4Z4Z0.jpg");
user.Profile.Platforms.Add(new Platform("Nintendo Switch"));
Game game = new Game("Splatoon 2");
user.Profile.Games.Add(game);
user.EventsAttending = events;
db.Add(user);
db.Add(user.Profile);
db.SaveChanges();
Console.WriteLine("User added");