using AutoFixture.AutoMoq;
using AutoFixture;
using Bogus;
using Moq;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Services;
using GestaoInvestimentosCore.Entities;

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
    }
}
