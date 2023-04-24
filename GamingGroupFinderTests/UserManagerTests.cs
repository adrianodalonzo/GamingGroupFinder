using GamingGroupFinder;
using GamingGroupFinderDatabase;
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
        UserManager userManager = new UserManager();

        // Act
        User user = new User("newuser", "newpass", "salt", new List<User>());
        userManager.CreateUser(user);

        // Assert
        mockSet.Verify(u => u.Add(It.IsAny<UserDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void TestLogInUser_LogsUserIn() {

    }

    [TestMethod]
    public void TestLogInUser_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestLogOutUser_LogsUserOut() {

    }

    [TestMethod]
    public void TestLogOutUser_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestChangePassword_ChangesPassword() {

    }

    [TestMethod]
    public void TestChangePassword_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestDeleteAccount_DeletesLoggedInUser() {

    }

    [TestMethod]
    public void TestDeleteAccount_DeletesGivenUser() {

    }

    [TestMethod]
    public void TestDeleteAccount_ThrowsWhenGivenNull() {
        
    }
}