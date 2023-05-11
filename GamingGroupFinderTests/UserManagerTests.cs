using GamingGroupFinder;
using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GamingGroupFinderTests;

[TestClass]
public class UserManagerTests {
    [TestMethod]
    public void TestCreateUser_AddsUser() {
        // Arrange
        var mockSet = new Mock<DbSet<UserDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        UserManager userManager = UserManager.GetInstance();
        userManager.SetApplicationContext(mockContext.Object);

        // Act
        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        userManager.CreateUser(user);

        // Assert
        mockSet.Verify(u => u.Add(It.IsAny<UserDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void TestLogInUser_LogsUserIn() {
        // Arrange
        var mockSet = new Mock<DbSet<UserDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        UserManager userManager = UserManager.GetInstance();
        userManager.SetApplicationContext(mockContext.Object);

        // Act
        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        userManager.LogInUser(user);

        // Assert
        Assert.AreEqual(user, userManager.LoggedInUser);
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestLogInUser_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<UserDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        UserManager userManager = UserManager.GetInstance();
        userManager.SetApplicationContext(mockContext.Object);

        // Act
        userManager.LogInUser(null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestLogOutUser_LogsUserOut() {
        // Arrange
        var mockSet = new Mock<DbSet<UserDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        UserManager userManager = UserManager.GetInstance();
        userManager.SetApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        userManager.LoggedInUser = user;

        // Act
        userManager.LogOutUser();

        // Assert
        Assert.AreEqual(null, userManager.LoggedInUser);
    }

    [TestMethod]
    public void TestChangePassword_ChangesPassword() {
        // Arrange
        var mockSet = new Mock<DbSet<UserDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        UserManager userManager = UserManager.GetInstance();
        userManager.SetApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        userManager.LoggedInUser = user;

        // Act
        userManager.ChangePassword("anotherpassword");

        // Assert
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestChangePassword_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<UserDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        UserManager userManager = UserManager.GetInstance();
        userManager.SetApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        userManager.LoggedInUser = user;

        // Act
        userManager.ChangePassword(null);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestDeleteAccount_DeletesLoggedInUser() {
        // Arrange
        var mockSet = new Mock<DbSet<UserDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        UserManager userManager = UserManager.GetInstance();
        userManager.SetApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        userManager.CreateUser(user);
        userManager.LoggedInUser = user;

        // Act
        userManager.DeleteAccount();

        // Assert
        mockSet.Verify(u => u.Remove(It.IsAny<UserDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Exactly(2));
    }

    [TestMethod]
    public void TestDeleteAccount_DeletesGivenUser() {
        // Arrange
        var mockSet = new Mock<DbSet<UserDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        UserManager userManager = UserManager.GetInstance();
        userManager.SetApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        userManager.CreateUser(user);
        userManager.LoggedInUser = user;

        // Act
        userManager.DeleteAccount(user);

        // Assert
        mockSet.Verify(u => u.Remove(It.IsAny<UserDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Exactly(2));
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestDeleteAccount_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<UserDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.UsersDB).Returns(mockSet.Object);
        UserManager userManager = UserManager.GetInstance();
        userManager.SetApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        userManager.CreateUser(user);
        userManager.LoggedInUser = user;

        // Act
        userManager.DeleteAccount(null);

        // Assert
        Assert.Fail();
    }
}