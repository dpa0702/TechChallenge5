using Bogus;
using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
using GestaoInvestimentosTests.Entities.Mock;

namespace GestaoInvestimentosTests.Entities
{
    [TestClass]
    public class AtivoTest
    {
        private readonly Faker _faker;

        public AtivoTest()
        {
            _faker = new Faker();
        }

        #region Method Insert Tests
        [TestMethod]
        public void ValidateInsertAtivo_ShouldThrowException_WhenNomeIsEmptyOrNull()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.Nome = string.Empty;

            // Act
            var ativoDto = new CreateAtivoDTO { TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };
            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O Nome não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateInsertAtivo_ShouldThrowException_WhenCodigoIsEmptyOrNull()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.Codigo = string.Empty;

            // Act
            var ativoDto = new CreateAtivoDTO { TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };
            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O Codigo não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateInserAtivo_ShouldThrowException_WhenNomeIsBiggerThan100Chars()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.Nome = _faker.Random.String2(120);

            // Act
            var ativoDto = new CreateAtivoDTO { TipoAtivo = TipoAtivo.Titulo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };

            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O Nome deve ter no máximo 100 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateInsertAtivo_ShouldThrowException_WhenCodigoIsBiggerThan50Chars()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.Codigo = _faker.Random.String2(60);

            // Act
            var ativoDto = new CreateAtivoDTO { TipoAtivo = TipoAtivo.Titulo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };
            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O Codigo deve ter no máximo 50 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateInserAtivo_ShouldReturnSuccess()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();

            // Act
            var ativoDto = new CreateAtivoDTO { TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };

            // Assert
            Assert.AreEqual(ativoDtoMock.TipoAtivo, ativoDto.TipoAtivo);
            Assert.AreEqual(ativoDtoMock.Nome, ativoDto.Nome);
            Assert.AreEqual(ativoDtoMock.Codigo, ativoDto.Codigo);
        }
        #endregion

        #region Method Update Tests
        [TestMethod]
        public void ValidateUpdateAtivo_ShouldThrowException_WhenNomeIsEmptyOrNull()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.Nome = string.Empty;

            // Act
            var ativoDto = new UpdateAtivoDTO { Id = ativoDtoMock.Id, TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };
            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O Nome não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdateAtivo_ShouldThrowException_WhenCodigoIsEmptyOrNull()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.Codigo = string.Empty;

            // Act
            var ativoDto = new UpdateAtivoDTO { Id = ativoDtoMock.Id, TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };
            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O Codigo não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdateAtivo_ShouldThrowException_WhenNomeIsBiggerThan100Chars()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.Nome = _faker.Random.String2(120);

            // Act
            var ativoDto = new UpdateAtivoDTO { Id = ativoDtoMock.Id, TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };
            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O Nome deve ter no máximo 100 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdateAtivo_ShouldThrowException_WhenCodigoIsBiggerThan100Chars()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.Codigo = _faker.Random.String2(120);

            // Act
            var ativoDto = new UpdateAtivoDTO { Id = ativoDtoMock.Id, TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };
            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O Codigo deve ter no máximo 50 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdateAtivo_ShouldReturnSuccess()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();

            // Act
            var ativoDto = new UpdateAtivoDTO { Id = ativoDtoMock.Id, TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo};

            // Assert
            Assert.AreEqual(ativoDtoMock.Id, ativoDto.Id);
            Assert.AreEqual(ativoDtoMock.TipoAtivo, ativoDto.TipoAtivo);
            Assert.AreEqual(ativoDtoMock.Nome, ativoDto.Nome);
            Assert.AreEqual(ativoDtoMock.Codigo, ativoDto.Codigo);
        }
        #endregion
    }
}
