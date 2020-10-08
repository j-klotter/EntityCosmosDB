using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Models
{
    public class Header
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime TimestampSend { get; set; }
        public DateTime TimestampReceive { get; set; }
        public string VersionNo { get; set; }
        public string? Subject { get; set; }
        public string Type { get; set; }
        public string RevisionNr { get; set; }
        public Guid CaseName { get; set; }
        public Guid CaseId { get; set; }
    }
}
