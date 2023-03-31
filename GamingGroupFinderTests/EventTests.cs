using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class EventTests {
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
        public static Event CreateBaseEvent() {
            List<string> platforms = new List<string>();
            platforms.Add("PC");
            platforms.Add("NINTENDO SWITCH");

            Game splatoon = new Game("Splatoon", platforms, GameSplatoonRanks());

            User vince = new User("vince", "vince", new List<User>());
            User user1 = new User("u1", "you1", new List<User>());
            User user2 = new User("u2", "you2", new List<User>());

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user1);
            attendees.Add(user2);

            DateTime date = new DateTime(2023, 3, 25, 14, 30, 0);
            return new Event("Base Event", date, "over there", splatoon, "NINTENDO SWITCH", "A+", "smth", vince, attendees);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            List<string> platforms = new List<string>();
            platforms.Add("PC");
            platforms.Add("NINTENDO SWITCH");

            Game splatoon = new Game("Splatoon", platforms, GameSplatoonRanks());

            User vince = new User("vince", "vince", new List<User>());
            User user1 = new User("u1", "you1", new List<User>());
            User user2 = new User("u2", "you2", new List<User>());

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user1);
            attendees.Add(user2);

            Event ev = new Event(null, DateTime.Now, "over there", splatoon, "NINTENDO SWITCH", "A+", "smth", vince, attendees);
            Assert.Fail();
        }

        [TestMethod]
        public void TestAttendEvent_AddsUser() {
            Event ev = CreateBaseEvent();
            User otherUser = new User("other", "user", new List<User>());

            User vince = new User("vince", "vince", new List<User>());
            User user1 = new User("u1", "you1", new List<User>());
            User user2 = new User("u2", "you2", new List<User>());

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user1);
            attendees.Add(user2);
            attendees.Add(otherUser);

            ev.AttendEvent(otherUser);

            Assert.IsTrue(attendees.SequenceEqual(ev.Attendees));
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestAttendEvent_ThrowsWhenGivenNull() {
            Event ev = CreateBaseEvent();
            User? otherUser = null;

            ev.AttendEvent(otherUser);
            Assert.Fail();
        }

        [TestMethod]
        public void TestLeaveEvent_RemovesUser() {
            Event ev = CreateBaseEvent();
            User user1 = new User("u1", "you1", new List<User>());

            User vince = new User("vince", "vince", new List<User>());
            User user2 = new User("u2", "you2", new List<User>());

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user2);

            ev.LeaveEvent(user1);

            Assert.IsTrue(attendees.SequenceEqual(ev.Attendees));
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestLeaveEvent_ThrowsWhenGivenNull() {
            Event ev = CreateBaseEvent();
            User? user1 = null;

            ev.LeaveEvent(user1);
            Assert.Fail();
        }

        [TestMethod]
        public void TestViewAttendees_ReturnsCorrect() {
            Event ev = CreateBaseEvent();
            
            string expectedString = "vince, u1, u2, ";

            Assert.AreEqual(expectedString, ev.ViewAttendees());
        }
    }
}