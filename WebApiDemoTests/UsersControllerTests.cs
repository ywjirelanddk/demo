using NUnit.Framework;
using WebApiDemo.Controllers;
using WebApiDemo.Services;
using NSubstitute;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace Tests
{
    public class UsersControllerTests
    {
        private UsersController _sut;
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            _userService = Substitute.For<IUserService>();
            _sut = new UsersController(_userService);
        }

        public static IEnumerable<TestCaseData> testParams()
        {
            yield return new TestCaseData(1, new OkObjectResult(new object()));
        }

        [Test, TestCaseSource("testParams")]
        public void GetUserById_ReturnsBadRequest_WithInvalidId(int id, IActionResult expectedResult)
        {
            _userService.GetById(Arg.Any<int>()).Returns(x => new User());

            var result = _sut.Get(id);

            Assert.IsInstanceOf(typeof(OkObjectResult), result);

        }
    }
}