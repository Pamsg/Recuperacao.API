using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Domains
{
    public class Usuario : BaseDomain
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Guid IdAcesso { get; set; }
        [ForeignKey("IdAcesso")]
        public Type TipoUsuario { get; set; }
    }
}
