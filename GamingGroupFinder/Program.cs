using GamingGroupFinder;
using GamingGroupFinderDatabase;

Console.Clear();
Console.WriteLine("Welcome to GamingGroupFinder!");

ApplicationContext db = new ApplicationContext();
UserManager userManager = new UserManager();
ProfileManager profileManager = new ProfileManager();
MessageManager messageManager = new MessageManager();

User u1 = new User("adridalo", "pass", "salt", new List<User>());
User u2 = new User("peter", "pass", "salt", new List<User>());

// userManager.CreateUser(u1);
// userManager.CreateUser(u2);
// userManager.LogInUser(u1);
// Console.WriteLine("User Logged");

// Message m = new Message(u2, u1, DateTime.Now, "i am super good at programming!", false);
// messageManager.CreateMessage(m);
// Console.Write("Messages successfully sent!");

messageManager.MarkMessageSeen(new Message(u2, u1, DateTime.Now, "i am super good at programming!", false));
Console.Write("Message is seen!");
