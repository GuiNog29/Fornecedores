using Microsoft.AspNetCore.Mvc;
using Fornecedores.Application.DTOs;
using Fornecedores.Application.Interfaces;

namespace Fornecedores.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpPost("CadastrarFornecedor")]
        public async Task<IActionResult> CadastrarFornecedor([FromBody] FornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var fornecedor = await _fornecedorService.CadastrarFornecedor(fornecedorDto);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar cadastrar um fornecedor: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpPut("AtualizarFornecedor/{fornecedorId}")]
        public async Task<IActionResult> AtualizarFornecedor([FromBody] FornecedorDto fornecedorDto, int fornecedorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var fornecedorAtualizado = await _fornecedorService.AtualizarFornecedor(fornecedorDto, fornecedorId);
                return Ok(fornecedorAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar atualizar fornecedor: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpDelete("ExcluirFornecedorPorId/{fornecedorId}")]
        public async Task<IActionResult> ExcluirFornecedorPorId(int fornecedorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _fornecedorService.ExcluirFornecedorPorId(fornecedorId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar excluir fornecedor: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpGet("BuscarFornecedorPorId/{fornecedorId}")]
        public async Task<IActionResult> BuscarFornecedorPorId(int fornecedorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var fornecedor = await _fornecedorService.BuscarFornecedorPorId(fornecedorId);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar buscar fornecedor: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpGet("BuscarTodosFornecedores")]
        public async Task<IActionResult> BuscarTodosFornecedores()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var listaFornecedores = await _fornecedorService.BuscarTodosFornecedores();
                return Ok(listaFornecedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar buscar fornecedores: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }
    }
}
