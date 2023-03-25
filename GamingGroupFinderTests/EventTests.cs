using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class EventTests {
        public static Event CreateBaseEvent() {
            Platform pc = new Platform("PC");
            Platform xbox = new Platform("xbox");

            List<Platform> platforms = new List<Platform>();
            platforms.Add(pc);
            platforms.Add(xbox);

            Game valorant = new Game("Valorant", platforms, "Gold");

            User vince = new User("vince", "vince");
            User user1 = new User("u1", "you1");
            User user2 = new User("u2", "you2");

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user1);
            attendees.Add(user2);

            DateTime date = new DateTime(2023, 3, 25, 14, 30, 0);
            return new Event("Base Event", date, "over there", valorant, pc, "Gold", "smth", vince, attendees);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            Platform pc = new Platform("PC");
            Platform xbox = new Platform("xbox");

            List<Platform> platforms = new List<Platform>();
            platforms.Add(pc);
            platforms.Add(xbox);

            Game valorant = new Game("Valorant", platforms, "Gold");

            User vince = new User("vince", "vince");
            User user1 = new User("u1", "you1");
            User user2 = new User("u2", "you2");

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user1);
            attendees.Add(user2);

            Event ev = new Event(null, DateTime.Now, "over there", valorant, pc, "Gold", "smth", vince, attendees);
            Assert.Fail();
        }

        [TestMethod]
        public void TestAttendEvent_AddsUser() {
            Event ev = CreateBaseEvent();
            User otherUser = new User("other", "user");

            User vince = new User("vince", "vince");
            User user1 = new User("u1", "you1");
            User user2 = new User("u2", "you2");

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
            User user1 = new User("u1", "you1");

            User vince = new User("vince", "vince");
            User user2 = new User("u2", "you2");

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