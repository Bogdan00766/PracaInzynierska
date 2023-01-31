using AutoMapper;
using Moq;
using NUnit.Framework;
using PracaInzynierska.Application.Dto;
using PracaInzynierska.Application.Services;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;
using System.Security.Cryptography;
using System.Text;

namespace PracaInzynierska.UnitTests.Application.Services
{
    public class UserServiceTests
    {
        [Test]
        public void Login_WhenNullPassword_ShouldThrowException()
        {
            var mockMapper = new Mock<IMapper>();
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object, mockMapper.Object);
            var ex = Assert.Throws<Exception>(() => userService.Login("email", null));

            Assert.That(ex.Message, Is.EqualTo("Password cannot be null"));
        }

        [Test]
        public void Login_WhenNullEmail_ShouldThrowException()
        {
            var mockMapper = new Mock<IMapper>();
            var mockUserRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockUserRepository.Object, mockMapper.Object);
            var ex = Assert.Throws<Exception>(() => userService.Login(null, "password"));

            Assert.That(ex.Message, Is.EqualTo("Email cannot be null"));
        }

        [Test]
        public void Login_WhenIncorrectUser_ShouldReturnThrowExceptipon()
        {
            var email = "email";
            var password = "password";

            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(email + password));
            }

            var mockMapper = new Mock<IMapper>();

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.CheckPassword(email, hash)).Returns(false);

            var userService = new UserService(mockUserRepository.Object, mockMapper.Object);

            var ex = Assert.Throws<Exception>(() => userService.Login(email, password));

            Assert.That(ex.Message, Is.EqualTo("User not found"));
        }

        [Test]
        public void Login_WhenIncorrectPassword_ShouldReturnThrowExceptipon()
        {
            var email = "email";
            var password = "password";

            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(email + password));
            }

            var mockMapper = new Mock<IMapper>();

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.CheckPassword(email, hash)).Returns(false);
            mockUserRepository.Setup(x => x.FindByEmail(email)).Returns(new User());

            var userService = new UserService(mockUserRepository.Object, mockMapper.Object);

            var ex = Assert.Throws<Exception>(() => userService.Login(email, password));

            Assert.That(ex.Message, Is.EqualTo("Wrong password"));
        }

        [Test]
        public void Login_WhenCorrectPassword_ShouldReturnUserDto()
        {
            var email = "email";
            var password = "password";
            var user = new User();
            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(email + password));
            }

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.CheckPassword(email, hash)).Returns(true);
            mockUserRepository.Setup(x => x.FindByEmail(email)).Returns(user);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<UserDto>(user)).Returns(new UserDto());

            var userService = new UserService(mockUserRepository.Object, mockMapper.Object);

            var result = userService.Login(email, password);

            Assert.IsInstanceOf<UserDto>(result);
        }
        [Test]
        public void IsLogged_WhenFoundUser_ShouldReturnTrue()
        {
            //Arrange
            var guid = new Guid();
            var user = new User();
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.FindUserByGUID(guid)).Returns(user);
            var mockMapper = new Mock<IMapper>();
            var userService = new UserService(mockUserRepository.Object, mockMapper.Object);
            //Act
            var result = userService.IsLogged(guid);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void IsLogged_WhenNotFoundUser_ShouldReturnFalse()
        {
            var guid = new Guid();

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.FindUserByGUID(guid)).Returns((User)null);
            var mockMapper = new Mock<IMapper>();

            var userService = new UserService(mockUserRepository.Object, mockMapper.Object);

            var result = userService.IsLogged(guid);

            Assert.IsFalse(result);
        }
        [Test]
        public void Logout_WhenFoundUser_ShouldEmptyAutoLoginGuid()
        {
            var guid = new Guid();
            var user = new User()
            {
                AutoLoginGUID = guid.ToString(),
                AutoLoginGUIDExpires = DateTime.MinValue
            };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.FindUserByGUID(guid)).Returns(user);
            var mockMapper = new Mock<IMapper>();

            var userService = new UserService(mockUserRepository.Object, mockMapper.Object);
            userService.Logout(guid);

            Assert.That(user.AutoLoginGUID, Is.EqualTo(Guid.Empty.ToString()));
        }

        [Test]
        public void Logout_WhenFoundUser_ShouldSetAutoLoginGUIDExpiresNow()
        {
            var guid = new Guid();
            var user = new User()
            {
                AutoLoginGUID = guid.ToString(),
                AutoLoginGUIDExpires = DateTime.MinValue
            };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.FindUserByGUID(guid)).Returns(user);
            var mockMapper = new Mock<IMapper>();

            var userService = new UserService(mockUserRepository.Object, mockMapper.Object);
            userService.Logout(guid);

            Assert.That(user.AutoLoginGUIDExpires, !Is.EqualTo(DateTime.MinValue));
        }

    }
}
