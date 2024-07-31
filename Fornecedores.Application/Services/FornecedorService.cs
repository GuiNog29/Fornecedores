using AutoMapper;
using Fornecedores.Application.DTOs;
using Fornecedores.Application.Interfaces;
using Fornecedores.Domain.Entities;
using Fornecedores.Domain.Interfaces;

namespace Fornecedores.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<FornecedorDto> CadastrarFornecedor(FornecedorDto fornecedorDto)
        {
            if (fornecedorDto == null)
                throw new ArgumentNullException(nameof(fornecedorDto));

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            fornecedor = await _fornecedorRepository.CadastrarFornecedor(fornecedor);
            return _mapper.Map<FornecedorDto>(fornecedor);
        }

        public async Task<FornecedorDto> AtualizarFornecedor(FornecedorDto fornecedorDto, int fornecedorId)
        {
            ValidarFornecedorId(fornecedorId);
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            var fornecedorAtualizado =  await _fornecedorRepository.AtualizarFornecedor(fornecedor, fornecedorId);
            return _mapper.Map<FornecedorDto>(fornecedorAtualizado);
        }

        public async Task<bool> ExcluirFornecedorPorId(int fornecedorId)
        {
            ValidarFornecedorId(fornecedorId);
            return await _fornecedorRepository.ExcluirFornecedorPorId(fornecedorId);
        }

        public async Task<FornecedorDto> BuscarFornecedorPorId(int fornecedorId)
        {
            ValidarFornecedorId(fornecedorId);
            var fornecedor = await _fornecedorRepository.BuscarFornecedorPorId(fornecedorId);
            return _mapper.Map<FornecedorDto>(fornecedor);
        }

        public async Task<IEnumerable<FornecedorDto>> BuscarTodosFornecedores()
        {
            var listaFornecedores = await _fornecedorRepository.BuscarTodosFornecedores();
            return _mapper.Map<IEnumerable<FornecedorDto>>(listaFornecedores);
        }

        private void ValidarFornecedorId(int fornecedorId)
        {
            if (fornecedorId <= 0)
                throw new ArgumentException("ID do fornecdor inválido", nameof(fornecedorId));
        }
    }
}
