using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Domains
{
    public class Sala : BaseDomain
    {
        public float Andar { get; set; }
        public float MetragemSala { get; set; }
        public string NomeSala { get; set; }
    }
}
