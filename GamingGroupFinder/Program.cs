using GamingGroupFinderDatabase;

Console.WriteLine("Welcome to GamingGroupFinder!");

ApplicationContext db = new ApplicationContext();
User user = new User();
user.Username = "Test";
user.UserId = 1;
user.Salt = "134jidkfgjdf";
user.Password = "jhfsd76y79n2b3b5bbjn`l;";
user.EventsAttending = new List<Event>();
user.EventsOwned = new List<Event>();

Profile profile = new Profile();
profile.Age = 19;
profile.Bio = "bio";
profile.Name = "Test";
profile.ProfileId = 1;
profile.ProfilePicture = "link";
profile.Pronouns = "they/them";
profile.User = user;

user.Profile = profile;
db.Add(user);
db.SaveChanges();
Console.WriteLine("User added");