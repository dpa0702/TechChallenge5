using AutoFixture.AutoMoq;
using AutoFixture;
using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using GestaoInvestimentosInfrastructure.Repositories;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;

namespace GestaoInvestimentosTests.Repository
{
    [TestClass]
    public class AtivoRepositoryTest
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private AtivoRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseInMemory")
                .Options;

            _context = new ApplicationDbContext();
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _repository = new AtivoRepository(_context);
        }

        [TestMethod]
        public void GetById_ReturnsAtivo_WhenValidId()
        {
            // Arrange
            int idToFakeInsertAndSearch = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var ativo = autoFixture.Build<Ativo>()
                .With(x => x.Id, idToFakeInsertAndSearch).Create();
            _context.Ativos.Add(ativo);

            // Act
            var result = _repository.GetById(idToFakeInsertAndSearch);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById_ReturnsAtivo_WhenValidTipoAtivoAcao()
        {
            // Arrange
            int idToFakeInsertAndSearch = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var ativo = autoFixture.Build<Ativo>()
                .With(x => x.Id, idToFakeInsertAndSearch)
                .With(x => x.TipoAtivo, TipoAtivo.Acao).Create();

            _context.Ativos.Add(ativo);

            // Act
            var result = _repository.GetById(idToFakeInsertAndSearch);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(TipoAtivo.Acao, result.TipoAtivo);
        }


        [TestMethod]
        public void GetById_ReturnNull_WhenInvalidId()
        {
            // Arrange
            int idToFakeInsert = 1;
            int idToSearch = 666;

            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var ativo = autoFixture.Build<Ativo>()
                .With(x => x.Transacoes, default(ICollection<Transacao>?))
                .With(x => x.Id, idToFakeInsert).Create();

            _context.Ativos.Add(ativo);

            // Act
            var result = _repository.GetById(idToSearch);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AtivoListByFilter_ReturnsAtivos_WhenNoFilter()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void AtivoListByFilter_ReturnsAtivos_WhenFilterId()
        {
            // Act
            var result = _repository.GetAllAsync(1, null, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void AtivoListByFilter_ReturnsAtivos_WhenFilterTipoAtivoTitulo()
        {
            // Act
            var result = _repository.GetAllAsync(null, TipoAtivo.Titulo.GetHashCode(), "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void AtivoListByFilter_ReturnsAtivos_WhenFilterTipoAtivoAcao()
        {
            // Act
            var result = _repository.GetAllAsync(null, TipoAtivo.Acao.GetHashCode(), "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void AtivoListByFilter_ReturnsAtivos_WhenFilterTipoAtivoCriptomoeda()
        {
            // Act
            var result = _repository.GetAllAsync(null, TipoAtivo.Criptomoeda.GetHashCode(), "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void AtivoListByFilter_ReturnsAtivos_WhenFilterByIdThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(666, null, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AtivoListByFilter_ReturnsAtivos_WhenFilterByTipoAtivoThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, 666, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AtivoListByFilter_ReturnsAtivos_WhenFilterByNomeThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, "666", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void AtivoListByFilter_ReturnsAtivos_WhenFilterByCodigoThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, "", "666");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
