using Fornecedores.Domain.Entities;

namespace Fornecedores.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor> CadastrarFornecedor(Fornecedor fornecedor);
        Task<Fornecedor> AtualizarFornecedor(Fornecedor fornecedor, int fornecedorId);
        Task<bool> ExcluirFornecedorPorId(int fornecedorId);
        Task<Fornecedor> BuscarFornecedorPorId(int fornecedorId);
        Task<IEnumerable<Fornecedor>> BuscarTodosFornecedores();
    }
}
