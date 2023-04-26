using GamingGroupFinder;
using GamingGroupFinderDatabase;
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

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, new List<Platform>(), new List<Game>(), "bio", "pfp", new List<Interest>());

        // Act
        profileManager.CreateProfile(profile, user);

        // Assert
        mockSet.Verify(u => u.Add(It.IsAny<ProfileDB>()), Times.Once());
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void TestCreateProfile_ThrowsIfNoUser() {

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

        User user = new User("newuser", "newpass", "salt", new List<User>());

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

        User user = new User("newuser", "newpass", "salt", new List<User>());
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

        User user = new User("newuser", "newpass", "salt", new List<User>());

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

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, new List<Platform>(), new List<Game>(), "bio", "pfp", new List<Interest>());
        profileManager.CreateProfile(profile, user);

        // Act
        profileManager.EditProfile(profile);
        
        // Assert
        mockSet.Verify(u => u.Add(It.IsAny<ProfileDB>()), Times.AtLeastOnce());
        mockContext.Verify(u => u.SaveChanges(), Times.Once());
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
    public void TestGetProfileGames_GetsGames() {
        // Arrange
        Game game1 = new Game("Splatoon 3", new List<Platform>(), new List<Rank>());
        Game game2 = new Game("Valorant", new List<Platform>(), new List<Rank>());
        List<Game> games = new List<Game>();
        games.Add(game1);
        games.Add(game2);

        GameDB gameDB1 = new GameDB("Splatoon 3");
        GameDB gameDB2 = new GameDB("Valorant");
        List<GameDB> gamesDB = new List<GameDB>();
        gamesDB.Add(gameDB1);
        gamesDB.Add(gameDB2);

        var data = gamesDB.AsQueryable();

        var mockSet = new Mock<DbSet<GameDB>>();
        mockSet.As<IQueryable<GameDB>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<GameDB>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<GameDB>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<GameDB>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.GamesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, new List<Platform>(), games, "bio", "pfp", new List<Interest>());
        profileManager.CreateProfile(profile, user);

        // Act
        List<GameDB> profileGamesDB = profileManager.GetProfileGames(profile);

        // Arrange
        Assert.AreEqual(2, profileGamesDB.Count());
        Assert.AreEqual("Splatoon 3", profileGamesDB[0].GameName);
        Assert.AreEqual("Valorant", profileGamesDB[1].GameName);
    }

    [TestMethod]
    public void TestGetProfileGames_ThrowsIfNoProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetProfileGames_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        // Act
        List<GameDB> gamesDB = profileManager.GetProfileGames(null);
        
        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestGetProfilePlatforms_GetsPlatforms() {
        // Arrange
        Platform platform1 = new Platform(1, "PC");
        Platform platform2 = new Platform(1, "Nintendo Switch");
        List<Platform> platforms = new List<Platform>();
        platforms.Add(platform1);
        platforms.Add(platform2);

        PlatformDB platformDB1 = new PlatformDB("PC");
        PlatformDB platformDB2 = new PlatformDB("Nintendo Switch");
        List<PlatformDB> platformsDB = new List<PlatformDB>();
        platformsDB.Add(platformDB1);
        platformsDB.Add(platformsDB2);

        var data = platformsDB.AsQueryable();

        var mockSet = new Mock<DbSet<PlatformDB>>();
        mockSet.As<IQueryable<PlatformDB>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<PlatformDB>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<PlatformDB>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<PlatformDB>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.PlatformsDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, platforms, new List<Game>(), "bio", "pfp", new List<Interest>());
        profileManager.CreateProfile(profile, user);

        // Act
        List<PlatformDB> profilePlatformsDB = profileManager.GetProfilePlatforms(profile);

        // Arrange
        Assert.AreEqual(2, profilePlatformsDB.Count());
        Assert.AreEqual("PC", profilePlatformsDB[0].PlatformName);
        Assert.AreEqual("Nintendo Switch", profilePlatformsDB[1].PlatformName);
    }

    [TestMethod]
    public void TestGetProfilePlatforms_ThrowsIfNoProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetProfilePlatforms_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        // Act
        List<PlatformDB> platformsDB = profileManager.GetProfilePlatforms(null);
        
        // Assert
        Assert.Fail();
    }

    [TestMethod]
    public void TestGetProfileInterests_GetsInterests() {
        // Arrange
        Interest interest1 = new Interest(1, "Reading");
        Interest interest2 = new Interest(1, "Music");
        List<Interest> interests = new List<Interest>();
        interests.Add(interest1);
        interests.Add(interest2);

        InterestDB interestDB1 = new InterestDB("Reading");
        InterestDB interestDB2 = new InterestDB("Music");
        List<InterestDB> interestsDB = new List<InterestDB>();
        interestsDB.Add(interestDB1);
        interestsDB.Add(interestDB2);

        var data = interestsDB.AsQueryable();

        var mockSet = new Mock<DbSet<InterestDB>>();
        mockSet.As<IQueryable<InterestDB>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<InterestDB>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<InterestDB>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<InterestDB>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.InterestsDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, new List<Platform>(), new List<Game>(), "bio", "pfp", interests);
        profileManager.CreateProfile(profile, user);

        // Act
        List<InterestDB> profileInterestsDB = profileManager.GetProfilePlatforms(profile);

        // Arrange
        Assert.AreEqual(2, profileInterestsDB.Count());
        Assert.AreEqual("Reading", profileInterestsDB[0].InterestName);
        Assert.AreEqual("Music", profileInterestsDB[1].InterestName);
    }

    [TestMethod]
    public void TestGetProfileInterests_ThrowsIfNoProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetProfileInterests_ThrowsWhenGivenNull() {
        // Arrange
        var mockSet = new Mock<DbSet<ProfileDB>>();
        var mockContext = new Mock<ApplicationContext>();
        mockContext.Setup(u => u.ProfilesDB).Returns(mockSet.Object);
        ProfileManager profileManager = ProfileManager.GetInstance();
        profileManager.setApplicationContext(mockContext.Object);

        // Act
        List<InterestDB> interestsDB = profileManager.GetProfileInterests(null);
        
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

        User user = new User("newuser", "newpass", "salt", new List<User>());
        Profile profile = new Profile(user, "name", "pronouns", 20, new List<Platform>(), new List<Game>(), "bio", "pfp", interests);
        profileManager.CreateProfile(profile, user);

        // Act
        Profile searchedProfile = profileManager.SearchProfile("newuser");
        
        // Assert
        Assert.AreEqual("newuser", searchedProfile.Name);
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
        Profile searchedProfile = profileManager.SearchProfile(null);
        
        // Assert
        Assert.Fail();
    }
}