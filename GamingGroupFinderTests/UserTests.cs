using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class UserTests {
        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            User user = new User(null, "password");

            Assert.Fail();
        }

        [TestMethod]
        public void TestVerifyUser_ReturnsCorrect() {
            User vince = new User("vince", "vince");

            Assert.IsTrue(vince.VerifyUser("vince", "vince"));
        }

        [TestMethod]
        public void TestVerifyUser_ReturnsIncorrect() {
            User vince = new User("vince", "vince");

            Assert.IsFalse(vince.VerifyUser("vince", "totallyVince"));
        }

        [TestMethod]
        public void TestChangePassword_ChangesPassword() {
            User vince = new User("vince", "vince");

            vince.ChangePassword("thunder");

            Assert.AreEqual("thunder", vince.Password);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestChangePassword_ThrowsWhenGivenNull() {
            User vince = new User("vince", "vince");

            vince.ChangePassword(null);
            
            Assert.Fail();
        }

        [TestMethod]
        public void TestEquals_ReturnsCorrect() {
            User vince = new User("vince", "vince");
            User maybeVince = new User("vince", "vince");

            Assert.IsTrue(vince.Equals(maybeVince));
        }

        [TestMethod]
        public void TestEquals_ReturnsIncorrect() {
            User vince = new User("vince", "vince");
            User maybeVince = new User("notvince", "notVince");

            Assert.IsFalse(vince.Equals(maybeVince));
        }

        [TestMethod]
        public void TestEquals_ReturnsFalseWhenNull() {
            User vince = new User("vince", "vince");
            
            Assert.IsFalse(vince.Equals(null));
        }
    }
}