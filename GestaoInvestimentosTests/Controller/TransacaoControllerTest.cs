using AutoFixture.AutoMoq;
using AutoFixture;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoInvestimentosCore.Enums;

namespace GestaoInvestimentosTests.Controller
{
    [TestClass]
    public class TransacaoControllerTest
    {
        TransacaoController? transacaoController;
        private Mock<ITransacaoService> _mockTransacaoService;
        private readonly ILogger<TransacaoController> _logger;

        [TestInitialize]
        public void Start()
        {
            _mockTransacaoService = new Mock<ITransacaoService>();

            transacaoController = new TransacaoController(_mockTransacaoService.Object, _logger);
        }

        #region Get
        [TestMethod]
        public void GetTransacaoById_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var transacao = autoFixture.Build<Transacao>().With(x => x.Id, id).Create();
            _mockTransacaoService.Setup(service => service.GetTransacaoByIdAsync(id)).Returns(transacao);

            // Act
            var result = transacaoController?.Get(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void GetTransacaoById_ReturnsBad_WhenPortfolioIsNull()
        {
            // Act
            var result = transacaoController?.Get(1) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void GetTransacaoById_ReturnsBad_WhenServiceThrowsException()
        {
            // Arrange
            var id = 1;
            _mockTransacaoService.Setup(service => service.GetTransacaoByIdAsync(id)).Throws(new Exception("Service exception"));

            // Act
            var result = transacaoController?.Get(id) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual($"Service exception", result.Value);
        }
        #endregion Get

        #region Create
        [TestMethod]
        public void CreateTransacao_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var transacao = autoFixture.Build<Transacao>().With(x => x.Id, id).Create();
            _mockTransacaoService.Setup(service => service.GetTransacaoByIdAsync(id)).Returns(transacao);

            // Act
            var result = transacaoController?.Get(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Create

        #region Delete
        [TestMethod]
        public void DeleteTransacaoo_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var transacao = autoFixture.Build<Transacao>().With(x => x.Id, id).Create();
            _mockTransacaoService.Setup(service => service.GetTransacaoByIdAsync(id)).Returns(transacao);

            // Act
            var result = transacaoController?.Delete(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Delete

    }
}
