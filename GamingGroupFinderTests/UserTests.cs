using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class UserTests {
        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            User user = new User(null, "password", new List<User>());

            Assert.Fail();
        }

        [TestMethod]
        public void TestVerifyUser_ReturnsCorrect() {
            User vince = new User("vince", "vince", new List<User>());

            Assert.IsTrue(vince.VerifyUser("vince", "vince"));
        }

        [TestMethod]
        public void TestVerifyUser_ReturnsIncorrect() {
            User vince = new User("vince", "vince", new List<User>());

            Assert.IsFalse(vince.VerifyUser("vince", "totallyVince"));
        }

        [TestMethod]
        public void TestChangePassword_ChangesPassword() {
            User vince = new User("vince", "vince", new List<User>());

            vince.ChangePassword("thunder");

            Assert.AreEqual("thunder", vince.Password);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestChangePassword_ThrowsWhenGivenNull() {
            User vince = new User("vince", "vince", new List<User>());

            vince.ChangePassword(null);
            
            Assert.Fail();
        }

        [TestMethod]
        public void TestEquals_ReturnsCorrect() {
            User vince = new User("vince", "vince", new List<User>());
            User maybeVince = new User("vince", "vince", new List<User>());

            Assert.IsTrue(vince.Equals(maybeVince));
        }

        [TestMethod]
        public void TestEquals_ReturnsIncorrect() {
            User vince = new User("vince", "vince", new List<User>());
            User maybeVince = new User("notvince", "notVince", new List<User>());

            Assert.IsFalse(vince.Equals(maybeVince));
        }

        [TestMethod]
        public void TestEquals_ReturnsFalseWhenNull() {
            User vince = new User("vince", "vince", new List<User>());
            
            Assert.IsFalse(vince.Equals(null));
        }
    }
}