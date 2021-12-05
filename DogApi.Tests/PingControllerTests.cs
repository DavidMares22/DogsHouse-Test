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


        [Fact]
        public void GetPing_ManyTimes_Returns_429()
        {
            // Arrange
            var controller = new PingController();
             
            // Act
            for (int i = 0; i < 8; i++)
            {

            var actionResult = controller.Get();
            }

            IActionResult result = controller.Get();
            //Assert

            Assert.Equal(new ObjectResult(new { message = "429 Too Many Requests" }).ToString(), result.ToString());

        }
    }
}
