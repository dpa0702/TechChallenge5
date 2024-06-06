using AutoFixture.AutoMoq;
using AutoFixture;
using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoInvestimentosInfrastructure.Repositories;
using GestaoInvestimentosCore.Entities;

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
            int idToFakeInsertAndSearch = 100;

            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var ativo = autoFixture.Build<Ativo>().With(x => x.Transacoes, default(ICollection<Transacao>?))
                .With(x => x.Id, idToFakeInsertAndSearch)
                .With(x => x.TipoAtivo, "TipoAtivoA").Create();

            _context.Ativos.Add(ativo);
            _context.SaveChanges();

            // Act
            var result = _repository.GetById(idToFakeInsertAndSearch);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("TipoAtivoA", result.TipoAtivo);
        }

        [TestMethod]
        public void GetById_ReturnNull_WhenInvalidId()
        {
            // Arrange
            int idToFakeInsert = 1;
            int idToSearch = 666;

            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var ativo = autoFixture.Build<Ativo>().With(x => x.Transacoes, default(ICollection<Transacao>?)).With(x => x.Id, idToFakeInsert).Create();

            _context.Ativos.Add(ativo);

            // Act
            var result = _repository.GetById(idToSearch);

            // Assert
            Assert.IsNull(result);
        }
    }
}
