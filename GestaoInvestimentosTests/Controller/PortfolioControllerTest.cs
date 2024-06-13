using AutoFixture.AutoMoq;
using AutoFixture;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using GestaoInvestimentosCore.Enums;

namespace GestaoInvestimentosTests.Controller
{
    [TestClass]
    public class PortfolioControllerTest
    {
        PortfolioController? portfolioController;
        private Mock<IPortfolioService> _mockPortfolioService;
        private readonly ILogger<PortfolioController> _logger;

        [TestInitialize]
        public void Start()
        {
            _mockPortfolioService = new Mock<IPortfolioService>();

            portfolioController = new PortfolioController(_mockPortfolioService.Object, _logger);
        }

        #region Get
        [TestMethod]
        public void GetPortfolioById_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var portfolio = autoFixture.Build<Portfolio>().With(x => x.Transacoes, default(ICollection<Transacao>?)).With(x => x.Id, id).Create();
            _mockPortfolioService.Setup(service => service.GetPortfolioByIdAsync(id)).Returns(portfolio);

            // Act
            var result = portfolioController?.Get(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void GePortfolioById_ReturnsBad_WhenPortfolioIsNull()
        {
            // Act
            var result = portfolioController?.Get(1) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void GetPortfolioById_ReturnsBad_WhenServiceThrowsException()
        {
            // Arrange
            var id = 1;
            _mockPortfolioService.Setup(service => service.GetPortfolioByIdAsync(id)).Throws(new Exception("Service exception"));

            // Act
            var result = portfolioController?.Get(id) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual($"Service exception", result.Value);
        }
        #endregion Get

        #region Create
        [TestMethod]
        public void CreatePortfolio_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var portfolio = autoFixture.Build<Portfolio>().With(x => x.Id, id).Create();
            _mockPortfolioService.Setup(service => service.GetPortfolioByIdAsync(id)).Returns(portfolio);

            // Act
            var result = portfolioController?.Get(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Create

        #region Delete
        [TestMethod]
        public void DeletePortfolio_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var portfolio = autoFixture.Build<Portfolio>().With(x => x.Id, id).Create();
            _mockPortfolioService.Setup(service => service.GetPortfolioByIdAsync(id)).Returns(portfolio);

            // Act
            var result = portfolioController?.Delete(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Delete
    }
}
