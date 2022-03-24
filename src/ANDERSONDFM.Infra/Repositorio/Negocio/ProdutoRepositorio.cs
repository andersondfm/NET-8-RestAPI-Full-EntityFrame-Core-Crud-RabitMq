using ANDERSONDFM.Dominio.Entidades;
using ANDERSONDFM.Dominio.Interfaces;
using ANDERSONDFM.Infra.Contextos;

namespace ANDERSONDFM.Infra.Repositorio.Negocio
{
    public class ProdutoRepositorio : RepositoryBase<Produtos>, IProdutoRepositorio
    {
        private readonly Contexto _contexto;
        public ProdutoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
