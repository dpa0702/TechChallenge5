using AutoFixture.AutoMoq;
using AutoFixture;
using Bogus;
using Moq;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Services;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosTests.Entities.Mock;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace GestaoInvestimentosTests.Services
{
    [TestClass]
    public class AtivoServiceTest
    {
        private Mock<IAtivoRepository> _mockAtivoRepository;
        private AtivoService _ativoService;
        private Faker _faker;

        [TestInitialize]
        public void Setup()
        {
            _mockAtivoRepository = new Mock<IAtivoRepository>();
            _ativoService = new AtivoService(_mockAtivoRepository.Object);
            _faker = new Faker();
        }

        [TestMethod]
        public void GetAtivoById_ShouldReturnSuccess()
        {
            // Arrange
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var ativo = autoFixture.Build<Ativo>().With(x => x.Transacoes, default(ICollection<Transacao>?)).With(x => x.Id, 1).Create();
            _mockAtivoRepository.Setup(service => service.GetById(It.IsAny<int>())).Returns(ativo);

            // Act
            var result = _ativoService.GetAtivoByIdAsync(It.IsAny<int>());

            // Assert
            Assert.AreEqual(ativo, result);
        }

        [TestMethod]
        public void GetAtivoById_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            _mockAtivoRepository.Setup(service => service.GetById(It.IsAny<int>())).Throws(new Exception("Repository exception"));

            // Act & Assert
            try
            {
                _ativoService.GetAtivoByIdAsync(It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Erro na camada de serviço ao consultar Ativo por id. Mensagem de Erro: Repository exception", ex.Message);
            }
        }

        [TestMethod]
        public void AtivoListByFilter_ShouldReturnSuccess()
        {
            // Arrange

            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            int idFilter = It.IsAny<int>();
            int idUsuarioFilter = It.IsAny<int>();
            string nomeFilter = _faker.Random.String2(100);
            string descricaofilter = _faker.Random.String2(100);

            var ativoList = new List<Ativo>()
    {
        autoFixture.Build<Ativo>().With(x => x.Transacoes, default(ICollection<Transacao>?)).With(x => x.Id, 1).Create()
    };

            _mockAtivoRepository.Setup(repo => repo.GetAllAsync(idFilter, idUsuarioFilter, nomeFilter, descricaofilter)).Returns(ativoList);

            // Act
            var result = _ativoService.GetAllAtivosAsync(idFilter, idUsuarioFilter, nomeFilter, descricaofilter);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void AtivoListByFilter_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            _mockAtivoRepository.Setup(repo => repo.GetAllAsync(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                               .Throws(new Exception("Repository exception"));

            // Act & Assert
            try
            {
                _ativoService.GetAllAtivosAsync(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Erro na camada de serviço ao consultar Ativo por id. Mensagem de Erro: Repository exception", ex.Message);
            }
        }

        [TestMethod]
        public void InsertAtivo_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            var ativoDto = new CreateAtivoDTO { Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };

            _mockAtivoRepository.Setup(repo => repo.Insert(It.IsAny<Ativo>())).Throws(new Exception("Repository exception"));

            // Act & Assert
            var exception = Assert.ThrowsException<Exception>(() => _ativoService.AddAtivoAsync(ativoDto));
            Assert.AreEqual("Erro na camada de serviço ao inserir Ativo. Mensagem de Erro: O Codigo deve ter no máximo 50 caracteres!", exception.Message);
        }

        [TestMethod]
        public void UpdateAtivo_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            var ativoDto = new UpdateAtivoDTO { Id = ativoDtoMock.Id, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };

            _mockAtivoRepository.Setup(repo => repo.Update(It.IsAny<Ativo>())).Throws(new Exception("Repository exception"));

            // Act & Assert
            var exception = Assert.ThrowsException<Exception>(() => _ativoService.UpdateAtivoAsync(ativoDto));
            Assert.AreEqual("Erro na camada de serviço ao atualizar Ativo. Mensagem de Erro: O Codigo deve ter no máximo 50 caracteres!", exception.Message);
        }
    }
}
