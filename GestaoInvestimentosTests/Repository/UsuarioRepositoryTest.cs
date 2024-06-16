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
    public class UsuarioRepositoryTest
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private UsuarioRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseInMemory")
                .Options;

            _context = new ApplicationDbContext();
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _repository = new UsuarioRepository(_context);
        }

        [TestMethod]
        public void GetById_ReturnsUsuario_WhenValidId()
        {
            // Arrange
            int idToFakeInsertAndSearch = 1;
            var autoFixture = new Fixture().Customize(new AutoMoqCustomization());
            var usuario = autoFixture.Build<Usuario>()
                .With(x => x.Id, idToFakeInsertAndSearch).Create();
            _context.Usuarios.Add(usuario);

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
            var usuario = autoFixture.Build<Usuario>()
                .With(x => x.Id, idToFakeInsert).Create();

            _context.Usuarios.Add(usuario);

            // Act
            var result = _repository.GetById(idToSearch);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UsuarioListByFilter_ReturnsUsuarios_WhenNoFilter()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void UsuarioListByFilter_ReturnsUsuarios_WhenFilterId()
        {
            // Act
            var result = _repository.GetAllAsync(1, null, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }


        [TestMethod]
        public void UsuarioListByFilter_ReturnsUsuarios_WhenFilterByIdThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(666, null, "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void UsuarioListByFilter_ReturnsUsuarios_WhenFilterByNomeThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, "666", "", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void UsuarioListByFilter_ReturnsUsuarios_WhenFilterByEmailThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, "666", "");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void UsuarioListByFilter_ReturnsUsuarios_WhenFilterBySenhaThatDoesntExistInTheList()
        {
            // Act
            var result = _repository.GetAllAsync(null, null, "", "666");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
