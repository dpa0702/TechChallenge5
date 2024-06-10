using AutoFixture;
using AutoFixture.AutoMoq;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GestaoInvestimentosTests.Controller
{
    [TestClass]
    public class AtivoControllerTest
    {
        AtivoController? ativoController;
        private Mock<IAtivoService> _mockAtivoService;

        [TestInitialize]
        public void Start()
        {
            _mockAtivoService = new Mock<IAtivoService>();

            ativoController = new AtivoController(_mockAtivoService.Object);
        }

        //[TestMethod]
        //public void GetAtivoById_ReturnsOk_WhenIdIsValid()
        //{
        //    // Arrange
        //    var id = 1;
        //    var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
        //    var ativo = autoFixture.Build<Ativo>().With(x => x.Transacoes, default(ICollection<Transacao>?)).With(x => x.Id, id).Create();
        //    _mockAtivoService.Setup(service => service.GetAtivoByIdAsync(id)).Returns(ativo);

        //    // Act
        //    var result = ativoController?.Get(id) as OkObjectResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(200, result.StatusCode);
        //}

        [TestMethod]
        public void GetAtivoById_ReturnsBad_WhenBookIsNull()
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
    }
}
