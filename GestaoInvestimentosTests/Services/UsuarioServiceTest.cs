using AutoFixture.AutoMoq;
using AutoFixture;
using Bogus;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosCore.Services;
using Moq;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosTests.Services
{
    [TestClass]
    public class UsuarioServiceTest
    {
        private Mock<IUsuarioRepository> _mockUsuarioRepository;
        private Mock<ITokenService> _mockTokenService;
        private UsuarioService _usuarioService;
        private Faker _faker;

        [TestInitialize]
        public void Setup()
        {
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
            _mockTokenService = new Mock<ITokenService>();
            _usuarioService = new UsuarioService(_mockUsuarioRepository.Object, _mockTokenService.Object);
            _faker = new Faker();
        }

        [TestMethod]
        public void GetUsuarioById_ShouldReturnSuccess()
        {
            // Arrange
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var usuario = autoFixture.Build<Usuario>().With(x => x.Id, 1).Create();
            _mockUsuarioRepository.Setup(service => service.GetById(1)).Returns(usuario);

            // Act
            var result = _usuarioService.GetUsuarioByIdAsync(1);

            // Assert
            Assert.AreEqual(usuario, result);
        }

        [TestMethod]
        public void GetUsuarioById_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            _mockUsuarioRepository.Setup(service => service.GetById(1)).Throws(new Exception("Repository exception"));

            // Act & Assert
            try
            {
                _usuarioService.GetUsuarioByIdAsync(2);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Erro na camada de serviço ao consultar Usuarioo por id. Mensagem de Erro: Repository exception", ex.Message);
            }
        }
    }
}
