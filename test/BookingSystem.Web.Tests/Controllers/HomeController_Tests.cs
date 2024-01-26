using System.Threading.Tasks;
using BookingSystem.Models.TokenAuth;
using BookingSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace BookingSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: BookingSystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}