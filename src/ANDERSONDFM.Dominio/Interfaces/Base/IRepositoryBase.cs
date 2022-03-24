using System.Linq.Expressions;

namespace ANDERSONDFM.Dominio.Interfaces.Base
{
    public interface IRepositoryBase<T>
    {
        void Inserir(T entity);
        void InserirRange(List<T> entity);
        void Alterar(T entity, bool checkConcurrency = false, byte[] rowVersion = null);
        void Excluir(T entity);
        void ExcluirRange(List<T> entity);
        T ObterPorId(int id);
        int Salvar(string usuario);
        void Dispose();
        IEnumerable<T> Selecionar(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> SelecionarTodos(params Expression<Func<T, object>>[] includes);
        Task<bool> InserirAsync(T entidade);
        Task<bool> AlterarAsync(T entity);
        Task<bool> ExcluirAsync(T entity);
        Task<T> ObterPorIdAsync(int id);
        Task<int> SalvarAsync(string usuario);
    }
}
