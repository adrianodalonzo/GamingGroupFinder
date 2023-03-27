using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class MessageTests {
        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            User vince = new User("vince", "vince"); 
            Message msg = new Message(null, vince, DateTime.Now, "a msg", false);
            Assert.Fail();
        }

        [TestMethod]
        public void TestMarkSeen_SetsIsSeenTrue() {
            User vince = new User("vince", "vince");
            User user1 = new User("u1", "you1");
            Message msg = new Message(user1, vince, DateTime.Now, "a msg", false);

            msg.MarkSeen();

            Assert.IsTrue(msg.IsSeen);
        }
    }
}