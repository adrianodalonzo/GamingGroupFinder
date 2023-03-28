using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class GameTests {
        public static List<string> CreateListPlatforms() {
            List<string> platforms = new List<string>();
            platforms.Add("PC");
            platforms.Add("NINTENDO SWITCH");

            return platforms;
        }

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

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            List<string> platforms = CreateListPlatforms();
            Game splatoon = new Game(null, platforms, GameSplatoonRanks());
            Assert.Fail();
        }
    }
}