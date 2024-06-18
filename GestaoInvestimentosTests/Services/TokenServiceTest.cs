using AutoFixture.AutoMoq;
using AutoFixture;
using Bogus;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosCore.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoInvestimentosCore.DTO.Usuario;

namespace GestaoInvestimentosTests.Services
{
    [TestClass]
    public class TokenServiceTest
    {
        private Mock<ITokenService> _mockTokenService;
        private TokenService _tokenService;
        private Faker _faker;

        [TestInitialize]
        public void Setup()
        {
            _mockTokenService = new Mock<ITokenService>();
            _tokenService = new TokenService(_mockTokenService.Object);
            _faker = new Faker();
        }

        [TestMethod]
        public void GenerateToken_ShouldReturnSuccess()
        {
            // Arrange
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var loginUsuarioDTO = autoFixture.Build<LoginUsuarioDTO>().With(x => x.Senha, "1q2w3e4r@#").Create();
            _mockTokenService.Setup(service => service.GenerateToken(loginUsuarioDTO)).Returns(loginUsuarioDTO);

            // Act
            var result = _tokenService.GenerateToken(loginUsuarioDTO);

            // Assert
            Assert.AreEqual(loginUsuarioDTO, result);
        }
    }
}
