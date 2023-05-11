using GamingGroupFinder;
using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GamingGroupFinderTests;

[TestClass]
public class EventManagerTests {
    private EventDB EventToEventDB(Event ev) {
        return new EventDB(UserToUserDB(ev.Owner), ev.Title, ev.DateTime, ev.Location, GameToGameDB(ev.Game), PlatformToPlatformDB(ev.Platform), ev.Description, UsersToUsersDB(ev.Attendees));
    }
    // convert user to userdb
    private UserDB UserToUserDB(User u) {
        return new UserDB(u.Username, u.Password, u.Salt, null);
    }
    // convert game to gamedb
    private GameDB GameToGameDB(Game g) {
        return new GameDB(g.Name);
    }
    // convert platform to platformdb
    private PlatformDB PlatformToPlatformDB(Platform p) {
        return new PlatformDB(p.Name);
    }
    // convert list of users to list of userDB
    private List<UserDB> UsersToUsersDB(List<User> users) {
        List<UserDB> usersDB = new List<UserDB>();
        foreach(var user in users) {
            usersDB.Add(UserToUserDB(user));
        }
        return usersDB;
    }
    [TestMethod]
    public void TestCreateEvent_CreatesEvent() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.SetApplicationContext(mockContext.Object);

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

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());

        // Act
        eventManager.CreateEvent(EventToEventDB(e));

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
        eventManager.SetApplicationContext(mockContext.Object);

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

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());

        // Act
        eventManager.CreateEvent(EventToEventDB(e));

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
        eventManager.SetApplicationContext(mockContext.Object);

        // Act
        eventManager.CreateEvent((EventDB)null);

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
        eventManager.SetApplicationContext(mockContext.Object);

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

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());

        eventManager.CreateEvent(EventToEventDB(e));

        EventDB eDB = new EventDB(new UserDB("newuser", "newpass", new byte['s'], null), "editedevent", DateTime.Now, "overthere"
        , new GameDB("Splatoon 3"), new PlatformDB("Nintendo Switch"), "desc", new List<UserDB>());

        // Act
        eventManager.EditEvent(eDB);

        // Assert
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestEditEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.SetApplicationContext(mockContext.Object);

        // Act
        eventManager.EditEvent(null);

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
        eventManager.SetApplicationContext(mockContext.Object);

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

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());
        
        UserDB userDB = new UserDB("newuser", "newpass", new byte['s'], null);
        GameDB gameDB = new GameDB("Splatoon 3");
        PlatformDB platformDB = new PlatformDB("Nintendo Switch");
        EventDB eDB = new EventDB(userDB, "newevent", DateTime.Now, "over there", gameDB, platformDB,"desc", new List<UserDB>());

        eventManager.CreateEvent(EventToEventDB(e));

        // Act
        eventManager.DeleteEvent(eDB);
        // Assert
        mockSet.Verify(u => u.Remove(It.IsAny<EventDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.AtLeastOnce());
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestDeleteEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.SetApplicationContext(mockContext.Object);

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
        eventManager.SetApplicationContext(mockContext.Object);

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

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);
        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, new List<User>());

        eventManager.CreateEvent(EventToEventDB(e));

        User attendee = new User("attending", "event", new byte['s'], new List<User>());

        UserDB userDB = new UserDB("newuser", "newpass", new byte['s'], null);
        GameDB gameDB = new GameDB("Splatoon 3");
        PlatformDB platformDB = new PlatformDB("Nintendo Switch");
        EventDB eDB = new EventDB(userDB, "newevent", DateTime.Now, "over there", gameDB, platformDB,"desc", new List<UserDB>());


        // Act
        eventManager.AttendEvent(eDB, "attending");

        // Assert
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestAttendEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.SetApplicationContext(mockContext.Object);

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
        eventManager.SetApplicationContext(mockContext.Object);

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

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Game game = new Game("Splatoon 3", platforms, ranks);

        List<User> users = new List<User>();
        User user2 = new User("user2", "user2", new byte['s'], new List<User>());
        users.Add(user2);

        Event e = new Event("newevent", DateTime.Now, "over there", game, nintendo, am, ap, "desc", user, users);

        eventManager.CreateEvent(EventToEventDB(e));

        UserDB userDB = new UserDB("newuser", "newpass", new byte['s'], null);
        GameDB gameDB = new GameDB("Splatoon 3");
        PlatformDB platformDB = new PlatformDB("Nintendo Switch");
        EventDB eDB = new EventDB(userDB, "newevent", DateTime.Now, "over there", gameDB, platformDB,"desc", new List<UserDB>(){new UserDB("user2", "pass2", new byte['s'], null)});


        // Act
        eventManager.LeaveEvent(eDB, "user2");

        // Assert
        mockContext.Verify(u => u.SaveChanges(), Times.AtLeastOnce());
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestLeaveEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.SetApplicationContext(mockContext.Object);

        // Act
        eventManager.LeaveEvent(null, null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestViewAttendees_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.SetApplicationContext(mockContext.Object);

        // Act
        eventManager.ViewAttendees(null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestFindEvent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<EventDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.EventsDB).Returns(mockSet.Object);
        EventManager eventManager = EventManager.GetInstance();
        eventManager.SetApplicationContext(mockContext.Object);

        // Act
        eventManager.FindEvent(null, "PC");

        // Assert
        Assert.Fail();
    }
}