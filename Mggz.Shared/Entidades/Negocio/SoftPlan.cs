using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mggz.Shared.Entidades.Negocio
{
    public class SoftPlan
    {
        public int SoftPlanId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Meses { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; } = true;
        public int ClinicsCount { get; set; }
    }
}
