using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using EntityFramworkCosmos.Models;

namespace EntityFramworkCosmos.Contracts
{
    public interface IAzureStorageClient
    {
        Task<ActionResult<Guid>> Upload(Stream s);
        Task<Stream> Download(BodyDTO bodydto);
    }
}
