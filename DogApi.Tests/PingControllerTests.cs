using DogApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace DogsApi.Tests
{
    public class PingControllerTests
    {
        [Fact]
        public void GetPing_Returns_Name_And_Version()
        {
            // Arrange
            var controller = new PingController();

            // Act
            var actionResult = controller.Get();

            //Assert

            Assert.Equal(new ObjectResult(new { message = "Dogs house service. Version 1.0.1" }).ToString(), actionResult.ToString());

        }
    }
}
