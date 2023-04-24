using GamingGroupFinder;
using GamingGroupFinderDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GamingGroupFinderTests;

[TestClass]
public class EventManagerTests {
    [TestMethod]
    public void TestCreateEvent_CreatesEvent() {

    }

    [TestMethod]
    public void TestCreateEvent_ThrowsIfAlreadyCreated() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestCreateEvent_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestEditEvent_EditsEvent() {

    }

    [TestMethod]
    public void TestEditEvent_ThrowsIfNoEvent() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestEditEvent_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestDeleteEvent_DeletesEvent() {

    }

    [TestMethod]
    public void TestDeleteEvent_ThrowsIfNoEvent() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestDeleteEvent_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestAttendEvent_AddsUserToEvent() {

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

    }

    [TestMethod]
    public void TestLeaveEvent_RemovesUser() {

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

    }

    [TestMethod]
    public void TestFindEvent_FindsEvent() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestFindEvent_ThrowsWhenGivenNull() {
        
    }
}