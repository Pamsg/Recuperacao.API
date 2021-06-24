using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Domains
{
    public class Sala : BaseDomain
    {
        public string Andar { get; set; }
        public string MetragemSala { get; set; }
        public string NomeSala { get; set; }
    }
}
