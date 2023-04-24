using GamingGroupFinder;
using GamingGroupFinderDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GamingGroupFinderTests;

[TestClass]
public class MessageManagerTests {
    [TestMethod]
    public void TestCreateMessage_CreatesMessage() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestCreateMessage_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestGetMessagesSent_GetsMessages() {

    }

    [TestMethod]
    public void TestGetMessagesSent_ThrowsIfNoUser() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetMessagesSent_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestGetMessagesRecieved_GetsMessages() {

    }

    [TestMethod]
    public void TestGetMessagesRecieved_ThrowsIfNoUser() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestGetMessagesRecieved_ThrowsWhenGivenNull() {

    }

    [TestMethod]
    public void TestMarkMessageSeen_MarksMessagesAsSeen() {

    }

    [TestMethod]
    public void TestMarkMessageSeen_ThrowsIfNoMessage() {

    }

    [TestMethod]
    [ExpectedException (typeof(ArgumentNullException))]
    public void TestMarkMessageSeen_ThrowsWhenGivenNull() {

    }
}