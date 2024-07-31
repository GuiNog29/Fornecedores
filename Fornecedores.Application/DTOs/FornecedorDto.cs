using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Fornecedores.Application.DTOs
{
    public class FornecedorDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Required]
        public required string Nome { get; set; }
        public required string Email { get; set; }
    }
}
