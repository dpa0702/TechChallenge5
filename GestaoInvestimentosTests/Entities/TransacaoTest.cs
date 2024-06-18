using Bogus;
using GestaoInvestimentosCore.DTO.Transacao;
using GestaoInvestimentosCore.Entities;
using GestaoInvestimentosCore.Enums;
using GestaoInvestimentosTests.Entities.Mock;

namespace GestaoInvestimentosTests.Entities
{
    [TestClass]
    public class TransacaoTest
    {
        private readonly Faker _faker;

        public TransacaoTest()
        {
            _faker = new Faker();
        }

        #region Method Insert Tests
        [TestMethod]
        public void ValidateInserTransacao_ShouldReturnSuccessAtivoId()
        {
            // Arrange
            var TransacaoDtoMock = new MockTransacaoDTO();
            TransacaoDtoMock.AtivoId = 1;

            // Act
            var TransacaoDto = new CreateTransacaoDTO
            {
                AtivoId = TransacaoDtoMock.AtivoId,
                PortfolioId = TransacaoDtoMock.PortfolioId,
                TipoTransacao = TransacaoDtoMock.TipoTransacao,
                Preco = TransacaoDtoMock.Preco,
                Quantidade = TransacaoDtoMock.Quantidade,
                DataTransacao = TransacaoDtoMock.DataTransacao,
            };

            // Assert
            Assert.AreEqual(TransacaoDtoMock.DataTransacao, TransacaoDto.DataTransacao);
        }

        [TestMethod]
        public void ValidateInserTransacao_ShouldReturnSuccessPortfolioId()
        {
            // Arrange
            var TransacaoDtoMock = new MockTransacaoDTO();
            TransacaoDtoMock.PortfolioId = 1;

            // Act
            var TransacaoDto = new CreateTransacaoDTO
            {
                AtivoId = TransacaoDtoMock.AtivoId,
                PortfolioId = TransacaoDtoMock.PortfolioId,
                TipoTransacao = TransacaoDtoMock.TipoTransacao,
                Preco = TransacaoDtoMock.Preco,
                Quantidade = TransacaoDtoMock.Quantidade,
                DataTransacao = TransacaoDtoMock.DataTransacao,
            };

            // Assert
            Assert.AreEqual(TransacaoDtoMock.DataTransacao, TransacaoDto.DataTransacao);
        }

        [TestMethod]
        public void ValidateInserTransacao_ShouldReturnSuccessTipoTransacaoVenda()
        {
            // Arrange
            var TransacaoDtoMock = new MockTransacaoDTO();
            TransacaoDtoMock.TipoTransacao = TipoTransacao.Venda;

            // Act
            var TransacaoDto = new CreateTransacaoDTO
            {
                AtivoId = TransacaoDtoMock.AtivoId,
                PortfolioId = TransacaoDtoMock.PortfolioId,
                TipoTransacao = TransacaoDtoMock.TipoTransacao,
                Preco = TransacaoDtoMock.Preco,
                Quantidade = TransacaoDtoMock.Quantidade,
                DataTransacao = TransacaoDtoMock.DataTransacao,
            };

            // Assert
            Assert.AreEqual(TransacaoDtoMock.DataTransacao, TransacaoDto.DataTransacao);
        }

        [TestMethod]
        public void ValidateInserTransacao_ShouldReturnSuccessTipoTransacaoCompra()
        {
            // Arrange
            var TransacaoDtoMock = new MockTransacaoDTO();
            TransacaoDtoMock.TipoTransacao = TipoTransacao.Compra;

            // Act
            var TransacaoDto = new CreateTransacaoDTO
            {
                AtivoId = TransacaoDtoMock.AtivoId,
                PortfolioId = TransacaoDtoMock.PortfolioId,
                TipoTransacao = TransacaoDtoMock.TipoTransacao,
                Preco = TransacaoDtoMock.Preco,
                Quantidade = TransacaoDtoMock.Quantidade,
                DataTransacao = TransacaoDtoMock.DataTransacao,
            };

            // Assert
            Assert.AreEqual(TransacaoDtoMock.DataTransacao, TransacaoDto.DataTransacao);
        }

