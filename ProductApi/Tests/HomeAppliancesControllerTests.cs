using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


public class HomeAppliancesControllerTests
{
    private readonly Mock<IHomeApplianceRepository> _mockRepo;
    private readonly HomeAppliancesController _controller;

    public HomeAppliancesControllerTests()
    {
        _mockRepo = new Mock<IHomeApplianceRepository>();
        _controller = new HomeAppliancesController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetHomeAppliances_ReturnsActionResult_WithListOfHomeAppliances()
    {
        // Arrange
        var homeAppliances = new List<HomeAppliance> { new HomeAppliance(), new HomeAppliance() };
        _mockRepo.Setup(repo => repo.GetHomeAppliancesAsync()).ReturnsAsync(homeAppliances);

        // Act
        var result = await _controller.GetHomeAppliances();

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<HomeAppliance>>>(result);
        var returnValue = Assert.IsType<List<HomeAppliance>>(actionResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetHomeAppliance_ReturnsNotFound_WhenIdIsInvalid()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.GetHomeApplianceByIdAsync(It.IsAny<int>())).ReturnsAsync((HomeAppliance)null);

        // Act
        var result = await _controller.GetHomeAppliance(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    /// <summary>
    /// Tests that the GetHomeAppliance method returns a HomeAppliance object when a valid ID is provided.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Fact]
    public async Task GetHomeAppliance_ReturnsHomeAppliance_WhenIdIsValid()
    {
        // Arrange
        var homeAppliance = new HomeAppliance { Id = 1 };
        _mockRepo.Setup(repo => repo.GetHomeApplianceByIdAsync(1)).ReturnsAsync(homeAppliance);

        // Act
        var result = await _controller.GetHomeAppliance(1);

        // Assert
        var actionResult = Assert.IsType<ActionResult<HomeAppliance>>(result);
        var returnValue = Assert.IsType<HomeAppliance>(actionResult.Value);
        Assert.Equal(1, returnValue.Id);
    }

    [Fact]
    public async Task PutHomeAppliance_ReturnsNoContent_WhenUpdateIsSuccessful()
    {
        // Arrange
        var homeAppliance = new HomeAppliance { Id = 1 };
        _mockRepo.Setup(repo => repo.UpdateHomeApplianceAsync(1, homeAppliance)).ReturnsAsync(true);

        // Act
        var result = await _controller.PutHomeAppliance(1, homeAppliance);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task PutHomeAppliance_ReturnsBadRequest_WhenUpdateFails()
    {
        // Arrange
        var homeAppliance = new HomeAppliance { Id = 1 };
        _mockRepo.Setup(repo => repo.UpdateHomeApplianceAsync(1, homeAppliance)).ReturnsAsync(false);

        // Act
        var result = await _controller.PutHomeAppliance(1, homeAppliance);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task PostHomeAppliance_ReturnsCreatedAtAction_WithNewHomeAppliance()
    {
  
        var homeAppliance = new HomeAppliance { Id = 1 };
        _mockRepo.Setup(repo => repo.AddHomeApplianceAsync(homeAppliance)).ReturnsAsync(homeAppliance);


        var result = await _controller.PostHomeAppliance(homeAppliance);

        var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnValue = Assert.IsType<HomeAppliance>(actionResult.Value);
        Assert.Equal(1, returnValue.Id);
    }

    [Fact]
    public async Task DeleteHomeAppliance_ReturnsNoContent_WhenDeleteIsSuccessful()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.DeleteHomeApplianceAsync(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteHomeAppliance(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteHomeAppliance_ReturnsNotFound_WhenDeleteFails()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.DeleteHomeApplianceAsync(1)).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteHomeAppliance(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
