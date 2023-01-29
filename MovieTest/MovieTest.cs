//namespace MovieTest
//{
//    [TestClass]
//    public class MovieTest
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {
//        }
//    }
//}

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Movie.Controllers;
//using Movie.Data;
//using Movie.Models;
//using Xunit;

//namespace MovieTest
//{
//    [TestClass]
//    public class UserControllerTest
//    {
//        private UserController _userController;
//        private Mock<MovieDbContext> _mockDbContext;
//        private List<User> _userList;

//        [TestInitialize]
//        public void Initialize()
//        {
//            _userList = new List<User>
//            {
//                new User { UserId = 1, UserName = "user1", UserPassword = "password1", UserType = "Normal User" },
//                new User { UserId = 2, UserName = "user2", UserPassword = "password2", UserType = "Normal User" },
//                new User { UserId = 3, UserName = "admin", UserPassword = "admin", UserType = "Administrator" }
//            };

//            _mockDbContext = new Mock<MovieDbContext>();
//            _mockDbContext.Setup(x => x.Users).ReturnsDbSet(_userList);

//            _userController = new UserController(_mockDbContext.Object);
//        }

//        [TestMethod]
//        public async Task GetUsers_ReturnsAllUsers()
//        {
//            // Act
//            var result = await _userController.GetUsers();

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(3, result.Count());
//            Assert.AreEqual("user1", result.ElementAt(0).UserName);
//            Assert.AreEqual("user2", result.ElementAt(1).UserName);
//            Assert.AreEqual("admin", result.ElementAt(2).UserName);
//        }

//        [TestMethod]
//        public async Task Login_ReturnsOk_WithCorrectCredentials()
//        {
//            // Arrange
//            var user = new User { UserName = "admin", UserPassword = "admin" };

//            // Act
//            var result = await _userController.Login(user);

//            // Assert
//            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
//            var okResult = result as OkObjectResult;
//            Assert.AreEqual("Login successful as Administrator", okResult.Value);
//        }

//        [TestMethod]
//        public async Task Login_ReturnsBadRequest_WithIncorrectPassword()
//        {
//            // Arrange
//            var user = new User { UserName = "admin", UserPassword = "wrongpassword" };

//            // Act
//            var result = await _userController.Login(user);

//            // Assert
//            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
//            var badRequestResult = result as BadRequestObjectResult;
//            Assert.AreEqual("Incorrect password", badRequestResult.Value);
//        }
//    }
//}


//namespace MovieTest
//{
//    public class UserControllerTests
//    {
//        [Fact]
//        public async Task GetUsers_ReturnsUsersList_Test()
//        {
//            var users = new List<User>()
//            {
//                new User()
//                {
//                    UserId = 1,
//                    UserName = "test",
//                    UserPassword = "test",
//                    UserType = "Normal User"
//                }
//            }.AsQueryable();

//            var mockDbSet = new Mock<DbSet<User>>();
//            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
//            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
//            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
//            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

//            var mockContext = new Mock<MovieDbContext>();
//            mockContext.Setup(m => m.Users).Returns(mockDbSet.Object);
//            var controller = new UserController(mockContext.Object);

//            // Act
//            var result = await controller.GetUsers();

//            // Assert
//            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
//            var okResult = result as OkObjectResult;
//            Assert.IsInstanceOfType(okResult.Value, typeof(IEnumerable<User>));
//            Assert.AreEqual(users.Count(), returnUsers.Count());
//            Assert.AreEqual(users, returnUsers);
//        }
//    }
//}