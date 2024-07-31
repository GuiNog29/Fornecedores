using Fornecedores.Application.DTOs;

namespace Fornecedores.Application.Interfaces
{
    public interface IFornecedorService
    {
        Task<FornecedorDto> CadastrarFornecedor(FornecedorDto fornecedorDto);
        Task<FornecedorDto> AtualizarFornecedor(FornecedorDto fornecedorDto, int fornecedorId);
        Task<bool> ExcluirFornecedorPorId(int fornecedorId);
        Task<FornecedorDto> BuscarFornecedorPorId(int fornecedorId);
        Task<IEnumerable<FornecedorDto>> BuscarTodosFornecedores();
    }
}
