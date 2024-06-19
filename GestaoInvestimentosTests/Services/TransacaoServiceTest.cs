using AutoFixture.AutoMoq;
using AutoFixture;
using Bogus;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Services;
using Moq;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosTests.Services
{
    [TestClass]
    public class TransacaoServiceTest
    {
        private Mock<ITransacaoRepository> _mockTransacaoRepository;
        private TransacaoService _transacaoService;
        private Faker _faker;

        [TestInitialize]
        public void Setup()
        {
            _mockTransacaoRepository = new Mock<ITransacaoRepository>();
            _transacaoService = new TransacaoService(_mockTransacaoRepository.Object);
            _faker = new Faker();
        }

        [TestMethod]
        public void GetTransacaoById_ShouldReturnSuccess()
        {
            // Arrange
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var transacao = autoFixture.Build<Transacao>()
                .With(x => x.Ativo, default(Ativo?))
                .With(x => x.Portfolio, default(Portfolio?))
                .With(x => x.Id, 1).Create();
            _mockTransacaoRepository.Setup(service => service.GetById(It.IsAny<int>())).Returns(transacao);

            // Act
            var result = _transacaoService.GetTransacaoByIdAsync(It.IsAny<int>());

            // Assert
            Assert.AreEqual(transacao, result);
        }

        [TestMethod]
        public void GetTransacaoById_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            _mockTransacaoRepository.Setup(service => service.GetById(It.IsAny<int>())).Throws(new Exception("Repository exception"));

            // Act & Assert
            try
            {
                _transacaoService.GetTransacaoByIdAsync(It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Erro na camada de serviço ao consultar Transacao por id. Mensagem de Erro: Repository exception", ex.Message);
            }
        }
    }
}
