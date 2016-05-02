using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Sagaru.Controllers;
using Sagaru.Models;
using Xunit;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Moq;
using Microsoft.Extensions.OptionsModel;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Http;

namespace Sagaru.Tests.ControllerTests
{
    public class ProjectsControllerTest
    {
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            ApplicationDbContext db = new ApplicationDbContext();
            var userManager = new FakeUserManager();

            HomeController controller = new HomeController(userManager, db);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }

    public class FakeUserManager : UserManager<ApplicationUser>
    {
        public FakeUserManager()
            : base(new Mock<IUserStore<ApplicationUser>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<ApplicationUser>>().Object,
                  new IUserValidator<ApplicationUser>[0],
                  new IPasswordValidator<ApplicationUser>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<ApplicationUser>>>().Object,
                  new Mock<IHttpContextAccessor>().Object)
        { }

        public override Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return Task.FromResult(IdentityResult.Success);
        }
    }

}
