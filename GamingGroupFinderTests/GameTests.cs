using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class GameTests {
        public static List<Platform> CreateListPlatforms() {
            List<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform("PC"));
            platforms.Add(new Platform("XBOX"));

            return platforms;
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            List<Platform> platforms = CreateListPlatforms();
            Game valorant = new Game(null, platforms, "GOLD");
            Assert.Fail();
        }
    }
}