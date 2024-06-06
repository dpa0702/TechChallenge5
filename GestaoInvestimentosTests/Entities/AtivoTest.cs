using Bogus;
using GestaoInvestimentosCore.DTO.Ativo;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosTests.Entities.Mock;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [TestMethod]
        public void ValidateInsertAtivo_ShouldThrowException_WhenTipoAtivoIsEmptyOrNull()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.TipoAtivo = string.Empty;

            // Act
            var ativoDto = new CreateAtivoDTO { TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };
            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O TipoAtivo não pode ser nulo nem vazio!", result.Message);
        }

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
        public void ValidateUpdateBook_ShouldThrowException_WhenTipoAtivoIsEmptyOrNull()
        {
            // Arrange
            var ativoDtoMock = new MockAtivoDTO();
            ativoDtoMock.TipoAtivo = string.Empty;

            // Act
            var ativoDto = new UpdateAtivoDTO { Id = ativoDtoMock.Id, TipoAtivo = ativoDtoMock.TipoAtivo, Nome = ativoDtoMock.Nome, Codigo = ativoDtoMock.Codigo };
            var result = Assert.ThrowsException<DomainException>(() => new Ativo(ativoDto));

            //Assert
            Assert.AreEqual("O TipoAtivo não pode ser nulo nem vazio!", result.Message);
        }

        [TestMethod]
        public void ValidateUpdateBook_ShouldThrowException_WhenNomeIsEmptyOrNull()
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
        public void ValidateUpdateBook_ShouldThrowException_WhenCodigoIsEmptyOrNull()
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
    }
}
