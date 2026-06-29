using Microsoft.AspNetCore.Mvc;
using SampleWebApp.Controllers;
using Xunit;

namespace SampleWebApp.Tests;

public class HomeControllerTests
{
    [Fact]
    public void Index_ReturnsViewResult()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void About_ReturnsViewResult_WithMessage()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.About() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Your mobile-friendly movie ticket app.", result.ViewData["Message"]);
    }
}