using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class ProfileTests {
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

            List<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform("PC"));
            platforms.Add(new Platform("NINTENDO SWITCH"));

            List<Game> games = new List<Game>();
            games.Add(new Game("Splatoon 3", platforms, "A+"));
            games.Add(new Game("Brawlhalla", platforms, "SILVER"));

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