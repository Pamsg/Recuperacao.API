using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recuperacao.API.Domains
{
    public class BaseDomain
    {
        [Key]
        public Guid Id { get; set; }

    }
}
