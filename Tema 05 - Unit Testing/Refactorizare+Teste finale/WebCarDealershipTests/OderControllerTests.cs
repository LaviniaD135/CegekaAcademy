using CarDealership.Data;
using CarDealership.Data.Models;
using Moq;
using WebCarDealership.Controllers;
using WebCarDealership.Requests;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCarDealership.Service;
using Microsoft.AspNetCore.Http;

namespace WebCarDealershipTests
{
    public class OderControllerTests
    {
       // private readonly Mock<IRepository> repoMock;
        private readonly Mock<IEntityService> entityMock;
        private readonly OrderController controllerSut;
        public OderControllerTests()
        {
          //  repoMock = new Mock<IRepository>();
            entityMock = new Mock<IEntityService>();
            controllerSut = new OrderController(entityMock.Object);
        }

        //[Fact]
        //public async Task GivenAValidRequestModel_WhenCallingPost_ThenGettingAResponse()
        //{
        //    //Arrange
        //    var offer = new CarOffer()
        //    {
        //        Id = 1,
        //        Model = "Alex Model"
        //    };
        //    repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

        //    var requestModel = new OrderRequestModel()
        //    {
        //        CarOfferId = 1
        //    };

        //    //Act
        //    var result = await controllerSut.Post(requestModel);

        //    //Assert
        //    result.Should().NotBeNull();
        //}

        //[Fact]
        //public async Task GivenAnInvalidCarOfferId_WhenCallingPost_ThenGetNotFound()
        //{
        //    //Arrange
        //    repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync((CarOffer)null);
        //    var requestModel = new OrderRequestModel();

        //    //Act
        //    var result = await controllerSut.Post(requestModel);

        //    //Assert
        //    result.Should().BeOfType<NotFoundObjectResult>();
        //}
        //[Fact]
        //public async Task GivenAnInvalidCarOfferModel_WhenCallingPost_ThenGetBadRequest()
        //{
        //    //Arrange
        //    var offer = new CarOffer()
        //    {
        //        Id = 1,
        //        Model = null
        //    };
        //    repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

        //    var requestModel = new OrderRequestModel()
        //    {
        //        CarOfferId = 1
        //    };

        //    //Act
        //    var result = await controllerSut.Post(requestModel);

        //    //Assert
        //    result.Should().BeOfType<BadRequestObjectResult>();
        //}
        //[Fact]
        //public async Task GivenOrderQuantityBiggerThanAvailableStock_WhenCallingPost_ThenGetBadRequest()
        //{
        //    //Arrange
        //    var offer = new CarOffer()
        //    {
        //        Id = 1,
        //        Make = "Dacia",
        //        Model = "Spring",
        //        AvailableStock = 20
        //    };
        //    repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

        //    var requestModel = new OrderRequestModel()
        //    {
        //        CarOfferId = 1,
        //        Quantity = 23
        //    };

        //    //Act
        //    var result = await controllerSut.Post(requestModel);

        //    //Assert
        //    result.Should().BeOfType<BadRequestObjectResult>();
        //}
        //[Fact]
        //public async Task GivenOrderQuantitySmallerThanAvailableStock_WhenCallingPost_ThenGetResponse()
        //{
        //    //Arrange
        //    var offer = new CarOffer()
        //    {
        //        Id = 1,
        //        Make = "Dacia",
        //        Model = "Spring",
        //        AvailableStock = 20
        //    };
        //    repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

        //    var requestModel = new OrderRequestModel()
        //    {
        //        CarOfferId = 1,
        //        Quantity = 19
        //    };

        //    //Act
        //    var result = await controllerSut.Post(requestModel);

        //    //Assert
        //    result.Should().NotBeNull();
        //}

        [Fact]
        public async Task GivenAValidModel_WhenCallingPost_ThenReturnOKResponse()
        {
            // Arrange
            entityMock.Setup(entityMock => entityMock.IsOrderRequestModelValid(It.IsAny<OrderRequestModel>())).ReturnsAsync(true);
            entityMock.Setup(entityMock => entityMock.CreateOrder(It.IsAny<OrderRequestModel>())).ReturnsAsync(new Order());
            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                CustomerId= 1,
                Quantity = 23
            };

            // Act
            var result = await controllerSut.Post(requestModel);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GivenAnInvalidModel_WhenCallingPost_ThenReturnBadRequestResponse()
        {
            // Arrange
            entityMock.Setup(entityMock => entityMock.IsOrderRequestModelValid(It.IsAny<OrderRequestModel>())).ReturnsAsync(false);
            var requestModel = new OrderRequestModel();

            // Act
            var result = await controllerSut.Post(requestModel);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task GivenFailedCreate_WhenCallingPost_ThenReturnInternalServerErrorResponse()
        {
            // Arrange
            entityMock.Setup(entityMock => entityMock.IsOrderRequestModelValid(It.IsAny<OrderRequestModel>())).ReturnsAsync(true);
            entityMock.Setup(entityMock => entityMock.CreateOrder(It.IsAny<OrderRequestModel>())).ReturnsAsync((Order)null);
            var requestModel = new OrderRequestModel();

            // Act
            var result = await controllerSut.Post(requestModel);

            // Assert
            result.Should().BeOfType<ObjectResult>(StatusCodes.Status500InternalServerError.ToString());
        }
    }
}
