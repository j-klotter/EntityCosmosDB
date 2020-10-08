using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Models
{
    public class Case
    {
        public Guid Id { get; set; }
        public string Version { get; set; }
        public string RevisionNumber { get; set; }
        public string PartitionKey { get; set; }
    }
}
