using GamingGroupFinder;
using GamingGroupFinderDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GamingGroupFinderTests;

[TestClass]
public class ProfileManagerTests {
    [TestMethod]
    public void TestCreateProfile_CreatesProfile() {

    }

    [TestMethod]
    public void TestCreateProfile_ThrowsIfNoUser() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestCreateEvent_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestDeleteProfile_DeletesProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestDeleteProfile_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestEditProfile_EditsProfile() {

    }

    [TestMethod]
    public void TestEditProile_ThrowsIfNoProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestEditProfile_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestGetProfileGames_GetsGames() {

    }

    [TestMethod]
    public void TestGetProfileGames_ThrowsIfNoProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetProfileGames_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestGetProfilePlatforms_GetsPlatforms() {

    }

    [TestMethod]
    public void TestGetProfilePlatforms_ThrowsIfNoProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetProfilePlatforms_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestGetProfileInterests_GetsInterests() {

    }

    [TestMethod]
    public void TestGetProfileInterests_ThrowsIfNoProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetProfileInterests_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestSearchProfile_GetsProfile() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestSearchProfile_ThrowsWhenGivenNull() {

    }
}