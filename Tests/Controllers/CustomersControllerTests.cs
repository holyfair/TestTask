using AutoFixture.Xunit2;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository.Models.Customer;
using Repository.Repository;
using System.Threading.Tasks;
using Tests.Helpers;
using TestTask.Controllers;
using TestTask.Enums;
using TestTask.Models.Customer;
using Xunit;

namespace Tests.Controllers
{
    public class CustomersControllerTests
    {
        [Theory, AutoMoqData]
        public async Task CreateCustomerSuccessful(Mock<ICustomersRepository> repositoryMock, Mock<IMapper> mapperMock, CustomerBase model, CustomerModel record)
        {
            // Arrange
            var brandType = BrandType.MrGreen;
            var sut = new CustomersController(mapperMock.Object, repositoryMock.Object);
            mapperMock.Setup(svc => svc.Map<CustomerModel>(model)).Returns(record);
            repositoryMock.Setup(svc => svc.CreateAsync(record)).ReturnsAsync(record);

            // Act
            var result = await sut.CreateCustomer(model, brandType) as OkObjectResult;

            // Assert
            Assert.Equal(record, result.Value);
            repositoryMock.Verify(x => x.CreateAsync(record), Times.Once);
            mapperMock.Verify(svc => svc.Map<CustomerModel>(model), Times.Once);
        }
    }
}