        [TestMethod]
        public void ValidateInserTransacao_ShouldReturnSuccessPreco()
        {
            // Arrange
            var TransacaoDtoMock = new MockTransacaoDTO();
            TransacaoDtoMock.Preco = 1000;

            // Act
            var TransacaoDto = new CreateTransacaoDTO
            {
                AtivoId = TransacaoDtoMock.AtivoId,
                PortfolioId = TransacaoDtoMock.PortfolioId,
                TipoTransacao = TransacaoDtoMock.TipoTransacao,
                Preco = TransacaoDtoMock.Preco,
                Quantidade = TransacaoDtoMock.Quantidade,
                DataTransacao = TransacaoDtoMock.DataTransacao,
            };

            // Assert
            Assert.AreEqual(TransacaoDtoMock.DataTransacao, TransacaoDto.DataTransacao);
        }

        [TestMethod]
        public void ValidateInserTransacao_ShouldReturnSuccessQuantidade()
        {
            // Arrange
            var TransacaoDtoMock = new MockTransacaoDTO();
            TransacaoDtoMock.Quantidade = 100;

            // Act
            var TransacaoDto = new CreateTransacaoDTO
            {
                AtivoId = TransacaoDtoMock.AtivoId,
                PortfolioId = TransacaoDtoMock.PortfolioId,
                TipoTransacao = TransacaoDtoMock.TipoTransacao,
                Preco = TransacaoDtoMock.Preco,
                Quantidade = TransacaoDtoMock.Quantidade,
                DataTransacao = TransacaoDtoMock.DataTransacao,
            };

            // Assert
            Assert.AreEqual(TransacaoDtoMock.DataTransacao, TransacaoDto.DataTransacao);
        }

        [TestMethod]
        public void ValidateInserTransacao_ShouldReturnSuccessDataTransacao()
        {
            // Arrange
            var TransacaoDtoMock = new MockTransacaoDTO();
            TransacaoDtoMock.DataTransacao = DateTime.Now;

            // Act
            var TransacaoDto = new CreateTransacaoDTO
            {
                AtivoId = TransacaoDtoMock.AtivoId,
                PortfolioId = TransacaoDtoMock.PortfolioId,
                TipoTransacao = TransacaoDtoMock.TipoTransacao,
                Preco = TransacaoDtoMock.Preco,
                Quantidade = TransacaoDtoMock.Quantidade,
                DataTransacao = TransacaoDtoMock.DataTransacao,
            };

            // Assert
            Assert.AreEqual(TransacaoDtoMock.DataTransacao, TransacaoDto.DataTransacao);
        }

        [TestMethod]
        public void ValidateInserTransacao_ShouldReturnSuccess()
        {
            // Arrange
            var TransacaoDtoMock = new MockTransacaoDTO();

            // Act
            var TransacaoDto = new CreateTransacaoDTO { AtivoId = TransacaoDtoMock.AtivoId,
                PortfolioId = TransacaoDtoMock.PortfolioId,
                TipoTransacao = TransacaoDtoMock.TipoTransacao,
                Preco = TransacaoDtoMock.Preco,
                Quantidade = TransacaoDtoMock.Quantidade,
                DataTransacao = TransacaoDtoMock.DataTransacao,
                };

            // Assert
            Assert.AreEqual(TransacaoDtoMock.AtivoId, TransacaoDto.AtivoId);
            Assert.AreEqual(TransacaoDtoMock.PortfolioId, TransacaoDto.PortfolioId);
            Assert.AreEqual(TransacaoDtoMock.TipoTransacao, TransacaoDto.TipoTransacao);
            Assert.AreEqual(TransacaoDtoMock.Preco, TransacaoDto.Preco);
            Assert.AreEqual(TransacaoDtoMock.Quantidade, TransacaoDto.Quantidade);
            Assert.AreEqual(TransacaoDtoMock.DataTransacao, TransacaoDto.DataTransacao);
        }
        #endregion
    }
}
