using GamingGroupFinder;
using GamingGroupFinderDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GamingGroupFinderTests;

[TestClass]
public class EventManagerTests {
    [TestMethod]
    public void TestCreateEvent_CreatesEvent() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        List<Platform> platforms = new List<Platform>();
        Platform nintendo = new Platform(1, "Nintendo Switch");
        platforms.Add(nintendo);

        List<Rank> ranks = new List<Rank>();
        Rank am = new Rank(1, 1, "A-");
        ranks.Add(am);
        Rank a = new Rank(2, 2, "A");
        ranks.Add(a);
        Rank ap = new Rank(3, 3, "A+");
        ranks.Add(ap);

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());

        // Act
        eventManager.CreateEvent(e);

        // Assert
        mockSet.Verify(u => u.Add(It.IsAny<EventDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentException))]
    public void TestCreateEvent_ThrowsIfAlreadyCreated() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        List<Platform> platforms = new List<Platform>();
        Platform nintendo = new Platform(1, "Nintendo Switch");
        platforms.Add(nintendo);

        List<Rank> ranks = new List<Rank>();
        Rank am = new Rank(1, 1, "A-");
        ranks.Add(am);
        Rank a = new Rank(2, 2, "A");
        ranks.Add(a);
        Rank ap = new Rank(3, 3, "A+");
        ranks.Add(ap);

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());

        // Act
        eventManager.CreateEvent(e);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestCreateEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        // Act
        eventManager.CreateEvent(null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestEditEvent_EditsEvent() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        List<Platform> platforms = new List<Platform>();
        Platform nintendo = new Platform(1, "Nintendo Switch");
        platforms.Add(nintendo);

        List<Rank> ranks = new List<Rank>();
        Rank am = new Rank(1, 1, "A-");
        ranks.Add(am);
        Rank a = new Rank(2, 2, "A");
        ranks.Add(a);
        Rank ap = new Rank(3, 3, "A+");
        ranks.Add(ap);

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());

        eventManager.CreateEvent(e);

        EventDB eDB = new EventDB(new UserDB("newuser", "newpass", "salt", null), "editedevent", DateTime.Now, "overthere"
        , new GameDB("Splatoon 3"), new PlatformDB("Nintendo Switch"), new RankDB(1, "A-"), new RankDB(3, "A+")
        , "desc");

        // Act
        eventManager.EditEvent(e, eDB);

        // Assert
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void TestEditEvent_ThrowsIfNoEvent() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestEditEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        // Act
        eventManager.EditEvent(null, null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestDeleteEvent_DeletesEvent() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        List<Platform> platforms = new List<Platform>();
        Platform nintendo = new Platform(1, "Nintendo Switch");
        platforms.Add(nintendo);

        List<Rank> ranks = new List<Rank>();
        Rank am = new Rank(1, 1, "A-");
        ranks.Add(am);
        Rank a = new Rank(2, 2, "A");
        ranks.Add(a);
        Rank ap = new Rank(3, 3, "A+");
        ranks.Add(ap);

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());

        eventManager.CreateEvent(e);

        // Act
        eventManager.DeleteEvent(e);
        // Assert
        mockSet.Verify(u => u.Remove(It.IsAny<EventDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.AtLeastOnce());
    }

    [TestMethod]
    public void TestDeleteEvent_ThrowsIfNoEvent() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestDeleteEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        // Act
        eventManager.DeleteEvent(null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestAttendEvent_AddsUserToEvent() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        List<Platform> platforms = new List<Platform>();
        Platform nintendo = new Platform(1, "Nintendo Switch");
        platforms.Add(nintendo);

        List<Rank> ranks = new List<Rank>();
        Rank am = new Rank(1, 1, "A-");
        ranks.Add(am);
        Rank a = new Rank(2, 2, "A");
        ranks.Add(a);
        Rank ap = new Rank(3, 3, "A+");
        ranks.Add(ap);

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());

        eventManager.CreateEvent(e);

        User attendee = new User("attending", "event", "salt", new List<User>());

        // Act
        eventManager.AttendEvent(attendee, e);

        // Assert
        mockSet.Verify(u => u.Add(It.IsAny<EventDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void TestAttendEvent_ThrowsIfNoUser() {

    }

    [TestMethod]
    public void TestAttendEvent_ThrowsIfNoEvent() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestAttendEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        // Act
        eventManager.AttendEvent(null, null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestLeaveEvent_RemovesUser() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        List<Platform> platforms = new List<Platform>();
        Platform nintendo = new Platform(1, "Nintendo Switch");
        platforms.Add(nintendo);

        List<Rank> ranks = new List<Rank>();
        Rank am = new Rank(1, 1, "A-");
        ranks.Add(am);
        Rank a = new Rank(2, 2, "A");
        ranks.Add(a);
        Rank ap = new Rank(3, 3, "A+");
        ranks.Add(ap);

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);

        List<User> users = new List<User>();
        User user2 = new User("user2", "user2", "salt", new List<User>());
        users.Add(user2);

        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, attendees);

        eventManager.CreateEvent(e);

        // Act
        eventManager.LeaveEvent(user2, e);

        // Assert
        mockSet.Verify(u => u.Remove(It.IsAny<EventDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.AtLeastOnce());
    }

    [TestMethod]
    public void TestLeaveEvent_ThrowsIfNoUser() {

    }

    [TestMethod]
    public void TestLeaveEvent_ThrowsIfNoEvent() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestLeaveEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        // Act
        eventManager.LeaveEvent(null, null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestViewAttendees_GivesCorrect() {

    }

    [TestMethod]
    public void TestViewAttendees_ThrowsIfNoEvent() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestViewAttendees_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        // Act
        eventManager.ViewAttendees(null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestFindEvent_FindsEvent() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestFindEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.setApplicationContext(mockContext.Object);

        // Act
        eventManager.FindEvent(null, "PC", "Bronze");

        // Assert
        Assert.Fail();
    }
}