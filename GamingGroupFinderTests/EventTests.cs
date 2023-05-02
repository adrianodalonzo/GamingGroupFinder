using GamingGroupFinder;

namespace GamingGroupFinderTests {
    [TestClass]
    public class EventTests {
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
        public static Event CreateBaseEvent() {
            List<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform(1, "PC"));
            Platform nintendoSwitch = new Platform(2, "NINTENDO SWITCH");
            platforms.Add(nintendoSwitch);

            Game splatoon = new Game("Splatoon", platforms, GameSplatoonRanks());

            User vince = new User("vince", "vince", "salt", new List<User>());
            User user1 = new User("u1", "you1", "salt", new List<User>());
            User user2 = new User("u2", "you2", "salt", new List<User>());

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user1);
            attendees.Add(user2);

            Rank minRank = new Rank(1, 1, "A-");
            Rank maxRank = new Rank(3, 3, "A+");

            DateTime date = new DateTime(2023, 3, 25, 14, 30, 0);
            return new Event("Base Event", date, "over there", splatoon, nintendoSwitch, minRank, maxRank, "smth", vince, attendees);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestConstructor_ThrowsWhenGivenNull() {
            List<Platform> platforms = new List<Platform>();
            platforms.Add(new Platform(1, "PC"));
            Platform nintendoSwitch = new Platform(2, "NINTENDO SWITCH");
            platforms.Add(nintendoSwitch);

            Game splatoon = new Game("Splatoon", platforms, GameSplatoonRanks());

            User vince = new User("vince", "vince", "salt", new List<User>());
            User user1 = new User("u1", "you1", "salt", new List<User>());
            User user2 = new User("u2", "you2", "salt", new List<User>());

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user1);
            attendees.Add(user2);

            Rank minRank = new Rank(1, 1, "A-");
            Rank maxRank = new Rank(3, 3, "A+");

            Event ev = new Event(null, DateTime.Now, "over there", splatoon, nintendoSwitch, minRank, maxRank, "smth", vince, attendees);
            Assert.Fail();
        }

        [TestMethod]
        public void TestAttendEvent_AddsUser() {
            Event ev = CreateBaseEvent();
            User otherUser = new User("other", "user", "salt", new List<User>());

            User vince = new User("vince", "vince", "salt", new List<User>());
            User user1 = new User("u1", "you1", "salt", new List<User>());
            User user2 = new User("u2", "you2", "salt", new List<User>());

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user1);
            attendees.Add(user2);
            attendees.Add(otherUser);

            EventManager evMan = new EventManager(ev);

            evMan.AttendEvent(otherUser);

            Assert.IsTrue(attendees.SequenceEqual(ev.Attendees));
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestAttendEvent_ThrowsWhenGivenNull() {
            Event ev = CreateBaseEvent();
            EventManager evMan = new EventManager(ev);
            User? otherUser = null;

            evMan.AttendEvent(otherUser);
            Assert.Fail();
        }

        [TestMethod]
        public void TestLeaveEvent_RemovesUser() {
            Event ev = CreateBaseEvent();
            User user1 = new User("u1", "you1", "salt", new List<User>());

            User vince = new User("vince", "vince", "salt", new List<User>());
            User user2 = new User("u2", "you2", "salt", new List<User>());

            List<User> attendees = new List<User>();
            attendees.Add(vince);
            attendees.Add(user2);

            EventManager evMan = new EventManager(ev);

            evMan.LeaveEvent(user1);

            Assert.IsTrue(attendees.SequenceEqual(ev.Attendees));
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestLeaveEvent_ThrowsWhenGivenNull() {
            Event ev = CreateBaseEvent();
            EventManager evMan = new EventManager(ev);
            User? user1 = null;

            evMan.LeaveEvent(user1);
            Assert.Fail();
        }

        [TestMethod]
        public void TestViewAttendees_ReturnsCorrect() {
            Event ev = CreateBaseEvent();
            EventManager evMan = new EventManager(ev);
            
            string expectedString = "vince, u1, u2, ";

            Assert.AreEqual(expectedString, evMan.ViewAttendees());
        }
    }
}