using AutoFixture.AutoMoq;
using AutoFixture;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosInfrastructure.Data;
using GestaoInvestimentosInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentosTests.Repository
{
    [TestClass]
    public class PortfolioRepositoryTest
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private PortfolioRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseInMemory")
                .Options;

            _context = new ApplicationDbContext();
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _repository = new PortfolioRepository(_context);
        }


        [TestMethod]
        public void GetById_ReturnsPortfolio_WhenValidId()
        {
            // Arrange
            int idToFakeInsertAndSearch = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var Portfolio = autoFixture.Build<Portfolio>()
                .With(x => x.Transacoes, default(ICollection<Transacao>?))
                .With(x => x.Usuario, default(Usuario?))
                .With(x => x.Id, idToFakeInsertAndSearch).Create();
            _context.Portfolios.Add(Portfolio);

            // Act
            var result = _repository.GetById(idToFakeInsertAndSearch);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById_ReturnNull_WhenInvalidId()
        {
            // Arrange
            int idToFakeInsert = 1;
            int idToSearch = 666;

            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var Portfolio = autoFixture.Build<Portfolio>()
                .With(x => x.Transacoes, default(ICollection<Transacao>?))
                .With(x => x.Usuario, default(Usuario?))
                .With(x => x.Id, idToFakeInsert).Create();

            _context.Portfolios.Add(Portfolio);

            // Act
            var result = _repository.GetById(idToSearch);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void PortfolioListByFilter_ReturnsPortfolios_WhenNoFilter()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void PortfolioListByFilter_ReturnsPortfolios_WhenFilterId()
        {
            // Act
            var result = _repository.GetAllAsync(1, null, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }


        [TestMethod]
        public void PortfolioListByFilter_ReturnsPortfolios_WhenFilterByIdThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(666, null, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void PortfolioListByFilter_ReturnsPortfolios_WhenFilterByTipoPortfolioThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, 666, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void PortfolioListByFilter_ReturnsPortfolios_WhenFilterByNomeThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, "666", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void PortfolioListByFilter_ReturnsPortfolios_WhenFilterByCodigoThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, "", "666");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
