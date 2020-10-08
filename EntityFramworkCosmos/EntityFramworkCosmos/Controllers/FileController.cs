using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramworkCosmos.Services;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EntityFramworkCosmos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly StorageClientService StorageClientService;
        
        public FileController( StorageClientService storageClientService)
        {
            this.StorageClientService = storageClientService;
        }

        [HttpPost]
        public async Task<Guid> Upload()
        {
            byte[] array = new byte[Request.ContentLength.Value];
            MemoryStream memoryStream = new MemoryStream(array);
            await Request.Body.CopyToAsync(memoryStream);

            var guid = await StorageClientService.Upload(memoryStream);
            return guid.Value;
        }
        [HttpGet("{guid}")]
        public async Task Download(string guid)
        {
            
        }
    }
}
