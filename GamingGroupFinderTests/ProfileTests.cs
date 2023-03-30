using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class ProfileTests {
        public static Tuple<List<string>, List<int>> GameSplatoonRanks() {
            List<string> splatoonRanks = new List<string>();
            splatoonRanks.Add("A-");
            splatoonRanks.Add("A");
            splatoonRanks.Add("A+");

            List<int> splatoonRankValues = new List<int>();
            splatoonRankValues.Add(1);
            splatoonRankValues.Add(2);
            splatoonRankValues.Add(3);

            return new Tuple<List<string>, List<int>>(splatoonRanks, splatoonRankValues);
        }

        public static Tuple<List<string>, List<int>> GameValorantRanks() {
            List<string> valorantRanks = new List<string>();
            valorantRanks.Add("BRONZE");
            valorantRanks.Add("SILVER");
            valorantRanks.Add("GOLD");

            List<int> valorantRankValues = new List<int>();
            valorantRankValues.Add(1);
            valorantRankValues.Add(2);
            valorantRankValues.Add(3);

            return new Tuple<List<string>, List<int>>(valorantRanks, valorantRankValues);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            User vince = new User("vince", "vince");
            Profile profile = new Profile(vince, "Vince", "hehim", 18, null, null, "uhhhhhh", "some link", null);
            Assert.Fail();
        }

        [TestMethod]
        public void TestClearData_Clears() {
            User vince = new User("vince", "vince");

            List<string> platforms = new List<string>();
            platforms.Add("PC");
            platforms.Add("NINTENDO SWITCH");

            List<Game> games = new List<Game>();
            games.Add(new Game("Splatoon 3", platforms, GameSplatoonRanks()));
            games.Add(new Game("Brawlhalla", platforms, GameValorantRanks()));

            List<string> interests = new List<string>();
            interests.Add("MUSIC");
            interests.Add("READING");
            interests.Add("BIKING");

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