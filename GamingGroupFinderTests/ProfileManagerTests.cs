using GamingGroupFinder;
using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GamingGroupFinderTests;

[TestClass]
public class ProfileManagerTests {
    [TestMethod]
    public void TestCreateProfile_CreatesProfile() {
        // Arrange
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, new List<Platform>(), new List<Game>(), "bio", "pfp", new List<Interest>());

        // Act
        profileManager.CreateProfile(profile, user);

        // Assert
        mockSet.Verify(u => u.Add(It.IsAny<ProfileDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestCreateProfile_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());

        // Act
        profileManager.CreateProfile(null, user);

        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestDeleteProfile_DeletesProfile() {
        // Arrange
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, new List<Platform>(), new List<Game>(), "bio", "pfp", new List<Interest>());
        profileManager.CreateProfile(profile, user);

        // Act
        profileManager.DeleteProfile(profile, user);

        // Assert
        mockSet.Verify(u => u.Remove(It.IsAny<ProfileDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Exactly(2));
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestDeleteProfile_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());

        // Act
        profileManager.DeleteProfile(null, user);
        
        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestEditProfile_EditsProfile() {
        // Arrange
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, new List<Platform>(), new List<Game>(), "bio", "pfp", new List<Interest>());
        profileManager.CreateProfile(profile, user);

        UserDB userDB = new UserDB("newuser", "newpass", new byte['s'], null);
        ProfileDB profileDB = new ProfileDB(userDB, "NewUser", "he/him", 18, "bio", "path", new List<InterestDB>(), new List<PlatformDB>(), new List<GameDB>());

        // Act
        profileManager.EditProfile(profileDB);
        
        // Assert
        mockContext.Verify(u => u.SaveChanges(), Times.AtLeastOnce());
    }

    [TestMethod]
    public void TestEditProile_ThrowsIfNoProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestEditProfile_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        // Act
        profileManager.EditProfile(null);
        
        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestSearchProfile_GetsProfile() {
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", new byte['s'], new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, new List<Platform>(), new List<Game>(), "bio", "pfp", new List<Interest>());
        profileManager.CreateProfile(profile, user);

        // Act
        List<ProfileDB> searchedProfile = profileManager.SearchProfile("newuser");
        
        // Assert
        Assert.AreEqual("newuser", searchedProfile[0].Name);
    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestSearchProfile_ThrowsWhenGivenNull() {
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        // Act
        List<ProfileDB> searchedProfile = profileManager.SearchProfile(null);
        
        // Assert
        Assert.Fail();
    }
}