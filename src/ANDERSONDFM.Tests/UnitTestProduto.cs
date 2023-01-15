using ANDERSONDFM.API.Controllers;
using ANDERSONDFM.Aplicacao.Servicos;
using ANDERSONDFM.Dominio.Entidades;
using ANDERSONDFM.Infra.Contextos;
using ANDERSONDFM.Infra.Repositorio.Negocio;
using Microsoft.EntityFrameworkCore;

namespace ANDERSONDFM.Tests
{
    public class UnitTestProduto
    {
        /// <summary>
        /// Test the GetProduto() method
        /// </summary>
        [Fact]
        public async Task GetProduto()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "Produtos")
                .Options;

            using var context = new Contexto(options);

            context.Add(new Produtos()
            {
                Nome = "teste1",
                DataInclusao = DateTime.Now,
                UsuarioInclusao = "teste1"
            });
            context.SaveChanges();
            var repository = new ProdutoRepositorio(context);
            var produtoservice = new ProdutoAppService(repository, null);
            var controller = new ProdutoController(produtoservice);

            //// Act
            var result = await controller.Get(1);
            // Assert
            Assert.NotNull(result);
        }
    }
}