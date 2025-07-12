using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mggz.Shared.DTOs.Oficiales
{
    public class PaisDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoTelefono { get; set; } = null!;
    }
}
