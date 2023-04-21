using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class GameTests {
        public static List<Platform> CreateListPlatforms() {
            List<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform(1, "PC"));
            platforms.Add(new Platform(2, "NINTENDO SWITCH"));

            return platforms;
        }

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

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            List<Platform> platforms = CreateListPlatforms();
            Game splatoon = new Game(null, platforms, GameSplatoonRanks());
            Assert.Fail();
        }
    }
}