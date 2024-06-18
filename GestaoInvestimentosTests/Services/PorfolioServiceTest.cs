using AutoFixture.AutoMoq;
using AutoFixture;
using Bogus;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Services;
using Moq;

namespace GestaoInvestimentosTests.Services
{
    [TestClass]
    public class PorfolioServiceTest
    {
        private Mock<IPortfolioRepository> _mockPortfolioRepository;
        private PortfolioService _portfolioService;
        private Faker _faker;

        [TestInitialize]
        public void Setup()
        {
            _mockPortfolioRepository = new Mock<IPortfolioRepository>();
            _portfolioService = new PortfolioService(_mockPortfolioRepository.Object);
            _faker = new Faker();
        }

        [TestMethod]
        public void GetPortfolioById_ShouldReturnSuccess()
        {
            // Arrange
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var Portfolio = autoFixture.Build<Portfolio>().With(x => x.Id, 1).Create();
            _mockPortfolioRepository.Setup(service => service.GetById(It.IsAny<int>())).Returns(Portfolio);

            // Act
            var result = _portfolioService.GetPortfolioByIdAsync(It.IsAny<int>());

            // Assert
            Assert.AreEqual(Portfolio, result);
        }

        [TestMethod]
        public void GetPortfolioById_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            _mockPortfolioRepository.Setup(service => service.GetById(It.IsAny<int>())).Throws(new Exception("Repository exception"));

            // Act & Assert
            try
            {
                _portfolioService.GetPortfolioByIdAsync(It.IsAny<int>());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Erro na camada de serviço ao consultar Portfolio por id. Mensagem de Erro: Repository exception", ex.Message);
            }
        }
    }
}
