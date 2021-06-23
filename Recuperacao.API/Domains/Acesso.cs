using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Domains
{
    public class Acesso : BaseDomain
    {
        public string TipoUsuario { get; set; }

        [NotMapped]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
