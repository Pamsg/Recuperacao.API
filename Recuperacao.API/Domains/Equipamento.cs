using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Domains
{
    public class Equipamento : BaseDomain
    {
        public float NumeroSerie { get; set; }
        public string Marca { get; set; }
        public string Descricao { get; set; }
        public string AtivoInativo { get; set; }
        public string Tipo { get; set; }
        public int NumeroPatrimonio { get; set; }

        public Guid IdSala { get; set; }
        [ForeignKey("IdSala")]
        public Type TipoSala { get; set; }
    }
}
