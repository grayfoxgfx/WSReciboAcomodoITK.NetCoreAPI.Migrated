using Microsoft.AspNetCore.Mvc;
using WSReciboAcomodoITK.NetCoreAPI.API.Controllers;
using NUnit.Framework;

namespace WSReciboAcomodoITK.NetCoreAPI.Tests.AuthModule
{
    public class LoginControllerTests
    {
        [Test]
        public void Login_WithValidCredentials_ReturnsToken()
        {
            var controller = new LoginController();
            var request = new LoginRequest { Username = "admin", Password = "password" };
            var result = controller.Login(request) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value?.ToString(), Does.Contain("token"));
        }

        [Test]
        public void Login_WithInvalidCredentials_ReturnsUnauthorized()
        {
            var controller = new LoginController();
            var request = new LoginRequest { Username = "user", Password = "wrong" };
            var result = controller.Login(request);
            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }
    }
}
