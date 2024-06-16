using AutoFixture.AutoMoq;
using AutoFixture;
using GestaoInvestimentosInfrastructure.Data;
using GestaoInvestimentosInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoInvestimentosCore.Entities;

namespace GestaoInvestimentosTests.Repository
{
    [TestClass]
    public class TransacaoRepositoryTest
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private TransacaoRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseInMemory")
                .Options;

            _context = new ApplicationDbContext();
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _repository = new TransacaoRepository(_context);
        }

        [TestMethod]
        public void GetById_ReturnsTransacao_WhenValidId()
        {
            // Arrange
            int idToFakeInsertAndSearch = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var transacao = autoFixture.Build<Transacao>()
                .With(x => x.Id, idToFakeInsertAndSearch).Create();
            _context.Transacoes.Add(transacao);

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
            var Transacao = autoFixture.Build<Transacao>()
                .With(x => x.Id, idToFakeInsert).Create();

            _context.Transacoes.Add(Transacao);

            // Act
            var result = _repository.GetById(idToSearch);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TransacaoListByFilter_ReturnsTransacaos_WhenFilterId()
        {
            // Act
            var result = _repository.GetAllAsync(1, null, null, null, null, null, "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }


        [TestMethod]
        public void TransacaoListByFilter_ReturnsTransacaos_WhenFilterByIdThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(666, null, null, null, null, null, "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TransacaoListByFilter_ReturnsTransacaos_WhenFilterByPortfolioIdThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, 666, null, null, null, null, "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TransacaoListByFilter_ReturnsTransacaos_WhenFilterAtivoIdThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, 666, null, null, null, "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TransacaoListByFilter_ReturnsTransacaos_WhenFilterByTipoThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, null, 666, null, null, "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TransacaoListByFilter_ReturnsTransacaos_WhenFilterByquantidadeThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, null, null, 100000, null, "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TransacaoListByFilter_ReturnsTransacaos_WhenFilterByPrecoThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, null, null, null, 100000, "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
