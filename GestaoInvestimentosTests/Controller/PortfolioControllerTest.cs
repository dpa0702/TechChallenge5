using AutoFixture.AutoMoq;
using AutoFixture;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using GestaoInvestimentosCore.Enums;
using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosTests.Entities.Mock;
using GestaoInvestimentosCore.DTO.Portfolio;
using Castle.Core.Resource;

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
            var portfolio = autoFixture.Build<Portfolio>()
                .With(x => x.Transacoes, default(ICollection<Transacao>?))
                .With(x => x.Usuario, default(Usuario?))
                .With(x => x.Id, id).Create();
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
            var portfolioDtoMock = new MockPortfolioDTO();
            var portfolioDto = new CreatePortfolioDTO { UsuarioId = portfolioDtoMock.UsuarioId, Nome = portfolioDtoMock.Nome, Descricao = portfolioDtoMock.Descricao };
            _mockPortfolioService.Setup(service => service.AddPortfolioAsync(portfolioDto));

            // Act
            var result = portfolioController?.Create(portfolioDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Create

        #region Update
        [TestMethod]
        public void UpdatePortfolio_ReturnsOk()
        {
            // Arrange
            var portfolioDtoMock = new MockPortfolioDTO();
            var portfolioDto = new UpdatePortfolioDTO { Id = portfolioDtoMock.Id, UsuarioId = portfolioDtoMock.UsuarioId, Nome = portfolioDtoMock.Nome, Descricao = portfolioDtoMock.Descricao };
            _mockPortfolioService.Setup(service => service.UpdatePortfolioAsync(portfolioDto));

            // Act
            var result = portfolioController?.Update(portfolioDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Update

        #region Delete
        [TestMethod]
        public void DeletePortfolio_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            _mockPortfolioService.Setup(service => service.DeletePortfolioAsync(id));

            // Act
            var result = portfolioController?.Delete(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Delete
    }
}
