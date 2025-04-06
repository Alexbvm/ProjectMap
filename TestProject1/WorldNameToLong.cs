using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProjectMap.WebApi.Controllers;
using ProjectMap.WebApi.Models;
using ProjectMap.WebApi.Repositories;

namespace TestProject1;

[TestClass]

public class WorldNameToLong
{

    [TestMethod]

    public async Task Enviroment2DToLong()
    {
        //Arrange
        string validName = "MMWWMMWWMMWWMMWWMMWWMMWWML";//L is 26ste teken

        var environment2DRepository = new Mock<IEnvironment2DRepository>();
        var authenticationService = new Mock<IAuthenticationService>();
        var logger = new Mock<ILogger<Environment2DController>>();

        Environment2DController controller = new Environment2DController(authenticationService.Object, environment2DRepository.Object, logger.Object);
        Environment2D environment2D = new Environment2D { Name = validName };

        //Act
        var response = await controller.Add(environment2D);
        //Assert
        Assert.IsInstanceOfType(response, typeof(BadRequestResult));
    }


}