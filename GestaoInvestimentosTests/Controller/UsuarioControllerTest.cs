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

namespace GestaoInvestimentosTests.Controller
{
    [TestClass]
    public class UsuarioControllerTest
    {
        UsuarioController? usuarioController;
        private Mock<IUsuarioService> _mockUsuarioService;
        private readonly ILogger<UsuarioController> _logger;

        [TestInitialize]
        public void Start()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();

            usuarioController = new UsuarioController(_mockUsuarioService.Object, _logger);
        }

        #region Get
        [TestMethod]
        public void GeUsuarioById_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var usuario = autoFixture.Build<Usuario>().With(x => x.Id, id).Create();
            _mockUsuarioService.Setup(service => service.GetUsuarioByIdAsync(id)).Returns(usuario);

            // Act
            var result = usuarioController?.Get(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void GetUsuarioById_ReturnsBad_WhenPortfolioIsNull()
        {
            // Act
            var result = usuarioController?.Get(1) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void GetUsuarioById_ReturnsBad_WhenServiceThrowsException()
        {
            // Arrange
            var id = 1;
            _mockUsuarioService.Setup(service => service.GetUsuarioByIdAsync(id)).Throws(new Exception("Service exception"));

            // Act
            var result = usuarioController?.Get(id) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual($"Service exception", result.Value);
        }
        #endregion Get

        #region Create
        [TestMethod]
        public void CreateUsuario_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var usuario = autoFixture.Build<Usuario>().With(x => x.Id, id).Create();
            _mockUsuarioService.Setup(service => service.GetUsuarioByIdAsync(id)).Returns(usuario);

            // Act
            var result = usuarioController?.Get(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Create

        #region Delete
        [TestMethod]
        public void DeleteUsuario_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var usuario = autoFixture.Build<Usuario>().With(x => x.Id, id).Create();
            _mockUsuarioService.Setup(service => service.GetUsuarioByIdAsync(id)).Returns(usuario);

            // Act
            var result = usuarioController?.Delete(id) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
        #endregion Delete
    }
}
