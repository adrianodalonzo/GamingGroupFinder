using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class PlatformTests {
        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            Platform platform = new Platform(null);
            Assert.Fail();
        }
    }
}