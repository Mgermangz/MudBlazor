using Mggz.Shared.Entidades.Negocio;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mggz.Shared.Entidades.Admin
{
    public class Usuario : IdentityUser
    {
        /// <summary>
        /// Identificador del país asociado al usuario.
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Apellido Paterno del usuario.
        public string APaterno { get; set; }

        /// <summary>
        /// Apellido Materno del usuario.
        public string MPaterno { get; set; }
        /// <summary>
        /// Indica si el Usuario está activo o no.
        /// </summary>
        public string UrlFoto { get; set; }
        /// <summary>
        /// Indica si el usuario está activo.
        /// </summary>
        public bool Activo { get; set; } = true;
        public int? EmpresaId { get; set; }
        public Empresa?  EmpresaRow { get; set; }
    }
}
