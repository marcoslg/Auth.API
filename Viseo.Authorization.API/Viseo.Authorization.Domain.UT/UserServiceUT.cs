using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Viseo.Authorization.Domain.Contracts;
using Viseo.Authorization.Domain.Exceptions;
using Viseo.Authorization.Domain.Exceptions.Users;
using Viseo.Authorization.Domain.Services;

namespace Viseo.Authorization.Domain.UT
{
    [TestClass]
    public class UserServiceUT
    {
        private UsersService userService;
        private IUsersRepository repository;
        [TestInitialize]
        public void TestInitialize()
        {
            repository = Substitute.For<IUsersRepository>();
            userService = new UsersService(repository);
        }
        #region get
        [TestMethod]
        [ExpectedException(typeof(UserArgumentException))]
        public async Task When_GetUser_userNameIsEmpty_ThrowException()
        {
            await userService.Get(string.Empty);
        }
        [TestMethod]
        [ExpectedException(typeof(UserArgumentException))]
        public async Task When_GetUser_userNameIsNull_ThrowException()
        {
            await userService.Get(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UserArgumentException))]
        public async Task When_GetUser_userNameIsEmptyChars_ThrowUserException()
        {
            await userService.Get("");
        }
        [TestMethod]        
        public async Task When_GetUser_userName_ReturnUser()
        {
            repository.Get("testUser").ReturnsForAnyArgs(new Models.User() { UserName = "testUser" });
            var user  = await userService.Get("testUser");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public async Task When_GetUser_userNameNotExists_ThrowUserNotFoundException()
        {
            repository.Get("testUser").ReturnsForAnyArgs((Models.User) null);
            var user = await userService.Get("testUser");
        }
        #endregion get
        #region Add
        [TestMethod]
        [ExpectedException(typeof(UserArgumentException))]
        public async Task When_AddUser_userNull_ThrowUserArgumentException()
        {            
            await userService.Add(null);
        }
        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public async Task When_AddUser_userWithUserNameNull_ThrowUserUserException()
        {
            await userService.Add(new Models.User());
        }

        [TestMethod]
        [ExpectedException(typeof(UserException))]
        public async Task When_AddUser_userWithUserNameEmpty_ThrowUserUserException()
        {
            await userService.Add(new Models.User() { UserName = string.Empty });
        }

        [TestMethod]
        [ExpectedException(typeof(UserAlreadyExistsException))]
        public async Task When_AddUser_userAlreadyExists_ThrowUserAlreadyExistsException()
        {
            repository.Exists("testUser").ReturnsForAnyArgs(true);
            await userService.Add(new Models.User("testUser"));
        }

        [TestMethod]        
        public async Task When_AddUser_userWithOutRoles_Ok()
        {
            repository.Exists("testUser").ReturnsForAnyArgs(false);
            var user = new Models.User("testUser");
            await userService.Add(user);
            await repository.Received(1).Add(user);
            await repository.Received(0).AddRole(Arg.Any<string>(), Arg.Any<Role>());
        }

        [TestMethod]
        public async Task When_AddUser_userWithRoles_Ok()
        {
            repository.Exists("testUser").ReturnsForAnyArgs(false, true);
            var user = new Models.User("testUser", new List<Role>()
                {
                new Role("admin"),
                new Role("testing"),
                });
            await userService.Add(user);
            await repository.Received(1).Add(user);
            await repository.Received(2).AddRole(Arg.Any<string>(), Arg.Any<Role>());
        }
        #endregion Add


        #region AddRole
        [TestMethod]
        [ExpectedException(typeof(UserArgumentException))]
        public async Task When_AddRole_userNull_ThrowUserArgumentException()
        {
            await userService.AddRole(null,null);
        }
        [TestMethod]
        [ExpectedException(typeof(UserArgumentException))]
        public async Task When_AddRole_roleNull_ThrowUserUserException()
        {
            await userService.AddRole("testUser",null);
        }

        [TestMethod]
        [ExpectedException(typeof(RoleException))]
        public async Task When_AddRole_RoleEmpty_ThrowUserUserException()
        {
            await userService.AddRole("testUser",new Role());
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public async Task When_AddRole_userNotExists_ThrowUserNotFoundException()
        {
            repository.Exists("testUser").ReturnsForAnyArgs(false);
            await userService.AddRole("testUser", new Role("testing"));
        }

        [TestMethod]
        public async Task When_AddRole_Ok()
        {
            repository.Exists("testUser").ReturnsForAnyArgs(true);            
            await userService.AddRole("testUser", new Role("testing"));            
            await repository.Received(1).AddRole(Arg.Any<string>(), Arg.Any<Role>());
        }

        #endregion AddRole

        #region RemoveRole
        [TestMethod]
        [ExpectedException(typeof(UserArgumentException))]
        public async Task When_RemoveRole_userNull_ThrowUserArgumentException()
        {
            await userService.RemoveRole(null, null);
        }
        [TestMethod]
        [ExpectedException(typeof(UserArgumentException))]
        public async Task When_RemoveRole_roleNull_ThrowUserUserException()
        {
            await userService.RemoveRole("testUser", null);
        }

        [TestMethod]
        [ExpectedException(typeof(RoleException))]
        public async Task When_RemoveRole_RoleEmpty_ThrowUserUserException()
        {
            await userService.RemoveRole("testUser", new Role());
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public async Task When_RemoveRole_userNotExists_ThrowUserNotFoundException()
        {
            repository.Exists("testUser").ReturnsForAnyArgs(false);
            await userService.RemoveRole("testUser", new Role("testing"));
        }

        [TestMethod]
        public async Task When_RemoveRole_Ok()
        {
            repository.Exists("testUser").ReturnsForAnyArgs(true);
            await userService.RemoveRole("testUser", new Role("testing"));
            await repository.Received(1).RemoveRole(Arg.Any<string>(), Arg.Any<Role>());
        }

        #endregion AddRole
    }
}
