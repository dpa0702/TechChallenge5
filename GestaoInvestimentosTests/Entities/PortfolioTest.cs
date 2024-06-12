using Bogus;
using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.DTO.Portfolio;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
using GestaoInvestimentosTests.Entities.Mock;

namespace GestaoInvestimentosTests.Entities
{
    [TestClass]
    public class PortfolioTest
    {
        private readonly Faker _faker;

        public PortfolioTest()
        {
            _faker = new Faker();
        }

        #region Method Insert Tests
        [TestMethod]
        public void ValidateInsertPortfolio_ShouldThrowException_WhenNomeIsEmptyOrNull()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();
            PortfolioDtoMock.Nome = string.Empty;

            // Act
            var PortfolioDto = new CreatePortfolioDTO { UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };
            var result = Assert.ThrowsException<DomainException>(() => new Portfolio(PortfolioDto));

            //Assert
            Assert.AreEqual("O Nome não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateInsertPortfolio_ShouldThrowException_WhenDescricaoIsEmptyOrNull()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();
            PortfolioDtoMock.Descricao = string.Empty;

            // Act
            var PortfolioDto = new CreatePortfolioDTO { UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };
            var result = Assert.ThrowsException<DomainException>(() => new Portfolio(PortfolioDto));

            //Assert
            Assert.AreEqual("A Descricao não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateInserPortfolio_ShouldThrowException_WhenNomeIsBiggerThan100Chars()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();
            PortfolioDtoMock.Nome = _faker.Random.String2(120);

            // Act
            var PortfolioDto = new CreatePortfolioDTO { UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };

            var result = Assert.ThrowsException<DomainException>(() => new Portfolio(PortfolioDto));

            //Assert
            Assert.AreEqual("O Nome deve ter no máximo 100 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateInsertPortfolio_ShouldThrowException_WhenDescricaoIsBiggerThan50Chars()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();
            PortfolioDtoMock.Descricao = _faker.Random.String2(60);

            // Act
            var PortfolioDto = new CreatePortfolioDTO { UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };
            var result = Assert.ThrowsException<DomainException>(() => new Portfolio(PortfolioDto));

            //Assert
            Assert.AreEqual("A Descricao deve ter no máximo 50 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateInserPortfolio_ShouldReturnSuccess()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();

            // Act
            var PortfolioDto = new CreatePortfolioDTO { UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };

            // Assert
            Assert.AreEqual(PortfolioDtoMock.UsuarioId, PortfolioDto.UsuarioId);
            Assert.AreEqual(PortfolioDtoMock.Nome, PortfolioDto.Nome);
            Assert.AreEqual(PortfolioDtoMock.Descricao, PortfolioDto.Descricao);
        }
        #endregion

        #region Method Update Tests
        [TestMethod]
        public void ValidateUpdatePortfolio_ShouldThrowException_WhenNomeIsEmptyOrNull()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();
            PortfolioDtoMock.Nome = string.Empty;

            // Act
            var PortfolioDto = new UpdatePortfolioDTO { Id = PortfolioDtoMock.Id, UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };
            var result = Assert.ThrowsException<DomainException>(() => new Portfolio(PortfolioDto));

            //Assert
            Assert.AreEqual("O Nome não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdatePortfolio_ShouldThrowException_WhenDescricaoIsEmptyOrNull()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();
            PortfolioDtoMock.Descricao = string.Empty;

            // Act
            var PortfolioDto = new UpdatePortfolioDTO { Id = PortfolioDtoMock.Id, UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };
            var result = Assert.ThrowsException<DomainException>(() => new Portfolio(PortfolioDto));

            //Assert
            Assert.AreEqual("A Descricao não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdatePortfolio_ShouldThrowException_WhenNomeIsBiggerThan100Chars()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();
            PortfolioDtoMock.Nome = _faker.Random.String2(120);

            // Act
            var PortfolioDto = new UpdatePortfolioDTO { Id = PortfolioDtoMock.Id, UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };
            var result = Assert.ThrowsException<DomainException>(() => new Portfolio(PortfolioDto));

            //Assert
            Assert.AreEqual("O Nome deve ter no máximo 100 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdatePortfolio_ShouldThrowException_WhenDescricaoIsBiggerThan50Chars()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();
            PortfolioDtoMock.Descricao = _faker.Random.String2(60);

            // Act
            var PortfolioDto = new UpdatePortfolioDTO { Id = PortfolioDtoMock.Id, UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };
            var result = Assert.ThrowsException<DomainException>(() => new Portfolio(PortfolioDto));

            //Assert
            Assert.AreEqual("A Descricao deve ter no máximo 50 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdatePortfolio_ShouldReturnSuccess()
        {
            // Arrange
            var PortfolioDtoMock = new MockPortfolioDTO();

            // Act
            var PortfolioDto = new UpdatePortfolioDTO { Id = PortfolioDtoMock.Id, UsuarioId = PortfolioDtoMock.UsuarioId, Nome = PortfolioDtoMock.Nome, Descricao = PortfolioDtoMock.Descricao };

            // Assert
            Assert.AreEqual(PortfolioDtoMock.Id, PortfolioDto.Id);
            Assert.AreEqual(PortfolioDtoMock.UsuarioId, PortfolioDto.UsuarioId);
            Assert.AreEqual(PortfolioDtoMock.Nome, PortfolioDto.Nome);
            Assert.AreEqual(PortfolioDtoMock.Descricao, PortfolioDto.Descricao);
        }
        #endregion
    }
}
