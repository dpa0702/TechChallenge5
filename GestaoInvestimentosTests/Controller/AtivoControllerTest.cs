using AutoFixture;
using AutoFixture.AutoMoq;
using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosTests.Entities.Mock;
using GestaoInvestimentosWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace GestaoInvestimentosTests.Controller
{
    [TestClass]
    public class AtivoControllerTest
    {
        AtivoController? ativoController;
        private Mock<IAtivoService> _mockAtivoService;
        private readonly ILogger<AtivoController> _logger;

        [TestInitialize]
        public void Start()
        {
            _mockAtivoService = new Mock<IAtivoService>();

            ativoController = new AtivoController(_mockAtivoService.Object, _logger);
        }

        #region Get
        [TestMethod]
        public void GetAtivoById_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var ativo = autoFixture.Build<Ativo>()
                .With(x => x.Transacoes, default(ICollection<Transacao>?))
                .With(x => x.Id, id).Create();
            _mockAtivoService.Setup(service => service.GetAtivoByIdAsync(id)).Returns(ativo);

            // Act
            var result = ativoController?.Get(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void GetAtivoById_ReturnsBad_WhenPortfolioIsNull()
        {
            // Act
            var result = ativoController?.Get(1) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void GetAtivoById_ReturnsBad_WhenServiceThrowsException()
        {
            // Arrange
            var id = 1;
            _mockAtivoService.Setup(service => service.GetAtivoByIdAsync(id)).Throws(new Exception("Service exception"));

            // Act
            var result = ativoController?.Get(id) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual($"Service exception", result.Value);
        }
        #endregion Get

        #region Create
        [TestMethod]
        public void CreateAtivo_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            var ativoDto = new CreateAtivoDTO { Nome = ativoDtoMock.Nome, TipoAtivo = ativoDtoMock.TipoAtivo, Codigo = ativoDtoMock.Codigo };
            _mockAtivoService.Setup(service => service.TipoAtivoIsValid(It.IsAny<int>())).Returns(true);

            // Act
            var result = ativoController?.Create(ativoDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void CreateAtivo_ReturnsOk_WhenTipoAtivoTituloIsValid()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.TipoAtivo = TipoAtivo.Titulo;
            var ativoDto = new CreateAtivoDTO { Nome = ativoDtoMock.Nome, TipoAtivo = ativoDtoMock.TipoAtivo, Codigo = ativoDtoMock.Codigo };
            _mockAtivoService.Setup(service => service.TipoAtivoIsValid(It.IsAny<int>())).Returns(true);

            // Act
            var result = ativoController?.Create(ativoDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void CreateAtivo_ReturnsOk_WhenTipoAtivoCriptomoedaIsValid()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.TipoAtivo = TipoAtivo.Criptomoeda;
            var ativoDto = new CreateAtivoDTO { Nome = ativoDtoMock.Nome, TipoAtivo = ativoDtoMock.TipoAtivo, Codigo = ativoDtoMock.Codigo };
            _mockAtivoService.Setup(service => service.TipoAtivoIsValid(It.IsAny<int>())).Returns(true);

            // Act
            var result = ativoController?.Create(ativoDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void CreateAtivo_ReturnsOk_WhenTipoAtivoAcaoIsValid()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.TipoAtivo = TipoAtivo.Acao;
            var ativoDto = new CreateAtivoDTO { Nome = ativoDtoMock.Nome, TipoAtivo = ativoDtoMock.TipoAtivo, Codigo = ativoDtoMock.Codigo };
            _mockAtivoService.Setup(service => service.TipoAtivoIsValid(It.IsAny<int>())).Returns(true);

            // Act
            var result = ativoController?.Create(ativoDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Create

        #region Update
        [TestMethod]
        public void UpdateAtivo_ReturnsOk()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            var ativoDto = new UpdateAtivoDTO { Id = ativoDtoMock.Id, Nome = ativoDtoMock.Nome, TipoAtivo = ativoDtoMock.TipoAtivo, Codigo = ativoDtoMock.Codigo };
            _mockAtivoService.Setup(service => service.TipoAtivoIsValid(It.IsAny<int>())).Returns(true);

            // Act
            var result = ativoController?.Update(ativoDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Update

        #region Delete
        [TestMethod]
        public void DeleteAtivo_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            _mockAtivoService.Setup(service => service.DeleteAtivoAsync(id));

            // Act
            var result = ativoController?.Delete(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Delete
    }
}
