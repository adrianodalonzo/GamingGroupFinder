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
        byte[] hashedPassword = GenerateHash("dog123", salt);

        User u1 = new User("adridalo", ByteArrayToString(hashedPassword), ByteArrayToString(salt));
        User u2 = new User("bob", ByteArrayToString(hashedPassword), ByteArrayToString(salt));

        List<Platform> u1Platforms = new List<Platform>();
        u1Platforms.Add(new Platform(1, "PC"));
        u1Platforms.Add(new Platform(2, "Nintendo Switch"));

        List<Rank> u1Ranks = new List<Rank>();
        u1Ranks.Add(new Rank(1, 1, "Bronze"));
        u1Ranks.Add(new Rank(2, 3, "Gold"));

        List<Game> u1Games = new List<Game>();
        u1Games.Add(new Game("League of Legends", new List<Platform>(), new List<Rank>()));

        List<Interest> u1Interests = new List<Interest>();
        u1Interests.Add(new Interest(1, "Competitive"));
        u1Interests.Add(new Interest(2, "Casual"));

        Profile p1 = new Profile(u1, "Adriano", "he/him", 19, u1Platforms, u1Games, "Biography", "pic", u1Interests);
        Profile p2 = new Profile(u2, "bob", "they/them", 43, u1Platforms, u1Games, "I have 3 dogs!", "dog_pic", u1Interests);

        List<Platform> gamePlatforms = new List<Platform>();
        gamePlatforms.Add(new Platform("PC"));

        List<Rank> gameRanks = new List<Rank>();
        // create ranks for the game Valorant (just the names and not the numbers (iron not iron 1))
        gameRanks.Add(new Rank(1, "Iron"));
        gameRanks.Add(new Rank(2, "Bronze"));
        gameRanks.Add(new Rank(3, "Silver"));
        gameRanks.Add(new Rank(4, "Gold"));
        gameRanks.Add(new Rank(5, "Platinum"));
        gameRanks.Add(new Rank(6, "Diamond"));
        gameRanks.Add(new Rank(7, "Immortal"));
        gameRanks.Add(new Rank(8, "Radiant"));

        Game game = new Game("Valorant", gamePlatforms, gameRanks);
        Event e1 = new Event("Event 1", DateTime.Now, "Dawson", game, gamePlatforms[0], gameRanks[0], gameRanks[2], "This is a valorant tourny", u1, new List<User>());

        userManager.CreateUser(u1);
        userManager.LogInUser(u1);
        profileManager.CreateProfile(p1, u1);
        eventManager.CreateEvent(e1);
        userManager.LogOutUser();
        Console.WriteLine("User Logged Out");


        // userManager.CreateUser(u2);
        // profileManager.CreateProfile(p2, u2);
        // Message m1 = new Message(u1, u2, DateTime.Now, "You have yourself a great day!", false);
        // messageManager.CreateMessage(m1);
        // Console.WriteLine("Message created!");
        // userManager.CreateUser(u1);
        // Console.WriteLine("user created and logged in.");
        // profileManager.CreateProfile(p1, u1);
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
