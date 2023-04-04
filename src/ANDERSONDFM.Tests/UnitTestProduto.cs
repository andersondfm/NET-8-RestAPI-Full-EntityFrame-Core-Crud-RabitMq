using ANDERSONDFM.API.Controllers;
using ANDERSONDFM.Aplicacao.Servicos;
using ANDERSONDFM.Dominio.Entidades;
using ANDERSONDFM.Infra.Contextos;
using ANDERSONDFM.Infra.Repositorio.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ANDERSONDFM.Tests
{
    public class UnitTestProduto
    {
        /// <summary>
        /// Produto Quando Existir
        /// </summary>
        [Fact]
        public async Task Get_Deve_Retornar_Produto_Quando_Existir()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "Produtos")
                .Options;

            using var context = new Contexto(options);

            var produto = new Produtos()
            {
                Nome = "teste1",
                DataInclusao = DateTime.Now,
                UsuarioInclusao = "teste1"
            };
            context.Add(produto);
            context.SaveChanges();

            var repository = new ProdutoRepositorio(context);
            var produtoservice = new ProdutoAppService(repository, null);
            var controller = new ProdutoController(produtoservice);

            // Act
            var result = await controller.Get(produto.Id);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = (OkObjectResult)result.Result;
            var produtoRetornado = (Produtos)okResult.Value;
            Assert.Equal(produto.Nome, produtoRetornado.Nome);
            Assert.Equal(produto.DataInclusao, produtoRetornado.DataInclusao);
            Assert.Equal(produto.UsuarioInclusao, produtoRetornado.UsuarioInclusao);
        }

        /// <summary>
        /// Produto Quando não Existir
        /// </summary>
        [Fact]
        public async Task Get_Deve_Retornar_NoContent_Quando_Nao_Existir()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "Produtos")
                .Options;

            using var context = new Contexto(options);

            context.Database.EnsureDeleted(); // Limpa o banco de dados
            context.Database.EnsureCreated(); // Cria um novo banco de dados vazio

            var repository = new ProdutoRepositorio(context);
            var produtoservice = new ProdutoAppService(repository, null);
            var controller = new ProdutoController(produtoservice);

            // Act
            var result = await controller.Get(1);

            // Assert
            Assert.IsType<NoContentResult>(result.Result);
        }

    }
}