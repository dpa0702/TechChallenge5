using Bogus;
using GestaoInvestimentosCore.DTO.Usuario;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosTests.Entities.Mock;

namespace GestaoInvestimentosTests.Entities
{
    [TestClass]
    public  class UsuarioTest
    {
        private readonly Faker _faker;

        public UsuarioTest()
        {
            _faker = new Faker();
        }

        #region Method Insert Tests
        [TestMethod]
        public void ValidateInsertUsuario_ShouldThrowException_WhenNomeIsEmptyOrNull()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();
            UsuarioDtoMock.Nome = string.Empty;

            // Act
            var UsuarioDto = new CreateUsuarioDTO { Nome = UsuarioDtoMock.Nome, Email = UsuarioDtoMock.Email, Senha = UsuarioDtoMock.Email };
            var result = Assert.ThrowsException<DomainException>(() => new Usuario(UsuarioDto));

            //Assert
            Assert.AreEqual("O Nome não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateInsertUsuario_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();
            UsuarioDtoMock.Email = string.Empty;

            // Act
            var UsuarioDto = new CreateUsuarioDTO { Nome = UsuarioDtoMock.Nome, Email = UsuarioDtoMock.Email, Senha = UsuarioDtoMock.Email };
            var result = Assert.ThrowsException<DomainException>(() => new Usuario(UsuarioDto));

            //Assert
            Assert.AreEqual("O Email não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateInserUsuario_ShouldThrowException_WhenNomeIsBiggerThan100Chars()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();
            UsuarioDtoMock.Nome = _faker.Random.String2(120);

            // Act
            var UsuarioDto = new CreateUsuarioDTO { Nome = UsuarioDtoMock.Nome, Email = UsuarioDtoMock.Email, Senha = UsuarioDtoMock.Email };

            var result = Assert.ThrowsException<DomainException>(() => new Usuario(UsuarioDto));

            //Assert
            Assert.AreEqual("O Nome deve ter no máximo 100 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateInsertUsuario_ShouldThrowException_WhenEmailIsBiggerThan100Chars()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();
            UsuarioDtoMock.Email = _faker.Random.String2(120);

            // Act
            var UsuarioDto = new CreateUsuarioDTO { Nome = UsuarioDtoMock.Nome, Email = UsuarioDtoMock.Email, Senha = UsuarioDtoMock.Email };
            var result = Assert.ThrowsException<DomainException>(() => new Usuario(UsuarioDto));

            //Assert
            Assert.AreEqual("O Email deve ter no máximo 100 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateInserUsuario_ShouldReturnSuccess()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();

            // Act
            var UsuarioDto = new CreateUsuarioDTO { Nome = UsuarioDtoMock.Nome, Email = UsuarioDtoMock.Email, Senha = UsuarioDtoMock.Senha };

            // Assert
            Assert.AreEqual(UsuarioDtoMock.Nome, UsuarioDto.Nome);
            Assert.AreEqual(UsuarioDtoMock.Email, UsuarioDto.Email);
            Assert.AreEqual(UsuarioDtoMock.Senha, UsuarioDto.Senha);
        }
        #endregion

        #region Method Update Tests
        [TestMethod]
        public void ValidateUpdateUsuario_ShouldThrowException_WhenNomeIsEmptyOrNull()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();
            UsuarioDtoMock.Nome = string.Empty;

            // Act
            var UsuarioDto = new UpdateUsuarioDTO { Id = UsuarioDtoMock.Id, Email = UsuarioDtoMock.Email, Senha = UsuarioDtoMock.Senha };
            var result = Assert.ThrowsException<DomainException>(() => new Usuario(UsuarioDto));

            //Assert
            Assert.AreEqual("O Nome não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdateUsuario_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();
            UsuarioDtoMock.Email = string.Empty;

            // Act
            var UsuarioDto = new UpdateUsuarioDTO { Id = UsuarioDtoMock.Id, Nome = UsuarioDtoMock.Nome, Senha = UsuarioDtoMock.Senha };
            var result = Assert.ThrowsException<DomainException>(() => new Usuario(UsuarioDto));

            //Assert
            Assert.AreEqual("O Email não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdateUsuario_ShouldThrowException_WhenNomeIsBiggerThan100Chars()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();
            UsuarioDtoMock.Nome = _faker.Random.String2(120);

            // Act
            var UsuarioDto = new UpdateUsuarioDTO { Id = UsuarioDtoMock.Id, Nome = UsuarioDtoMock.Nome, Email = UsuarioDtoMock.Email, Senha = UsuarioDtoMock.Senha };
            var result = Assert.ThrowsException<DomainException>(() => new Usuario(UsuarioDto));

            //Assert
            Assert.AreEqual("O Nome deve ter no máximo 100 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdateUsuario_ShouldThrowException_WhenEmailIsBiggerThan100Chars()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();
            UsuarioDtoMock.Email = _faker.Random.String2(120);

            // Act
            var UsuarioDto = new UpdateUsuarioDTO { Id = UsuarioDtoMock.Id, Email = UsuarioDtoMock.Email, Nome = UsuarioDtoMock.Nome, Senha = UsuarioDtoMock.Senha };
            var result = Assert.ThrowsException<DomainException>(() => new Usuario(UsuarioDto));

            //Assert
            Assert.AreEqual("O Email deve ter no máximo 100 caracteres!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdateUsuario_ShouldReturnSuccess()
        {
            // Arrange
            var UsuarioDtoMock = new MockUsuarioDTO();

            // Act
            var UsuarioDto = new UpdateUsuarioDTO { Id = UsuarioDtoMock.Id, Nome = UsuarioDtoMock.Nome, Email = UsuarioDtoMock.Email, Senha = UsuarioDtoMock.Senha };

            // Assert
            Assert.AreEqual(UsuarioDtoMock.Id, UsuarioDto.Id);
            Assert.AreEqual(UsuarioDtoMock.Nome, UsuarioDto.Nome);
            Assert.AreEqual(UsuarioDtoMock.Email, UsuarioDto.Email);
            Assert.AreEqual(UsuarioDtoMock.Senha, UsuarioDto.Senha);
        }
        #endregion
    }
}
