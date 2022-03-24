using ANDERSONDFM.Compartilhado.ViewModel;

namespace ANDERSONDFM.Aplicacao.Interfaces
{
    public interface IProdutoAppService
    {
        Task<RetornoPadrao>ObterTodosProdutos();
    }
}
