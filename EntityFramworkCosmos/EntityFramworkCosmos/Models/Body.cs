using Microsoft.Azure.CosmosRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Models
{
    public class Body
    {
        public string Message { get; set; }
        public string Version { get; set; }
        public Guid ContentId { get; set; }
    }
}
