using System.Linq.Expressions;
using ANDERSONDFM.Dominio.Interfaces.Base;
using ANDERSONDFM.Infra.Contextos;
using Microsoft.EntityFrameworkCore;

namespace ANDERSONDFM.Infra.Repositorio.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Contexto Contexto { get; }

        public RepositoryBase(Contexto contexto)
        {
            Contexto = contexto;
        }

        public virtual void Inserir(T entity)
        {
            Contexto.Set<T>().Add(entity);
        }

        public virtual void Alterar(T entity, bool checkConcurrency = false, byte[]? rowVersion = null)
        {
            Contexto.Entry(entity).State = EntityState.Modified;

            if (checkConcurrency)
                CheckConcurrency(entity, rowVersion);
        }

        public virtual void Excluir(T entity)
        {
            Contexto.Set<T>().Remove(entity);
        }

        public virtual void CheckConcurrency(T entity, byte[]? rowVersion)
        {
            Contexto.Entry(entity).OriginalValues["RowVersion"] = rowVersion;
        }

        public virtual void Detached(T entity)
        {
            Contexto.Entry(entity).State = EntityState.Detached;
        }

        public virtual T? ObterPorId(int id)
        {
            return Contexto.Set<T>().Find(id);
        }

        public IEnumerable<T> Selecionar(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = Contexto.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }


            return query.Where(predicate);
        }

        public IEnumerable<T> SelecionarTodos(params Expression<Func<T, object>>[] includes)
        {
            var query = Contexto.Set<T>().AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }


            return query;
        }

        public int Salvar(string usuario)
        {
            return Contexto.SaveChanges();
        }

        public virtual async Task<bool> InserirAsync(T entidade)
        {
            Contexto.Set<T>().Add(entidade);
            return await CommitAsync().ConfigureAwait(false) > 0;
        }

        public virtual async Task<bool> AlterarAsync(T entity)
        {
            Contexto.Entry(entity).State = EntityState.Modified;
            return await CommitAsync().ConfigureAwait(false) > 0;
        }

        public virtual async Task<bool> ExcluirAsync(T entity)
        {
            Contexto.Set<T>().Remove(entity);
            return await CommitAsync().ConfigureAwait(false) > 0;
        }

        public virtual async Task<T?> ObterPorIdAsync(int id)
        {
            return await Contexto.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task<int> SalvarAsync(string usuario)
        {
            return await Contexto.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> CommitAsync()
        {
            return await Contexto.SaveChangesAsync().ConfigureAwait(false);
        }

        public void InserirRange(List<T> entity)
        {
            Contexto.Set<T>().AddRange(entity);
        }

        public void ExcluirRange(List<T> entity)
        {
            Contexto.Set<T>().RemoveRange(entity);
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }
    }
}
