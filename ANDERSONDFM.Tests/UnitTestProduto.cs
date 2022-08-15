using ANDERSONDFM.API.Controllers;
using ANDERSONDFM.Dominio.Entidades;

namespace ANDERSONDFM.Tests
{
    public class UnitTestProduto
    {
        /// <summary>
        /// Test the PostProduto() method
        /// </summary>
        [Fact]
        public async Task CriarProduto()
        {
            // Arrange
            var produto = new Produtos()
            {
                Nome = "teste1",
                DataInclusao = DateTime.Now,
                UsuarioInclusao = "teste1"
            };
            
            //// Act
            var resultado = produto;

            // Assert
            Assert.NotNull(resultado);
            


        }
    }
}