using GamingGroupFinder;
using GamingGroupFinderDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GamingGroupFinderTests;

[TestClass]
public class MessageManagerTests {
    [TestMethod]
    public void TestCreateMessage_CreatesMessage() {
        // Arrange
        var mockSet = new Mock<DbSet<MessageDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.MessagesDB).Returns(mockSet.Object);
        MessageManager messageManager = MessageManager.GetInstance();
        messageManager.setApplicationContext(mockContext.Object);

        User user1 = new User("user1", "pass1", "salt1", new List<User>());
        User user2 = new User("user2", "pass2", "salt2", new List<User>());
        Message m = new Message(user1, user2, DateTime.Now, "msg", false);

        // Act
        messageManager.CreateMessage(m);

        // Assert
        mockSet.Verify(u => u.Add(It.IsAny<MessageDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestCreateMessage_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<MessageDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        MessageManager messageManager = MessageManager.GetInstance();
        messageManager.setApplicationContext(mockContext.Object);

        // Act
        messageManager.CreateMessage(null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestGetMessagesSent_GetsMessages() {
        // Arrange
        UserDB user1 = new UserDB("user1", "pass1", "salt1", null);
        UserDB user2 = new UserDB("user2", "pass2", "salt2", null);
        UserDB user3 = new UserDB("user3", "pass3", "salt3", null);
        MessageDB m1 = new MessageDB(user1, user2, DateTime.Now, "a msg", false);
        MessageDB m2 = new MessageDB(user1, user2, DateTime.Now, "another msg", false);
        MessageDB m3 = new MessageDB(user1, user3, DateTime.Now, "perhaps", false);

        List<MessageDB> msgs = new List<MessageDB>();
        msgs.Add(m1);
        msgs.Add(m2);
        msgs.Add(m3);

        var data = msgs.AsQueryable();

        var mockSet = new Mock<DbSet<MessageDB>>();
        mockSet.As<IQueryable<MessageDB>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<MessageDB>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<MessageDB>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<MessageDB>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.MessagesDB).Returns(mockSet.Object);
        MessageManager messageManager = MessageManager.GetInstance();
        messageManager.setApplicationContext(mockContext.Object);

        // Act
        var msgsSent = messageManager.GetMessagesSent(user1);

        // Assert
        Assert.AreEqual(3, msgsSent.Count);
        Assert.AreEqual("a msg", msgsSent[0].MessageText);
        Assert.AreEqual("another msg", msgsSent[1].MessageText);
        Assert.AreEqual("perhaps", msgsSent[2].MessageText);
    }

    [TestMethod]
    public void TestGetMessagesSent_ThrowsIfNoUser() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetMessagesSent_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<MessageDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.MessagesDB).Returns(mockSet.Object);
        MessageManager messageManager = MessageManager.GetInstance();
        messageManager.setApplicationContext(mockContext.Object);

        // Act
        var msgsSent = messageManager.GetMessagesSent(null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestGetMessagesRecieved_GetsMessages() {
        // Arrange
        UserDB user1 = new UserDB("user1", "pass1", "salt1", null);
        UserDB user2 = new UserDB("user2", "pass2", "salt2", null);
        UserDB user3 = new UserDB("user3", "pass3", "salt3", null);
        MessageDB m1 = new MessageDB(user1, user2, DateTime.Now, "a msg", false);
        MessageDB m2 = new MessageDB(user1, user2, DateTime.Now, "another msg", false);
        MessageDB m3 = new MessageDB(user1, user3, DateTime.Now, "perhaps", false);

        List<MessageDB> msgs = new List<MessageDB>();
        msgs.Add(m1);
        msgs.Add(m2);
        msgs.Add(m3);

        var data = msgs.AsQueryable();

        var mockSet = new Mock<DbSet<MessageDB>>();
        mockSet.As<IQueryable<MessageDB>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<MessageDB>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<MessageDB>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<MessageDB>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.MessagesDB).Returns(mockSet.Object);
        MessageManager messageManager = MessageManager.GetInstance();
        messageManager.setApplicationContext(mockContext.Object);

        // Act
        var msgsRecieved = messageManager.GetMessagesRecieved(user2);

        // Assert
        Assert.AreEqual(2, msgsRecieved.Count);
        Assert.AreEqual("a msg", msgsRecieved[0].MessageText);
        Assert.AreEqual("another msg", msgsRecieved[1].MessageText);
    }

    [TestMethod]
    public void TestGetMessagesRecieved_ThrowsIfNoUser() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetMessagesRecieved_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<MessageDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.MessagesDB).Returns(mockSet.Object);
        MessageManager messageManager = MessageManager.GetInstance();
        messageManager.setApplicationContext(mockContext.Object);

        // Act
        var msgsSent = messageManager.GetMessagesRecieved(null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestMarkMessageSeen_MarksMessagesAsSeen() {
        // Arrange
        var mockSet = new Mock<DbSet<MessageDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.MessagesDB).Returns(mockSet.Object);
        MessageManager messageManager = MessageManager.GetInstance();
        messageManager.setApplicationContext(mockContext.Object);

        User user1 = new User("user1", "pass1", "salt1", new List<User>());
        User user2 = new User("user2", "pass2", "salt2", new List<User>());
        Message m = new Message(user1, user2, DateTime.Now, "msg", false);

        messageManager.CreateMessage(m);

        // Act
        messageManager.MarkMessageSeen(m);

        // Assert
        mockSet.Verify(u => u.Add(It.IsAny<MessageDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Exactly(2));
    }

    [TestMethod]
    public void TestMarkMessageSeen_ThrowsIfNoMessage() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestMarkMessageSeen_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<MessageDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.MessagesDB).Returns(mockSet.Object);
        MessageManager messageManager = MessageManager.GetInstance();
        messageManager.setApplicationContext(mockContext.Object);

        // Act
        messageManager.MarkMessageSeen(null);

        // Assert
        Assert.Fail();
    }
}