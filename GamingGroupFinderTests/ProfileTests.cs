using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class ProfileTests {
        public static List<Rank> GameSplatoonRanks() {
            Rank am = new Rank(1, 1, "A-");
            Rank a = new Rank(2, 2, "A");
            Rank ap = new Rank(3, 3, "A+");

            List<Rank> ranks = new List<Rank>();
            ranks.Add(am);
            ranks.Add(a);
            ranks.Add(ap);

            return ranks;
        }

        public static List<Rank> GameValorantRanks() {
            Rank bronze = new Rank(4, 1, "BRONZE");
            Rank silver = new Rank(5, 2, "SILVER");
            Rank gold = new Rank(6, 3, "GOLD");

            List<Rank> ranks = new List<Rank>();
            ranks.Add(bronze);
            ranks.Add(silver);
            ranks.Add(gold);

            return ranks;
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            User vince = new User("vince", "vince", "salt", new List<User>());
            Profile profile = new Profile(vince, "Vince", "hehim", 18, null, null, "uhhhhhh", "some link", null);
            Assert.Fail();
        }

        [TestMethod]
        public void TestClearData_Clears() {
            User vince = new User("vince", "vince", "salt", new List<User>());

            List<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform(1, "PC"));
            platforms.Add(new Platform(2, "NINTENDO SWITCH"));

            List<Game> games = new List<Game>();
            games.Add(new Game("Splatoon 3", platforms, GameSplatoonRanks()));
            games.Add(new Game("Brawlhalla", platforms, GameValorantRanks()));

            List<Interest> interests = new List<Interest>();
            interests.Add(new Interest(1, "MUSIC"));
            interests.Add(new Interest(1, "READING"));
            interests.Add(new Interest(1, "BIKING"));

            Profile profile = new Profile(vince, "Vince", "hehim", 18, platforms, games, "uhhhhhh", "some link", interests);
            // Profile profile = new Profile(vince, "", "", 0, platforms, games, "", "", interests);
            
            profile.ClearData();

            bool isCleared = true;

            if (profile.Name != "") isCleared = false;
            else if (profile.Pronouns != "") isCleared = false;
            else if (profile.Age != 0) isCleared = false;
            else if (profile.Platforms.Count != 0) isCleared = false;
            else if (profile.Games.Count != 0) isCleared = false;
            else if (profile.Bio != "") isCleared = false;
            else if (profile.ProfilePicture != "") isCleared = false;
            else if (profile.Interests.Count != 0) isCleared = false;

            Assert.IsTrue(isCleared);
        }
    }
}