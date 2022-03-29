using CarDealership.Data;
using CarDealership.Data.Models;
using Moq;
using WebCarDealership.Controllers;
using WebCarDealership.Requests;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCarDealershipTests
{
    public class OderControllerTests
    {
        private readonly Mock<IRepository> repoMock;
        private readonly OrderController controllerSut;
        public OderControllerTests()
        {
            repoMock = new Mock<IRepository>();
            controllerSut = new OrderController(repoMock.Object);
        }

        [Fact]
        public async Task GivenAValidRequestModel_WhenCallingPost_ThenGettingAResponse()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Alex Model"
            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenAnInvalidCarOfferId_WhenCallingPost_ThenGetNotFound()
        {
            //Arrange
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync((CarOffer)null);
            var requestModel = new OrderRequestModel();

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }
        [Fact]
        public async Task GivenAnInvalidCarOfferModel_WhenCallingPost_ThenGetBadRequest()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = null
            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        [Fact]
        public async Task GivenOrderQuantityBiggerThanAvailableStock_WhenCallingPost_ThenGetBadRequest()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Make = "Dacia",
                Model = "Spring",
                AvailableStock = 20
            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 23
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }
        [Fact]
        public async Task GivenOrderQuantitySmallerThanAvailableStock_WhenCallingPost_ThenGetResponse()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Make = "Dacia",
                Model = "Spring",
                AvailableStock = 20
            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 19
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().NotBeNull();
        }
    }
}