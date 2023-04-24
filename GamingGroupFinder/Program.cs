using GamingGroupFinder;
using GamingGroupFinderDatabase;
using System.Security.Cryptography;

public class Program {

    public static void Main(string[] args) {

        Console.Clear();
        Console.WriteLine("Welcome to GamingGroupFinder!");

        ApplicationContext db = new ApplicationContext();
        UserManager userManager = new UserManager();
        ProfileManager profileManager = new ProfileManager();
        MessageManager messageManager = new MessageManager();
        EventManager eventManager = new EventManager();

        byte[] salt = GenerateSalt();
        byte[] hashedPassword = GenerateHash("password", salt);

        User u1 = new User("adridalo", ByteArrayToString(hashedPassword), ByteArrayToString(salt));

        List<Platform> u1Platforms = new List<Platform>();
        u1Platforms.Add(new Platform(1, "PC"));
        u1Platforms.Add(new Platform(2, "Nintendo Switch"));

        List<Rank> u1Ranks = new List<Rank>();
        u1Ranks.Add(new Rank(1, 1, "bronze"));
        u1Ranks.Add(new Rank(2, 3, "gold"));

        List<Game> u1Games = new List<Game>();
        u1Games.Add(new Game("WWE2k23", u1Platforms, u1Ranks));

        List<Interest> u1Interests = new List<Interest>();
        u1Interests.Add(new Interest(1, "Competitive"));
        u1Interests.Add(new Interest(2, "Casual"));

        Profile p1 = new Profile(u1, "Adriano", "he/him", 19, u1Platforms, u1Games, "Biography", "pic", u1Interests);
        Event e1 = new Event("Event 1", DateTime.Now, "Dawson College", new Game("League of Legends", new List<Platform>(), new List<Rank>()), new Platform(1, "PC"), new Rank(2, "Bronze"), new Rank(4, "Gold"), "This is a description of the event!", u1, new List<User>());
        // User u2 = new User("peter", ByteArrayToString(hashedPassword), ByteArrayToString(salt), new List<User>());
        // Profile p2 = new Profile(u2, "Bob", "they/them", 22, new List<Platform>(), new List<Game>(), "Bio2", "pic", new List<Interest>());

        // userManager.CreateUser(u1);
        // userManager.LogInUser(u1);
        // profileManager.CreateProfile(p1, u1);
        // eventManager.CreateEvent(e1);
        // userManager.LogOutUser();
        // Console.WriteLine("User Logged Out");

        
        // userManager.CreateUser(u2);
        // profileManager.CreateProfile(p2, u2);
        // userManager.LogInUser(u1);
        // Console.WriteLine("User Logged In");

        // eventManager.CreateEvent(e1);
        // Console.WriteLine("Event Created!");

        // profileManager.CreateProfile(p1, u1);
        // Console.WriteLine("Profile Created!");

        // Message m = new Message(u2, u1, DateTime.Now, "i am super good at programming!", false);
        // messageManager.CreateMessage(m);
        // Console.Write("Messages successfully sent!");

        // messageManager.MarkMessageSeen(new Message(u2, u1, DateTime.Now, "i am super good at programming!", false));
        // Console.Write("Message is seen!");
        
    }

    private static byte[] GenerateSalt() {
        byte[] salt = new byte[8];
        using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider()) {
            rngCsp.GetBytes(salt);
        }
        return salt;
    }

    private static byte[] GenerateHash(string password, byte[] salt) {
        int numIterations = 1000;
        Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, numIterations);
        return key.GetBytes(32);
    }

    private static string ByteArrayToString(byte[] array) {
        string ByteString = "";
        foreach(byte val in array) {
            ByteString += val;
        }
        return ByteString;
    }

}
