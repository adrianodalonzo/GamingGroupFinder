using GamingGroupFinder;
using GamingGroupFinderDatabase;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GamingGroupFinderTests;

[TestClass]
public class UserManagerTests {
    [TestMethod]
    public void TestCreateUser_() {
        var mockSet = new Mock<DbSet<User>>();
        var mockContext = new Mock<ApplicationContext>();
        
    }
}