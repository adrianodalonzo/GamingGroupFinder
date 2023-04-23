using GamingGroupFinder;
using GamingGroupFinderDatabase;

Console.Clear();
Console.WriteLine("Welcome to GamingGroupFinder!");

ApplicationContext db = new ApplicationContext();
UserManager userManager = new UserManager();
ProfileManager profileManager = new ProfileManager();

User user1 = new User("user1", "password", "salt", new List<User>());
Profile profile1 = new Profile(user1, "user1", "pro", 11, new List<Platform>(), new List<Game>(), "bio", "pic", new List<Interest>());

// userEntity.Profile = profile1;

// Event event1Object = new Event("event1", DateTime.Now, "here", new Game("Rocket League", new List<Platform>(), new List<Rank>()), new Platform(1, "plat"), new Rank(1,1,"rank1"), new Rank(2,2,"rank2"), "desc", user1Object, new List<User>());
// EventDB eventEntity = new EventDB(userEntity, event1Object.Title, event1Object.DateTime, event1Object.Location, new GameDB(event1Object.Game.Name), new PlatformDB(event1Object.Platform.Name), new RankDB(event1Object.MinRank.RankValue, event1Object.MinRank.RankName), new RankDB(event1Object.MaxRank.RankValue, event1Object.MaxRank.RankName), event1Object.Description);

// userEntity.EventsOwned.Add(eventEntity);

// userManager.CreateUser(user1);
// profileManager.CreateProfile(profile1, user1);
// Console.Write("User added");

userManager.LogInUser(user1);
userManager.ChangePassword("test");
Console.Write("User password changed");














// User user = new User("adriano", "pass", "salt", null);
// List<Event> events = new List<Event>();
// events.Add(new Event(user, "Event 1", DateTime.Now, "here", new Game("Game 1"), new Platform("PC"), new Rank(1, "Gold"), new Rank(3, "Master"), "desc"));
// user.Profile = new Profile(user, "Adriano", "he/him", 19, "I like to play games", "https://i.imgur.com/0Y4Z4Z0.jpg");
// user.Profile.Platforms.Add(new Platform("Nintendo Switch"));
// Game game = new Game("Splatoon 2");
// user.Profile.Games.Add(game);
// user.EventsAttending = events;
// db.Add(user);
// db.Add(user.Profile);
// db.SaveChanges();
// Console.WriteLine("User added");