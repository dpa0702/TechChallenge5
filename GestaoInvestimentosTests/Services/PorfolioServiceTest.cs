using AutoFixture.AutoMoq;
using AutoFixture;
using Bogus;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Interfaces.Repository;
using GestaoInvestimentosCore.Services;
using Moq;
using GestaoInvestimentosCore.DTO.Portfolio;
using GestaoInvestimentosTests.Entities.Mock;

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
            var Portfolio = autoFixture.Build<Portfolio>()
                .With(x => x.Transacoes, default(ICollection<Transacao>?))
                .With(x => x.Usuario, default(Usuario?))
                .With(x => x.Id, 1).Create();
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

        [TestMethod]
        public void PortfolioListByFilter_ShouldReturnSuccess()
        {
            // Arrange

            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            int idFilter = It.IsAny<int>();
            int idUsuarioFilter = It.IsAny<int>();
            string nomeFilter = _faker.Random.String2(100);
            string descricaofilter = _faker.Random.String2(100);

            var portfolioList = new List<Portfolio>()
            {
                autoFixture.Build<Portfolio>()
                .With(x => x.Transacoes, default(ICollection<Transacao>?))
                .With(x => x.Usuario, default(Usuario?))
                .With(x => x.Id, 1).Create()
            };

            _mockPortfolioRepository.Setup(repo => repo.GetAllAsync(idFilter, idUsuarioFilter, nomeFilter, descricaofilter)).Returns(portfolioList);

            // Act
            var result = _portfolioService.GetAllPortfoliosAsync(idFilter, idUsuarioFilter, nomeFilter, descricaofilter);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void PortfolioListByFilter_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            _mockPortfolioRepository.Setup(repo => repo.GetAllAsync(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                               .Throws(new Exception("Repository exception"));

            // Act & Assert
            try
            {
                _portfolioService.GetAllPortfoliosAsync(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>());
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Erro na camada de serviço ao consultar Portfolio por id. Mensagem de Erro: Repository exception", ex.Message);
            }
        }

        [TestMethod]
        public void InsertPortfolio_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            var portfolioDtoMock = new MockPortfolioDTO();
            var portfolioDto = new CreatePortfolioDTO { UsuarioId = portfolioDtoMock.UsuarioId, Nome = portfolioDtoMock.Nome, Descricao = portfolioDtoMock.Descricao };

            _mockPortfolioRepository.Setup(repo => repo.Insert(It.IsAny<Portfolio>())).Throws(new Exception("Repository exception"));

            // Act & Assert
            var exception = Assert.ThrowsException<Exception>(() => _portfolioService.AddPortfolioAsync(portfolioDto));
            Assert.AreEqual("Erro na camada de serviço ao inserir Portfolio. Mensagem de Erro: Repository exception", exception.Message);
        }

        [TestMethod]
        public void UpdatePortfolio_RepositoryThrowsException_ShouldReturnThrowsExceptionWithMessage()
        {
            // Arrange
            var portfolioDtoMock = new MockPortfolioDTO();
            var portfolioDto = new UpdatePortfolioDTO { Id = portfolioDtoMock.Id, UsuarioId = portfolioDtoMock.UsuarioId, Nome = portfolioDtoMock.Nome, Descricao = portfolioDtoMock.Descricao };

            _mockPortfolioRepository.Setup(repo => repo.Update(It.IsAny<Portfolio>())).Throws(new Exception("Repository exception"));

            // Act & Assert
            var exception = Assert.ThrowsException<Exception>(() => _portfolioService.UpdatePortfolioAsync(portfolioDto));
            Assert.AreEqual("Erro na camada de serviço ao atualizar Portfolio. Mensagem de Erro: Repository exception", exception.Message);
        }
    }
}
