using AutoFixture.AutoMoq;
using AutoFixture;
using Bogus;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Interfaces.Services;
using GestaoInvestimentosCore.Services;
using Moq;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosTests.Entities.Mock;

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

        [TestMethod]
        public void UsuarioListByFilter_ShouldReturnSuccess()
        {
            // Arrange

            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            int idFilter = It.IsAny<int>();
            string nomeFilter = _faker.Random.String2(100);
            string emailfilter = _faker.Random.String2(100);
            string senhafilter = _faker.Random.String2(100);

            var usuarioList = new List<Usuario>()
            {
                autoFixture.Build<Usuario>().With(x => x.Id, idFilter).Create()
            };

            _mockUsuarioRepository.Setup(repo => repo.GetAllAsync(idFilter, nomeFilter, emailfilter, senhafilter)).Returns(usuarioList);

            // Act
            var result = _usuarioService.GetAllUsuariosAsync(idFilter, nomeFilter, emailfilter, senhafilter);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void UsuarioListByFilter_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            _mockUsuarioRepository.Setup(repo => repo.GetAllAsync(It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                               .Throws(new Exception("Repository exception"));

            // Act & Assert
            try
            {
                _usuarioService.GetAllUsuariosAsync(It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Erro na camada de serviço ao consultar Usuario por id. Mensagem de Erro: Repository exception", ex.Message);
            }
        }

        [TestMethod]
        public void InsertUsuario_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            var usuarioDtoMock = new MockUsuarioDTO();
            var usuarioDto = new CreateUsuarioDTO { Nome = usuarioDtoMock.Nome, Email = usuarioDtoMock.Email, Senha = usuarioDtoMock.Senha };

            _mockUsuarioRepository.Setup(repo => repo.Insert(It.IsAny<Usuario>())).Throws(new Exception("Repository exception"));

            // Act & Assert
            var exception = Assert.ThrowsException<Exception>(() => _usuarioService.AddUsuarioAsync(usuarioDto));
            Assert.AreEqual("Erro na camada de serviço ao inserir Usuario. Mensagem de Erro: Repository exception", exception.Message);
        }

        [TestMethod]
        public void UpdateUsuario_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            var usuarioDtoMock = new MockUsuarioDTO();
            var usuarioDto = new UpdateUsuarioDTO { Id = usuarioDtoMock.Id, Nome = usuarioDtoMock.Nome, Email = usuarioDtoMock.Email, Senha = usuarioDtoMock.Senha };

            _mockUsuarioRepository.Setup(repo => repo.Update(It.IsAny<Usuario>())).Throws(new Exception("Repository exception"));

            // Act & Assert
            var exception = Assert.ThrowsException<Exception>(() => _usuarioService.UpdateUsuarioAsync(usuarioDto));
            Assert.AreEqual("Erro na camada de serviço ao atualizar Usuario. Mensagem de Erro: Repository exception", exception.Message);
        }
    }
}
