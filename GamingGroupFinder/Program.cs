// using GamingGroupFinder;
// using GamingGroupFinderDatabase;
// using System.Security.Cryptography;

// public class Program {

// <<<<<<< HEAD
// ApplicationContext db = new ApplicationContext();
// // UserManager userManager = new UserManager();
// ProfileManager profileManager = new ProfileManager();
// =======
//     public static void Main(string[] args) {
// >>>>>>> f091c9655bb96bbcb17450a7c8664061c0dd68cb

//         Console.Clear();
//         Console.WriteLine("Welcome to GamingGroupFinder!");

//         ApplicationContext db = new ApplicationContext();
//         UserManager userManager = UserManager.GetInstance();
//         userManager.SetApplicationContext(db);
//         ProfileManager profileManager = ProfileManager.GetInstance();
//         profileManager.SetApplicationContext(db);
//         MessageManager messageManager = MessageManager.GetInstance();
//         EventManager eventManager = EventManager.GetInstance();

//         var salt = GenerateSalt();
//         var password = GenerateHash("password", salt);
//         User u = new User("adridalo", ByteArrayToString(password), ByteArrayToString(salt), new List<User>());
//         // userManager.CreateUser(u);
//         // list of platforms
//         List<Platform> platforms = new List<Platform>();
//         platforms.Add(new Platform("PC"));
//         platforms.Add(new Platform("Xbox"));
//         platforms.Add(new Platform("Playstation"));

//         //list of games
//         List<Game> games = new List<Game>();
//         games.Add(new Game("League of Legends"));
//         games.Add(new Game("Valorant"));
//         games.Add(new Game("Overwatch"));

//         //list of interests
//         List<Interest> interests = new List<Interest>();
//         interests.Add(new Interest("Competitive"));
//         interests.Add(new Interest("Casual"));
//         interests.Add(new Interest("Co-op"));

//         // userManager.LogInUser(user1);
//         // userManager.ChangePassword("test");
//         // Console.Write("User password changed");
//         Profile p = new Profile(u, "Adriano", "he/him", 19, platforms, games, "bio", "link", interests);
//         profileManager.CreateProfile(p, u);
        
//     }

//     private static byte[] GenerateSalt() {
//         byte[] salt = new byte[8];
//         using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider()) {
//             rngCsp.GetBytes(salt);
//         }
//         return salt;
//     }

//     private static byte[] GenerateHash(string password, byte[] salt) {
//         int numIterations = 1000;
//         Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, numIterations);
//         return key.GetBytes(32);
//     }

//     private static string ByteArrayToString(byte[] array) {
//         string ByteString = "";
//         foreach(byte val in array) {
//             ByteString += val;
//         }
//         return ByteString;
//     }

// }
