using Fornecedores.Domain.Entities;
using Fornecedores.Domain.Interfaces;
using Fornecedores.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Fornecedores.Application.Helpers;
using Fornecedores.Domain.Enums;

namespace Fornecedores.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly FornecedoresDbContext _context;

        public FornecedorRepository(FornecedoresDbContext context)
        {
            _context = context;
        }

        public async Task<Fornecedor> CadastrarFornecedor(Fornecedor fornecedor)
        {
            ValidarCamposFornecedor(fornecedor, ValidacaoPara.Cadastro);
            await ValidarFornecedorExistente(fornecedor);

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<Fornecedor> AtualizarFornecedor(Fornecedor fornecedor, int fornecedorId)
        {
            var fornecedorExistente = await ObterFornecedorPorId(fornecedorId);

            if (string.IsNullOrEmpty(fornecedor.Email))
                fornecedor.Email = fornecedorExistente.Email;

            ValidarCamposFornecedor(fornecedor, ValidacaoPara.Atualizacao);

            fornecedor.Id = fornecedorId;
            _context.Entry(fornecedorExistente).CurrentValues.SetValues(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedorExistente;
        }

        public async Task<bool> ExcluirFornecedorPorId(int fornecedorId)
        {
            var fornecedor = await ObterFornecedorPorId(fornecedorId);

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Fornecedor> BuscarFornecedorPorId(int fornecedorId)
        {
            var fornecedor = await ObterFornecedorPorId(fornecedorId);
            return fornecedor;
        }

        public async Task<IEnumerable<Fornecedor>> BuscarTodosFornecedores()
        {
            var fornecedores = await _context.Fornecedores.ToListAsync();
            if (fornecedores.Count == 0)
                throw new Exception($"Não foi encontrado nenhum fornecedor.");

            return fornecedores;
        }

        private async Task<Fornecedor> ObterFornecedorPorId(int fornecedorId)
        {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == fornecedorId);
            if (fornecedor == null)
                throw new KeyNotFoundException($"Fornecedor com ID {fornecedorId} não foi encontrado.");

            return fornecedor;
        }

        private async Task ValidarFornecedorExistente(Fornecedor fornecedor)
        {
            var fornecedorExistente = await _context.Fornecedores
                .FirstOrDefaultAsync(x => x.Email == fornecedor.Email || x.Nome == fornecedor.Nome);

            if (fornecedorExistente != null)
                throw new Exception($"Já existe um fornecedor cadastrado com esses dados.");
        }

        private void ValidarCamposFornecedor(Fornecedor fornecedor, ValidacaoPara tipoValidacao)
        {
            if (string.IsNullOrEmpty(fornecedor.Nome))
                throw new Exception("Nome deve ser preenchido.");

            if(tipoValidacao == ValidacaoPara.Cadastro)
            {
                if (string.IsNullOrEmpty(fornecedor.Email))
                    throw new Exception("E-mail deve ser preenchido.");

                if (!ValidadorEmail.VerifiaSeEmailEValido(fornecedor.Email))
                    throw new Exception("E-mail inválido.");
            }
        }
    }
}
