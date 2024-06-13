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
using GestaoInvestimentosTests.Entities.Mock;
using GestaoInvestimentosCore.DTO.Portfolio;
using GestaoInvestimentosCore.DTO.Transacao;

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
        public void GetTransacaoById_ReturnsBad_WhenTransacaoIsNull()
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
            var transacaoDtoMock = new MockTransacaoDTO();
            var transacaoDto = new CreateTransacaoDTO { PortfolioId = transacaoDtoMock.PortfolioId, AtivoId = transacaoDtoMock.AtivoId, TipoTransacao = transacaoDtoMock.TipoTransacao, Preco = transacaoDtoMock.Preco, Quantidade = transacaoDtoMock.Quantidade, DataTransacao = transacaoDtoMock.DataTransacao };
            _mockTransacaoService.Setup(service => service.AddTransacaoAsync(transacaoDto));

            // Act
            var result = transacaoController?.Create(transacaoDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Create

        #region Update
        [TestMethod]
        public void UpdateTransacao_ReturnsOk()
        {
            // Arrange
            var transacaoDtoMock = new MockTransacaoDTO();
            var transacaoDto = new UpdateTransacaoDTO { PortfolioId = transacaoDtoMock.PortfolioId, AtivoId = transacaoDtoMock.AtivoId, TipoTransacao = transacaoDtoMock.TipoTransacao, Preco = transacaoDtoMock.Preco, Quantidade = transacaoDtoMock.Quantidade, DataTransacao = transacaoDtoMock.DataTransacao };
            _mockTransacaoService.Setup(service => service.UpdateTransacaoAsync(transacaoDto));

            // Act
            var result = transacaoController?.Update(transacaoDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Update

        #region Delete
        [TestMethod]
        public void DeleteTransacaoo_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            _mockTransacaoService.Setup(service => service.DeleteTransacaoAsync(id));

            // Act
            var result = transacaoController?.Delete(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Delete

    }
}
